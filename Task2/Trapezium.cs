using System;

namespace Task2
{
	public class Trapezium
	{
		private Func<double, double> Function { get; }
		private int N { get; set; }
		private double Area { get; set; }
		private readonly double _epsilon;
		private readonly double _a;
		private readonly double _b;

		public Trapezium(Func<double, double> function, double epsilon, double a, double b, int n)
		{
			Function = function;
			_epsilon = epsilon;
			_a = a;
			_b = b;
			N = n;
			
			Calculate();
		}
		
		public (int n, double area) GetResult() =>
			(N, Area);

		private void Calculate()
		{
			double S0 = 0;
			double S1 = TrapeziumCalc();

			do
			{
				N++;
				S0 = S1;
				S1 = TrapeziumCalc();
			} while (Math.Abs((S1 - S0) / S0) > _epsilon);

			Area = S1;
		}

		private double TrapeziumCalc()
		{
			double h = (_b - _a) / N;
			double sum = Function(_a) + Function(_b);
			for (int i = 1; i < N; i++)
			{
				sum += 2 * Function(_a + i * h);
			}

			return sum * h / 2;
		}
	}
}