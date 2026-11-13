using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GhosttyVT.Interop;

namespace GhosttyVT;

public unsafe interface IGhosttyAllocator {
    /// <summary>
    /// Allocate a block of memory.
    /// </summary>
    /// <param name="len">Number of bytes to allocate</param>
    /// <param name="alignment">The block's address must be a multiple of 1 bitshifted to alignment bytes</param>
    /// <param name="ret_addr">Address of the requesting code, or 0. Safe to ignore.</param>
    /// <returns>The new block, or NULL if it could not be allocated </returns>
    /// <remarks>
    /// This is the alloc function of a GhosttyAllocatorVtable. It's required.
    /// </remarks>
    nint Alloc(nuint len, byte alignment, nint ret_addr);

    /// <summary>
    /// Free a block.
    /// </summary>
    /// <param name="memory">Start of a block returned by alloc or remap</param>
    /// <param name="memory_len">Current length of the block</param>
    /// <param name="alignment">The alignment the block was allocated with</param>
    /// <param name="ret_addr">	Address of the requesting code, or 0. Safe to ignore.</param>
    /// <remarks>
    /// This is the free function of a GhosttyAllocatorVtable. It's required.
    /// After it returns, the library never uses memory again.
    /// </remarks>
    void Free(nint memory, nuint memory_len, byte alignment, nint ret_addr);
    
    /// <summary>
    /// Grow or shrink a block, moving it if that is cheaper than a copy.
    /// </summary>
    /// <param name="memory"></param>
    /// <param name="memory_len"></param>
    /// <param name="alignment"></param>
    /// <param name="new_len"></param>
    /// <param name="ret_addr"></param>
    /// <returns></returns>
    /// <remarks>
    /// <p>
    /// It's optional, and leaving it unimplemented is the same as always returning NULL.
    /// </p>
    /// <p>
    /// Unlike <see cref="Resize"/>, this may return a new address, for example after remapping virtual memory pages.
    /// The block must hold the old contents at that address, and the old address is no longer valid.
    /// </p>
    /// <p>
    /// Return NULL when the only way to do it would be to allocate, copy, and free. The library does that itself, so
    /// there is no benefit in doing it here.
    /// </p>
    /// </remarks>
    virtual nint Remap(nint memory, nuint memory_len, byte alignment, nuint new_len, nint ret_addr) => 0;
    
    /// <summary>
    /// Try to grow or shrink a block without moving it.
    /// </summary>
    /// <param name="memory">Start of a block returned by alloc or remap</param>
    /// <param name="memory_len">Current length of the block</param>
    /// <param name="alignment">The alignment the block was allocated with</param>
    /// <param name="new_len">Requested length, always greater than zero</param>
    /// <param name="ret_addr">Address of the requesting code, or 0. Safe to ignore.</param>
    /// <returns></returns>
    /// <p>
    /// This is the resize function of a GhosttyAllocatorVtable. It's optional.
    /// </p>
    /// <p>
    /// Return true only if the block at memory is now new_len bytes long at the same address. Return false if that
    /// would require moving it. The library then decides whether to allocate a new block and copy.
    /// </p>
    virtual bool Resize(nint memory, nuint memory_len, byte alignment, nuint new_len, nint ret_addr) => false;

    private static GhosttyAllocatorVtable* _vtable;

    internal static GhosttyAllocator* GetAllocatorStruct(IGhosttyAllocator allocator) {
        var handle = GCHandle.Alloc(allocator, GCHandleType.Normal);
        // should be allocator from the interface itself be used there? it's certainly possible
        var alloc = (GhosttyAllocator*)NativeMemory.Alloc((nuint)Unsafe.SizeOf<GhosttyAllocator>());
        alloc->ctx = (void*)GCHandle.ToIntPtr(handle);
        alloc->vtable = _vtable;
        return alloc;
    }
    internal static void FreeAllocatorStruct(GhosttyAllocator* alloc) {
        if (alloc is not null) {
            var handle = GCHandle.FromIntPtr((IntPtr)alloc->ctx);
            NativeMemory.Free(alloc);
            handle.Free();
            alloc = null;
        }
    } 

    static IGhosttyAllocator() {
        _vtable = (GhosttyAllocatorVtable*)NativeMemory.Alloc((nuint)Unsafe.SizeOf<GhosttyAllocatorVtable>());
        _vtable->alloc = &AllocNative;
        _vtable->free = &FreeNative;
        _vtable->remap = &RemapNative;
        _vtable->resize = &ResizeNative;
        _vtable->reserved[0] = null;
        _vtable->reserved[1] = null;
        _vtable->reserved[2] = null;
        _vtable->reserved[3] = null;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void* AllocNative(void* ctx, nuint len, byte alignment, nuint ret_addr) {
        try {
            var handle = GCHandle.FromIntPtr((IntPtr)ctx);
            if (handle.Target is IGhosttyAllocator allocator) {
                return (void*)allocator.Alloc(len, alignment, unchecked((nint)ret_addr));
            }
        }
        catch (Exception e) {
            // TODO: log maybe?
        }

        return null;
    }
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void FreeNative(void* ctx, void* memory, nuint len, byte alignment, nuint ret_addr) {
        try {
            var handle = GCHandle.FromIntPtr((IntPtr)ctx);
            if (handle.Target is IGhosttyAllocator allocator) {
                allocator.Free((nint)memory, len, alignment, unchecked((nint)ret_addr));
            }
        }
        catch (Exception e) {
            // TODO: log maybe?
        }
    }
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void* RemapNative(void* ctx, void* memory, nuint memory_len, byte alignment, nuint new_len, nuint ret_addr) {
        try {
            var handle = GCHandle.FromIntPtr((IntPtr)ctx);
            if (handle.Target is IGhosttyAllocator allocator) {
                return (void*)allocator.Remap((nint)memory, memory_len, alignment, new_len, unchecked((nint)ret_addr));
            }
        }
        catch (Exception e) {
            // TODO: log maybe?
        }

        return null;
    }
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static bool ResizeNative(void* ctx, void* memory, nuint memory_len, byte alignment, nuint new_len, nuint ret_addr) {
        try {
            var handle = GCHandle.FromIntPtr((IntPtr)ctx);
            if (handle.Target is IGhosttyAllocator allocator) {
                return allocator.Resize((nint)memory, memory_len, alignment, new_len, unchecked((nint)ret_addr));
            }
        }
        catch (Exception e) {
            // TODO: log maybe?
        }

        return false;
    }
}