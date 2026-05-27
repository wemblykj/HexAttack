namespace HexLib.Model;

public readonly record struct Axial
{
    public static Axial Zero => new(0, 0);

    public int Q { get; init; }
    public int R { get; init; }
    public readonly int S => -Q - R;

    public Axial(int q, int r)
    {
        Q = q;
        R = r;
    }

    public Axial()
    {
        Q = 0;
        R = 0;
    }
}
