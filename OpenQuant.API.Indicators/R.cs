using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class R : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.R).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.R).Length = value;
			}
		}
		private R()
		{
			this.indicator = new SmartQuant.Indicators.R();
		}
		public R(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.R(series.series, length);
		}
		public R(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.R(indicator.indicator, length);
		}
		public R(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.R(series.series, length);
		}
		public R(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.R(series.series, length, color);
		}
		public R(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.R(indicator.indicator, length, color);
		}
		public R(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.R(series.series, length, color);
		}
	}
}
