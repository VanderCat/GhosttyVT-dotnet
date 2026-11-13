using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GhosttyVT.Interop;

[StructLayout(LayoutKind.Explicit)]
public partial struct GhosttyPointValue
{
    [FieldOffset(0)]
    public GhosttyPointCoordinate coordinate;

    [FieldOffset(0)]
    [NativeTypeName("uint64_t[2]")]
    public __padding_e__FixedBuffer _padding;

    [InlineArray(2)]
    public partial struct __padding_e__FixedBuffer
    {
        public ulong e0;
    }
}
