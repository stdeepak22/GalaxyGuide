using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyGuide.roman.compiler
{
    public static class RomanCompiler
    {
        public static void Compile(int value)
        {
            var array = GetDigits(value);

        }
        private static int[] GetDigits(int value)
        {
            var asString = value.ToString();
            int length = asString.Length;
            var result = new int[length];
            int index = 0;
            while(index < length)
            {
                var stringVal = asString.Substring(index, 1).PadRight(length - index, '0');
                result[index] = int.Parse(stringVal);
                index++;
            }
            return result;
        }
    }
}
