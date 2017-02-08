using GalaxyGuide.roman.num;
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
            List<List<RomanNumber>> result = new List<List<RomanNumber>>();         
            var list = GetDigits(value);
            foreach (var oneNum in list)
            {
                result.Add(GetRomanNumber(oneNum));
            }
        }

        private static List<RomanNumber> GetRomanNumber(int oneNum)
        {
            var result = new List<RomanNumber>();
            var b = oneNum.GetBaseForValue();
            var isAnother = oneNum.DoINeedToUseAnotherRoman(b);
            if (isAnother)
            {
                var an = oneNum.GetAnotherRomanNumberToBeUser(ref b);
            }
            else
            {
                for (int i = 0; i < oneNum/(int)b; i++)
                {
                    result.Add(b);
                }                
            }
            return result;

        }

        public static List<int> GetDigits(int value)
        {
            var asString = value.ToString();
            int length = asString.Length;
            var result = new List<int>();
            int index = 0;
            while(index < length)
            {
                var stringVal = asString.Substring(index, 1).PadRight(length - index, '0');
                result.Add(int.Parse(stringVal));
                index++;
            }
            return result.Where(c=>c > 0).ToList();
        }

        public static bool DoINeedToUseAnotherRoman(this int num)
        {
            return num.DoINeedToUseAnotherRoman(num.GetBaseForValue());
        }

        public static bool DoINeedToUseAnotherRoman(this int num, RomanNumber baseNum)
        {
            return num > ((int)baseNum * baseNum.Frequencey());
        }
        public static RomanNumber GetAnotherRomanNumberToBeUser(this int num, ref RomanNumber baseNum)
        {
            var sbtrct = baseNum.CanBeSubtracted();
            if(sbtrct)
            {
                var l = baseNum.GetLeftRoman();
                // will be working here.
                return l;
            }
            else
            {
                return baseNum.GetRightRoman();
            }            
        }
        public static RomanNumber GetBaseForValue(this int num)
        {
            var result = Enum.GetValues(typeof(RomanNumber))
                .Cast<int>()
                .OrderByDescending(c=>c)
                .First(c => c <= num);
            return (RomanNumber)result;
        }
        public static RomanNumber GetLeftRoman(this RomanNumber num)
        {
            var result = Enum.GetValues(typeof(RomanNumber))
                .Cast<int>()
                .OrderByDescending(c => c)
                .First(c => c < (int)num);
            return (RomanNumber)result;
        }
        public static RomanNumber GetRightRoman(this RomanNumber num)
        {
            var result = Enum.GetValues(typeof(RomanNumber))
                .Cast<int>()
                .OrderBy(c => c)
                .First(c => c > (int)num);
            return (RomanNumber)result;
        }
    }
}
