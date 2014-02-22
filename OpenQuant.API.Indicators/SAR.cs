using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class SAR : global::OpenQuant.API.Indicator
	{
		public double InitialAcc
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.SAR).InitialAcc;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.SAR).InitialAcc = value;
			}
		}
		public double UpperBound
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.SAR).UpperBound;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.SAR).UpperBound = value;
			}
		}
		public double Step
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.SAR).Step;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.SAR).Step = value;
			}
		}
		private SAR()
		{
			this.indicator = new SmartQuant.Indicators.SAR();
		}
		public SAR(BarSeries series, double upperBound, double step, double initialAcc)
		{
			this.indicator = new SmartQuant.Indicators.SAR(series.series, upperBound, step, initialAcc);
		}
		public SAR(global::OpenQuant.API.Indicator indicator, double upperBound, double step, double initialAcc)
		{
			this.indicator = new SmartQuant.Indicators.SAR(indicator.indicator, upperBound, step, initialAcc);
		}
		public SAR(BarSeries series, double upperBound, double step, double initialAcc, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SAR(series.series, upperBound, step, initialAcc, color);
		}
		public SAR(global::OpenQuant.API.Indicator indicator, double upperBound, double step, double initialAcc, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SAR(indicator.indicator, upperBound, step, initialAcc, color);
		}
	}
}
