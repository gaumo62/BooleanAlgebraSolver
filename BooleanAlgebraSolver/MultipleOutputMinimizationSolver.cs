using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BooleanAlgebraSolver
{
    public class MINOUTPUT
    {
        public List<string> Y1 = new List<string>();
        public List<string> Y2 = new List<string>();
        public List<string> C = new List<string>();
        public int tc = 0;
        public MINOUTPUT()
        {

        }
        public MINOUTPUT(MINOUTPUT a)
        {
            this.Y1 = new List<string>(a.Y1);
            this.Y2 = new List<string>(a.Y2);
            this.C = new List<string>(a.C);
            this.tc = a.tc;
        }
    }

    public class MultipleOutputMinimizationSolver
    {
        public int variables;
        public List<int> function1 = new List<int>(), function2 = new List<int>();
        public List<MINOUTPUT> answer = new List<MINOUTPUT>();
        public string dis = "";
        public MultipleOutputMinimizationSolver(int var, List<int> func1, List<int> func2)
        {
            this.variables = var;
            this.function1 = new List<int>(func1);
            this.function2 = new List<int>(func2);
        }
        private string VECTOSTR(List<int> mt)
        {
            int N = int.Parse(Math.Pow(2, variables).ToString());
            string ans = new string('0', N);
            for (int i = 0; i < mt.Count; i++)
            {
                ans = ans.Remove(mt[i], 1).Insert(mt[i], "1");
            }
            return ans;
        }
        private int BINTODEC(string s)
        {
            int n = 0;
            s.Reverse();

            for (int i = 0; i < s.Length; i++)
                if (s[i] == '1')
                    n += int.Parse(Math.Pow(2, i).ToString());
            return n;
        }
        private List<int> STRTOVEC(string s)
        {
            int n = s.Length;
            List<int> ans = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    ans.Add(i);
                }
            }
            return ans;
        }
        MINOUTPUT COST(MINOUTPUT a)
        {
            int g = 0, ng = 0;
            for(int i=0;i<a.Y1.Count;i++)
            {
                int term_length = 0;
                for(int j=0;j<a.Y1[i].Length;j++)
                {
                    if (a.Y1[i][j] != '-') term_length++;
                }
                if(term_length>1)
                {
                    g += term_length;
                    ng++;
                }
            }
            for (int i = 0; i < a.Y2.Count; i++)
            {
                int term_length = 0;
                for (int j = 0; j < a.Y2[i].Length; j++)
                {
                    if (a.Y2[i][j] != '-') term_length++;
                }
                if (term_length > 1)
                {
                    g += term_length;
                    ng++;
                }
            }
            for (int i = 0; i < a.C.Count; i++)
            {
                int term_length = 0;
                for (int j = 0; j < a.C[i].Length; j++)
                {
                    if (a.C[i][j] != '-') term_length++;
                }
                if (term_length > 1)
                {
                    g += term_length;
                    ng++;
                }
            }

            if(a.Y1.Count+a.C.Count>1)
            {
                g += a.Y1.Count + a.C.Count;
                ng++;
            }
            if (a.Y2.Count + a.C.Count > 1)
            {
                g += a.Y2.Count + a.C.Count;
                ng++;
            }
            a.tc = g + ng;
            //Console.WriteLine("Cost: " + a.tc.ToString());
            return a;
            #region
            //int l1 = 0, t1 = 0;
            //for (int i = 0; i < a.C.Count; i++)
            //{
            //    int cnt = 0;
            //    for (int j = 0; j < a.C[i].Length; j++)
            //    {
            //        if (a.C[i][j] != '-')
            //        {
            //            ++cnt;
            //            ++l1;
            //        }
            //    }
            //    if (cnt > 1) t1 += 3;
            //}
            //for (int i = 0; i < a.Y1.Count; i++)
            //{
            //    int cnt = 0;
            //    for (int j = 0; j < a.Y1[i].Length; j++)
            //    {
            //        if (a.Y1[i][j] != '-')
            //        {
            //            ++cnt;
            //            ++l1;
            //        }
            //    }
            //    if (cnt > 1) t1 += 2;
            //}
            //for (int i = 0; i < a.Y2.Count; i++)
            //{
            //    int cnt = 0;
            //    for (int j = 0; j < a.Y2[i].Length; j++)
            //    {
            //        if (a.Y2[i][j] != '-')
            //        {
            //            ++cnt;
            //            ++l1;
            //        }
            //    }
            //    if (cnt > 1) t1 += 2;
            //}
            //a.tc = l1 + t1 + 2;
            //return a;
            #endregion
        }
        private List<MINOUTPUT> COSTUTILITY(List<List<string>> a, List<List<string>> b, List<List<string>> c)
        {
            List<MINOUTPUT> answer = new List<MINOUTPUT>();
            MINOUTPUT temp = new MINOUTPUT();
            List<string> empty = new List<string>();
            if (c.Count == 0)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    for (int j = 0; j < b.Count; j++)
                    {
                        temp.Y1 = new List<string>(a[i]);
                        temp.Y2 = new List<string>(b[j]);
                        temp.C = new List<string>(empty);
                        temp.tc = 0;
                        temp = COST(temp);
                        answer.Add(new MINOUTPUT(temp));
                    }
                }
                return answer;
            }

            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < b.Count; j++)
                {
                    for (int k = 0; k < c.Count; k++)
                    {
                        temp.Y1 = new List<string>(a[i]);
                        temp.Y2 = new List<string>(b[j]);
                        temp.C = new List<string>(c[k]);
                        temp.tc = 0;
                        temp = COST(temp);
                        answer.Add(new MINOUTPUT(temp));
                    }
                }
            }
            return answer;
        }
        List<MINOUTPUT> MINCOST(List<MINOUTPUT> A)
        {
            int cost = Int32.MaxValue;
            //Console.WriteLine("COSTS:");
            for (int i = 0; i < A.Count; i++)
            {
                cost = Math.Min(cost, A[i].tc);
                //Console.WriteLine(A[i].tc);
            }

            List<MINOUTPUT> answer = new List<MINOUTPUT>();

            for (int i = 0; i < A.Count; i++)
                if (A[i].tc == cost)
                    answer.Add(new MINOUTPUT(A[i]));

            return answer;
        }
        public void PRNMINOUTPUT()
        {
            Console.Write("\n");
            dis += "\n";
            for (int i = 0; i < answer.Count; i++)
            {
                List<List<string>> temp = new List<List<string>>();
                temp.Add(new List<string>(answer[i].Y1));
                temp.Add(new List<string>(answer[i].Y2));
                temp.Add(new List<string>(answer[i].C));
                //Console.WriteLine("TOTAL COST = " + answer[i].tc);
                QMSolver q = new QMSolver(temp);
                q.CONVERT();
                temp = new List<List<string>>();
                for (int j = 0; j < q.essentialPi.Count; j++)
                {
                    List<string> copy = new List<string>(q.essentialPi[j]);
                    temp.Add(new List<string>(copy));
                }
                answer[i].Y1 = new List<string>(temp[0]);
                answer[i].Y2 = new List<string>(temp[1]);
                answer[i].C = new List<string>(temp[2]);

                Console.Write("Y1 = ");
                dis += "Y1 = ";
                for (int j = 0; j < answer[i].C.Count; j++)
                {
                    Console.Write(answer[i].C[j] + " + ");
                    dis += answer[i].C[j] + " + ";
                }
                for (int j = 0; j < answer[i].Y1.Count; j++)
                {
                    Console.Write(answer[i].Y1[j] + " + ");
                    dis += answer[i].Y1[j] + " + ";
                }

                dis = dis.Substring(0, dis.Length - 2);
                Console.Write("\n");
                dis += "\n";

                Console.Write("Y2 = ");
                dis += "Y2 = ";
                for (int j = 0; j < answer[i].C.Count; j++)
                {
                    Console.Write(answer[i].C[j] + " + ");
                    dis += answer[i].C[j] + " + ";
                }

                for (int j = 0; j < answer[i].Y2.Count; j++)
                {
                    Console.Write(answer[i].Y2[j] + " + ");
                    dis += answer[i].Y2[j] + " + ";

                }
                dis = dis.Substring(0, dis.Length - 2);

                Console.Write("\n");
                dis += "\n";

                Console.WriteLine("Total Cost = " + answer[i].tc);
                Console.Write("\n");
                dis += "Total Cost = " + answer[i].tc+"\n\n";
            }
        }
        public void solve()
        {
            int N = int.Parse(Math.Pow(2, variables).ToString());
            string s1 = VECTOSTR(function1);
            string s2 = VECTOSTR(function2);

            List<int> empty = new List<int>();

            for (int i = 1; i < int.Parse(Math.Pow(2, N).ToString()); i++)
            {
                int mask = i, cnt = 0, f = 1;
                List<int> com = new List<int>();
                while (mask > 0)
                {
                    if (mask % 2 == 1)
                    {
                        if (s1[cnt] == '1' && s2[cnt] == '1') com.Add(cnt);
                        else
                        {
                            f = 0;
                            break;
                        }
                    }
                    cnt++;
                    mask = mask / 2;
                }

                if (f == 1)
                {
                    s1.Reverse();
                    int S1 = BINTODEC(s1);
                    s1.Reverse();

                    s2.Reverse();
                    int S2 = BINTODEC(s2);
                    s2.Reverse();

                    string sc = VECTOSTR(com);
                    sc.Reverse();
                    int SC = BINTODEC(sc);
                    sc.Reverse();
                    
                    //Console.WriteLine(S1.ToString() + " " + S2.ToString() + " "+ SC.ToString());

                    S1 = S1 ^ SC;
                    S2 = S2 ^ SC;

                    //Console.WriteLine(S1.ToString() + " " + S2.ToString() + " " + SC.ToString());

                    string ts1 = (new QMSolver(N)).DECTOBIN(S1);
                    string ts2 = (new QMSolver(N)).DECTOBIN(S2);
                    string tsc = (new QMSolver(N)).DECTOBIN(SC);
                    ts1 = new string(ts1.ToCharArray().Reverse().ToArray());
                    ts2 = new string(ts2.ToCharArray().Reverse().ToArray());
                    tsc = new string(tsc.ToCharArray().Reverse().ToArray());
                    //ts1 = ts1.Reverse();
                    //ts2 = ts2.Reverse();
                    //tsc.Reverse();

                    //Console.WriteLine(ts1 + " " + ts2 + " " + tsc);

                    List<int> t_mt1 = STRTOVEC(ts1);
                    List<int> t_mt2 = STRTOVEC(ts2);
                    List<int> t_mtc = STRTOVEC(tsc);
                    //Console.WriteLine("anaklakcsaklcmklasmcklasmcklasmckllasmkcmaskcmas");
                    //for (int j = 0; j < t_mt1.Count; j++) Console.Write(t_mt1[j] + " ");
                    //Console.Write("\n");
                    //for (int j = 0; j < t_mt2.Count; j++) Console.Write(t_mt2[j] + " ");
                    //Console.Write("\n");
                    //for (int j = 0; j < t_mtc.Count; j++) Console.Write(t_mtc[j] + " ");
                    //Console.Write("\n");

                    List<int> emp = new List<int>();

                    QMSolver q1 = new QMSolver(variables, t_mt1, emp), q2 = new QMSolver(variables, t_mt2, emp), q3 = new QMSolver(variables, t_mtc, emp);
                    q1.solve(false);
                    q2.solve(false);
                    q3.solve(false);
                    //q1.PRINT();
                    //q2.PRINT();
                    //q3.PRINT();


                    //Console.WriteLine("q1: ");
                    //for (int k = 0; k < q1.essentialPi.Count; k++)
                    //{
                    //    for (int j = 0; j < q1.essentialPi[k].Count; j++) Console.Write(q1.essentialPi[k][j] + " ");
                    //    Console.WriteLine("");
                    //}
                    //Console.WriteLine("q2: ");
                    //for (int k = 0; k < q2.essentialPi.Count; k++)
                    //{
                    //    for (int j = 0; j < q2.essentialPi[k].Count; j++) Console.Write(q2.essentialPi[k][j] + " ");
                    //    Console.WriteLine("");
                    //}
                    //Console.WriteLine("q3: ");
                    //for (int k = 0; k < q3.essentialPi.Count; k++)
                    //{
                    //    for (int j = 0; j < q3.essentialPi[k].Count; j++) Console.Write(q3.essentialPi[k][j] + " ");
                    //    Console.WriteLine("");
                    //}
                    List<MINOUTPUT> tempo = COSTUTILITY(q1.essentialPi, q2.essentialPi, q3.essentialPi);
                    for (int j = 0; j < tempo.Count; j++)
                        answer.Add(new MINOUTPUT(tempo[j]));
                }
            }

            //NO COMMON TERMS
            QMSolver qo1 = new QMSolver(variables, function1, empty), qo2 = new QMSolver(variables, function2, empty);
            qo1.solve(false);
            qo2.solve(false);
            //Console.WriteLine("qo1: ");
            //for (int k = 0; k < qo1.essentialPi.Count; k++)
            //{
            //    for (int j = 0; j < qo1.essentialPi[k].Count; j++) Console.Write(qo1.essentialPi[k][j] + " ");
            //    Console.WriteLine("");
            //}
            //Console.WriteLine("qo2: ");
            //for (int k = 0; k < qo2.essentialPi.Count; k++)
            //{
            //    for (int j = 0; j < qo2.essentialPi[k].Count; j++) Console.Write(qo2.essentialPi[k][j] + " ");
            //    Console.WriteLine("");
            //}
            List<List<string>> empty1 = new List<List<string>>();
            List<MINOUTPUT> temp = COSTUTILITY(qo1.essentialPi, qo2.essentialPi, empty1);
            for (int i = 0; i < temp.Count; i++)
                answer.Add(new MINOUTPUT(temp[i]));

            //Console.WriteLine("Answer before: " + answer.Count.ToString());
            answer = new List<MINOUTPUT>(MINCOST(answer));
            //Console.WriteLine("Answer After: " + answer.Count.ToString());

            //Console.WriteLine("FINAL COSTS:");
            //for(int i=0;i<answer.Count;i++)
            //{
            //    Console.Write(answer[i].tc.ToString());
            //    Console.WriteLine("");
            //}
        }
    }
}
