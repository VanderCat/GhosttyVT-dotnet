namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyClipboardWrite
{
    public GhosttyClipboardLocation location;

    [NativeTypeName("const GhosttyClipboardContent *")]
    public GhosttyClipboardContent* contents;

    [NativeTypeName("size_t")]
    public nuint contents_len;

    public GhosttyString name;

    public bool granted;

    public bool can_remember;

    [NativeTypeName("const void *")]
    public void* ctx;

    [NativeTypeName("GhosttyClipboardWriteReplyFn")]
    public delegate* unmanaged[Cdecl]<GhosttyClipboardWrite*, GhosttyClipboardWriteReply*, void> reply;
}
