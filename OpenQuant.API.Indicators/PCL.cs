using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class PCL : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.PCL).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.PCL).Length = value;
			}
		}
		private PCL()
		{
			this.indicator = new SmartQuant.Indicators.PCL();
		}
		public PCL(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.PCL(series.series, length);
		}
		public PCL(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.PCL(indicator.indicator, length);
		}
		public PCL(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PCL(series.series, length, color);
		}
		public PCL(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PCL(indicator.indicator, length, color);
		}
	}
}
