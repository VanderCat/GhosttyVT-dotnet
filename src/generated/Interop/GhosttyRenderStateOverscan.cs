namespace GhosttyVT.Interop;

public partial struct GhosttyRenderStateOverscan
{
    [NativeTypeName("uint16_t")]
    public ushort above;

    [NativeTypeName("uint16_t")]
    public ushort below;
}
