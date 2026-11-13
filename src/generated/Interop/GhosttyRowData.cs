namespace GhosttyVT.Interop;

public enum GhosttyRowData
{
    INVALID = 0,
    WRAP = 1,
    WRAP_CONTINUATION = 2,
    GRAPHEME = 3,
    STYLED = 4,
    HYPERLINK = 5,
    SEMANTIC_PROMPT = 6,
    KITTY_VIRTUAL_PLACEHOLDER = 7,
    DIRTY = 8,
    MAX_VALUE = 2147483647,
}
