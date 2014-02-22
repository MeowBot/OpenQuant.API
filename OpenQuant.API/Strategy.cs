using OpenQuant.API.Engine;
using OpenQuant.API.Logs;
using OpenQuant.API.Plugins;
using OpenQuant.Config;
using OpenQuant.ObjectMap;
using SmartQuant;
using SmartQuant.Execution;
using SmartQuant.FIX;
using SmartQuant.Indicators;
using SmartQuant.Instruments;
using SmartQuant.Providers;
using SmartQuant.Series;
using SmartQuant.Testing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
namespace OpenQuant.API
{
	public class Strategy
	{
		private bool active;
		private Portfolio portfolio;
		private Portfolio metaPortfolio;
		private Performance performance;
		private Performance metaPerformance;
		private Instrument instrument;
		private SmartQuant.Instruments.Instrument sq_Instrument;
		private int maxPadNumber = 1;
		private Chart chart = new Chart();
		private InstrumentList instrumentList;
		private Dictionary<DateTime, HashSet<object>> timers;
		private DataRequests dataRequests;
		private string strategyName;
		private bool stopTraceOnBar = true;
		private bool stopTraceOnTrade = true;
		private bool stopTraceOnQuote = true;
		private long defaultBarSize = -1L;
		private BarType defaultBarType;
		private static Hashtable global = new Hashtable();
		private IStrategyLogManager strategyLogManager;
		[Parameter("Report Enabled", "Reporting")]
		internal bool ReportEnabled;
		[Parameter("Testing Period", "Reporting")]
		internal TimeIntervalSize TestingPeriod = TimeIntervalSize.day1;
		[Parameter("Currency", "Account")]
		internal string Currency;
		private DateTime startDate = DateTime.MinValue;
		private DateTime stopDate = DateTime.MinValue;
		private double cash = double.NaN;
		public string Name
		{
			get
			{
				return this.strategyName;
			}
		}
		public Chart Chart
		{
			get
			{
				return this.chart;
			}
		}
		public StrategyMode Mode
		{
			get
			{
				switch (global::OpenQuant.Config.Configuration.ActiveMode)
				{
				case ConfigurationMode.Simulation:
					return StrategyMode.Simulation;
				case ConfigurationMode.Paper:
					return StrategyMode.Paper;
				case ConfigurationMode.Live:
					return StrategyMode.Live;
				default:
					throw new InvalidOperationException("Unknown strategy mode");
				}
			}
		}
		public ExecutionProvider ExecutionProvider
		{
			get
			{
				return new ExecutionProvider(global::OpenQuant.Config.Configuration.Active.ExecutionProvider);
			}
		}
		public MarketDataProvider MarketDataProvider
		{
			get
			{
				return new MarketDataProvider(global::OpenQuant.Config.Configuration.Active.MarketDataProvider);
			}
		}
		public bool Active
		{
			get
			{
				return this.active;
			}
		}
		public DataRequests DataRequests
		{
			get
			{
				return this.dataRequests;
			}
		}
		public bool TraceOnBar
		{
			get
			{
				return this.stopTraceOnBar;
			}
			set
			{
				this.stopTraceOnBar = value;
			}
		}
		public bool TraceOnTrade
		{
			get
			{
				return this.stopTraceOnTrade;
			}
			set
			{
				this.stopTraceOnTrade = value;
			}
		}
		public bool TraceOnQuote
		{
			get
			{
				return this.stopTraceOnQuote;
			}
			set
			{
				this.stopTraceOnQuote = value;
			}
		}
		public double Cash
		{
			get
			{
				return this.cash;
			}
		}
		public DateTime StartDate
		{
			get
			{
				return IDE.Scenario.Solution.StartDate;
			}
		}
		public DateTime StopDate
		{
			get
			{
				return IDE.Scenario.Solution.StopDate;
			}
		}
		[Browsable(false)]
		public Instrument Instrument
		{
			get
			{
				return this.instrument;
			}
		}
		[Browsable(false)]
		public Portfolio Portfolio
		{
			get
			{
				return this.portfolio;
			}
		}
		public Portfolio MetaPortfolio
		{
			get
			{
				return this.metaPortfolio;
			}
		}
		[Browsable(false)]
		public Performance Performance
		{
			get
			{
				return this.performance;
			}
		}
		[Browsable(false)]
		public Performance MetaPerformance
		{
			get
			{
				return this.metaPerformance;
			}
		}
		[Browsable(false)]
		public Position Position
		{
			get
			{
				return this.Portfolio.Positions[this.instrument.Symbol];
			}
		}
		[Browsable(false)]
		public bool HasPosition
		{
			get
			{
				return this.Position != null;
			}
		}
		public Bar Bar
		{
			get
			{
				return this.Instrument.Bar;
			}
		}
		public Trade Trade
		{
			get
			{
				return this.Instrument.Trade;
			}
		}
		public Quote Quote
		{
			get
			{
				return this.Instrument.Quote;
			}
		}
		public OrderBook OrderBook
		{
			get
			{
				return this.Instrument.OrderBook;
			}
		}
		[Browsable(false)]
		public BarSeries Bars
		{
			get
			{
				return OpenQuant.Bars[this.Instrument];
			}
		}
		public TradeSeries Trades
		{
			get
			{
				SmartQuant.Instruments.Instrument instrument = Map.OQ_SQ_Instrument[this.instrument] as SmartQuant.Instruments.Instrument;
				return new TradeSeries(instrument.Trades);
			}
		}
		public QuoteSeries Quotes
		{
			get
			{
				SmartQuant.Instruments.Instrument instrument = Map.OQ_SQ_Instrument[this.instrument] as SmartQuant.Instruments.Instrument;
				return new QuoteSeries(instrument.Quotes);
			}
		}
		[Browsable(false)]
		public InstrumentList Instruments
		{
			get
			{
				if (this.instrumentList == null)
				{
					this.instrumentList = new InstrumentList();
					foreach (string current in Map.Instruments[this.strategyName])
					{
						this.instrumentList.Add(current, OpenQuant.Instruments[current]);
					}
				}
				return this.instrumentList;
			}
		}
		[Browsable(false)]
		public OrderList Orders
		{
			get
			{
				return OpenQuant.Orders;
			}
		}
		public static Hashtable Global
		{
			get
			{
				return Strategy.global;
			}
		}
		protected IStrategyLogList SolutionLogs
		{
			get
			{
				return this.strategyLogManager.GetLogList(string.Empty, string.Empty);
			}
		}
		protected IStrategyLogList StrategyLogs
		{
			get
			{
				return this.strategyLogManager.GetLogList(this.strategyName, string.Empty);
			}
		}
		protected IStrategyLogList InstrumentLogs
		{
			get
			{
				return this.strategyLogManager.GetLogList(this.strategyName, this.instrument.Symbol);
			}
		}
		protected Strategy()
		{
			this.timers = new Dictionary<DateTime, HashSet<object>>();
			this.Currency = CurrencyManager.DefaultCurrency.Code;
		}
		private void Init(SmartQuant.Instruments.Portfolio sq_Portfolio, SmartQuant.Instruments.Portfolio sq_MetaPortfolio, SmartQuant.Instruments.Instrument sq_Instrument, DataRequests strategyRequests, string strategyName, IStrategyLogManager strategyLogManager)
		{
			this.sq_Instrument = sq_Instrument;
			this.instrument = (Map.SQ_OQ_Instrument[sq_Instrument] as Instrument);
			this.portfolio = (Map.SQ_OQ_Portfolio[sq_Portfolio] as Portfolio);
			this.metaPortfolio = (Map.SQ_OQ_Portfolio[sq_MetaPortfolio] as Portfolio);
			this.performance = new Performance(this.portfolio);
			this.metaPerformance = new Performance(this.metaPortfolio);
			this.dataRequests = strategyRequests;
			this.strategyName = strategyName;
			this.strategyLogManager = strategyLogManager;
		}
		private void Done()
		{
			SmartQuant.Clock.RemoveReminder(new ReminderEventHandler(this.OnReminder));
		}
		public BarSeries GetBars(BarType barType, long barSize)
		{
			return OpenQuant.Bars[this.instrument, barType, barSize];
		}
		public BarSeries GetBars(long barSize)
		{
			return OpenQuant.Bars[this.instrument, BarType.Time, barSize];
		}
		public BarSeries GetBars(Instrument instrument, BarType barType, long barSize)
		{
			return OpenQuant.Bars[instrument, barType, barSize];
		}
		public BarSeries GetBars(Instrument instrument, long barSize)
		{
			return OpenQuant.Bars[instrument, BarType.Time, barSize];
		}
		public BarSeries GetBars(Instrument instrument)
		{
			return OpenQuant.Bars[instrument, this.defaultBarType, this.defaultBarSize];
		}
		public QuoteSeries GetQuotes(Instrument instrument)
		{
			SmartQuant.Instruments.Instrument instrument2 = Map.OQ_SQ_Instrument[instrument] as SmartQuant.Instruments.Instrument;
			return new QuoteSeries(instrument2.Quotes);
		}
		public TradeSeries GetTrades(Instrument instrument)
		{
			SmartQuant.Instruments.Instrument instrument2 = Map.OQ_SQ_Instrument[instrument] as SmartQuant.Instruments.Instrument;
			return new TradeSeries(instrument2.Trades);
		}
		public BarSeries GetHistoricalBars(DateTime begin, DateTime end, BarType barType, long barSize)
		{
			return DataManager.GetHistoricalBars(this.Instrument, begin, end, barType, barSize);
		}
		public BarSeries GetHistoricalBars(BarType barType, long barSize)
		{
			return DataManager.GetHistoricalBars(this.Instrument, barType, barSize);
		}
		public BarSeries GetHistoricalBars(string provider, Instrument instrument, DateTime begin, DateTime end, int size)
		{
			return DataManager.GetHistoricalBars(provider, instrument, begin, end, size);
		}
		public BarSeries GetHistoricalBars(string provider, DateTime begin, DateTime end, int size)
		{
			return DataManager.GetHistoricalBars(provider, this.Instrument, begin, end, size);
		}
		public TradeSeries GetHistoricalTrades(DateTime begin, DateTime end)
		{
			return DataManager.GetHistoricalTrades(this.Instrument, begin, end);
		}
		public TradeSeries GetHistoricalTrades(string provider, Instrument instrument, DateTime begin, DateTime end)
		{
			return DataManager.GetHistoricalTrades(provider, instrument, begin, end);
		}
		public TradeSeries GetHistoricalTrades(string provider, DateTime begin, DateTime end)
		{
			return DataManager.GetHistoricalTrades(provider, this.Instrument, begin, end);
		}
		public QuoteSeries GetHistoricalQuotes(DateTime begin, DateTime end)
		{
			return DataManager.GetHistoricalQuotes(this.Instrument, begin, end);
		}
		public QuoteSeries GetHistoricalQuotes(string provider, Instrument instrument, DateTime begin, DateTime end)
		{
			return DataManager.GetHistoricalQuotes(provider, instrument, begin, end);
		}
		public QuoteSeries GetHistoricalQuotes(string provider, DateTime begin, DateTime end)
		{
			return DataManager.GetHistoricalQuotes(provider, this.Instrument, begin, end);
		}
		public BarSeries GetHistoricalBars(DateTime begin, DateTime end)
		{
			return DataManager.GetHistoricalBars(this.Instrument, begin, end);
		}
		public BarSeries GetHistoricalBars()
		{
			return DataManager.GetHistoricalBars(this.Instrument);
		}
		public virtual void OnStrategyStart()
		{
		}
		public virtual void OnStrategyStop()
		{
		}
		public virtual void OnActiveChanged()
		{
		}
		public void StopStrategy()
		{
			Map.RequestStrategyStop(this);
		}
		public virtual void OnBar(Bar bar)
		{
		}
		public virtual void OnBarSlice(long size)
		{
		}
		public virtual void OnBarOpen(Bar bar)
		{
		}
		public virtual void OnTrade(Trade trade)
		{
		}
		public virtual void OnQuote(Quote quote)
		{
		}
		public virtual void OnOrderBookChanged(OrderBookUpdate update)
		{
		}
		public bool HasPositionQty(double qty)
		{
			return this.HasPosition && this.Position.Qty == qty;
		}
		public bool HasPositionAmount(double amount)
		{
			return this.HasPosition && this.Position.Amount == amount;
		}
		public virtual void OnPositionOpened()
		{
		}
		public virtual void OnPositionClosed()
		{
		}
		public virtual void OnPositionChanged()
		{
		}
		public virtual void OnPositionValueChanged()
		{
		}
		public virtual void OnNewOrder(Order order)
		{
		}
		public virtual void OnOrderStatusChanged(Order order)
		{
		}
		public virtual void OnOrderRejected(Order order)
		{
		}
		public virtual void OnOrderCancelled(Order order)
		{
		}
		public virtual void OnOrderExpired(Order order)
		{
		}
		public virtual void OnOrderReplaced(Order order)
		{
		}
		public virtual void OnOrderFilled(Order order)
		{
		}
		public virtual void OnOrderPartiallyFilled(Order order)
		{
		}
		public virtual void OnOrderReplaceReject(Order order)
		{
		}
		public virtual void OnOrderCancelReject(Order order)
		{
		}
		public virtual void OnOrderDone(Order order)
		{
		}
		public Order MarketOrder(OrderSide side, double qty, string text)
		{
			SingleOrder singleOrder;
			if (side == OrderSide.Buy)
			{
				singleOrder = new MarketOrder(this.sq_Instrument, Side.Buy, qty, text);
			}
			else
			{
				singleOrder = new MarketOrder(this.sq_Instrument, Side.Sell, qty, text);
			}
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void SendMarketOrder(OrderSide side, double qty, string text)
		{
			this.MarketOrder(side, qty, text).Send();
		}
		public Order MarketOrder(OrderSide side, double qty)
		{
			return this.MarketOrder(side, qty, "");
		}
		public void SendMarketOrder(OrderSide side, double qty)
		{
			this.MarketOrder(side, qty).Send();
		}
		public Order StopOrder(OrderSide side, double qty, double stopPrice, string text)
		{
			SingleOrder singleOrder;
			if (side == OrderSide.Buy)
			{
				singleOrder = new StopOrder(this.sq_Instrument, Side.Buy, qty, stopPrice, text);
			}
			else
			{
				singleOrder = new StopOrder(this.sq_Instrument, Side.Sell, qty, stopPrice, text);
			}
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void SendStopOrder(OrderSide side, double qty, double stopPrice, string text)
		{
			this.StopOrder(side, qty, stopPrice, text).Send();
		}
		public Order StopOrder(OrderSide side, double qty, double stopPrice)
		{
			return this.StopOrder(side, qty, stopPrice, "");
		}
		public void SendStopOrder(OrderSide side, double qty, double stopPrice)
		{
			this.StopOrder(side, qty, stopPrice).Send();
		}
		public Order LimitOrder(OrderSide side, double qty, double limitPrice, string text)
		{
			SingleOrder singleOrder;
			if (side == OrderSide.Buy)
			{
				singleOrder = new LimitOrder(this.sq_Instrument, Side.Buy, qty, limitPrice, text);
			}
			else
			{
				singleOrder = new LimitOrder(this.sq_Instrument, Side.Sell, qty, limitPrice, text);
			}
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void SendLimitOrder(OrderSide side, double qty, double limitPrice, string text)
		{
			this.LimitOrder(side, qty, limitPrice, text).Send();
		}
		public Order LimitOrder(OrderSide side, double qty, double limitPrice)
		{
			return this.LimitOrder(side, qty, limitPrice, "");
		}
		public void SendLimitOrder(OrderSide side, double qty, double limitPrice)
		{
			this.LimitOrder(side, qty, limitPrice).Send();
		}
		public Order StopLimitOrder(OrderSide side, double qty, double limitPrice, double stopPrice, string text)
		{
			SingleOrder singleOrder;
			if (side == OrderSide.Buy)
			{
				singleOrder = new StopLimitOrder(this.sq_Instrument, Side.Buy, qty, limitPrice, stopPrice, text);
			}
			else
			{
				singleOrder = new StopLimitOrder(this.sq_Instrument, Side.Sell, qty, limitPrice, stopPrice, text);
			}
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void SendStopLimitOrder(OrderSide side, double qty, double limitPrice, double stopPrice, string text)
		{
			this.StopLimitOrder(side, qty, limitPrice, stopPrice, text).Send();
		}
		public Order StopLimitOrder(OrderSide side, double qty, double limitPrice, double stopPrice)
		{
			return this.StopLimitOrder(side, qty, limitPrice, stopPrice, "");
		}
		public void SendStopLimitOrder(OrderSide side, double qty, double limitPrice, double stopPrice)
		{
			this.StopLimitOrder(side, qty, limitPrice, stopPrice).Send();
		}
		public Order MarketOrder(Instrument instrument, OrderSide side, double qty, string text)
		{
			SingleOrder singleOrder;
			if (side == OrderSide.Buy)
			{
				singleOrder = new MarketOrder(instrument.instrument, Side.Buy, qty, text);
			}
			else
			{
				singleOrder = new MarketOrder(instrument.instrument, Side.Sell, qty, text);
			}
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void SendMarketOrder(Instrument instrument, OrderSide side, double qty, string text)
		{
			this.MarketOrder(instrument, side, qty, text).Send();
		}
		public Order MarketOrder(Instrument instrument, OrderSide side, double qty)
		{
			return this.MarketOrder(instrument, side, qty, "");
		}
		public void SendMarketOrder(Instrument instrument, OrderSide side, double qty)
		{
			this.MarketOrder(instrument, side, qty).Send();
		}
		public Order StopOrder(Instrument instrument, OrderSide side, double qty, double stopPrice, string text)
		{
			SingleOrder singleOrder;
			if (side == OrderSide.Buy)
			{
				singleOrder = new StopOrder(instrument.instrument, Side.Buy, qty, stopPrice, text);
			}
			else
			{
				singleOrder = new StopOrder(instrument.instrument, Side.Sell, qty, stopPrice, text);
			}
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void SendStopOrder(Instrument instrument, OrderSide side, double qty, double stopPrice, string text)
		{
			this.StopOrder(instrument, side, qty, stopPrice, text).Send();
		}
		public Order StopOrder(Instrument instrument, OrderSide side, double qty, double stopPrice)
		{
			return this.StopOrder(instrument, side, qty, stopPrice, "");
		}
		public void SendStopOrder(Instrument instrument, OrderSide side, double qty, double stopPrice)
		{
			this.StopOrder(instrument, side, qty, stopPrice).Send();
		}
		public Order LimitOrder(Instrument instrument, OrderSide side, double qty, double limitPrice, string text)
		{
			SingleOrder singleOrder;
			if (side == OrderSide.Buy)
			{
				singleOrder = new LimitOrder(instrument.instrument, Side.Buy, qty, limitPrice, text);
			}
			else
			{
				singleOrder = new LimitOrder(instrument.instrument, Side.Sell, qty, limitPrice, text);
			}
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void SendLimitOrder(Instrument instrument, OrderSide side, double qty, double limitPrice, string text)
		{
			this.LimitOrder(instrument, side, qty, limitPrice, text).Send();
		}
		public Order LimitOrder(Instrument instrument, OrderSide side, double qty, double limitPrice)
		{
			return this.LimitOrder(instrument, side, qty, limitPrice, "");
		}
		public void SendLimitOrder(Instrument instrument, OrderSide side, double qty, double limitPrice)
		{
			this.LimitOrder(instrument, side, qty, limitPrice).Send();
		}
		public Order StopLimitOrder(Instrument instrument, OrderSide side, double qty, double limitPrice, double stopPrice, string text)
		{
			SingleOrder singleOrder;
			if (side == OrderSide.Buy)
			{
				singleOrder = new StopLimitOrder(instrument.instrument, Side.Buy, qty, limitPrice, stopPrice, text);
			}
			else
			{
				singleOrder = new StopLimitOrder(instrument.instrument, Side.Sell, qty, limitPrice, stopPrice, text);
			}
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void SendStopLimitOrder(Instrument instrument, OrderSide side, double qty, double limitPrice, double stopPrice, string text)
		{
			this.StopLimitOrder(instrument, side, qty, limitPrice, stopPrice, text).Send();
		}
		public Order StopLimitOrder(Instrument instrument, OrderSide side, double qty, double limitPrice, double stopPrice)
		{
			return this.StopLimitOrder(instrument, side, qty, limitPrice, stopPrice, "");
		}
		public void SendStopLimitOrder(Instrument instrument, OrderSide side, double qty, double limitPrice, double stopPrice)
		{
			this.StopLimitOrder(instrument, side, qty, limitPrice, stopPrice).Send();
		}
		public Order BuyOrder(double qty, string text)
		{
			SingleOrder singleOrder = new MarketOrder(this.sq_Instrument, Side.Buy, qty, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public Order SellOrder(double qty, string text)
		{
			SingleOrder singleOrder = new MarketOrder(this.sq_Instrument, Side.Sell, qty, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void Buy(double qty, string text)
		{
			this.BuyOrder(qty, text).Send();
		}
		public void Sell(double qty, string text)
		{
			this.SellOrder(qty, text).Send();
		}
		public Order BuyOrder(double qty)
		{
			return this.BuyOrder(qty, "");
		}
		public Order SellOrder(double qty)
		{
			return this.SellOrder(qty, "");
		}
		public void Buy(double qty)
		{
			this.BuyOrder(qty).Send();
		}
		public void Sell(double qty)
		{
			this.SellOrder(qty).Send();
		}
		public Order BuyStopOrder(double qty, double stopPrice, string text)
		{
			SingleOrder singleOrder = new StopOrder(this.sq_Instrument, Side.Buy, qty, stopPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public Order SellStopOrder(double qty, double stopPrice, string text)
		{
			SingleOrder singleOrder = new StopOrder(this.sq_Instrument, Side.Sell, qty, stopPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void BuyStop(double qty, double stopPrice, string text)
		{
			this.BuyStopOrder(qty, stopPrice, text).Send();
		}
		public void SellStop(double qty, double stopPrice, string text)
		{
			this.SellStopOrder(qty, stopPrice, text).Send();
		}
		public Order BuyStopOrder(double qty, double stopPrice)
		{
			return this.BuyStopOrder(qty, stopPrice, "");
		}
		public Order SellStopOrder(double qty, double stopPrice)
		{
			return this.SellStopOrder(qty, stopPrice, "");
		}
		public void BuyStop(double qty, double stopPrice)
		{
			this.BuyStopOrder(qty, stopPrice).Send();
		}
		public void SellStop(double qty, double stopPrice)
		{
			this.SellStopOrder(qty, stopPrice).Send();
		}
		public Order BuyLimitOrder(double qty, double limitPrice, string text)
		{
			SingleOrder singleOrder = new LimitOrder(this.sq_Instrument, Side.Buy, qty, limitPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public Order SellLimitOrder(double qty, double limitPrice, string text)
		{
			SingleOrder singleOrder = new LimitOrder(this.sq_Instrument, Side.Sell, qty, limitPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void BuyLimit(double qty, double limitPrice, string text)
		{
			this.BuyLimitOrder(qty, limitPrice, text).Send();
		}
		public void SellLimit(double qty, double limitPrice, string text)
		{
			this.SellLimitOrder(qty, limitPrice, text).Send();
		}
		public Order BuyLimitOrder(double qty, double limitPrice)
		{
			return this.BuyLimitOrder(qty, limitPrice, "");
		}
		public Order SellLimitOrder(double qty, double limitPrice)
		{
			return this.SellLimitOrder(qty, limitPrice, "");
		}
		public void BuyLimit(double qty, double limitPrice)
		{
			this.BuyLimitOrder(qty, limitPrice).Send();
		}
		public void SellLimit(double qty, double limitPrice)
		{
			this.SellLimitOrder(qty, limitPrice).Send();
		}
		public Order BuyStopLimitOrder(double qty, double limitPrice, double stopPrice, string text)
		{
			SingleOrder singleOrder = new StopLimitOrder(this.sq_Instrument, Side.Buy, qty, limitPrice, stopPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public Order SellStopLimitOrder(double qty, double limitPrice, double stopPrice, string text)
		{
			SingleOrder singleOrder = new StopLimitOrder(this.sq_Instrument, Side.Sell, qty, limitPrice, stopPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void BuyStopLimit(double qty, double limitPrice, double stopPrice, string text)
		{
			this.BuyStopLimitOrder(qty, limitPrice, stopPrice, text).Send();
		}
		public void SellStopLimit(double qty, double limitPrice, double stopPrice, string text)
		{
			this.SellStopLimitOrder(qty, limitPrice, stopPrice, text).Send();
		}
		public Order BuyStopLimitOrder(double qty, double limitPrice, double stopPrice)
		{
			return this.BuyStopLimitOrder(qty, limitPrice, stopPrice, "");
		}
		public Order SellStopLimitOrder(double qty, double limitPrice, double stopPrice)
		{
			return this.SellStopLimitOrder(qty, limitPrice, stopPrice, "");
		}
		public void BuyStopLimit(double qty, double limitPrice, double stopPrice)
		{
			this.BuyStopLimitOrder(qty, limitPrice, stopPrice).Send();
		}
		public void SellStopLimit(double qty, double limitPrice, double stopPrice)
		{
			this.SellStopLimitOrder(qty, limitPrice, stopPrice).Send();
		}
		public Order BuyOrder(Instrument instrument, double qty, string text)
		{
			SingleOrder singleOrder = new MarketOrder(instrument.instrument, Side.Buy, qty, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public Order SellOrder(Instrument instrument, double qty, string text)
		{
			SingleOrder singleOrder = new MarketOrder(instrument.instrument, Side.Sell, qty, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void Buy(Instrument instrument, double qty, string text)
		{
			this.BuyOrder(instrument, qty, text).Send();
		}
		public void Sell(Instrument instrument, double qty, string text)
		{
			this.SellOrder(instrument, qty, text).Send();
		}
		public Order BuyOrder(Instrument instrument, double qty)
		{
			return this.BuyOrder(instrument, qty, "");
		}
		public Order SellOrder(Instrument instrument, double qty)
		{
			return this.SellOrder(instrument, qty, "");
		}
		public void Buy(Instrument instrument, double qty)
		{
			this.BuyOrder(instrument, qty).Send();
		}
		public void Sell(Instrument instrument, double qty)
		{
			this.SellOrder(instrument, qty).Send();
		}
		public Order BuyStopOrder(Instrument instrument, double qty, double stopPrice, string text)
		{
			SingleOrder singleOrder = new StopOrder(instrument.instrument, Side.Buy, qty, stopPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public Order SellStopOrder(Instrument instrument, double qty, double stopPrice, string text)
		{
			SingleOrder singleOrder = new StopOrder(instrument.instrument, Side.Sell, qty, stopPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void BuyStop(Instrument instrument, double qty, double stopPrice, string text)
		{
			this.BuyStopOrder(instrument, qty, stopPrice, text).Send();
		}
		public void SellStop(Instrument instrument, double qty, double stopPrice, string text)
		{
			this.SellStopOrder(instrument, qty, stopPrice, text).Send();
		}
		public Order BuyStopOrder(Instrument instrument, double qty, double stopPrice)
		{
			return this.BuyStopOrder(instrument, qty, stopPrice, "");
		}
		public Order SellStopOrder(Instrument instrument, double qty, double stopPrice)
		{
			return this.SellStopOrder(instrument, qty, stopPrice, "");
		}
		public void BuyStop(Instrument instrument, double qty, double stopPrice)
		{
			this.BuyStopOrder(instrument, qty, stopPrice).Send();
		}
		public void SellStop(Instrument instrument, double qty, double stopPrice)
		{
			this.SellStopOrder(instrument, qty, stopPrice).Send();
		}
		public Order BuyLimitOrder(Instrument instrument, double qty, double limitPrice, string text)
		{
			SingleOrder singleOrder = new LimitOrder(instrument.instrument, Side.Buy, qty, limitPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public Order SellLimitOrder(Instrument instrument, double qty, double limitPrice, string text)
		{
			SingleOrder singleOrder = new LimitOrder(instrument.instrument, Side.Sell, qty, limitPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void BuyLimit(Instrument instrument, double qty, double limitPrice, string text)
		{
			this.BuyLimitOrder(instrument, qty, limitPrice, text).Send();
		}
		public void SellLimit(Instrument instrument, double qty, double limitPrice, string text)
		{
			this.SellLimitOrder(instrument, qty, limitPrice, text).Send();
		}
		public Order BuyLimitOrder(Instrument instrument, double qty, double limitPrice)
		{
			return this.BuyLimitOrder(instrument, qty, limitPrice, "");
		}
		public Order SellLimitOrder(Instrument instrument, double qty, double limitPrice)
		{
			return this.SellLimitOrder(instrument, qty, limitPrice, "");
		}
		public void BuyLimit(Instrument instrument, double qty, double limitPrice)
		{
			this.BuyLimitOrder(instrument, qty, limitPrice).Send();
		}
		public void SellLimit(Instrument instrument, double qty, double limitPrice)
		{
			this.SellLimitOrder(instrument, qty, limitPrice).Send();
		}
		public Order BuyStopLimitOrder(Instrument instrument, double qty, double limitPrice, double stopPrice, string text)
		{
			SingleOrder singleOrder = new StopLimitOrder(instrument.instrument, Side.Buy, qty, limitPrice, stopPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public Order SellStopLimitOrder(Instrument instrument, double qty, double limitPrice, double stopPrice, string text)
		{
			SingleOrder singleOrder = new StopLimitOrder(instrument.instrument, Side.Sell, qty, limitPrice, stopPrice, text);
			singleOrder.Strategy = this.strategyName;
			Order order = new Order(singleOrder);
			order.Portfolio = this.portfolio;
			Map.OQ_SQ_Order[order] = singleOrder;
			Map.SQ_OQ_Order[singleOrder] = order;
			return order;
		}
		public void BuyStopLimit(Instrument instrument, double qty, double limitPrice, double stopPrice, string text)
		{
			this.BuyStopLimitOrder(instrument, qty, limitPrice, stopPrice, text).Send();
		}
		public void SellStopLimit(Instrument instrument, double qty, double limitPrice, double stopPrice, string text)
		{
			this.SellStopLimitOrder(instrument, qty, limitPrice, stopPrice, text).Send();
		}
		public Order BuyStopLimitOrder(Instrument instrument, double qty, double limitPrice, double stopPrice)
		{
			return this.BuyStopLimitOrder(instrument, qty, limitPrice, stopPrice, "");
		}
		public Order SellStopLimitOrder(Instrument instrument, double qty, double limitPrice, double stopPrice)
		{
			return this.SellStopLimitOrder(instrument, qty, limitPrice, stopPrice, "");
		}
		public void BuyStopLimit(Instrument instrument, double qty, double limitPrice, double stopPrice)
		{
			this.BuyStopLimitOrder(instrument, qty, limitPrice, stopPrice).Send();
		}
		public void SellStopLimit(Instrument instrument, double qty, double limitPrice, double stopPrice)
		{
			this.SellStopLimitOrder(instrument, qty, limitPrice, stopPrice).Send();
		}
		public virtual void OnStopExecuted(Stop stop)
		{
		}
		public Stop SetStop(Position position, double level, StopType type, StopMode mode)
		{
			Stop stop = new Stop(position, level, type, mode);
			Map.OQ_SQ_Stop[stop] = stop.stop;
			Map.SQ_OQ_Stop[stop.stop] = stop;
			Map.AddStop(stop.stop, this.strategyName);
			stop.TraceOnBar = this.stopTraceOnBar;
			stop.TraceOnTrade = this.stopTraceOnTrade;
			stop.TraceOnQuote = this.stopTraceOnQuote;
			return stop;
		}
		public Stop SetStop(double level, StopType type, StopMode mode)
		{
			return this.SetStop(this.Position, level, type, mode);
		}
		public Stop SetStop(Position position, DateTime dateTime)
		{
			Stop stop = new Stop(position, dateTime);
			Map.OQ_SQ_Stop[stop] = stop.stop;
			Map.SQ_OQ_Stop[stop.stop] = stop;
			Map.AddStop(stop.stop, this.strategyName);
			stop.TraceOnBar = this.stopTraceOnBar;
			stop.TraceOnTrade = this.stopTraceOnTrade;
			stop.TraceOnQuote = this.stopTraceOnQuote;
			return stop;
		}
		public Stop SetStop(DateTime dateTime)
		{
			return this.SetStop(this.Position, dateTime);
		}
		public virtual void OnTimer(DateTime datetime, object data)
		{
		}
		public void AddTimer(DateTime datetime, object data)
		{
			HashSet<object> hashSet;
			if (!this.timers.TryGetValue(datetime, out hashSet))
			{
				hashSet = new HashSet<object>();
				this.timers.Add(datetime, hashSet);
				SmartQuant.Clock.AddReminder(new ReminderEventHandler(this.OnReminder), datetime, null);
			}
			hashSet.Add(data);
		}
		public void AddTimer(DateTime datetime)
		{
			this.AddTimer(datetime, null);
		}
		public void RemoveTimer(DateTime datetime, object data)
		{
			HashSet<object> hashSet;
			if (this.timers.TryGetValue(datetime, out hashSet))
			{
				hashSet.Remove(data);
				if (hashSet.Count == 0)
				{
					this.timers.Remove(datetime);
					SmartQuant.Clock.RemoveReminder(new ReminderEventHandler(this.OnReminder), datetime);
				}
			}
		}
		public void RemoveTimer(DateTime datetime)
		{
			this.RemoveTimer(datetime, null);
		}
		public void RemoveTimers(DateTime datetime)
		{
			HashSet<object> collection;
			if (this.timers.TryGetValue(datetime, out collection))
			{
				foreach (object current in new List<object>(collection))
				{
					this.RemoveTimer(datetime, current);
				}
			}
		}
		public void RemoveTimers()
		{
			this.timers.Clear();
		}
		private void OnReminder(ReminderEventArgs args)
		{
			HashSet<object> hashSet;
			if (this.timers.TryGetValue(args.SignalTime, out hashSet))
			{
				this.timers.Remove(args.SignalTime);
				foreach (object current in hashSet)
				{
					this.OnTimer(args.SignalTime, current);
				}
			}
		}
		public void ClosePosition()
		{
			if (this.HasPosition)
			{
				if (this.Position.Side == PositionSide.Long)
				{
					this.Sell(this.Position.Qty);
					return;
				}
				this.Buy(this.Position.Qty);
			}
		}
		public void ClosePosition(string text)
		{
			if (this.HasPosition)
			{
				if (this.Position.Side == PositionSide.Long)
				{
					this.Sell(this.Position.Qty, text);
					return;
				}
				this.Buy(this.Position.Qty, text);
			}
		}
		public void CloseAllPositions(string text)
		{
			List<Position> list = this.portfolio.Positions.Cast<Position>().ToList<Position>();
			foreach (Position current in list)
			{
				if (current.Side == PositionSide.Long)
				{
					this.Sell(current.Instrument, current.Qty, text);
				}
				else
				{
					this.Buy(current.Instrument, current.Qty, text);
				}
			}
		}
		public void CloseAllPositions()
		{
			this.CloseAllPositions("");
		}
		public void CancelOrders()
		{
			SingleOrder[] array = (
				from Order o in OpenQuant.Orders
				select o.order).ToArray<SingleOrder>();
			SingleOrder[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				SingleOrder singleOrder = array2[i];
				if (!singleOrder.IsDone && singleOrder.Strategy == this.strategyName && singleOrder.Instrument == this.instrument.instrument)
				{
					singleOrder.Cancel();
				}
			}
		}
		public void CancelAllOrders()
		{
			List<SingleOrder> list = (
				from Order o in OpenQuant.Orders
				select o.order).ToList<SingleOrder>();
			foreach (SingleOrder current in list)
			{
				if (!current.IsDone && current.Strategy == this.strategyName)
				{
					current.Cancel();
				}
			}
		}
		public virtual void OnConnected(string provider)
		{
		}
		public virtual void OnDisconnected(string provider)
		{
		}
		public virtual void OnError(ProviderError error)
		{
		}
		public void Draw(Indicator indicator)
		{
			int padNumber = -1;
			switch (indicator.indicator.Type)
			{
			case EIndicatorType.Oscillator:
			case EIndicatorType.Volume:
				padNumber = this.maxPadNumber + 1;
				break;
			case EIndicatorType.Price:
				padNumber = 0;
				break;
			}
			if (indicator is UserIndicator)
			{
				(indicator as UserIndicator).Init();
			}
			this.Draw(indicator.indicator, padNumber);
		}
		public void Draw(Indicator indicator, int padNumber)
		{
			if (indicator is UserIndicator)
			{
				(indicator as UserIndicator).Init();
			}
			this.Draw(indicator.indicator, padNumber);
		}
		public void Draw(TimeSeries series)
		{
			this.Draw(series.series, this.maxPadNumber + 1);
		}
		public void Draw(TimeSeries series, int padNumber)
		{
			this.Draw(series.series, padNumber);
		}
		public void Draw(Indicator indicator, DrawStyle style)
		{
			int padNumber = -1;
			switch (indicator.indicator.Type)
			{
			case EIndicatorType.Oscillator:
			case EIndicatorType.Volume:
				padNumber = this.maxPadNumber + 1;
				break;
			case EIndicatorType.Price:
				padNumber = 0;
				break;
			}
			if (indicator is UserIndicator)
			{
				(indicator as UserIndicator).Init();
			}
			this.Draw(indicator.indicator, padNumber, style);
		}
		public void Draw(Indicator indicator, int padNumber, DrawStyle style)
		{
			if (indicator is UserIndicator)
			{
				(indicator as UserIndicator).Init();
			}
			this.Draw(indicator.indicator, padNumber, style);
		}
		public void Draw(TimeSeries series, DrawStyle style)
		{
			this.Draw(series.series, this.maxPadNumber + 1, style);
		}
		public void Draw(TimeSeries series, int padNumber, DrawStyle style)
		{
			this.Draw(series.series, padNumber, style);
		}
		private void Draw(DoubleSeries series, int padNumber)
		{
			this.Draw(series, padNumber, DrawStyle.Line);
		}
		private void Draw(DoubleSeries series, int padNumber, DrawStyle stype)
		{
			Dictionary<SmartQuant.Instruments.Instrument, Dictionary<DoubleSeries, Tuple<int, DrawStyle>>> dictionary;
			if (Map.DrawTable.ContainsKey(this.strategyName))
			{
				dictionary = (Map.DrawTable[this.strategyName] as Dictionary<SmartQuant.Instruments.Instrument, Dictionary<DoubleSeries, Tuple<int, DrawStyle>>>);
			}
			else
			{
				dictionary = new Dictionary<SmartQuant.Instruments.Instrument, Dictionary<DoubleSeries, Tuple<int, DrawStyle>>>();
				Map.DrawTable[this.strategyName] = dictionary;
			}
			Dictionary<DoubleSeries, Tuple<int, DrawStyle>> dictionary2;
			if (dictionary.ContainsKey(this.sq_Instrument))
			{
				dictionary2 = dictionary[this.sq_Instrument];
			}
			else
			{
				dictionary2 = new Dictionary<DoubleSeries, Tuple<int, DrawStyle>>();
				dictionary[this.sq_Instrument] = dictionary2;
			}
			dictionary2[series] = new Tuple<int, DrawStyle>(padNumber, stype);
			this.maxPadNumber = Math.Max(this.maxPadNumber, padNumber);
		}
		public void Scan(BarData barData)
		{
			this.ScanObject(barData);
		}
		public void Scan(ISeries series)
		{
			this.ScanObject(series);
		}
		private void ScanObject(object obj)
		{
			OrderedDictionary orderedDictionary;
			if (Map.PrintTable.ContainsKey(this.strategyName))
			{
				orderedDictionary = Map.PrintTable[this.strategyName];
			}
			else
			{
				orderedDictionary = new OrderedDictionary();
				Map.PrintTable[this.strategyName] = orderedDictionary;
			}
			string key;
			if (obj is ISeries)
			{
				key = (obj as ISeries).Name;
			}
			else
			{
				key = ((BarData)obj).ToString();
			}
			Dictionary<Instrument, object> dictionary;
			if (orderedDictionary.Contains(key))
			{
				dictionary = (orderedDictionary[key] as Dictionary<Instrument, object>);
			}
			else
			{
				dictionary = new Dictionary<Instrument, object>();
				orderedDictionary[key] = dictionary;
			}
			dictionary[this.instrument] = obj;
		}
		public virtual void OnUserCommand(UserCommand command)
		{
		}
		public virtual void OnCustomCommand(object[] parameters)
		{
		}
		public void SendCustomCommand(string projectName, string symbol, params object[] parameters)
		{
			Map.RaiseCommand(projectName, symbol, parameters);
		}
		public void SendCustomCommand(string projectName, params object[] parameters)
		{
			this.SendCustomCommand(projectName, null, parameters);
		}
		public void SendCustomCommand(params object[] parameters)
		{
			this.SendCustomCommand(null, null, parameters);
		}
		public void EmitTrade(Instrument instrument, Trade trade)
		{
			if (this.MarketDataProvider.provider is ISimulationMarketDataProvider)
			{
				(this.MarketDataProvider.provider as ISimulationMarketDataProvider).EmitTrade(instrument.instrument, trade.trade);
			}
		}
		public void EmitTrade(Trade trade)
		{
			this.EmitTrade(this.Instrument, trade);
		}
		public void EmitQuote(Instrument instrument, Quote quote)
		{
			if (this.MarketDataProvider.provider is ISimulationMarketDataProvider)
			{
				(this.MarketDataProvider.provider as ISimulationMarketDataProvider).EmitQuote(instrument.instrument, quote.quote);
			}
		}
		public void EmitQuote(Quote quote)
		{
			this.EmitQuote(this.Instrument, quote);
		}
	}
}
