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
    public partial class CodeConversion : Form
    {
        private readonly string[] val5211 = { "0000", "0001", "0011", "0101", "0111", "1000", "1010", "1100", "1110", "1111" };
        private readonly string[] val8421 = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001" };
        private readonly string[] val2421 = { "0000", "0001", "0010", "0011", "0100", "1011", "1100", "1101", "1110", "1111" };
        private readonly string[] valxs3 = { "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100" };

        public CodeConversion()
        {
            InitializeComponent();
        }

        bool preprocessing(TextBox t, bool code = true)
        {
            if (t.Text.Trim().Length == 0) return false;
            if(code)
            {
                if (t.Text.Trim().Length % 4 != 0)
                {
                    MessageBox.Show("The input code length should be a multiple of 4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            for (int i = 0; i < t.Text.Trim().Length; i++)
            {
                if (t.Text.Trim()[i] != '0' && t.Text.Trim()[i] != '1')
                {
                    MessageBox.Show("Wrong input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            clearallTB();
            return true;
        }
        void clearallTB()
        {
            opDecimalTB.Text = "";
            opBinaryTB.Text = "";
            op2421TB.Text = "";
            op5211TB.Text = "";
            op8421TB.Text = "";
            opGrayCodeTB.Text = "";
            opxs3TB.Text = "";
            ipDecimalTB.BackColor = Color.White;
            ipBinaryTB.BackColor = Color.White;
            ip2421TB.BackColor = Color.White;
            ip5211TB.BackColor = Color.White;
            ip8421TB.BackColor = Color.White;
            ipGrayCodeTB.BackColor = Color.White;
            ipxs3TB.BackColor = Color.White;
        }
        
        //To Decimal
        long code8421_to_dec(string s)
        {
            long ans = 0;
            int n = s.Length / 4;
            for (int i = 0; i < s.Length; i += 4)
            {
                if(val8421.Contains(s.Substring(i,4))==false)
                {
                    MessageBox.Show("Invalid 8421 (BCD) Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                ans += Convert.ToInt64(Math.Pow(10, n - 1) * (Convert.ToInt32(s.Substring(i, 4), 2)));
                n--;
            }
            return ans;
        }
        long code2421_to_dec(string s)
        {
            long ans = 0;
            int n = s.Length / 4;
            for (int i = 0; i < s.Length; i += 4)
            {
                if (val2421.Contains(s.Substring(i, 4)) == false)
                {
                    MessageBox.Show("Invalid 2421 Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                int val = Convert.ToInt32(s.Substring(i, 4), 2);
                if (val > 4) val -= 6;
                ans += Convert.ToInt64(Math.Pow(10, n - 1) * (val));
                n--;
            }
            return ans;
        }
        long code5211_to_dec(string s)
        {
            long ans = 0;
            int n = s.Length / 4;
            for (int i = 0; i < s.Length; i += 4)
            {
                if (val5211.Contains(s.Substring(i, 4)) == false)
                {
                    MessageBox.Show("Invalid 5211 Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                int val = Convert.ToInt32(s.Substring(i, 4), 2);
                if (val >= 14) val -= 6;
                else if (val == 12) val = 7;
                else if (val == 10) val = 6;
                else if (val == 8) val = 5;
                else val = (val + 1) / 2;
                ans += Convert.ToInt64(Math.Pow(10, n - 1) * (val));
                n--;
            }
            return ans;
        }
        long XS3_to_dec(string s)
        {
            long ans = 0;
            int n = s.Length / 4;
            for (int i = 0; i < s.Length ; i += 4)
            {
                if (valxs3.Contains(s.Substring(i, 4)) == false)
                {
                    MessageBox.Show("Invalid XS-3 Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                ans += Convert.ToInt64(Math.Pow(10, n - 1) * (Convert.ToInt32(s.Substring(i, 4), 2) - 3));
                n--;
            }
            return ans;
        }
        long gray_to_dec(string s)
        {
            string ans = s;
            for (int i = 1; i < s.Length; i++)
            {
                ans = ans.Remove(i, 1).Insert(i, (int.Parse(s[i].ToString()) ^ int.Parse(ans[i - 1].ToString())).ToString());
            }
            long val = Convert.ToInt64(ans, 2); //bin to decimal
            return val;
        }
        long binary_to_dec(string s)
        {
            return Convert.ToInt64(s, 2);
        }

        //Decimal to other 
        string dec_to_code8421(long n)
        {
            string ans="";
            long temp = n;
            while (temp > 0)
            {
                int digit = Convert.ToInt32(temp % 10);
                string s = Convert.ToString(digit, 2);
                while (s.Length != 4) s = "0" + s;
                s += ans;
                ans = s;
                temp /= 10;
            }
            for(int i=4;i<ans.Length;i+=5)  ans = ans.Insert(i, "-");
            return ans;
        }
        string dec_to_code2421(long n)
        {
            string ans="";
            long temp = n;
            while (temp > 0)
            {
                int digit = Convert.ToInt32(temp % 10);
                if (digit > 4) digit += 6;
                string s = Convert.ToString(digit, 2);
                while (s.Length != 4) s = "0" + s;
                s += ans;
                ans = s;
                temp /= 10;
            }
            for(int i=4;i<ans.Length;i+=5)  ans = ans.Insert(i, "-");
            return ans;
        }
        string dec_to_code5211(long n)
        {
            string ans="";
            long temp = n;
            while (temp > 0)
            {
                int digit = Convert.ToInt32(temp % 10);
                string s = val5211[digit];
                s += ans;
                ans = s;
                temp /= 10;
            }
            for(int i=4;i<ans.Length;i+=5)  ans = ans.Insert(i, "-");
            return ans;
        }
        string dec_to_XS3(long n)
        {
            string ans="";
            long temp = n;
            while (temp > 0)
            {
                int digit = Convert.ToInt32(temp % 10) + 3;
                string s = Convert.ToString(digit, 2);
                while (s.Length != 4) s = "0" + s;
                s += ans;
                ans = s;
                temp /= 10;
            }
            for(int i=4;i<ans.Length;i+=5)  ans = ans.Insert(i, "-");
            return ans;
        }
        string dec_to_gray(long n)
        {
            string ans = "", bin="";
            long temp = n;
            while (temp > 0)
            {  //decimal to binary
                char s = (temp % 2).ToString()[0];
                bin = bin.Insert(0, s.ToString());
                temp /= 2;
            }
            ans = bin;
            for (int i = 1; i < bin.Length; i++)
            {   //binary to gray
                ans = ans.Remove(i, 1).Insert(i, (int.Parse(bin[i].ToString()) ^ int.Parse(bin[i - 1].ToString())).ToString());
            }
            while (ans.Length %4 !=0) ans = "0" + ans;
            return ans;
        }
        string dec_to_binary(long n)
        {
            return Convert.ToString((long)n, 2);
        }
        
        //Clicks
        private void conv8421Button_Click(object sender, EventArgs e)
        {
            if (!preprocessing(ip8421TB)) return;

            //Convert to decimal
            long dec = code8421_to_dec(ip8421TB.Text.Trim());
            if (dec == -1) return;
            //All conversions
            opDecimalTB.Text = dec.ToString();
            opBinaryTB.Text = dec_to_binary(dec);
            op2421TB.Text = dec_to_code2421(dec);
            op5211TB.Text = dec_to_code5211(dec);
            opxs3TB.Text = dec_to_XS3(dec);
            opGrayCodeTB.Text = dec_to_gray(dec);
            if(dec==0)
            {
                string zeros = "";
                while (zeros.Length % 4 != 0 || zeros.Length == 0) zeros += "0";
                op2421TB.Text = zeros;
                op5211TB.Text = zeros;
                opxs3TB.Text = zeros;
            }

            op8421TB.Text = ip8421TB.Text.Trim();
            ip8421TB.BackColor = Color.LightGreen;
        }
        private void conv2421Button_Click(object sender, EventArgs e)
        {
            if (!preprocessing(ip2421TB)) return;

            //Convert to decimal
            long dec = code2421_to_dec(ip2421TB.Text.Trim());
            if (dec == -1) return;
            Console.WriteLine("Decimal: " + dec.ToString());
            //All conversions
            opDecimalTB.Text = dec.ToString();
            opBinaryTB.Text = dec_to_binary(dec);
            op8421TB.Text = dec_to_code8421(dec);
            op5211TB.Text = dec_to_code5211(dec);
            opxs3TB.Text = dec_to_XS3(dec);
            opGrayCodeTB.Text = dec_to_gray(dec);
            if (dec == 0)
            {
                string zeros = "";
                while (zeros.Length % 4 != 0 || zeros.Length == 0) zeros += "0";
                op8421TB.Text = zeros;
                op5211TB.Text = zeros;
                opxs3TB.Text = zeros;
            }

            op2421TB.Text = ip2421TB.Text.Trim();
            ip2421TB.BackColor = Color.LightGreen;
        }
        private void conv5211Button_Click(object sender, EventArgs e)
        {
            if (!preprocessing(ip5211TB)) return;

            //Convert to decimal
            long dec = code5211_to_dec(ip5211TB.Text.Trim());
            Console.WriteLine("Decimal: " + dec.ToString());
            //All conversions
            opDecimalTB.Text = dec.ToString();
            opBinaryTB.Text = dec_to_binary(dec);
            op8421TB.Text = dec_to_code8421(dec);
            op2421TB.Text = dec_to_code2421(dec);
            opxs3TB.Text = dec_to_XS3(dec);
            opGrayCodeTB.Text = dec_to_gray(dec);
            if (dec == 0)
            {
                string zeros = "";
                while (zeros.Length % 4 != 0 || zeros.Length == 0) zeros += "0";
                op8421TB.Text = zeros;
                op2421TB.Text = zeros;
                opxs3TB.Text = zeros;
            }

            op5211TB.Text = ip5211TB.Text.Trim();
            ip5211TB.BackColor = Color.LightGreen;
        }
        private void convxs3Button_Click(object sender, EventArgs e)
        {
            if (!preprocessing(ipxs3TB)) return;

            //Convert to decimal
            long dec = XS3_to_dec(ipxs3TB.Text.Trim());
            Console.WriteLine("Decimal: " + dec.ToString());
            if (dec == uint.MaxValue) return;
            //All conversions
            opDecimalTB.Text = dec.ToString();
            opBinaryTB.Text = dec_to_binary(dec);
            op2421TB.Text = dec_to_code2421(dec);
            op8421TB.Text = dec_to_code8421(dec);
            op5211TB.Text = dec_to_code5211(dec);
            opGrayCodeTB.Text = dec_to_gray(dec);
            if (dec == 0)
            {
                string zeros = "";
                while (zeros.Length % 4 != 0 || zeros.Length == 0) zeros += "0";
                op8421TB.Text = zeros;
                op2421TB.Text = zeros;
                op5211TB.Text = zeros;
            }

            opxs3TB.Text = ipxs3TB.Text.Trim();
            ipxs3TB.BackColor = Color.LightGreen;
        }
        private void convGrayCodeButton_Click(object sender, EventArgs e)
        {
            if (!preprocessing(ipGrayCodeTB, false)) return;

            //Convert to decimal
            long dec = gray_to_dec(ipGrayCodeTB.Text.Trim());
            Console.WriteLine("Decimal: " + dec.ToString());
            //All conversions
            opDecimalTB.Text = dec.ToString();
            opBinaryTB.Text = dec_to_binary(dec);
            op8421TB.Text = dec_to_code8421(dec);
            op2421TB.Text = dec_to_code2421(dec);
            op5211TB.Text = dec_to_code5211(dec);
            opxs3TB.Text = dec_to_XS3(dec);
            if (dec == 0)
            {
                string zeros = "";
                while (zeros.Length % 4 != 0 || zeros.Length == 0) zeros += "0";
                op8421TB.Text = zeros;
                op2421TB.Text = zeros;
                op5211TB.Text = zeros;
                opxs3TB.Text = zeros;
            }

            opGrayCodeTB.Text = ipGrayCodeTB.Text.Trim();
            ipGrayCodeTB.BackColor = Color.LightGreen;
        }
        private void convDecimalButton_Click(object sender, EventArgs e)
        {
            if (ipDecimalTB.Text.Trim().Length == 0) return;
            long dec;
            try
            {
                dec = Convert.ToInt64(ipDecimalTB.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Enter the decimal lnumber properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clearallTB();
            Console.WriteLine("Decimal: " + dec.ToString());
            //All conversions
            opBinaryTB.Text = dec_to_binary(dec);
            op8421TB.Text = dec_to_code8421(dec);
            op2421TB.Text = dec_to_code2421(dec);
            op5211TB.Text = dec_to_code5211(dec);
            opxs3TB.Text = dec_to_XS3(dec);
            opGrayCodeTB.Text = dec_to_gray(dec);

            if (dec == 0)
            {
                string zeros = "";
                while (zeros.Length%4 != 0 || zeros.Length==0) zeros += "0";
                op8421TB.Text = zeros;
                op2421TB.Text = zeros;
                op5211TB.Text = zeros;
                opxs3TB.Text = zeros;
            }

            opDecimalTB.Text = ipDecimalTB.Text.Trim();
            ipDecimalTB.BackColor = Color.LightGreen;
        }
        private void convBinaryButton_Click(object sender, EventArgs e)
        {
            if (!preprocessing(ipBinaryTB, false)) return;

            //Convert to decimal
            long dec = binary_to_dec(ipBinaryTB.Text.Trim());
            Console.WriteLine("Decimal: " + dec.ToString());
            //All conversions
            opDecimalTB.Text = dec.ToString();
            op8421TB.Text = dec_to_code8421(dec);
            op2421TB.Text = dec_to_code2421(dec);
            op5211TB.Text = dec_to_code5211(dec);
            opxs3TB.Text = dec_to_XS3(dec);
            opGrayCodeTB.Text = dec_to_gray(dec);
            if (dec == 0)
            {
                string zeros = "";
                while (zeros.Length % 4 != 0 || zeros.Length == 0) zeros += "0";
                op8421TB.Text = zeros;
                op2421TB.Text = zeros;
                op5211TB.Text = zeros;
                opxs3TB.Text = zeros;
            }

            opBinaryTB.Text = ipBinaryTB.Text.Trim();
            ipBinaryTB.BackColor = Color.LightGreen;
        }
    }
}
