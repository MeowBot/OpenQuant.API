using OpenQuant.API.Indicators;
using SmartQuant.Data;
using SmartQuant.FIX;
using SmartQuant.Indicators;
using SmartQuant.Series;
using SmartQuant.Trading;
using System;
namespace OpenQuant.API
{
	internal class EnumConverter
	{
		internal static OrderSide Convert(Side side)
		{
			switch (side)
			{
			case Side.Buy:
				return OrderSide.Buy;
			case Side.Sell:
				return OrderSide.Sell;
			default:
				throw new ArgumentException(string.Format("Side is not supported - {0}", side));
			}
		}
		internal static Side Convert(OrderSide side)
		{
			switch (side)
			{
			case OrderSide.Buy:
				return Side.Buy;
			case OrderSide.Sell:
				return Side.Sell;
			default:
				throw new ArgumentException(string.Format("Unsupported OrderSide - {0}", side));
			}
		}
		internal static OrderType Convert(OrdType type)
		{
			switch (type)
			{
			case OrdType.Market:
				return OrderType.Market;
			case OrdType.Limit:
				return OrderType.Limit;
			case OrdType.Stop:
				return OrderType.Stop;
			case OrdType.StopLimit:
				return OrderType.StopLimit;
			case OrdType.MarketOnClose:
				return OrderType.MarketOnClose;
			default:
				switch (type)
				{
				case OrdType.TrailingStop:
					return OrderType.Trail;
				case OrdType.TrailingStopLimit:
					return OrderType.TrailLimit;
				default:
					throw new ArgumentException(string.Format("OrdType is not supported - {0}", type));
				}
				break;
			}
		}
		internal static OrdType Convert(OrderType type)
		{
			switch (type)
			{
			case OrderType.Market:
				return OrdType.Market;
			case OrderType.Limit:
				return OrdType.Limit;
			case OrderType.Stop:
				return OrdType.Stop;
			case OrderType.StopLimit:
				return OrdType.StopLimit;
			case OrderType.Trail:
				return OrdType.TrailingStop;
			case OrderType.TrailLimit:
				return OrdType.TrailingStopLimit;
			case OrderType.MarketOnClose:
				return OrdType.MarketOnClose;
			default:
				throw new ArgumentException(string.Format("Unsupported OrderType - {0}", type));
			}
		}
		internal static OrderStatus Convert(OrdStatus status)
		{
			switch (status)
			{
			case OrdStatus.New:
				return OrderStatus.New;
			case OrdStatus.PartiallyFilled:
				return OrderStatus.PartiallyFilled;
			case OrdStatus.Filled:
				return OrderStatus.Filled;
			case OrdStatus.Cancelled:
				return OrderStatus.Cancelled;
			case OrdStatus.Replaced:
				return OrderStatus.Replaced;
			case OrdStatus.PendingCancel:
				return OrderStatus.PendingCancel;
			case OrdStatus.Rejected:
				return OrderStatus.Rejected;
			case OrdStatus.PendingNew:
				return OrderStatus.PendingNew;
			case OrdStatus.Expired:
				return OrderStatus.Expired;
			case OrdStatus.PendingReplace:
				return OrderStatus.PendingReplace;
			}
			throw new NotImplementedException("OrderStatus is not supported : " + status);
		}
		internal static CommType Convert(CommissionType commissionType)
		{
			switch (commissionType)
			{
			case CommissionType.PerShare:
				return CommType.PerShare;
			case CommissionType.Percent:
				return CommType.Percent;
			case CommissionType.Absolute:
				return CommType.Absolute;
			default:
				throw new NotImplementedException("CommissionType is not supported : " + commissionType);
			}
		}
		internal static OrdStatus Convert(OrderStatus status)
		{
			switch (status)
			{
			case OrderStatus.PendingNew:
				return OrdStatus.PendingNew;
			case OrderStatus.New:
				return OrdStatus.New;
			case OrderStatus.PartiallyFilled:
				return OrdStatus.PartiallyFilled;
			case OrderStatus.Filled:
				return OrdStatus.Filled;
			case OrderStatus.PendingCancel:
				return OrdStatus.PendingCancel;
			case OrderStatus.Cancelled:
				return OrdStatus.Cancelled;
			case OrderStatus.Expired:
				return OrdStatus.Expired;
			case OrderStatus.PendingReplace:
				return OrdStatus.PendingReplace;
			case OrderStatus.Replaced:
				return OrdStatus.Replaced;
			case OrderStatus.Rejected:
				return OrdStatus.Rejected;
			default:
				throw new NotImplementedException("OrderStatus is not supported : " + status);
			}
		}
		internal static InstrumentType Convert(string instrumentType)
		{
			switch (instrumentType)
			{
			case "TBOND":
				return InstrumentType.Bond;
			case "CS":
				return InstrumentType.Stock;
			case "FUT":
				return InstrumentType.Futures;
			case "OPT":
				return InstrumentType.Option;
			case "ETF":
				return InstrumentType.ETF;
			case "IDX":
				return InstrumentType.Index;
			case "FOR":
				return InstrumentType.FX;
			case "FOP":
				return InstrumentType.FutOpt;
			case "MLEG":
				return InstrumentType.MultiLeg;
			case "CMDTY":
				return InstrumentType.Commodity;
			}
			throw new NotImplementedException("SecurityType is not supported : " + instrumentType);
		}
		internal static string Convert(InstrumentType instrumentType)
		{
			switch (instrumentType)
			{
			case InstrumentType.Stock:
				return "CS";
			case InstrumentType.Futures:
				return "FUT";
			case InstrumentType.Option:
				return "OPT";
			case InstrumentType.FutOpt:
				return "FOP";
			case InstrumentType.Bond:
				return "TBOND";
			case InstrumentType.Index:
				return "IDX";
			case InstrumentType.ETF:
				return "ETF";
			case InstrumentType.FX:
				return "FOR";
			case InstrumentType.MultiLeg:
				return "MLEG";
			case InstrumentType.Commodity:
				return "CMDTY";
			default:
				throw new NotImplementedException("SecurityType is not supported : " + instrumentType);
			}
		}
		internal static BarType Convert(SmartQuant.Data.BarType barType)
		{
			switch (barType)
			{
			case SmartQuant.Data.BarType.Time:
				return BarType.Time;
			case SmartQuant.Data.BarType.Tick:
				return BarType.Tick;
			case SmartQuant.Data.BarType.Volume:
				return BarType.Volume;
			case SmartQuant.Data.BarType.Range:
				return BarType.Range;
			default:
				throw new NotImplementedException("BarType is not supported : " + barType);
			}
		}
		internal static SmartQuant.Data.BarType Convert(BarType barType)
		{
			switch (barType)
			{
			case BarType.Time:
				return SmartQuant.Data.BarType.Time;
			case BarType.Tick:
				return SmartQuant.Data.BarType.Tick;
			case BarType.Volume:
				return SmartQuant.Data.BarType.Volume;
			case BarType.Range:
				return SmartQuant.Data.BarType.Range;
			default:
				throw new NotImplementedException("BarType is not supported : " + barType);
			}
		}
		internal static global::OpenQuant.API.Indicators.RegressionDistanceMode Convert(SmartQuant.Indicators.RegressionDistanceMode mode)
		{
			switch (mode)
			{
			case SmartQuant.Indicators.RegressionDistanceMode.Time:
				return global::OpenQuant.API.Indicators.RegressionDistanceMode.Time;
			case SmartQuant.Indicators.RegressionDistanceMode.Index:
				return global::OpenQuant.API.Indicators.RegressionDistanceMode.Index;
			default:
				throw new NotImplementedException("RegressionDistanceMode is not supported : " + mode);
			}
		}
		internal static SmartQuant.Indicators.RegressionDistanceMode Convert(global::OpenQuant.API.Indicators.RegressionDistanceMode mode)
		{
			switch (mode)
			{
			case global::OpenQuant.API.Indicators.RegressionDistanceMode.Time:
				return SmartQuant.Indicators.RegressionDistanceMode.Time;
			case global::OpenQuant.API.Indicators.RegressionDistanceMode.Index:
				return SmartQuant.Indicators.RegressionDistanceMode.Index;
			default:
				throw new NotImplementedException("RegressionDistanceMode is not supported : " + mode);
			}
		}
		internal static SmartQuant.Data.BarData Convert(BarData barData)
		{
			switch (barData)
			{
			case BarData.Close:
				return SmartQuant.Data.BarData.Close;
			case BarData.Open:
				return SmartQuant.Data.BarData.Open;
			case BarData.High:
				return SmartQuant.Data.BarData.High;
			case BarData.Low:
				return SmartQuant.Data.BarData.Low;
			case BarData.Median:
				return SmartQuant.Data.BarData.Median;
			case BarData.Typical:
				return SmartQuant.Data.BarData.Typical;
			case BarData.Weighted:
				return SmartQuant.Data.BarData.Weighted;
			case BarData.Average:
				return SmartQuant.Data.BarData.Average;
			case BarData.Volume:
				return SmartQuant.Data.BarData.Volume;
			case BarData.OpenInt:
				return SmartQuant.Data.BarData.OpenInt;
			default:
				throw new NotImplementedException("BarData is not supported : " + barData);
			}
		}
		internal static Cross Convert(ECross cross)
		{
			switch (cross)
			{
			case ECross.Above:
				return Cross.Above;
			case ECross.Below:
				return Cross.Below;
			case ECross.None:
				return Cross.None;
			default:
				throw new NotImplementedException("Cross type is not supported : " + cross);
			}
		}
		internal static ECross Convert(Cross cross)
		{
			switch (cross)
			{
			case Cross.Above:
				return ECross.Above;
			case Cross.Below:
				return ECross.Below;
			case Cross.None:
				return ECross.None;
			default:
				throw new NotImplementedException("Cross type is not supported : " + cross);
			}
		}
		internal static SmartQuant.Trading.StopType Convert(StopType stopType)
		{
			switch (stopType)
			{
			case StopType.Fixed:
				return SmartQuant.Trading.StopType.Fixed;
			case StopType.Trailing:
				return SmartQuant.Trading.StopType.Trailing;
			case StopType.Time:
				return SmartQuant.Trading.StopType.Time;
			default:
				throw new NotImplementedException("Stop type is not supported : " + stopType);
			}
		}
		internal static StopType Convert(SmartQuant.Trading.StopType stopType)
		{
			switch (stopType)
			{
			case SmartQuant.Trading.StopType.Fixed:
				return StopType.Fixed;
			case SmartQuant.Trading.StopType.Trailing:
				return StopType.Trailing;
			case SmartQuant.Trading.StopType.Time:
				return StopType.Time;
			default:
				throw new NotImplementedException("Stop type is not supported : " + stopType);
			}
		}
		internal static SmartQuant.Trading.StopMode Convert(StopMode stopMode)
		{
			switch (stopMode)
			{
			case StopMode.Absolute:
				return SmartQuant.Trading.StopMode.Absolute;
			case StopMode.Percent:
				return SmartQuant.Trading.StopMode.Percent;
			default:
				throw new NotImplementedException("Stop mode is not supported : " + stopMode);
			}
		}
		internal static StopMode Convert(SmartQuant.Trading.StopMode stopMode)
		{
			switch (stopMode)
			{
			case SmartQuant.Trading.StopMode.Absolute:
				return StopMode.Absolute;
			case SmartQuant.Trading.StopMode.Percent:
				return StopMode.Percent;
			default:
				throw new NotImplementedException("Stop mode is not supported : " + stopMode);
			}
		}
		internal static SmartQuant.Trading.StopStatus Convert(StopStatus stopStatus)
		{
			switch (stopStatus)
			{
			case StopStatus.Active:
				return SmartQuant.Trading.StopStatus.Active;
			case StopStatus.Executed:
				return SmartQuant.Trading.StopStatus.Executed;
			case StopStatus.Canceled:
				return SmartQuant.Trading.StopStatus.Canceled;
			default:
				throw new NotImplementedException("Stop status is not supported : " + stopStatus);
			}
		}
		internal static StopStatus Convert(SmartQuant.Trading.StopStatus stopStatus)
		{
			switch (stopStatus)
			{
			case SmartQuant.Trading.StopStatus.Active:
				return StopStatus.Active;
			case SmartQuant.Trading.StopStatus.Executed:
				return StopStatus.Executed;
			case SmartQuant.Trading.StopStatus.Canceled:
				return StopStatus.Canceled;
			default:
				throw new NotImplementedException("Stop status is not supported : " + stopStatus);
			}
		}
		internal static PutCall Convert(PutOrCall value)
		{
			switch (value)
			{
			case PutOrCall.Put:
				return PutCall.Put;
			case PutOrCall.Call:
				return PutCall.Call;
			default:
				throw new ArgumentException(string.Format("Unsupported put or call: {0}", value));
			}
		}
		internal static PutOrCall Convert(PutCall value)
		{
			switch (value)
			{
			case PutCall.Put:
				return PutOrCall.Put;
			case PutCall.Call:
				return PutOrCall.Call;
			default:
				throw new ArgumentException(string.Format("Unsupported PutOrCall - {0}", value));
			}
		}
		internal static IndicatorStyle Convert(EIndicatorStyle indicatorStyle)
		{
			switch (indicatorStyle)
			{
			case EIndicatorStyle.QuantStudio:
				return IndicatorStyle.SmartQuant;
			case EIndicatorStyle.MetaStock:
				return IndicatorStyle.MetaStock;
			default:
				throw new NotImplementedException("Indicator style is not supported : " + indicatorStyle);
			}
		}
		internal static EIndicatorStyle Convert(IndicatorStyle indicatorStyle)
		{
			switch (indicatorStyle)
			{
			case IndicatorStyle.SmartQuant:
				return EIndicatorStyle.QuantStudio;
			case IndicatorStyle.MetaStock:
				return EIndicatorStyle.MetaStock;
			default:
				throw new NotImplementedException("Indicator style is not supported : " + indicatorStyle);
			}
		}
		internal static BidAsk Convert(MDSide side)
		{
			switch (side)
			{
			case MDSide.Bid:
				return BidAsk.Bid;
			case MDSide.Ask:
				return BidAsk.Ask;
			default:
				throw new NotSupportedException(string.Format("MDSide is not supported - {0}", side));
			}
		}
		internal static MDSide Convert(BidAsk side)
		{
			switch (side)
			{
			case BidAsk.Bid:
				return MDSide.Bid;
			case BidAsk.Ask:
				return MDSide.Ask;
			default:
				throw new NotSupportedException(string.Format("BidAsk is not supported - {0}", side));
			}
		}
		internal static OrderBookAction Convert(MDOperation operation)
		{
			switch (operation)
			{
			case MDOperation.Insert:
				return OrderBookAction.Insert;
			case MDOperation.Update:
				return OrderBookAction.Update;
			case MDOperation.Delete:
				return OrderBookAction.Delete;
			case (MDOperation)3:
				break;
			case MDOperation.Reset:
				return OrderBookAction.Reset;
			default:
				if (operation == MDOperation.Undefined)
				{
					return OrderBookAction.Undefined;
				}
				break;
			}
			throw new NotSupportedException(string.Format("MDOperation is not supported - {0}", operation));
		}
		internal static MDOperation Convert(OrderBookAction action)
		{
			switch (action)
			{
			case OrderBookAction.Insert:
				return MDOperation.Insert;
			case OrderBookAction.Update:
				return MDOperation.Update;
			case OrderBookAction.Delete:
				return MDOperation.Delete;
			case OrderBookAction.Reset:
				return MDOperation.Reset;
			case OrderBookAction.Undefined:
				return MDOperation.Undefined;
			default:
				throw new NotSupportedException(string.Format("OrderBookAction is not supported - {0}", action));
			}
		}
	}
}
