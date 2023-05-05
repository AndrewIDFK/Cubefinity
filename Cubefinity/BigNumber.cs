using System;

namespace Cubefinity
{
    public class BigNumber
    {
        private double _exponent;

        public BigNumber(double value)
        {
            _exponent = Math.Log10(value);
        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            // Use logarithmic addition formula to add two numbers
            double resultExponent = Math.Log10(Math.Pow(10, a._exponent) + Math.Pow(10, b._exponent));
            return new BigNumber(Math.Pow(10, resultExponent));
        }

        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            // Use logarithmic multiplication formula to multiply two numbers
            double resultExponent = a._exponent + b._exponent;
            return new BigNumber(Math.Pow(10, resultExponent));
        }

        public override string ToString()
        {
            // Return the number in scientific notation
            double value = Math.Pow(10, _exponent);

            if (value < 100)
            {
                return value.ToString("0.000");
            }
            else
            {
                if (value < 1000)
                {
                    return value.ToString("0.00");
                }
                else
                {
                    if (value < 10000)
                    {
                        return value.ToString("0.0");
                    }
                    else
                    {
                        if (value < 1e6) // 1 million
                        {
                            return value.ToString("0");
                        }
                        else 
                        {
                            return value.ToString("0.000e0");
                        }
                    }
                }
            }
        }
    }
}
