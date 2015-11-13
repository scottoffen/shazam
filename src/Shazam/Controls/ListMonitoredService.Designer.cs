namespace Shazam.Controls
{
	partial class ListMonitoredService
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
			this.dgvServices = new System.Windows.Forms.DataGridView();
			this.btnRemoveService = new System.Windows.Forms.Button();
			this.btnEditService = new System.Windows.Forms.Button();
			this.btnAddService = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvServices
			// 
			this.dgvServices.AllowUserToAddRows = false;
			this.dgvServices.AllowUserToDeleteRows = false;
			this.dgvServices.AllowUserToResizeColumns = false;
			this.dgvServices.AllowUserToResizeRows = false;
			this.dgvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvServices.Location = new System.Drawing.Point(0, 0);
			this.dgvServices.Name = "dgvServices";
			this.dgvServices.ReadOnly = true;
			this.dgvServices.Size = new System.Drawing.Size(632, 397);
			this.dgvServices.TabIndex = 0;
			this.dgvServices.SelectionChanged += new System.EventHandler(this.dgvServices_SelectionChanged);
			this.dgvServices.Sorted += new System.EventHandler(this.dgvServices_Sorted);
			// 
			// btnRemoveService
			// 
			this.btnRemoveService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveService.Enabled = false;
			this.btnRemoveService.Location = new System.Drawing.Point(533, 407);
			this.btnRemoveService.Name = "btnRemoveService";
			this.btnRemoveService.Size = new System.Drawing.Size(100, 23);
			this.btnRemoveService.TabIndex = 1;
			this.btnRemoveService.Text = "Remove Service";
			this.btnRemoveService.UseVisualStyleBackColor = true;
			this.btnRemoveService.Click += new System.EventHandler(this.btnRemoveService_Click);
			// 
			// btnEditService
			// 
			this.btnEditService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditService.Enabled = false;
			this.btnEditService.Location = new System.Drawing.Point(423, 407);
			this.btnEditService.Name = "btnEditService";
			this.btnEditService.Size = new System.Drawing.Size(100, 23);
			this.btnEditService.TabIndex = 2;
			this.btnEditService.Text = "Edit Service";
			this.btnEditService.UseVisualStyleBackColor = true;
			this.btnEditService.Click += new System.EventHandler(this.btnEditService_Click);
			// 
			// btnAddService
			// 
			this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddService.Location = new System.Drawing.Point(-1, 407);
			this.btnAddService.Name = "btnAddService";
			this.btnAddService.Size = new System.Drawing.Size(100, 23);
			this.btnAddService.TabIndex = 3;
			this.btnAddService.Text = "Add Service";
			this.btnAddService.UseVisualStyleBackColor = true;
			this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
			// 
			// ListMonitoredService
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnAddService);
			this.Controls.Add(this.btnEditService);
			this.Controls.Add(this.btnRemoveService);
			this.Controls.Add(this.dgvServices);
			this.Name = "ListMonitoredService";
			this.Size = new System.Drawing.Size(632, 429);
			((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Button btnRemoveService;
        private System.Windows.Forms.Button btnEditService;
        private System.Windows.Forms.Button btnAddService;

    }
}
