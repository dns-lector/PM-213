using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public record RomanNumber(int Value)
    {
        private readonly int _value = Value;
        public int Value => _value;

        public static RomanNumber Parse(String input)
        {
            int value = 0;
            int prevDigit = 0;
            foreach (char c in input.Reverse())
            {
                int digit = DigitValue(c.ToString());
                if (digit >= prevDigit)
                {
                    value += digit;
                }
                else
                {
                    value -= digit;
                }
                prevDigit = digit;
            }
            return new(value);
        }

        public static int DigitValue(String digit) => digit switch
        {
            "N" => 0,
            "I" => 1,
            "V" => 5,
            "X" => 10,
            "L" => 50,
            "C" => 100,
            "D" => 500,
            _ => 1000
            // "M" => 1000,
            // _ => throw new ArgumentException("Invalid Roman digit.")
        };
    }

}
