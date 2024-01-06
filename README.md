Форк для изучения библиотеки

Изменения от оригинала<br>
1 - в папке док добавлены снипеты для быстрого и удобного создания индикаторов и ботов<br>
2 - "слежение" сделано по мне логично - двигает топ и профит в лучшую сторону по мере измерения цены, а не просто от цены входа фикс<br>
3 - косметика -при установке цен стоп и профит -округляет до размерности инструмента. а не десятки знаков после запятой<br>

![image](https://github.com/AlexWan/OsEngine/assets/26077466/dd61c155-6d9b-46ff-864a-f902130f9e01)

# Open Source Algo Trading Platform

[Developer site](https://os-engine-eng.com)

[Support](https://t.me/osengine_official_support)

## What is OsEngine?

This is a full range of programs required to automate trading on the stock exchange.

![algotasks](https://user-images.githubusercontent.com/26077466/243118924-bfb99f06-1107-495e-a266-12ba0c8d5a55.jpg)

It includes:

The layer for creating robots is similar to the Wealth-Lab script and Ninja Script. It's simple. We do not change it with every release and support backward compatibility.

*Data* - program to download historical data. With the program you can get candles, market depths and trades from a variety of sources.

*Optimizer* - the program to select the optimal parameters for the strategy.

*Tester* - exchange emulator. The program for testing on the history of many strategies at the same time, with a single portfolio. Supports translation of multiple timeframes and multiple instruments at the same time.

*Miner* - the program to search for profitable formations on the chart. Both manual and automatic. Work with Bigdata on your computer. Patterns found with the help of this program can be launched into trading.

*Bot station* -the program to run the robots in the trade.

*Available connections for cryptocurrency exchanges*

| ________ logo ________                                                                                                                                                                                                |_______ name _______ | _______ support _______                                                                                            |   discount for our users                                                                                                                                                                                                                                                     |
|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|:-------------------:|:------------------------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|
| [![Binance](https://user-images.githubusercontent.com/26077466/239530178-79f2b6e7-1886-4851-9236-71037130cb40.png)](https://accounts.binance.com/register?ref=K3L7BLL1)                                               | Binance             | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 20% discount!](https://user-images.githubusercontent.com/26077466/239537321-b47e697c-468b-41e8-956e-033e66dca8ac.png)](https://accounts.binance.com/register?ref=K3L7BLL1)                                                   |
| [![Binance Futures](https://user-images.githubusercontent.com/26077466/239529542-da06360a-1354-419d-92fa-807eaf893d49.png)](https://accounts.binance.com/register?ref=K3L7BLL1)                                       | Binance Futures     | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 10% discount!](https://user-images.githubusercontent.com/26077466/239537247-b91835cb-4285-40a7-b66f-1fb29ca7822d.png)](https://accounts.binance.com/register?ref=K3L7BLL1)                                                   |
| [![BitGet](https://user-images.githubusercontent.com/26077466/239529626-69d43a71-f81c-4f1f-9936-6bd0e24f05f0.png)](https://partner.bitget.com/bg/txme90901684140842016)                                               | BitGet              | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 20% discount!](https://user-images.githubusercontent.com/26077466/239537321-b47e697c-468b-41e8-956e-033e66dca8ac.png)](https://partner.bitget.com/bg/txme90901684140842016)                                                  |
| [![OKX](https://user-images.githubusercontent.com/26077466/239530076-8b55f551-1a13-4ab5-8b42-8aebb7a34dc1.png)](https://www.okx.com/join/52450928)                                                                    | OKX                 | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 15% discount!](https://user-images.githubusercontent.com/26077466/239537290-7e7376fb-692e-48d7-b24f-a0cbe42b641f.png)](https://www.okx.com/join/52450928)                                                                    |
| [![Huobi](https://user-images.githubusercontent.com/26077466/239530230-8efd2c6f-44da-45c9-b05c-d289fa886420.png)](https://www.huobi.com.ro/invite/ru-ru/1g?invite_code=jxbn7223)                                      | Huobi               | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 30% discount!](https://user-images.githubusercontent.com/26077466/239537442-de38f220-aea7-4a4a-81e4-a4b901082fdd.png)](https://www.huobi.com.ro/invite/ru-ru/1g?invite_code=jxbn7223)                                        |
| [![Gate IO](https://user-images.githubusercontent.com/26077466/239529937-4ebf0078-bb13-48e0-9962-be05d907f62d.png)](https://www.gate.io/signup/13169541)                                                              | Gate IO             | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 20% discount!](https://user-images.githubusercontent.com/26077466/239537321-b47e697c-468b-41e8-956e-033e66dca8ac.png)](https://www.gate.io/signup/13169541)                                                                  |
| [![Askend](https://user-images.githubusercontent.com/26077466/239529277-970b73a2-9f39-4af8-94e9-cb74b9744275.png)](https://ascendex.com/register?inviteCode=BPEFZZW8Q)                                                | Askend              | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 25% discount!](https://user-images.githubusercontent.com/26077466/239537379-f2ab0ed6-5977-4e06-b37d-f838fa48c723.png)](https://ascendex.com/register?inviteCode=BPEFZZW8Q)                                                   |
| [![ByBit](https://user-images.githubusercontent.com/26077466/239529845-3f0e24d4-16d5-4ec1-add8-d835cbbc3d67.png)](https://www.bybit.com/register?affiliate_id=37176&group_id=0&group_type=1)                          | ByBit               | ![standart](https://user-images.githubusercontent.com/26077466/239537839-a844b85a-1139-444f-80bf-44914c09740c.png) | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![BitMex](https://user-images.githubusercontent.com/26077466/239529700-4371874c-e619-4302-a6d4-4f9373e88c0e.png)](https://www.bitmex.com)                                                                            | BitMex              | ![standart](https://user-images.githubusercontent.com/26077466/239537839-a844b85a-1139-444f-80bf-44914c09740c.png) | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![Bitstamp](https://user-images.githubusercontent.com/26077466/239529765-3f035413-8b5c-4991-ad1a-510c1c6794a6.png)](https://partner.bitget.com/bg/txme90901684140842016)                                             | Bitstamp            | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![Exmo](https://user-images.githubusercontent.com/26077466/239529888-69d8f5a3-1cce-4f67-b630-25e0a8dc9ff3.png)](https://partner.bitget.com/bg/txme90901684140842016)                                                 | Exmo                | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![HitBtc](https://user-images.githubusercontent.com/26077466/239529991-09128262-b125-4307-b69e-106a43e0381d.png)](https://partner.bitget.com/bg/txme90901684140842016)                                               | HitBtc              | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![Kraken](https://user-images.githubusercontent.com/26077466/239530042-5b45e459-3991-44e1-b5e2-ede94d724421.png)](https://partner.bitget.com/bg/txme90901684140842016)                                               | Kraken              | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![ZB](https://user-images.githubusercontent.com/26077466/239530136-9cab79ad-6f60-4dc4-bd6c-8dd9d90bd782.png)](https://partner.bitget.com/bg/txme90901684140842016)                                                   | ZB                  | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |


*Available connections for MOEX*

| ________ logo ________                                                                                                                        |_______ name _______ | _______ support _______                                                                                            |   discount for our users                                                                                                                                                                                                                                                     |
|:-------------------------------------------------------------------------------------------------------------------------------------------------------:|:-------------------:|:------------------------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------:|
| [![ALOR OPEN API](https://github.com/AlexWan/OsEngine/assets/26077466/0ec1e32a-9936-4063-966e-f61fce56bfff)](https://www.alorbroker.ru/open?pr=L0745)   | ALOR OPEN API       | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)](https://www.alorbroker.ru/open?pr=L0745) |
| ![Quik DDE](https://user-images.githubusercontent.com/26077466/239535136-051c4d6e-980a-456b-996c-93024d72fa8b.png)                                      | Quik DDE            | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Transaq](https://user-images.githubusercontent.com/26077466/239535313-b948d50e-1d7d-4cff-b994-c2c711bb1688.png)                                       | Transaq             | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Tinkoff Api](https://user-images.githubusercontent.com/26077466/239535245-83ac09ac-586c-4021-a96b-9b9685e5ffc4.png)                                   | Tinkoff Api         | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Quik LUA](https://user-images.githubusercontent.com/26077466/239535058-d5ac0db1-8b0f-4602-a6c1-abcbe6fc7cb6.png)                                      | Quik LUA            | ![standart](https://user-images.githubusercontent.com/26077466/239537839-a844b85a-1139-444f-80bf-44914c09740c.png) | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Plaza 2](https://user-images.githubusercontent.com/26077466/239535000-fb36abb2-4e29-4ae1-ae3f-9952c4211485.png)                                       | Plaza 2             | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Asts Bridge](https://user-images.githubusercontent.com/26077466/239534827-4d9bfa5a-2a20-4bca-92ac-63ef62aace77.png)                                   | Asts Bridge         | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |



*Available international connections*

| ________ logo ________                                                                                                                                                                   |_______ name _______ |  _______ support _______                                                                                           | discount for our users                                                                                                                                                                                                           
|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|:-------------------:|:------------------------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------------------:|
| [![Interactive Brokers](https://user-images.githubusercontent.com/26077466/239535591-8420295f-7405-4bf2-9e18-c5112b4b2582.png)](https://www.interactivebrokers.com/en/home.php)          | Interactive Brokers | ![standart](https://user-images.githubusercontent.com/26077466/239537839-a844b85a-1139-444f-80bf-44914c09740c.png) | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)   |
| [![Ninja Trader](https://user-images.githubusercontent.com/26077466/239535631-bb4596f4-160f-4506-bcdd-4832d1deb188.png)](https://ninjatrader.com)                                        | Ninja Trader        | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)   |
| [![LMAX](https://user-images.githubusercontent.com/26077466/239535509-2336139b-b648-4a66-b2a6-cb6d2b3e91b6.png)](https://www.lmax.com)                                                   | LMAX                | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)   |


*Included with OsEngine is more than 30 built-in robots*

1) Сlassic trend robots like moving average crossing, bill Williams strategy or Jesse Livermore trend strategy.

2) Counter-trend systems on Bollinger bands, balance lines and even some market-making strategies.

3) Arbitrage strategies for trading divergences of correlating instruments, including one-legged arbitrage.

Until August 2023, the project was distributed under the Apache 2 licence. Since September 2023 it is distributed under a commercial licence. All rights belong to Wang Technologies Ltd. In order to use any part of the project in your commercial projects, you need to obtain an extended licence on the site of the right holder.


![oslogo250](https://user-images.githubusercontent.com/26077466/264690708-54b9eca1-09ef-4e6c-b9cf-442e4c1b7dc3.png)

## Что такое OsEngine?

Это полный комплекс программ необходимых для автоматизации торговли на бирже. 

[Сайт разработчиков](http://o-s-a.net)

![default](https://user-images.githubusercontent.com/26077466/243121761-25fe883f-d567-4ed0-bdd6-7f28c7ff667b.jpg)

В него входят:

Слой создания роботов похожий на Wealth-Lab script и Ninja script. Он очень прост. Мы не изменяем его с каждым релизом и поддерживаем в нём обратную совместимость.

*OData* - программа для загрузки исторических данных, с помощью которой Вы можете получать свечи, стаканы и тики из самых различных источников.

*Optimizer* - программа для подбора оптимальных параметров для стратегии.

*Tester* - эмулятор биржи. Программа для тестирования на истории множества стратегий одновременно, с единым портфелем.  Поддерживает трансляцию нескольких таймфреймов и нескольких инструментов одновременно.

*Miner* - программа для поиска прибыльных формаций на графике. Как в ручном, так и в автоматическом режиме. Работа с БигДатой у Вас на компьютере. Паттерны найденные при помощи этой программы можно запускать в торговлю.

*Bot station* - программа для запуска роботов в торговлю.


*Доступные подключения для бирж криптовалют*

| ________ Лого ________                                                                                                                                                                                                |_______ Имя _______  | _______ Поддержка _______                                                                                          |   Скидка пользователям OsEngine                                                                                                                                                                                                                                              |
|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|:-------------------:|:------------------------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|
| [![Binance](https://user-images.githubusercontent.com/26077466/239530178-79f2b6e7-1886-4851-9236-71037130cb40.png)](https://accounts.binance.com/register?ref=K3L7BLL1)                                               | Binance             | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 20% discount!](https://user-images.githubusercontent.com/26077466/239537321-b47e697c-468b-41e8-956e-033e66dca8ac.png)](https://accounts.binance.com/register?ref=K3L7BLL1)                                                   |
| [![Binance Futures](https://user-images.githubusercontent.com/26077466/239529542-da06360a-1354-419d-92fa-807eaf893d49.png)](https://accounts.binance.com/register?ref=K3L7BLL1)                                       | Binance Futures     | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 10% discount!](https://user-images.githubusercontent.com/26077466/239537247-b91835cb-4285-40a7-b66f-1fb29ca7822d.png)](https://accounts.binance.com/register?ref=K3L7BLL1)                                                   |
| [![BitGet](https://user-images.githubusercontent.com/26077466/239529626-69d43a71-f81c-4f1f-9936-6bd0e24f05f0.png)](https://partner.bitget.com/bg/txme90901684140842016)                                               | BitGet              | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 20% discount!](https://user-images.githubusercontent.com/26077466/239537321-b47e697c-468b-41e8-956e-033e66dca8ac.png)](https://partner.bitget.com/bg/txme90901684140842016)                                                  |
| [![OKX](https://user-images.githubusercontent.com/26077466/239530076-8b55f551-1a13-4ab5-8b42-8aebb7a34dc1.png)](https://www.okx.com/join/52450928)                                                                    | OKX                 | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 15% discount!](https://user-images.githubusercontent.com/26077466/239537290-7e7376fb-692e-48d7-b24f-a0cbe42b641f.png)](https://www.okx.com/join/52450928)                                                                    |
| [![Huobi](https://user-images.githubusercontent.com/26077466/239530230-8efd2c6f-44da-45c9-b05c-d289fa886420.png)](https://www.huobi.com.ro/invite/ru-ru/1g?invite_code=jxbn7223)                                      | Huobi               | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 30% discount!](https://user-images.githubusercontent.com/26077466/239537442-de38f220-aea7-4a4a-81e4-a4b901082fdd.png)](https://www.huobi.com.ro/invite/ru-ru/1g?invite_code=jxbn7223)                                        |
| [![Gate IO](https://user-images.githubusercontent.com/26077466/239529937-4ebf0078-bb13-48e0-9962-be05d907f62d.png)](https://www.gate.io/signup/13169541)                                                              | Gate IO             | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 20% discount!](https://user-images.githubusercontent.com/26077466/239537321-b47e697c-468b-41e8-956e-033e66dca8ac.png)](https://www.gate.io/signup/13169541)                                                                  |
| [![Askend](https://user-images.githubusercontent.com/26077466/239529277-970b73a2-9f39-4af8-94e9-cb74b9744275.png)](https://ascendex.com/register?inviteCode=BPEFZZW8Q)                                                | Askend              | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![Sign up using OsEngine's referral link for a 25% discount!](https://user-images.githubusercontent.com/26077466/239537379-f2ab0ed6-5977-4e06-b37d-f838fa48c723.png)](https://ascendex.com/register?inviteCode=BPEFZZW8Q)                                                   |
| [![ByBit](https://user-images.githubusercontent.com/26077466/239529845-3f0e24d4-16d5-4ec1-add8-d835cbbc3d67.png)](https://www.bybit.com/register?affiliate_id=37176&group_id=0&group_type=1)                          | ByBit               | ![standart](https://user-images.githubusercontent.com/26077466/239537839-a844b85a-1139-444f-80bf-44914c09740c.png) | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![BitMex](https://user-images.githubusercontent.com/26077466/239529700-4371874c-e619-4302-a6d4-4f9373e88c0e.png)](https://www.bitmex.com)                                                                            | BitMex              | ![standart](https://user-images.githubusercontent.com/26077466/239537839-a844b85a-1139-444f-80bf-44914c09740c.png) | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![Bitstamp](https://user-images.githubusercontent.com/26077466/239529765-3f035413-8b5c-4991-ad1a-510c1c6794a6.png)](https://partner.bitget.com/bg/txme90901684140842016)                                             | Bitstamp            | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![Exmo](https://user-images.githubusercontent.com/26077466/239529888-69d8f5a3-1cce-4f67-b630-25e0a8dc9ff3.png)](https://partner.bitget.com/bg/txme90901684140842016)                                                 | Exmo                | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![HitBtc](https://user-images.githubusercontent.com/26077466/239529991-09128262-b125-4307-b69e-106a43e0381d.png)](https://partner.bitget.com/bg/txme90901684140842016)                                               | HitBtc              | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![Kraken](https://user-images.githubusercontent.com/26077466/239530042-5b45e459-3991-44e1-b5e2-ede94d724421.png)](https://partner.bitget.com/bg/txme90901684140842016)                                               | Kraken              | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |
| [![ZB](https://user-images.githubusercontent.com/26077466/239530136-9cab79ad-6f60-4dc4-bd6c-8dd9d90bd782.png)](https://partner.bitget.com/bg/txme90901684140842016)                                                   | ZB                  | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                                                                                                                                                 |


*Доступные подключения для MOEX*

| ________ Лого ________                                                                                                                        |_______ Имя _______  |  _______ Поддержка _______                                                                                         | Скидка пользователям OsEngine                                                                                                                                                                                                         
|:-------------------------------------------------------------------------------------------------------------------------------------------------------:|:-------------------:|:------------------------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------:|
| [![ALOR OPEN API](https://github.com/AlexWan/OsEngine/assets/26077466/0ec1e32a-9936-4063-966e-f61fce56bfff)](https://www.alorbroker.ru/open?pr=L0745)   | ALOR OPEN API       | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | [![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)](https://www.alorbroker.ru/open?pr=L0745) |
| ![Quik DDE](https://user-images.githubusercontent.com/26077466/239535136-051c4d6e-980a-456b-996c-93024d72fa8b.png)                                      | Quik DDE            | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Transaq](https://user-images.githubusercontent.com/26077466/239535313-b948d50e-1d7d-4cff-b994-c2c711bb1688.png)                                       | Transaq             | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Tinkoff Api](https://user-images.githubusercontent.com/26077466/239535245-83ac09ac-586c-4021-a96b-9b9685e5ffc4.png)                                   | Tinkoff Api         | ![prime](https://user-images.githubusercontent.com/26077466/239537776-71b68997-e4f9-4c06-9a9c-770b6e54b32d.png)    | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Quik LUA](https://user-images.githubusercontent.com/26077466/239535058-d5ac0db1-8b0f-4602-a6c1-abcbe6fc7cb6.png)                                      | Quik LUA            | ![standart](https://user-images.githubusercontent.com/26077466/239537839-a844b85a-1139-444f-80bf-44914c09740c.png) | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Plaza 2](https://user-images.githubusercontent.com/26077466/239535000-fb36abb2-4e29-4ae1-ae3f-9952c4211485.png)                                       | Plaza 2             | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |
| ![Asts Bridge](https://user-images.githubusercontent.com/26077466/239534827-4d9bfa5a-2a20-4bca-92ac-63ef62aace77.png)                                   | Asts Bridge         | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)                                               |


*Доступные международные подключения*

| ________ Лого ________                                                                                                                                                                   |_______ Имя _______  |  _______ Поддержка _______                                                                                         | Скидка пользователям OsEngine                                                                                                                                                                                                         
|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|:-------------------:|:------------------------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------------------:|
| [![Interactive Brokers](https://user-images.githubusercontent.com/26077466/239535591-8420295f-7405-4bf2-9e18-c5112b4b2582.png)](https://www.interactivebrokers.com/en/home.php)          | Interactive Brokers | ![standart](https://user-images.githubusercontent.com/26077466/239537839-a844b85a-1139-444f-80bf-44914c09740c.png) | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)   |
| [![Ninja Trader](https://user-images.githubusercontent.com/26077466/239535631-bb4596f4-160f-4506-bcdd-4832d1deb188.png)](https://ninjatrader.com)                                        | Ninja Trader        | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)   |
| [![LMAX](https://user-images.githubusercontent.com/26077466/239535509-2336139b-b648-4a66-b2a6-cb6d2b3e91b6.png)](https://www.lmax.com)                                                   | LMAX                | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)       | ![no](https://user-images.githubusercontent.com/26077466/239537736-63d17a8f-7bdf-4209-8455-a2994c137fed.png)   |


*В комплекте с OsEngine идёт более 30ти встроенных роботов*

1) классические трендовые роботы, вроде пересечения машек, стратегии Билла Вильямса или трендовой стратегии Джесси Ливермора.

2) контрТрендовые системы на боллинжере, линиях баланса и даже некоторые маркет-мэйкерские стратегии.

3) арбитражные стратегии для торговли расхождения коррелирующих инструментов, в том числе одноногие арбитражи.

FAQ: https://o-s-a.net/os-engine-faq

Телеграмм группа поддержки: https://t.me/osengine_official_support

До августа 2023 года проект распространялся под лицензией Apache 2. С сентября 2023 года распространяется под коммерческой лицензией. Все права принадлежат ООО "Ван Технологии". Для того чтобы использовать любую часть проекта, добавленного в репозиторий начиная с сентября 2023 года в своих коммерческих проектах, Вам необходимо получить расширенную лицензию на сайте правообладателя.

Разьяснения относительно лицензионного соглашения: https://o-s-a.net/os-engine-license-about 
