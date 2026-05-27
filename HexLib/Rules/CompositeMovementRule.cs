using HexLib.Map;
using HexLib.Model;

namespace HexLib.Rules;

public sealed class CompositeMovementRule<T> : IMovementRule<T>
{
    private readonly IReadOnlyList<IMovementRule<T>> _rules;

    public CompositeMovementRule(params IMovementRule<T>[] rules) => _rules = rules;

    public bool AllowMove(Axial from, Axial to, HexMapView<T> view)
    {
        foreach (var r in _rules)
            if (!r.AllowMove(from, to, view))
                return false;
        return true;
    }
}
