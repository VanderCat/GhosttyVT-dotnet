namespace GhosttyVT.Interop;

public enum GhosttyResult
{
    SUCCESS = 0,
    OUT_OF_MEMORY = -1,
    INVALID_VALUE = -2,
    OUT_OF_SPACE = -3,
    NO_VALUE = -4,
    IO_ERROR = -5,
    LIMIT_EXCEEDED = -6,
    REJECTED = -7,
    UNSUPPORTED = -8,
    RESULT_MAX_VALUE = 2147483647,
}
