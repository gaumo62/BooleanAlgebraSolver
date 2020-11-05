using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BooleanAlgebraSolver
{
    class ROW
    {
        public string s;
        public List<int> minTermsIncluded;
        public int isTicked;
        public ROW()
        {
            this.s = "";
            this.isTicked = 0;
            this.minTermsIncluded = new List<int>();
        }
        public ROW(string str, int mti)
        {
            this.s = str;
            this.isTicked = 0;
            this.minTermsIncluded = new List<int>();
            this.minTermsIncluded.Add(mti);
        }
        public ROW(ROW r)
        {
            this.s = r.s;
            this.isTicked = r.isTicked;
            this.minTermsIncluded = new List<int>(r.minTermsIncluded);
        }
    }
    class STAGE
    {
        public List<List<ROW>> rows;
        public STAGE(STAGE s)
        {
            rows = new List<List<ROW>>(); 
            for (int i = 0; i < s.rows.Count; i++)
            {
                List<ROW> copy = s.rows[i].Select(row => new ROW(row)).ToList();
                this.rows.Add(new List<ROW>(copy));
            }
        }
        public STAGE()
        {
            this.rows = new List<List<ROW>>();
        }
    }

    class QMSolver
    {
        public int variables;
        public List<int> minterms_orig = new List<int>(); //Original minterms
        public List<int> dontcares = new List<int>();
        public List<int> minTerms = new List<int>();  //Minterms + DC
        public List<STAGE> stages = new List<STAGE>();
        public List<Tuple<string, List<int>>> primeImplicant = new List<Tuple<string, List<int>>>();
        public List<List<string>> essentialPi = new List<List<string>>();
        public QMSolver(int var)
        {
            this.variables = var;
        }
        public QMSolver(List<List<string>> epi)
        {
            for (int i = 0; i < epi.Count; i++)
            {
                List<string> copy = new List<string>(epi[i]);
                essentialPi.Add(new List<string>(copy));
            }
            //Console.WriteLine("INSIDE: ");
            //for (int j = 0; j < essentialPi.Count; j++)
            //{
            //    for (int k = 0; k < essentialPi[j].Count; k++)
            //    {
            //        Console.Write(essentialPi[j][k]);
            //    }
            //    Console.Write("\n");
            //}
        }
        public QMSolver(int var, List<int> mint, List<int> dc)
        {
            this.variables = var;
            this.minterms_orig = new List<int>(mint);
            this.minTerms = new List<int>(mint);
            this.dontcares = new List<int>(dc);
        }

        private void MERGE()
        {
            for (int i = 0; i < this.dontcares.Count; i++)
            {
                minTerms.Add(dontcares[i]);
            }
            minTerms.Sort();
        }
        public string DECTOBIN(int num)
        {
            string binary = Convert.ToString(num, 2);
            while (binary.Length != variables) binary = "0" + binary;
            return binary;
        }
        int COUNTONE(string binary)
        {
            int count = 0;
            for(int i=0;i<binary.Length;i++)
            {
                if (binary[i] == '1') count++;
            }
            return count;
        }
        private int CHECK(string s1, string s2)
        {
            int cnt = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                    cnt++;
            }
            if (cnt == 1) return 1;
            return 0;
        }
        private ROW MERGEROW(ROW r1, ROW r2)
        {
            ROW mergedRow = new ROW(r1);
            for (int i = 0; i < variables; i++)
            {
                if (r1.s[i] != r2.s[i])
                {
                    mergedRow.s = mergedRow.s.Remove(i, 1).Insert(i, "-");
                    break;
                }
            }
            for (int i = 0; i < (r2.minTermsIncluded).Count; i++)
            {
                mergedRow.minTermsIncluded.Add(r2.minTermsIncluded[i]);
            }
            mergedRow.isTicked = 0;
            return mergedRow;
        }
        public void PRINT()
        {
            //Console.Write("Stages Count: " + stages.Count+"\n");
            for (int i = 0; i < stages.Count; i++)
            {
                Console.Write("STAGE " + (i + 1).ToString() + ":\n\n");
                List<List<ROW>> rows = new List<List<ROW>>(stages[i].rows);
                for (int j = 0; j < rows.Count; j++)
                {
                    for (int k = 0; k < rows[j].Count; k++)
                    {
                        Console.Write(rows[j][k].s + "   ");
                        Console.Write("isTICKED?" + " " + rows[j][k].isTicked + "    ");
                        List<int> t =new List<int>(rows[j][k].minTermsIncluded);
                        for (int l = 0; l < t.Count; l++)
                        {
                            Console.Write(t[l] + " ");
                        }
                        Console.Write("\n");
                    }
                    Console.Write("\n");
                }
                Console.Write("_______________________________________________________\n");
                Console.Write("\n");
            }

            //UNIQUE PI
            Console.Write("\nUnique PI:\n ");
            Console.WriteLine(primeImplicant.Count);
            for (int i = 0; i < primeImplicant.Count; i++)
            {
                Console.Write(primeImplicant[i].Item1 + ": ");
                for (int j = 0; j < primeImplicant[i].Item2.Count; j++)
                {
                    Console.Write(primeImplicant[i].Item2[j] + " ");
                }
                Console.Write("\n");
            }

            //ESSENTIAL PI
            Console.Write("\nEssestial PI:\n ");
            for (int i = 0; i < essentialPi.Count; i++)
            {
                Console.Write("Y = " + essentialPi[i][0].ToString());
                for (int j = 1; j < essentialPi[i].Count; j++) Console.Write(" + " + (essentialPi[i][j]).ToString());
                Console.Write("\n");
            }
        }
        public void UNIQUE()
        {
            Dictionary<string, List<int>> m = new Dictionary<string, List<int>>();
            for (int k = 0; k < stages.Count; k++)
            {
                for (int i = 0; i < stages[k].rows.Count; i++)
                {
                    for (int j = 0; j < stages[k].rows[i].Count; j++)
                    {
                        if (stages[k].rows[i][j].isTicked == 0)
                        {
                            
                            if (m.ContainsKey(stages[k].rows[i][j].s) == false)
                            {
                                m[stages[k].rows[i][j].s] = new List<int>(stages[k].rows[i][j].minTermsIncluded);
                            }
                        }
                    }
                }
            }
            foreach (KeyValuePair<string, List<int>> entry in m)
            {
                this.primeImplicant.Add(new Tuple<string, List<int>>(entry.Key, new List<int>(entry.Value)));
            }
        }
        void ESSENTIALPI()
        {
            int N = primeImplicant.Count;
            string required="";
            for (int i = 0; i < Math.Pow(2, variables); i++) required += "0";

            for (int i = 0; i < minterms_orig.Count; i++)
            {
                required = required.Remove(minterms_orig[i], 1).Insert(minterms_orig[i], "1");
            }

            List<List<string>> finalAns = new List<List<string>>();
            if (N == 0) return;

            for (int i = 0; i < Math.Pow(2, N); i++)
            {
                int key = i;
                int cnt = 0;
                string curans="";
                for (int k = 0; k < Math.Pow(2, variables); k++) curans += "0";
                List<string> ans = new List<string>();
                while (key > 0)
                {
                    if (key % 2 == 1)
                    {
                        string temp = primeImplicant[cnt].Item1;
                        List<int> temp2 = new List<int>(primeImplicant[cnt].Item2);
                        for (int j = 0; j < temp2.Count; j++)
                        {
                            if (required[temp2[j]] == '1') curans = curans.Remove(temp2[j], 1).Insert(temp2[j], "1");
                        }
                        ans.Add(temp);
                    }

                    key = key / 2;
                    cnt++;
                }

                if (curans == required)
                {
                    finalAns.Add(new List<string>(ans));
                }
            }

            int minCount = N;
            for(int i=0;i<finalAns.Count;i++) minCount = Math.Min(minCount, (int) finalAns[i].Count);

            for(int i=0;i<finalAns.Count;i++)
            {
                if((int) finalAns[i].Count==minCount) essentialPi.Add(new List<string>(finalAns[i]));
            }
        }
        public void CONVERT()
        {
            for (int i = 0; i < essentialPi.Count; i++)
            {
                for (int j = 0; j < essentialPi[i].Count; j++)
                {
                    string t1 = essentialPi[i][j];
                    string t2="";
                    for (int k = 0; k < t1.Length; k++)
                    {
                        if (t1[k] != '-')
                        {
                            t2+=(char)('A' + k);
                            if (t1[k] == '0') t2+='\'';
                        }
                    }
                    essentialPi[i][j] = t2;
                }
            }
        }
        private void PRINTSTAGE(STAGE s)
        {
            for (int i = 0; i < s.rows.Count; i++)
            {
                for (int j = 0; j < s.rows[i].Count; j++)
                {
                    Console.Write(s.rows[i][j].s + "   ");
                    Console.Write("isTICKED?" + " " + s.rows[i][j].isTicked + "    ");
                    List<int> t = s.rows[i][j].minTermsIncluded;
                    for (int l = 0; l < t.Count; l++)
                    {
                        Console.Write(t[l] + " ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            }
        }
        public void solve(bool convert = true)
        {
            if (minterms_orig.Count == 0) return;
            MERGE();

            List<Tuple<int, ROW>> stage0 = new List<Tuple<int, ROW>>();
            STAGE tStage = new STAGE();
            List<ROW> temp = new List<ROW>(), temp1 = new List<ROW>(), temp2 = new List<ROW>();
            List<List<ROW>> tRows = new List<List<ROW>>(), curRows = new List<List<ROW>>();
            List<List<ROW>> newRows = new List<List<ROW>>();

            for (int i = 0; i < minTerms.Count; i++)
            {
                int countOne = COUNTONE(DECTOBIN(minTerms[i]));
                stage0.Add(new Tuple<int, ROW>(countOne, new ROW(DECTOBIN(minTerms[i]), minTerms[i])));
            }

            stage0.Sort((x, y) => (y.Item1.CompareTo(x.Item1)));
            stage0.Reverse();

            temp.Add(new ROW(stage0[0].Item2));
            for (int i = 1; i < stage0.Count; i++)
            {
                if (stage0[i].Item1 == stage0[i - 1].Item1) temp.Add(new ROW(stage0[i].Item2));
                else
                {
                    tRows.Add(new List<ROW>(temp));
                    temp.Clear();
                    temp.Add(new ROW(stage0[i].Item2));
                }
            }

            tRows.Add(new List<ROW>(temp));
            tStage.rows = tRows;
            tStage.rows = tRows.Select(x => x.ToList()).ToList();
            for(int i=0;i<tStage.rows.Count;i++)
            {
                tStage.rows[i].Reverse();
            }

            stages.Add(new STAGE(tStage));
            int mainFlag;
            while (true)
            {
                tStage.rows.Clear();
                STAGE curStage = new STAGE(stages[stages.Count - 1]);
                stages.RemoveAt(stages.Count - 1);
                curRows = new List<List<ROW>>();
                for (int i = 0; i < curStage.rows.Count; i++)
                {
                    List<ROW> copy = curStage.rows[i].Select(row => new ROW(row)).ToList();
                    curRows.Add(new List<ROW>(copy));
                }

                mainFlag = 0;
                newRows.Clear();
                for (int i = 1; i < curRows.Count; i++)
                {
                    temp2.Clear();
                    for (int j = 0; j < curRows[i - 1].Count; j++)
                    {
                        for (int k = 0; k < curRows[i].Count; k++)
                        {
                            int flag = CHECK(curRows[i - 1][j].s, curRows[i][k].s);
                            if (flag == 1)
                            {
                                mainFlag = 1;
                                ROW tRow = new ROW(MERGEROW(curRows[i - 1][j], curRows[i][k]));
                                curRows[i - 1][j].isTicked = 1;
                                curRows[i][k].isTicked = 1;
                                temp2.Add(new ROW(tRow));

                            }
                        }
                    }
                    newRows.Add(new List<ROW>(temp2));
                }

                for (int i = 0; i < newRows.Count; i++)
                {
                    List<ROW> copy = newRows[i].Select(row => new ROW(row)).ToList();
                    tStage.rows.Add(new List<ROW>(copy));
                }
                for (int i = 0; i < curRows.Count; i++)
                {
                    List<ROW> copy = curRows[i].Select(row => new ROW(row)).ToList();
                    curStage.rows.Add(new List<ROW>(copy));
                }
                stages.Add(new STAGE(curStage));

                if (mainFlag == 0)
                    break;

                stages.Add(new STAGE(tStage));
            }

            for (int i = 0; i < stages.Count; i++)
            {
                stages[i].rows.RemoveRange(0, stages[i].rows.Count / 2);
            }

            UNIQUE();
            ESSENTIALPI();
            if(convert) CONVERT();
        }
    }
}
