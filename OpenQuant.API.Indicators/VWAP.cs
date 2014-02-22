using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class VWAP : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.VWAP).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.VWAP).Length = value;
			}
		}
		private VWAP()
		{
			this.indicator = new SmartQuant.Indicators.VWAP();
		}
		public VWAP(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.VWAP(series.series, length);
		}
		public VWAP(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.VWAP(indicator.indicator, length);
		}
		public VWAP(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.VWAP(series.series, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public VWAP(OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.VWAP(indicator.indicator, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public VWAP(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VWAP(series.series, length, color);
		}
		public VWAP(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VWAP(indicator.indicator, length, color);
		}
		public VWAP(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VWAP(series.series, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public VWAP(OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VWAP(indicator.indicator, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
