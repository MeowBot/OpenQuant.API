using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class AroonL : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.AroonL).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.AroonL).Length = value;
			}
		}
		private AroonL()
		{
			this.indicator = new SmartQuant.Indicators.AroonL();
		}
		public AroonL(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.AroonL(series.series, length);
		}
		public AroonL(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.AroonL(indicator.indicator, length);
		}
		public AroonL(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.AroonL(series.series, length);
		}
		public AroonL(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AroonL(series.series, length, color);
		}
		public AroonL(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AroonL(indicator.indicator, length, color);
		}
		public AroonL(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AroonL(series.series, length, color);
		}
	}
}
