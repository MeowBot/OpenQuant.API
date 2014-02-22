using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class PVT : global::OpenQuant.API.Indicator
	{
		private PVT()
		{
			this.indicator = new SmartQuant.Indicators.PVT();
		}
		public PVT(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.PVT(series.series);
		}
		public PVT(global::OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.PVT(indicator.indicator);
		}
		public PVT(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PVT(series.series, color);
		}
		public PVT(global::OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PVT(indicator.indicator, color);
		}
	}
}
