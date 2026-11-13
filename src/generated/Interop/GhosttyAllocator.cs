namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyAllocator
{
    public void* ctx;

    [NativeTypeName("const GhosttyAllocatorVtable *")]
    public GhosttyAllocatorVtable* vtable;
}
