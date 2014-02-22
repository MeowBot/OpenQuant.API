using OpenQuant.Config;
using OpenQuant.ObjectMap;
using SmartQuant;
using SmartQuant.Instruments;
using System;
namespace OpenQuant.API.Engine
{
	public class Scenario
	{
		public event EventHandler StartRequested;
		public event EventHandler StopRequested;
		public Solution Solution
		{
			get
			{
				return IDE.Solution;
			}
		}
		public ExecutionProvider ExecutionProvider
		{
			get
			{
				return new ExecutionProvider(OpenQuant.Config.Configuration.Active.ExecutionProvider);
			}
		}
		public MarketDataProvider MarketDataProvider
		{
			get
			{
				return new MarketDataProvider(OpenQuant.Config.Configuration.Active.MarketDataProvider);
			}
		}
		public OpenQuant.API.PortfolioPricer PortfolioPricer
		{
			set
			{
				PortfolioManager.Pricer = new SQPortfolioPricer(value);
			}
		}
		public StrategyMode Mode
		{
			get;
			private set;
		}
		public bool ResetOnStart
		{
			get;
			set;
		}
		public bool StartOver
		{
			get;
			set;
		}
		public bool CallOnStrategyStart
		{
			get;
			set;
		}
		protected Scenario()
		{
			this.ResetOnStart = true;
			this.StartOver = false;
		}
		public virtual void Run()
		{
			this.Start();
		}
		protected void Start(StrategyMode mode)
		{
			if (this.StartRequested != null)
			{
				this.StartRequested(mode, EventArgs.Empty);
			}
		}
		protected void Start()
		{
			this.Solution.OnStart();
			if (this.StartRequested != null)
			{
				this.StartRequested(null, EventArgs.Empty);
			}
		}
		protected void Stop(bool stopScenario)
		{
			if (stopScenario)
			{
				if (this.StopRequested != null)
				{
					this.StopRequested(null, EventArgs.Empty);
					return;
				}
			}
			else
			{
				Map.RequestStrategyStop(this);
			}
		}
		public void AddTimer(DateTime datetime, object data)
		{
			SmartQuant.Clock.AddReminder(new ReminderEventHandler(this.OnReminder), datetime, data);
		}
		public void RemoveTimer(DateTime datetime, object data)
		{
			SmartQuant.Clock.RemoveReminder(new ReminderEventHandler(this.OnReminder), datetime);
		}
		private void OnReminder(ReminderEventArgs args)
		{
			this.OnTimer(args.SignalTime, args.Data);
		}
		public virtual void OnTimer(DateTime datetime, object data)
		{
		}
	}
}
