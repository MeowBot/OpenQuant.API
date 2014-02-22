using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class PERF : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("K")]
		public double K
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.PERF).K;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.PERF).K = value;
			}
		}
		private PERF()
		{
			this.indicator = new SmartQuant.Indicators.PERF();
		}
		public PERF(BarSeries series, double k)
		{
			this.indicator = new SmartQuant.Indicators.PERF(series.series, k);
		}
		public PERF(global::OpenQuant.API.Indicator indicator, double k)
		{
			this.indicator = new SmartQuant.Indicators.PERF(indicator.indicator, k);
		}
		public PERF(BarSeries series, double k, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.PERF(series.series, k, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public PERF(global::OpenQuant.API.Indicator indicator, double k, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.PERF(indicator.indicator, k, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public PERF(BarSeries series, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PERF(series.series, k, color);
		}
		public PERF(global::OpenQuant.API.Indicator indicator, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PERF(indicator.indicator, k, color);
		}
		public PERF(BarSeries series, double k, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PERF(series.series, k, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public PERF(global::OpenQuant.API.Indicator indicator, double k, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PERF(indicator.indicator, k, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
