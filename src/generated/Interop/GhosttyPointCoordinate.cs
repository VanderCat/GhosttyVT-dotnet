namespace GhosttyVT.Interop;

public partial struct GhosttyPointCoordinate
{
    [NativeTypeName("uint16_t")]
    public ushort x;

    [NativeTypeName("uint32_t")]
    public uint y;
}
