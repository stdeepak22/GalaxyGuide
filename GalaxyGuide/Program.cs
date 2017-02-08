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

            //Console.WriteLine(100.GetBiggerRomanNumber());
            //Console.WriteLine(100.GetSmallerRomanNumber());
            Console.WriteLine(400.DoINeedToUseAnotherRoman());
            Console.WriteLine("now");
            RomanCompiler.GetDigits(100).ToList().ForEach(c =>
            {
                Console.WriteLine(c);
            });
            Console.ReadLine();
        }
    }
}
