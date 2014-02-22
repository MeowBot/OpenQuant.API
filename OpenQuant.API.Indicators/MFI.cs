using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class MFI : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.MFI).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.MFI).Length = value;
			}
		}
		private MFI()
		{
			this.indicator = new SmartQuant.Indicators.MFI();
		}
		public MFI(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.MFI(series.series, length);
		}
		public MFI(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.MFI(indicator.indicator, length);
		}
		public MFI(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MFI(series.series, length, color);
		}
		public MFI(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MFI(indicator.indicator, length, color);
		}
	}
}
