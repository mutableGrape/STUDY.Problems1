using System;
using System.Collections.Generic;
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
    }
}
