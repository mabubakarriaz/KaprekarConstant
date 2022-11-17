using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal static class Utilities
    {
        public static int Ascending(char[] digits)
        {
            Int32 asc;
            Array.Sort(digits);
            asc = Convert.ToInt32(string.Join("", digits));
            return asc;
        }


        public static int Descending(char[] digits)
        {
            Int32 desc;
            Array.Reverse(digits);

            if (digits.Length == 3)
            {
                //fix ending zero
                desc = Convert.ToInt32(string.Join("", digits) + "0");
            }
            else
            {
                desc = Convert.ToInt32(string.Join("", digits));
            }

            return desc;
        }


    }
}
