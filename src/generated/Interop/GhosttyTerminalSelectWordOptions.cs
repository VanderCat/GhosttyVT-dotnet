namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyTerminalSelectWordOptions
{
    [NativeTypeName("size_t")]
    public nuint size;

    public GhosttyGridRef @ref;

    [NativeTypeName("const uint32_t *")]
    public uint* boundary_codepoints;

    [NativeTypeName("size_t")]
    public nuint boundary_codepoints_len;
}
