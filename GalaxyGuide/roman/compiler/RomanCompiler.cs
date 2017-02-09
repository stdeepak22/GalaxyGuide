using GalaxyGuide.roman.num;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GalaxyGuide.roman.compiler
{
    public static class RomanCompiler
    {        
        public static string Compile(int value)
        {
            List<List<RomanNumber>> result = new List<List<RomanNumber>>();         
            var list = GetDigits(value);
            foreach (var oneNum in list)
            {
                result.Add(GetRomanNumber(oneNum));
            }

            return string.Join("", result.SelectMany(c => c).Select(c => c.ToString()));
        }

        private static List<RomanNumber> GetRomanNumber(int oneNum)
        {
            var result = new List<RomanNumber>();
            var b = oneNum.GetBaseForValue();
            var isAnother = oneNum.DoINeedToUseAnotherRoman(b);
            if (isAnother)
            {
                var an = oneNum.GetAnotherRomanNumberToBeUser(ref b);
                FormTheList(b, an, oneNum, result);
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
        private static void FormTheList(RomanNumber b, RomanNumber an, int num, IList<RomanNumber> result)
        {
            result.Add(an);
            
            int sum = an.Value();
            while(sum != num)
            {
                if(sum < num)
                {
                    result.Add(b);
                    sum += b.Value();
                }
                else
                {
                    result.Insert(0, b);
                    sum -= b.Value();
                }
            }
        }
        private static List<int> GetDigits(int value)
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
        private static bool DoINeedToUseAnotherRoman(this int num)
        {
            return num.DoINeedToUseAnotherRoman(num.GetBaseForValue());
        }
        private static bool DoINeedToUseAnotherRoman(this int num, RomanNumber baseNum)
        {
            return num > baseNum.MaxValue();
        }
        private static RomanNumber GetAnotherRomanNumberToBeUser(this int num, ref RomanNumber baseNum)
        {
            RomanNumber result;
            var sbtrct = baseNum.CanBeSubtracted();
            if(!sbtrct)
            {
                var l = baseNum.GetLeftRoman();
                if (num <= l.MaxValue() + baseNum.MaxValue())
                {
                    result = baseNum;
                    baseNum = l;
                }
                else
                {
                    result = baseNum.GetRightRoman();
                    baseNum = l;
                }                
            }
            else
            {
                result = baseNum.GetRightRoman();
            }
            return result;
        }
        private static RomanNumber GetBaseForValue(this int num)
        {
            var result = Enum.GetValues(typeof(RomanNumber))
                .Cast<int>()
                .OrderByDescending(c=>c)
                .First(c => c <= num);
            return (RomanNumber)result;
        }
        private static RomanNumber GetLeftRoman(this RomanNumber num)
        {
            var result = Enum.GetValues(typeof(RomanNumber))
                .Cast<int>()
                .OrderByDescending(c => c)
                .First(c => c < (int)num);
            return (RomanNumber)result;
        }
        private static RomanNumber GetRightRoman(this RomanNumber num)
        {
            var result = Enum.GetValues(typeof(RomanNumber))
                .Cast<int>()
                .OrderBy(c => c)
                .First(c => c > (int)num);
            return (RomanNumber)result;
        }
    }

    static class ExtToCollection
    {
        
    }
}
