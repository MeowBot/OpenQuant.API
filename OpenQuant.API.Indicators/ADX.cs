using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class ADX : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.ADX).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ADX).Length = value;
			}
		}
		public IndicatorStyle Style
		{
			get
			{
				return OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.ADX).Style);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ADX).Style = OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private ADX()
		{
			this.indicator = new SmartQuant.Indicators.ADX();
		}
		public ADX(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.ADX(series.series, length);
		}
		public ADX(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.ADX(indicator.indicator, length);
		}
		public ADX(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ADX(series.series, length, color);
		}
		public ADX(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ADX(indicator.indicator, length, color);
		}
	}
}
