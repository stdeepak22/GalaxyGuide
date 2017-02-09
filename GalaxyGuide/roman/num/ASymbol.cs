using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyGuide.roman.num
{
    public static class RomanSymbol
    {
        static RomanSymbol()
        {

            _frequency[RomanNumber.I] = 3;
            _frequency[RomanNumber.V] = 1;
            _frequency[RomanNumber.X] = 3;
            _frequency[RomanNumber.L] = 1;
            _frequency[RomanNumber.C] = 3;
            _frequency[RomanNumber.D] = 1;
            _frequency[RomanNumber.M] = 3;


            _synonyms[RomanNumber.I] = new List<string> { RomanNumber.I.ToString() };
            _synonyms[RomanNumber.V] = new List<string> { RomanNumber.V.ToString() };
            _synonyms[RomanNumber.X] = new List<string> { RomanNumber.X.ToString() };
            _synonyms[RomanNumber.L] = new List<string> { RomanNumber.L.ToString() };
            _synonyms[RomanNumber.C] = new List<string> { RomanNumber.C.ToString() };
            _synonyms[RomanNumber.D] = new List<string> { RomanNumber.D.ToString() };
            _synonyms[RomanNumber.M] = new List<string> { RomanNumber.M.ToString() };

            _subtrationList[RomanNumber.I] = new List<RomanNumber> { RomanNumber.V, RomanNumber.X };
            _subtrationList[RomanNumber.V] = new List<RomanNumber> { };
            _subtrationList[RomanNumber.X] = new List<RomanNumber> { RomanNumber.L, RomanNumber.C};
            _subtrationList[RomanNumber.L] = new List<RomanNumber> { };
            _subtrationList[RomanNumber.C] = new List<RomanNumber> { RomanNumber.D, RomanNumber.M};
            _subtrationList[RomanNumber.D] = new List<RomanNumber> { };
            _subtrationList[RomanNumber.M] = new List<RomanNumber> { /*because its highest roman symbol*/ };
        }
        

        readonly static private Dictionary<RomanNumber, int> _frequency = new Dictionary<RomanNumber, int>();
        readonly static Dictionary<RomanNumber, List<string>> _synonyms = new Dictionary<RomanNumber, List<string>>();
        readonly static Dictionary<RomanNumber, List<RomanNumber>> _subtrationList = new Dictionary<RomanNumber, List<RomanNumber>>();

        public static int Value(this RomanNumber num)
        {
            return (int)num;
        }

        public static int Frequencey(this RomanNumber num)
        {
            if (_frequency.Keys.Contains(num))
            {
                return _frequency[num]; 
            }
            return -1;
        }

        public static void AddSynonym(this RomanNumber num, string syn)
        {
            if (!_synonyms.Keys.Contains(num))
            {
                _synonyms[num] = new List<string>();
            }
            if (!_synonyms[num].Contains(syn.Trim()))
            {
                _synonyms[num].Add(syn.Trim()); 
            }
        }

        public static List<string> GetSynonyms(this RomanNumber num)
        {
            return _synonyms[num];
        }

        public static bool IsSynonyms(this RomanNumber num, string syn)
        {            
            return _synonyms[num].Contains(syn.Trim());
        }

        public static bool CanBeSubtracted(this RomanNumber num)
        {
            return _subtrationList.Keys.Contains(num) && _subtrationList[num].Any();
        }

        public static bool CanBeSubtractedFrom(this RomanNumber num, RomanNumber fromNum)
        {
            return _subtrationList.Keys.Contains(num) && _subtrationList[num].Contains(fromNum);
        }

        public static int MaxValue(this RomanNumber num)
        {
            return _frequency[num] * num.Value();
        }
        
        public static RomanNumber GetRomanFromSyn(this string syn)
        {
            return _synonyms.Where(c => c.Value.Contains(syn)).First().Key;
        }
    }    
}
