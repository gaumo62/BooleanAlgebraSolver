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
    public partial class HazardOutput : Form
    {
        public HazardOutput(HazardSolver hs, Label exp)
        {
            InitializeComponent();
            this.noofvarLabel.Text = "Number of variables: " + hs.variables.ToString();
            this.modeLabel.Text = "Static " + hs.mode.ToString() + " Hazard";
            this.expressionLabel.Text = exp.Text;
            if(hs.hz_terms.Count==0)
            {
                titleLabel.Text = "NO HAZARD FOUND!!";
            }
            
            for(int i=0,j=0;i<Math.Ceiling((decimal)hs.hz_vars.Count/2);i++,j+=2)
            {
                if (i > 0)
                {
                    tableLayoutPanel1.RowCount += 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                string terms1;
                if(hs.mode==1)
                {
                    terms1 = hs.val2altval(hs.hz_terms[j].Item1) + " + " + hs.val2altval(hs.hz_terms[j].Item2);
                }
                else
                {
                    terms1 = "(" + hs.val2altval1(hs.hz_terms[j].Item1) + ").(" + hs.val2altval1(hs.hz_terms[j].Item2) + ")";
                }
                Label l1 = new Label() { Text = "\nHazardous Terms: " + terms1 + "\n\nHazardous Variable: " + hs.hz_vars[j] + "\n\n" };
                l1.AutoSize = true;
                Font f = new Font(FontFamily.GenericSansSerif,12,FontStyle.Regular);
                l1.Font = f;
                tableLayoutPanel1.Controls.Add(l1, 0, tableLayoutPanel1.RowCount - 1);

                if(j+1<hs.hz_vars.Count)
                {
                    string terms2;
                    if (hs.mode == 1)
                    {
                        terms2 = hs.val2altval(hs.hz_terms[j + 1].Item1) + " + " + hs.val2altval(hs.hz_terms[j + 1].Item2);
                    }
                    else
                    {
                        terms2 = "(" + hs.val2altval1(hs.hz_terms[j + 1].Item1) + ").(" + hs.val2altval1(hs.hz_terms[j + 1].Item2) + ")";
                    }
                    Label l2 = new Label() { Text = "\nHazardous Terms: " + terms2 + "\n\nHazardous Variable: " + hs.hz_vars[j + 1] + "\n\n" };
                    l2.AutoSize = true;
                    l2.Font = f;
                    tableLayoutPanel1.Controls.Add(l2, 1, tableLayoutPanel1.RowCount - 1);
                }
                //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            }
            for (int i = 0; i < hs.ans.Count; i++) coverLabel.Text += " (" + hs.ans[i] + "),";
            coverLabel.Text = coverLabel.Text.Substring(0, coverLabel.Text.Length - 1); ;
            finalExpLabel.Text += expressionLabel.Text.Substring(18,expressionLabel.Text.Length-18);
            if(hs.mode==1)
            {
                for(int i=0;i<hs.ans.Count;i++) finalExpLabel.Text += " + " + hs.ans[i];
            }
            else
            {
                for (int i = 0; i < hs.ans.Count; i++) finalExpLabel.Text += "(" + hs.ans[i] + ")";
            }

        }
    }
}
