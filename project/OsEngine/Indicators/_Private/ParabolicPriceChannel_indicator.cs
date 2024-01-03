using System;
using System.Collections.Generic;
using System.Drawing;
using OsEngine.Entity;
using OsEngine.Indicators;
 

public class ParabolicPriceChannel_indicator : Aindicator
{
    private IndicatorParameterInt _lenghtUp;
    private IndicatorParameterInt _lenghtDown;

    private IndicatorParameterString _period;
    private IndicatorParameterInt _averagingPeriod;
    private IndicatorParameterDecimal _volatMult;

    private IndicatorDataSeries _seriesUp;
    private IndicatorDataSeries _seriesDown;
    private IndicatorDataSeries _seriesP;
    private IndicatorDataSeries _seriesValueVolatility;

    List<decimal> HiLowPercent = new List<decimal>();

    public override void OnStateChange(IndicatorState state)
    {
        if (state == IndicatorState.Configure)
        {
            _lenghtUp = CreateParameterInt("Length up", 21);
            _lenghtDown = CreateParameterInt("Lenght down", 21);

            _period = CreateParameterStringCollection("Volatility calculation period", "Day", new List<string> { "Minute", "Hour", "Day", "Week", "Month" });
            _averagingPeriod = CreateParameterInt("Averaging Period Volatility", 15);
            _volatMult = CreateParameterDecimal("Volatility multi", 0.1m);

            _seriesUp = CreateSeries("Up line", Color.Aqua, IndicatorChartPaintType.Line, true);
            _seriesDown = CreateSeries("Down line", Color.BlueViolet, IndicatorChartPaintType.Line, true);
            _seriesP = CreateSeries("Parabolicline", Color.Aqua, IndicatorChartPaintType.Point, true);

            _seriesValueVolatility = CreateSeries("Volatility value series", Color.Aquamarine, IndicatorChartPaintType.Line, false);
        }
    }

    public override void OnProcess(List<Candle> candles, int index)
    {
        if (index == 0)
            HiLowPercent.Clear();
        if (index <= 20)
            return;

        decimal HiLowDifference = GetVolatility(candles, index);
        decimal volatilityPercent = GetVolatilityPercent(candles, index, HiLowDifference);

        if (HiLowPercent.Count < _averagingPeriod.ValueInt)
        {
            HiLowPercent.Add(volatilityPercent);
        }
        else
        {
            HiLowPercent.RemoveAt(0);
            HiLowPercent.Add(volatilityPercent);
        }

        decimal ValueVolatility = HiLowDifference * _volatMult.ValueDecimal;
        decimal ValueVolatilityAverage = GetAverageVolatilityValue(candles, index);

        _seriesValueVolatility.Values[index] = Math.Round(ValueVolatility, 6);

        decimal upLine = 0;

        if (index - _lenghtUp.ValueInt > 0)
        {
            for (int i = index; i > -1 && i > index - _lenghtUp.ValueInt; i--)
            {
                if (upLine < candles[i].High)
                {
                    upLine = candles[i].High;
                }
            }
        }

        decimal downLine = 0;

        if (index - _lenghtDown.ValueInt > 0)
        {
            downLine = decimal.MaxValue;

            for (int i = index; i > -1 && i > index - _lenghtDown.ValueInt; i--)
            {
                if (downLine > candles[i].Low)
                {
                    downLine = candles[i].Low;
                }
            }
        }

        _seriesUp.Values[index] = upLine;
        _seriesDown.Values[index] = downLine;

        if (candles[index].High >= upLine)
        {
            drawBelow = true;
        }
        if (candles[index].Low <= downLine)
        {
            drawBelow = false;
        }

        bool changePosition = false;

        if (lastDrawBelow != drawBelow)
        {
            changePosition = true;
        }

        if (drawBelow)
        {
            if (_seriesP.Values[index - 1] != 0 &&
                changePosition == false)
            {
                decimal value = _seriesP.Values[index - 1] + ValueVolatilityAverage;

                if (value < _seriesDown.Values[index])
                {
                    value = _seriesDown.Values[index];
                }
                if (value > _seriesUp.Values[index])
                {
                    value = _seriesUp.Values[index];
                }

                _seriesP.Values[index] = value;
            }
            else
            {
                _seriesP.Values[index] = _seriesDown.Values[index];
            }
        }
        else
        {
            if (_seriesP.Values[index - 1] != 0 &&
                changePosition == false)
            {
                decimal value = _seriesP.Values[index - 1] - ValueVolatilityAverage;
                if (value > _seriesUp.Values[index])
                {
                    value = _seriesUp.Values[index];
                }
                if (value < _seriesDown.Values[index])
                {
                    value = _seriesDown.Values[index];
                }

                _seriesP.Values[index] = value;
            }
            else
            {
                _seriesP.Values[index] = _seriesUp.Values[index];
            }
        }

        lastDrawBelow = drawBelow;
    }

    bool drawBelow = false;
    bool lastDrawBelow = false;

    public decimal GetVolatility(List<Candle> candles, int index)
    {
        DateTime calcStartDay = candles[index].TimeStart;
        DateTime time = candles[index].TimeStart;

        if (_period.ValueString.Contains("Minute"))
        {
            time = calcStartDay.AddMinutes(-1);
        }
        else if (_period.ValueString.Contains("Hour"))
        {
            time = calcStartDay.AddHours(-1);
        }
        else if (_period.ValueString.Contains("Day"))
        {
            time = calcStartDay.AddDays(-1);
        }
        else if (_period.ValueString.Contains("Week"))
        {
            time = calcStartDay.AddDays(-7);
        }
        else if (_period.ValueString.Contains("Month"))
        {
            time = calcStartDay.AddMonths(-1);
        }

        decimal high = candles[index].High;
        decimal low = candles[index].Low;
        int l = 1;
        while (index - l >= 0 && candles[index - l].TimeStart >= time)
        {
            if (candles[index - l].High > high)
            {
                high = candles[index - l].High;
            }
            if (candles[index - l].Low < low)
            {
                low = candles[index - l].Low;
            }
            l++;
        }
        decimal result = high - low;

        return result;
    }
    public decimal GetVolatilityPercent(List<Candle> candles, int index, decimal HiLowDifference)
    {
        
        
        decimal percent = HiLowDifference==0 ? 0:((candles[index].High - candles[index].Low) / HiLowDifference) * 100;

        return percent;
    }

    public decimal GetAverageVolatilityValue(List<Candle> candles, int index)
    {
        if (_seriesValueVolatility.Values.Count <= _averagingPeriod.ValueInt)
        {
            return _seriesValueVolatility.Values[index];
        }
        decimal avr = 0;
        for (int i = _seriesValueVolatility.Values.Count - _averagingPeriod.ValueInt; i < _seriesValueVolatility.Values.Count; i++)
        {
            avr += _seriesValueVolatility.Values[i] * _volatMult.ValueDecimal;
        }
        avr = avr / _averagingPeriod.ValueInt;

        return avr;
    }
}

