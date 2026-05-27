using HexLib.Map;
using HexLib.Model;

namespace HexLib.Traversal;

public interface ITraversalStrategy<T>
{
    // Compute the new location if relocating; return the (possibly unchanged) axial.
    Axial Relocate(Axial current, Axial destination, HexMapView<T> view);

    // Compute a single step from current in given direction; return new current (or unchanged).
    Axial Step(Axial current, HexDirection direction, HexMapView<T> view);

    // Produce the sequence of hexes along a traversal from current to destination.
    IEnumerable<(Axial axial, T value)> Traverse(Axial current, Axial destination, HexMapView<T> view);
}
