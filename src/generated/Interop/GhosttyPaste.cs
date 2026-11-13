namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyPaste
{
    [NativeTypeName("size_t")]
    public nuint size;

    public GhosttyClipboardLocation location;

    public GhosttyPasteSource source;

    [NativeTypeName("const GhosttyString *")]
    public GhosttyString* mimes;

    [NativeTypeName("size_t")]
    public nuint mimes_len;

    public GhosttyMimeReader reader;

    public bool allow_unsafe;
}
