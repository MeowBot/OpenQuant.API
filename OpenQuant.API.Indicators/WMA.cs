using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class WMA : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.WMA).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.WMA).Length = value;
			}
		}
		private WMA()
		{
			this.indicator = new SmartQuant.Indicators.WMA();
		}
		public WMA(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.WMA(series.series, length);
		}
		public WMA(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.WMA(series.series, length);
		}
		public WMA(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.WMA(indicator.indicator, length);
		}
		public WMA(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.WMA(series.series, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public WMA(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.WMA(series.series, length);
		}
		public WMA(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.WMA(series.series, length);
		}
		public WMA(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.WMA(indicator.indicator, length);
		}
		public WMA(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.WMA(series.series, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
