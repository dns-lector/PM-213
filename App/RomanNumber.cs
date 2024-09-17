﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public record RomanNumber(int Value)
    {

        public RomanNumber(String input): 
            this(RomanNumberFactory.ParseAsInt(input))
        { }

        public override string? ToString()
        {
            // 3343 -> MMMCCCXLIII
            // M M M
            // D (500) x
            // CD (400) x
            // C C C
            // L x
            // XL 
            // X x
            // V x
            // IV
            // III
            if (Value == 0) return "N";
            Dictionary<int, String> parts = new()
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };
            int v = Value;
            StringBuilder sb = new();
            foreach (var part in parts)
            {
                while(v >= part.Key)
                {
                    v -= part.Key;
                    sb.Append(part.Value);
                }
            }
            return sb.ToString();
        }

        public Int32 ToInt() => Value;
        public Int16 ToShort() => (short) Value;
        public UInt32 ToUnsignedInt() => (uint) Value;
        public UInt16 ToUnsignedShort() => (ushort) Value;
        public Single ToFloat() => (float) Value;
        public Double ToDouble() => (double) Value;

    }

}
