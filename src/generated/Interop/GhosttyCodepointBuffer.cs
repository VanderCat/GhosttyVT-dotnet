namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyCodepointBuffer
{
    [NativeTypeName("uint32_t *")]
    public uint* ptr;

    [NativeTypeName("size_t")]
    public nuint cap;

    [NativeTypeName("size_t")]
    public nuint len;
}
