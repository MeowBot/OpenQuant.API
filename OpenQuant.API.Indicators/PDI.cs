using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class PDI : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.PDI).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.PDI).Length = value;
			}
		}
		public IndicatorStyle Style
		{
			get
			{
				return global::OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.PDI).Style);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.PDI).Style = global::OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private PDI()
		{
			this.indicator = new SmartQuant.Indicators.PDI();
		}
		public PDI(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.PDI(series.series, length);
		}
		public PDI(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.PDI(indicator.indicator, length);
		}
		public PDI(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PDI(series.series, length, color);
		}
		public PDI(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PDI(indicator.indicator, length, color);
		}
	}
}
