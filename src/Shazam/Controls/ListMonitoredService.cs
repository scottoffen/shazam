using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Shazam.Models;

namespace Shazam.Controls
{
	public partial class ListMonitoredService : UserControl
	{
		private String SortBy { get; set; }
		private SortOrder SortOrder { get; set; }
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
		private DataTable DataTable
		{
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

		public ListMonitoredService()
		{
			InitializeComponent();
			this.SortOrder = SortOrder.None;
			LoadDataGridView();
		}

		private void LoadDataGridView()
		{
			dgvServices.DataSource = DataTable;
			dgvServices.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void dgvServices_Sorted(object sender, EventArgs e)
		{
			SortBy = dgvServices.SortedColumn.HeaderText.Replace(" ", "");
			this.SortOrder = dgvServices.SortOrder;
		}

		private void dgvServices_SelectionChanged(object sender, EventArgs e)
		{
			var enabledState = (dgvServices.SelectedRows.Count > 0);
			btnEditService.Enabled = enabledState;
			btnRemoveService.Enabled = enabledState;
		}

		private void btnAddService_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Add Service");
		}

		private void btnEditService_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Edit Service");
		}

		private void btnRemoveService_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Remove Service");
		}
	}
}