using System.Runtime.CompilerServices;
using GhosttyVT.Interop;

namespace GhosttyVT;

public unsafe class GhosttyFormatter : IDisposable {
    private GhosttyFormatterImpl* _ptr;
    public GhosttyFormatterImpl* NativeHandle => _ptr;
    private GhosttyAllocator* _allocator;

    private GhosttyFormatter(GhosttyTerminalImpl* terminal) {
        GhosttyFormatterImpl* ptr;
        Ghostty.formatter_terminal_new(null, &ptr, terminal).ThrowIfError();;
        _ptr = ptr;
    }
    private GhosttyFormatter(IGhosttyAllocator allocator, GhosttyTerminalImpl* terminal) {
        GhosttyFormatterImpl* ptr;
        _allocator = IGhosttyAllocator.GetAllocatorStruct(allocator);
        Ghostty.formatter_terminal_new(_allocator, &ptr, terminal).ThrowIfError();
        _ptr = ptr;
    }

    public GhosttyFormatter(IGhosttyAllocator allocator, GhosttyTerminal terminal) : this(allocator, terminal.NativeHandle) { }
    public GhosttyFormatter(GhosttyTerminal terminal) : this(new GhosttyNativeMemoryAllocator(), terminal) {}
    public static GhosttyFormatter FromTerminal(GhosttyTerminal terminal) => new(terminal);
    public static GhosttyFormatter FromTerminal(IGhosttyAllocator allocator, GhosttyTerminal terminal) => new(allocator, terminal);
    public void Dispose() {
        GC.SuppressFinalize(this);
        Ghostty.formatter_free(_ptr);
        _ptr = null;
        IGhosttyAllocator.FreeAllocatorStruct(_allocator);
    }

    /// <summary>
    /// Set a formatter option.
    /// </summary>
    /// <remarks>
    /// <p>
    /// value points to the option's new value. Its type is listed on each GhosttyFormatterOption.
    /// The formatter copies the value, so it only has to be valid during the call. The change applies to every format
    /// call after this one.
    /// </p>
    /// <p>
    /// If the call fails, the option keeps its previous value.
    /// </p>
    /// </remarks>
    /// <param name="option">The option to set</param>
    /// <param name="value">the new value</param>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="SetDefault"/>
    public void Set<T>(GhosttyFormatterOption option, ref T value) where T : unmanaged {
        Ghostty.formatter_set(_ptr, option, Unsafe.AsPointer(ref value)).ThrowIfError();
    }
    public void SetDefault(GhosttyFormatterOption option) {
        Ghostty.formatter_set(_ptr, option, null).ThrowIfError();
    }

    /// <summary>
    /// Run the formatter and return an allocated buffer with the output.
    /// </summary>
    /// <remarks>
    /// Each call formats the current terminal state.
    /// </remarks>
    /// <returns>the allocated buffer</returns>
    public byte[] Format() {
        var size = GetFormatSize();
        var array = new byte[size];
        fixed(byte* arrayPtr = array)
            Ghostty.formatter_format_buf(_ptr, arrayPtr, size, &size).ThrowIfError();
        return array;
    }

    /// <summary>
    /// Run the formatter and produce output into your buffer.
    /// </summary>
    /// <param name="buffer">the output buffer</param>
    /// <returns></returns>
    public nuint Format(Span<byte> buffer) {
        nuint bytesWritten = 0;
        fixed(byte* bufferPtr = buffer)
            Ghostty.formatter_format_buf(_ptr, bufferPtr, (nuint)buffer.Length, &bytesWritten).ThrowIfError();
        return bytesWritten;
    }

    public UIntPtr GetFormatSize() {
        nuint size = 0;
        var result = Ghostty.formatter_format_buf(_ptr, (byte*)&size, 0, &size);
        if (result == GhosttyResult.SUCCESS) return 0;
        if (result != GhosttyResult.OUT_OF_SPACE)
            result.ThrowIfError();
        return size;
    }
}