using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public static class PracticeLoopsandOperators
    {
        public static void FizzBuzz()
        {
            for (int i = 1; i < 100; ++i)
            {
                if (i % 15 == 0) Console.WriteLine("fizzbuzz");
                else if (i % 5 == 0) Console.WriteLine("buzz");
                else if (i % 3 == 0) Console.WriteLine("fizz");
                else Console.WriteLine(i);
            }
        }

        // public static void PrintaPyramid()
        //{
        //int max = 500;
        //for (byte i = 0; i < max; i++)
        //{
        //if (i.GetType() != max.GetType()) throw (new ApplicationException("Not the Same"));
        //Console.WriteLine(i);
        // }
        // }

        public static void Greetings()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12 && hour > 8) Console.WriteLine("Good Morning");
            if (hour < 18 && hour >= 12) Console.WriteLine("Good Afternoon");
            if (hour < 20 && hour >= 18) Console.WriteLine("Good Evening");
            if ((hour <= 24 && hour >= 20) || hour <= 8) Console.WriteLine("Good Night");
            Console.WriteLine(hour);
        }
        public static void Loop()
        {
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 24; j = j + i)
                {
                    Console.Write($"{j},");
                }
                Console.WriteLine(24);
            }
        }
        public static void BDay()
        {
            Console.WriteLine("Enter your birthday:");
            DateTime birthday = Convert.ToDateTime(Console.ReadLine());
            double days = (DateTime.Today - birthday).TotalDays;
            Console.WriteLine(days);
        }
    }
   

}
