namespace GhosttyVT.Interop;

public partial struct GhosttyTerminalProgramStatus
{
    public GhosttyProgramStatusState state;

    public GhosttyProgramStatusKind kind;

    [NativeTypeName("int8_t")]
    public sbyte progress;

    public GhosttyString id;

    public GhosttyString app;

    public GhosttyString title;

    public GhosttyString message;
}
