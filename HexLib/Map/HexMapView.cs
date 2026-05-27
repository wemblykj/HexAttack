using HexLib.Boundaries;
using HexLib.Model;

namespace HexLib.Map;
public class HexMapView<T>
{
    public IReadOnlyDictionary<Axial, T> Hexes { get; }

    public Axial Origin { get; init; }

    public AxialBoundary Boundary { get; init; } = new InfiniteBoundary();

    public HexMapView(HexMap<T> hexMap, Axial origin)
    {
        Hexes = hexMap.Hexes;
        Origin = origin;
    }

}
