using System;
using System.Text;

namespace Task3
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

            var area = new Gauss(SourceData.Function, epsilon, a, b, n).GetResult();

            PrintResult(area);

            UserConsole.Wait();
        }

        private static void PrintSource(double epsilon, double a, double b, double n)
        {
            UserConsole.PrintString("Входные данные");
            UserConsole.PrintString("Подынтегральная функция:\nMath.Exp(-Math.Pow(x, 2)) * Math.Sin(x)");
            UserConsole.PrintNumber("Начало интервала", a);
            UserConsole.PrintNumber("Конец интервала", b);
            UserConsole.PrintNumber("Порядок формулы", n);
            UserConsole.PrintNumber("Относительная точность", epsilon);
        }

        private static void PrintResult(double area)
        {
            UserConsole.PrintString("\nВыходные данные");
            UserConsole.PrintNumber("Значение интеграла", area);
            UserConsole.PrintNumber("Точность интегрирования", Math.Abs(area - 0.42116423940845));
        }
    }
}