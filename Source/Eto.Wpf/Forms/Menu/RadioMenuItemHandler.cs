using System;
using System.Collections.Generic;
using Eto.Forms;
using swc = System.Windows.Controls;
using swm = System.Windows.Media;
using swi = System.Windows.Input;
using System.Linq;
using System.ComponentModel;

namespace Eto.Wpf.Forms.Menu
{
	public class RadioMenuItemHandler : MenuItemHandler<swc.MenuItem, RadioMenuItem, RadioMenuItem.ICallback>, RadioMenuItem.IHandler
	{
		List<RadioMenuItem> group;

		public RadioMenuItemHandler()
		{
			Control = new swc.MenuItem
			{
				IsCheckable = true
			};
		}

		protected override void OnClick()
		{
			if (group != null)
			{
				var checkedItem = group.FirstOrDefault(r => r.Checked && r != Widget);
				if (checkedItem != null)
					checkedItem.Checked = false;
			}
			Checked = true;
			base.OnClick();
		}


		public bool Checked
		{
			get { return Control.IsChecked; }
			set { Control.IsChecked = value; }
		}

		public void Create(RadioMenuItem controller)
		{
			if (controller != null)
			{
				var controllerInner = (RadioMenuItemHandler)controller.Handler;
				if (controllerInner.group == null)
				{
					controllerInner.group = new List<RadioMenuItem>();
					controllerInner.group.Add(controller);
				}
				group = controllerInner.group;
				group.Add(Widget);
			}
		}

		static DependencyPropertyDescriptor dpdIsChecked = DependencyPropertyDescriptor.FromProperty(swc.MenuItem.IsCheckedProperty, typeof(swc.MenuItem));

		public override void AttachEvent(string id)
		{
			switch (id)
			{
				case RadioMenuItem.CheckedChangedEvent:
					dpdIsChecked.AddValueChanged(Control, (sender, e) => Callback.OnCheckedChanged(Widget, EventArgs.Empty));
					break;
				default:
					base.AttachEvent(id);
					break;
			}
		}
	}
}
