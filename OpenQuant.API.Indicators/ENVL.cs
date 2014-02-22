using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class ENVL : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.ENVL).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ENVL).Length = value;
			}
		}
		[Category("Parameters"), Description("Shift")]
		public double Shift
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.ENVL).Shift;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ENVL).Shift = value;
			}
		}
		private ENVL()
		{
			this.indicator = new SmartQuant.Indicators.ENVL();
		}
		public ENVL(BarSeries series, int length, int shift)
		{
			this.indicator = new SmartQuant.Indicators.ENVL(series.series, length, (double)shift);
		}
		public ENVL(OpenQuant.API.Indicator indicator, int length, int shift)
		{
			this.indicator = new SmartQuant.Indicators.ENVL(indicator.indicator, length, (double)shift);
		}
		public ENVL(BarSeries series, int length, int shift, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.ENVL(series.series, length, (double)shift, OpenQuant.API.EnumConverter.Convert(option));
		}
		public ENVL(OpenQuant.API.Indicator indicator, int length, int shift, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.ENVL(indicator.indicator, length, (double)shift, OpenQuant.API.EnumConverter.Convert(option));
		}
		public ENVL(BarSeries series, int length, int shift, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ENVL(series.series, length, (double)shift, color);
		}
		public ENVL(OpenQuant.API.Indicator indicator, int length, int shift, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ENVL(indicator.indicator, length, (double)shift, color);
		}
		public ENVL(BarSeries series, int length, int shift, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ENVL(series.series, length, (double)shift, OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public ENVL(OpenQuant.API.Indicator indicator, int length, int shift, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ENVL(indicator.indicator, length, (double)shift, OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
