using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class LRI : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.LRI).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.LRI).Length = value;
			}
		}
		[Category("Parameters"), Description("Distance Mode")]
		public RegressionDistanceMode DistanceMode
		{
			get
			{
				return global::OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.LRI).DistanceMode);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.LRI).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private LRI()
		{
			this.indicator = new SmartQuant.Indicators.LRI();
		}
		public LRI(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.LRI(series.series, length);
		}
		public LRI(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.LRI(indicator.indicator, length);
		}
		public LRI(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.LRI(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public LRI(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.LRI(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public LRI(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRI(series.series, length, color);
		}
		public LRI(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRI(indicator.indicator, length, color);
		}
		public LRI(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRI(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public LRI(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRI(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public LRI(BarSeries series, int length, RegressionDistanceMode distanceMode)
		{
			this.indicator = new SmartQuant.Indicators.LRI(series.series, length);
		}
		public LRI(global::OpenQuant.API.Indicator indicator, int length, RegressionDistanceMode distanceMode)
		{
			this.indicator = new SmartQuant.Indicators.LRI(indicator.indicator, length);
		}
		public LRI(BarSeries series, int length, RegressionDistanceMode distanceMode, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.LRI(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public LRI(global::OpenQuant.API.Indicator indicator, int length, RegressionDistanceMode distanceMode, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.LRI(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public LRI(BarSeries series, int length, RegressionDistanceMode distanceMode, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRI(series.series, length, color);
		}
		public LRI(global::OpenQuant.API.Indicator indicator, int length, RegressionDistanceMode distanceMode, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRI(indicator.indicator, length, color);
		}
		public LRI(BarSeries series, int length, RegressionDistanceMode distanceMode, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRI(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public LRI(global::OpenQuant.API.Indicator indicator, int length, RegressionDistanceMode distanceMode, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRI(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}
