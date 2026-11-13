namespace GhosttyVT.Interop;

public partial struct GhosttyTerminalResizeWindowGrid
{
    [NativeTypeName("uint16_t")]
    public ushort rows;

    [NativeTypeName("uint16_t")]
    public ushort columns;
}
