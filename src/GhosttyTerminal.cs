using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using GhosttyVT.Interop;

namespace GhosttyVT;

public unsafe class GhosttyTerminal : IDisposable {
    private GhosttyTerminalImpl* _ptr;
    public GhosttyTerminalImpl* NativeHandle => _ptr;
    private GhosttyAllocator* _allocator;
    /// <summary>
    /// Create a new terminal instance.
    /// </summary>
    /// <remarks>
    /// The terminal starts with various reasonable defaults e.g. around scrollback limits.
    /// Use <see cref="Set"/> to change any options prior to using the terminal.
    /// </remarks>
    /// <param name="allocator">Object instance with allocator interface implemented</param>
    /// <para name="cols">Terminal width in cells (must be greater than zero) </para>
    /// <para name="rows">Terminal height in cells (must be greater than zero) </para>
    public GhosttyTerminal(IGhosttyAllocator? allocator, ushort cols, ushort rows) {
        GhosttyTerminalImpl* ptr;
        if (allocator is not null) {
            _allocator = IGhosttyAllocator.GetAllocatorStruct(allocator);
            Ghostty.terminal_new(_allocator, &ptr, cols, rows).ThrowIfError();;
        }
        else {
            Ghostty.terminal_new(null, &ptr, cols, rows).ThrowIfError();
        }
        _ptr = ptr;
    }
    public GhosttyTerminal(ushort cols, ushort rows) : this(new GhosttyNativeMemoryAllocator(), cols, rows) {}
    
    public void Dispose() {
        GC.SuppressFinalize(this);
        Ghostty.terminal_free(_ptr);
        _ptr = null;
        IGhosttyAllocator.FreeAllocatorStruct(_allocator);
    }

    /// <summary>
    /// Write VT-encoded data to the terminal for processing.
    /// </summary>
    /// <remarks>
    /// <p>
    /// Feeds raw bytes through the terminal's VT stream parser, updating terminal state accordingly. By default,
    /// sequences that require output (queries, device status reports) are silently ignored. Use <see cref="Set"/>
    /// with GHOSTTY_TERMINAL_OPT_WRITE_PTY to install a callback that receives response data.
    /// </p>
    /// <p>
    /// This never fails. Any erroneous input or errors in processing the input are logged internally but do not cause
    /// this function to fail because this input is assumed to be untrusted and from an external source; so the primary
    /// goal is to keep the terminal state consistent and not allow malformed input to corrupt or crash.
    /// </p>
    /// </remarks>
    /// <param name="text">the data to write</param>
    public void VtWrite(ReadOnlySpan<byte> text) {
        fixed(byte* textPtr = text)
            Ghostty.terminal_vt_write(_ptr, textPtr, (UIntPtr)text.Length);
    }

    // public void VtWrite(string text) {
    //     var size = Encoding.UTF8.GetByteCount(text);
    //     if (size < 256) {
    //         Span<byte> span = stackalloc byte[size];
    //         Encoding.UTF8.GetBytes(text, span);
    //         VtWrite(span);
    //         return;
    //     }
    //     var array = ArrayPool<byte>.Shared.Rent(size);
    //     Encoding.UTF8.GetBytes(text, array);
    //     VtWrite(array);
    //     ArrayPool<byte>.Shared.Return(array);
    // }
}