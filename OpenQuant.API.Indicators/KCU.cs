using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class KCU : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.KCU).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.KCU).Length = value;
			}
		}
		private KCU()
		{
			this.indicator = new SmartQuant.Indicators.KCU();
		}
		public KCU(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.KCU(series.series, length);
		}
		public KCU(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.KCU(indicator.indicator, length);
		}
		public KCU(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KCU(series.series, length, color);
		}
		public KCU(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KCU(indicator.indicator, length, color);
		}
		public KCU(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.KCU(series.series, length);
		}
		public KCU(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KCU(series.series, length, color);
		}
	}
}
