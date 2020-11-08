namespace BooleanAlgebraSolver
{
    partial class KMapInput
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.minimizeSOPButton = new System.Windows.Forms.Button();
            this.minimizePOSButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "ENTER THE FUNCTION";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1,
            this.ColumnX});
            this.dataGridView1.Location = new System.Drawing.Point(12, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(896, 538);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column0
            // 
            this.Column0.HeaderText = "0";
            this.Column0.MinimumWidth = 6;
            this.Column0.Name = "Column0";
            this.Column0.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "Don\'t Care (X)";
            this.ColumnX.MinimumWidth = 6;
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.Width = 125;
            // 
            // minimizeSOPButton
            // 
            this.minimizeSOPButton.Location = new System.Drawing.Point(914, 494);
            this.minimizeSOPButton.Name = "minimizeSOPButton";
            this.minimizeSOPButton.Size = new System.Drawing.Size(145, 48);
            this.minimizeSOPButton.TabIndex = 2;
            this.minimizeSOPButton.Text = "Minimize SOP";
            this.minimizeSOPButton.UseVisualStyleBackColor = true;
            this.minimizeSOPButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // minimizePOSButton
            // 
            this.minimizePOSButton.Location = new System.Drawing.Point(914, 548);
            this.minimizePOSButton.Name = "minimizePOSButton";
            this.minimizePOSButton.Size = new System.Drawing.Size(145, 48);
            this.minimizePOSButton.TabIndex = 3;
            this.minimizePOSButton.Text = "Minimize POS";
            this.minimizePOSButton.UseVisualStyleBackColor = true;
            this.minimizePOSButton.Click += new System.EventHandler(this.minimizePOSButton_Click);
            // 
            // KMapInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 614);
            this.Controls.Add(this.minimizePOSButton);
            this.Controls.Add(this.minimizeSOPButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "KMapInput";
            this.Text = "K-Map Input";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column0;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnX;
        private System.Windows.Forms.Button minimizeSOPButton;
        private System.Windows.Forms.Button minimizePOSButton;
    }
}