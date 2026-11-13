namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyReader
{
    [NativeTypeName("GhosttyReaderFn")]
    public delegate* unmanaged[Cdecl]<void*, byte*, nuint, nuint*, bool> read;

    public void* userdata;
}
