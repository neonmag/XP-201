using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        public int Value { get; set; }
        public int Val2;
        public static RomanNumber Parse(String input)
        {
            return new()
            {
                Value = 1
            };
        }
    }
}
