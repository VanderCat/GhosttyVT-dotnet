namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyClipboardRead
{
    public GhosttyClipboardLocation location;

    [NativeTypeName("const GhosttyString *")]
    public GhosttyString* mimes;

    [NativeTypeName("size_t")]
    public nuint mimes_len;

    public bool list;

    public GhosttyString name;

    public bool granted;

    public bool can_remember;

    [NativeTypeName("const void *")]
    public void* ctx;

    [NativeTypeName("GhosttyClipboardReadReplyFn")]
    public delegate* unmanaged[Cdecl]<GhosttyClipboardRead*, GhosttyClipboardReadReply*, void> reply;
}
