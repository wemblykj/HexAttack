using HexLib.Extensions;
using HexLib.Model;

namespace HexLib.Transforms;

public static class TransformExtensions
{
    // Convert axial coordinate to pixel coordinates using layout
    public static Point ToPoint(this Axial a, HexLayout layout)
    {
        var o = layout.Orientation;
        double x = (o.F0 * a.Q + o.F1 * a.R) * layout.SizeX;
        double y = (o.F2 * a.Q + o.F3 * a.R) * layout.SizeY;
        return new Point(x + layout.Origin.X, y + layout.Origin.Y);
    }

    /// <summary>
    /// Convert pixel coordinate to nearest axial (uses cube rounding)
    /// </summary>
    /// <param name="p"></param>
    /// <param name="layout"></param>
    /// <returns></returns>
    public static Axial ToAxial(this Point p, HexLayout layout)
    {
        var o = layout.Orientation;
        double px = (p.X - layout.Origin.X) / layout.SizeX;
        double py = (p.Y - layout.Origin.Y) / layout.SizeY;

        double q = o.B0 * px + o.B1 * py;
        double r = o.B2 * px + o.B3 * py;
        // fractional cube
        double x = q;
        double y = r;
        double z = -x - y;

        return HexMath.Round(x, y, z).ToAxial();
    }

}