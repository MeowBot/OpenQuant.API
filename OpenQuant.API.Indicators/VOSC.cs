using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class VOSC : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length1")]
		public int Length1
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.VOSC).Length1;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.VOSC).Length1 = value;
			}
		}
		[Category("Parameters"), Description("Length2")]
		public int Length2
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.VOSC).Length2;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.VOSC).Length2 = value;
			}
		}
		private VOSC()
		{
			this.indicator = new SmartQuant.Indicators.VOSC();
		}
		public VOSC(BarSeries series, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.VOSC(series.series, length1, length2);
		}
		public VOSC(OpenQuant.API.Indicator indicator, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.VOSC(indicator.indicator, length1, length2);
		}
		public VOSC(BarSeries series, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VOSC(series.series, length1, length2, color);
		}
		public VOSC(OpenQuant.API.Indicator indicator, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VOSC(indicator.indicator, length1, length2, color);
		}
	}
}
