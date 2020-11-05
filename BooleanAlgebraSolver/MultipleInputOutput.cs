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
    public partial class MultipleInputOutput : Form
    {
        public MultipleInputOutput(MultipleOutputMinimizationSolver ms)
        {
            InitializeComponent();
            this.noofvarLabel.Text = "Number of variables: " + ms.variables.ToString();
            for(int i=0;i<ms.function1.Count;i++) func1Label.Text += " " + ms.function1[i].ToString() + ",";
            func1Label.Text = func1Label.Text.Substring(0, func1Label.Text.Length - 1);
            func1Label.Text += ")";
            
            for (int i = 0; i < ms.function2.Count; i++) func2Label.Text += " " + ms.function2[i].ToString() + ",";
            func2Label.Text = func2Label.Text.Substring(0, func2Label.Text.Length - 1);
            func2Label.Text += ")";
            
            ansLabel.Text = ms.dis;
            ansLabel.AutoSize = true;
        }
    }
}
