using HexLib.Model;

namespace HexLib.Boundaries;

public sealed record CompositeBoundary(AxialBoundary[] Parts, bool AllMustMatch = true) : AxialBoundary
{
    public override bool IsWithinBoundary(Axial axial, Axial centre)
    {
        return AllMustMatch
            ? Parts.All(p => p.IsWithinBoundary(axial, centre))
            : Parts.Any(p => p.IsWithinBoundary(axial, centre));
    }
}
