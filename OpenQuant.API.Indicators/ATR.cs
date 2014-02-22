using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class ATR : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.ATR).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ATR).Length = value;
			}
		}
		public IndicatorStyle Style
		{
			get
			{
				return global::OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.ATR).Style);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ATR).Style = global::OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private ATR()
		{
			this.indicator = new SmartQuant.Indicators.ATR();
		}
		public ATR(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.ATR(series.series, length);
		}
		public ATR(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.ATR(indicator.indicator, length);
		}
		public ATR(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ATR(series.series, length, color);
		}
		public ATR(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ATR(indicator.indicator, length, color);
		}
	}
}
