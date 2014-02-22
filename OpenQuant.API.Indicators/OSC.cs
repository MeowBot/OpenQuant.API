using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class OSC : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length1")]
		public int Length1
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.OSC).Length1;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.OSC).Length1 = value;
			}
		}
		[Category("Parameters"), Description("Length2")]
		public int Length2
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.OSC).Length2;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.OSC).Length2 = value;
			}
		}
		private OSC()
		{
			this.indicator = new SmartQuant.Indicators.OSC();
		}
		public OSC(BarSeries series, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.OSC(series.series, length1, length2);
		}
		public OSC(global::OpenQuant.API.Indicator indicator, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.OSC(indicator.indicator, length1, length2);
		}
		public OSC(BarSeries series, int length1, int length2, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.OSC(series.series, length1, length2, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public OSC(global::OpenQuant.API.Indicator indicator, int length1, int length2, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.OSC(indicator.indicator, length1, length2, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public OSC(BarSeries series, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.OSC(series.series, length1, length2, color);
		}
		public OSC(global::OpenQuant.API.Indicator indicator, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.OSC(indicator.indicator, length1, length2, color);
		}
		public OSC(BarSeries series, int length1, int length2, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.OSC(series.series, length1, length2, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public OSC(global::OpenQuant.API.Indicator indicator, int length1, int length2, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.OSC(indicator.indicator, length1, length2, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
