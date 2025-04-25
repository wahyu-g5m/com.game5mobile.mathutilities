using BigInteger = System.Numerics.BigInteger;
using UnityEngine;

namespace Toolbox.MathUtilities
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
    }
}