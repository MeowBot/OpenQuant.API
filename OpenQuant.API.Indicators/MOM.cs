using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class MOM : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.MOM).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.MOM).Length = value;
			}
		}
		private MOM()
		{
			this.indicator = new SmartQuant.Indicators.MOM();
		}
		public MOM(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.MOM(series.series, length);
		}
		public MOM(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.MOM(indicator.indicator, length);
		}
		public MOM(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.MOM(series.series, length);
		}
		public MOM(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.MOM(series.series, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public MOM(OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.MOM(indicator.indicator, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public MOM(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MOM(series.series, length, color);
		}
		public MOM(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MOM(indicator.indicator, length, color);
		}
		public MOM(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MOM(series.series, length, color);
		}
		public MOM(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MOM(series.series, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
