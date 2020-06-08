using System;
using System.Text;

namespace Task2
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (!UserConsole.GetValue("Укажите требуемую точность интегрирования", out var epsilon))
            {
                UserConsole.PrintString("Введенное значение не распознается как точность интегрирования");
                UserConsole.Wait();
                return;
            }
            var a = SourceData.A;
            var b = SourceData.B;
            var n = SourceData.N;

            PrintSource(epsilon, a, b, n);

            var (resultN, area) = new Trapezium(SourceData.Function, epsilon, a, b, n).GetResult();

            PrintResult(resultN, area);

            UserConsole.Wait();
        }

        private static void PrintSource(double epsilon, double a, double b, double n)
        {
            UserConsole.PrintString("Входные данные");
            UserConsole.PrintString("Аналитическая функция:\nMath.Exp(-Math.Pow(x, 2)) * Math.Sin(x)");
            UserConsole.PrintNumber("Начало интервала", a);
            UserConsole.PrintNumber("Конец интервала", b);
            UserConsole.PrintNumber("Начальное количество узлов", n);
            UserConsole.PrintNumber("Относительная точность", epsilon);
        }

        private static void PrintResult(int resultN, double area)
        {
            UserConsole.PrintString("\nВыходные данные");
            UserConsole.PrintNumber("Конечное количество узлов", resultN);
            UserConsole.PrintNumber("Значение интеграла", area);
            UserConsole.PrintNumber("Точность интегрирования", Math.Abs(area - 0.42116423940845));
        }
    }
}