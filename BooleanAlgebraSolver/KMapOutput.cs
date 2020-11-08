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
    public partial class KMapOutput : Form
    {
        //private List<string> rowheadSOP_2_3 = new List<string> { "A'", "A" };
        //private List<string> colheadSOP_2 = new List<string> { "B'", "B" };
        //private List<string> colheadSOP_3 = new List<string> { "B'C'", "B'C","BC","BC'" };
        //private List<string> rowheadSOP_4 = new List<string> { "A'B'", "A'B","AB","AB'" };
        //private List<string> colheadSOP_4 = new List<string> { "C'D'", "C'D","CD","CD'" };
        //private List<string> rowheadSOP_5 = new List<string> { "A'B'C'", "A'B'C", "A'BC", "A'BC'", "AB'C'", "AB'C", "ABC", "ABC'" };
        //private List<string> colheadSOP_5 = new List<string> { "D'E'", "D'E", "DE", "DE'" };

        private List<string> rowheadSOP_2_3 = new List<string> { "0", "1" };
        private List<string> colheadSOP_2 = new List<string> { "-0", "-1" };
        private List<string> colheadSOP_3 = new List<string> { "-00", "-01", "-11", "-10" };
        private List<string> rowheadSOP_4 = new List<string> { "00", "01", "11", "10" };
        private List<string> colheadSOP_4 = new List<string> { "--00", "--01", "--11", "--10" };
        private List<string> rowheadSOP_5 = new List<string> { "000", "001", "011", "010", "100", "101", "111", "110" };
        private List<string> colheadSOP_5 = new List<string> { "---00", "---01", "---11", "---10" };

        //private List<string> rowheadPOS_2_3 = new List<string> { "A", "A'" };
        //private List<string> colheadPOS_2 = new List<string> { "B", "B'" };
        //private List<string> colheadPOS_3 = new List<string> { "B+C", "B+C'", "B'+C'", "B'+C" };
        //private List<string> rowheadPOS_4 = new List<string> { "A+B", "A+B'", "A'+B'", "A'+B" };
        //private List<string> colheadPOS_4 = new List<string> { "C+D", "C+D'", "C'+D'", "C'+D" };
        //private List<string> rowheadPOS_5 = new List<string> { "A+B+C", "A+B+C'", "A+B'+C'", "A+B'+C", "A'+B+C", "A'+B+C'", "A'+B'+C'", "A'+B'+C" };
        //private List<string> colheadPOS_5 = new List<string> { "D+E", "D+E'", "D'+E'", "D'+E" };
        public KMapOutput(QMSolver qs, List<int> maxterms)
        {
            InitializeComponent();
            this.noofvarLabel.Text = "Number of variables: " + qs.variables.ToString();
            if (qs.mode == 0) dataGridView1.Columns[1].HeaderText = "Maxterms";
            
            for (int i = 0; i < qs.dontcares.Count; i++) dcLabel.Text += " " + qs.dontcares[i].ToString() + ",";
            dcLabel.Text = dcLabel.Text.Substring(0, dcLabel.Text.Length - 1);
            dcLabel.Text += ")";

            if (qs.mode == 1)
            {
                this.simplificationLabel.Text += " SOP";
                mtLabel.Text = "Σm(";
                for (int i = 0; i < qs.minterms_orig.Count; i++) mtLabel.Text += " " + qs.minterms_orig[i].ToString() + ",";
                mtLabel.Text = mtLabel.Text.Substring(0, mtLabel.Text.Length - 1);
                mtLabel.Text += ")";
            }
            else
            {
                this.simplificationLabel.Text += " POS";
                mtLabel.Text = "ΠM(";
                for (int i = 0; i < maxterms.Count; i++) mtLabel.Text += " " + maxterms[i].ToString() + ",";
                mtLabel.Text = mtLabel.Text.Substring(0, mtLabel.Text.Length - 1);
                mtLabel.Text += ")";
                //mtLabel.Text.Replace('Σ', 'Π');
                //mtLabel.Text.Replace('m', 'M');
            }
            if (qs.dontcares.Count == 0) dcLabel.Text = "None";

            Font f = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);

            fillKMapHeaders(qs.variables, dataGridView2,qs);
            fillKMapHeaders(qs.variables, dataGridView3,qs);
            fillKMapLayout(qs.variables);
            fillKMap(qs.variables, qs.mode, qs);

            string epi = "";
            List<int> all_highlight = new List<int>();
            if (qs.mode==1)
            {
                for (int i = 0; i < qs.essentialPi.Count; i++)
                {
                    dataGridView1.Rows.Add("Solution " + (i + 1).ToString() + ":", "");
                    for (int j = 0; j < qs.essentialPi[i].Count; j++)
                    {
                        string group = "";
                        List<int> grp = new List<int>(qs.GETGROUP(qs.raw_essentialPi[i][j]));
                        all_highlight.AddRange(grp);
                        for (int k = 0; k < grp.Count; k++) group += grp[k] + ", ";
                        group = group.Substring(0, group.Length - 2);
                        dataGridView1.Rows.Add(qs.essentialPi[i][j], group);
                    }
                }

                epi += "\nPossible Solutions:\n";
                for (int i = 0; i < qs.essentialPi.Count; i++)
                {
                    epi += "Solution " + (i + 1).ToString() + ":    Y = " + qs.essentialPi[i][0].ToString();
                    for (int j = 1; j < qs.essentialPi[i].Count; j++) epi += " + " + (qs.essentialPi[i][j]).ToString();
                    epi += "\n";
                }
                
            }
            else
            {
                for (int i = 0; i < qs.essentialPi.Count; i++)
                {
                    dataGridView1.Rows.Add("Solution " + (i + 1).ToString() + ":", "");
                    for (int j = 0; j < qs.essentialPi[i].Count; j++)
                    {
                        string group = "";
                        //List<int> grp = new List<int>(getGroupPOS(qs.variables, rawEPIComp(qs.raw_essentialPi[i][j])));
                        Console.WriteLine("Essential PI:" + qs.raw_essentialPi[i][j]);
                        List<int> grp = new List<int>(qs.GETGROUP(qs.raw_essentialPi[i][j]));
                        all_highlight.AddRange(grp);
                        for (int k = 0; k < grp.Count; k++) group += grp[k] + ", ";
                        group = group.Substring(0, group.Length - 2);
                        dataGridView1.Rows.Add(qs.CONVERT(qs.raw_essentialPi[i][j].ToString()), group);
                    }
                }

                epi += "\nPossible Solutions:\n";
                for (int i = 0; i < qs.essentialPi.Count; i++)
                {
                    epi += "Solution " + (i + 1).ToString() + ":    Y = ";
                    for (int j = 0; j < qs.essentialPi[i].Count; j++) epi += "(" + qs.CONVERT(qs.raw_essentialPi[i][j].ToString()) + ")";
                    epi += "\n";
                }
            }
            Console.WriteLine("ALLL VALUES: ");
            for (int i = 0; i < all_highlight.Count; i++) Console.WriteLine(all_highlight[i].ToString() + " ");
            List<int> all_highlight_distinct = all_highlight.Distinct().ToList();
            Console.WriteLine("ALLL VALUES DISTINCT: ");
            for (int i = 0; i < all_highlight_distinct.Count; i++) Console.WriteLine(all_highlight_distinct[i].ToString() + " ");
            for(int i=0;i<dataGridView3.Rows.Count;i++)
            {
                for(int j=0;j<dataGridView3.Columns.Count;j++)
                {
                    if (all_highlight_distinct.Contains(int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString()))) dataGridView2.Rows[i].Cells[j].Style.BackColor = Color.LightYellow;
                }
            }
            
            Label l2 = new Label() { Text = epi };
            l2.AutoSize = true;
            l2.Font = f;
            panel1.Controls.Add(l2);

            adjust_dgvs();
        }
        void adjust_dgvs()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(g => g.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Cast<DataGridViewColumn>().ToList().ForEach(g => g.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView2.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;
            foreach (DataGridViewColumn dgvc in dataGridView2.Columns) dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns.Cast<DataGridViewColumn>().ToList().ForEach(g => g.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView3.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.Black; 
            foreach (DataGridViewColumn dgvc in dataGridView3.Columns) dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        void fillKMapHeaders(int var,DataGridView dgv, QMSolver qs)
        {
            if(var==2)
            {
                for(int i=0;i<2;i++)
                {
                    dgv.Columns.Add("col_" + i.ToString(), qs.CONVERT(colheadSOP_2[i]));
                    dgv.Rows.Add();
                    dgv.Rows[i].HeaderCell.Value = qs.CONVERT(rowheadSOP_2_3[i]);
                }
            }
            else if (var == 3)
            {
                for(int i=0;i<4;i++)    dgv.Columns.Add("col_" + i.ToString(), qs.CONVERT(colheadSOP_3[i]));
                for (int i = 0; i < 2; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].HeaderCell.Value = qs.CONVERT(rowheadSOP_2_3[i]);
                }
            }
            else if (var == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    dgv.Columns.Add("col_" + i.ToString(), qs.CONVERT(colheadSOP_4[i]));
                    dgv.Rows.Add();
                    dgv.Rows[i].HeaderCell.Value = qs.CONVERT(rowheadSOP_4[i]);
                }
            }
            else if (var == 5)
            {
                for (int i = 0; i < 4; i++) dgv.Columns.Add("col_" + i.ToString(), qs.CONVERT(colheadSOP_5[i]));
                for(int i=0;i<8;i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].HeaderCell.Value = qs.CONVERT(rowheadSOP_5[i]);
                }
            }
        }
        void fillKMapLayout(int var)
        {
            if(var==2)
            {
                for(int i=0;i<2;i++)
                {
                    for(int j=0;j<2;j++)
                    {
                        string binary = rowheadSOP_2_3[i].Replace("-", "") + colheadSOP_2[j].Replace("-", "");
                        int mt =  Convert.ToInt32(binary, 2);
                        dataGridView3.Rows[i].Cells[j].Value = mt;
                    }
                }
            }
            else if (var == 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string binary = rowheadSOP_2_3[i].Replace("-", "") + colheadSOP_3[j].Replace("-", "");
                        int mt = Convert.ToInt32(binary, 2);
                        dataGridView3.Rows[i].Cells[j].Value = mt;
                    }
                }
            }
            else if (var == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string binary = rowheadSOP_4[i].Replace("-", "") + colheadSOP_4[j].Replace("-", "");
                        int mt = Convert.ToInt32(binary, 2);
                        dataGridView3.Rows[i].Cells[j].Value = mt;
                    }
                }
            }
            else if (var == 5)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string binary = rowheadSOP_5[i].Replace("-", "") + colheadSOP_5[j].Replace("-", "");
                        int mt = Convert.ToInt32(binary, 2);
                        dataGridView3.Rows[i].Cells[j].Value = mt;
                    }
                }
            }
        }
        void fillCell(int i, int j, QMSolver qs)
        {
            int dec = int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString());
            if (qs.minterms_orig.Contains(dec))
            {
                if (qs.mode == 1) dataGridView2.Rows[i].Cells[j].Value = 1;
                if (qs.mode == 0) dataGridView2.Rows[i].Cells[j].Value = 0;
                dataGridView2.Rows[i].Cells[j].Style.BackColor = Color.LightYellow;
            }
            else if (qs.dontcares.Contains(dec)) dataGridView2.Rows[i].Cells[j].Value = "X";
        }
        void fillKMap(int var, int mode, QMSolver qs)
        {
            if(var==2)
            {
                for(int i=0;i<2;i++)
                {
                    for(int j=0;j<2;j++)
                    {
                        fillCell(i, j, qs);
                    }
                }
            }
            else if (var == 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        fillCell(i, j, qs);
                    }
                }
            }
            else if (var == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        fillCell(i, j, qs);
                    }
                }
            }
            else if (var == 5)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        fillCell(i, j, qs);
                    }
                }
            }
        }
        List<int> getGroupPOS(int var, string raw_epi)
        {
            List<int> grp = new List<int>();
            string temp = raw_epi;
            Console.WriteLine("RAW EPI: " + raw_epi);
            int len = temp.Replace("-", "").Length;
            Console.WriteLine("LENGTH: " + len.ToString());
            if (var==2)
            {
                for(int i=0;i<2;i++)
                {
                    for(int j=0;j<2;j++)
                    {
                        string term = rowheadSOP_2_3[i] + colheadSOP_2[j].Replace("-", "");
                        Console.WriteLine("TERM: " + term);
                        int temp_len = 0;
                        for(int k=0;k<raw_epi.Length;k++)
                        {
                            if(raw_epi[k]!='-')
                            {
                                if (raw_epi[k] == term[k]) temp_len++;
                            }
                        }
                        if(temp_len==len)   grp.Add(Convert.ToInt32(term, 2));
                    }
                }
            }
            else if(var == 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string term = rowheadSOP_2_3[i] + colheadSOP_3[j].Replace("-", "");
                        Console.WriteLine("TERM: " + term);
                        int temp_len = 0;
                        for (int k = 0; k < raw_epi.Length; k++)
                        {
                            if (raw_epi[k] != '-')
                            {
                                if (raw_epi[k] == term[k]) temp_len++;
                            }
                        }
                        if (temp_len == len) grp.Add(Convert.ToInt32(term, 2));
                    }
                }
            }
            else if (var == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string term = rowheadSOP_4[i] + colheadSOP_4[j].Replace("-", "");
                        Console.WriteLine("TERM: " + term);
                        int temp_len = 0;
                        for (int k = 0; k < raw_epi.Length; k++)
                        {
                            if (raw_epi[k] != '-')
                            {
                                if (raw_epi[k] == term[k]) temp_len++;
                            }
                        }
                        if (temp_len == len) grp.Add(Convert.ToInt32(term, 2));
                    }
                }
            }
            else if (var == 5)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string term = rowheadSOP_5[i] + colheadSOP_5[j].Replace("-", "");
                        Console.WriteLine("TERM: " + term);
                        int temp_len = 0;
                        for (int k = 0; k < raw_epi.Length; k++)
                        {
                            if (raw_epi[k] != '-')
                            {
                                if (raw_epi[k] == term[k]) temp_len++;
                            }
                        }
                        if (temp_len == len) grp.Add(Convert.ToInt32(term, 2));
                    }
                }
            }

            return grp;
        }
        string rawEPIComp(string raw_epi)
        {
            string ans="";
            for(int i=0;i<raw_epi.Length;i++)
            {
                if (raw_epi[i] == '-') ans += '-';
                else if (raw_epi[i] == '1') ans += '0';
                else ans += '1';
            }
            return ans;
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }
    }
}
