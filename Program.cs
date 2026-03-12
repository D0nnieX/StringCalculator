using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new StringCalculator();

            //step 1
            //Console.WriteLine("STEP 1-2");
            //Console.WriteLine(calc.Add(""));
            //Console.WriteLine(calc.Add("1"));
            //Console.WriteLine(calc.Add("1,2"));

            //step 2
            //Console.WriteLine(calc.Add("1,2,3,4"));

            //step 3
            //Console.WriteLine("STEP 3");
            //Console.WriteLine(calc.Add("1,-2,3,-4"));

            //step 4
            //Console.WriteLine("STEP 4");
            //Console.WriteLine(calc.Add("2,1001"));

            //steps 5-6-7
            Console.WriteLine(calc.Add("1,2,3"));
            Console.WriteLine(calc.Add("//[*]//1*2*3"));
            Console.WriteLine(calc.Add("//[*][%]//1*2%3"));
            Console.WriteLine(calc.Add("//[***][%%]//1***2%%3"));

            Console.ReadLine();
        }
    }
}