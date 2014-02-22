using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class Range : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.Range).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.Range).Length = value;
			}
		}
		private Range()
		{
			this.indicator = new SmartQuant.Indicators.Range();
		}
		public Range(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.Range(series.series, length);
		}
		public Range(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.Range(indicator.indicator, length);
		}
		public Range(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.Range(series.series, length, color);
		}
		public Range(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.Range(indicator.indicator, length, color);
		}
	}
}
