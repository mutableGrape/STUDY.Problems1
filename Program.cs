using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problems from Dev58/problems/Coding Exercises.docx");

            Console.WriteLine("Problem 1: Longest Sequence");
            Console.WriteLine(LongestSequence(new int[] { 1, 2, 1, 1, 0, 3, 1, 0, 0, 2, 4, 1, 0, 0, 0, 0, 2, 1, 0, 3, 1, 0, 0, 0, 6, 1, 3, 0, 0, 0 }));
            Console.ReadLine();

            Console.WriteLine("Problem 2: Anagrams");
            string[] answer = Anagrams("star", new string[] { "parts", "traps", "arts", "rats", "starts", "tarts", "rat", "art", "tar", "tars", "stars", "stray" });
            Console.WriteLine(string.Join(", ", answer));
            Console.ReadLine();

            Console.WriteLine("Problem 3: Pyramid");
            PrintPyramid(5);
            Console.ReadLine();

            Console.WriteLine("Problem 4: Pyramid");
            PrintPyramid(5);
            PrintPyramid(4, false);
            Console.ReadLine();

            Console.WriteLine("Problem 5: Reverse String");
            Console.WriteLine(Reverse("hello world"));
            Console.ReadLine();

            Console.WriteLine("Problem 6: Palindrome");
            foreach (string s in new string[] { "madam", "step on no pets", "book" })
            {
                Console.Write(s + " is ");
                if (s != Reverse(s)) { Console.Write("not "); }
                Console.Write("a palindrome.\n");
            }
            Console.ReadLine();

            Console.WriteLine("Problem 7: Sum digits");
            Console.WriteLine(SumDigits(12));
            Console.WriteLine(SumDigits(123));
            Console.WriteLine(SumDigits(5000));
            Console.ReadLine();

            Console.WriteLine("Problem 8: TwoSums");
            Tuple<int, int> answer8 = TwoSums(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
            Console.Write(answer8.Item1);
            Console.Write(", ");
            Console.WriteLine(answer8.Item2);
            Console.ReadLine();

            Console.WriteLine("Problem 9: Prime Index");
            Console.WriteLine(PrimeIndex(3));
            Console.WriteLine(PrimeIndex(5));
            Console.ReadLine();

        }
        static int LongestSequence(int[] arr)
        {
            int max = 0;
            int running = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] > 0) && (running > 0))
                {
                    if (max < running) { max = running; }
                    running = 0;
                } else
                {
                    running++;
                }
            }
            return max;
        }

        static string[] Anagrams(string a, string[] words)
        {
            int wordLength = a.Length;
            bool isAnagram = true;
            List<string> ans = new List<string>();

            foreach (string word in words)
            {

                isAnagram = true;
                if (word.Length == wordLength)
                {
                    foreach (char i in a)
                    {

                        if (word.IndexOf(i) < 0)
                        {
                            isAnagram = false;
                            break;
                        }
                    }

                    if (isAnagram)
                    {
                        ans.Add(word);
                    }
                }
            }
            return ans.ToArray();
        }

        static void PrintPyramid(int size, bool upside = true)
        {
            // Designed to print pyramid upwards or downwards for convenience of problem 4
            int start, inrement;
            if (upside)
            {
                start = 1;
                inrement = 2;
            }
            else
            {
                start = 2 * size - 1;
                inrement = -2;
            }

            for (int i = 0; i < size; i++)
            {
                if (!upside) { Console.Write(" "); }
                for (int j = 0; j < (2 * size - start) / 2; j++) { Console.Write(" "); };
                for (int j = 0; j < start; j++) { Console.Write("*"); }
                start += inrement;
                Console.Write("\n");
            }
        }

        static string Reverse(string a)
        {
            string b = "";
            for (int i = a.Length - 1; i >= 0; i--)
            {
                b += a[i];
            }
            return b;
        }

        static int SumDigits(int num)
        {
            int sum = 0;
            int temp = num;

            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
            }

            return sum;
        }

        static Tuple<int, int> TwoSums(List<int> items, int targetSum)
        {
            for (int i = 0; i < items.Count - 2; i++)
            {
                for (int j = i+1; j < items.Count - 1; j++)
                {
                    if (items[i] + items[j] == targetSum)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return null;
        }

        static bool IsPrime(int num)
        {
            if (num < 2)
            {
                return false;
            } 
            else
            {
                for (int divis = 2; divis*divis <= num; divis++)
                {
                    if (num % divis == 0) { return false; }
                }
            }
            return true;
        }

        static int PrimeIndex(int num)
        {
            if (num == 1) { return 2; }

            int primeCounter = 2;
            int a = 3;

            while (primeCounter < num)
            {
                a += 2;
                if (IsPrime(a)) { primeCounter++; }
            }

            return a;
        }
    }
}
