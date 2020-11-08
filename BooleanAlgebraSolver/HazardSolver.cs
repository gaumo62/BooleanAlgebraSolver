using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanAlgebraSolver
{
	public class HazardSolver
	{
		public int variables;
		public List<string> expression = new List<string>();
		public List<string> ans = new List<string>();
		public List<string> raw_ans = new List<string>();
		public List<string> hz_vars = new List<string>();
		public List<Tuple<string, string>> hz_terms = new List<Tuple<string, string>>();
		public string vars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public int mode;
		public HazardSolver(int var, List<string> exp, int m)
		{
			this.variables = var;
			this.expression = new List<string>(exp);
			this.mode = m;
			this.hz_vars = new List<string>();
		}
		private Tuple<int, string> is_adjacent(string t1, string t2)
		{
			int sum = 0;
			int jack = 0;
			for (int i = 0; i < variables; i++)
			{
				// check each character of both term contents
				char c1 = t1[i];
				char c2 = t2[i];
				if (c1 == '_' || c2 == '_') sum = sum + 0;
				else if (c1 != c2) sum = sum + 1;
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
						if (c1 == c2) val = val + '_';
						else
						{
							if (c1 == '_') val = val + c2;
							else val = val + c1;
						}
					}
					else
					{
						if (c1 == c2) val = val + c1;
						else
						{
							val = val + '_';
							// the variable with error
							jack = i + 1;
						}
					}
				}
				// we check if any other term already present in the expression compensates this hazard
				int flag = 1; // 1 indicates term contains compensation term within it
				for (int i = 0; i < this.expression.Count; i++)
				{
					string term = this.expression[i];
					if (t1 == term) continue;
					if (t2 == term) continue;
					for (int j = 0; j < variables; j++)
					{
						// check each character of both term contents
						char c1 = val[j]; // our term character
						char c2 = term[j]; // check term's character
						if (c2 == '_') continue;
						else if (c1 != c2) { flag = 1; break; } // a different aspect of same variable indicates both terms are different
						else flag = 0;
					}
					if (flag == 0) break;
				}
				if (flag == 0) return new Tuple<int, string>(0, "");
				else
				{
					return new Tuple<int, string>(jack, val);
				}
				//end of check
			}
			else
			{
				return new Tuple<int, string>(jack, "");
			}
		}
		public string val2altval(string val)
		{
			string vars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string ans = "";
			for (int i = 0; i < val.Length; i++)
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
		public string val2altval1(string val)
		{
			string vars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string ans = "";
			for (int i = 0; i < val.Length; i++)
			{
				if (val[i] == '1')
				{
					if (ans!="") ans = ans + " + ";
					ans = ans + vars[i];
					ans = ans + "\'";
				}
				else if (val[i] == '0')
				{
					if (ans!="") ans = ans + " + ";
					ans = ans + vars[i];
				}
			}
			return ans;
		}
		private void generate(string t1, string t2)
		{
			Tuple<int, string> retval;
			retval = this.is_adjacent(t1, t2);
			if (retval.Item1 != 0)
			{
				if (mode == 1) this.ans.Add(this.val2altval(retval.Item2));
				else if (mode == 0) this.ans.Add(this.val2altval1(retval.Item2));
				this.raw_ans.Add(retval.Item2);
				this.hz_vars.Add(this.vars[retval.Item1 - 1].ToString());
				this.hz_terms.Add(new Tuple<string, string>(t1, t2));
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
			if (mode == 0)
			{
				for (int i = 0; i < ans.Count; i++)
				{
					if (ans[i][0] == '+') ans[i] = ans[i].Remove(0, 1);
				}
			}

			//TEMP PRINT CODE
			if (raw_ans.Count == 0) Console.WriteLine("NO HAZARD DETECTED!");
			else Console.WriteLine("HAZARD DETECTED!");
			Console.WriteLine("Raw hazard cover");
			for (int i = 0; i < raw_ans.Count; i++)
			{
				Console.Write(raw_ans[i] + " ");
			}
			Console.WriteLine("\nHazard cover");
			for (int i = 0; i < ans.Count; i++)
			{
				Console.WriteLine(ans[i] + " ");
			}
			Console.WriteLine("Hazard Terms: ");
			for (int i = 0; i < hz_vars.Count; i++)
			{
				Console.WriteLine(hz_vars[i] + ": " + hz_terms[i].Item1 + " " + hz_terms[i].Item2);
			}
		}
	}
}
