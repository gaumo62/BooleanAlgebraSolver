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
            Console.WriteLine(corrected_code);
            Console.WriteLine(hamming_decode);
        }
        public void display()
        {
            int n = CalcParityBits(code);

        }
    }
}
