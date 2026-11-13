namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyMimeReader
{
    [NativeTypeName("GhosttyMimeReaderFn")]
    public delegate* unmanaged[Cdecl]<void*, GhosttyString, GhosttyWriter, bool> read;

    public void* userdata;
}
