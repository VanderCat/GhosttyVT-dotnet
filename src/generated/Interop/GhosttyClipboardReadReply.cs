namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyClipboardReadReply
{
    [NativeTypeName("size_t")]
    public nuint size;

    public GhosttyClipboardReadResult result;

    [NativeTypeName("const GhosttyClipboardContent *")]
    public GhosttyClipboardContent* contents;

    [NativeTypeName("size_t")]
    public nuint contents_len;

    [NativeTypeName("const GhosttyString *")]
    public GhosttyString* available;

    [NativeTypeName("size_t")]
    public nuint available_len;

    public bool remember;
}
