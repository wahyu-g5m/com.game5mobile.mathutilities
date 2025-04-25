using BigInteger = System.Numerics.BigInteger;
using UnityEngine;

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
}