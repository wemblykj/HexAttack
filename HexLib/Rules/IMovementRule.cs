using HexLib.Map;
using HexLib.Model;

namespace HexLib.Rules;

public interface IMovementRule<T>
{
    // Return true if moving from -> to is allowed in the given view.
    bool AllowMove(Axial from, Axial to, HexMapView<T> view);
}
