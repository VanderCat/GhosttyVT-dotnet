using System.Runtime.CompilerServices;

namespace GhosttyVT.Interop;

public partial struct GhosttyColorPaletteMask
{
    [NativeTypeName("uint64_t[4]")]
    public _bits_e__FixedBuffer bits;

    [InlineArray(4)]
    public partial struct _bits_e__FixedBuffer
    {
        public ulong e0;
    }
}
