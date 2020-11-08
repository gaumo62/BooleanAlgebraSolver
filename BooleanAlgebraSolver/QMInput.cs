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
    public partial class QMInput : Form
    {
        private List<int> minterms;
        private List<int> dontcares;
        private int variables;
        public QMInput(int var)
        {
            InitializeComponent();
            this.variables = var;
            this.noofvarLabel.Text = "Number of variables = " + this.variables.ToString();
        }
        public string[] csvToArray(string str)
        {
            if (str.Contains(",") == false)
            {
                string[] ans2 = new string[1];
                ans2[0] = str;
                return ans2;
            }
            string[] ans = str.Split(',');
            ans = ans.Take(ans.Length - 1).ToArray();
            return ans;
        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            #region
            //Initialise the lists
            minterms = new List<int>();
            dontcares = new List<int>();

            //Check if minterms Textbox is empty
            if(mintermTB.Text.Replace(" ", String.Empty)=="")
            {
                MessageBox.Show("Please enter atleast one minterm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //Add minterms to minterms list
            try
            {
                string[] function = csvToArray(mintermTB.Text.Replace(" ", String.Empty)+",");
                for(int i=0;i<function.Length;i++)
                {
                    string temp = function[i].Trim();
                    Console.WriteLine(temp);
                    this.minterms.Add(int.Parse(temp));
                    //Check if minterms are in the correct range
                    if(int.Parse(temp) < 0 || int.Parse(temp)>=Math.Pow(2,this.variables))
                    {
                        MessageBox.Show("Entered Minterms should be between 0 and " + (Math.Pow(2, this.variables) - 1).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
                //To catch any random error
                MessageBox.Show("Enter the Minterms properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check for duplicate minterms
            var total = minterms.GroupBy(_ => _).Where(_ => _.Count() > 1).Sum(_ => _.Count());
            Console.WriteLine(total);
            if (total!=0)
            {
                MessageBox.Show("All minterms should be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Add dontcares to dontcares list
            try
            {
                string[] function = csvToArray(dontcareTB.Text.Replace(" ", String.Empty)+",");
                for (int i = 0; i < function.Length; i++)
                {
                    string temp = function[i].Trim();
                    this.dontcares.Add(int.Parse(temp));
                    //Check if dontcares are in the correct range
                    if (int.Parse(temp) < 0 || int.Parse(temp) >= Math.Pow(2, this.variables))
                    {
                        MessageBox.Show("Entered Don't Care terms should be between 0 and " + (Math.Pow(2, this.variables) - 1).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
                //To catch any random error
                if(dontcareTB.Text.Replace(" ", String.Empty)!="")
                {
                    MessageBox.Show("Enter the Don't Cares properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }

            //Check if minterms and dontcares have any common terms 
            var commonList = minterms.Intersect(dontcares);
            if(commonList.Any())
            {
                MessageBox.Show("Terms are repeating between Minterms and Don't Cares", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            
            Console.Write("\nMinterms:");
            for (int i = 0; i < minterms.Count; i++) Console.Write(minterms[i] + " ");
            Console.WriteLine("\nDont Cares:");
            for (int i = 0; i < dontcares.Count; i++) Console.Write(dontcares[i] + " ");
            Console.Write("\n");
            QMSolver s = new QMSolver(this.variables, minterms, dontcares);
            s.solve();
            s.PRINT();
            QMOutput qo = new QMOutput(s);
            qo.Show();
        }
    }
}
