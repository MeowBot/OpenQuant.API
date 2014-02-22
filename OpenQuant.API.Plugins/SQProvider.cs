using OpenQuant.ObjectMap;
using SmartQuant.Data;
using SmartQuant.Execution;
using SmartQuant.FIX;
using SmartQuant.Instruments;
using SmartQuant.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
namespace OpenQuant.API.Plugins
{
	[TypeDescriptionProvider(typeof(SQProviderTypeDescriptionProvider))]
	internal class SQProvider : IMarketDataProvider, IExecutionProvider, IHistoricalDataProvider, IProvider
	{
		private const string CATEGORY_INFO = "Information";
		private const string CATEGORY_STATUS = "Status";
		private const string CATEGORY_BAR_FACTORY = "Bar Factory";
		private UserProvider provider;
		private IBarFactory barFactory;
		private Dictionary<Order, OrderRecord> orderRecords;
		private Dictionary<string, global::OpenQuant.API.HistoricalDataRequest> historicalDataRequests;
		public event EventHandler Connected;
		public event EventHandler Disconnected;
		public event ProviderErrorEventHandler Error;
		public event EventHandler StatusChanged;
		public event MarketDataRequestRejectEventHandler MarketDataRequestReject;
		public event MarketDataSnapshotEventHandler MarketDataSnapshot;
		public event BarEventHandler NewBar;
		public event BarEventHandler NewBarOpen;
		public event BarSliceEventHandler NewBarSlice;
		public event CorporateActionEventHandler NewCorporateAction;
		public event FundamentalEventHandler NewFundamental;
		public event BarEventHandler NewMarketBar;
		public event MarketDataEventHandler NewMarketData;
		public event MarketDepthEventHandler NewMarketDepth;
		public event QuoteEventHandler NewQuote;
		public event TradeEventHandler NewTrade;
		public event ExecutionReportEventHandler ExecutionReport;
		public event OrderCancelRejectEventHandler OrderCancelReject;
		public event HistoricalDataEventHandler HistoricalDataRequestCancelled;
		public event HistoricalDataEventHandler HistoricalDataRequestCompleted;
		public event HistoricalDataErrorEventHandler HistoricalDataRequestError;
		public event HistoricalBarEventHandler NewHistoricalBar;
		public event HistoricalMarketDepthEventHandler NewHistoricalMarketDepth;
		public event HistoricalQuoteEventHandler NewHistoricalQuote;
		public event HistoricalTradeEventHandler NewHistoricalTrade;
		internal UserProvider UserProvider
		{
			get
			{
				return this.provider;
			}
		}
		[Browsable(false)]
		public string PropertiesStr
		{
			get
			{
				List<string> list = new List<string>();
				foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(this.provider))
				{
					if (!propertyDescriptor.IsReadOnly && propertyDescriptor.IsBrowsable && propertyDescriptor.PropertyType.IsSerializable)
					{
						object value = propertyDescriptor.GetValue(this.provider);
						if (value != null)
						{
							list.Add(string.Format(CultureInfo.InvariantCulture, "{0}={1}", new object[]
							{
								propertyDescriptor.Name,
								value
							}));
						}
					}
				}
				return string.Join(";", list.ToArray());
			}
			set
			{
				string[] array = value.Split(new char[]
				{
					';'
				});
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.provider);
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					string[] array3 = text.Split(new char[]
					{
						'='
					});
					if (array3.Length == 2)
					{
						PropertyDescriptor propertyDescriptor = properties[array3[0]];
						if (propertyDescriptor != null)
						{
							try
							{
								TypeConverter converter = TypeDescriptor.GetConverter(propertyDescriptor.PropertyType);
								if (converter != null && converter.CanConvertFrom(typeof(string)))
								{
									object value2 = converter.ConvertFromInvariantString(array3[1]);
									propertyDescriptor.SetValue(this.provider, value2);
								}
							}
							catch
							{
							}
						}
					}
				}
			}
		}
		[Category("Information")]
		public byte Id
		{
			get
			{
				return this.provider.GetId();
			}
		}
		[Category("Information")]
		public string Name
		{
			get
			{
				return this.provider.GetName();
			}
		}
		[Category("Information")]
		public string Title
		{
			get
			{
				return this.provider.GetDescription();
			}
		}
		[Category("Information")]
		public string URL
		{
			get
			{
				return this.provider.GetURL();
			}
		}
		[Category("Status")]
		public bool IsConnected
		{
			get
			{
				return this.provider.CallIsConnected();
			}
		}
		[Category("Status")]
		public ProviderStatus Status
		{
			get
			{
				if (!this.IsConnected)
				{
					return ProviderStatus.Disconnected;
				}
				return ProviderStatus.Connected;
			}
		}
		[Category("Bar Factory")]
		public IBarFactory BarFactory
		{
			get
			{
				return this.barFactory;
			}
			set
			{
				if (this.barFactory != null)
				{
					this.barFactory.NewBarOpen -= new BarEventHandler(this.barFactory_NewBarOpen);
					this.barFactory.NewBar -= new BarEventHandler(this.barFactory_NewBar);
					this.barFactory.NewBarSlice -= new BarSliceEventHandler(this.barFactory_NewBarSlice);
				}
				this.barFactory = value;
				if (this.barFactory != null)
				{
					this.barFactory.NewBarOpen += new BarEventHandler(this.barFactory_NewBarOpen);
					this.barFactory.NewBar += new BarEventHandler(this.barFactory_NewBar);
					this.barFactory.NewBarSlice += new BarSliceEventHandler(this.barFactory_NewBarSlice);
				}
			}
		}
		[Browsable(false)]
		public IMarketDataFilter MarketDataFilter
		{
			get;
			set;
		}
		[Browsable(false)]
		public int[] BarSizes
		{
			get
			{
				return new int[0];
			}
		}
		[Browsable(false)]
		public int MaxConcurrentRequests
		{
			get
			{
				return 1;
			}
		}
		[Browsable(false)]
		public HistoricalDataRange DataRange
		{
			get
			{
				return HistoricalDataRange.DateTimeInterval;
			}
		}
		[Browsable(false)]
		public HistoricalDataType DataType
		{
			get
			{
				return HistoricalDataType.Trade | HistoricalDataType.Quote | HistoricalDataType.Bar | HistoricalDataType.Daily;
			}
		}
		internal SQProvider(UserProvider provider)
		{
			this.provider = provider;
			this.BarFactory = new SmartQuant.Providers.BarFactory(false);
			this.orderRecords = new Dictionary<Order, OrderRecord>();
			this.historicalDataRequests = new Dictionary<string, global::OpenQuant.API.HistoricalDataRequest>();
		}
		public void Connect(int timeout)
		{
			this.provider.CallConnect();
			SmartQuant.Providers.ProviderManager.WaitConnected(this, timeout);
		}
		public void Connect()
		{
			this.provider.CallConnect();
		}
		public void Disconnect()
		{
			this.provider.CallDisconnect();
		}
		public void Shutdown()
		{
			this.provider.CallShutdown();
		}
		public void EmitConnected()
		{
			if (this.Connected != null)
			{
				this.Connected(this, EventArgs.Empty);
			}
		}
		public void EmitDisconnected()
		{
			if (this.Disconnected != null)
			{
				this.Disconnected(this, EventArgs.Empty);
			}
		}
		public void EmitStatusChanged()
		{
			if (this.StatusChanged != null)
			{
				this.StatusChanged(this, EventArgs.Empty);
			}
		}
		public void EmitError(int id, int code, string message)
		{
			if (this.Error != null)
			{
				this.Error(new ProviderErrorEventArgs(this, id, code, message));
			}
		}
		public void SendMarketDataRequest(FIXMarketDataRequest request)
		{
			SubscriptionDataType subscriptionDataType = (SubscriptionDataType)0;
			for (int i = 0; i < request.NoMDEntryTypes; i++)
			{
				FIXMDEntryTypesGroup mDEntryTypesGroup = request.GetMDEntryTypesGroup(i);
				switch (mDEntryTypesGroup.MDEntryType)
				{
				case '0':
				case '1':
					if (request.MarketDepth == 1)
					{
						subscriptionDataType |= SubscriptionDataType.Quotes;
					}
					else
					{
						subscriptionDataType |= SubscriptionDataType.OrderBook;
					}
					break;
				case '2':
					subscriptionDataType |= SubscriptionDataType.Trades;
					break;
				}
			}
			for (int j = 0; j < request.NoRelatedSym; j++)
			{
				FIXRelatedSymGroup relatedSymGroup = request.GetRelatedSymGroup(j);
				SmartQuant.Instruments.Instrument key = SmartQuant.Instruments.InstrumentManager.Instruments[relatedSymGroup.Symbol];
				global::OpenQuant.API.Instrument instrument = Map.SQ_OQ_Instrument[key] as global::OpenQuant.API.Instrument;
				switch (request.SubscriptionRequestType)
				{
				case '1':
					this.provider.CallSubscribe(instrument, subscriptionDataType);
					break;
				case '2':
					this.provider.CallUnsubscribe(instrument, subscriptionDataType);
					break;
				default:
					throw new Exception("Unknown subscription request type " + request.SubscriptionRequestType);
				}
			}
		}
		public void EmitTrade(global::OpenQuant.API.Instrument instrument, DateTime time, byte providerId, double price, int size)
		{
			SmartQuant.Data.Trade trade = new SmartQuant.Data.Trade(time, price, size);
			trade.ProviderId = providerId;
			if (this.MarketDataFilter != null)
			{
				trade = this.MarketDataFilter.FilterTrade(trade, instrument.Symbol);
			}
			if (trade == null)
			{
				return;
			}
			if (this.NewTrade != null)
			{
				this.NewTrade(this, new TradeEventArgs(trade, instrument.instrument, this));
			}
			if (this.barFactory != null)
			{
				this.barFactory.OnNewTrade(instrument.instrument, trade);
			}
		}
		public void EmitQuote(global::OpenQuant.API.Instrument instrument, DateTime time, byte providerId, double bid, int bidSize, double ask, int askSize)
		{
			SmartQuant.Data.Quote quote = new SmartQuant.Data.Quote(time, bid, bidSize, ask, askSize);
			quote.ProviderId = providerId;
			if (this.MarketDataFilter != null)
			{
				quote = this.MarketDataFilter.FilterQuote(quote, instrument.Symbol);
			}
			if (quote == null)
			{
				return;
			}
			if (this.NewQuote != null)
			{
				this.NewQuote(this, new QuoteEventArgs(quote, instrument.instrument, this));
			}
			if (this.barFactory != null)
			{
				this.barFactory.OnNewQuote(instrument.instrument, quote);
			}
		}
		public void EmitMarketDepth(global::OpenQuant.API.Instrument instrument, DateTime time, BidAsk side, OrderBookAction action, double price, int size, int position)
		{
			MarketDepth marketDepth = new MarketDepth(time, string.Empty, position, global::OpenQuant.API.EnumConverter.Convert(action), global::OpenQuant.API.EnumConverter.Convert(side), price, size);
			if (this.NewMarketDepth != null)
			{
				this.NewMarketDepth(this, new MarketDepthEventArgs(marketDepth, instrument.instrument, this));
			}
		}
		public void EmitBarOpen(global::OpenQuant.API.Instrument instrument, global::OpenQuant.API.BarType barType, long barSize, DateTime beginDateTime, DateTime endDateTime, double open, double high, double low, double close, long volume)
		{
			SmartQuant.Data.Bar bar = new SmartQuant.Data.Bar(global::OpenQuant.API.EnumConverter.Convert(barType), barSize, beginDateTime, endDateTime, open, high, low, close, volume, 0L);
			if (this.MarketDataFilter != null)
			{
				bar = this.MarketDataFilter.FilterBarOpen(bar, instrument.Symbol);
			}
			if (bar != null)
			{
				this.EmitBarOpen(instrument.instrument, bar);
			}
		}
		public void EmitBar(global::OpenQuant.API.Instrument instrument, global::OpenQuant.API.BarType barType, long barSize, DateTime beginDateTime, DateTime endDateTime, double open, double high, double low, double close, long volume)
		{
			SmartQuant.Data.Bar bar = new SmartQuant.Data.Bar(global::OpenQuant.API.EnumConverter.Convert(barType), barSize, beginDateTime, endDateTime, open, high, low, close, volume, 0L);
			if (this.MarketDataFilter != null)
			{
				bar = this.MarketDataFilter.FilterBar(bar, instrument.Symbol);
			}
			if (bar != null)
			{
				this.EmitBar(instrument.instrument, bar);
			}
		}
		public void EmitBarSlice(long barSize)
		{
			if (this.NewBarSlice != null)
			{
				this.NewBarSlice(this, new BarSliceEventArgs(barSize, this));
			}
		}
		public void EmitMarketData()
		{
			if (this.NewMarketData != null)
			{
				this.NewMarketData(this, new MarketDataEventArgs(null, null, this));
			}
		}
		public void EmitMarketDataSnapshot()
		{
			if (this.MarketDataSnapshot != null)
			{
				this.MarketDataSnapshot(this, new MarketDataSnapshotEventArgs(null));
			}
		}
		public void EmitMarketDataRequestReject()
		{
			if (this.MarketDataRequestReject != null)
			{
				this.MarketDataRequestReject(this, new MarketDataRequestRejectEventArgs(null));
			}
		}
		public void EmitMarketBar()
		{
			if (this.NewMarketBar != null)
			{
				this.NewMarketBar(this, new BarEventArgs(null, null, this));
			}
		}
		public void EmitFundamental()
		{
			if (this.NewFundamental != null)
			{
				this.NewFundamental(this, new FundamentalEventArgs(null, null, this));
			}
		}
		public void EmitCorporateAction()
		{
			if (this.NewCorporateAction != null)
			{
				this.NewCorporateAction(this, new CorporateActionEventArgs(null, null, this));
			}
		}
		private void EmitBarOpen(IFIXInstrument instrument, SmartQuant.Data.Bar bar)
		{
			if (this.NewBarOpen != null)
			{
				this.NewBarOpen(this, new BarEventArgs(bar, instrument, this));
			}
		}
		private void EmitBar(IFIXInstrument instrument, SmartQuant.Data.Bar bar)
		{
			if (this.NewBar != null)
			{
				this.NewBar(this, new BarEventArgs(bar, instrument, this));
			}
		}
		public void SendNewOrderSingle(NewOrderSingle order)
		{
			Order order2 = Map.SQ_OQ_Order[order] as Order;
			this.orderRecords.Add(order2, new OrderRecord(order as SingleOrder));
			this.provider.CallSend(order2);
		}
		public void SendOrderCancelReplaceRequest(OrderCancelReplaceRequest request)
		{
			IOrder key = OrderManager.Orders.All[request.OrigClOrdID];
			Order order = Map.SQ_OQ_Order[key] as Order;
			this.provider.CallReplace(order);
		}
		public void SendOrderCancelRequest(OrderCancelRequest request)
		{
			IOrder key = OrderManager.Orders.All[request.OrigClOrdID];
			Order order = Map.SQ_OQ_Order[key] as Order;
			this.provider.CallCancel(order);
		}
		public void SendOrderStatusRequest(OrderStatusRequest request)
		{
			throw new Exception("The method or operation is not implemented.");
		}
		public SmartQuant.Providers.BrokerInfo GetBrokerInfo()
		{
			return this.provider.CallGetBrokerInfo().brokerInfo;
		}
		public void RegisterOrder(NewOrderSingle order)
		{
		}
		public void EmitExecutionReport(Order order, double price, int quantity)
		{
			OrderRecord record = this.orderRecords[order];
			this.EmitExecutionReport(record, OrdStatus.Undefined, price, quantity, "");
		}
		public void EmitExecutionReport(Order order, double price, int quantity, CommType commType, double commission)
		{
			OrderRecord record = this.orderRecords[order];
			this.EmitExecutionReport(record, OrdStatus.Undefined, price, quantity, "", commType, commission);
		}
		public void EmitExecutionReport(Order order, OrdStatus status, string text)
		{
			OrderRecord record = this.orderRecords[order];
			this.EmitExecutionReport(record, status, 0.0, 0, text);
		}
		public void EmitExecutionReport(Order order, OrdStatus status)
		{
			this.EmitExecutionReport(order, status, "");
		}
		public void EmitCancelReject(Order order, OrdStatus status, string message)
		{
			OrderRecord record = this.orderRecords[order];
			this.EmitOrderCancelReject(record, status, CxlRejResponseTo.CancelRequest, message);
		}
		public void EmitCancelReplaceReject(Order order, OrdStatus status, string message)
		{
			OrderRecord record = this.orderRecords[order];
			this.EmitOrderCancelReject(record, status, CxlRejResponseTo.CancelReplaceRequest, message);
		}
		private void EmitExecutionReport(OrderRecord record, OrdStatus ordStatus, double lastPx, int lastQty, string text)
		{
			this.EmitExecutionReport(record, ordStatus, lastPx, lastQty, text, CommType.Absolute, 0.0);
		}
		private void EmitExecutionReport(OrderRecord record, OrdStatus ordStatus, double lastPx, int lastQty, string text, CommType commType, double commission)
		{
			SmartQuant.FIX.ExecutionReport executionReport = new SmartQuant.FIX.ExecutionReport();
			executionReport.TransactTime = Clock.Now;
			executionReport.ClOrdID = record.Order.ClOrdID;
			executionReport.OrigClOrdID = record.Order.ClOrdID;
			executionReport.OrderID = record.Order.OrderID;
			executionReport.Symbol = record.Order.Symbol;
			executionReport.SecurityType = record.Order.SecurityType;
			executionReport.SecurityExchange = record.Order.SecurityExchange;
			executionReport.Currency = record.Order.Currency;
			executionReport.CommType = commType;
			executionReport.Commission = commission;
			executionReport.Side = record.Order.Side;
			if (ordStatus == OrdStatus.Replaced)
			{
				executionReport.OrdType = (record.Order.ReplaceOrder.ContainsField(40) ? record.Order.ReplaceOrder.OrdType : record.Order.OrdType);
				executionReport.TimeInForce = (record.Order.ReplaceOrder.ContainsField(59) ? record.Order.ReplaceOrder.TimeInForce : record.Order.TimeInForce);
				executionReport.OrderQty = (record.Order.ReplaceOrder.ContainsField(38) ? record.Order.ReplaceOrder.OrderQty : record.Order.OrderQty);
				executionReport.Price = (record.Order.ReplaceOrder.ContainsField(44) ? record.Order.ReplaceOrder.Price : record.Order.Price);
				executionReport.StopPx = (record.Order.ReplaceOrder.ContainsField(99) ? record.Order.ReplaceOrder.StopPx : record.Order.StopPx);
				record.LeavesQty = (int)executionReport.OrderQty - record.CumQty;
			}
			else
			{
				executionReport.OrdType = record.Order.OrdType;
				executionReport.TimeInForce = record.Order.TimeInForce;
				executionReport.OrderQty = record.Order.OrderQty;
				executionReport.Price = record.Order.Price;
				executionReport.StopPx = record.Order.StopPx;
			}
			executionReport.LastPx = lastPx;
			executionReport.LastQty = (double)lastQty;
			if (ordStatus == OrdStatus.Undefined)
			{
				record.AddFill(lastPx, lastQty);
				if (record.LeavesQty > 0)
				{
					ordStatus = OrdStatus.PartiallyFilled;
				}
				else
				{
					ordStatus = OrdStatus.Filled;
				}
			}
			executionReport.AvgPx = record.AvgPx;
			executionReport.CumQty = (double)record.CumQty;
			executionReport.LeavesQty = (double)record.LeavesQty;
			executionReport.ExecType = this.GetExecType(ordStatus);
			executionReport.OrdStatus = ordStatus;
			executionReport.Text = text;
			this.EmitExecutionReport(executionReport);
		}
		private void EmitOrderCancelReject(OrderRecord record, OrdStatus ordStatus, CxlRejResponseTo responseTo, string text)
		{
			this.EmitOrderCancelReject(new OrderCancelReject
			{
				TransactTime = Clock.Now,
				ClOrdID = record.Order.ClOrdID,
				OrigClOrdID = record.Order.ClOrdID,
				OrdStatus = ordStatus,
				CxlRejResponseTo = responseTo,
				CxlRejReason = CxlRejReason.BrokerOption,
				Text = text
			});
		}
		private void EmitExecutionReport(SmartQuant.FIX.ExecutionReport report)
		{
			if (this.ExecutionReport != null)
			{
				this.ExecutionReport(this, new ExecutionReportEventArgs(report));
			}
		}
		private void EmitOrderCancelReject(OrderCancelReject reject)
		{
			if (this.OrderCancelReject != null)
			{
				this.OrderCancelReject(this, new OrderCancelRejectEventArgs(reject));
			}
		}
		private ExecType GetExecType(OrdStatus status)
		{
			switch (status)
			{
			case OrdStatus.New:
				return ExecType.New;
			case OrdStatus.PartiallyFilled:
				return ExecType.PartialFill;
			case OrdStatus.Filled:
				return ExecType.Fill;
			case OrdStatus.Cancelled:
				return ExecType.Cancelled;
			case OrdStatus.Replaced:
				return ExecType.Replace;
			case OrdStatus.PendingCancel:
				return ExecType.PendingCancel;
			case OrdStatus.Rejected:
				return ExecType.Rejected;
			case OrdStatus.PendingReplace:
				return ExecType.PendingReplace;
			}
			throw new ArgumentException(string.Format("Cannot find exec type for ord status - {0}", status));
		}
		private void barFactory_NewBarOpen(object sender, BarEventArgs args)
		{
			this.EmitBarOpen(args.Instrument, args.Bar);
		}
		private void barFactory_NewBar(object sender, BarEventArgs args)
		{
			this.EmitBar(args.Instrument, args.Bar);
		}
		private void barFactory_NewBarSlice(object sender, BarSliceEventArgs args)
		{
			this.EmitBarSlice(args.BarSize);
		}
		public void SendHistoricalDataRequest(SmartQuant.Providers.HistoricalDataRequest request)
		{
			global::OpenQuant.API.HistoricalDataRequest historicalDataRequest = new global::OpenQuant.API.HistoricalDataRequest(request);
			this.historicalDataRequests.Add(request.RequestId, historicalDataRequest);
			this.provider.CallRequestHistoricalData(historicalDataRequest);
		}
		public void CancelHistoricalDataRequest(string requestId)
		{
			global::OpenQuant.API.HistoricalDataRequest request;
			if (this.historicalDataRequests.TryGetValue(requestId, out request))
			{
				this.provider.CallCancelHistoricalData(request);
			}
		}
		public void EmitHistoricalTrade(global::OpenQuant.API.HistoricalDataRequest request, DateTime datetime, double price, int size)
		{
			if (this.NewHistoricalTrade != null)
			{
				SmartQuant.Data.Trade trade = new SmartQuant.Data.Trade(datetime, price, size);
				HistoricalTradeEventArgs args = new HistoricalTradeEventArgs(trade, request.request.RequestId, request.request.Instrument, this, 0);
				this.NewHistoricalTrade(this, args);
			}
		}
		public void EmitHistoricalQuote(global::OpenQuant.API.HistoricalDataRequest request, DateTime datetime, double bid, int bidSize, double ask, int askSize)
		{
			if (this.NewHistoricalQuote != null)
			{
				SmartQuant.Data.Quote quote = new SmartQuant.Data.Quote(datetime, bid, bidSize, ask, askSize);
				HistoricalQuoteEventArgs args = new HistoricalQuoteEventArgs(quote, request.request.RequestId, request.request.Instrument, this, 0);
				this.NewHistoricalQuote(this, args);
			}
		}
		public void EmitHistoricalBar(global::OpenQuant.API.HistoricalDataRequest request, DateTime datetime, double open, double high, double low, double close, long volume)
		{
			if (this.NewHistoricalBar != null)
			{
				SmartQuant.Data.Bar bar;
				if (request.request.DataType == HistoricalDataType.Daily)
				{
					bar = new Daily(datetime, open, high, low, close, volume, 0L);
				}
				else
				{
					bar = new SmartQuant.Data.Bar(datetime, open, high, low, close, volume, request.request.BarSize);
				}
				HistoricalBarEventArgs args = new HistoricalBarEventArgs(bar, request.request.RequestId, request.request.Instrument, this, 0);
				this.NewHistoricalBar(this, args);
			}
		}
		private void EmitNewHistoricalMarketDepth()
		{
			if (this.NewHistoricalMarketDepth != null)
			{
				this.NewHistoricalMarketDepth(this, new HistoricalMarketDepthEventArgs(null, null, null, this, 0));
			}
		}
		public void EmitHistoricalDataCompleted(global::OpenQuant.API.HistoricalDataRequest request)
		{
			if (this.HistoricalDataRequestCompleted != null)
			{
				HistoricalDataEventArgs args = new HistoricalDataEventArgs(request.request.RequestId, request.request.Instrument, this, 0);
				this.HistoricalDataRequestCompleted(this, args);
			}
		}
		public void EmitHistoricalDataCancelled(global::OpenQuant.API.HistoricalDataRequest request)
		{
			if (this.HistoricalDataRequestCancelled != null)
			{
				HistoricalDataEventArgs args = new HistoricalDataEventArgs(request.request.RequestId, request.request.Instrument, this, 0);
				this.HistoricalDataRequestCancelled(this, args);
			}
		}
		public void EmitHistoricalDataError(global::OpenQuant.API.HistoricalDataRequest request, string message)
		{
			if (this.HistoricalDataRequestError != null)
			{
				HistoricalDataErrorEventArgs args = new HistoricalDataErrorEventArgs(request.request.RequestId, request.request.Instrument, this, 0, message);
				this.HistoricalDataRequestError(this, args);
			}
		}
	}
}
