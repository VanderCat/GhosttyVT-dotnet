namespace GhosttyVT.Interop;

public partial struct GhosttyDeviceAttributesSecondary
{
    [NativeTypeName("uint16_t")]
    public ushort device_type;

    [NativeTypeName("uint16_t")]
    public ushort firmware_version;

    [NativeTypeName("uint16_t")]
    public ushort rom_cartridge;
}
