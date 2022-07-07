using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Strings
    {
       public static String Reverse(String str)
        {
            int i = str.Length - 1;
            int start, end = i + 1;
            String result = "";

            while (i >= 0)
            {
                if (str[i] == ' ')
                {
                    start = i + 1;
                    while (start != end)
                        result += str[start++];

                    result += ' ';

                    end = i;
                }
                i--;
            }

            start = 0;
            while (start != end)
                result += str[start++];

            return result;
        }
        public static void Main()
        {
            String str = "I AM A GEEK";

            Console.Write(Reverse(str));
        }
       
        
        
        public static void Sentence()
        {
            string text = "My name is Archit Patel";

            Console.WriteLine(string.Join(" ", text.Split(' ').Reverse()));
        }


        public static void Palindromes()
        {
            Console.WriteLine("Please enter your String");
            string input = Console.ReadLine();
            int n = 0;
            int st = 0;
            List<string> answer = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) == false && i != 0)
                {
                    int x = n;
                    int y = i - 1;
                    int check = 0;
                    while (x < y)
                    {
                        if (input[x] != input[y])
                        {
                            check = 1;
                            break;
                        }
                        x++;
                        y--;
                    }

                    if (check == 0)
                    {
                        Console.Write($"{input.Substring(n, i - n)}, ");
                    }
                    n = i + 1;
                }
            }
            Console.WriteLine();
        }
        public static void URL()
        {
            Console.WriteLine("Please enter your URL:");
            string input = Console.ReadLine();
            int part = 0;
            int n = 0;
            int i = 0;
            while (i < input.Length)
            {
                if (input[i] == ':' && input[i + 1] == '/' && input[i + 2] == '/')
                {
                    Console.WriteLine($"[protocol] = \" {input.Substring(n, i)}\"");
                    part = 1;
                    i = i + 3;
                    n = i;
                }
                else if ((input[i] == '/' && input[i - 1] != '/'))
                {
                    part = 2;
                    if (part == 0)
                    {
                        Console.WriteLine($"[protocol] = \"\"");
                        Console.WriteLine($"[server] = \"{input.Substring(n, i)}\"");
                        Console.WriteLine($"[resource] = \"{input.Substring(i + 1, input.Length - i - 1)}\"");
                    }
                    else
                    {
                        Console.WriteLine($"[server] = \"{input.Substring(n, i - n)}\"");
                        Console.WriteLine($"[resource] = \"{input.Substring(i + 1, input.Length - i - 1)}\"");
                    }

                }
                i++;
            }
            if (part == 0)
            {
                Console.WriteLine($"[protocol] = \"\"");
                Console.WriteLine($"[server] = \"{input}\"");
                Console.WriteLine($"[resourcel] = \"\"");
            }
            else if (part == 1)
            {
                Console.WriteLine($"[server] = \"{input.Substring(n, i - n)}\"");
                Console.WriteLine($"[resourcel] = \"\"");
            }

        }
    }
}



