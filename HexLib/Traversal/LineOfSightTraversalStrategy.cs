using HexLib.Extensions;
using HexLib.Map;
using HexLib.Model;
using HexLib.Rules;

namespace HexLib.Traversal;

public sealed class LineOfSightTraversalStrategy<T> : ITraversalStrategy<T>
{
    private readonly IMovementRule<T>? _movementRule;

    public LineOfSightTraversalStrategy(IMovementRule<T>? movementRule = null)
    {
        _movementRule = movementRule;
    }

    public Axial Relocate(Axial current, Axial destination, HexMapView<T> view)
    {
        if (view.Boundary.IsWithinBoundary(destination, view.Origin))
            return destination;
        return current;
    }

    public Axial Step(Axial current, HexDirection direction, HexMapView<T> view)
    {
        var next = current.Add(direction.ToAxial());
        if (!view.Boundary.IsWithinBoundary(next, view.Origin)) return current;
        if (_movementRule != null && !_movementRule.AllowMove(current, next, view)) return current;
        return next;
    }

    public IEnumerable<(Axial axial, T value)> Traverse(Axial current, Axial destination, HexMapView<T> view)
    {
        var a = current.ToCube();
        var b = destination.ToCube();
        var n = a.Distance(b);
        if (n == 0)
        {
            if (view.Boundary.IsWithinBoundary(current, view.Origin) && view.Hexes.TryGetValue(current, out var v0))
                yield return (current, v0);
            yield break;
        }

        for (int i = 0; i <= n; i++)
        {
            var t = (double)i / n;
            var (x, y, z) = HexMath.Lerp(a, b, t);
            var axial = HexMath.Round(x, y, z).ToAxial();

            if (!view.Boundary.IsWithinBoundary(axial, view.Origin))
                yield break;

            if (view.Hexes.TryGetValue(axial, out var value))
                yield return (axial, value);
        }
    }

}
