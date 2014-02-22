using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class ENVU : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.ENVU).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ENVU).Length = value;
			}
		}
		[Category("Parameters"), Description("Shift")]
		public double Shift
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.ENVU).Shift;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ENVU).Shift = value;
			}
		}
		private ENVU()
		{
			this.indicator = new SmartQuant.Indicators.ENVU();
		}
		public ENVU(BarSeries series, int length, int shift)
		{
			this.indicator = new SmartQuant.Indicators.ENVU(series.series, length, (double)shift);
		}
		public ENVU(global::OpenQuant.API.Indicator indicator, int length, int shift)
		{
			this.indicator = new SmartQuant.Indicators.ENVU(indicator.indicator, length, (double)shift);
		}
		public ENVU(BarSeries series, int length, int shift, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.ENVU(series.series, length, (double)shift, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public ENVU(global::OpenQuant.API.Indicator indicator, int length, int shift, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.ENVU(indicator.indicator, length, (double)shift, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public ENVU(BarSeries series, int length, int shift, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ENVU(series.series, length, (double)shift, color);
		}
		public ENVU(global::OpenQuant.API.Indicator indicator, int length, int shift, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ENVU(indicator.indicator, length, (double)shift, color);
		}
		public ENVU(BarSeries series, int length, int shift, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ENVU(series.series, length, (double)shift, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public ENVU(global::OpenQuant.API.Indicator indicator, int length, int shift, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ENVU(indicator.indicator, length, (double)shift, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
