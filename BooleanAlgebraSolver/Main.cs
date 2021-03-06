﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanAlgebraSolver
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void kmapButton_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                KMapInput f = new KMapInput(2);
                f.Show();
            }
            if (radioButton2.Checked == true)
            {
                KMapInput f = new KMapInput(3);
                f.Show();
            }
            if (radioButton3.Checked == true)
            {
                KMapInput f = new KMapInput(4);
                f.Show();
            }
            if (radioButton4.Checked == true)
            {
                KMapInput f = new KMapInput(5);
                f.Show();
            }
        }

        private void qmButton_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(qmTB.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter an integer value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            QMInput f = new QMInput(int.Parse(qmTB.Text.Trim()));
            f.Show();
        }

        private void hazardButton_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(hazardTB.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter an integer value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HazardInput f = new HazardInput(int.Parse(hazardTB.Text.Trim()), 1);
            f.Show();
        }

        private void static0Button_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(hazardTB.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter an integer value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HazardInput f = new HazardInput(int.Parse(hazardTB.Text.Trim()), 0);
            f.Show();
        }

        private void multipleOutMinButton_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(multipleOutMinTB.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter an integer value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MultipleOutputMinimization f = new MultipleOutputMinimization(int.Parse(multipleOutMinTB.Text.Trim()));
            f.Show();
        }

        private void codeConversionButton_Click(object sender, EventArgs e)
        {
            CodeConversion f = new CodeConversion();
            f.Show();
        }

        private void generateHCButton_Click(object sender, EventArgs e)
        {
            if (hammingCodeInputTB.Text.Trim().Length == 0) return;
            for(int i=0;i<hammingCodeInputTB.Text.Trim().Length;i++)
            {
                if(hammingCodeInputTB.Text.Trim()[i]!='0' && hammingCodeInputTB.Text.Trim()[i] != '1')
                {
                    MessageBox.Show("Incorrect Input Code. Data should be in 0s and 1s only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            HammingCodeGenerator h = new HammingCodeGenerator(hammingCodeInputTB.Text.Trim());
            h.generate();
            h.Show();
        }

        private void checkErrorButton_Click(object sender, EventArgs e)
        {
            if (hammingCodeInputTB.Text.Trim().Length == 0) return;
            for (int i = 0; i < hammingCodeInputTB.Text.Trim().Length; i++)
            {
                if (hammingCodeInputTB.Text.Trim()[i] != '0' && hammingCodeInputTB.Text.Trim()[i] != '1')
                {
                    MessageBox.Show("Incorrect Input Code. Data should be in 0s and 1s only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            HammingCodeCorrector h = new HammingCodeCorrector(hammingCodeInputTB.Text.Trim());
            h.correct();
            h.Show();
        }
    }
}
