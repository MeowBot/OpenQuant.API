using SmartQuant.Trading;
using System;
namespace OpenQuant.API
{
	public class Stop
	{
		internal ATSStop stop;
		private Position position;
		public Instrument Instrument
		{
			get
			{
				return this.position.Instrument;
			}
		}
		public double FillPrice
		{
			get
			{
				return this.stop.FillPrice;
			}
		}
		public double StopPrice
		{
			get
			{
				return this.stop.StopPrice;
			}
		}
		public double Level
		{
			get
			{
				return this.stop.Level;
			}
		}
		public StopType Type
		{
			get
			{
				return EnumConverter.Convert(this.stop.Type);
			}
		}
		public StopMode Mode
		{
			get
			{
				return EnumConverter.Convert(this.stop.Mode);
			}
		}
		public StopStatus Status
		{
			get
			{
				return EnumConverter.Convert(this.stop.Status);
			}
		}
		public bool TraceOnBar
		{
			get
			{
				return this.stop.TraceOnBar;
			}
			set
			{
				this.stop.TraceOnBar = value;
			}
		}
		public bool TraceOnTrade
		{
			get
			{
				return this.stop.TraceOnTrade;
			}
			set
			{
				this.stop.TraceOnTrade = value;
			}
		}
		public bool TraceOnQuote
		{
			get
			{
				return this.stop.TraceOnQuote;
			}
			set
			{
				this.stop.TraceOnQuote = value;
			}
		}
		public DateTime CreationTime
		{
			get
			{
				return this.stop.CreationTime;
			}
		}
		public DateTime CompletionTime
		{
			get
			{
				return this.stop.CompletionTime;
			}
		}
		public void SetBarFilter(long barSize, BarType barType)
		{
			this.stop.SetBarFilter(barSize, EnumConverter.Convert(barType));
		}
		public void SetBarFilter(long barSize)
		{
			this.SetBarFilter(barSize, BarType.Time);
		}
		internal Stop(Position position, DateTime dateTime)
		{
			this.position = position;
			this.stop = new ATSStop(position.position, dateTime);
			this.stop.TrailOnHighLow = true;
			this.stop.TraceOnBarOpen = true;
			this.stop.TraceOnBar = true;
			this.stop.TraceOnQuote = true;
			this.stop.TraceOnTrade = true;
		}
		internal Stop(Position position, double level, StopType type, StopMode mode)
		{
			this.position = position;
			SmartQuant.Trading.StopType type2 = EnumConverter.Convert(type);
			SmartQuant.Trading.StopMode mode2 = EnumConverter.Convert(mode);
			this.stop = new ATSStop(position.position, level, type2, mode2);
			this.stop.TrailOnHighLow = true;
			this.stop.TraceOnBarOpen = true;
			this.stop.TraceOnBar = true;
			this.stop.TraceOnQuote = true;
			this.stop.TraceOnTrade = true;
		}
		public void Cancel()
		{
			this.stop.Cancel();
		}
		private void stop_StatusChanged(StopEventArgs args)
		{
		}
		public void Disconnect()
		{
			this.stop.Disconnect();
		}
	}
}
