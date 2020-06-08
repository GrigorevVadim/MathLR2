using System;

namespace Task3
{
    public static class SourceData
    {
        public static double Function(double x) => 
            Math.Exp(-Math.Pow(x, 2)) * Math.Sin(x);

        public static int N = 6;
        public static double A = 0;
        public static double B = 2;
    }
}