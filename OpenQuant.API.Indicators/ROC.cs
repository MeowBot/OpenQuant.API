using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class ROC : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.ROC).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.ROC).Length = value;
			}
		}
		private ROC()
		{
			this.indicator = new SmartQuant.Indicators.ROC();
		}
		public ROC(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.ROC(series.series, length);
		}
		public ROC(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.ROC(indicator.indicator, length);
		}
		public ROC(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.ROC(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public ROC(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.ROC(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public ROC(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ROC(series.series, length, color);
		}
		public ROC(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ROC(indicator.indicator, length, color);
		}
		public ROC(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ROC(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public ROC(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.ROC(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
