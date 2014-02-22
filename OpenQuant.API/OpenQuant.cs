using OpenQuant.ObjectMap;
using SmartQuant.Execution;
using SmartQuant.Instruments;
using System;
namespace OpenQuant.API
{
	public class OpenQuant
	{
		private static InstrumentList instruments = new InstrumentList();
		private static OrderList orders = new OrderList();
		private static BarSeriesList bars = new BarSeriesList();
		public static InstrumentList Instruments
		{
			get
			{
				return OpenQuant.instruments;
			}
		}
		public static OrderList Orders
		{
			get
			{
				return OpenQuant.orders;
			}
		}
		public static BarSeriesList Bars
		{
			get
			{
				return OpenQuant.bars;
			}
		}
		public static bool EnablePartialTransactions
		{
			get
			{
				return OrderManager.EnablePartialTransactions;
			}
			set
			{
				OrderManager.EnablePartialTransactions = value;
			}
		}
		public static void Init()
		{
			Currency.Converter = new DefaultCurrencyConverter();
			foreach (SmartQuant.Instruments.Instrument sq_instrument in SmartQuant.Instruments.InstrumentManager.Instruments)
			{
				OpenQuant.AddInstrument(sq_instrument);
			}
			SmartQuant.Instruments.InstrumentManager.InstrumentAdded += new InstrumentEventHandler(OpenQuant.SQInstrumentManager_InstrumentAdded);
			SmartQuant.Instruments.InstrumentManager.InstrumentRemoved += new InstrumentEventHandler(OpenQuant.SQInstrumentManager_InstrumentRemoved);
			foreach (SmartQuant.Instruments.Portfolio sq_portfolio in PortfolioManager.Portfolios)
			{
				OpenQuant.AddPortfolio(sq_portfolio);
			}
			PortfolioManager.PortfolioAdded += new PortfolioEventHandler(OpenQuant.SQ_PortfolioManager_PortfolioAdded);
			OpenQuant.InitOrders();
			OrderManager.NewOrder += new OrderEventHandler(OpenQuant.SQ_OrderManager_NewOrder);
			OrderManager.OrderRemoved += new OrderEventHandler(OpenQuant.SQ_OrderManager_OrderRemoved);
			OrderManager.OrderListUpdated += new EventHandler(OpenQuant.SQ_OrderManager_OrderListUpdated);
		}
		private static void InitOrders()
		{
			foreach (SingleOrder singleOrder in OrderManager.Orders.All)
			{
				Order order = Order.CreateWrapper(singleOrder);
				OpenQuant.orders.Add(order);
				Map.OQ_SQ_Order[order] = singleOrder;
				Map.SQ_OQ_Order[singleOrder] = order;
			}
		}
		private static void SQ_OrderManager_OrderListUpdated(object sender, EventArgs e)
		{
			OpenQuant.orders.Clear();
			Map.OQ_SQ_Order.Clear();
			Map.SQ_OQ_Order.Clear();
			foreach (SingleOrder singleOrder in OrderManager.Orders.All)
			{
				Order order = new Order(singleOrder);
				OpenQuant.orders.Add(order);
				Map.OQ_SQ_Order[order] = singleOrder;
				Map.SQ_OQ_Order[singleOrder] = order;
			}
		}
		private static void SQ_OrderManager_NewOrder(OrderEventArgs args)
		{
			Order order;
			if (Map.SQ_OQ_Order.ContainsKey(args.Order))
			{
				order = (Map.SQ_OQ_Order[args.Order] as Order);
			}
			else
			{
				order = new Order(args.Order);
				Map.OQ_SQ_Order[order] = args.Order;
				Map.SQ_OQ_Order[args.Order] = order;
			}
			OpenQuant.orders.Add(order);
		}
		private static void SQ_OrderManager_OrderRemoved(OrderEventArgs args)
		{
			Order order = Map.SQ_OQ_Order[args.Order] as Order;
			OpenQuant.orders.Remove(order);
			Map.SQ_OQ_Order.Remove(args.Order);
			Map.OQ_SQ_Order.Remove(order);
		}
		private static void SQInstrumentManager_InstrumentAdded(InstrumentEventArgs args)
		{
			OpenQuant.AddInstrument(args.Instrument);
		}
		private static void SQInstrumentManager_InstrumentRemoved(InstrumentEventArgs args)
		{
			OpenQuant.RemoveInstrument(args.Instrument);
		}
		private static void AddInstrument(SmartQuant.Instruments.Instrument sq_instrument)
		{
			Instrument instrument = new Instrument(sq_instrument);
			OpenQuant.instruments.Add(sq_instrument.Symbol, instrument);
			Map.OQ_SQ_Instrument[instrument] = sq_instrument;
			Map.SQ_OQ_Instrument[sq_instrument] = instrument;
		}
		private static void RemoveInstrument(SmartQuant.Instruments.Instrument sq_instrument)
		{
			OpenQuant.instruments.Remove(sq_instrument.Symbol);
			Instrument key = Map.SQ_OQ_Instrument[sq_instrument] as Instrument;
			Map.OQ_SQ_Instrument.Remove(key);
			Map.SQ_OQ_Instrument.Remove(sq_instrument);
		}
		private static void SQ_PortfolioManager_PortfolioAdded(PortfolioEventArgs args)
		{
			OpenQuant.AddPortfolio(args.Portfolio);
		}
		private static void AddPortfolio(SmartQuant.Instruments.Portfolio sq_portfolio)
		{
			Portfolio portfolio = new Portfolio(sq_portfolio);
			Map.OQ_SQ_Portfolio[portfolio] = sq_portfolio;
			Map.SQ_OQ_Portfolio[sq_portfolio] = portfolio;
		}
	}
}
