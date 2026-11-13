namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyColorX11Entry
{
    [NativeTypeName("const char *")]
    public sbyte* name;

    public GhosttyColorRgb color;
}
