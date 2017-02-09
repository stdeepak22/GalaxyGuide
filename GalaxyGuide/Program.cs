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
            Console.WriteLine("now");
            Console.WriteLine(RomanCompiler.Decompile("DEEPAK"));

            Console.WriteLine(RomanCompiler.Decompile("CCCXCIX"));
            //RomanCompiler.GetDigits(100).ToList().ForEach(c =>
            //{
            //    Console.WriteLine(c);
            //});
            Console.ReadLine();
        }
    }
}
