using HexLib.Model;

namespace HexLib.Boundaries
{
    public sealed record RectangularBoundary : AxialBoundary
    {
        public int Width { get; }
        public int Height { get; }
        public RectangularBoundary(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override bool IsWithinBoundary(Axial axial, Axial centre)
        {
            var rel = new Axial(axial.Q - centre.Q, axial.R - centre.R);
            return rel.Q >= 0 && rel.Q < Width && rel.R >= 0 && rel.R < Height;
        }
    }
}