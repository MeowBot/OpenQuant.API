using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class VROC : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.VROC).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.VROC).Length = value;
			}
		}
		private VROC()
		{
			this.indicator = new SmartQuant.Indicators.VROC();
		}
		public VROC(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.VROC(series.series, length);
		}
		public VROC(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.VROC(indicator.indicator, length);
		}
		public VROC(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VROC(series.series, length, color);
		}
		public VROC(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VROC(indicator.indicator, length, color);
		}
	}
}
