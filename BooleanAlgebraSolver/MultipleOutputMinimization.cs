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
    public partial class MultipleOutputMinimization : Form
    {
        private List<int> function1;
        private List<int> function2;
        private int variables;
        public MultipleOutputMinimization(int var)
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
            function1 = new List<int>();
            function2 = new List<int>();

            //Check if both minterms Textbox are empty
            if(function1TB.Text.Replace(" ", String.Empty)=="")
            {
                MessageBox.Show("Please enter atleast one minterm of Function 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (function2TB.Text.Replace(" ", String.Empty) == "")
            {
                MessageBox.Show("Please enter atleast one minterm of Function 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Add minterms to function 1 list
            try
            {
                string[] function = csvToArray(function1TB.Text.Replace(" ", String.Empty)+",");
                for(int i=0;i<function.Length;i++)
                {
                    string temp = function[i].Trim();
                    Console.WriteLine(temp);
                    this.function1.Add(int.Parse(temp));
                    //Check if minterms are in the correct range
                    if(int.Parse(temp) < 0 || int.Parse(temp)>=Math.Pow(2,this.variables))
                    {
                        MessageBox.Show("Entered Minterms of Function 1 should be between 0 and " + (Math.Pow(2, this.variables) - 1).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
                //To catch any random error
                MessageBox.Show("Enter the Minterms of Function 1 properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check for duplicate minterms of function 1
            var total = function1.GroupBy(_ => _).Where(_ => _.Count() > 1).Sum(_ => _.Count());
            Console.WriteLine(total);
            if (total!=0)
            {
                MessageBox.Show("All minterms of Function 1 should be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Add minterms to function2 list
            try
            {
                string[] function = csvToArray(function2TB.Text.Replace(" ", String.Empty)+",");
                for (int i = 0; i < function.Length; i++)
                {
                    string temp = function[i].Trim();
                    this.function2.Add(int.Parse(temp));
                    //Check if function2 minterms are in the correct range
                    if (int.Parse(temp) < 0 || int.Parse(temp) >= Math.Pow(2, this.variables))
                    {
                        MessageBox.Show("Entered Minterms of Function 2 should be between 0 and " + (Math.Pow(2, this.variables) - 1).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
                //To catch any random error
                if(function2TB.Text.Replace(" ", String.Empty)!="")
                {
                    MessageBox.Show("Enter the minterms of Fucntion 2 properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            //Check for duplicate minterms of function 2
            total = function2.GroupBy(_ => _).Where(_ => _.Count() > 1).Sum(_ => _.Count());
            Console.WriteLine(total);
            if (total != 0)
            {
                MessageBox.Show("All minterms of Function 2 should be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            
            Console.Write("\nFunction 1:");
            for (int i = 0; i < function1.Count; i++) Console.Write(function1[i] + " ");
            Console.WriteLine("\nFunction 2:");
            for (int i = 0; i < function2.Count; i++) Console.Write(function2[i] + " ");
            Console.Write("\n");
            MultipleOutputMinimizationSolver s = new MultipleOutputMinimizationSolver(this.variables, function1, function2);
            s.solve();
            s.PRNMINOUTPUT();
        }
    }
}
