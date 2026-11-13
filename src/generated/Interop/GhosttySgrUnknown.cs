namespace GhosttyVT.Interop;

public unsafe partial struct GhosttySgrUnknown
{
    [NativeTypeName("const uint16_t *")]
    public ushort* full_ptr;

    [NativeTypeName("size_t")]
    public nuint full_len;

    [NativeTypeName("const uint16_t *")]
    public ushort* partial_ptr;

    [NativeTypeName("size_t")]
    public nuint partial_len;
}
