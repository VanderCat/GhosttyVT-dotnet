using System.Runtime.CompilerServices;

namespace GhosttyVT.Interop;

public partial struct GhosttyRenderStateColors
{
    [NativeTypeName("size_t")]
    public nuint size;

    public GhosttyColorRgb background;

    public GhosttyColorRgb foreground;

    public GhosttyColorRgb cursor;

    public bool cursor_has_value;

    [NativeTypeName("GhosttyColorRgb[256]")]
    public _palette_e__FixedBuffer palette;

    [InlineArray(256)]
    public partial struct _palette_e__FixedBuffer
    {
        public GhosttyColorRgb e0;
    }
}
