using SmartQuant.Providers;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
namespace OpenQuant.API.Design
{
	internal class AltSourceTypeEditor : ObjectSelectorEditor
	{
		public override bool IsDropDownResizable
		{
			get
			{
				return true;
			}
		}
		protected override void FillTreeWithData(ObjectSelectorEditor.Selector selector, ITypeDescriptorContext context, IServiceProvider provider)
		{
			if (context != null && context.Instance != null)
			{
				AltIDGroup altIDGroup = (AltIDGroup)context.Instance;
				selector.Clear();
				foreach (IProvider provider2 in SmartQuant.Providers.ProviderManager.Providers)
				{
					selector.AddNode(provider2.Name, provider2.Name, null);
				}
				selector.Sort();
				foreach (ObjectSelectorEditor.SelectorNode selectorNode in selector.Nodes)
				{
					if (selectorNode.value.Equals(altIDGroup.AltSource))
					{
						selector.SelectedNode = selectorNode;
						break;
					}
				}
				selector.Width = 144;
				return;
			}
			base.FillTreeWithData(selector, context, provider);
		}
	}
}
