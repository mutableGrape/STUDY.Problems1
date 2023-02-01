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
            Console.WriteLine(LongestSequence(new int[] {1,2,1,1,0,3,1,0,0,2,4,1,0,0,0,0,2,1,0,3,1,0,0,0,6,1,3,0,0,0}));
            Console.ReadLine();

            Console.WriteLine("Problem 2: Anagrams");
            string[] answer = Anagrams("star", new string[] { "parts", "traps", "arts", "rats", "starts", "tarts", "rat", "art", "tar", "tars", "stars", "stray" });
            Console.WriteLine(string.Join(", ", answer));
            Console.ReadLine();

            Console.WriteLine("Problem 3: Pyramid");
            PrintPyramid(5);
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
    }
}
