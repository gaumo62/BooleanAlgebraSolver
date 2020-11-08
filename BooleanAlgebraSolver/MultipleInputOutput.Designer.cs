namespace BooleanAlgebraSolver
{
    partial class MultipleInputOutput
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
            this.expressionLabel = new System.Windows.Forms.Label();
            this.noofvarLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ansLabel = new System.Windows.Forms.Label();
            this.func1Label = new System.Windows.Forms.Label();
            this.func2Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // expressionLabel
            // 
            this.expressionLabel.AutoSize = true;
            this.expressionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionLabel.Location = new System.Drawing.Point(58, 101);
            this.expressionLabel.Name = "expressionLabel";
            this.expressionLabel.Size = new System.Drawing.Size(208, 29);
            this.expressionLabel.TabIndex = 23;
            this.expressionLabel.Text = "Your Expressions:";
            // 
            // noofvarLabel
            // 
            this.noofvarLabel.AutoSize = true;
            this.noofvarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noofvarLabel.Location = new System.Drawing.Point(335, 55);
            this.noofvarLabel.Name = "noofvarLabel";
            this.noofvarLabel.Size = new System.Drawing.Size(196, 25);
            this.noofvarLabel.TabIndex = 22;
            this.noofvarLabel.Text = "{number of variables}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(658, 46);
            this.label1.TabIndex = 21;
            this.label1.Text = "LEAST COST IMPLEMENTATION";
            // 
            // ansLabel
            // 
            this.ansLabel.AutoSize = true;
            this.ansLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansLabel.Location = new System.Drawing.Point(332, 73);
            this.ansLabel.Name = "ansLabel";
            this.ansLabel.Size = new System.Drawing.Size(69, 29);
            this.ansLabel.TabIndex = 26;
            this.ansLabel.Text = "{ans}";
            // 
            // func1Label
            // 
            this.func1Label.AutoSize = true;
            this.func1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.func1Label.Location = new System.Drawing.Point(211, 139);
            this.func1Label.Name = "func1Label";
            this.func1Label.Size = new System.Drawing.Size(93, 25);
            this.func1Label.TabIndex = 29;
            this.func1Label.Text = "Y1 = Σm(";
            this.func1Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // func2Label
            // 
            this.func2Label.AutoSize = true;
            this.func2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.func2Label.Location = new System.Drawing.Point(211, 174);
            this.func2Label.Name = "func2Label";
            this.func2Label.Size = new System.Drawing.Size(93, 25);
            this.func2Label.TabIndex = 30;
            this.func2Label.Text = "Y2 = Σm(";
            this.func2Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ansLabel);
            this.panel1.Location = new System.Drawing.Point(12, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 262);
            this.panel1.TabIndex = 31;
            // 
            // MultipleInputOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 483);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.func2Label);
            this.Controls.Add(this.func1Label);
            this.Controls.Add(this.expressionLabel);
            this.Controls.Add(this.noofvarLabel);
            this.Controls.Add(this.label1);
            this.Name = "MultipleInputOutput";
            this.Text = "HazardOutput";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label expressionLabel;
        private System.Windows.Forms.Label noofvarLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ansLabel;
        private System.Windows.Forms.Label func1Label;
        private System.Windows.Forms.Label func2Label;
        private System.Windows.Forms.Panel panel1;
    }
}