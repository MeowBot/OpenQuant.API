using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class UltOsc : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("N1")]
		public int N1
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.UltOsc).N1;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.UltOsc).N1 = value;
			}
		}
		[Category("Parameters"), Description("N2")]
		public int N2
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.UltOsc).N2;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.UltOsc).N2 = value;
			}
		}
		[Category("Parameters"), Description("N3")]
		public int N3
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.UltOsc).N3;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.UltOsc).N3 = value;
			}
		}
		private UltOsc()
		{
			this.indicator = new SmartQuant.Indicators.UltOsc();
		}
		public UltOsc(BarSeries series, int n1, int n2, int n3)
		{
			this.indicator = new SmartQuant.Indicators.UltOsc(series.series, n1, n2, n3);
		}
		public UltOsc(global::OpenQuant.API.Indicator indicator, int n1, int n2, int n3)
		{
			this.indicator = new SmartQuant.Indicators.UltOsc(indicator.indicator, n1, n2, n3);
		}
		public UltOsc(BarSeries series, int n1, int n2, int n3, Color color)
		{
			this.indicator = new SmartQuant.Indicators.UltOsc(series.series, n1, n2, n3, color);
		}
		public UltOsc(global::OpenQuant.API.Indicator indicator, int n1, int n2, int n3, Color color)
		{
			this.indicator = new SmartQuant.Indicators.UltOsc(indicator.indicator, n1, n2, n3, color);
		}
	}
}
