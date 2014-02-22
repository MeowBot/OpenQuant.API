using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class SMA : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.SMA).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.SMA).Length = value;
			}
		}
		private SMA()
		{
			this.indicator = new SmartQuant.Indicators.SMA();
		}
		public SMA(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.SMA(series.series, length);
		}
		public SMA(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.SMA(indicator.indicator, length);
		}
		public SMA(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.SMA(series.series, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public SMA(OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.SMA(indicator.indicator, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public SMA(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMA(series.series, length, color);
		}
		public SMA(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMA(indicator.indicator, length, color);
		}
		public SMA(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMA(series.series, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public SMA(OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMA(indicator.indicator, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public SMA(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.SMA(series.series, length);
		}
		public SMA(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMA(series.series, length, color);
		}
	}
}
