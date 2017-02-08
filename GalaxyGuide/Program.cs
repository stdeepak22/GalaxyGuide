using GalaxyGuide.roman.compiler;
using GalaxyGuide.roman.num;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyGuide
{
    class Program
    {
        static void Main(string[] args)
        {
            RomanNumber.C.AddSynonym("new");
            RomanNumber.C.GetSynonyms().ForEach(c => Console.WriteLine(c));
            //Console.WriteLine();
            Console.WriteLine(RomanNumber.C.Value());
            Console.ReadLine();
        }
    }
}
