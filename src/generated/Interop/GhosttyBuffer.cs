namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyBuffer
{
    [NativeTypeName("uint8_t *")]
    public byte* ptr;

    [NativeTypeName("size_t")]
    public nuint cap;

    [NativeTypeName("size_t")]
    public nuint len;
}
