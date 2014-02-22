using OpenQuant.API.Design;
using SmartQuant;
using SmartQuant.FIX;
using SmartQuant.Instruments;
using System;
using System.ComponentModel;
using System.Drawing.Design;
namespace OpenQuant.API
{
	public class Instrument
	{
		private const string CATEGORY_APPEARANCE = "Appearance";
		private const string CATEGORY_APPEARANCE_ALTERNATIVE = "Appearance (alternative)";
		private const string CATEGORY_DERIVATIVE = "Derivative";
		private const string CATEGORY_MARGIN = "Margin";
		private const string CATEGORY_INDUSTRY = "Industry";
		private const string CATEGORY_DISPLAY = "Display";
		private const string CATEGORY_TICK_SIZE = "TickSize";
		internal SmartQuant.Instruments.Instrument instrument;
		private OrderBook book;
		[Category("Appearance"), Description("Instrument symbol")]
		public string Symbol
		{
			get
			{
				return this.instrument.Symbol;
			}
		}
		[Category("Appearance"), Description("Instrument Type (Stock, Futures, Option, Bond, ETF, Index, etc.)")]
		public InstrumentType Type
		{
			get
			{
				return EnumConverter.Convert(this.instrument.SecurityType);
			}
		}
		[Category("Appearance"), Description("Instrument description")]
		public string Description
		{
			get
			{
				return this.instrument.SecurityDesc;
			}
			set
			{
				this.instrument.SecurityDesc = value;
				this.instrument.Save();
			}
		}
		[Category("Appearance"), Description("Instrument exchange")]
		public string Exchange
		{
			get
			{
				return this.instrument.SecurityExchange;
			}
			set
			{
				this.instrument.SecurityExchange = value;
				this.instrument.Save();
			}
		}
		[Category("Appearance"), Description("Instrument currency code (USD, EUR, RUR, CAD, etc.)")]
		public string Currency
		{
			get
			{
				return this.instrument.Currency;
			}
			set
			{
				this.instrument.Currency = value;
				this.instrument.Save();
			}
		}
		[Category("Appearance (alternative)"), Description("Instrument alternative symbol"), Editor(typeof(AltIDGroupListEditor), typeof(UITypeEditor)), RefreshProperties(RefreshProperties.All), TypeConverter(typeof(AltIDGroupListTypeConverter))]
		public AltIDGroupList AltIDGroups
		{
			get;
			private set;
		}
		[Browsable(false), Category("Appearance (alternative)"), Description("Instrument alternative symbol"), Obsolete("Use Instrument.AltIDGroups property instead")]
		public string AltSymbol
		{
			get
			{
				if (this.instrument.SecurityAltIDGroup.Count == 0)
				{
					return string.Empty;
				}
				return this.instrument.SecurityAltIDGroup[0].SecurityAltID;
			}
			set
			{
				if (this.instrument.SecurityAltIDGroup.Count == 0)
				{
					this.instrument.SecurityAltIDGroup.Add(new FIXSecurityAltIDGroup());
				}
				this.instrument.SecurityAltIDGroup[0].SecurityAltID = value;
				this.instrument.Save();
			}
		}
		[Browsable(false), Category("Appearance (alternative)"), Description("Alternative source of instrument definition (provider name)"), Editor(typeof(AltSourceTypeEditor), typeof(UITypeEditor)), Obsolete("Use Instrument.AltIDGroups property instead")]
		public string AltSource
		{
			get
			{
				if (this.instrument.SecurityAltIDGroup.Count == 0)
				{
					return string.Empty;
				}
				return this.instrument.SecurityAltIDGroup[0].SecurityAltIDSource;
			}
			set
			{
				if (this.instrument.SecurityAltIDGroup.Count == 0)
				{
					this.instrument.SecurityAltIDGroup.Add(new FIXSecurityAltIDGroup());
				}
				this.instrument.SecurityAltIDGroup[0].SecurityAltIDSource = value;
				this.instrument.Save();
			}
		}
		[Browsable(false), Category("Appearance (alternative)"), Description("Instrument alternative exchange"), Obsolete("Use Instrument.AltIDGroups property instead")]
		public string AltExchange
		{
			get
			{
				if (this.instrument.SecurityAltIDGroup.Count == 0)
				{
					return string.Empty;
				}
				return this.instrument.SecurityAltIDGroup[0].SecurityAltExchange;
			}
			set
			{
				if (this.instrument.SecurityAltIDGroup.Count == 0)
				{
					this.instrument.SecurityAltIDGroup.Add(new FIXSecurityAltIDGroup());
				}
				this.instrument.SecurityAltIDGroup[0].SecurityAltExchange = value;
				this.instrument.Save();
			}
		}
		[Category("Derivative"), DefaultValue(0.0), Description("Contract Value Factor by which price must be adjusted to determine the true nominal value of one futures/options contract. (Qty * Price) * Factor = Nominal Value")]
		public double Factor
		{
			get
			{
				return this.instrument.Factor;
			}
			set
			{
				this.instrument.Factor = value;
				this.instrument.Save();
			}
		}
		[Category("Derivative"), Description("Instrument maturity")]
		public DateTime Maturity
		{
			get
			{
				return this.instrument.MaturityDate;
			}
			set
			{
				this.instrument.MaturityDate = value;
				this.instrument.Save();
			}
		}
		[Category("Derivative"), DefaultValue(0.0), Description("Instrument strike price")]
		public double Strike
		{
			get
			{
				return this.instrument.StrikePrice;
			}
			set
			{
				this.instrument.StrikePrice = value;
				this.instrument.Save();
			}
		}
		[Category("Derivative"), Description("Option type : put or call")]
		public PutCall PutCall
		{
			get
			{
				switch (this.instrument.PutOrCall)
				{
				case PutOrCall.Put:
					return PutCall.Put;
				case PutOrCall.Call:
					return PutCall.Call;
				default:
					throw new ArgumentException(string.Format("PutCall is not supported - {0}", this.instrument.PutOrCall));
				}
			}
			set
			{
				switch (value)
				{
				case PutCall.Put:
					this.instrument.PutOrCall = PutOrCall.Put;
					break;
				case PutCall.Call:
					this.instrument.PutOrCall = PutOrCall.Call;
					break;
				default:
					throw new ArgumentException(string.Format("PutCall is not supported - {0}", value));
				}
				this.instrument.Save();
			}
		}
		[Category("Margin"), DefaultValue(0.0), Description("Initial margin (simulations)")]
		public double Margin
		{
			get
			{
				return this.instrument.Margin;
			}
			set
			{
				this.instrument.Margin = value;
				this.instrument.Save();
			}
		}
		[Category("Industry"), Description("Industry group")]
		public string Group
		{
			get
			{
				return this.instrument.IndustryGroup;
			}
			set
			{
				this.instrument.IndustryGroup = value;
				this.instrument.Save();
			}
		}
		[Category("Industry"), Description("Industry sector")]
		public string Sector
		{
			get
			{
				return this.instrument.IndustrySector;
			}
			set
			{
				this.instrument.IndustrySector = value;
				this.instrument.Save();
			}
		}
		[Category("Display"), DefaultValue("F2"), Description("C# price format string (example: F4 - show four decimal numbers for Forex contracts)")]
		public string PriceFormat
		{
			get
			{
				return this.instrument.PriceDisplay;
			}
			set
			{
				this.instrument.PriceDisplay = value;
				this.instrument.Save();
			}
		}
		[Category("TickSize"), DefaultValue(0.0)]
		public double TickSize
		{
			get
			{
				return this.instrument.TickSize;
			}
			set
			{
				this.instrument.TickSize = value;
				this.instrument.Save();
			}
		}
		[Browsable(false)]
		public Bar Bar
		{
			get
			{
				return new Bar(this.instrument.Bar);
			}
		}
		[Browsable(false)]
		public Trade Trade
		{
			get
			{
				return new Trade(this.instrument.Trade);
			}
		}
		[Browsable(false)]
		public Quote Quote
		{
			get
			{
				return new Quote(this.instrument.Quote);
			}
		}
		[Browsable(false)]
		public OrderBook OrderBook
		{
			get
			{
				return this.book;
			}
		}
		internal Instrument(SmartQuant.Instruments.Instrument instrument)
		{
			this.instrument = instrument;
			this.book = new OrderBook(instrument.OrderBook);
			this.AltIDGroups = new AltIDGroupList(this);
		}
		public Instrument(InstrumentType type, string symbol) : this(type, symbol, Framework.Configuration.DefaultExchange, Framework.Configuration.DefaultCurrency)
		{
		}
		public Instrument(InstrumentType type, string symbol, string secutityExchange, string currency)
		{
			if (!SmartQuant.Instruments.InstrumentManager.Instruments.Contains(symbol))
			{
				this.instrument = new SmartQuant.Instruments.Instrument(symbol, EnumConverter.Convert(type));
				this.instrument.SecurityExchange = secutityExchange;
				this.instrument.Currency = currency;
				this.instrument.Save();
			}
		}
		public override string ToString()
		{
			return this.instrument.ToString();
		}
		public string GetSymbol(string source)
		{
			return this.instrument.GetSymbol(source);
		}
		public string GetExchange(string source)
		{
			return this.instrument.GetSecurityExchange(source);
		}
	}
}
