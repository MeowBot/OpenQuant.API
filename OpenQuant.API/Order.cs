using OpenQuant.Config;
using OpenQuant.ObjectMap;
using SmartQuant.Execution;
using SmartQuant.FIX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace OpenQuant.API
{
	public class Order
	{
		private const string CATEGORY_APPEARANCE = "Appearance";
		private const string CATEGORY_EXECUTION = "Execution";
		private const string CATEGORY_STATUS = "Status";
		private const string CATEGORY_EXTENSIONS = "Extensions";
		internal SingleOrder order;
		private Instrument instrument;
		private IBEx ibEx;
		[Category("Appearance")]
		public DateTime DateTime
		{
			get
			{
				return this.order.TransactTime;
			}
		}
		[Category("Appearance")]
		public Instrument Instrument
		{
			get
			{
				return this.instrument;
			}
		}
		[Category("Appearance")]
		public OrderSide Side
		{
			get
			{
				switch (this.order.Side)
				{
				case SmartQuant.FIX.Side.Buy:
					return OrderSide.Buy;
				case SmartQuant.FIX.Side.Sell:
					return OrderSide.Sell;
				default:
					throw new NotImplementedException("OrderSide is not supported : " + this.order.Side);
				}
			}
		}
		[Category("Appearance")]
		public OrderType Type
		{
			get
			{
				OrdType ordType = this.order.OrdType;
				switch (ordType)
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
					switch (ordType)
					{
					case OrdType.TrailingStop:
						return OrderType.Trail;
					case OrdType.TrailingStopLimit:
						return OrderType.TrailLimit;
					default:
						throw new NotImplementedException("OrderType is not supported : " + this.order.OrdType);
					}
					break;
				}
			}
			set
			{
				switch (value)
				{
				case OrderType.Market:
					this.order.OrdType = OrdType.Market;
					return;
				case OrderType.Limit:
					this.order.OrdType = OrdType.Limit;
					return;
				case OrderType.Stop:
					this.order.OrdType = OrdType.Stop;
					return;
				case OrderType.StopLimit:
					this.order.OrdType = OrdType.StopLimit;
					return;
				case OrderType.Trail:
					this.order.OrdType = OrdType.TrailingStop;
					return;
				case OrderType.TrailLimit:
					this.order.OrdType = OrdType.TrailingStopLimit;
					return;
				case OrderType.MarketOnClose:
					this.order.OrdType = OrdType.MarketOnClose;
					return;
				default:
					throw new NotImplementedException("OrderType is not supported : " + value);
				}
			}
		}
		[Category("Appearance")]
		public TimeInForce TimeInForce
		{
			get
			{
				switch (this.order.TimeInForce)
				{
				case SmartQuant.FIX.TimeInForce.Day:
					return TimeInForce.Day;
				case SmartQuant.FIX.TimeInForce.GTC:
					return TimeInForce.GTC;
				case SmartQuant.FIX.TimeInForce.OPG:
					return TimeInForce.OPG;
				case SmartQuant.FIX.TimeInForce.IOC:
					return TimeInForce.IOC;
				case SmartQuant.FIX.TimeInForce.FOK:
					return TimeInForce.FOK;
				case SmartQuant.FIX.TimeInForce.GTX:
					return TimeInForce.GTX;
				case SmartQuant.FIX.TimeInForce.GoodTillDate:
					return TimeInForce.GTD;
				case SmartQuant.FIX.TimeInForce.AtTheClose:
					return TimeInForce.ATC;
				case SmartQuant.FIX.TimeInForce.GoodForSeconds:
					return TimeInForce.GFS;
				default:
					throw new NotImplementedException("TimeInForce is not supported : " + this.order.TimeInForce);
				}
			}
			set
			{
				switch (value)
				{
				case TimeInForce.Day:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.Day;
					return;
				case TimeInForce.GTC:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.GTC;
					return;
				case TimeInForce.OPG:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.OPG;
					return;
				case TimeInForce.IOC:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.IOC;
					return;
				case TimeInForce.FOK:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.FOK;
					return;
				case TimeInForce.GTX:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.GTX;
					return;
				case TimeInForce.GTD:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.GoodTillDate;
					return;
				case TimeInForce.ATC:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.AtTheClose;
					return;
				case TimeInForce.GFS:
					this.order.TimeInForce = SmartQuant.FIX.TimeInForce.GoodForSeconds;
					return;
				default:
					throw new NotImplementedException("TimeInForce is not supported : " + value);
				}
			}
		}
		public DateTime ExpireTime
		{
			get
			{
				return this.order.ExpireTime;
			}
			set
			{
				this.order.ExpireTime = value;
			}
		}
		public int ExpireSeconds
		{
			get
			{
				return this.order.ExpireSeconds;
			}
			set
			{
				this.order.ExpireSeconds = value;
			}
		}
		public OrderStatus Status
		{
			get
			{
				return EnumConverter.Convert(this.order.OrdStatus);
			}
		}
		[Category("Appearance")]
		public double Qty
		{
			get
			{
				return this.order.OrderQty;
			}
			set
			{
				if (!this.order.IsSent)
				{
					this.order.OrderQty = value;
					return;
				}
				this.order.ReplaceOrder.OrderQty = value;
			}
		}
		[Category("Execution")]
		public double LastQty
		{
			get
			{
				return this.order.LastQty;
			}
		}
		[Category("Execution")]
		public double LeavesQty
		{
			get
			{
				return this.order.LeavesQty;
			}
		}
		[Category("Execution")]
		public double CumQty
		{
			get
			{
				return this.order.CumQty;
			}
		}
		[Category("Appearance")]
		public double Price
		{
			get
			{
				return this.order.Price;
			}
			set
			{
				if (!this.order.IsSent)
				{
					this.order.Price = value;
					return;
				}
				this.order.ReplaceOrder.Price = value;
			}
		}
		[Category("Appearance")]
		public double StopPrice
		{
			get
			{
				return this.order.StopPx;
			}
			set
			{
				if (!this.order.IsSent)
				{
					this.order.StopPx = value;
					return;
				}
				this.order.ReplaceOrder.StopPx = value;
			}
		}
		[Category("Appearance")]
		public double TrailingAmt
		{
			get
			{
				return this.order.TrailingAmt;
			}
			set
			{
				if (!this.order.IsSent)
				{
					this.order.TrailingAmt = value;
					return;
				}
				this.order.ReplaceOrder.TrailingAmt = value;
			}
		}
		[Category("Execution")]
		public double AvgPrice
		{
			get
			{
				return this.order.AvgPx;
			}
		}
		[Category("Execution")]
		public double LastPrice
		{
			get
			{
				return this.order.LastPx;
			}
		}
		[Category("Appearance")]
		public string Account
		{
			get
			{
				return this.order.Account;
			}
			set
			{
				this.order.Account = value;
			}
		}
		[Category("Appearance")]
		public string ClientID
		{
			get
			{
				return this.order.GetStringValue(109);
			}
			set
			{
				this.order.SetStringValue(109, value);
			}
		}
		public string OrderID
		{
			get
			{
				return this.order.OrderID;
			}
			set
			{
				this.order.OrderID = value;
			}
		}
		public string Text
		{
			get
			{
				return this.order.Text;
			}
			set
			{
				this.order.Text = value;
			}
		}
		[Category("Status")]
		public bool IsNew
		{
			get
			{
				return this.order.IsNew;
			}
		}
		[Category("Status")]
		public bool IsPendingNew
		{
			get
			{
				return this.order.IsPendingNew;
			}
		}
		[Category("Status")]
		public bool IsFilled
		{
			get
			{
				return this.order.IsFilled;
			}
		}
		[Category("Status")]
		public bool IsPartiallyFilled
		{
			get
			{
				return this.order.IsPartiallyFilled;
			}
		}
		[Category("Status")]
		public bool IsPendingCancel
		{
			get
			{
				return this.order.IsPendingCancel;
			}
		}
		[Category("Status")]
		public bool IsCancelled
		{
			get
			{
				return this.order.IsCancelled;
			}
		}
		[Category("Status")]
		public bool IsExpired
		{
			get
			{
				return this.order.IsExpired;
			}
		}
		[Category("Status")]
		public bool IsPendingReplace
		{
			get
			{
				return this.order.IsPendingReplace;
			}
		}
		[Category("Status")]
		public bool IsRejected
		{
			get
			{
				return this.order.IsRejected;
			}
		}
		[Category("Status")]
		public bool IsDone
		{
			get
			{
				return this.order.IsDone;
			}
		}
		[Category("Appearance")]
		public string OCAGroup
		{
			get
			{
				return this.order.OCAGroup;
			}
			set
			{
				this.order.OCAGroup = value;
			}
		}
		[Category("Extensions")]
		public IBEx IB
		{
			get
			{
				return this.ibEx;
			}
		}
		public ExecutionReportList ExecutionReports
		{
			get
			{
				List<FIXMessage> list = new List<FIXMessage>();
				foreach (FIXMessage item in this.order.Reports)
				{
					list.Add(item);
				}
				foreach (FIXMessage item2 in this.order.Rejects)
				{
					list.Add(item2);
				}
				list.Sort((FIXMessage message1, FIXMessage message2) => message1.GetDateTimeValue(60).CompareTo(message2.GetDateTimeValue(60)));
				return new ExecutionReportList(list);
			}
		}
		internal Portfolio Portfolio
		{
			get
			{
				return Map.SQ_OQ_Portfolio[this.order.Portfolio] as Portfolio;
			}
			set
			{
				this.order.Portfolio = value.portfolio;
				this.order.Persistent = value.portfolio.Persistent;
			}
		}
		public bool StrategyFill
		{
			get
			{
				return this.order.StrategyFill;
			}
			set
			{
				this.order.StrategyFill = value;
			}
		}
		public double StrategyPrice
		{
			get
			{
				return this.order.StrategyPrice;
			}
			set
			{
				this.order.StrategyPrice = value;
			}
		}
		internal NewOrderSingle ReplaceOrder
		{
			get
			{
				return this.order.ReplaceOrder;
			}
		}
		public byte Route
		{
			get
			{
				return (byte)this.order.Route;
			}
			set
			{
				this.order.Route = (int)value;
			}
		}
		public int TradeVolumeDelay
		{
			get
			{
				return this.order.TradeVolumeDelay;
			}
			set
			{
				this.order.TradeVolumeDelay = value;
			}
		}
		internal Order(SingleOrder order)
		{
			this.order = order;
			this.instrument = (Map.SQ_OQ_Instrument[order.Instrument] as Instrument);
			this.ibEx = new IBEx(order);
			if (order.Provider == null)
			{
				order.Provider = Configuration.Active.ExecutionProvider;
				order.StrategyMode = ConfigurationModeConverter.ModeToChar(Configuration.ActiveMode);
			}
		}
		private Order()
		{
		}
		internal static Order CreateWrapper(SingleOrder order)
		{
			return new Order
			{
				order = order,
				instrument = Map.SQ_OQ_Instrument[order.Instrument] as Instrument,
				ibEx = new IBEx(order)
			};
		}
		public void Send()
		{
			this.order.Send();
		}
		public void Cancel()
		{
			this.order.Cancel();
		}
		public void Replace()
		{
			this.order.Replace();
		}
	}
}
