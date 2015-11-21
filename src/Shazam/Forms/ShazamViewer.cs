using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shazam.Models;

namespace Shazam.Forms
{
	public partial class ShazamViewer : Form
	{
		public ShazamViewer()
		{
			InitializeComponent();
		}

		private void btnRemoveService_Click(object sender, EventArgs e)
		{

		}

		private void btnAddService_Click(object sender, EventArgs e)
		{

		}

		private void ShazamViewer_Shown(object sender, EventArgs e)
		{
		}

		private void ShazamViewer_KeyDown(object sender, KeyEventArgs e)
		{
			// Right now this just closes the form, but if you are on the edit screen, you should just go back to the list view
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
			else
			{
				MessageBox.Show(String.Format("{0} != {1}", e.KeyCode, Keys.Escape));
			}
		}
	}
}
