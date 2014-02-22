using System;
namespace OpenQuant.API.Compression
{
	internal class VolumeBarCompressor : BarCompressor
	{
		protected override void Add(DataEntry entry)
		{
			if (this.bar == null)
			{
				base.CreateNewBar(BarType.Volume, entry.DateTime, entry.DateTime, entry.Items[0].Price);
			}
			base.AddItemsToBar(entry.Items);
			this.bar.bar.EndTime = entry.DateTime;
			if (this.bar.Volume >= this.newBarSize)
			{
				base.EmitNewCompressedBar();
				this.bar = null;
			}
		}
	}
}
