﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eto.Forms;
using mw = Microsoft.Win32;
using sw = System.Windows;

namespace Eto.Platform.Wpf.Forms
{
	public class OpenFileDialogHandler : WpfFileDialog<mw.OpenFileDialog, OpenFileDialog>, IOpenFileDialog
	{
		public OpenFileDialogHandler ()
		{
			Control = new mw.OpenFileDialog ();
		}
	}
}
