using System;
using System.ComponentModel;
using System.Globalization;
namespace OpenQuant.API.Design
{
	internal class AltIDGroupTypeConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (!(destinationType == typeof(string)) || !(value is AltIDGroup))
			{
				return base.ConvertTo(context, culture, value, destinationType);
			}
			AltIDGroup altIDGroup = (AltIDGroup)value;
			if (string.IsNullOrWhiteSpace(altIDGroup.AltExchange) && string.IsNullOrWhiteSpace(altIDGroup.AltSymbol))
			{
				return string.Empty;
			}
			return string.Format("{0}@{1}", altIDGroup.AltSymbol, altIDGroup.AltExchange);
		}
	}
}
