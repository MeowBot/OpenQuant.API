using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class HV : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.HV).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.HV).Length = value;
			}
		}
		[Category("Parameters"), Description("Span")]
		public double Span
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.HV).Span;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.HV).Span = value;
			}
		}
		private HV()
		{
			this.indicator = new SmartQuant.Indicators.HV();
		}
		public HV(BarSeries series, int length, int span)
		{
			this.indicator = new SmartQuant.Indicators.HV(series.series, length, (double)span);
		}
		public HV(OpenQuant.API.Indicator indicator, int length, int span)
		{
			this.indicator = new SmartQuant.Indicators.HV(indicator.indicator, length, (double)span);
		}
		public HV(BarSeries series, int length, int span, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.HV(series.series, length, (double)span, OpenQuant.API.EnumConverter.Convert(option));
		}
		public HV(OpenQuant.API.Indicator indicator, int length, int span, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.HV(indicator.indicator, length, (double)span, OpenQuant.API.EnumConverter.Convert(option));
		}
		public HV(BarSeries series, int length, int span, Color color)
		{
			this.indicator = new SmartQuant.Indicators.HV(series.series, length, (double)span, color);
		}
		public HV(OpenQuant.API.Indicator indicator, int length, int span, Color color)
		{
			this.indicator = new SmartQuant.Indicators.HV(indicator.indicator, length, (double)span, color);
		}
		public HV(BarSeries series, int length, int span, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.HV(series.series, length, (double)span, OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public HV(OpenQuant.API.Indicator indicator, int length, int span, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.HV(indicator.indicator, length, (double)span, OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
