using System;
using System.ComponentModel;
using System.Globalization;
namespace OpenQuant.API.Design
{
	internal class AltIDGroupListTypeConverter : ArrayConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is AltIDGroupList && destinationType == typeof(string))
			{
				return string.Format("{0} Alt Group(s)", ((AltIDGroupList)value).Count);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			AltIDGroupList altIDGroupList = (AltIDGroupList)value;
			int num = 0;
			foreach (AltIDGroup group in altIDGroupList)
			{
				AltIDGroupPropertyDescriptor value2 = new AltIDGroupPropertyDescriptor(group, num++);
				propertyDescriptorCollection.Add(value2);
			}
			return propertyDescriptorCollection;
		}
	}
}
