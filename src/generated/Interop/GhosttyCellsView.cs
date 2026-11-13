namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyCellsView
{
    [NativeTypeName("const GhosttyCell *")]
    public ulong* ptr;

    [NativeTypeName("size_t")]
    public nuint len;
}
