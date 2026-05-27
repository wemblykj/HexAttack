using HexLib.Model;

namespace HexLib.Extensions;

public static class CubeExtensions
{
    public static Axial ToAxial(this Cube cube)
    {
        return new Axial
        {
            Q = cube.X,
            R = cube.Y
        };
    }

    public static Cube Add(this Cube a, Cube b) => new()
    {
        X = a.X + b.X,
        Y = a.Y + b.Y,
        Z = a.Z + b.Z
    };

    public static Cube Subtract(this Cube a, Cube b) => new()
    {
        X = a.X - b.X,
        Y = a.Y - b.Y,
        Z = a.Z - b.Z
    };

    public static int Distance(this Cube a, Cube b)
    {
        return (Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.Z - b.Z)) / 2;
    }
}
