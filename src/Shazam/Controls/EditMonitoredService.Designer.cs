namespace Shazam.Controls
{
	partial class EditMonitoredService
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmbServiceName = new System.Windows.Forms.ComboBox();
			this.lblService = new System.Windows.Forms.Label();
			this.tbDisplayName = new System.Windows.Forms.TextBox();
			this.lblDisplayName = new System.Windows.Forms.Label();
			this.cbAutoStart = new System.Windows.Forms.CheckBox();
			this.cbAutoStop = new System.Windows.Forms.CheckBox();
			this.btnSaveService = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblEditServiceHeader = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmbServiceName
			// 
			this.cmbServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbServiceName.FormattingEnabled = true;
			this.cmbServiceName.Location = new System.Drawing.Point(83, 32);
			this.cmbServiceName.Name = "cmbServiceName";
			this.cmbServiceName.Size = new System.Drawing.Size(331, 21);
			this.cmbServiceName.TabIndex = 0;
			// 
			// lblService
			// 
			this.lblService.AutoSize = true;
			this.lblService.Location = new System.Drawing.Point(3, 35);
			this.lblService.Name = "lblService";
			this.lblService.Size = new System.Drawing.Size(74, 13);
			this.lblService.TabIndex = 1;
			this.lblService.Text = "Service Name";
			// 
			// tbDisplayName
			// 
			this.tbDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDisplayName.Location = new System.Drawing.Point(83, 64);
			this.tbDisplayName.Name = "tbDisplayName";
			this.tbDisplayName.Size = new System.Drawing.Size(331, 20);
			this.tbDisplayName.TabIndex = 2;
			// 
			// lblDisplayName
			// 
			this.lblDisplayName.AutoSize = true;
			this.lblDisplayName.Location = new System.Drawing.Point(5, 67);
			this.lblDisplayName.Name = "lblDisplayName";
			this.lblDisplayName.Size = new System.Drawing.Size(72, 13);
			this.lblDisplayName.TabIndex = 3;
			this.lblDisplayName.Text = "Display Name";
			// 
			// cbAutoStart
			// 
			this.cbAutoStart.AutoSize = true;
			this.cbAutoStart.Location = new System.Drawing.Point(83, 94);
			this.cbAutoStart.Name = "cbAutoStart";
			this.cbAutoStart.Size = new System.Drawing.Size(182, 17);
			this.cbAutoStart.TabIndex = 4;
			this.cbAutoStart.Text = "Start Automatically With Shazam!";
			this.cbAutoStart.UseVisualStyleBackColor = true;
			// 
			// cbAutoStop
			// 
			this.cbAutoStop.AutoSize = true;
			this.cbAutoStop.Location = new System.Drawing.Point(83, 122);
			this.cbAutoStop.Name = "cbAutoStop";
			this.cbAutoStop.Size = new System.Drawing.Size(182, 17);
			this.cbAutoStop.TabIndex = 5;
			this.cbAutoStop.Text = "Stop Automatically With Shazam!";
			this.cbAutoStop.UseVisualStyleBackColor = true;
			// 
			// btnSaveService
			// 
			this.btnSaveService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveService.Location = new System.Drawing.Point(208, 163);
			this.btnSaveService.Name = "btnSaveService";
			this.btnSaveService.Size = new System.Drawing.Size(100, 23);
			this.btnSaveService.TabIndex = 6;
			this.btnSaveService.Text = "Save";
			this.btnSaveService.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(314, 163);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// lblEditServiceHeader
			// 
			this.lblEditServiceHeader.AutoSize = true;
			this.lblEditServiceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEditServiceHeader.Location = new System.Drawing.Point(3, 9);
			this.lblEditServiceHeader.Name = "lblEditServiceHeader";
			this.lblEditServiceHeader.Size = new System.Drawing.Size(191, 20);
			this.lblEditServiceHeader.TabIndex = 8;
			this.lblEditServiceHeader.Text = "Add Service to Monitor";
			// 
			// EditMonitoredService
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.lblEditServiceHeader);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSaveService);
			this.Controls.Add(this.cbAutoStop);
			this.Controls.Add(this.cbAutoStart);
			this.Controls.Add(this.lblDisplayName);
			this.Controls.Add(this.tbDisplayName);
			this.Controls.Add(this.lblService);
			this.Controls.Add(this.cmbServiceName);
			this.Name = "EditMonitoredService";
			this.Size = new System.Drawing.Size(417, 189);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbServiceName;
		private System.Windows.Forms.Label lblService;
		private System.Windows.Forms.TextBox tbDisplayName;
		private System.Windows.Forms.Label lblDisplayName;
		private System.Windows.Forms.CheckBox cbAutoStart;
		private System.Windows.Forms.CheckBox cbAutoStop;
		private System.Windows.Forms.Button btnSaveService;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblEditServiceHeader;

	}
}
