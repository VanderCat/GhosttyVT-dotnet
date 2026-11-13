namespace GhosttyVT.Interop;

public enum GhosttyTerminalBoundary
{
    GROUND = 1 << 0,
    APC_START = 1 << 1,
    APC_END = 1 << 2,
    DCS_START = 1 << 3,
    DCS_END = 1 << 4,
    OSC_START = 1 << 5,
    OSC_END = 1 << 6,
    MAX_VALUE = 2147483647,
}
