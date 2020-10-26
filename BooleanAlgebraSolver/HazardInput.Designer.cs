namespace BooleanAlgebraSolver
{
    partial class HazardInput
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
            this.noofvarLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.termsLabel = new System.Windows.Forms.Label();
            this.expressionLabel = new System.Windows.Forms.Label();
            this.termTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nonCpmplimentButton = new System.Windows.Forms.Button();
            this.complimentButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noofvarLabel
            // 
            this.noofvarLabel.AutoSize = true;
            this.noofvarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noofvarLabel.Location = new System.Drawing.Point(213, 55);
            this.noofvarLabel.Name = "noofvarLabel";
            this.noofvarLabel.Size = new System.Drawing.Size(196, 25);
            this.noofvarLabel.TabIndex = 11;
            this.noofvarLabel.Text = "{number of variables}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 46);
            this.label1.TabIndex = 10;
            this.label1.Text = "ENTER THE FUNCTION";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(626, 385);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(162, 53);
            this.solveButton.TabIndex = 12;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // termsLabel
            // 
            this.termsLabel.AutoSize = true;
            this.termsLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.termsLabel.Location = new System.Drawing.Point(310, 91);
            this.termsLabel.Name = "termsLabel";
            this.termsLabel.Size = new System.Drawing.Size(190, 27);
            this.termsLabel.TabIndex = 13;
            this.termsLabel.Text = "Enter the ___ terms";
            // 
            // expressionLabel
            // 
            this.expressionLabel.AutoSize = true;
            this.expressionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionLabel.Location = new System.Drawing.Point(22, 299);
            this.expressionLabel.Name = "expressionLabel";
            this.expressionLabel.Size = new System.Drawing.Size(177, 25);
            this.expressionLabel.TabIndex = 14;
            this.expressionLabel.Text = "Your Expression = ";
            // 
            // termTB
            // 
            this.termTB.Location = new System.Drawing.Point(251, 251);
            this.termTB.Name = "termTB";
            this.termTB.Size = new System.Drawing.Size(313, 22);
            this.termTB.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Current Term";
            // 
            // nonCpmplimentButton
            // 
            this.nonCpmplimentButton.Location = new System.Drawing.Point(349, 138);
            this.nonCpmplimentButton.Name = "nonCpmplimentButton";
            this.nonCpmplimentButton.Size = new System.Drawing.Size(102, 31);
            this.nonCpmplimentButton.TabIndex = 17;
            this.nonCpmplimentButton.Text = "{NC}";
            this.nonCpmplimentButton.UseVisualStyleBackColor = true;
            this.nonCpmplimentButton.Click += new System.EventHandler(this.nonCpmplimentButton_Click);
            // 
            // complimentButton
            // 
            this.complimentButton.Location = new System.Drawing.Point(349, 175);
            this.complimentButton.Name = "complimentButton";
            this.complimentButton.Size = new System.Drawing.Size(102, 31);
            this.complimentButton.TabIndex = 18;
            this.complimentButton.Text = "{C}";
            this.complimentButton.UseVisualStyleBackColor = true;
            this.complimentButton.Click += new System.EventHandler(this.complimentButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(349, 212);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 31);
            this.button3.TabIndex = 19;
            this.button3.Text = "Not Present";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLabel.Location = new System.Drawing.Point(425, 55);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(75, 25);
            this.modeLabel.TabIndex = 20;
            this.modeLabel.Text = "{mode}";
            // 
            // HazardInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.complimentButton);
            this.Controls.Add(this.nonCpmplimentButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.termTB);
            this.Controls.Add(this.expressionLabel);
            this.Controls.Add(this.termsLabel);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.noofvarLabel);
            this.Controls.Add(this.label1);
            this.Name = "HazardInput";
            this.Text = "HazardInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label noofvarLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Label termsLabel;
        private System.Windows.Forms.Label expressionLabel;
        private System.Windows.Forms.TextBox termTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button nonCpmplimentButton;
        private System.Windows.Forms.Button complimentButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label modeLabel;
    }
}