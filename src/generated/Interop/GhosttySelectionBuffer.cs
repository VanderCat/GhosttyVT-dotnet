namespace GhosttyVT.Interop;

public unsafe partial struct GhosttySelectionBuffer
{
    public GhosttySelection* ptr;

    [NativeTypeName("size_t")]
    public nuint cap;

    [NativeTypeName("size_t")]
    public nuint len;
}
