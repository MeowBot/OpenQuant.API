using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class ADXR : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.ADXR).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ADXR).Length = value;
			}
		}
		public IndicatorStyle Style
		{
			get
			{
				return OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.ADXR).Style);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ADXR).Style = OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private ADXR()
		{
			this.indicator = new SmartQuant.Indicators.ADXR();
		}
		public ADXR(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.ADXR(series.series, length);
		}
		public ADXR(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.ADXR(indicator.indicator, length);
		}
		public ADXR(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ADXR(series.series, length, color);
		}
		public ADXR(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ADXR(indicator.indicator, length, color);
		}
	}
}
