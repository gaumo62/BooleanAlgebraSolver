namespace BooleanAlgebraSolver
{
    partial class HazardOutput
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
            this.modeLabel = new System.Windows.Forms.Label();
            this.expressionLabel = new System.Windows.Forms.Label();
            this.noofvarLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.finalExpLabel = new System.Windows.Forms.Label();
            this.coverLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLabel.Location = new System.Drawing.Point(482, 55);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(75, 25);
            this.modeLabel.TabIndex = 24;
            this.modeLabel.Text = "{mode}";
            // 
            // expressionLabel
            // 
            this.expressionLabel.AutoSize = true;
            this.expressionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionLabel.Location = new System.Drawing.Point(58, 101);
            this.expressionLabel.Name = "expressionLabel";
            this.expressionLabel.Size = new System.Drawing.Size(177, 25);
            this.expressionLabel.TabIndex = 23;
            this.expressionLabel.Text = "Your Expression = ";
            // 
            // noofvarLabel
            // 
            this.noofvarLabel.AutoSize = true;
            this.noofvarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noofvarLabel.Location = new System.Drawing.Point(230, 55);
            this.noofvarLabel.Name = "noofvarLabel";
            this.noofvarLabel.Size = new System.Drawing.Size(196, 25);
            this.noofvarLabel.TabIndex = 22;
            this.noofvarLabel.Text = "{number of variables}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 46);
            this.label1.TabIndex = 21;
            this.label1.Text = "HAZARD FREE FUNCTION";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 189);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 298F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 298F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 298F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 298F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 298);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(210, 154);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(420, 32);
            this.titleLabel.TabIndex = 26;
            this.titleLabel.Text = "Hazardous Terms and Variables";
            // 
            // finalExpLabel
            // 
            this.finalExpLabel.AutoSize = true;
            this.finalExpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalExpLabel.Location = new System.Drawing.Point(7, 546);
            this.finalExpLabel.Name = "finalExpLabel";
            this.finalExpLabel.Size = new System.Drawing.Size(246, 25);
            this.finalExpLabel.TabIndex = 27;
            this.finalExpLabel.Text = "Hazard-Free Expression = ";
            // 
            // coverLabel
            // 
            this.coverLabel.AutoSize = true;
            this.coverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coverLabel.Location = new System.Drawing.Point(7, 508);
            this.coverLabel.Name = "coverLabel";
            this.coverLabel.Size = new System.Drawing.Size(210, 25);
            this.coverLabel.TabIndex = 28;
            this.coverLabel.Text = "Hazard Cover Terms:  ";
            // 
            // HazardOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 580);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.coverLabel);
            this.Controls.Add(this.finalExpLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.expressionLabel);
            this.Controls.Add(this.noofvarLabel);
            this.Controls.Add(this.label1);
            this.Name = "HazardOutput";
            this.Text = "HazardOutput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label expressionLabel;
        private System.Windows.Forms.Label noofvarLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label finalExpLabel;
        private System.Windows.Forms.Label coverLabel;
    }
}