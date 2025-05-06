using BigInteger = System.Numerics.BigInteger;
using UnityEngine;
using System;

namespace Five.Utils
{
    public static class MathUtils
    {
        public static float Map(float aValue, float aMin, float aMax, float bMin, float bMax)
        {
            var normal = Mathf.InverseLerp(aMin, aMax, aValue);
            return Mathf.Lerp(bMin, bMax, normal);
        }

        public static float Round(float value, int decimalPoint = 0)
        {
            var decimalValue = 10f * decimalPoint;
            var roundedValue = (RoundToInt(value * decimalValue)) / decimalValue;
            return roundedValue;
        }

        public static int RoundToInt(float value)
        {
            var flooredValue = Mathf.Floor(value);
            var roundedValue = value - flooredValue >= 0.5f ? flooredValue + 1 : flooredValue;
            return (int)roundedValue;
        }

        public static BigInteger RoundToBigInteger(double value)
        {
            var flooredValue = System.Math.Floor(value);
            var roundedValue = value - flooredValue >= 0.5f ? flooredValue + 1 : flooredValue;
            return (BigInteger)roundedValue;
        }

        public static int CeilToInt(float value)
        {
            var decimalValue = value - (int)value;
            var ceilValue = decimalValue > 0f ? value + 1 : value;
            return (int)ceilValue;
        }

        #region Easings
        public static float EaseInQuad(float start, float end, float t)
        {
            t = Mathf.Clamp01(t);
            return start + (end - start) * t * t;
        }

        public static float EaseInOutSine(float start, float end, float t)
        {
            t = Mathf.Clamp01(t);
            return start + (end - start) * (-0.5f * (Mathf.Cos(Mathf.PI * t) - 1));
        }

        public static float EaseInBack(float t, float power = 1.70158f)
        {
            float c1 = power;
            float c3 = c1 + 1;
            return c3 * t * t * t - c1 * t * t;
        }

        public static float EaseOutBack(float t, float power = 1.70158f)
        {
            float c1 = power;
            float c3 = c1 + 1;

            return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
        }

        public static float EaseInQuad(float t)
        {
            return t * t;
        }

        public static float EaseOutQuad(float t)
        {
            return 1 - (1 - t) * (1 - t);
        }
        #endregion

        # region Abbreviations
        public static ValueTuple<string, string> FormatNumber(long number)
        {
            string roundedNumberString = string.Empty;
            long roundedNumber = number;
            long thousand = 1000;
            long modValue = 0;
            int i = 0;
            while (Mathf.Abs(roundedNumber) >= thousand)
            {
                modValue = roundedNumber % thousand;
                roundedNumber /= thousand;

                i++;
            }

            string abbreviation = string.Empty;

            if (i > 0)
            {
                if (roundedNumber < 1)
                {
                    i -= 1;
                    roundedNumber *= thousand;
                    roundedNumber += modValue;
                }

                if (i < Abbreviations.Length)
                {
                    abbreviation = Abbreviations[i];
                }
                else
                {
                    var abbDistance = i - Abbreviations.Length;
                    var secondChar = abbDistance % 26;
                    var firstChar = Mathf.Clamp(abbDistance / 26, 0, 25);

                    abbreviation = Convert.ToChar('a' + firstChar).ToString() + Convert.ToChar('a' + secondChar).ToString();
                }
            }

            if (i == 1 && roundedNumber < 1)
            {
                roundedNumberString = Format(roundedNumber);
            }
            else
            {
                roundedNumberString = Format(roundedNumber);
                var roundedNumberSplit = Format(roundedNumber).Split(",");
                if (roundedNumberSplit.Length == 2)
                {
                    var decimalPoint = roundedNumberSplit[0].Length >= 3 ? 1 : 2;
                    roundedNumberString = roundedNumberSplit[0] + "," + roundedNumberSplit[1].Substring(0, decimalPoint);
                }
            }
            roundedNumberString = roundedNumberString.Replace(",", ".");
            return new ValueTuple<string, string>(roundedNumberString, abbreviation);
        }

        public static ValueTuple<string, string> FormatNumber(BigInteger number)
        {
            string roundedNumberString = string.Empty;
            var roundedNumber = number;
            var thousand = 1000;
            var modValue = new BigInteger();
            int i = 0;
            while (BigInteger.Abs(roundedNumber) >= thousand)
            {
                modValue = roundedNumber % thousand;
                roundedNumber /= thousand;

                i++;
            }

            string abbreviation = string.Empty;
            if (i > 0)
            {
                if (i == 1 && roundedNumber < 1)
                {
                    i -= 1;
                }

                roundedNumber *= thousand;
                roundedNumber += modValue;

                if (i < Abbreviations.Length)
                {
                    abbreviation = Abbreviations[i];
                }
                else
                {
                    var abbDistance = i - Abbreviations.Length;
                    var secondChar = abbDistance % 26;
                    var firstChar = Mathf.Clamp(abbDistance / 26, 0, 25);

                    abbreviation = Convert.ToChar('a' + firstChar).ToString() + Convert.ToChar('a' + secondChar).ToString();
                }
            }

            if (i == 1 && roundedNumber < 1)
            {
                roundedNumberString = Format(roundedNumber);
            }
            else
            {
                roundedNumberString = Format(roundedNumber);
                var roundedNumberSplit = Format(roundedNumber).Split(",");
                if (roundedNumberSplit.Length == 2)
                {
                    var decimalPoint = roundedNumberSplit[0].Length >= 3 ? 1 : 2;
                    roundedNumberString = roundedNumberSplit[0] + "," + roundedNumberSplit[1].Substring(0, decimalPoint);
                }
            }
            roundedNumberString = roundedNumberString.Replace(",", ".");
            return new ValueTuple<string, string>(roundedNumberString, abbreviation);
        }

        private static readonly string[] Abbreviations = new string[5]
        {
            "",
            "K",
            "M",
            "B",
            "T"
        };

        private static string Format(long i)
        {
            return string.Format("{0:n0}", i);
        }

        private static string Format(BigInteger i)
        {
            return i.ToString("N0");
        }
        #endregion
    }
}