namespace GhosttyVT.Interop;

public partial struct GhosttyRenderStateCursor
{
    [NativeTypeName("size_t")]
    public nuint size;

    public bool viewport_has_value;

    [NativeTypeName("uint16_t")]
    public ushort viewport_x;

    [NativeTypeName("uint16_t")]
    public ushort viewport_y;

    public bool wide_tail;

    public bool visible;

    public bool blinking;

    public bool password_input;

    public GhosttyCursorStyle visual_style;
}
