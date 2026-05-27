using HexLib.Model;

namespace HexLib.Boundaries;

public abstract record AxialBoundary
{
    /// <summary>
    /// Returns true if the supplied axial coordinate is within this boundary
    /// when the boundary is centered on <paramref name="centre"/>.
    /// </summary>
    public abstract bool IsWithinBoundary(Axial axial, Axial centre);

    /// <summary>
    /// Enumerates all axial coordinates contained by this boundary when centered on <paramref name="centre"/>.
    /// Default: not required to be implemented, but useful for many boundaries.
    /// </summary>
    public virtual IEnumerable<Axial> EnumerateCells(Axial centre) => throw new NotSupportedException();
}
