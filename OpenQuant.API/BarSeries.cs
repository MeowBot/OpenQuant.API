using SmartQuant.Data;
using SmartQuant.Series;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class BarSeries : IEnumerable, ISeries
	{
		internal SmartQuant.Series.BarSeries series;
		public string Name
		{
			get
			{
				return this.series.Name;
			}
		}
		public int Count
		{
			get
			{
				return this.series.Count;
			}
		}
		public Bar First
		{
			get
			{
				return new Bar(this.series.First);
			}
		}
		public Bar Last
		{
			get
			{
				return new Bar(this.series.Last);
			}
		}
		public Bar this[int index]
		{
			get
			{
				return new Bar(this.series[index]);
			}
		}
		public Bar this[DateTime dateTime]
		{
			get
			{
				SmartQuant.Data.Bar bar = this.series[dateTime];
				if (bar == null)
				{
					return null;
				}
				return new Bar(bar);
			}
		}
		public double this[DateTime dateTime, BarData barData]
		{
			get
			{
				Bar bar = this[dateTime];
				switch (barData)
				{
				case BarData.Close:
					return bar.Close;
				case BarData.Open:
					return bar.Open;
				case BarData.High:
					return bar.High;
				case BarData.Low:
					return bar.Low;
				case BarData.Median:
					return bar.Median;
				case BarData.Typical:
					return bar.Typical;
				case BarData.Weighted:
					return bar.Weighted;
				case BarData.Average:
					return bar.Average;
				case BarData.Volume:
					return (double)bar.Volume;
				case BarData.OpenInt:
					return (double)bar.OpenInt;
				default:
					throw new NotSupportedException("BarData " + barData + " is not supported");
				}
			}
		}
		public double this[int index, BarData barData]
		{
			get
			{
				return this[this.series.GetDateTime(index), barData];
			}
		}
		public Bar this[DateTime dateTime, SearchOption searchOption]
		{
			get
			{
				if (searchOption == SearchOption.Next)
				{
					return new Bar(this.series[dateTime, EIndexOption.Next]);
				}
				return new Bar(this.series[dateTime, EIndexOption.Prev]);
			}
		}
		internal BarSeries(SmartQuant.Series.BarSeries series)
		{
			this.series = series;
		}
		public BarSeries(string name, string title)
		{
			this.series = new SmartQuant.Series.BarSeries(name, title);
		}
		public BarSeries(string name) : this(name, "")
		{
		}
		public BarSeries() : this("", "")
		{
		}
		public void Add(Bar bar)
		{
			this.series.Add(bar.bar);
		}
		public void Add(DateTime datetime, double open, double high, double low, double close, long volume, long size)
		{
			this.series.Add(new SmartQuant.Data.Bar(datetime, open, high, low, close, volume, size));
		}
		public void Add(BarType barType, long size, DateTime beginTime, DateTime endTime, double open, double high, double low, double close, long volume, long openInt)
		{
			this.series.Add(new SmartQuant.Data.Bar(EnumConverter.Convert(barType), size, beginTime, endTime, open, high, low, close, volume, openInt));
		}
		public void Remove(DateTime dateTime)
		{
			this.series.Remove(dateTime);
		}
		public void Remove(int index)
		{
			this.series.Remove(index);
		}
		public bool Contains(DateTime dateTime)
		{
			return this.series.Contains(dateTime);
		}
		public bool Contains(Bar bar)
		{
			return this.series.Contains(bar.DateTime);
		}
		public DateTime GetDateTime(int index)
		{
			return this.series.GetDateTime(index);
		}
		public int GetIndex(DateTime dateTime)
		{
			return this.series.GetIndex(dateTime);
		}
		public Bar Ago(int n)
		{
			return new Bar(this.series.Ago(n));
		}
		public virtual Cross Crosses(TimeSeries series, DateTime dateTime)
		{
			return EnumConverter.Convert(this.series.Crosses(series.series, dateTime));
		}
		public virtual bool CrossesBelow(TimeSeries series, DateTime dateTime)
		{
			return this.series.CrossesBelow(series.series, dateTime);
		}
		public virtual bool CrossesAbove(TimeSeries series, DateTime dateTime)
		{
			return this.series.CrossesAbove(series.series, dateTime);
		}
		public bool CrossesBelow(BarSeries series, Bar bar)
		{
			return this.series.CrossesBelow(series.series, bar.bar);
		}
		public bool CrossesAbove(BarSeries series, Bar bar)
		{
			return this.series.CrossesAbove(series.series, bar.bar);
		}
		public bool CrossesBelow(Indicator indicator, Bar bar)
		{
			return this.series.CrossesBelow(indicator.indicator, bar.bar);
		}
		public bool CrossesAbove(Indicator indicator, Bar bar)
		{
			return this.series.CrossesAbove(indicator.indicator, bar.bar);
		}
		public Cross Crosses(Indicator indicator, Bar bar)
		{
			return EnumConverter.Convert(this.series.Crosses(indicator.indicator, bar.bar));
		}
		public Cross Crosses(BarSeries series, Bar bar)
		{
			return EnumConverter.Convert(this.series.Crosses(series.series, bar.bar));
		}
		public double HighestHigh()
		{
			return this.series.HighestHigh();
		}
		public double HighestHigh(int nBars)
		{
			return this.series.HighestHigh(nBars);
		}
		public double HighestHigh(DateTime dateTime1, DateTime dateTime2)
		{
			return this.series.HighestHigh(dateTime1, dateTime2);
		}
		public double HighestHigh(int index1, int index2)
		{
			return this.series.HighestHigh(index1, index2);
		}
		public double LowestLow()
		{
			return this.series.LowestLow();
		}
		public double LowestLow(int nBars)
		{
			return this.series.LowestLow(nBars);
		}
		public double LowestLow(DateTime dateTime1, DateTime dateTime2)
		{
			return this.series.LowestLow(dateTime1, dateTime2);
		}
		public double LowestLow(int index1, int index2)
		{
			return this.series.LowestLow(index1, index2);
		}
		public BarSeries Compress(long newBarSize)
		{
			return new BarSeries(this.series.Compress(newBarSize));
		}
		public BarSeries GetRange(DateTime dateTime1, DateTime dateTime2)
		{
			BarSeries barSeries = new BarSeries();
			int index = this.series.GetIndex(dateTime1, EIndexOption.Next);
			int index2 = this.series.GetIndex(dateTime1, EIndexOption.Prev);
			if (index != -1 && index2 != -1)
			{
				for (int i = index; i <= index2; i++)
				{
					barSeries.Add(new Bar(this.series[i]));
				}
			}
			return barSeries;
		}
		public void Clear()
		{
			this.series.Clear();
		}
		public IEnumerator GetEnumerator()
		{
			return new BarSeriesEnumerator(this.series);
		}
		double ISeries.Ago(int n)
		{
			return this.series.Ago(n).Close;
		}
	}
}
