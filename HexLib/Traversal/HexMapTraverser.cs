using HexLib.Map;
using HexLib.Model;

namespace HexLib.Traversal;

public sealed class HexMapTraverser<T>
{
    private Axial _current;
    private readonly HexMapView<T> _view;
    private readonly ITraversalStrategy<T> _strategy;

    public Axial Current { get => _current; set => _current = value; }

    public HexMapTraverser(HexMapView<T> view, Axial current, ITraversalStrategy<T> strategy)
    {
        _view = view;
        _current = current;
        _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    public Axial Step(HexDirection direction)
    {
        var next = _strategy.Step(_current, direction, _view);
        _current = next;
        return _current;
    }

    public Axial Relocate(Axial destination)
    {
        var next = _strategy.Relocate(_current, destination, _view);
        _current = next;
        return _current;
    }

    public IEnumerable<(Axial axial, T value)> Traverse(Axial destination)
    {
        return _strategy.Traverse(_current, destination, _view);
    }
}