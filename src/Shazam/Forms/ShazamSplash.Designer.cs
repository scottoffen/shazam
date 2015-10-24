namespace Shazam.Forms
{
	partial class ShazamSplash
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pbAutoStart = new System.Windows.Forms.ProgressBar();
			this.lbProgress = new System.Windows.Forms.Label();
			this.workerAutoStart = new System.ComponentModel.BackgroundWorker();
			this.timerCompletion = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// pbAutoStart
			// 
			this.pbAutoStart.Location = new System.Drawing.Point(140, 424);
			this.pbAutoStart.Name = "pbAutoStart";
			this.pbAutoStart.Size = new System.Drawing.Size(520, 14);
			this.pbAutoStart.TabIndex = 0;
			// 
			// lbProgress
			// 
			this.lbProgress.AutoSize = true;
			this.lbProgress.BackColor = System.Drawing.Color.Transparent;
			this.lbProgress.Location = new System.Drawing.Point(137, 408);
			this.lbProgress.Name = "lbProgress";
			this.lbProgress.Size = new System.Drawing.Size(61, 13);
			this.lbProgress.TabIndex = 1;
			this.lbProgress.Text = "Initializing...";
			// 
			// workerAutoStart
			// 
			this.workerAutoStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerAutoStart_DoWork);
			this.workerAutoStart.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerAutoStart_ProgressChanged);
			this.workerAutoStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerAutoStart_RunWorkerCompleted);
			// 
			// timerCompletion
			// 
			this.timerCompletion.Tick += new System.EventHandler(this.timerCompletion_Tick);
			// 
			// ShazamSplash
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Shazam.Properties.Resources.banner;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lbProgress);
			this.Controls.Add(this.pbAutoStart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ShazamSplash";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ShazamSplash";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar pbAutoStart;
		private System.Windows.Forms.Label lbProgress;
		private System.ComponentModel.BackgroundWorker workerAutoStart;
		private System.Windows.Forms.Timer timerCompletion;
	}
}