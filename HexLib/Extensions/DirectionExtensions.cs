using HexLib.Model;

namespace HexLib.Extensions;

public static class DirectionExtensions
{
    /// <summary>
    /// Canonical axial unit vectors for the six directions.
    /// The ordering is chosen to match common axial neighbor order:
    /// (1,0), (1,-1), (0,-1), (-1,0), (-1,1), (0,1).
    /// Rendering code may rotate or relabel these for pointy/flat layouts.
    /// </summary>
    public static readonly Axial[] UnitDirections =
    [
        new Axial(1, 0),   // Direction0
        new Axial(1, -1),  // Direction1
        new Axial(0, -1),  // Direction2
        new Axial(-1, 0),  // Direction3
        new Axial(-1, 1),  // Direction4
        new Axial(0, 1)    // Direction5
    ];

    public static Axial ToAxial(this HexDirection d) => UnitDirections[(int)d];

    public static HexDirection Opposite(this HexDirection d) => (HexDirection)(((int)d + 3) % 6);

    public static HexDirection Rotate(this HexDirection d, int steps)
    {
        var v = ((int)d + steps) % 6;
        if (v < 0) v += 6;
        return (HexDirection)v;
    }

    public static Axial Move(this Axial a, HexDirection d) => a.Add(d.ToAxial());
}