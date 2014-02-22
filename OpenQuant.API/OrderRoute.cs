using System;
namespace OpenQuant.API
{
	[Obsolete("Use global::OpenQuant.API.Route class instead")]
	public static class OrderRoute
	{
		public const byte Simulator = 2;
		public const byte IB = 4;
		public const byte TTFIX = 10;
		public const byte Hotspot = 26;
		public const byte Currenex = 28;
		public const byte QUIKFIX = 31;
		public const byte OSLFIX = 32;
		public const byte Nordnet = 33;
		public const byte Integral = 35;
		public const byte Finam = 117;
	}
}
