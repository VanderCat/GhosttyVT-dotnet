namespace GhosttyVT.Interop;

public unsafe partial struct GhosttySysImage
{
    [NativeTypeName("uint32_t")]
    public uint width;

    [NativeTypeName("uint32_t")]
    public uint height;

    [NativeTypeName("uint8_t *")]
    public byte* data;

    [NativeTypeName("size_t")]
    public nuint data_len;
}
