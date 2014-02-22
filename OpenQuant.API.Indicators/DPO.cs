using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class DPO : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.DPO).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.DPO).Length = value;
			}
		}
		private DPO()
		{
			this.indicator = new SmartQuant.Indicators.DPO();
		}
		public DPO(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.DPO(series.series, length);
		}
		public DPO(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.DPO(indicator.indicator, length);
		}
		public DPO(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.DPO(series.series, length);
		}
		public DPO(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.DPO(series.series, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public DPO(OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.DPO(indicator.indicator, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public DPO(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.DPO(series.series, length, color);
		}
		public DPO(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.DPO(indicator.indicator, length, color);
		}
		public DPO(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.DPO(series.series, length, color);
		}
		public DPO(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.DPO(series.series, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
