using System;
using System.ComponentModel;
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
			workerAutoStart.RunWorkerAsync();
		}

		private void workerAutoStart_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			worker.ReportProgress(Progress);

			var services = MonitoredServices.GetInstance();
			var progressPerService = services.CountAutoStart/100;
			Progress = services.CountAutoStart%100;

			services.List.ForEach(service =>
			{
				if (service.AutoStart)
				{
					Phase = String.Format("Starting {0} service", service.DisplayName);
					worker.ReportProgress(Progress);
					service.Start();
					Progress += progressPerService;
				}
			});

			Progress = 100;
			Phase = "Completed";
			worker.ReportProgress(Progress);
		}

		private void workerAutoStart_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbAutoStart.Value = Progress;
			lbProgress.Text = Phase;
		}

		private void workerAutoStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message, "Service AutoStart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			pbAutoStart.Update();
			pbAutoStart.Refresh();

			timerCompletion.Enabled = true;
		}

		private void timerCompletion_Tick(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
	}
}
