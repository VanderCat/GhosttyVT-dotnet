namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyWriter
{
    [NativeTypeName("GhosttyWriterFn")]
    public delegate* unmanaged[Cdecl]<void*, byte*, nuint, bool> write;

    public void* userdata;
}
