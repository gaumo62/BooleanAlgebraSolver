using System;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
