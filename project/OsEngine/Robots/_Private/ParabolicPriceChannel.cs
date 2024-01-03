using OsEngine.Entity;
using OsEngine.Indicators;
using OsEngine.OsTrader.Panels;
using OsEngine.OsTrader.Panels.Attributes;
using OsEngine.OsTrader.Panels.Tab;
using OsEngine.Robots;
using System;
using System.Collections.Generic;
using System.Drawing;

[Bot("ParabolicPriceChannel")]
class ParabolicPriceChannel : BotPanel
{
    BotTabSimple _tab;

    StrategyParameterString _Regime;

    StrategyParameterDecimal _Slippage;

    StrategyParameterDecimal _VolumeOnPosition;
    StrategyParameterString _VolumeRegime;
    StrategyParameterInt _VolumeDecimals;

    StrategyParameterTimeOfDay _TimeStart;
    StrategyParameterTimeOfDay _TimeEnd;

    Aindicator _SmaFilter;
    StrategyParameterBool _SmaPositionFilterIsOn;
    StrategyParameterInt _SmaLengthFilter;
    StrategyParameterBool _SmaSlopeFilterIsOn;

    Aindicator _ParabolicPC;
    StrategyParameterInt _PeriodUpPPC;
    StrategyParameterInt _PeriodDownPPC;
    StrategyParameterString _PeriodVolatility;
    StrategyParameterInt _AveragingPeriod;
    StrategyParameterDecimal _MultiVol;

    StrategyParameterLabel label1;
    StrategyParameterLabel label2;
    StrategyParameterLabel label3;
    StrategyParameterLabel label4;
    //?StrategyParameterLabel label5;
    //? StrategyParameterLabel label6;
    StrategyParameterLabel label7;
    //?StrategyParameterLabel label8;

    decimal lastPriceClose;
    decimal lastPriceChannelUp;
    decimal lastPriceChannelDown;
    decimal lastParabolicStop;

    public ParabolicPriceChannel(string name, StartProgram startProgram) : base(name, startProgram)
    {
        TabCreate(BotTabType.Simple);
        _tab = TabsSimple[0];
        var _pageName = "Base";
        _Regime = CreateParameter("Regime", "Off", new[] { "Off", "On", "OnlyLong", "OnlyShort", "OnlyClosePosition" }, _pageName);

        label2 = CreateParameterLabel("label2", "--------", "--------", 10, 5, Color.White, _pageName);
        _VolumeRegime = CreateParameter("Volume type", "Contract currency", new[] { "Number of contracts", "Contract currency", "% of the total portfolio" }, _pageName);
        _VolumeDecimals = CreateParameter("Number of Digits after the decimal point in the volume", 2, 1, 50, 4, _pageName);
        _VolumeOnPosition = CreateParameter("Volume", 10, 1.0m, 50, 4, _pageName);

        label1 = CreateParameterLabel("label1", "--------", "--------", 10, 5, Color.White, _pageName);
        _Slippage = CreateParameter("Slippage %", 0m, 0, 20, 1, _pageName);

        label3 = CreateParameterLabel("label3", "--------", "--------", 10, 5, Color.White, _pageName);
        _TimeStart = CreateParameterTimeOfDay("Start Trade Time", 0, 0, 0, 0, _pageName);
        _TimeEnd = CreateParameterTimeOfDay("End Trade Time", 24, 0, 0, 0, _pageName);
        _pageName = "Indicators settings";
        _PeriodUpPPC = CreateParameter("Period Up line Parabolic Price Channel", 50, 50, 200, 25, _pageName);
        _PeriodDownPPC = CreateParameter("Period Down Parabolic Price Channel", 50, 50, 200, 25, _pageName);
        label4 = CreateParameterLabel("label4", "--------", "--------", 10, 5, Color.White, _pageName);

        _PeriodVolatility = CreateParameter("Volatility calculation period", "Hour", new[] { "Minute", "Hour", "Day", "Week", "Month" }, _pageName);
        _AveragingPeriod = CreateParameter("Averaging Period Volatility", 15, 50, 200, 5, _pageName);
        _MultiVol = CreateParameter("Volatility multi", 0.2m, 3, 5, 1, _pageName);



        _ParabolicPC = IndicatorsFactory.CreateIndicatorByName(nameClass: "ParabolicPriceChannel_indicator", name: name + "ParabolicPC", canDelete: false);
        if(null == _ParabolicPC)
        {
            return;
        }
        _ParabolicPC = (Aindicator)_tab.CreateCandleIndicator(_ParabolicPC, nameArea: "Prime");
        _ParabolicPC.ParametersDigit[0].Value = _PeriodUpPPC.ValueInt;
        _ParabolicPC.ParametersDigit[1].Value = _PeriodDownPPC.ValueInt;
        ((IndicatorParameterString)_ParabolicPC.Parameters[2]).ValueString = _PeriodVolatility.ValueString;
        _ParabolicPC.ParametersDigit[2].Value = _AveragingPeriod.ValueInt;
        _ParabolicPC.ParametersDigit[3].Value = _MultiVol.ValueDecimal;
        _ParabolicPC.Save();

        _pageName = "Filter parameters";
        _SmaLengthFilter = CreateParameter("Sma Length Filter", 100, 10, 500, 1, _pageName);
        _SmaPositionFilterIsOn = CreateParameter("Is SMA Filter On", false, _pageName);
        _SmaSlopeFilterIsOn = CreateParameter("Is Sma Slope Filter On", false, _pageName);

        _SmaFilter = IndicatorsFactory.CreateIndicatorByName(nameClass: "Sma", name: name + "Sma_Filter", canDelete: false);
        _SmaFilter = (Aindicator)_tab.CreateCandleIndicator(_SmaFilter, nameArea: "Prime");
        _SmaFilter.DataSeries[0].Color = System.Drawing.Color.Azure;
        _SmaFilter.ParametersDigit[0].Value = _SmaLengthFilter.ValueInt;
        _SmaFilter.Save();

        StopOrActivateIndicators();

        ParametrsChangeByUser += Bot_ParametrsChangeByUser;
        _tab.CandleFinishedEvent += _tab_CandleFinishedEvent;
        Bot_ParametrsChangeByUser();

    }

