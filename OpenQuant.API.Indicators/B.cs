using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class B : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.B).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.B).Length = value;
			}
		}
		[Category("Parameters"), Description("K")]
		public double K
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.B).K;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.B).K = value;
			}
		}
		private B()
		{
			this.indicator = new SmartQuant.Indicators.B();
		}
		public B(BarSeries series, int length, double k)
		{
			this.indicator = new SmartQuant.Indicators.B(series.series, length, k);
		}
		public B(global::OpenQuant.API.Indicator indicator, int length, double k)
		{
			this.indicator = new SmartQuant.Indicators.B(indicator.indicator, length, k);
		}
		public B(BarSeries series, int length, double k, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.B(series.series, length, k, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public B(global::OpenQuant.API.Indicator indicator, int length, double k, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.B(indicator.indicator, length, k, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public B(BarSeries series, int length, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.B(series.series, length, k, color);
		}
		public B(global::OpenQuant.API.Indicator indicator, int length, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.B(indicator.indicator, length, k, color);
		}
		public B(BarSeries series, int length, double k, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.B(series.series, length, k, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public B(global::OpenQuant.API.Indicator indicator, int length, double k, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.B(indicator.indicator, length, k, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
