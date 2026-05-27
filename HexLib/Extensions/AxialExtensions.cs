using HexLib.Model;

namespace HexLib.Extensions;

public static class AxialExtensions
{
    public static Cube ToCube(this Axial axial)
    {
        return new Cube
        {
            X = axial.Q,
            Y = axial.R,
            Z = axial.S
        };
    }

    public static Axial Add(this Axial a, Axial b)
    {
        return new Axial(a.Q + b.Q, a.R + b.R);
    }

    public static Axial Subtract(this Axial a, Axial b)
    {
        return new Axial(a.Q - b.Q, a.R - b.R);
    }

    public static int Distance(this Axial a, Axial b)
    {
        return (Math.Abs(a.Q - b.Q) + Math.Abs(a.R - b.R) + Math.Abs(a.S - b.S)) / 2;
    }

    public static Axial ToUnitDirection(this Axial axial)
    {
        if (axial.Q == 0 && axial.R == 0)
            return Axial.Zero;

        var cube = axial.ToCube();

        // normalize to length 1 in cube space (floating)
        double length = (Math.Abs(cube.X) + Math.Abs(cube.Y) + Math.Abs(cube.Z)) / 2.0;
        if (length == 0)
            return Axial.Zero;

        double nx = cube.X / length;
        double ny = cube.Y / length;
        double nz = cube.Z / length;

        return HexMath.Round(nx, ny, nz).ToAxial();
    }

}
