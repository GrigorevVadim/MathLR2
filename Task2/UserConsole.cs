using System;
using System.Collections.Generic;

namespace Task2
{
    public static class UserConsole
    {
        public static bool GetValue(string str, out double value)
        {
            Console.Write($"{str}: ");
            var stringUserValue = Console.ReadLine();
            return double.TryParse(stringUserValue, out value);
        }
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