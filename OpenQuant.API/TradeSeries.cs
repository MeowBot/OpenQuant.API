using SmartQuant.Data;
using SmartQuant.Series;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class TradeSeries : IEnumerable
	{
		private class TradeSeriesEnumerator : IEnumerator
		{
			private TradeArray series;
			private IEnumerator enumerator;
			public object Current
			{
				get
				{
					SmartQuant.Data.Trade trade = this.enumerator.Current as SmartQuant.Data.Trade;
					return new Trade(trade);
				}
			}
			public TradeSeriesEnumerator(TradeArray series)
			{
				this.series = series;
				this.enumerator = series.GetEnumerator();
			}
			public bool MoveNext()
			{
				return this.enumerator.MoveNext();
			}
			public void Reset()
			{
				this.enumerator.Reset();
			}
		}
		internal TradeArray series;
		public int Count
		{
			get
			{
				return this.series.Count;
			}
		}
		public Trade Last
		{
			get
			{
				if (this.series.Count > 0)
				{
					return new Trade(this.series[this.series.Count - 1]);
				}
				return null;
			}
		}
		public Trade this[int index]
		{
			get
			{
				return new Trade(this.series[index]);
			}
		}
		internal TradeSeries(TradeArray series)
		{
			this.series = series;
		}
		public TradeSeries()
		{
			this.series = new TradeArray();
		}
		public void Add(Trade trade)
		{
			this.series.Add(trade.trade);
		}
		public BarSeries CompressBars(BarType barType, long barSize)
		{
			return DataManager.CompressBars(this, barType, barSize);
		}
		public IEnumerator GetEnumerator()
		{
			return new TradeSeries.TradeSeriesEnumerator(this.series);
		}
		public void Clear()
		{
			this.series.Clear();
		}
	}
}
