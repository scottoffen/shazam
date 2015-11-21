using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using Shazam.Models;

namespace Shazam.Controls
{
	public partial class EditMonitoredService : UserControl
	{
		private MonitoredService _service;

		public EditMonitoredService()
		{
			InitializeComponent();
			LoadServicesList();
		}

		private void LoadServicesList()
		{
			List<ServiceData> services = new List<ServiceData>();
			ServiceController.GetServices().ToList().ForEach(service =>
			{
				services.Add(new ServiceData
				{
					ServiceName = service.ServiceName,
					DisplayName = service.DisplayName
				});
			});
			services.OrderBy(service => service.ServiceName);

			cmbServiceName.DataSource = services;
			cmbServiceName.DisplayMember = "CombinedName";
			cmbServiceName.ValueMember = "ServiceName";
		}

		internal void SetService(MonitoredService service)
		{
			_service = service;

		}

		internal void RemoveService()
		{
			
		}
	}

	internal class ServiceData
	{
		public String ServiceName { get; set; }
		public String DisplayName { get; set; }

		public String CombinedName
		{
			get { return String.Format("{0} ({1})", DisplayName, ServiceName); }
		}
	}
}
