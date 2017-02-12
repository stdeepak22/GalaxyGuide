using GalaxyGuide.roman.compiler;
using GalaxyGuide.roman.num;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GalaxyGuide
{
    public static class UserQueries
    {
        #region Variables
        static readonly string errorMsg = "I have no idea what you are talking about";

        static readonly List<string> regQuestions = new List<string> {
            @"(((how much)|(how many))\s+(?<Cur>\w+\s+)?is\s+(?<syns>(\w+\s{0,})+)+(\?)?)"
        };

        static readonly List<string> regSynWithRoman = new List<string> {
            @"((?<syn>\w+)\s+is\s+(?<roman>[IVXLCDM]))",
        };

        static readonly List<string> regSynWithNumber = new List<string> {
            @"((?<syns>(\w+\s+)+)is\s+(?<Cr>\d+)(\s+)?(?<Cur>\w+)?)",
            @"((?<Cr>\d+)\s+(?<Cur>\w+\s+)?is(?<syns>(\s+\w+)+))",
        }; 
        #endregion

        public static string HandleInput(string inputFromUser)
        {
            string result = null;
            string pat = string.Empty;
            if (IsThatAQuestion(inputFromUser, ref pat))
            {
                result = AnswerTheQuestion(inputFromUser, pat);
            }
            else if (IsThatASynForRoman(inputFromUser, ref pat))
            {
                SaveDirectSynosyms(inputFromUser, pat);
            }
            else if (IsThatACalculationStatement(inputFromUser, ref pat))
            {
                CalculateAndSaveSynosyms(inputFromUser, pat);
            }
            else
            {
                result = errorMsg;
            }
            return result;
        }

        #region What type of the input it is - Question, Roman or Calculation Statement
        private static bool IsThatAQuestion(string input, ref string pattern)
        {
            return IsThatBelongsToPatterns(regQuestions, input, ref pattern);
        }

        private static bool IsThatASynForRoman(string input, ref string pattern)
        {
            return IsThatBelongsToPatterns(regSynWithRoman, input, ref pattern);
        }

        private static bool IsThatACalculationStatement(string input, ref string pattern)
        {
            return IsThatBelongsToPatterns(regSynWithNumber, input, ref pattern);
        }

        private static bool IsThatBelongsToPatterns(List<string> patterns, string input, ref string returnPattern)
        {
            string pat = string.Empty;
            bool result = false;
            result = patterns.Any(c =>
            {
                pat = c;
                return Regex.IsMatch(input, c);
            });
            returnPattern = pat;
            return result;
        }
        #endregion
        
        #region Handle the user input
        private static string AnswerTheQuestion(string input, string pattern)
        {
            string answer = @"{0} is {1} {2}";

            var groups = Regex.Match(input, pattern).Groups;
            var romanString = string.Empty;
            var syns = groups["syns"].Value.Trim();
            var synsList = syns.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var syn in synsList)
            {
                try
                {
                    romanString += syn.GetRomanFromSyn().ToString();                    
                }
                catch (Exception)
                {
                    //in question if user enter a roman value itself like - VIII - without space and expect a output
                    romanString = string.Join("", synsList);                   
                }
            }
            if (!RomanCompiler.ValidRomanStringRegex(romanString))
            {
                return errorMsg;
            }
            return string.Format(answer, syns, RomanCompiler.Decompile(romanString), groups["Cur"]);
        }
        private static void SaveDirectSynosyms(string input, string pattern)
        {
            var groups = Regex.Match(input, pattern).Groups;
            var syn = groups["syn"].Value;
            RomanNumber romanNumber = groups["roman"].Value.GetRomanFromSyn();
            romanNumber.AddSynonym(syn);
        }
        private static void CalculateAndSaveSynosyms(string input, string pattern)
        {
            var groups = Regex.Match(input, pattern).Groups;
            var synonyns = groups["syns"].Value;
            string numericValue = groups["Cr"].Value;

            //Get the roman format
            var compVal = RomanCompiler.Compile(int.Parse(numericValue));

            var syns = synonyns.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (compVal.Length != syns.Count)
            {
                Console.Write("something is wrong.  check the input.");
            }
            else
            {
                for (int i = 0; i < compVal.Length; i++)
                {
                    compVal[i].ToString().GetRomanFromSyn().AddSynonym(syns[i]);
                }
            }
        }
        #endregion
    }
}
