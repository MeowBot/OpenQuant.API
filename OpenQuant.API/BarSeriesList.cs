using OpenQuant.ObjectMap;
using SmartQuant.Instruments;
using System;
namespace OpenQuant.API
{
	public class BarSeriesList
	{
		public BarSeries this[Instrument instrument, BarType barType, long barSize]
		{
			get
			{
				SmartQuant.Instruments.Instrument instrument2 = Map.OQ_SQ_Instrument[instrument] as SmartQuant.Instruments.Instrument;
				return new BarSeries(SmartQuant.Instruments.DataManager.Bars[instrument2, EnumConverter.Convert(barType), barSize]);
			}
		}
		public BarSeries this[Instrument instrument]
		{
			get
			{
				SmartQuant.Instruments.Instrument instrument2 = Map.OQ_SQ_Instrument[instrument] as SmartQuant.Instruments.Instrument;
				return new BarSeries(SmartQuant.Instruments.DataManager.Bars[instrument2]);
			}
		}
	}
}
