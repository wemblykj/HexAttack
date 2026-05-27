using HexLib.Model;

namespace HexLib.Boundaries;
public sealed record HexagonalBoundary(int Radius) : AxialBoundary
{
    public override bool IsWithinBoundary(Axial axial, Axial centre)
    {
        // coordinates relative to centre
        var rel = new Axial(axial.Q - centre.Q, axial.R - centre.R);
        return Math.Abs(rel.Q) <= Radius && Math.Abs(rel.R) <= Radius && Math.Abs(rel.S) <= Radius;
    }

    public override IEnumerable<Axial> EnumerateCells(Axial centre)
    {
        for (int q = -Radius; q <= Radius; q++)
        {
            int r1 = Math.Max(-Radius, -q - Radius);
            int r2 = Math.Min(Radius, -q + Radius);
            for (int r = r1; r <= r2; r++)
            {
                yield return new Axial(centre.Q + q, centre.R + r);
            }
        }
    }
}