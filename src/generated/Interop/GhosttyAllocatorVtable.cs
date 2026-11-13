using System.Runtime.CompilerServices;

namespace GhosttyVT.Interop;

public unsafe partial struct GhosttyAllocatorVtable
{
    [NativeTypeName("GhosttyAllocatorAllocFn")]
    public delegate* unmanaged[Cdecl]<void*, nuint, byte, nuint, void*> alloc;

    [NativeTypeName("GhosttyAllocatorResizeFn")]
    public delegate* unmanaged[Cdecl]<void*, void*, nuint, byte, nuint, nuint, bool> resize;

    [NativeTypeName("GhosttyAllocatorRemapFn")]
    public delegate* unmanaged[Cdecl]<void*, void*, nuint, byte, nuint, nuint, void*> remap;

    [NativeTypeName("GhosttyAllocatorFreeFn")]
    public delegate* unmanaged[Cdecl]<void*, void*, nuint, byte, nuint, void> free;

    [NativeTypeName("void *[4]")]
    public _reserved_e__FixedBuffer reserved;

    public unsafe partial struct _reserved_e__FixedBuffer
    {
        public void* e0;
        public void* e1;
        public void* e2;
        public void* e3;

        public ref void* this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (void** pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}
