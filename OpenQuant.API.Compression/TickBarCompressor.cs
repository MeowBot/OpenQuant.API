using System;
namespace OpenQuant.API.Compression
{
	internal class TickBarCompressor : BarCompressor
	{
		private long tickCount;
		public TickBarCompressor()
		{
			this.tickCount = 0L;
		}
		protected override void Add(DataEntry entry)
		{
			if (this.bar == null)
			{
				base.CreateNewBar(BarType.Tick, entry.DateTime, entry.DateTime, entry.Items[0].Price);
			}
			base.AddItemsToBar(entry.Items);
			this.bar.bar.EndTime = entry.DateTime;
			this.tickCount += this.oldBarSize;
			if (this.tickCount == this.newBarSize)
			{
				base.EmitNewCompressedBar();
				this.bar = null;
				this.tickCount = 0L;
			}
		}
	}
}
