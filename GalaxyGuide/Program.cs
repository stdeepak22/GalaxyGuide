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
        static List<string> forCalculation = new List<string> {
            @"((?<syn>\w+\s+)+is\s+(?<Amount>\d+)(\s+)?(?<Cur>\w+)?)",
            @"((?<Amount>\d+)\s+(?<Cur>\w+\s+)?is(?<syn>\s+\w+)+)",
        };

        static void Main(string[] args)
        {            
            Console.WriteLine("now");
            Console.WriteLine(RomanCompiler.Decompile("9999015379"));

            Console.WriteLine(RomanCompiler.Decompile("CCCXCIX"));
            //RomanCompiler.GetDigits(100).ToList().ForEach(c =>
            //{
            //    Console.WriteLine(c);
            //});
            Console.ReadLine();
        }
    }
}