    private void Bot_ParametrsChangeByUser()
    {
        StopOrActivateIndicators();

        if (_ParabolicPC.ParametersDigit[0].Value != _PeriodUpPPC.ValueInt ||
        _ParabolicPC.ParametersDigit[1].Value != _PeriodDownPPC.ValueInt ||
        ((IndicatorParameterString)_ParabolicPC.Parameters[2]).ValueString != _PeriodVolatility.ValueString ||
        _ParabolicPC.ParametersDigit[2].Value != _AveragingPeriod.ValueInt ||
        _ParabolicPC.ParametersDigit[3].Value != _MultiVol.ValueDecimal)
        {
            _ParabolicPC.ParametersDigit[0].Value = _PeriodUpPPC.ValueInt;
            _ParabolicPC.ParametersDigit[1].Value = _PeriodDownPPC.ValueInt;
            ((IndicatorParameterString)_ParabolicPC.Parameters[2]).ValueString = _PeriodVolatility.ValueString;
            _ParabolicPC.ParametersDigit[2].Value = _AveragingPeriod.ValueInt;
            _ParabolicPC.ParametersDigit[3].Value = _MultiVol.ValueDecimal;
            _ParabolicPC.Reload();
            _ParabolicPC.Save();
        }

        if (_SmaFilter.ParametersDigit[0].Value != _SmaLengthFilter.ValueInt)
        {
            _SmaFilter.ParametersDigit[0].Value = _SmaLengthFilter.ValueInt;
            _SmaFilter.Reload();
            _SmaFilter.Save();
        }

        if (_SmaFilter.DataSeries != null && _SmaFilter.DataSeries.Count > 0)
        {
            if (!_SmaPositionFilterIsOn.ValueBool)
            {
                _SmaFilter.DataSeries[0].IsPaint = false;
            }
            else
            {
                _SmaFilter.DataSeries[0].IsPaint = true;
            }
        }
    }

    private void StopOrActivateIndicators()
    {

        if (_SmaPositionFilterIsOn.ValueBool == false
            && _SmaSlopeFilterIsOn.ValueBool == false
            && _SmaFilter.IsOn == true)
        {
            _SmaFilter.IsOn = false;
            _SmaFilter.Reload();
        }
        else if ((_SmaPositionFilterIsOn.ValueBool == true
            || _SmaSlopeFilterIsOn.ValueBool == true)
            && _SmaFilter.IsOn == false)
        {
            _SmaFilter.IsOn = true;
            _SmaFilter.Reload();
        }
    }

    public override string GetNameStrategyType()
    {
        return "ParabolicPriceChannel";
    }

    public override void ShowIndividualSettingsDialog()
    {

    }

    private void _tab_CandleFinishedEvent(List<Candle> candles)
    {
        if (_TimeStart.Value > _tab.TimeServerCurrent ||
          _TimeEnd.Value < _tab.TimeServerCurrent)
        {
            return;
        }
        if (_SmaLengthFilter.ValueInt >= candles.Count || _PeriodUpPPC.ValueInt >= candles.Count || _PeriodDownPPC.ValueInt >= candles.Count)
        {
            return;
        }
        if (!GetValueVariables(candles))
        {
            return;
        }

        List<Position> positions = _tab.PositionsOpenAll;

        for (int i = 0; i < positions.Count; i++)
        {
            ClosePosition(candles, positions[i]);
        }

        if (positions == null || positions.Count == 0)
        {
            OpenPosotion(candles);
        }

    }

    private bool GetValueVariables(List<Candle> candles)
    {
        lastPriceClose = candles[candles.Count - 1].Close;
        lastPriceChannelUp = _ParabolicPC.DataSeries[0].Last;
        lastPriceChannelDown = _ParabolicPC.DataSeries[1].Last;
        lastParabolicStop = _ParabolicPC.DataSeries[2].Last;

        if (lastPriceClose == 0 || lastPriceChannelUp == 0
           || lastPriceChannelDown == 0 || lastParabolicStop == 0)
        {
            return false;
        }
        return true;
    }

