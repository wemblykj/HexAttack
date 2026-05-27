using HexLib.Model;

namespace HexLib.Map;

public static class HexMapViewExtensions 
{
    public static HexMap<T> ToMap<T>(this HexMapView<T> hexMapView)
    {
        var hexes = hexMapView.Hexes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        return new HexMap<T>(hexes);
    }

    public static HexMapView<T> ToView<T>(this HexMap<T> hexMap, Axial centre)
    {
        return new HexMapView<T>(hexMap, centre);
    }

}
