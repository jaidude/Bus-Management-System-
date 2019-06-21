namespace BR
{
    partial class viewbuses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewbuses));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.busdetails = new BR.busdetails();
            this.bUSESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bUSESTableAdapter = new BR.busdetailsTableAdapters.BUSESTableAdapter();
            this.bUSNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bUSTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sFROMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMOUNTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIMINGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.busdetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bUSESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bUSNODataGridViewTextBoxColumn,
            this.bUSTYPEDataGridViewTextBoxColumn,
            this.sFROMDataGridViewTextBoxColumn,
            this.dTODataGridViewTextBoxColumn,
            this.aMOUNTDataGridViewTextBoxColumn,
            this.tIMINGDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bUSESBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(39, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 290);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // busdetails
            // 
            this.busdetails.DataSetName = "busdetails";
            this.busdetails.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bUSESBindingSource
            // 
            this.bUSESBindingSource.DataMember = "BUSES";
            this.bUSESBindingSource.DataSource = this.busdetails;
            // 
            // bUSESTableAdapter
            // 
            this.bUSESTableAdapter.ClearBeforeFill = true;
            // 
            // bUSNODataGridViewTextBoxColumn
            // 
            this.bUSNODataGridViewTextBoxColumn.DataPropertyName = "BUS_NO";
            this.bUSNODataGridViewTextBoxColumn.HeaderText = "BUS_NO";
            this.bUSNODataGridViewTextBoxColumn.Name = "bUSNODataGridViewTextBoxColumn";
            // 
            // bUSTYPEDataGridViewTextBoxColumn
            // 
            this.bUSTYPEDataGridViewTextBoxColumn.DataPropertyName = "BUS_TYPE";
            this.bUSTYPEDataGridViewTextBoxColumn.HeaderText = "BUS_TYPE";
            this.bUSTYPEDataGridViewTextBoxColumn.Name = "bUSTYPEDataGridViewTextBoxColumn";
            // 
            // sFROMDataGridViewTextBoxColumn
            // 
            this.sFROMDataGridViewTextBoxColumn.DataPropertyName = "S_FROM";
            this.sFROMDataGridViewTextBoxColumn.HeaderText = "S_FROM";
            this.sFROMDataGridViewTextBoxColumn.Name = "sFROMDataGridViewTextBoxColumn";
            // 
            // dTODataGridViewTextBoxColumn
            // 
            this.dTODataGridViewTextBoxColumn.DataPropertyName = "D_TO";
            this.dTODataGridViewTextBoxColumn.HeaderText = "D_TO";
            this.dTODataGridViewTextBoxColumn.Name = "dTODataGridViewTextBoxColumn";
            // 
            // aMOUNTDataGridViewTextBoxColumn
            // 
            this.aMOUNTDataGridViewTextBoxColumn.DataPropertyName = "AMOUNT";
            this.aMOUNTDataGridViewTextBoxColumn.HeaderText = "AMOUNT";
            this.aMOUNTDataGridViewTextBoxColumn.Name = "aMOUNTDataGridViewTextBoxColumn";
            // 
            // tIMINGDataGridViewTextBoxColumn
            // 
            this.tIMINGDataGridViewTextBoxColumn.DataPropertyName = "TIMING";
            this.tIMINGDataGridViewTextBoxColumn.HeaderText = "TIMING";
            this.tIMINGDataGridViewTextBoxColumn.Name = "tIMINGDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Fax", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.Location = new System.Drawing.Point(135, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<< Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // viewbuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(735, 448);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "viewbuses";
            this.Text = "viewbuses";
            this.Load += new System.EventHandler(this.viewbuses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.busdetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bUSESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private busdetails busdetails;
        private System.Windows.Forms.BindingSource bUSESBindingSource;
        private busdetailsTableAdapters.BUSESTableAdapter bUSESTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn bUSNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bUSTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sFROMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMOUNTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIMINGDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}