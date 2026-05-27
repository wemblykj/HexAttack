using HexLib.Boundaries;
using HexLib.Model;

namespace HexLib.Map;

public static class HexMapExtensions
{
    public static HexMapView<T> ToView<T>(this HexMap<T> hexMap)
    {
        return new HexMapView<T>(hexMap, Axial.Zero);
    }

    public static HexMapView<T> ToView<T>(this HexMap<T> hexMap, Axial origin)
    {
        return new HexMapView<T>(hexMap, origin);
    }

    public static HexMapView<T> ToBoundedView<T>(this HexMap<T> hexMap, Axial origin, AxialBoundary boundary)
    {
        var view = new HexMapView<T>(hexMap, origin)
        {
            Origin = origin,
            Boundary = boundary
        };

        return view;
    }

    public static HexMapView<T> ToRadialView<T>(this HexMap<T> hexMap, Axial origin, int radius)
    {
        var view = new HexMapView<T>(hexMap, origin)
        {
            Origin = origin,
            Boundary = new HexagonalBoundary(radius)
        };

        return view;
    }
}