    private void OpenPosotion(List<Candle> candles)
    {
        if (lastPriceChannelUp <= lastParabolicStop || lastPriceChannelDown >= lastParabolicStop)
        {
            return;
        }

        decimal slippage = 0;

        if (lastPriceClose <= lastPriceChannelUp)
        {
            slippage = _Slippage.ValueDecimal * lastPriceChannelUp / 100;

            if (BuySignalIsFiltered(candles) == false)
            {
                _tab.BuyAtStop(GetVolume(), lastPriceChannelUp, lastPriceChannelUp + slippage, StopActivateType.HigherOrEqual, 1);
            }           
        }
        if (lastPriceClose >= lastPriceChannelDown)
        {
            slippage = _Slippage.ValueDecimal * lastPriceChannelDown / 100;

            if (SellSignalIsFiltered(candles) == false)
            {
                _tab.SellAtStop(GetVolume(), lastPriceChannelDown, lastPriceChannelDown - slippage, StopActivateType.LowerOrEqyal, 1);
            } 
        }
        if (BuySignalIsFiltered(candles))
        {
            _tab.BuyAtStopCancel();
        }
        if (SellSignalIsFiltered(candles))
        {
            _tab.SellAtStopCancel();
        }
    }

    private void ClosePosition(List<Candle> candles, Position position)
    {
        List<Position> positions = _tab.PositionsOpenAll;

        if (positions == null || positions.Count == 0)
        {
            return;
        }
        if (position.State == PositionStateType.Open ||
            position.State == PositionStateType.ClosingFail)
        {

            if (position.CloseActiv == true ||
            (position.CloseOrders != null && position.CloseOrders.Count > 0))
            {
                return;
            }

            decimal slippage = _Slippage.ValueDecimal * lastPriceClose / 100;

            if (position.Direction == Side.Buy)
            {
                _tab.CloseAtTrailingStop(position, lastParabolicStop, lastParabolicStop - slippage);
            }
            if (position.Direction == Side.Sell)
            {

                _tab.CloseAtTrailingStop(position, lastParabolicStop, lastParabolicStop + slippage);
            }
        }
    }


    #region GetVolume()
    private decimal GetVolume()
    {
        decimal volume = _VolumeOnPosition.ValueDecimal;

        if (_VolumeRegime.ValueString == "Contract currency") // "Валюта контракта"
        {
            decimal contractPrice = TabsSimple[0].PriceBestAsk;
            volume = Math.Round(_VolumeOnPosition.ValueDecimal / contractPrice, _VolumeDecimals.ValueInt);
            return volume;
        }
        else if (_VolumeRegime.ValueString == "Number of contracts")
        {
            return volume;
        }
        else //if (VolumeRegime.ValueString == "% of the total portfolio")
        {
            return Math.Round(_tab.Portfolio.ValueCurrent * (volume / 100) / _tab.PriceBestAsk / _tab.Securiti.Lot, _VolumeDecimals.ValueInt);
        }
    }
    #endregion

    private bool BuySignalIsFiltered(List<Candle> candles)
    {
        // фильтр для покупок

        decimal lastSma = _SmaFilter.DataSeries[0].Last;
        decimal _lastPrice = candles[candles.Count - 1].Close;
        //если режим выкл то возвращаем тру
        if (_Regime.ValueString == "Off" ||
            _Regime.ValueString == "OnlyShort" ||
            _Regime.ValueString == "OnlyClosePosition")
        {
            return true;
        }

        if (_SmaPositionFilterIsOn.ValueBool)
        {
            // если цена ниже последней сма - возвращаем на верх true

            if (_lastPrice < lastSma)
            {
                return true;
            }

        }
        if (_SmaSlopeFilterIsOn.ValueBool)
        {
            // если последняя сма ниже предыдущей сма - возвращаем на верх true            
            decimal previousSma = _SmaFilter.DataSeries[0].Values[_SmaFilter.DataSeries[0].Values.Count - 2]; ///

            if (lastSma < previousSma)
            {
                return true;
            }
        }
        return false;
    }

    private bool SellSignalIsFiltered(List<Candle> candles)
    {
        // фильтр для шорта
        decimal _lastPrice = candles[candles.Count - 1].Close;
        decimal lastSma = _SmaFilter.DataSeries[0].Last;
        //если режим выкл то возвращаем тру
        if (_Regime.ValueString == "Off" ||
            _Regime.ValueString == "OnlyLong" ||
            _Regime.ValueString == "OnlyClosePosition")
        {
            return true;
        }

        if (_SmaPositionFilterIsOn.ValueBool)
        {
            // если цена выше последней сма - возвращаем на верх true

            if (_lastPrice > lastSma)
            {
                return true;
            }

        }
        if (_SmaSlopeFilterIsOn.ValueBool)
        {
            // если последняя сма выше предыдущей сма - возвращаем на верх true
            decimal previousSma = _SmaFilter.DataSeries[0].Values[_SmaFilter.DataSeries[0].Values.Count - 2];

            if (lastSma > previousSma)
            {
                return true;
            }

        }
        return false;
    }
}

