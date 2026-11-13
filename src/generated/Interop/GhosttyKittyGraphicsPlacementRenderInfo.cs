namespace GhosttyVT.Interop;

public partial struct GhosttyKittyGraphicsPlacementRenderInfo
{
    [NativeTypeName("size_t")]
    public nuint size;

    [NativeTypeName("uint32_t")]
    public uint pixel_width;

    [NativeTypeName("uint32_t")]
    public uint pixel_height;

    [NativeTypeName("uint32_t")]
    public uint grid_cols;

    [NativeTypeName("uint32_t")]
    public uint grid_rows;

    [NativeTypeName("int32_t")]
    public int viewport_col;

    [NativeTypeName("int32_t")]
    public int viewport_row;

    public bool viewport_visible;

    [NativeTypeName("uint32_t")]
    public uint source_x;

    [NativeTypeName("uint32_t")]
    public uint source_y;

    [NativeTypeName("uint32_t")]
    public uint source_width;

    [NativeTypeName("uint32_t")]
    public uint source_height;
}
