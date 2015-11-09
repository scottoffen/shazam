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
		private String SortBy { get; set; }
		private SortOrder SortOrder { get; set; }

		public ShazamViewer()
		{
			InitializeComponent();
			this.SortOrder = SortOrder.None;
			LoadDataGridView();
		}

		private List<MonitoredService> Services
		{
			get
			{
				if (ReferenceEquals(SortBy, null) || ReferenceEquals(SortBy, String.Empty)) SortBy = "DisplayName";

				List<MonitoredService> services;

				if (this.SortOrder == SortOrder.Descending)
				{
					services =
						MonitoredServices.GetInstance()
							.List.OrderByDescending(service => service.GetType().GetProperty(SortBy).GetValue(service, null))
							.ToList();
				}
				else
				{
					services = MonitoredServices.GetInstance()
						.List.OrderBy(service => service.GetType().GetProperty(SortBy).GetValue(service, null))
						.ToList();
				}

				return services;
			}
		}

		private DataTable DataTable {
			get
			{
				var datatable = new DataTable
				{
					Columns =
					{
						{"Display Name"},
						{"Service Name"},
						{"Status"},
						{"Auto Start"},
						{"Auto Stop"}
					}
				};

				Services.ForEach(service =>
				{
					datatable.Rows.Add(service.DisplayName, service.ServiceName, service.Status, service.AutoStart, service.AutoStop);
				});

				return datatable;
			}
		}

		private void LoadDataGridView()
		{
			dgvServices.DataSource = DataTable;
			dgvServices.AllowUserToResizeColumns = false;
			dgvServices.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void dgvServices_Sorted(object sender, EventArgs e)
		{
			SortBy = dgvServices.SortedColumn.HeaderText.Replace(" ", "");
			this.SortOrder = dgvServices.SortOrder;
		}

		private void btnRemoveService_Click(object sender, EventArgs e)
		{
			MessageBox.Show(dgvServices.SelectedRows.Count.ToString());
		}

		private void btnAddService_Click(object sender, EventArgs e)
		{

		}

		private void ShazamViewer_Shown(object sender, EventArgs e)
		{
			dgvServices.CurrentCell.Selected = false;
			btnEditService.Enabled = false;
		}

		private void dgvServices_SelectionChanged(object sender, EventArgs e)
		{
			btnEditService.Enabled = true;
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
