namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyCodepoints
{
    [NativeTypeName("const uint32_t *")]
    public uint* ptr;

    [NativeTypeName("size_t")]
    public nuint len;
}
