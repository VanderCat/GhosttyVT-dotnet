namespace GhosttyVT.Interop;

public partial struct GhosttyTerminalMemoryUsage
{
    [NativeTypeName("size_t")]
    public nuint size;

    public bool compression_supported;

    [NativeTypeName("uint64_t")]
    public ulong primary_pages;

    [NativeTypeName("uint64_t")]
    public ulong primary_virtual_bytes;

    [NativeTypeName("uint64_t")]
    public ulong primary_resident_bytes;

    [NativeTypeName("uint64_t")]
    public ulong primary_compressed_pages;

    [NativeTypeName("uint64_t")]
    public ulong primary_compressed_bytes;

    [NativeTypeName("uint64_t")]
    public ulong primary_image_bytes;

    [NativeTypeName("uint64_t")]
    public ulong alternate_pages;

    [NativeTypeName("uint64_t")]
    public ulong alternate_virtual_bytes;

    [NativeTypeName("uint64_t")]
    public ulong alternate_resident_bytes;

    [NativeTypeName("uint64_t")]
    public ulong alternate_compressed_pages;

    [NativeTypeName("uint64_t")]
    public ulong alternate_compressed_bytes;

    [NativeTypeName("uint64_t")]
    public ulong alternate_image_bytes;
}
