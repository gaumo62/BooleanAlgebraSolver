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
    public partial class HammingCodeCorrector : Form
    {
        private string code, hamming_decode;
        private string corrected_code;
        private int error_loc;
        private List<Tuple<int,int>> list_of_tuples = new List<Tuple<int,int>>();
        public HammingCodeCorrector(string d)
        {
            InitializeComponent();
            code = d;
            dataLabel.Text += code;
        }
        //return positions in code where value is 1.
        private List<int> Index1Bits(string data)
        {
            int i = 1;
            foreach(char ch in data)
            {
                list_of_tuples.Add(new Tuple<int, int>(i, int.Parse(ch.ToString())));
                i++;
            }
            List<int> ret = new List<int>();
            for(int j=0;j<list_of_tuples.Count;j++)
            {
                if (list_of_tuples[j].Item2 == 1) ret.Add(list_of_tuples[j].Item1);
            }
            return ret;
        }
        private int XORofList(List<int> listOfNumbers)
        {
            int xor_val=listOfNumbers[0];
            for(int i=1;i<listOfNumbers.Count;i++)
            {
                xor_val ^= listOfNumbers[i];
            }
            return xor_val;
        }
        private int CalcParityBits(string data)
        {
            //# Slightly different to the Parity Function in "hamming_generate.py"
            //# Use the formula 2^m >= N (=m+n) to calculate the no of parity bits.
            //# Iterate over 0 .. N and return the value that satisfies the equation
            int N = data.Length;
            for(int i=0;i<N;i++)
            {
                if (Math.Pow(2, i) > N) return i;
            }
            return -1;
        }
        private string HammingDecode(string data)
        {
            int m = CalcParityBits(data);
            string temp = data;
            while(m>0)
            {
                temp = temp.Remove(Convert.ToInt32(Math.Pow(2, m - 1)) - 1,1);
                m--;
            }
            return temp;
        }
        public void correct()
        {
            string temp_code = code;
            List<int> indices_of_1 = new List<int>(Index1Bits(temp_code));
            error_loc = XORofList(indices_of_1);
            if(error_loc!=0)
            {
                if (temp_code[error_loc - 1] == '0') temp_code = temp_code.Remove(error_loc - 1, 1).Insert(error_loc - 1, "1");
                else temp_code = temp_code.Remove(error_loc - 1, 1).Insert(error_loc - 1, "0");
            }
            corrected_code = temp_code;
            hamming_decode = HammingDecode(corrected_code);

            display();
            Console.WriteLine(corrected_code);
            Console.WriteLine(hamming_decode);
        }
        public void display()
        {
            int n = CalcParityBits(code);
            for (int i = 0; i < n; i++) dataGridView2.Columns.Add("col" + i.ToString(), "");
            for(int i=0;i<list_of_tuples.Count;i++)
            {
                if(list_of_tuples[i].Item2==1)
                {
                    string binary = Convert.ToString(list_of_tuples[i].Item1, 2);
                    while (binary.Length != n) binary = "0" + binary;
                    dataGridView2.Rows.Add();
                    for (int j = 0; j < n; j++) dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[j].Value = binary[j];
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].HeaderCell.Value = list_of_tuples[i].Item1.ToString();
                }
            }
            dataGridView2.Rows.Add();
            string binary2 = Convert.ToString(error_loc, 2);
            while (binary2.Length != n) binary2 = "0" + binary2;
            for (int j = 0; j < n; j++) dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[j].Value = binary2[j];
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].HeaderCell.Value = "(XOR) " + error_loc.ToString();
            if(error_loc>0) dataGridView2.Rows[dataGridView2.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
            else dataGridView2.Rows[dataGridView2.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LimeGreen;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].DefaultCellStyle.Font = new Font("Arial", 8.75F, FontStyle.Bold);

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.75F, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Cast<DataGridViewColumn>().ToList().ForEach(g => g.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView2.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.75F, FontStyle.Bold);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;
            foreach (DataGridViewColumn dgvc in dataGridView2.Columns) dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if(error_loc!=0) errorTextLabel.Text = "Bit number " + error_loc.ToString() + " is erraneous";
            else errorTextLabel.Text = "No error in the Hamming Code";

            for (int i = 0; i < corrected_code.Length; i++)
            {
                if (i == 1 || Math.Ceiling(Math.Log(i + 1, 2)) == Math.Floor(Math.Log(i + 1, 2)))
                {
                    dataGridView1.Columns.Add("P" + (i + 1).ToString(), "P" + (i + 1).ToString());
                }
                else dataGridView1.Columns.Add("D" + (i + 1).ToString(), "D" + (i + 1).ToString());
            }
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].HeaderCell.Value = "Original Code";
            for (int i = 0; i < code.Length; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = code[i];
                if (error_loc > 0) dataGridView1.Rows[0].Cells[error_loc - 1].Style.BackColor = Color.Red;
            }
            dataGridView1.Rows.Add();
            dataGridView1.Rows[1].HeaderCell.Value = "Final Code";
            for (int i = 0; i < code.Length; i++)
            {
                dataGridView1.Rows[1].Cells[i].Value = corrected_code[i];
                if (error_loc > 0) dataGridView1.Rows[1].Cells[error_loc - 1].Style.BackColor = Color.LimeGreen;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.75F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(g => g.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView1.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 7.75F, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            foreach (DataGridViewColumn dgvc in dataGridView1.Columns) dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Rows[0].Cells[2].Selected = true;

            correctDataLabel.Text += hamming_decode;
            correctHCLabel.Text += corrected_code;
        }
    }
}
