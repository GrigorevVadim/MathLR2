using System;

namespace Task3
{
	public class Gauss
	{
		private Func<double, double> Function { get; }
		private double Area { get; set; }
		private readonly double[,] _gaussTableA;
		private readonly double[,] _gaussTableT;

		public Gauss(Func<double, double> function, double epsilon, double a, double b, int n)
		{
			Function = function;

			_gaussTableT = GaussTables.CreateTableT();
			_gaussTableA = GaussTables.CreateTableA();
			
			Calculate(a, b, n, epsilon);
		}
		
		public double GetResult() => Area;

		void Calculate(double a, double b, int n, double epsilon)
		{
			double S0 = 0;
			double S1 = GaussCalc(a, b, n);

			do
			{
				S0 = S1;
				S1 = GaussCalc(a, b, ++n);
			} while (Math.Abs((S1 - S0) / S0) > epsilon);

			Area = S1;
		}

		double GaussCalc(double a, double b, int n)
		{
			double S = 0;

			if (n < 7)
			{
				for (int i = 0; i < n; i++)
				{
					double xi = (b + a) / 2 + (b - a) / 2 * _gaussTableT[n - 1,i];
					S += _gaussTableA[n - 1,i] * Function(xi);
				}

				S *= (b - a) / 2;
			}
			else
			{
				S = GaussCalc(a, a + (b - a) / 2, n / 2);
				S += GaussCalc(a + (b - a) / 2, b, n / 2);
			}

			return S;
		}
	}
}