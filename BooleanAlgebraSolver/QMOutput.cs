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
    public partial class QMOutput : Form
    {
        public QMOutput(QMSolver qs)
        {
            InitializeComponent();
            this.noofvarLabel.Text = "Number of variables: " + qs.variables.ToString();
            for(int i=0;i<qs.minterms_orig.Count;i++) mtLabel.Text += " " + qs.minterms_orig[i].ToString() + ",";
            mtLabel.Text = mtLabel.Text.Substring(0, mtLabel.Text.Length - 1);
            mtLabel.Text += ")";
            
            for (int i = 0; i < qs.dontcares.Count; i++) dcLabel.Text += " " + qs.dontcares[i].ToString() + ",";
            dcLabel.Text = dcLabel.Text.Substring(0, dcLabel.Text.Length - 1);
            dcLabel.Text += ")";
            if (qs.dontcares.Count == 0) dcLabel.Text = "None";

            Font f = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
            
            for (int i=0;i<qs.dis.Count;i++)
            {
                if (i > 0)
                {
                    tableLayoutPanel1.ColumnCount += 1;
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                }
                Label l1 = new Label() { Text = qs.dis[i]};
                l1.AutoSize = true;
                l1.Font = f;
                tableLayoutPanel1.Controls.Add(l1, tableLayoutPanel1.ColumnCount-1, 0);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(g => g.SortMode = DataGridViewColumnSortMode.NotSortable);
            for(int i=0;i<qs.primeImplicant.Count;i++)
            {
                string minterms = "";
                for (int j = 0; j < qs.primeImplicant[i].Item2.Count; j++) minterms += qs.primeImplicant[i].Item2[j] + ", ";
                minterms = minterms.Substring(0, minterms.Length - 2);
                dataGridView1.Rows.Add(qs.primeImplicantTerms[i], qs.primeImplicant[i].Item1, minterms);
            }

            string epi = "";
            epi += "\nEssestial PI:\n";
            for (int i = 0; i < qs.essentialPi.Count; i++)
            {
                epi += "Y = " + qs.essentialPi[i][0].ToString();
                for (int j = 1; j < qs.essentialPi[i].Count; j++) epi += " + " + (qs.essentialPi[i][j]).ToString();
                epi += "\n";
            }
            Label l2 = new Label() { Text = epi};
            l2.AutoSize = true;
            l2.Font = f;
            panel1.Controls.Add(l2);
            panel2.VerticalScroll.Value = 0;
        }
    }
}
