using System;
using Eto.Forms;
using Eto.Drawing;
using sw = System.Windows;
using swc = System.Windows.Controls;
using System.ComponentModel;

namespace Eto.Wpf.Forms.Controls
{
	public class ExpanderHandler : WpfPanel<swc.Expander, Expander, Expander.ICallback>, Expander.IHandler
	{
		public ExpanderHandler()
		{
			Control = new swc.Expander();
		}

		static DependencyPropertyDescriptor dpdIsExpanded = DependencyPropertyDescriptor.FromProperty(swc.Expander.IsExpandedProperty, typeof(swc.Expander));

		public bool Expanded
		{
			get { return Control.IsExpanded; }
			set { Control.IsExpanded = value; }
		}

		static readonly object Header_Key = new object();

		public Control Header
		{
			get { return Widget.Properties.Get<Control>(Header_Key); }
			set
			{
				Widget.Properties.Set(Header_Key, value, () => Control.Header = value.ToNative());
			}
		}

		public override void SetContainerContent(sw.FrameworkElement content)
		{
			Control.Content = content;
		}

		public override Color BackgroundColor
		{
			get { return Control.Background.ToEtoColor(); }
			set { Control.Background = value.ToWpfBrush(); }
		}

		public override void AttachEvent(string id)
		{
			switch (id)
			{
				case Expander.ExpandedChangedEvent:
					dpdIsExpanded.AddValueChanged(Control, (sender, e) => Callback.OnExpandedChanged(Widget, EventArgs.Empty));
					break;
				default:
					base.AttachEvent(id);
					break;
			}
		}

	}
}
