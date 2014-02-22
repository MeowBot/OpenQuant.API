using OpenQuant.ObjectMap;
using SmartQuant.Providers;
using System;
namespace OpenQuant.API
{
	public class HistoricalDataRequest
	{
		internal SmartQuant.Providers.HistoricalDataRequest request;
		public Instrument Instrument
		{
			get
			{
				return Map.SQ_OQ_Instrument[this.request.Instrument] as Instrument;
			}
		}
		public DataType DataType
		{
			get
			{
				HistoricalDataType dataType = this.request.DataType;
				switch (dataType)
				{
				case HistoricalDataType.Trade:
					return DataType.Trade;
				case HistoricalDataType.Quote:
					return DataType.Quote;
				case HistoricalDataType.Trade | HistoricalDataType.Quote:
					break;
				case HistoricalDataType.Bar:
					return DataType.Bar;
				default:
					if (dataType == HistoricalDataType.Daily)
					{
						return DataType.Daily;
					}
					break;
				}
				throw new ArgumentException(string.Format("Not supported data type - {0}", this.request.DataType));
			}
		}
		public long BarSize
		{
			get
			{
				return this.request.BarSize;
			}
		}
		public DateTime BeginDate
		{
			get
			{
				return this.request.BeginDate;
			}
		}
		public DateTime EndDate
		{
			get
			{
				return this.request.EndDate;
			}
		}
		internal HistoricalDataRequest(SmartQuant.Providers.HistoricalDataRequest request)
		{
			this.request = request;
		}
	}
}
