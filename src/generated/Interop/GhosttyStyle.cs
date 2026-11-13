namespace GhosttyVT.Interop;

public partial struct GhosttyStyle
{
    public GhosttyStyleColor fg_color;

    public GhosttyStyleColor bg_color;

    public GhosttyStyleColor underline_color;

    [NativeTypeName("GhosttyStyleFlags")]
    public ushort flags;

    [NativeTypeName("uint16_t")]
    public ushort reserved;
}
