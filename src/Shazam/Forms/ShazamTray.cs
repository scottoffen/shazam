using System;
using System.Windows.Forms;
using Shazam.Models;

namespace Shazam.Forms
{
	internal class ShazamTray : Form
	{
		private NotifyIcon _icon;
		private ContextMenu _menu;
		private ShazamViewer _viewer;

		public ShazamTray()
		{
			NotifyIcon.Visible = true;
			(new ShazamSplash()).Start();
		}

		internal NotifyIcon NotifyIcon
		{
			get
			{
				if (_icon == null)
				{
					_icon = new NotifyIcon();
					_icon.Text = "Shazam";
					_icon.Icon = Properties.Resources.shazam;
					_icon.ContextMenu = NotifyIconMenu;
					_icon.MouseDoubleClick += HandleIconDblClick;
					_icon.ShowBalloonTip(5000, "Shazam", "Manage system services", ToolTipIcon.None);
				}

				return _icon;
			}
		}

		internal ContextMenu NotifyIconMenu
		{
			get
			{
				if (_menu == null)
				{
					_menu = new ContextMenu();
					_menu.MenuItems.Add("Restore", HandleMenuClick);
					_menu.MenuItems.Add("About", HandleMenuClick);
					_menu.MenuItems.Add("Exit", HandleMenuClick);
				}

				return _menu;
			}
		}

		internal bool ViewerIsReady
		{
			get { return (_viewer != null && !_viewer.IsDisposed); }
		}

		internal ShazamViewer Viewer
		{
			get
			{
				if (!ViewerIsReady)
				{
					_viewer = new ShazamViewer();
				}

				return _viewer;
			}
		}

		protected void ShowViewer()
		{
			if (Viewer.WindowState == FormWindowState.Minimized)
			{
				Viewer.WindowState = FormWindowState.Normal;
			}
			else
			{
				Viewer.Show();
			}
		}

		protected bool HideViewer()
		{
			if (ViewerIsReady)
			{
				Viewer.Hide();
				return true;
			}
			return false;
		}

		protected void ShowAbout()
		{
			var showMainScreenAfterClose = HideViewer();
			using (var box = new ShazamAbout())
			{
				box.ShowDialog(this);
			}
			if (showMainScreenAfterClose)
			{
				ShowViewer();
			}
		}

		protected void HandleIconDblClick (object sender, MouseEventArgs e)
		{
			ShowViewer();
		}

		protected void HandleMenuClick(object sender, EventArgs e)
		{
			var item = (MenuItem) sender;

			switch (item.Text)
			{
				case "Restore":
					ShowViewer();
					break;
				case "About":
					ShowAbout();
					break;
				default:
					_viewer.Close();
					MonitoredServices.GetInstance().AutoStop();
					Application.Exit();
					break;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			this.Visible = false;
			this.ShowInTaskbar = false;
			base.OnLoad(e);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_viewer.Dispose();
				_menu.Dispose();
				_icon.Dispose();
				MonitoredServices.GetInstance().AutoStop();
			}

			base.Dispose(disposing);
		}
	}
}
