using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class CAD : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length1")]
		public int Length1
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.CAD).Length1;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.CAD).Length1 = value;
			}
		}
		[Category("Parameters"), Description("Length2")]
		public int Length2
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.CAD).Length2;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.CAD).Length2 = value;
			}
		}
		private CAD()
		{
			this.indicator = new SmartQuant.Indicators.CAD();
		}
		public CAD(BarSeries series, int length1, int lenght2)
		{
			this.indicator = new SmartQuant.Indicators.CAD(series.series, length1, lenght2);
		}
		public CAD(global::OpenQuant.API.Indicator indicator, int length1, int lenght2)
		{
			this.indicator = new SmartQuant.Indicators.CAD(indicator.indicator, length1, lenght2);
		}
		public CAD(BarSeries series, int length1, int lenght2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CAD(series.series, length1, lenght2, color);
		}
		public CAD(global::OpenQuant.API.Indicator indicator, int length1, int lenght2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CAD(indicator.indicator, length1, lenght2, color);
		}
	}
}
