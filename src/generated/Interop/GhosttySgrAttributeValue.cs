using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GhosttyVT.Interop;

[StructLayout(LayoutKind.Explicit)]
public partial struct GhosttySgrAttributeValue
{
    [FieldOffset(0)]
    public GhosttySgrUnknown unknown;

    [FieldOffset(0)]
    public GhosttySgrUnderline underline;

    [FieldOffset(0)]
    public GhosttyColorRgb underline_color;

    [FieldOffset(0)]
    [NativeTypeName("GhosttyColorPaletteIndex")]
    public byte underline_color_256;

    [FieldOffset(0)]
    public GhosttyColorRgb direct_color_fg;

    [FieldOffset(0)]
    public GhosttyColorRgb direct_color_bg;

    [FieldOffset(0)]
    [NativeTypeName("GhosttyColorPaletteIndex")]
    public byte bg_8;

    [FieldOffset(0)]
    [NativeTypeName("GhosttyColorPaletteIndex")]
    public byte fg_8;

    [FieldOffset(0)]
    [NativeTypeName("GhosttyColorPaletteIndex")]
    public byte bright_bg_8;

    [FieldOffset(0)]
    [NativeTypeName("GhosttyColorPaletteIndex")]
    public byte bright_fg_8;

    [FieldOffset(0)]
    [NativeTypeName("GhosttyColorPaletteIndex")]
    public byte bg_256;

    [FieldOffset(0)]
    [NativeTypeName("GhosttyColorPaletteIndex")]
    public byte fg_256;

    [FieldOffset(0)]
    [NativeTypeName("uint64_t[8]")]
    public __padding_e__FixedBuffer _padding;

    [InlineArray(8)]
    public partial struct __padding_e__FixedBuffer
    {
        public ulong e0;
    }
}
