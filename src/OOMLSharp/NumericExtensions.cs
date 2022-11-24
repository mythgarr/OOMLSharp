using System.Globalization;
using System.Numerics;

namespace OOMLSharp;

public static class NumericExtensions
{
    /// <summary>
    /// Convert vector3 into an OpenSCAD array string.
    /// </summary>
    public static string ToScadString(this Vector3 vector3)
    {
        const string formatString = "[{0}, {1}, {2}]";
        object[] components = { vector3.X, vector3.Y, vector3.Z };
        return ToStringHelper(formatString, components);
    }

    /// <summary>
    /// Convert matrix4X4 into an OpenSCAD array string.
    /// </summary>
    public static string ToScadString(this Matrix4x4 matrix4X4)
    {
        const string formatString = """
            [ [{0}, {1}, {2}, {3}],
              [{4}, {5}, {6}, {7}],
              [{8}, {9}, {10}, {11}],
              [{12}, {13}, {14}, {15}] ]
            """;
        float[] components =
        {
            matrix4X4.M11, matrix4X4.M12, matrix4X4.M13, matrix4X4.M14,
            matrix4X4.M21, matrix4X4.M22, matrix4X4.M23, matrix4X4.M24,
            matrix4X4.M31, matrix4X4.M32, matrix4X4.M33, matrix4X4.M34,
            matrix4X4.M41, matrix4X4.M42, matrix4X4.M43, matrix4X4.M44,
        };
        return ToStringHelper(formatString, components);
    }

    private static string ToStringHelper(string formatString, params object[] args)
    {
        return String.Format(CultureInfo.InvariantCulture, formatString, args);
    }
}