namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyTerminalSelectLineOptions
{
    [NativeTypeName("size_t")]
    public nuint size;

    public GhosttyGridRef @ref;

    [NativeTypeName("const uint32_t *")]
    public uint* whitespace;

    [NativeTypeName("size_t")]
    public nuint whitespace_len;

    public bool semantic_prompt_boundary;
}
