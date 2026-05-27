using HexLib.Extensions;

namespace HexLib.Model;

/// <summary>
/// Six canonical hex directions in axial coordinates.
/// These names are ordinal and layout-agnostic — they do not imply "pointy" or "flat" rendering.
/// Use <see cref="DirectionExtensions.UnitDirections"/> to get the axial vector for each value.
/// </summary>
public enum HexDirection
{
    Direction0 = 0,
    Direction1 = 1,
    Direction2 = 2,
    Direction3 = 3,
    Direction4 = 4,
    Direction5 = 5
}
