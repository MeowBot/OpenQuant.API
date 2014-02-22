using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class KRI : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.KRI).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.KRI).Length = value;
			}
		}
		private KRI()
		{
			this.indicator = new SmartQuant.Indicators.KRI();
		}
		public KRI(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.KRI(series.series, length);
		}
		public KRI(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.KRI(indicator.indicator, length);
		}
		public KRI(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.KRI(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public KRI(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.KRI(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public KRI(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KRI(series.series, length, color);
		}
		public KRI(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KRI(indicator.indicator, length, color);
		}
		public KRI(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KRI(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public KRI(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.KRI(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
