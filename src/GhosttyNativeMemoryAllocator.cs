using System.Runtime.InteropServices;

namespace GhosttyVT;

public unsafe class GhosttyNativeMemoryAllocator : IGhosttyAllocator {
    public IntPtr Alloc(UIntPtr len, byte alignment, IntPtr ret_addr) {
        return (IntPtr)NativeMemory.AlignedAlloc(len, (UIntPtr)1 << alignment);
    }
    
    public void Free(IntPtr memory, UIntPtr memory_len, byte alignment, IntPtr ret_addr) {
        NativeMemory.AlignedFree((void*)memory);
    }
}