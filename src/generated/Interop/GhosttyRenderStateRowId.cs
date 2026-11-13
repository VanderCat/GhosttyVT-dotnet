using System.Runtime.CompilerServices;

namespace GhosttyVT.Interop;

public partial struct GhosttyRenderStateRowId
{
    [NativeTypeName("uint64_t[2]")]
    public _bits_e__FixedBuffer bits;

    [InlineArray(2)]
    public partial struct _bits_e__FixedBuffer
    {
        public ulong e0;
    }
}
