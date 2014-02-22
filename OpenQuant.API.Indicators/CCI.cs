using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class CCI : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.CCI).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.CCI).Length = value;
			}
		}
		private CCI()
		{
			this.indicator = new SmartQuant.Indicators.CCI();
		}
		public CCI(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.CCI(series.series, length);
		}
		public CCI(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.CCI(indicator.indicator, length);
		}
		public CCI(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.CCI(series.series, length);
		}
		public CCI(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CCI(series.series, length, color);
		}
		public CCI(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CCI(indicator.indicator, length, color);
		}
		public CCI(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CCI(series.series, length, color);
		}
	}
}
