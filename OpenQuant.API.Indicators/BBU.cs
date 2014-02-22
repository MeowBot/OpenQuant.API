using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class BBU : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.BBU).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.BBU).Length = value;
			}
		}
		[Category("Parameters"), Description("K")]
		public double K
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.BBU).K;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.BBU).K = value;
			}
		}
		private BBU()
		{
			this.indicator = new SmartQuant.Indicators.BBU();
		}
		public BBU(BarSeries series, int length, double k)
		{
			this.indicator = new SmartQuant.Indicators.BBU(series.series, length, k);
		}
		public BBU(OpenQuant.API.Indicator indicator, int length, double k)
		{
			this.indicator = new SmartQuant.Indicators.BBU(indicator.indicator, length, k);
		}
		public BBU(BarSeries series, int length, double k, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.BBU(series.series, length, k, OpenQuant.API.EnumConverter.Convert(option));
		}
		public BBU(OpenQuant.API.Indicator indicator, int length, double k, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.BBU(indicator.indicator, length, k, OpenQuant.API.EnumConverter.Convert(option));
		}
		public BBU(BarSeries series, int length, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBU(series.series, length, k, color);
		}
		public BBU(OpenQuant.API.Indicator indicator, int length, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBU(indicator.indicator, length, k, color);
		}
		public BBU(BarSeries series, int length, double k, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBU(series.series, length, k, OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public BBU(OpenQuant.API.Indicator indicator, int length, double k, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBU(indicator.indicator, length, k, OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public BBU(TimeSeries series, int length, double k)
		{
			this.indicator = new SmartQuant.Indicators.BBU(series.series, length, k);
		}
		public BBU(TimeSeries series, int length, double k, Color color)
		{
			this.indicator = new SmartQuant.Indicators.BBU(series.series, length, k, color);
		}
	}
}
