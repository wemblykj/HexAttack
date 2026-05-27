using HexLib.Extensions;
using HexLib.Model;

namespace HexLib;

/// <summary>
/// Common hex coordinate math utilities (cube lerp & rounding).
/// Centralizes algorithms used by traversal, range, line-drawing, etc.
/// </summary>
public static class HexMath
{
    /// <summary>
    /// Linearly interpolates between two cube coordinates.
    /// Returns a fractional cube triple (x,y,z).
    /// </summary>
    public static (double x, double y, double z) Lerp(Cube a, Cube b, double t)
        => (a.X + (b.X - a.X) * t,
            a.Y + (b.Y - a.Y) * t,
            a.Z + (b.Z - a.Z) * t);

    /// <summary>
    /// Rounds a fractional cube coordinate to the nearest integer cube coordinate
    /// while preserving x + y + z == 0.
    /// </summary>
    public static Cube Round(double x, double y, double z)
    {
        double rx = Math.Round(x);
        double ry = Math.Round(y);
        double rz = Math.Round(z);

        var xDiff = Math.Abs(rx - x);
        var yDiff = Math.Abs(ry - y);
        var zDiff = Math.Abs(rz - z);

        if (xDiff > yDiff && xDiff > zDiff)
            rx = -ry - rz;
        else if (yDiff > zDiff)
            ry = -rx - rz;
        else
            rz = -rx - ry;

        return new Cube { X = (int)rx, Y = (int)ry, Z = (int)rz };
    }

    /// <summary>
    /// Convenience overload that rounds a fractional cube tuple.
    /// </summary>
    public static Cube Round((double x, double y, double z) frac) => Round(frac.x, frac.y, frac.z);
}