namespace GhosttyVT.Interop;

public partial struct GhosttyClipboardWriteReply
{
    [NativeTypeName("size_t")]
    public nuint size;

    public GhosttyClipboardWriteResult result;

    public bool remember;
}
