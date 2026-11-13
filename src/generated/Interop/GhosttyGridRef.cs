namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyGridRef
{
    public void* node;

    [NativeTypeName("uint16_t")]
    public ushort x;

    [NativeTypeName("uint16_t")]
    public ushort y;
}
