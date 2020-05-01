using System;

namespace Task1
{
    public class Lagrange
    {
        private readonly int _polynomial;
        private readonly double[] _sourceGreed;
        private readonly double[] _sourceValues;
        private readonly double[] _resultGreed;
        private double[] ResultValues { get; set; }
        private double[] FirstDerivativeValues { get; set; }
        private double[] SecondDerivativeValues { get; set; }
        private double[] FirstDerivativeResidual { get; set; }
        private double[] SecondDerivativeResidual { get; set; }

        public Lagrange(int polynomial, double[] sourceGreed, double[] sourceValues, double[] resultGreed)
        {
            _polynomial = polynomial;
            _sourceGreed = sourceGreed;
            _sourceValues = sourceValues;
            _resultGreed = resultGreed;

            var resultDimension = _resultGreed.Length;
            ResultValues = new double[resultDimension];
            FirstDerivativeValues = new double[resultDimension];
            SecondDerivativeValues = new double[resultDimension];
            FirstDerivativeResidual = new double[resultDimension];
            SecondDerivativeResidual = new double[resultDimension];

            Calculate();
        }

        public (double[] firstDerivativeValues, double[] secondDerivativeValues) GetDerivativeValues() =>
            (FirstDerivativeValues, SecondDerivativeValues);

        public (double[] firstDerivativeResidual, double[] secondDerivativeResidual) GetDerivativeResiduals() =>
            (FirstDerivativeResidual, SecondDerivativeResidual);

        private void Calculate()
        {
            CalculateValues();
            CalculateDerivatives();
            CalculateResiduals();
        }

        void CalculateValues()
        {
            int currentResultElementPosition = 0;

            while (currentResultElementPosition < _resultGreed.Length)
            {
                var currentSourceElementPosition = GetSourceElementByResultElement(currentResultElementPosition);
                ResultValues[currentResultElementPosition] = CalculateValuesElement(_resultGreed[currentResultElementPosition], currentSourceElementPosition);

                currentResultElementPosition++;
            }
        }

        int GetSourceElementByResultElement(int resultElementPosition)
        {
            var resultElement = _resultGreed[resultElementPosition];
            int sourceElementPosition = 0;

            for (int i = 0; i < _sourceGreed.Length; i++)
            {
                if (_sourceGreed[i] <= resultElement) 
                    sourceElementPosition = i;
            }

            if (sourceElementPosition + _polynomial >= _sourceGreed.Length)
                return _sourceGreed.Length - _polynomial - 1;

            return sourceElementPosition;
        }

        double CalculateValuesElement(double currentCalculateElement, int currentSourceElementPosition)
        {
            double sum = 0;
            for (int i = currentSourceElementPosition; i <= currentSourceElementPosition + _polynomial; i++)
            {
                double temp = _sourceValues[i];
                for (int j = currentSourceElementPosition; j <= currentSourceElementPosition + _polynomial; j++)
                {
                    if (i == j) continue;
                    temp *= (currentCalculateElement - _sourceGreed[j]);
                    temp /= (_sourceGreed[i] - _sourceGreed[j]);
                }
                sum += temp;
            }

            return sum;
        }

        private void CalculateDerivatives()
        {
            int currentElementPosition = 0;

            while (currentElementPosition < _resultGreed.Length)
            {
                var startElementPosition = GetStartElementByCurrentElement(currentElementPosition);
                FirstDerivativeValues[currentElementPosition] = CalculateDerivativeElement(currentElementPosition, startElementPosition);
                SecondDerivativeValues[currentElementPosition] = CalculateSecondDerivativeElement(currentElementPosition, startElementPosition);

                currentElementPosition++;
            }
        }

        private int GetStartElementByCurrentElement(int currentElementPosition)
        {
            if (currentElementPosition + _polynomial >= _resultGreed.Length)
                return _resultGreed.Length - _polynomial - 1;

            return currentElementPosition;
        }

        double CalculateDerivativeElement(int currentElementPosition, int startElementPosition)
        {
            double sum = 0;
            var cur = _resultGreed[currentElementPosition];

            for (int i = startElementPosition; i <= startElementPosition + _polynomial; i++)
            {
                if (i == currentElementPosition) continue;

                sum += 1 / (cur - _resultGreed[i]);
            }
            sum *= ResultValues[currentElementPosition];

            double temp = 0;
            for (int i = startElementPosition; i <= startElementPosition + _polynomial; i++)
            {
                if (i == currentElementPosition) continue;
                double temp1 = ResultValues[i];

                temp1 *= (1 / (cur - _resultGreed[i]));

                for (int j = startElementPosition; j <= startElementPosition + _polynomial; j++)
                {
                    if (j == i) continue;

                    temp1 *= (1 / (_resultGreed[i] - _resultGreed[j]));
                }

                temp += temp1;
            }

            for (int i = startElementPosition; i <= startElementPosition + _polynomial; i++)
            {
                if (i == currentElementPosition) continue;

                temp *= (cur - _resultGreed[i]);
            }

            return sum + temp;
        }

        double CalculateSecondDerivativeElement(int currentElementPosition, int startElementPosition)
        {
            double sum = 0;
            var cur = _resultGreed[currentElementPosition];

            for (int i = startElementPosition; i <= startElementPosition + _polynomial; i++)
            {
                if (i == currentElementPosition) continue;

                double sum1 = 0;
                for (int j = i + 1; j <= startElementPosition + _polynomial; j++)
                {
                    if (j == i || j == currentElementPosition) continue;
			
                    sum1 += (1 / ((cur - _resultGreed[j]) * (cur - _resultGreed[i])));
                }

                sum += sum1;
            }
            sum *= ResultValues[currentElementPosition];

            double temp = 0;
            for (int i = startElementPosition; i <= startElementPosition + _polynomial; i++)
            {
                if (i == currentElementPosition) continue;
                double temp1 = ResultValues[i];

                temp1 *= (1 / (cur - _resultGreed[i]));

                for (int j = startElementPosition; j <= startElementPosition + _polynomial; j++)
                {
                    if (j == i) continue;

                    temp1 *= (1 / (_resultGreed[i] - _resultGreed[j]));
                }

                double temp2 = 0;
                for (int j = startElementPosition; j <= startElementPosition + _polynomial; j++)
                {
                    if (j == i || j == currentElementPosition) continue;

                    temp2 += (1 / (cur - _resultGreed[j]));
                }
                temp1 *= temp2;

                temp += temp1;
            }

            for (int i = startElementPosition; i <= startElementPosition + _polynomial; i++)
            {
                if (i == currentElementPosition) continue;

                temp *= (cur - _resultGreed[i]);
            }

            return 2 * (sum + temp);
        }

        private void CalculateResiduals()
        {
            for (int i = 0; i < _resultGreed.Length; i++)
            {
                FirstDerivativeResidual[i] = Math.Abs(DerivativeFunctions.FirstDerivative(_resultGreed[i]) - FirstDerivativeValues[i]);
                SecondDerivativeResidual[i] = Math.Abs(DerivativeFunctions.SecondDerivative(_resultGreed[i]) - SecondDerivativeValues[i]);
            }
        }
    }
}