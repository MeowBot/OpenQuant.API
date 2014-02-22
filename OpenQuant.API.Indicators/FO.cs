using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class FO : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.FO).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.FO).Length = value;
			}
		}
		[Category("Parameters"), Description("Distance Mode")]
		public RegressionDistanceMode DistanceMode
		{
			get
			{
				return global::OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.FO).DistanceMode);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.FO).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private FO()
		{
			this.indicator = new SmartQuant.Indicators.FO();
		}
		public FO(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.FO(series.series, length);
		}
		public FO(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.FO(indicator.indicator, length);
		}
		public FO(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.FO(series.series, length);
		}
		public FO(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.FO(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public FO(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.FO(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public FO(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.FO(series.series, length, color);
		}
		public FO(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.FO(indicator.indicator, length, color);
		}
		public FO(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.FO(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
