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
    public partial class KMapInput : Form
    {
        private int variables;
        public KMapInput(int var)
        {
            InitializeComponent();
            this.variables = var;
            List<string> alpha = new List<string>();
            alpha.Add("A");
            alpha.Add("B");
            alpha.Add("C");
            alpha.Add("D");
            alpha.Add("E");
            
            //Add columns dynamically to dataGridView1 (Table)
            for (int i=0;i<variables;i++)
            {
                DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
                c.HeaderText = alpha[i];
                c.ReadOnly = true;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(i,c);
            }
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Number";
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(this.variables, col);
            
            //Add 2^32 columns and filling their values
            for(int i=0;i<=Math.Pow(2,variables)-1;i++)
            {
                string binary = Convert.ToString(i, 2);
                while(binary.Length!=variables) binary = "0" + binary;
                dataGridView1.Rows.Add();
                int j;
                for (j = 0; j < variables; j++) dataGridView1.Rows[i].Cells[j].Value = binary[j];
                dataGridView1.Rows[i].Cells[j].Value = i;
                dataGridView1.Rows[i].Cells[j + 1].Value = true;
                dataGridView1.Rows[i].Cells[j + 2].Value = false;
                dataGridView1.Rows[i].Cells[j + 3].Value = false;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //When any cell of the table is clicked, if it is a checkbox cell, that checkbox should get ticked and rest all should get unticked
            if (dataGridView1.Rows.Count <= 0) return;
            if (e.RowIndex < 0) return;
            for (int i = dataGridView1.Columns.Count - 3; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Rows[e.RowIndex].Cells[i].Value = false;
            }
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            int row_count = 0;
            List<int> minterm = new List<int>();
            List<int> maxterm = new List<int>();
            List<int> dontcare = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //Check if only 1 checkbox per row is clicked. If yes, add the terms to respective arrays
                int check = 0,check_ind=-1;
                for (int i = dataGridView1.Columns.Count - 3; i < dataGridView1.Columns.Count; i++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[i];
                    if (chk.Value.ToString() == "True")
                    {
                        check++;
                        check_ind = dataGridView1.Columns.Count - i;
                    }
                }
                if(check!=1)
                {
                    MessageBox.Show("Enter 1 value in row: " + row_count,"Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (check_ind == 3) maxterm.Add(row_count);
                    else if (check_ind == 2) minterm.Add(row_count);
                    else if (check_ind == 1) dontcare.Add(row_count);
                }
                row_count++;
            }
            Console.Write("Maxterms:");
            for (int i = 0; i < maxterm.Count; i++) Console.Write(maxterm[i] + " ");
            Console.Write("\nMinterms:");
            for (int i = 0; i < minterm.Count; i++) Console.Write(minterm[i] + " ");
            Console.WriteLine("\nDont Cares:");
            for (int i = 0; i < dontcare.Count; i++) Console.WriteLine(dontcare[i] + " ");
            QMSolver s = new QMSolver(this.variables, minterm, dontcare);
            s.solve();
        }


    }
}
