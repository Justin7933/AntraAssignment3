using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{

    class PlayingWithConsoleApp

    {
        public static void InputandOut()
        {

            Console.WriteLine("What is your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("How old are you:");
            int age = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"Hi,{name}. you are {age}");
            Console.WriteLine("What is your astrology sign?");
            string astro = Console.ReadLine();
            Console.WriteLine("What is your favorite color?");
            string color = Console.ReadLine();
            Console.WriteLine($"Oh, your are {astro}, and you like {color}");
        }
    }
}
