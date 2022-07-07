using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Arrays
    {
        public static void CloneArray()
        {
            int[] firstArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] secondArray = new int[firstArray.Length];
            for (int i = 0; i < firstArray.Length; i++)
            {
                secondArray[i] = firstArray[i];
                Console.Write(firstArray[i]);
            }
        }
        public static void ChangeList()
        {
            List<string> listlist = new List<string>();
            while (true)
            {
                Console.WriteLine("Type (+ item, - item, or -- to clear)):");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                switch (input.Substring(0, 2))
                {
                    case "+ ":
                        listlist.Add(input.Substring(2, input.Length - 2));
                        foreach (string s in listlist) Console.Write($"{s} ");
                        Console.WriteLine();
                        break;
                    case "- ":
                        listlist.Remove(input.Substring(2, input.Length - 2));
                        foreach (string s in listlist) Console.Write($"{s} ");
                        Console.WriteLine();
                        break;
                    case "--":
                        listlist.Clear();
                        foreach (string s in listlist) Console.Write($"{s} ");
                        Console.WriteLine();
                        break;
                }

            }
        }
        public static void PrimeNum()
        {
            int num, i, ctr, stno, enno;

            Console.Write("\n\n");
            Console.Write("Find the prime numbers within a range of numbers:\n");
            Console.Write("---------------------------------------------------");
            Console.Write("\n\n");

            Console.Write("Input starting number of range: ");
            stno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input ending number of range : ");
            enno = Convert.ToInt32(Console.ReadLine());
            Console.Write("The prime numbers between {0} and {1} are : \n", stno, enno);

            for (num = stno; num <= enno; num++)
            {
                ctr = 0;

                for (i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        ctr++;
                        break;
                    }
                }

                if (ctr == 0 && num != 1)
                    Console.Write("{0} ", num);
            }
            Console.Write("\n");
        }
        public static void RotateArray()
        {
            int i = 0;
            int sum;
            Console.WriteLine("Please enter your array");
            string input = Console.ReadLine();
            int[] arrays = Array.ConvertAll(input.Split(' '), int.Parse);
            Console.WriteLine("Please enter the rotation time");
            int rotateTime = Convert.ToInt32(Console.ReadLine());
            int[] answer = new int[arrays.Length];
            for (i = 0; i < arrays.Length; i++)
            {
                sum = 0;
                for (int j = 1; j <= rotateTime % arrays.Length; j++)
                {
                    sum = sum + arrays[(i + arrays.Length - j) % arrays.Length];
                }
                Console.Write($"{sum} ");
            }
            Console.WriteLine();
        }
        
        public static void Frequent()
        {
            Console.WriteLine("Please enter your array");
            string input = Console.ReadLine();
            int[] arrays = Array.ConvertAll(input.Split(' '), int.Parse);
            Dictionary<int, int> mfrequent = new Dictionary<int, int>();
            for (int i = 0; i < arrays.Length; i++)
            {
                if (mfrequent.ContainsKey(arrays[i])) mfrequent[arrays[i]]++;
                else mfrequent.Add(arrays[i], 1);
            }
            int key = -1;
            int max = 0;
            foreach (int i in mfrequent.Keys)
            {

                if (mfrequent[i] > max)
                {
                    max = mfrequent[i];
                    key = i;
                }
            }
            Console.WriteLine(key);
        }
        public static void Sequence()
        {
            var elemts = new int[] { 0, 1, 1, 5, 2, 2, 6, 3, 3 };

            var result = LongestSequence(elemts);

            foreach (var i in result)
            {
                Console.Write(i + "\t");
            }

            Console.ReadLine();
        }

        public static int[] LongestSequence(int[] elems)
        {
            var longSequenceEqualElem = new List<int>();
            return LongestSequenceRec(elems, longSequenceEqualElem, 0);
        }

        private static int[] LongestSequenceRec(int[] elems, List<int> sequence, int pos)
        {
            if (pos < elems.Length)
            {
                if (sequence.Contains(elems[pos]))
                {
                    sequence.Add(elems[pos]);
                    return LongestSequenceRec(elems, sequence, pos + 1);
                }
                else
                {
                    var newSeq = LongestSequenceRec(elems, new List<int> { elems[pos] }, pos + 1);
                    return (newSeq.Length > sequence.Count) ? newSeq.ToArray() : sequence.ToArray();
                }
            }
            return sequence.ToArray();
        }
    }
}


