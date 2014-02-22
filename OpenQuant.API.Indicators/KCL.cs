using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class KCL : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.KCL).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.KCL).Length = value;
			}
		}
		private KCL()
		{
			this.indicator = new SmartQuant.Indicators.KCL();
		}
		public KCL(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.KCL(series.series, length);
		}
		public KCL(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.KCL(indicator.indicator, length);
		}
		public KCL(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KCL(series.series, length, color);
		}
		public KCL(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KCL(indicator.indicator, length, color);
		}
		public KCL(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.KCL(series.series, length);
		}
		public KCL(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KCL(series.series, length, color);
		}
	}
}
