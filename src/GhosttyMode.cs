using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GhosttyVT;

/// <summary>
/// A packed 16-bit terminal mode.
/// </summary>
/// <remarks>
/// Encodes a mode value (bits 0–14) and an ANSI flag (bit 15) into a single 16-bit integer.
/// Use the inline helper functions to construct and inspect modes rather than manipulating bits directly. 
/// </remarks>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GhosttyMode {
    private ushort _mode;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GhosttyMode(ushort value, bool ansi) {
        _mode = (ushort)((value & 0x7FFF) | ((ansi?1:0) << 15));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private GhosttyMode(ushort value) {
        _mode = value;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GhosttyMode operator |(GhosttyMode a, GhosttyMode b) => new((ushort)(a._mode | b._mode));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GhosttyMode operator &(GhosttyMode a, GhosttyMode b) => new((ushort)(a._mode & b._mode));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GhosttyMode operator ^(GhosttyMode a, GhosttyMode b) => new((ushort)(a._mode ^ b._mode));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort operator |(GhosttyMode a, ushort b) => (ushort)(a._mode | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort operator &(GhosttyMode a, ushort b) => (ushort)(a._mode & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort operator ^(GhosttyMode a, ushort b) => (ushort)(a._mode ^ b);
    

    public ushort Value => (ushort)(_mode & 0x7FFF);
    public bool Ansi => (_mode >> 15) != 0;
    public static GhosttyMode Disable_keyboard() => (new(2, true));
    public static GhosttyMode Insert() => (new(4, true));
    public static GhosttyMode SendReceiveMode() => (new(12, true));
    public static GhosttyMode Linefeed() => (new(20, true));
    public static GhosttyMode CursorKeys() => (new(1, false));
    public static GhosttyMode Column132() => (new(3, false));
    public static GhosttyMode SlowScroll() => (new(4, false));
    public static GhosttyMode ReverseColors() => (new(5, false));
    public static GhosttyMode Origin() => (new(6, false));
    public static GhosttyMode Wraparound() => (new(7, false));
    public static GhosttyMode Autorepeat() => (new(8, false));
    public static GhosttyMode MouseEventX10() => (new(9, false));
    public static GhosttyMode CursorBlinking() => (new(12, false));
    public static GhosttyMode CursorVisible() => (new(25, false));
    public static GhosttyMode EnableMode3() => (new(40, false));
    public static GhosttyMode ReverseWrap() => (new(45, false));
    public static GhosttyMode AltScreenLegacy() => (new(47, false));
    public static GhosttyMode KeypadKeys() => (new(66, false));
    public static GhosttyMode BackarrowKeyMode() => (new(67, false));
    public static GhosttyMode EnableLeftAndRightMargin() => (new(69, false));
    public static GhosttyMode MouseEventNormal() => (new(1000, false));
    public static GhosttyMode MouseEventButton() => (new(1002, false));
    public static GhosttyMode MouseEventAny() => (new(1003, false));
    public static GhosttyMode FocusEvent() => (new(1004, false));
    public static GhosttyMode MouseFormatUtf8() => (new(1005, false));
    public static GhosttyMode MouseFormatSgr() => (new(1006, false));
    public static GhosttyMode MouseAlternateScroll() => (new(1007, false));
    public static GhosttyMode MouseFormatUrxvt() => (new(1015, false));
    public static GhosttyMode MouseFormatSgrPixels() => (new(1016, false));
    public static GhosttyMode IgnoreKeypadWithNumlock() => (new(1035, false));
    public static GhosttyMode AltEscPrefix() => (new(1036, false));
    public static GhosttyMode AltSendsEscape() => (new(1039, false));
    public static GhosttyMode ReverseWrapExtended() => (new(1045, false));
    public static GhosttyMode AltScreen() => (new(1047, false));
    public static GhosttyMode SaveCursor() => (new(1048, false));
    public static GhosttyMode AltScreenSaveCursorClearEnter() => (new(1049, false));
    public static GhosttyMode BracketedPaste() => (new(2004, false));
    public static GhosttyMode SynchronizedOutput() => (new(2026, false));
    public static GhosttyMode GraphemeCluster() => (new(2027, false));
    public static GhosttyMode ReportColorScheme() => (new(2031, false));
    public static GhosttyMode ReportVisibility() => (new(2033, false));
    public static GhosttyMode InBandSizeReports() => (new(2048, false));
    public static GhosttyMode KittyPasteEvents() => (new(5522, false));
}