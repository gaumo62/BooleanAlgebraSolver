using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanAlgebraSolver
{
    class HazardSolver
    {
        public int variables;
        public List<string> expression = new List<string>();
        public List<string> ans = new List<string>();
        public List<string> raw_ans = new List<string>();
		public int mode;
        public HazardSolver(int var, List<string> exp, int m)
        {
            this.variables = var;
            this.expression = new List<string>(exp);
			this.mode = m;
        }
		private Tuple<int, string> is_adjacent(string t1, string t2)
		{
			int sum = 0;
			for (int i = 0; i < variables; i++)
			{
				// check each character of both term contents
				char c1 = t1[i];
				char c2 = t2[i];
				if (c1 == '_' || c2 == '_')	sum = sum + 0;
				else if (c1 != c2)	sum = sum + 1;
			}
			string val = "";
			if (sum == 1)
			{
				for (int i = 0; i < variables; i++)
				{
					// check each character of both term contents
					char c1 = t1[i];
					char c2 = t2[i];
					if (c1 == '_' || c2 == '_')
					{
						if (c1 == c2)	val = val + '_';
						else
						{
							if (c1 == '_')	val = val + c2;
							else	val = val + c1;
						}
					}
					else
					{
						if (c1 == c2)	val = val + c1;
						else	val = val + '_';
					}
				}
				return new Tuple<int, string>(1, val);
			}
			else
			{
				return new Tuple<int, string>(0, "");
			}
		}
		private string val2altval(string val)
		{
			string vars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string ans = "";
			for(int i=0;i<val.Length;i++)
			{
				if (val[i] == '1')
				{
					ans = ans + vars[i];
				}
				else if (val[i] == '0')
				{
					ans = ans + vars[i];
					ans = ans + "\'";
				}
			}
			return ans;
		}
		private string val2altval1(string val)
		{
			string vars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string ans = "";
			for (int i = 0; i < val.Length; i++)
			{
				if (val[i] == '1')
				{
					if (i > 0) ans = ans + "+";
					ans = ans + vars[i];
					ans = ans + "\'";
				}
				else if (val[i] == '0')
				{
					if (i > 0) ans = ans + "+";
					ans = ans + vars[i];
				}
			}
			return ans;
		}
		private void generate(string t1, string t2)
        {
			Tuple<int, string> retval;
            retval = this.is_adjacent(t1, t2);
		    if(retval.Item1 == 1)
            {
			    if(mode==1) this.ans.Add(this.val2altval(retval.Item2));
				else if(mode==0) this.ans.Add(this.val2altval1(retval.Item2));
				this.raw_ans.Add(retval.Item2);
		    }
			else
			{

			}
        }
    public void solve()
        {
            for (int i = 0; i < this.expression.Count; i++)
            {
                string term1 = this.expression[i];
                for (int j = i + 1; j < this.expression.Count; j++)
                {
                    string term2 = this.expression[j];
                    this.generate(term1, term2);
                }
            }
			if(mode==0)
			{
				for(int i=0;i<ans.Count;i++)
				{
					if (ans[i][0] == '+') ans[i] = ans[i].Remove(0, 1);
				}
			}

			//TEMP PRINT CODE
			for (int i = 0; i < raw_ans.Count; i++)
			{
				Console.Write(raw_ans[i] + " ");
			}
			Console.Write("\n");
			for (int i = 0; i < ans.Count; i++)
			{
				Console.WriteLine(ans[i] + " ");
			}
		}
    }
}
