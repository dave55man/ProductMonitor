namespace Trek.ProductMonitor.View.View
{
    partial class ProductMaster
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
            this.VendorBox = new System.Windows.Forms.ListBox();
            this.ProductUpdateLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.VendorLabel = new System.Windows.Forms.Label();
            this.ProductUpdateGrid = new System.Windows.Forms.DataGridView();
            this.productUpdateModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendorProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ProductUpdateGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productUpdateModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorProductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // VendorBox
            // 
            this.VendorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VendorBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorBox.FormattingEnabled = true;
            this.VendorBox.ItemHeight = 20;
            this.VendorBox.Location = new System.Drawing.Point(12, 30);
            this.VendorBox.Name = "VendorBox";
            this.VendorBox.Size = new System.Drawing.Size(373, 344);
            this.VendorBox.TabIndex = 0;
            this.VendorBox.SelectedIndexChanged += new System.EventHandler(this.VendorBox_SelectedIndexChanged);
            // 
            // ProductUpdateLabel
            // 
            this.ProductUpdateLabel.AutoSize = true;
            this.ProductUpdateLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductUpdateLabel.Location = new System.Drawing.Point(399, 9);
            this.ProductUpdateLabel.Name = "ProductUpdateLabel";
            this.ProductUpdateLabel.Size = new System.Drawing.Size(148, 18);
            this.ProductUpdateLabel.TabIndex = 4;
            this.ProductUpdateLabel.Text = "Product Updates";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(983, 475);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(902, 475);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // VendorLabel
            // 
            this.VendorLabel.AutoSize = true;
            this.VendorLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorLabel.Location = new System.Drawing.Point(12, 9);
            this.VendorLabel.Name = "VendorLabel";
            this.VendorLabel.Size = new System.Drawing.Size(77, 18);
            this.VendorLabel.TabIndex = 7;
            this.VendorLabel.Text = "Vendors";
            // 
            // ProductUpdateGrid
            // 
            this.ProductUpdateGrid.AllowUserToAddRows = false;
            this.ProductUpdateGrid.AllowUserToDeleteRows = false;
            this.ProductUpdateGrid.AllowUserToResizeColumns = false;
            this.ProductUpdateGrid.AllowUserToResizeRows = false;
            this.ProductUpdateGrid.AutoGenerateColumns = false;
            this.ProductUpdateGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ProductUpdateGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductUpdateGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vendor,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.ProductUpdateGrid.DataSource = this.productUpdateModelBindingSource;
            this.ProductUpdateGrid.Location = new System.Drawing.Point(402, 30);
            this.ProductUpdateGrid.Name = "ProductUpdateGrid";
            this.ProductUpdateGrid.ReadOnly = true;
            this.ProductUpdateGrid.RowHeadersVisible = false;
            this.ProductUpdateGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductUpdateGrid.Size = new System.Drawing.Size(656, 439);
            this.ProductUpdateGrid.TabIndex = 8;
            // 
            // productUpdateModelBindingSource
            // 
            this.productUpdateModelBindingSource.DataSource = typeof(Trek.ProductMonitor.View.Model.ProductUpdateModel);
            // 
            // vendorBindingSource
            // 
            this.vendorBindingSource.DataSource = typeof(Trek.ProductMonitor.Model.Domain.Vendor);
            // 
            // vendorProductBindingSource
            // 
            this.vendorProductBindingSource.DataSource = typeof(Trek.ProductMonitor.Model.Domain.VendorProduct);
            // 
            // Vendor
            // 
            this.Vendor.DataPropertyName = "Vendor";
            this.Vendor.HeaderText = "Vendor Name";
            this.Vendor.Name = "Vendor";
            this.Vendor.ReadOnly = true;
            this.Vendor.Width = 150;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 250;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ProductMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 507);
            this.Controls.Add(this.ProductUpdateGrid);
            this.Controls.Add(this.VendorLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ProductUpdateLabel);
            this.Controls.Add(this.VendorBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProductMaster";
            this.Text = "Product Master";
            this.Load += new System.EventHandler(this.ProductMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductUpdateGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productUpdateModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorProductBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox VendorBox;
        private System.Windows.Forms.Label ProductUpdateLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.BindingSource vendorProductBindingSource;
        private System.Windows.Forms.Label VendorLabel;
        private System.Windows.Forms.DataGridView ProductUpdateGrid;
        private System.Windows.Forms.BindingSource productUpdateModelBindingSource;
        private System.Windows.Forms.BindingSource vendorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    }
}