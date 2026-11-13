namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyString
{
    [NativeTypeName("const uint8_t *")]
    public byte* ptr;

    [NativeTypeName("size_t")]
    public nuint len;
}
