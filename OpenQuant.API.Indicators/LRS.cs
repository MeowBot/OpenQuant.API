using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class LRS : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.LRS).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.LRS).Length = value;
			}
		}
		[Category("Parameters"), Description("Distance Mode")]
		public RegressionDistanceMode DistanceMode
		{
			get
			{
				return global::OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.LRS).DistanceMode);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private LRS()
		{
			this.indicator = new SmartQuant.Indicators.LRS();
		}
		public LRS(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.LRS(series.series, length);
		}
		public LRS(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.LRS(indicator.indicator, length);
		}
		public LRS(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.LRS(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public LRS(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.LRS(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public LRS(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRS(series.series, length, color);
		}
		public LRS(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRS(indicator.indicator, length, color);
		}
		public LRS(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRS(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public LRS(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRS(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public LRS(BarSeries series, int length, RegressionDistanceMode distanceMode)
		{
			this.indicator = new SmartQuant.Indicators.LRS(series.series, length);
			(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(distanceMode);
		}
		public LRS(global::OpenQuant.API.Indicator indicator, int length, RegressionDistanceMode distanceMode)
		{
			this.indicator = new SmartQuant.Indicators.LRS(indicator.indicator, length);
			(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(distanceMode);
		}
		public LRS(BarSeries series, int length, RegressionDistanceMode distanceMode, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.LRS(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
			(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(distanceMode);
		}
		public LRS(global::OpenQuant.API.Indicator indicator, int length, RegressionDistanceMode distanceMode, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.LRS(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
			(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(distanceMode);
		}
		public LRS(BarSeries series, int length, RegressionDistanceMode distanceMode, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRS(series.series, length, color);
			(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(distanceMode);
		}
		public LRS(global::OpenQuant.API.Indicator indicator, int length, RegressionDistanceMode distanceMode, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRS(indicator.indicator, length, color);
			(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(distanceMode);
		}
		public LRS(BarSeries series, int length, RegressionDistanceMode distanceMode, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRS(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
			(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(distanceMode);
		}
		public LRS(global::OpenQuant.API.Indicator indicator, int length, RegressionDistanceMode distanceMode, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.LRS(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
			(this.indicator as SmartQuant.Indicators.LRS).DistanceMode = global::OpenQuant.API.EnumConverter.Convert(distanceMode);
		}
	}
}
