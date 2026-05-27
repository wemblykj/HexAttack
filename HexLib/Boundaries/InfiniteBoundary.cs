using HexLib.Model;

namespace HexLib.Boundaries;

public sealed record InfiniteBoundary : AxialBoundary
{
    public override bool IsWithinBoundary(Axial axial, Axial centre)
    {
        return true;
    }
}