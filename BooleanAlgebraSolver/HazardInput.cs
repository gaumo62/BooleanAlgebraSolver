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
    public partial class HazardInput : Form
    {
        public int variables;
        public List<string> expression = new List<string>();
        private char currentChar;
        private int currentNo = 1;
        private string toAdd = "";
        public int mode;
        public HazardInput(int var, int m)
        {
            InitializeComponent();
            this.variables = var;
            this.mode = m;
            nonCpmplimentButton.Text = "A";
            complimentButton.Text = "A\'";
            currentChar = 'A';
            termTB.Text = "";
            this.noofvarLabel.Text = "Number of variables = " + this.variables.ToString();
            this.modeLabel.Text = "Static " + mode.ToString() + " Hazard";
            string temp = "SOP";
            if (mode == 0) temp = "POS";
            this.termsLabel.Text = "Enter the " + temp + " terms";
        }
        private void nonCpmplimentButton_Click(object sender, EventArgs e)
        {
            if(mode==0)
            {
                if (currentNo == variables)
                {
                    if (termTB.Text == "") termTB.Text += currentChar;
                    else termTB.Text += " + " + currentChar;
                    toAdd += "0";
                    expressionLabel.Text += "(" + termTB.Text + ")";
                    expression.Add(toAdd);
                    termTB.Clear();
                    currentChar = 'A';
                    currentNo = 1;
                    toAdd = "";
                }
                else
                {
                    if (termTB.Text == "") termTB.Text += currentChar;
                    else termTB.Text += " + " + currentChar;
                    toAdd += "0";
                    currentNo++;
                    currentChar = (char)(currentChar + 1);
                }
            }
            if(mode==1)
            {
                if (currentNo == variables)
                {
                    termTB.Text += currentChar;
                    toAdd += "1";
                    if (expressionLabel.Text.Length == 18) expressionLabel.Text += termTB.Text;
                    else expressionLabel.Text += " + " + termTB.Text;
                    expression.Add(toAdd);
                    termTB.Clear();
                    currentChar = 'A';
                    currentNo = 1;
                    toAdd = "";
                }
                else
                {
                    termTB.Text += currentChar;
                    toAdd += "1";
                    currentNo++;
                    currentChar = (char)(currentChar + 1);
                }
            }
            
            nonCpmplimentButton.Text = currentChar.ToString();
            complimentButton.Text = currentChar + "\'";
        }
        private void complimentButton_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                if (currentNo == variables)
                {
                    if (termTB.Text == "") termTB.Text += currentChar + "\'";
                    else termTB.Text += " + " + currentChar + "\'";
                    toAdd += "1";
                    expressionLabel.Text += "(" + termTB.Text + ")";
                    expression.Add(toAdd);
                    termTB.Clear();
                    currentChar = 'A';
                    currentNo = 1;
                    toAdd = "";
                }
                else
                {
                    if (termTB.Text == "") termTB.Text += currentChar + "\'";
                    else termTB.Text += " + " + currentChar + "\'";
                    toAdd += "1";
                    currentNo++;
                    currentChar = (char)(currentChar + 1);
                }
            }
            if(mode==1)
            {
                if (currentNo == variables)
                {
                    termTB.Text += currentChar + "\'";
                    toAdd += "0";
                    if (expressionLabel.Text.Length == 18) expressionLabel.Text += termTB.Text;
                    else expressionLabel.Text += " + " + termTB.Text;
                    expression.Add(toAdd);
                    termTB.Clear();
                    currentChar = 'A';
                    currentNo = 1;
                    toAdd = "";
                }
                else
                {
                    termTB.Text += currentChar + "\'";
                    toAdd += "0";
                    currentNo++;
                    currentChar = (char)(currentChar + 1);
                }
            }
            nonCpmplimentButton.Text = currentChar.ToString();
            complimentButton.Text = currentChar + "\'";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (currentNo == variables)
            {
                toAdd += "_";
                if(mode==1)
                {
                    if (expressionLabel.Text.Length == 18) expressionLabel.Text += termTB.Text;
                    else expressionLabel.Text += " + " + termTB.Text;
                }
                else if(mode == 0)  expressionLabel.Text += "(" + termTB.Text + ")";
                
                expression.Add(toAdd);
                termTB.Clear();
                currentChar = 'A';
                currentNo = 1;
                toAdd = "";
            }
            else
            {
                toAdd += "_";
                currentNo++;
                currentChar = (char)(currentChar + 1);
            }
            nonCpmplimentButton.Text = currentChar.ToString();
            complimentButton.Text = currentChar + "\'";
        }
        private void solveButton_Click(object sender, EventArgs e)
        {
            //for(int i=0;i<expression.Count;i++)
            //{
            //    Console.WriteLine(expression[i] + " + ");
            //}
            HazardSolver hs = new HazardSolver(variables, expression, mode);
            hs.solve();
            HazardOutput ho = new HazardOutput(hs, expressionLabel);
            ho.Show();
        }
    }
}
