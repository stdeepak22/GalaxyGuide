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
            Console.WriteLine(RomanCompiler.Compile(1902));
            Console.WriteLine(RomanCompiler.Compile(200));
            Console.WriteLine(RomanCompiler.Compile(300));
            Console.WriteLine(RomanCompiler.Compile(400));
            Console.WriteLine(RomanCompiler.Compile(500));
            Console.WriteLine(RomanCompiler.Compile(600));
            Console.WriteLine(RomanCompiler.Compile(700));
            Console.WriteLine(RomanCompiler.Compile(800));
            Console.WriteLine(RomanCompiler.Compile(900));
            Console.WriteLine(RomanCompiler.Compile(1000));

            //RomanCompiler.GetDigits(100).ToList().ForEach(c =>
            //{
            //    Console.WriteLine(c);
            //});
            Console.ReadLine();
        }
    }
}
