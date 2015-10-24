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
	public partial class ShazamSplash : Form
	{
		private int Progress { get; set; }
		private string Phase { get; set; }

		public ShazamSplash()
		{
			InitializeComponent();

			Progress = 0;
			Phase = "Initializing...";

			workerAutoStart.WorkerReportsProgress = true;
			workerAutoStart.WorkerSupportsCancellation = true;
		}

		public void Start()
		{
			this.Show();

			MonitoredServices.GetInstance().AutoStartingDelegate = new AutoStartingDelegate(ServiceAutoStarting);
			MonitoredServices.GetInstance().AutoStartedDelegate = new AutoStartedDelegate(ServiceAutoStarted);

			workerAutoStart.RunWorkerAsync();
		}

		private void workerAutoStart_DoWork(object sender, DoWorkEventArgs e)
		{

		}

		private void workerAutoStart_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{

		}

		private void workerAutoStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message, "Service AutoStart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			MonitoredServices.GetInstance().AutoStartingDelegate = null;
			MonitoredServices.GetInstance().AutoStartedDelegate = null;

			pbAutoStart.Update();
			pbAutoStart.Refresh();

			timerCompletion.Enabled = true;
		}

		private void timerCompletion_Tick(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private void ServiceAutoStarting (MonitoredService service)
		{

		}

		private void ServiceAutoStarted (MonitoredService service)
		{

		}
	}
}
