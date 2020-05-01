using System;
using System.Text;

namespace Task1
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            var polynomial = SourceData.Polynomial;
            var sourceGreed = SourceData.CreateSourceGreed();
            var sourceValues = SourceData.CreateSourceValues(sourceGreed);
            var resultGreed = SourceData.CreateResultGreed();

            PrintSource(polynomial, sourceGreed, sourceValues, resultGreed);

            var lagrange = new Lagrange(polynomial, sourceGreed, sourceValues, resultGreed);
            var (firstDerivativeValues, secondDerivativeValues) = lagrange.GetDerivativeValues();
            var (firstDerivativeResidual, secondDerivativeResidual) = lagrange.GetDerivativeResiduals();

            PrintResult(resultGreed, firstDerivativeValues, secondDerivativeValues, firstDerivativeResidual, secondDerivativeResidual);

            UserConsole.Wait();
        }

        private static void PrintSource(int polynomial, double[] sourceGreed, double[] sourceValues, double[] resultGreed)
        {
            UserConsole.PrintString("Входные данные");
            UserConsole.PrintNumber("Порядок полинома", polynomial);
            UserConsole.PrintVector("Исходная сетка узлов", sourceGreed);
            UserConsole.PrintVector("Значения на исходной сетке", sourceValues);
            UserConsole.PrintVector("Новая сетка узлов", resultGreed);
        }

        private static void PrintResult(
            double[] resultGreed, 
            double[] firstDerivativeValues, 
            double[] secondDerivativeValues, 
            double[] firstDerivativeResidual, 
            double[] secondDerivativeResidual)
        {
            UserConsole.PrintString("\nВыходные данные");
            UserConsole.PrintVector("Новая сетка узлов", resultGreed);
            UserConsole.PrintVector("Значения первой производной", firstDerivativeValues);
            UserConsole.PrintVector("Значения второй производной", secondDerivativeValues);
            UserConsole.PrintVector("Погрешность первой производной", firstDerivativeResidual);
            UserConsole.PrintVector("Погрешность второй производной", secondDerivativeResidual);
        }
    }
}