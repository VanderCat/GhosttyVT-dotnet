namespace GhosttyVT.Interop;

public partial struct GhosttyTerminalWriteStop
{
    [NativeTypeName("size_t")]
    public nuint size;

    [NativeTypeName("size_t")]
    public nuint consumed;

    [NativeTypeName("uint32_t")]
    public uint reached;

    public GhosttyTerminalStringKind kind;

    public GhosttyTerminalStringIntroducer introducer;

    public GhosttyTerminalStringEnd end;

    [NativeTypeName("uint8_t")]
    public byte @byte;
}
