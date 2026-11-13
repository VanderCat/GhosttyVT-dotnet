namespace GhosttyVT.Interop;

public partial struct GhosttyTerminalProgressReport
{
    public GhosttyTerminalProgressState state;

    [NativeTypeName("int8_t")]
    public sbyte progress;
}
