using SmartQuant.Instruments;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class PositionList : IEnumerable
	{
		private SmartQuant.Instruments.PositionList positionList;
		public int Count
		{
			get
			{
				return this.positionList.Count;
			}
		}
		public Position this[string symbol]
		{
			get
			{
				SmartQuant.Instruments.Position position = this.positionList[symbol];
				if (position != null)
				{
					return new Position(position);
				}
				return null;
			}
		}
		public Position this[Instrument instrument]
		{
			get
			{
				SmartQuant.Instruments.Position position = this.positionList[instrument.instrument];
				if (position != null)
				{
					return new Position(position);
				}
				return null;
			}
		}
		internal PositionList(SmartQuant.Instruments.PositionList positionList)
		{
			this.positionList = positionList;
		}
		public IEnumerator GetEnumerator()
		{
			return new PositionListEnumerator(this.positionList);
		}
	}
}
