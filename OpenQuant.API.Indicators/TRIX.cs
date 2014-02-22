using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class TRIX : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.TRIX).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.TRIX).Length = value;
			}
		}
		private TRIX()
		{
			this.indicator = new SmartQuant.Indicators.TRIX();
		}
		public TRIX(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.TRIX(series.series, length);
		}
		public TRIX(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.TRIX(indicator.indicator, length);
		}
		public TRIX(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.TRIX(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public TRIX(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.TRIX(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public TRIX(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TRIX(series.series, length, color);
		}
		public TRIX(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TRIX(indicator.indicator, length, color);
		}
		public TRIX(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TRIX(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public TRIX(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TRIX(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
