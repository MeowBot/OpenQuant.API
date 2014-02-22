using OpenQuant.API.Design;
using SmartQuant.FIX;
using System;
using System.ComponentModel;
using System.Drawing.Design;
namespace OpenQuant.API
{
	public class AltIDGroup
	{
		internal FIXSecurityAltIDGroup group;
		private Instrument instrument;
		[Category("Appearance (alternative)"), Description("Instrument alternative symbol")]
		public string AltSymbol
		{
			get
			{
				return this.group.SecurityAltID;
			}
			set
			{
				this.group.SecurityAltID = value;
				this.instrument.instrument.Save();
			}
		}
		[Category("Appearance (alternative)"), Description("Alternative source of instrument definition (provider name)"), Editor(typeof(AltSourceTypeEditor), typeof(UITypeEditor))]
		public string AltSource
		{
			get
			{
				return this.group.SecurityAltIDSource;
			}
			set
			{
				this.group.SecurityAltIDSource = value;
				this.instrument.instrument.Save();
			}
		}
		[Category("Appearance (alternative)"), Description("Instrument alternative exchange")]
		public string AltExchange
		{
			get
			{
				return this.group.SecurityAltExchange;
			}
			set
			{
				this.group.SecurityAltExchange = value;
				this.instrument.instrument.Save();
			}
		}
		internal AltIDGroup(Instrument instrument, FIXSecurityAltIDGroup group)
		{
			this.group = group;
			this.instrument = instrument;
		}
		public override bool Equals(object obj)
		{
			AltIDGroup altIDGroup = obj as AltIDGroup;
			return altIDGroup != null && altIDGroup.group == this.group;
		}
		public override int GetHashCode()
		{
			return this.group.GetHashCode();
		}
		public override string ToString()
		{
			return this.AltSource;
		}
	}
}
