using System;

namespace Task1
{
    public static class DerivativeFunctions
    {
        public static double FirstDerivative(double x) =>
            -1 / (Math.Log(10) * x * Math.Pow(Math.Log10(x) + 1, 2));

        public static double SecondDerivative(double x) =>
            Math.Pow(Math.Log(10) * x * (Math.Log10(x) + 1), -2) * (Math.Log(10) + 2 * Math.Pow(Math.Log10(x) + 1, -1));
    }
}
