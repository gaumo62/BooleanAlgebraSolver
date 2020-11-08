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
    public partial class HammingCodeGenerator : Form
    {
        private string data;
        private List<List<int>> xors = new List<List<int>>();
        public HammingCodeGenerator(string d)
        {
            InitializeComponent();
            data = d;
            dataLabel.Text += data;
        }
        private int CalcParityBits(string code)
        {
            //Use the formula (2^m >= m + n) to calculate the no of parity bits. 
            //Iterate over 0 .. n and return the value that satisfies the equation
            int n = code.Length;
            for(int i=0;i<n;i++)
            {
                if (Math.Pow(2, i) > n + i) return i;
            }
            return -1;
        }
        private string AssignParityBits(string code, int parity_count)
        {
            int n = code.Length;
            //For finding rth parity bit, iterate over 0 to (parity_count - 1)
            for(int i = 0;i<parity_count;i++)
            {
                int val = 0;
                List<int> temp = new List<int>();
                for(int j=1;j<n + 1;j++)
                {
                    //If position has 1 in ith significant position then Bitwise XOR the array value to find parity bit value.
                    int c = j & Convert.ToInt32(Math.Pow(2, i));
                    if (c == Math.Pow(2, i))
                    {
                        val ^= int.Parse(code[j - 1].ToString());
                        temp.Add(j);    
                    }
                }
                //String Concatenation
                code = code.Substring(0, Convert.ToInt32(Math.Pow(2, i)) - 1) + (val).ToString() + code.Substring(Convert.ToInt32(Math.Pow(2, i)), code.Length - Convert.ToInt32(Math.Pow(2, i)));
                temp.RemoveAt(0);
                xors.Add(new List<int>(temp));
            }
            return code;
        }
    
        public void generate()
        {
            int n = data.Length;
            int parity_count = CalcParityBits(data);     //No. of parity bits
            int j = 0;
            int k = 0;
            string newcode = "";
            for (int i = 1; i < n + parity_count + 1; i++)    //# iterating over 1st ... (n+m)th term
            {
                if (i == Math.Pow(2, j))
                {
                    newcode += '0';
                    j++;
                }
                else
                {
                    newcode += data[k];
                    k++;
                }
            }
            string ans = AssignParityBits(newcode, parity_count);
            
            //Output
            for(int i=0;i<ans.Length;i++)
            {
                DataGridViewColumn dgvc = new DataGridViewColumn();
                if (i == 1 || Math.Ceiling(Math.Log(i + 1, 2)) == Math.Floor(Math.Log(i+1, 2)))
                {
                    dataGridView1.Columns.Add("P" + (i + 1).ToString(), "P" + (i + 1).ToString());
                }
                else dataGridView1.Columns.Add("D" + (i + 1).ToString(), "D" + (i + 1).ToString());
            }
            dataGridView1.Rows.Add();
            for (int i=0;i<ans.Length;i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = ans[i];
                if (i+1 == 1 || Math.Ceiling(Math.Log(i + 1, 2)) == Math.Floor(Math.Log(i+1, 2)))   dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.LightYellow;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(g => g.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            foreach (DataGridViewColumn dgvc in dataGridView1.Columns) dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Rows[0].Cells[2].Selected = true;

            displayLabel.Text = "";
            for(int i=0;i<xors.Count; i++)
            {
                displayLabel.Text += "P" + Math.Pow(2, i).ToString() + " = ";
                for(int l=0;l<xors[i].Count;l++)
                {
                    displayLabel.Text += "D" + xors[i][l].ToString() + " ^ ";
                }
                displayLabel.Text = displayLabel.Text.Substring(0, displayLabel.Text.Length - 2);
                displayLabel.Text += " = ";
                for (int l = 0; l < xors[i].Count; l++)
                {
                    displayLabel.Text += ans[xors[i][l] - 1].ToString() + " ^ ";
                }
                displayLabel.Text = displayLabel.Text.Substring(0, displayLabel.Text.Length - 2);
                displayLabel.Text += " = " + ans[Convert.ToInt32(Math.Pow(2, i)) - 1];
                displayLabel.Text += "\n";
            }
            displayLabel.TextAlign = ContentAlignment.MiddleCenter;
            hcLabel.Text += ans;
        }
    }
}
