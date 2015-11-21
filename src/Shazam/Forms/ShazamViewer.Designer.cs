namespace Shazam.Forms
{
	partial class ShazamViewer
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
			this.listMonitoredService1 = new Shazam.Controls.ListMonitoredService();
			this.editMonitoredService1 = new Shazam.Controls.EditMonitoredService();
			this.SuspendLayout();
			// 
			// listMonitoredService1
			// 
			this.listMonitoredService1.AutoSize = true;
			this.listMonitoredService1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMonitoredService1.Location = new System.Drawing.Point(0, 0);
			this.listMonitoredService1.Margin = new System.Windows.Forms.Padding(0);
			this.listMonitoredService1.Name = "listMonitoredService1";
			this.listMonitoredService1.Size = new System.Drawing.Size(624, 322);
			this.listMonitoredService1.TabIndex = 0;
			// 
			// editMonitoredService1
			// 
			this.editMonitoredService1.AutoSize = true;
			this.editMonitoredService1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editMonitoredService1.Location = new System.Drawing.Point(0, 0);
			this.editMonitoredService1.Margin = new System.Windows.Forms.Padding(0);
			this.editMonitoredService1.Name = "editMonitoredService1";
			this.editMonitoredService1.Size = new System.Drawing.Size(624, 322);
			this.editMonitoredService1.TabIndex = 1;
			// 
			// ShazamViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 322);
			this.Controls.Add(this.editMonitoredService1);
			this.Controls.Add(this.listMonitoredService1);
			this.Icon = global::Shazam.Properties.Resources.shazam;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(640, 360);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(640, 360);
			this.Name = "ShazamViewer";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shazam!";
			this.Shown += new System.EventHandler(this.ShazamViewer_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShazamViewer_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.ListMonitoredService listMonitoredService1;
		private Controls.EditMonitoredService editMonitoredService1;




	}
}