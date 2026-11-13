using System.Runtime.InteropServices;

namespace GhosttyVT.Interop;

[StructLayout(LayoutKind.Explicit)]
public partial struct GhosttyStyleColorValue
{
    [FieldOffset(0)]
    [NativeTypeName("GhosttyColorPaletteIndex")]
    public byte palette;

    [FieldOffset(0)]
    public GhosttyColorRgb rgb;
}
