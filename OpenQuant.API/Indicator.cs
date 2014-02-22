using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API
{
	public class Indicator : ISeries
	{
		internal SmartQuant.Indicators.Indicator indicator;
		[Browsable(false)]
		public string Name
		{
			get
			{
				return this.indicator.Name;
			}
			set
			{
				this.indicator.Name = value;
			}
		}
		[Browsable(false)]
		public string Description
		{
			get
			{
				return this.indicator.Title;
			}
			set
			{
				this.indicator.Title = value;
			}
		}
		[Category("Drawing"), Description("Gets or sets indicator color")]
		public Color Color
		{
			get
			{
				return this.indicator.Color;
			}
			set
			{
				this.indicator.Color = value;
			}
		}
		[Category("Drawing"), Description("Gets or sets indicator width")]
		public int Width
		{
			get
			{
				return this.indicator.DrawWidth;
			}
			set
			{
				this.indicator.DrawWidth = value;
			}
		}
		public virtual double this[int index]
		{
			get
			{
				return this.indicator[index];
			}
		}
		public virtual double this[DateTime dateTime]
		{
			get
			{
				return this.indicator[dateTime];
			}
		}
		[Browsable(false)]
		public virtual int Count
		{
			get
			{
				return this.indicator.Count;
			}
		}
		public virtual double this[Bar bar]
		{
			get
			{
				return this.indicator[bar.DateTime];
			}
		}
		[Browsable(false)]
		public virtual double Last
		{
			get
			{
				return this.indicator.Last;
			}
		}
		[Browsable(false)]
		public virtual DateTime FirstDateTime
		{
			get
			{
				return this.indicator.FirstDateTime;
			}
		}
		[Browsable(false)]
		public virtual DateTime LastDateTime
		{
			get
			{
				return this.indicator.LastDateTime;
			}
		}
		public virtual double this[DateTime dateTime, BarData barData]
		{
			get
			{
				return this.indicator[dateTime];
			}
		}
		public virtual double this[int index, BarData barData]
		{
			get
			{
				return this.indicator[index];
			}
		}
		public virtual double Ago(int n)
		{
			return this.indicator.Ago(n);
		}
		public virtual bool Contains(DateTime dateTime)
		{
			return this.indicator.Contains(dateTime);
		}
		public virtual bool Contains(Bar bar)
		{
			return this.indicator.Contains(bar.DateTime);
		}
		public virtual Cross Crosses(TimeSeries series, DateTime dateTime)
		{
			return EnumConverter.Convert(this.indicator.Crosses(series.series, dateTime));
		}
		public virtual bool CrossesBelow(TimeSeries series, DateTime dateTime)
		{
			return this.indicator.CrossesBelow(series.series, dateTime);
		}
		public virtual bool CrossesAbove(TimeSeries series, DateTime dateTime)
		{
			return this.indicator.CrossesAbove(series.series, dateTime);
		}
		public virtual bool CrossesBelow(BarSeries series, Bar bar)
		{
			return this.indicator.CrossesBelow(series.series, bar.bar);
		}
		public virtual bool CrossesAbove(BarSeries series, Bar bar)
		{
			return this.indicator.CrossesAbove(series.series, bar.bar);
		}
		public virtual bool CrossesBelow(Indicator indicator, Bar bar)
		{
			return this.indicator.CrossesBelow(indicator.indicator, bar.bar);
		}
		public virtual bool CrossesAbove(Indicator indicator, Bar bar)
		{
			return this.indicator.CrossesAbove(indicator.indicator, bar.bar);
		}
		public virtual Cross Crosses(Indicator indicator, Bar bar)
		{
			return EnumConverter.Convert(this.indicator.Crosses(indicator.indicator, bar.bar));
		}
		public virtual Cross Crosses(BarSeries series, Bar bar)
		{
			return EnumConverter.Convert(this.indicator.Crosses(series.series, bar.bar));
		}
		public virtual bool CrossesBelow(BarSeries series, Bar bar, BarData barData)
		{
			return this.indicator.CrossesBelow(series.series, bar.bar, (int)barData);
		}
		public virtual bool CrossesAbove(BarSeries series, Bar bar, BarData barData)
		{
			return this.indicator.CrossesAbove(series.series, bar.bar, (int)barData);
		}
		public virtual Cross Crosses(BarSeries series, Bar bar, BarData barData)
		{
			return EnumConverter.Convert(this.indicator.Crosses(series.series, bar.bar, (int)barData));
		}
		public virtual bool CrossesBelow(double level, Bar bar)
		{
			return this.indicator.CrossesBelow(level, this.indicator.GetIndex(bar.DateTime));
		}
		public virtual bool CrossesAbove(double level, Bar bar)
		{
			return this.indicator.CrossesAbove(level, this.indicator.GetIndex(bar.DateTime));
		}
		public virtual Cross Crosses(double level, Bar bar)
		{
			return EnumConverter.Convert(this.indicator.Crosses(level, this.indicator.GetIndex(bar.DateTime)));
		}
		public virtual DateTime GetDateTime(int index)
		{
			return this.indicator.GetDateTime(index);
		}
		public int GetIndex(DateTime dateTime)
		{
			return this.indicator.GetIndex(dateTime);
		}
		public double GetMax(int index1, int index2)
		{
			return this.indicator.GetMax(index1, index2);
		}
		public double GetMax(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetMax(dateTime1, dateTime2);
		}
		public double GetMin(int index1, int index2)
		{
			return this.indicator.GetMin(index1, index2);
		}
		public double GetMin(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetMin(dateTime1, dateTime2);
		}
		public double GetAsymmetry(int index1, int index2)
		{
			return this.indicator.GetAsymmetry(index1, index2);
		}
		public double GetAsymmetry(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetAsymmetry(dateTime1, dateTime2);
		}
		public double GetAutoCorrelation(int lag)
		{
			return this.indicator.GetAutoCorrelation(lag);
		}
		public double GetAutoCovariance(int lag)
		{
			return this.indicator.GetAutoCovariance(lag);
		}
		public double GetCorrelation(TimeSeries timeSeries)
		{
			return this.indicator.GetCorrelation(timeSeries.series);
		}
		public double GetCovariance(TimeSeries timeSeries)
		{
			return this.indicator.GetCovariance(timeSeries.series);
		}
		public double GetExcess(int index1, int index2)
		{
			return this.indicator.GetExcess(index1, index2);
		}
		public double GetExcess(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetExcess(dateTime1, dateTime2);
		}
		public double GetMean(int index1, int index2)
		{
			return this.indicator.GetMean(index1, index2);
		}
		public double GetMean(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetMean(dateTime1, dateTime2);
		}
		public double GetMedian(int index1, int index2)
		{
			return this.indicator.GetMedian(index1, index2);
		}
		public double GetMedian(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetMedian(dateTime1, dateTime2);
		}
		public double GetMoment(int k, int index1, int index2)
		{
			return this.indicator.GetMoment(k, index1, index2);
		}
		public double GetMoment(int k, DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetMoment(k, dateTime1, dateTime2);
		}
		public double GetNegativeStdDev(int index1, int index2)
		{
			return this.indicator.GetNegativeStdDev(index1, index2);
		}
		public double GetNegativeStdDev(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetNegativeStdDev(dateTime1, dateTime2);
		}
		public double GetNegativeVariance(int index1, int index2)
		{
			return this.indicator.GetNegativeVariance(index1, index2);
		}
		public double GetNegativeVariance(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetNegativeVariance(dateTime1, dateTime2);
		}
		public double GetPositiveStdDev(int index1, int index2)
		{
			return this.indicator.GetPositiveStdDev(index1, index2);
		}
		public double GetPositiveStdDev(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetPositiveStdDev(dateTime1, dateTime2);
		}
		public double GetPositiveVariance(int index1, int index2)
		{
			return this.indicator.GetPositiveVariance(index1, index2);
		}
		public double GetPositiveVariance(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetPositiveVariance(dateTime1, dateTime2);
		}
		public double GetStdDev(int index1, int index2)
		{
			return this.indicator.GetStdDev(index1, index2);
		}
		public double GetStdDev(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetStdDev(dateTime1, dateTime2);
		}
		public double GetSum(int index1, int index2)
		{
			return this.indicator.GetSum(index1, index2);
		}
		public double GetSum(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetSum(dateTime1, dateTime2);
		}
		public double GetVariance(int index1, int index2)
		{
			return this.indicator.GetVariance(index1, index2);
		}
		public double GetVariance(DateTime dateTime1, DateTime dateTime2)
		{
			return this.indicator.GetVariance(dateTime1, dateTime2);
		}
		public static TimeSeries operator +(Indicator indicator1, Indicator indicator2)
		{
			return new TimeSeries(indicator1.indicator + indicator2.indicator);
		}
		public static TimeSeries operator -(Indicator indicator1, Indicator indicator2)
		{
			return new TimeSeries(indicator1.indicator - indicator2.indicator);
		}
		public static TimeSeries operator *(Indicator indicator1, Indicator indicator2)
		{
			return new TimeSeries(indicator1.indicator * indicator2.indicator);
		}
		public static TimeSeries operator /(Indicator indicator1, Indicator indicator2)
		{
			return new TimeSeries(indicator1.indicator / indicator2.indicator);
		}
	}
}
