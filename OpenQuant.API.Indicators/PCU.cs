using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class PCU : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.PCU).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.PCU).Length = value;
			}
		}
		private PCU()
		{
			this.indicator = new SmartQuant.Indicators.PCU();
		}
		public PCU(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.PCU(series.series, length);
		}
		public PCU(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.PCU(indicator.indicator, length);
		}
		public PCU(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PCU(series.series, length, color);
		}
		public PCU(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PCU(indicator.indicator, length, color);
		}
	}
}
