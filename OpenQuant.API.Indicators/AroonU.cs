using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class AroonU : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.AroonU).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.AroonU).Length = value;
			}
		}
		private AroonU()
		{
			this.indicator = new SmartQuant.Indicators.AroonU();
		}
		public AroonU(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.AroonU(series.series, length);
		}
		public AroonU(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.AroonU(indicator.indicator, length);
		}
		public AroonU(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.AroonU(series.series, length);
		}
		public AroonU(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AroonU(series.series, length, color);
		}
		public AroonU(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AroonU(indicator.indicator, length, color);
		}
		public AroonU(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AroonU(series.series, length, color);
		}
	}
}
