namespace GhosttyVT.Interop;

public partial struct GhosttySizeReportSize
{
    [NativeTypeName("uint16_t")]
    public ushort rows;

    [NativeTypeName("uint16_t")]
    public ushort columns;

    [NativeTypeName("uint32_t")]
    public uint cell_width;

    [NativeTypeName("uint32_t")]
    public uint cell_height;
}
