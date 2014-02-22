using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class BBL : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.BBL).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.BBL).Length = value;
			}
		}
		[Category("Parameters"), Description("K")]
		public double K
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.BBL).K;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.BBL).K = value;
			}
		}
		private BBL()
		{
			this.indicator = new SmartQuant.Indicators.BBL();
		}
		public BBL(BarSeries series, int length, double k)
		{
			this.indicator = new SmartQuant.Indicators.BBL(series.series, length, k);
		}
		public BBL(global::OpenQuant.API.Indicator indicator, int length, double k)
		{
			this.indicator = new SmartQuant.Indicators.BBL(indicator.indicator, length, k);
		}
		public BBL(BarSeries series, int length, double k, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.BBL(series.series, length, k, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public BBL(global::OpenQuant.API.Indicator indicator, int length, double k, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.BBL(indicator.indicator, length, k, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public BBL(BarSeries series, int length, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBL(series.series, length, k, color);
		}
		public BBL(global::OpenQuant.API.Indicator indicator, int length, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBL(indicator.indicator, length, k, color);
		}
		public BBL(BarSeries series, int length, double k, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBL(series.series, length, k, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public BBL(global::OpenQuant.API.Indicator indicator, int length, double k, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBL(indicator.indicator, length, k, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public BBL(TimeSeries series, int length, double k)
		{
			this.indicator = new SmartQuant.Indicators.BBL(series.series, length, k);
		}
		public BBL(TimeSeries series, int length, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBL(series.series, length, k, color);
		}
	}
}
