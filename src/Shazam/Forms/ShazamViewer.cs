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
	}
}
