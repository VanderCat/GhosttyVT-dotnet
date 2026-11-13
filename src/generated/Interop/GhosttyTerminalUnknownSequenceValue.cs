using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GhosttyVT.Interop;

[StructLayout(LayoutKind.Explicit)]
public partial struct GhosttyTerminalUnknownSequenceValue
{
    [FieldOffset(0)]
    public GhosttyTerminalUnknownStringSequence apc;

    [FieldOffset(0)]
    public GhosttyTerminalUnknownOscSequence osc;

    [FieldOffset(0)]
    [NativeTypeName("uint64_t[16]")]
    public __padding_e__FixedBuffer _padding;

    [InlineArray(16)]
    public partial struct __padding_e__FixedBuffer
    {
        public ulong e0;
    }
}
