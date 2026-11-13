using System.Runtime.CompilerServices;

namespace GhosttyVT.Interop;

public partial struct GhosttyDeviceAttributesPrimary
{
    [NativeTypeName("uint16_t")]
    public ushort conformance_level;

    [NativeTypeName("uint16_t[64]")]
    public _features_e__FixedBuffer features;

    [NativeTypeName("size_t")]
    public nuint num_features;

    [InlineArray(64)]
    public partial struct _features_e__FixedBuffer
    {
        public ushort e0;
    }
}
