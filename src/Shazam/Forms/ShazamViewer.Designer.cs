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
			this.dgvServices = new System.Windows.Forms.DataGridView();
			this.btnAddService = new System.Windows.Forms.Button();
			this.btnRemoveService = new System.Windows.Forms.Button();
			this.btnEditService = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvServices
			// 
			this.dgvServices.AllowUserToAddRows = false;
			this.dgvServices.AllowUserToDeleteRows = false;
			this.dgvServices.AllowUserToResizeRows = false;
			this.dgvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvServices.Location = new System.Drawing.Point(12, 12);
			this.dgvServices.MultiSelect = false;
			this.dgvServices.Name = "dgvServices";
			this.dgvServices.ReadOnly = true;
			this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvServices.Size = new System.Drawing.Size(600, 269);
			this.dgvServices.TabIndex = 0;
			this.dgvServices.SelectionChanged += new System.EventHandler(this.dgvServices_SelectionChanged);
			this.dgvServices.Sorted += new System.EventHandler(this.dgvServices_Sorted);
			// 
			// btnAddService
			// 
			this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddService.Location = new System.Drawing.Point(411, 287);
			this.btnAddService.Name = "btnAddService";
			this.btnAddService.Size = new System.Drawing.Size(100, 23);
			this.btnAddService.TabIndex = 1;
			this.btnAddService.Text = "Add Service";
			this.btnAddService.UseVisualStyleBackColor = true;
			this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
			// 
			// btnRemoveService
			// 
			this.btnRemoveService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveService.Location = new System.Drawing.Point(517, 287);
			this.btnRemoveService.Name = "btnRemoveService";
			this.btnRemoveService.Size = new System.Drawing.Size(100, 23);
			this.btnRemoveService.TabIndex = 2;
			this.btnRemoveService.Text = "Remove Service";
			this.btnRemoveService.UseVisualStyleBackColor = true;
			this.btnRemoveService.Click += new System.EventHandler(this.btnRemoveService_Click);
			// 
			// btnEditService
			// 
			this.btnEditService.Enabled = false;
			this.btnEditService.Location = new System.Drawing.Point(12, 287);
			this.btnEditService.Name = "btnEditService";
			this.btnEditService.Size = new System.Drawing.Size(100, 23);
			this.btnEditService.TabIndex = 3;
			this.btnEditService.Text = "Edit Service";
			this.btnEditService.UseVisualStyleBackColor = true;
			// 
			// ShazamViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 322);
			this.Controls.Add(this.btnEditService);
			this.Controls.Add(this.btnRemoveService);
			this.Controls.Add(this.btnAddService);
			this.Controls.Add(this.dgvServices);
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
			((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvServices;
		private System.Windows.Forms.Button btnAddService;
		private System.Windows.Forms.Button btnRemoveService;
		private System.Windows.Forms.Button btnEditService;
	}
}