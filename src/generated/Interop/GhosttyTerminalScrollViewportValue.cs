using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GhosttyVT.Interop;

[StructLayout(LayoutKind.Explicit)]
public partial struct GhosttyTerminalScrollViewportValue
{
    [FieldOffset(0)]
    [NativeTypeName("intptr_t")]
    public nint delta;

    [FieldOffset(0)]
    [NativeTypeName("size_t")]
    public nuint row;

    [FieldOffset(0)]
    [NativeTypeName("intptr_t")]
    public nint delta_prompt;

    [FieldOffset(0)]
    [NativeTypeName("uint64_t[2]")]
    public __padding_e__FixedBuffer _padding;

    [InlineArray(2)]
    public partial struct __padding_e__FixedBuffer
    {
        public ulong e0;
    }
}
