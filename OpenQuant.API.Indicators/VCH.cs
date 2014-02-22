using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class VCH : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length1")]
		public int Length1
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.VCH).Length1;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.VCH).Length1 = value;
			}
		}
		[Category("Parameters"), Description("Length2")]
		public int Length2
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.VCH).Length2;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.VCH).Length2 = value;
			}
		}
		private VCH()
		{
			this.indicator = new SmartQuant.Indicators.VCH();
		}
		public VCH(BarSeries series, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.VCH(series.series, length1, length2);
		}
		public VCH(OpenQuant.API.Indicator indicator, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.VCH(indicator.indicator, length1, length2);
		}
		public VCH(BarSeries series, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VCH(series.series, length1, length2, color);
		}
		public VCH(OpenQuant.API.Indicator indicator, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VCH(indicator.indicator, length1, length2, color);
		}
	}
}
