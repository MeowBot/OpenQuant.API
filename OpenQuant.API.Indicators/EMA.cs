using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class EMA : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.EMA).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.EMA).Length = value;
			}
		}
		private EMA()
		{
			this.indicator = new SmartQuant.Indicators.EMA();
		}
		public EMA(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.EMA(series.series, length);
		}
		public EMA(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.EMA(indicator.indicator, length);
		}
		public EMA(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.EMA(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public EMA(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.EMA(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public EMA(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.EMA(series.series, length, color);
		}
		public EMA(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.EMA(indicator.indicator, length, color);
		}
		public EMA(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.EMA(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public EMA(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.EMA(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public EMA(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.EMA(series.series, length);
		}
		public EMA(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.EMA(series.series, length, color);
		}
	}
}
