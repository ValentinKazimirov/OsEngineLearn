using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Необходимо для панельного бота				
using OsEngine.Entity;
using OsEngine.OsTrader.Panels.Attributes;
using OsEngine.OsTrader.Panels.Tab;
using OsEngine.OsTrader.Panels;
using OsEngine.Language;

/*
!!Это можно удалить когда скопируете имя бота и неймспейс!!


namespace OsEngine.Robots.GreyCardinal
{
    internal class TabSample
    {
    }
}

*/

/*
Description
Важно! Описания кешируются. если не видите свое описание - удалите файл 
project\OsEngine\bin\Debug\BotsDescriprion.txt 
при старте создаст заново и описание появится
Ниже измените описание своего бота

My super bot
*/

namespace OsEngine.Robots.MyNamespace
{
    [Bot("MyNameBot")] // Имя бота в списке ботов

    internal class MyNameBot : BotPanel
    {

        private BotTabSimple _tabSimple; // Закладка с данными бота

        // опциональные параметры бота
        private StrategyParameterBool isActive;
        private StrategyParameterDecimal volumeParam;
        private StrategyParameterInt percentSL, percentTP;

        // Обязательные переопределяемые функции 
        public override string GetNameStrategyType()
        {
            return "MyNameBot";
        }

        public override void ShowIndividualSettingsDialog()
        {

        }

        // Constructor
        public MyNameBot(string name, StartProgram startProgram) : base(name, startProgram)
        {
            Description = "My super bot";

            // Названия переменных на разных языках
            var nameIsActive = OsLocalization.ConvertToLocString(
            "Eng:Is Active_" +
            "Ru:Активен_");
            var nameVolume = OsLocalization.ConvertToLocString(
            "Eng:Volume_" +
            "Ru:Объем_");
            var namePercentToStopLost = OsLocalization.ConvertToLocString(
            "Eng:Percent to StopLost_" +
            "Ru:Процентов до StopLost_");

            var namePercentToTakeProfit = OsLocalization.ConvertToLocString(
            "Eng:Percent to TakeProfit_" +
            "Ru:Процентов до TakeProfit_");

            TabCreate(BotTabType.Simple); _tabSimple = TabsSimple[0];

            // Events события
            _tabSimple.NewTickEvent += Strateg_tab_NewTickEvent; // Пришел новый тик в рынке
            _tabSimple.CandleFinishedEvent += Strateg_tab_CandleFinishedEvent; // свечка сформировалась
            _tabSimple.MarketDepthUpdateEvent += Strateg_tab_MarketDepthUpdateEvent; // Изменился стакан
            _tabSimple.PositionOpeningSuccesEvent += Strateg_tab_PositionOpeningSuccesEvent; // Позиция открылась успешно

            // Params Параметры
            isActive = CreateParameter(nameIsActive, true);
            // Параметры которые могут быть оптимизированы. Имя, значение по умолчанию, далее для оптимизатора: минимум, максимум, шаг
            volumeParam = CreateParameter(nameVolume, 1.0m, 1.0m, 10.0m, 1.0m);
            percentSL = CreateParameter(namePercentToStopLost, 1, 1, 100, 1);
            percentTP = CreateParameter(namePercentToTakeProfit, 2, 1, 100, 1);

        }

        // Follow opening positions событие позиция открыта
        private void Strateg_tab_PositionOpeningSuccesEvent(Position position)
        {
            trallingPosition(position, _tabSimple);
        }

        // Двигаем стопы за ценой
        private void trallingPosition(Position position, BotTabSimple tab)
        {
            decimal _newStopPrice = 0, _newProfitPrice = 0;
            if (position.Direction == Side.Buy)
            {
                _newStopPrice = tab.PriceBestBid * (1 - percentSL.ValueInt / 100);
                if (_newStopPrice > position.StopOrderPrice)
                {
                    tab.CloseAtStop(position, _newStopPrice, _newStopPrice);
                }
                _newProfitPrice = tab.PriceBestBid + percentTP.ValueInt * tab.Securiti.PriceStep;
                if (_newProfitPrice > position.ProfitOrderPrice)
                {
                    tab.CloseAtProfit(position, _newProfitPrice, _newProfitPrice);
                }
            }
            if (position.Direction == Side.Sell)
            {
                _newStopPrice = tab.PriceBestAsk + (1 + percentSL.ValueInt / 100);
                if (position.StopOrderPrice == 0 || _newStopPrice < position.StopOrderPrice)
                    tab.CloseAtStop(position, _newStopPrice, _newStopPrice);
                _newProfitPrice = tab.PriceBestAsk - (1 - percentTP.ValueInt / 100);
                if (position.ProfitOrderPrice == 0 || _newProfitPrice < position.ProfitOrderPrice)
                {
                    tab.CloseAtProfit(position, _newProfitPrice, _newProfitPrice);
                }
            }
        }

        // Logics for enter position
        private void Strateg_tab_CandleFinishedEvent(List<Candle> candels)
        {
            if (isActive.ValueBool == false) { return; }

            List<Position> positions = _tabSimple.PositionsOpenAll;

            if (positions.Count == 0)
            {
                // Открытых нет
                // Простой алгоритм -молот 
                bool candelUp = candels[candels.Count - 1].IsUp;
                bool candelDown = candels[candels.Count - 1].IsDown;
                decimal body = candels[candels.Count - 1].Body;
                decimal upShadow = candels[candels.Count - 1].ShadowTop;
                decimal downShadow = candels[candels.Count - 1].ShadowBottom;
                if (candelUp && body < downShadow / 2 && body > upShadow)
                {
                    _tabSimple.BuyAtMarket(1);
                }
                if (candelDown && body < upShadow / 2 && body > downShadow)
                {
                    _tabSimple.SellAtMarket(1);
                }
            }
            else
            {
                foreach (var position in positions)// Перебираем каждую открытую
                {
                    trallingPosition(position, _tabSimple);
                }
            }
        }

        // По стакану сделок появилось событие
        private void Strateg_tab_MarketDepthUpdateEvent(MarketDepth marketDepth)
        {
            if (!_tabSimple.IsConnected)
            {
                return;
            }

        }

        // Получено новое событие по свечке
        private void Strateg_tab_NewTickEvent(Trade trade)
        {
            if (!_tabSimple.IsConnected)
            {
                return;
            }
            // Тут пишите логику бота при поступлении события изменение цены
        }

    }
}


