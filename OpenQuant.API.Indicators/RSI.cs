using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class RSI : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.RSI).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.RSI).Length = value;
			}
		}
		public IndicatorStyle Style
		{
			get
			{
				return global::OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.RSI).Style);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.RSI).Style = global::OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private RSI()
		{
			this.indicator = new SmartQuant.Indicators.RSI();
		}
		public RSI(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.RSI(series.series, length);
		}
		public RSI(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.RSI(indicator.indicator, length);
		}
		public RSI(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.RSI(series.series, length);
		}
		public RSI(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.RSI(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public RSI(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.RSI(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public RSI(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.RSI(series.series, length, color);
		}
		public RSI(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.RSI(indicator.indicator, length, color);
		}
		public RSI(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.RSI(series.series, length, color);
		}
		public RSI(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.RSI(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), EIndicatorStyle.QuantStudio, color);
		}
		public RSI(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.RSI(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), EIndicatorStyle.QuantStudio, color);
		}
	}
}
