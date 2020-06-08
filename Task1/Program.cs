using System;
using System.Text;

namespace Task1
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            var sourceGreed = SourceData.CreateSourceGreed();
            var sourceValues = SourceData.CreateSourceValues(sourceGreed);
            var resultGreed = SourceData.CreateResultGreed();
            if (!UserConsole.GetValue("Введите порядок полинома", out var polynomial, 1, sourceGreed.Length - 1))
            {
                UserConsole.PrintString("Введенное значение не распознается как порядок полинома");
                UserConsole.Wait();
                return;
            }

            PrintSource(polynomial, sourceGreed, sourceValues, resultGreed);

            var lagrange = new Lagrange(polynomial, sourceGreed, sourceValues, resultGreed);
            var (firstDerivativePolynomialValues, secondDerivativePolynomialValues) = lagrange.GetDerivativePolynomialValues();
            var (firstDerivativeFunctionValues, secondDerivativeFunctionValues) = lagrange.GetDerivativeFunctionValues();
            var (firstDerivativeResidual, secondDerivativeResidual) = lagrange.GetDerivativeResiduals();

            PrintResult(
                resultGreed, 
                firstDerivativeFunctionValues, 
                secondDerivativeFunctionValues, 
                firstDerivativePolynomialValues, 
                secondDerivativePolynomialValues, 
                firstDerivativeResidual, 
                secondDerivativeResidual);

            UserConsole.Wait();
        }

        private static void PrintSource(int polynomial, double[] sourceGreed, double[] sourceValues, double[] resultGreed)
        {
            UserConsole.PrintString("Входные данные");
            UserConsole.PrintNumber("Порядок полинома", polynomial);
            UserConsole.PrintTable(
                ("x", sourceGreed),
                ("f(x)", sourceValues));
            UserConsole.PrintVector("Новая сетка узлов", resultGreed);
        }

        private static void PrintResult(
            double[] resultGreed, 
            double[] firstDerivativeFunctionValues, 
            double[] secondDerivativeFunctionValues, 
            double[] firstDerivativePolynomialValues, 
            double[] secondDerivativePolynomialValues, 
            double[] firstDerivativeResidual, 
            double[] secondDerivativeResidual)
        {
            UserConsole.PrintString("\nВыходные данные");
            
            UserConsole.PrintString("\nПервая производная");
            UserConsole.PrintTable(
                ("xi", resultGreed), 
                ("f'(xi)", firstDerivativeFunctionValues), 
                ("P'(xi)", firstDerivativePolynomialValues), 
                ("R'(xi)", firstDerivativeResidual));
            
            UserConsole.PrintString("\nВторая производная");
            UserConsole.PrintTable(
                ("xi", resultGreed), 
                ("f''(xi)", secondDerivativeFunctionValues), 
                ("P''(xi)", secondDerivativePolynomialValues), 
                ("R''(xi)", secondDerivativeResidual));
        }
    }
}