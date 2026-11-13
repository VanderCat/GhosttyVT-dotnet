namespace GhosttyVT.Interop;

public partial struct GhosttyRenderStateRowSelection
{
    [NativeTypeName("size_t")]
    public nuint size;

    [NativeTypeName("uint16_t")]
    public ushort start_x;

    [NativeTypeName("uint16_t")]
    public ushort end_x;
}
