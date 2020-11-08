namespace BooleanAlgebraSolver
{
    partial class MultipleOutputMinimization
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.function1TB = new System.Windows.Forms.TextBox();
            this.function2TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.noofvarLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "ENTER THE FUNCTION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter the Minterms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "(Enter Comma Seperated Integers Ex: 1,2,3,4) ";
            // 
            // function1TB
            // 
            this.function1TB.Location = new System.Drawing.Point(192, 138);
            this.function1TB.Name = "function1TB";
            this.function1TB.Size = new System.Drawing.Size(596, 22);
            this.function1TB.TabIndex = 4;
            // 
            // function2TB
            // 
            this.function2TB.Location = new System.Drawing.Point(193, 254);
            this.function2TB.Name = "function2TB";
            this.function2TB.Size = new System.Drawing.Size(595, 22);
            this.function2TB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "(Enter Comma Seperated Integers Ex: 1,2,3,4) ";
            // 
            // minimizeButton
            // 
            this.minimizeButton.Location = new System.Drawing.Point(643, 390);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(145, 48);
            this.minimizeButton.TabIndex = 8;
            this.minimizeButton.Text = "Minimize";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // noofvarLabel
            // 
            this.noofvarLabel.AutoSize = true;
            this.noofvarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noofvarLabel.Location = new System.Drawing.Point(305, 55);
            this.noofvarLabel.Name = "noofvarLabel";
            this.noofvarLabel.Size = new System.Drawing.Size(196, 25);
            this.noofvarLabel.TabIndex = 9;
            this.noofvarLabel.Text = "{number of variables}";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 43);
            this.label6.TabIndex = 10;
            this.label6.Text = "Function 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 43);
            this.label7.TabIndex = 11;
            this.label7.Text = "Function 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Enter the Minterms";
            // 
            // MultipleOutputMinimization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.noofvarLabel);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.function2TB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.function1TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MultipleOutputMinimization";
            this.Text = "Multiple Output Minimization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox function1TB;
        private System.Windows.Forms.TextBox function2TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Label noofvarLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}