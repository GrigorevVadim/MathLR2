using System;
using System.Collections.Generic;

namespace Task1
{
    public static class UserConsole
    {
        public static void PrintNumber<T>(string str, T num)
        {
            Console.WriteLine($"{str}:\n{num}");
        }
        public static void PrintVector(string str, List<double> vector)
        {
            Console.WriteLine($"{str}: ");
            foreach (var d in vector)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
        }
        public static void PrintVector(string str, double[] vector)
        {
            Console.WriteLine($"{str}: ");
            foreach (var d in vector)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
        }
        public static void PrintString(string str)
        {
            Console.WriteLine(str);
        }
        public static void Wait()
        {
            Console.ReadKey();
        }
    }
}