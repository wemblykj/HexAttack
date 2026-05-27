using System.Drawing;

namespace HexLib.Model;

public sealed record Orientation(
    double F0, double F1, double F2, double F3,
    double B0, double B1, double B2, double B3,
    double StartAngle);

public sealed record HexLayout(Orientation Orientation, double SizeX, double SizeY, Point Origin)
{
    public static readonly Orientation Pointy = new(
        Math.Sqrt(3.0), Math.Sqrt(3.0) / 2.0, 0.0, 3.0 / 2.0,
        Math.Sqrt(3.0) / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0,
        0.5);

    public static readonly Orientation Flat = new(
        3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0),
        2.0 / 3.0, 0.0, -1.0 / 3.0, Math.Sqrt(3.0) / 3.0,
        0.0);
}

public readonly record struct Point(double X, double Y);
