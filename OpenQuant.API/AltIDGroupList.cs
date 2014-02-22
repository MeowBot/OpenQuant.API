using SmartQuant.FIX;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class AltIDGroupList : IEnumerable
	{
		internal Instrument instrument;
		public AltIDGroup this[string altSource]
		{
			get
			{
				foreach (FIXSecurityAltIDGroup fIXSecurityAltIDGroup in this.instrument.instrument.SecurityAltIDGroup)
				{
					if (fIXSecurityAltIDGroup.SecurityAltIDSource == altSource)
					{
						return new AltIDGroup(this.instrument, fIXSecurityAltIDGroup);
					}
				}
				return null;
			}
		}
		public int Count
		{
			get
			{
				return this.instrument.instrument.SecurityAltIDGroup.Count;
			}
		}
		internal AltIDGroupList(Instrument instrument)
		{
			this.instrument = instrument;
		}
		public AltIDGroup Add(string altSource)
		{
			foreach (FIXSecurityAltIDGroup fIXSecurityAltIDGroup in this.instrument.instrument.SecurityAltIDGroup)
			{
				if (fIXSecurityAltIDGroup.SecurityAltIDSource == altSource)
				{
					return new AltIDGroup(this.instrument, fIXSecurityAltIDGroup);
				}
			}
			FIXSecurityAltIDGroup fIXSecurityAltIDGroup2 = new FIXSecurityAltIDGroup();
			fIXSecurityAltIDGroup2.SecurityAltIDSource = altSource;
			this.instrument.instrument.SecurityAltIDGroup.Add(fIXSecurityAltIDGroup2);
			return new AltIDGroup(this.instrument, fIXSecurityAltIDGroup2);
		}
		public void Remove(string altSource)
		{
			foreach (FIXSecurityAltIDGroup fIXSecurityAltIDGroup in this.instrument.instrument.SecurityAltIDGroup)
			{
				if (fIXSecurityAltIDGroup.SecurityAltIDSource == altSource)
				{
					this.instrument.instrument.SecurityAltIDGroup.Remove(fIXSecurityAltIDGroup);
					break;
				}
			}
		}
		public bool Contains(string altSource)
		{
			return this[altSource] != null;
		}
		public IEnumerator GetEnumerator()
		{
			foreach (FIXSecurityAltIDGroup group in this.instrument.instrument.SecurityAltIDGroup)
			{
				yield return new AltIDGroup(this.instrument, group);
			}
			yield break;
		}
	}
}
