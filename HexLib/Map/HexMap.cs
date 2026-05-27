using HexLib.Model;

namespace HexLib.Map;

public sealed class HexMap<T>
{
    private readonly IReadOnlyDictionary<Axial, T> _hexes = new Dictionary<Axial, T>();

    public HexMap(Dictionary<Axial, T> hexes)
    {
        _hexes = hexes;
    }

    public IReadOnlyDictionary<Axial, T> Hexes => _hexes;
}
