using System;
using System.Collections.Generic;

namespace Task2
{
    public static class UserConsole
    {
        public static void PrintNumber<T>(string str, T num)
        {
            Console.WriteLine($"{str}:\n{num}");
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