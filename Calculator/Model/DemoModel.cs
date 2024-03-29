﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class DemoModel
    {
        public string text { get; set; }

        public bool Div()
        {
            if (text.Length == 0)
                return true;

            if (!IsTextCharsValid(text))
            {
                text = "Error";
                return false;
            }

            int divSymbPos = text.IndexOf('/');
            if (divSymbPos < 0)
            { 
                text = "Error";
                return false;
            }

            string sLeft, sRight;

            try
            {
                sLeft = text.Substring(0, divSymbPos);
                sRight = text.Substring(divSymbPos + 1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                text = "Error";
                return false;
            }

            if (sLeft.Length == 0 || sRight.Length == 0)
            {
                text = "Error";
                return false;
            }

            int nLeft, nRight;

            try
            {
                nLeft = Int32.Parse(sLeft);
                nRight = Int32.Parse(sRight);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                text = "Error";
                return false;
            }

            if (nRight == 0)
            {
                text = "Infinity";
                return true;
            }

            int nResult = nLeft / nRight;
            text = nResult.ToString();

            return true;
        }

        private bool IsTextCharsValid(in string str)
        {
            if (str.Length == 0)
                return true;

            string num = "0123456789";

            foreach (var ch in str)
            {
                if (num.IndexOf(ch) >= 0)
                    continue;

                if (ch != '/')
                    return false;
            }

            return true;
        }
    }
}
