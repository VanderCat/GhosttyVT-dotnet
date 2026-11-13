namespace GhosttyVT.Interop;

public partial struct GhosttyTerminalScrollbar
{
    [NativeTypeName("uint64_t")]
    public ulong total;

    [NativeTypeName("uint64_t")]
    public ulong offset;

    [NativeTypeName("uint64_t")]
    public ulong len;
}
