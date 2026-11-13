namespace GhosttyVT.Interop;

public partial struct GhosttySelectionGestureGeometry
{
    [NativeTypeName("uint32_t")]
    public uint columns;

    [NativeTypeName("uint32_t")]
    public uint cell_width;

    [NativeTypeName("uint32_t")]
    public uint padding_left;

    [NativeTypeName("uint32_t")]
    public uint screen_height;
}
