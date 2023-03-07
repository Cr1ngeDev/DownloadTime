using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpeedCalc
{
    class Logic
    {

        public string GetText { get; private set; }
        public string SpeedOption { get; private set; }
        public string GetTextSize { get; private set; }
        public string SizeOption { get; private set; }
        public Logic(string GetText, string SpeedOption, string GetTextSize, string SizeOption)
        {
            this.GetText = GetText;
            this.SpeedOption = SpeedOption;
            this.GetTextSize = GetTextSize;
            this.SizeOption = SizeOption;
        }
        private string SpeedChoose()
        {
            double FinalRes = 0;
            string S1 = "no_data";
            try
            {
                if (GetText != "")
                {
                    if (SpeedOption != "")
                    {
                        if (SpeedOption == "KBits/s")
                        {
                            bool res = double.TryParse(GetText, out double number);
                            if(res == true)
                            {
                                FinalRes = number / 1000;
                                S1 = Convert.ToString(FinalRes);
                            }
                        }
                        else if(SpeedOption == "GBits/s") 
                        {
                            bool res = double.TryParse(GetText, out double number);
                            if (res == true)
                            {
                                FinalRes = number * 1000;
                                S1 = Convert.ToString(FinalRes);
                            }
                        }
                        else
                        {
                            S1 = GetText;
                        }
                    }
                    else
                    {
                        S1 = "errorOpt";
                    }
                }
                else
                {
                    S1 = "errorVal";
                }
            }
            catch 
            {
                MessageBox.Show("Smth wrong");
            }
            return S1;
        }
        public string GetSpeed()
        {
            string S = SpeedChoose();
            return S;
        }
        private string SizeChoose()
        {
            double FinalRes = 0;
            string S1 = "no_data";
            try
            {
                if (GetTextSize != "")
                {
                    if (SizeOption != "")
                    {
                        if (SizeOption == "Kilobyte/KB")
                        {
                            bool res = double.TryParse(GetTextSize, out var number);
                            if (res == true)
                            {
                                FinalRes = number / 1000;
                                S1 = Convert.ToString(FinalRes);
                            }
                        }
                        else if (SizeOption == "Gygabyte/GB")
                        {
                            bool res = double.TryParse(GetTextSize, out var number);
                            if (res == true)
                            {
                                FinalRes = number * 1024;
                                S1 = Convert.ToString(FinalRes);
                            }
                        }
                        else if (SizeOption == "Terabyte/TB")
                        {
                            bool res = double.TryParse(GetTextSize, out var number);
                            if (res == true)
                            {
                                FinalRes = number * 1048576;
                                S1 = Convert.ToString(FinalRes);
                            }
                        }
                        else
                        {
                            S1 = GetTextSize;
                        }
                    }
                    else
                    {
                        S1 = "errorOpt";
                    }
                }
                else
                {
                    S1 = "errorVal";
                }
            }
            catch 
            {
                MessageBox.Show("Smth wrong");
            }
            return S1;
        }
        public string GetSize()
        {
            string S = SizeChoose();
            return S;
        }
    }

}
