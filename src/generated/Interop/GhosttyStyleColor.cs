namespace GhosttyVT.Interop;

public partial struct GhosttyStyleColor
{
    [NativeTypeName("uint8_t")]
    public byte tag;

    public GhosttyStyleColorValue value;
}
