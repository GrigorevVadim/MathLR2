﻿using System;

namespace Task1
{
    public static class SourceData
    {
        public static double[] CreateSourceGreed()
        {
            var greed = new double[26];
            for (int i = 0; i < greed.Length; i++)
            {
                greed[i] = 1 + i * 2;
            }

            return greed;
        }

        public static double[] CreateSourceValues(double[] sourceGreed)
        {
            var resultGreed = new double[sourceGreed.Length];
            for (int i = 0; i < resultGreed.Length; i++)
            {
                resultGreed[i] = InvokeSourceFunction(sourceGreed[i]);
            }

            return resultGreed;
        }

        public static double[] CreateResultGreed()
        {
            var greed = new double[51];
            for (int i = 0; i < greed.Length; i++)
            {
                greed[i] = 1 + i;
            }

            return greed;
        }
        
        private static double InvokeSourceFunction(double x) => 
            1 / (1 + Math.Log10(x));
    }
}