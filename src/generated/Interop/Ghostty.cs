using System;
using System.Runtime.InteropServices;

namespace GhosttyVT.Interop;

public static unsafe partial class Ghostty
{
    [NativeTypeName("#define GHOSTTY_VT_VERSION_MAJOR 1")]
    public const int GHOSTTY_VT_VERSION_MAJOR = 1;

    [NativeTypeName("#define GHOSTTY_VT_VERSION_MINOR 0")]
    public const int GHOSTTY_VT_VERSION_MINOR = 0;

    [NativeTypeName("#define GHOSTTY_VT_VERSION_PATCH 1")]
    public const int GHOSTTY_VT_VERSION_PATCH = 1;

    [NativeTypeName("#define GHOSTTY_VT_VERSION \"1.0.1\"")]
    public static ReadOnlySpan<byte> GHOSTTY_VT_VERSION => "1.0.1"u8;

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z18ghostty_sized_initPvm", ExactSpelling = true)]
    public static extern void sized_init(void* ptr, [NativeTypeName("size_t")] nuint size);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z17ghostty_type_jsonv", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* type_json();

    [NativeTypeName("#define GHOSTTY_ENUM_MAX_VALUE INT_MAX")]
    public const int GHOSTTY_ENUM_MAX_VALUE = 2147483647;

    [NativeTypeName("#define GHOSTTY_IMAGE_LAYER_MASK_BELOW_BACKGROUND (1u << GHOSTTY_IMAGE_LAYER_BELOW_BACKGROUND)")]
    public const uint GHOSTTY_IMAGE_LAYER_MASK_BELOW_BACKGROUND = (1U << (int)((int)(GhosttyImageLayer.BELOW_BACKGROUND)));

    [NativeTypeName("#define GHOSTTY_IMAGE_LAYER_MASK_BELOW_TEXT (1u << GHOSTTY_IMAGE_LAYER_BELOW_TEXT)")]
    public const uint GHOSTTY_IMAGE_LAYER_MASK_BELOW_TEXT = (1U << (int)((int)(GhosttyImageLayer.BELOW_TEXT)));

    [NativeTypeName("#define GHOSTTY_IMAGE_LAYER_MASK_ABOVE_TEXT (1u << GHOSTTY_IMAGE_LAYER_ABOVE_TEXT)")]
    public const uint GHOSTTY_IMAGE_LAYER_MASK_ABOVE_TEXT = (1U << (int)((int)(GhosttyImageLayer.ABOVE_TEXT)));

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z13ghostty_allocPK16GhosttyAllocatorm", ExactSpelling = true)]
    [return: NativeTypeName("uint8_t *")]
    public static extern byte* alloc([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("size_t")] nuint len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z12ghostty_freePK16GhosttyAllocatorPhm", ExactSpelling = true)]
    public static extern void free([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("uint8_t *")] byte* ptr, [NativeTypeName("size_t")] nuint len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_build_info", ExactSpelling = true)]
    public static extern GhosttyResult build_info(GhosttyBuildInfo data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_version", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* version();

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_rgb_get", ExactSpelling = true)]
    public static extern void color_rgb_get([NativeTypeName("const GhosttyColorRgb *")] GhosttyColorRgb* color, [NativeTypeName("uint8_t *")] byte* r, [NativeTypeName("uint8_t *")] byte* g, [NativeTypeName("uint8_t *")] byte* b);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_parse_x11", ExactSpelling = true)]
    public static extern GhosttyResult color_parse_x11([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("size_t")] nuint len, GhosttyColorRgb* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_parse", ExactSpelling = true)]
    public static extern GhosttyResult color_parse([NativeTypeName("const char *")] sbyte* value, [NativeTypeName("size_t")] nuint len, GhosttyColorRgb* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_parse_palette_entry", ExactSpelling = true)]
    public static extern GhosttyResult color_parse_palette_entry([NativeTypeName("const char *")] sbyte* value, [NativeTypeName("size_t")] nuint len, [NativeTypeName("uint8_t *")] byte* out_index, GhosttyColorRgb* out_rgb);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_palette_default", ExactSpelling = true)]
    public static extern void color_palette_default(GhosttyColorRgb* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_palette_generate", ExactSpelling = true)]
    public static extern void color_palette_generate([NativeTypeName("const GhosttyColorRgb *")] GhosttyColorRgb* @base, [NativeTypeName("const GhosttyColorPaletteMask *")] GhosttyColorPaletteMask* skip, [NativeTypeName("const GhosttyColorRgb *")] GhosttyColorRgb* bg, [NativeTypeName("const GhosttyColorRgb *")] GhosttyColorRgb* fg, bool harmonious, GhosttyColorRgb* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_luminance", ExactSpelling = true)]
    public static extern double color_luminance([NativeTypeName("const GhosttyColorRgb *")] GhosttyColorRgb* color);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_perceived_luminance", ExactSpelling = true)]
    public static extern double color_perceived_luminance([NativeTypeName("const GhosttyColorRgb *")] GhosttyColorRgb* color);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_contrast", ExactSpelling = true)]
    public static extern double color_contrast([NativeTypeName("const GhosttyColorRgb *")] GhosttyColorRgb* a, [NativeTypeName("const GhosttyColorRgb *")] GhosttyColorRgb* b);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_x11_names", ExactSpelling = true)]
    [return: NativeTypeName("const GhosttyColorX11Entry *")]
    public static extern GhosttyColorX11Entry* color_x11_names();

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_x11_name_count", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint color_x11_name_count();

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BLACK 0")]
    public const int GHOSTTY_COLOR_NAMED_BLACK = 0;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_RED 1")]
    public const int GHOSTTY_COLOR_NAMED_RED = 1;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_GREEN 2")]
    public const int GHOSTTY_COLOR_NAMED_GREEN = 2;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_YELLOW 3")]
    public const int GHOSTTY_COLOR_NAMED_YELLOW = 3;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BLUE 4")]
    public const int GHOSTTY_COLOR_NAMED_BLUE = 4;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_MAGENTA 5")]
    public const int GHOSTTY_COLOR_NAMED_MAGENTA = 5;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_CYAN 6")]
    public const int GHOSTTY_COLOR_NAMED_CYAN = 6;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_WHITE 7")]
    public const int GHOSTTY_COLOR_NAMED_WHITE = 7;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BRIGHT_BLACK 8")]
    public const int GHOSTTY_COLOR_NAMED_BRIGHT_BLACK = 8;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BRIGHT_RED 9")]
    public const int GHOSTTY_COLOR_NAMED_BRIGHT_RED = 9;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BRIGHT_GREEN 10")]
    public const int GHOSTTY_COLOR_NAMED_BRIGHT_GREEN = 10;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BRIGHT_YELLOW 11")]
    public const int GHOSTTY_COLOR_NAMED_BRIGHT_YELLOW = 11;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BRIGHT_BLUE 12")]
    public const int GHOSTTY_COLOR_NAMED_BRIGHT_BLUE = 12;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BRIGHT_MAGENTA 13")]
    public const int GHOSTTY_COLOR_NAMED_BRIGHT_MAGENTA = 13;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BRIGHT_CYAN 14")]
    public const int GHOSTTY_COLOR_NAMED_BRIGHT_CYAN = 14;

    [NativeTypeName("#define GHOSTTY_COLOR_NAMED_BRIGHT_WHITE 15")]
    public const int GHOSTTY_COLOR_NAMED_BRIGHT_WHITE = 15;

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_color_scheme_report_encode", ExactSpelling = true)]
    public static extern GhosttyResult color_scheme_report_encode(GhosttyColorScheme scheme, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT100 1")]
    public const int GHOSTTY_DA_CONFORMANCE_VT100 = 1;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT101 1")]
    public const int GHOSTTY_DA_CONFORMANCE_VT101 = 1;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT102 6")]
    public const int GHOSTTY_DA_CONFORMANCE_VT102 = 6;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT125 12")]
    public const int GHOSTTY_DA_CONFORMANCE_VT125 = 12;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT131 7")]
    public const int GHOSTTY_DA_CONFORMANCE_VT131 = 7;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT132 4")]
    public const int GHOSTTY_DA_CONFORMANCE_VT132 = 4;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT220 62")]
    public const int GHOSTTY_DA_CONFORMANCE_VT220 = 62;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT240 62")]
    public const int GHOSTTY_DA_CONFORMANCE_VT240 = 62;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT320 63")]
    public const int GHOSTTY_DA_CONFORMANCE_VT320 = 63;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT340 63")]
    public const int GHOSTTY_DA_CONFORMANCE_VT340 = 63;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT420 64")]
    public const int GHOSTTY_DA_CONFORMANCE_VT420 = 64;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT510 65")]
    public const int GHOSTTY_DA_CONFORMANCE_VT510 = 65;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT520 65")]
    public const int GHOSTTY_DA_CONFORMANCE_VT520 = 65;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_VT525 65")]
    public const int GHOSTTY_DA_CONFORMANCE_VT525 = 65;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_LEVEL_2 62")]
    public const int GHOSTTY_DA_CONFORMANCE_LEVEL_2 = 62;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_LEVEL_3 63")]
    public const int GHOSTTY_DA_CONFORMANCE_LEVEL_3 = 63;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_LEVEL_4 64")]
    public const int GHOSTTY_DA_CONFORMANCE_LEVEL_4 = 64;

    [NativeTypeName("#define GHOSTTY_DA_CONFORMANCE_LEVEL_5 65")]
    public const int GHOSTTY_DA_CONFORMANCE_LEVEL_5 = 65;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_COLUMNS_132 1")]
    public const int GHOSTTY_DA_FEATURE_COLUMNS_132 = 1;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_PRINTER 2")]
    public const int GHOSTTY_DA_FEATURE_PRINTER = 2;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_REGIS 3")]
    public const int GHOSTTY_DA_FEATURE_REGIS = 3;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_SIXEL 4")]
    public const int GHOSTTY_DA_FEATURE_SIXEL = 4;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_SELECTIVE_ERASE 6")]
    public const int GHOSTTY_DA_FEATURE_SELECTIVE_ERASE = 6;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_USER_DEFINED_KEYS 8")]
    public const int GHOSTTY_DA_FEATURE_USER_DEFINED_KEYS = 8;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_NATIONAL_REPLACEMENT 9")]
    public const int GHOSTTY_DA_FEATURE_NATIONAL_REPLACEMENT = 9;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_TECHNICAL_CHARACTERS 15")]
    public const int GHOSTTY_DA_FEATURE_TECHNICAL_CHARACTERS = 15;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_LOCATOR 16")]
    public const int GHOSTTY_DA_FEATURE_LOCATOR = 16;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_TERMINAL_STATE 17")]
    public const int GHOSTTY_DA_FEATURE_TERMINAL_STATE = 17;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_WINDOWING 18")]
    public const int GHOSTTY_DA_FEATURE_WINDOWING = 18;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_HORIZONTAL_SCROLLING 21")]
    public const int GHOSTTY_DA_FEATURE_HORIZONTAL_SCROLLING = 21;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_ANSI_COLOR 22")]
    public const int GHOSTTY_DA_FEATURE_ANSI_COLOR = 22;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_RECTANGULAR_EDITING 28")]
    public const int GHOSTTY_DA_FEATURE_RECTANGULAR_EDITING = 28;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_ANSI_TEXT_LOCATOR 29")]
    public const int GHOSTTY_DA_FEATURE_ANSI_TEXT_LOCATOR = 29;

    [NativeTypeName("#define GHOSTTY_DA_FEATURE_CLIPBOARD 52")]
    public const int GHOSTTY_DA_FEATURE_CLIPBOARD = 52;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT100 0")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT100 = 0;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT220 1")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT220 = 1;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT240 2")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT240 = 2;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT330 18")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT330 = 18;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT340 19")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT340 = 19;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT320 24")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT320 = 24;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT382 32")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT382 = 32;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT420 41")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT420 = 41;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT510 61")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT510 = 61;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT520 64")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT520 = 64;

    [NativeTypeName("#define GHOSTTY_DA_DEVICE_TYPE_VT525 65")]
    public const int GHOSTTY_DA_DEVICE_TYPE_VT525 = 65;

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_focus_encode", ExactSpelling = true)]
    public static extern GhosttyResult focus_encode(GhosttyFocusEvent @event, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_formatter_terminal_new", ExactSpelling = true)]
    public static extern GhosttyResult formatter_terminal_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttyFormatter *")] GhosttyFormatterImpl** formatter, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_formatter_set", ExactSpelling = true)]
    public static extern GhosttyResult formatter_set([NativeTypeName("GhosttyFormatter")] GhosttyFormatterImpl* formatter, GhosttyFormatterOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_formatter_get", ExactSpelling = true)]
    public static extern GhosttyResult formatter_get([NativeTypeName("GhosttyFormatter")] GhosttyFormatterImpl* formatter, GhosttyFormatterOption option, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_formatter_format", ExactSpelling = true)]
    public static extern GhosttyResult formatter_format([NativeTypeName("GhosttyFormatter")] GhosttyFormatterImpl* formatter, GhosttyWriter writer);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_formatter_format_buf", ExactSpelling = true)]
    public static extern GhosttyResult formatter_format_buf([NativeTypeName("GhosttyFormatter")] GhosttyFormatterImpl* formatter, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_formatter_format_alloc", ExactSpelling = true)]
    public static extern GhosttyResult formatter_format_alloc([NativeTypeName("GhosttyFormatter")] GhosttyFormatterImpl* formatter, [NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("uint8_t **")] byte** out_ptr, [NativeTypeName("size_t *")] nuint* out_len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_formatter_free", ExactSpelling = true)]
    public static extern void formatter_free([NativeTypeName("GhosttyFormatter")] GhosttyFormatterImpl* formatter);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_PALETTE (1u << 0)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_PALETTE = (1U << 0);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_MODES (1u << 1)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_MODES = (1U << 1);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_SCROLLING_REGION (1u << 2)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_SCROLLING_REGION = (1U << 2);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_TABSTOPS (1u << 3)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_TABSTOPS = (1U << 3);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_PWD (1u << 4)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_PWD = (1U << 4);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_KEYBOARD (1u << 5)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_KEYBOARD = (1U << 5);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_CURSOR (1u << 6)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_CURSOR = (1U << 6);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_STYLE (1u << 7)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_STYLE = (1U << 7);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_HYPERLINK (1u << 8)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_HYPERLINK = (1U << 8);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_PROTECTION (1u << 9)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_PROTECTION = (1U << 9);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_KITTY_KEYBOARD (1u << 10)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_KITTY_KEYBOARD = (1U << 10);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRA_CHARSETS (1u << 11)")]
    public const uint GHOSTTY_FORMATTER_EXTRA_CHARSETS = (1U << 11);

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRAS_NONE 0u")]
    public const uint GHOSTTY_FORMATTER_EXTRAS_NONE = 0U;

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRAS_ALL 0xFFFu")]
    public const uint GHOSTTY_FORMATTER_EXTRAS_ALL = 0xFFFU;

    [NativeTypeName("#define GHOSTTY_FORMATTER_EXTRAS_DEFAULT (GHOSTTY_FORMATTER_EXTRA_PALETTE | GHOSTTY_FORMATTER_EXTRA_STYLE |         \\\n   GHOSTTY_FORMATTER_EXTRA_HYPERLINK)")]
    public const uint GHOSTTY_FORMATTER_EXTRAS_DEFAULT = ((1U << 0) | (1U << 7) | (1U << 8));

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_new", ExactSpelling = true)]
    public static extern GhosttyResult render_state_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttyRenderState *")] GhosttyRenderStateImpl** state);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_free", ExactSpelling = true)]
    public static extern void render_state_free([NativeTypeName("GhosttyRenderState")] GhosttyRenderStateImpl* state);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_update", ExactSpelling = true)]
    public static extern GhosttyResult render_state_update([NativeTypeName("GhosttyRenderState")] GhosttyRenderStateImpl* state, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_begin_update", ExactSpelling = true)]
    public static extern GhosttyResult render_state_begin_update([NativeTypeName("GhosttyRenderState")] GhosttyRenderStateImpl* state, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_end_update", ExactSpelling = true)]
    public static extern GhosttyResult render_state_end_update([NativeTypeName("GhosttyRenderState")] GhosttyRenderStateImpl* state);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_clean", ExactSpelling = true)]
    public static extern GhosttyResult render_state_clean([NativeTypeName("GhosttyRenderState")] GhosttyRenderStateImpl* state);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_get", ExactSpelling = true)]
    public static extern GhosttyResult render_state_get([NativeTypeName("GhosttyRenderState")] GhosttyRenderStateImpl* state, GhosttyRenderStateData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult render_state_get_multi([NativeTypeName("GhosttyRenderState")] GhosttyRenderStateImpl* state, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyRenderStateData *")] GhosttyRenderStateData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_set", ExactSpelling = true)]
    public static extern GhosttyResult render_state_set([NativeTypeName("GhosttyRenderState")] GhosttyRenderStateImpl* state, GhosttyRenderStateOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_iterator_new", ExactSpelling = true)]
    public static extern GhosttyResult render_state_row_iterator_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttyRenderStateRowIterator *")] GhosttyRenderStateRowIteratorImpl** out_iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_iterator_free", ExactSpelling = true)]
    public static extern void render_state_row_iterator_free([NativeTypeName("GhosttyRenderStateRowIterator")] GhosttyRenderStateRowIteratorImpl* iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_iterator_next", ExactSpelling = true)]
    public static extern bool render_state_row_iterator_next([NativeTypeName("GhosttyRenderStateRowIterator")] GhosttyRenderStateRowIteratorImpl* iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_iterator_next_dirty", ExactSpelling = true)]
    public static extern bool render_state_row_iterator_next_dirty([NativeTypeName("GhosttyRenderStateRowIterator")] GhosttyRenderStateRowIteratorImpl* iterator, [NativeTypeName("uint16_t *")] ushort* out_y);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_get", ExactSpelling = true)]
    public static extern GhosttyResult render_state_row_get([NativeTypeName("GhosttyRenderStateRowIterator")] GhosttyRenderStateRowIteratorImpl* iterator, GhosttyRenderStateRowData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult render_state_row_get_multi([NativeTypeName("GhosttyRenderStateRowIterator")] GhosttyRenderStateRowIteratorImpl* iterator, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyRenderStateRowData *")] GhosttyRenderStateRowData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_set", ExactSpelling = true)]
    public static extern GhosttyResult render_state_row_set([NativeTypeName("GhosttyRenderStateRowIterator")] GhosttyRenderStateRowIteratorImpl* iterator, GhosttyRenderStateRowOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_cells_new", ExactSpelling = true)]
    public static extern GhosttyResult render_state_row_cells_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttyRenderStateRowCells *")] GhosttyRenderStateRowCellsImpl** out_cells);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_cells_next", ExactSpelling = true)]
    public static extern bool render_state_row_cells_next([NativeTypeName("GhosttyRenderStateRowCells")] GhosttyRenderStateRowCellsImpl* cells);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_cells_select", ExactSpelling = true)]
    public static extern GhosttyResult render_state_row_cells_select([NativeTypeName("GhosttyRenderStateRowCells")] GhosttyRenderStateRowCellsImpl* cells, [NativeTypeName("uint16_t")] ushort x);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_cells_get", ExactSpelling = true)]
    public static extern GhosttyResult render_state_row_cells_get([NativeTypeName("GhosttyRenderStateRowCells")] GhosttyRenderStateRowCellsImpl* cells, GhosttyRenderStateRowCellsData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_cells_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult render_state_row_cells_get_multi([NativeTypeName("GhosttyRenderStateRowCells")] GhosttyRenderStateRowCellsImpl* cells, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyRenderStateRowCellsData *")] GhosttyRenderStateRowCellsData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_row_cells_free", ExactSpelling = true)]
    public static extern void render_state_row_cells_free([NativeTypeName("GhosttyRenderStateRowCells")] GhosttyRenderStateRowCellsImpl* cells);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_image_iterator_new", ExactSpelling = true)]
    public static extern GhosttyResult render_state_image_iterator_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttyRenderStateImageIterator *")] GhosttyRenderStateImageIteratorImpl** out_iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_image_iterator_free", ExactSpelling = true)]
    public static extern void render_state_image_iterator_free([NativeTypeName("GhosttyRenderStateImageIterator")] GhosttyRenderStateImageIteratorImpl* iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_image_iterator_next", ExactSpelling = true)]
    public static extern bool render_state_image_iterator_next([NativeTypeName("GhosttyRenderStateImageIterator")] GhosttyRenderStateImageIteratorImpl* iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_image_get", ExactSpelling = true)]
    public static extern GhosttyResult render_state_image_get([NativeTypeName("GhosttyRenderStateImageIterator")] GhosttyRenderStateImageIteratorImpl* iterator, GhosttyRenderStateImageData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_render_state_image_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult render_state_image_get_multi([NativeTypeName("GhosttyRenderStateImageIterator")] GhosttyRenderStateImageIteratorImpl* iterator, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyRenderStateImageData *")] GhosttyRenderStateImageData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_new", ExactSpelling = true)]
    public static extern GhosttyResult terminal_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttyTerminal *")] GhosttyTerminalImpl** terminal, [NativeTypeName("uint16_t")] ushort cols, [NativeTypeName("uint16_t")] ushort rows);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_free", ExactSpelling = true)]
    public static extern void terminal_free([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_reset", ExactSpelling = true)]
    public static extern void terminal_reset([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_resize", ExactSpelling = true)]
    public static extern GhosttyResult terminal_resize([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("uint16_t")] ushort cols, [NativeTypeName("uint16_t")] ushort rows, [NativeTypeName("uint32_t")] uint cell_width_px, [NativeTypeName("uint32_t")] uint cell_height_px);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_set", ExactSpelling = true)]
    public static extern GhosttyResult terminal_set([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyTerminalOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_vt_write", ExactSpelling = true)]
    public static extern void terminal_vt_write([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_vt_write_until", ExactSpelling = true)]
    public static extern GhosttyResult terminal_vt_write_until([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint len, [NativeTypeName("uint32_t")] uint boundaries, GhosttyTerminalWriteStop* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_continuation_write", ExactSpelling = true)]
    public static extern GhosttyResult terminal_continuation_write([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyWriter writer);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_continuation_buf", ExactSpelling = true)]
    public static extern GhosttyResult terminal_continuation_buf([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_continuation_alloc", ExactSpelling = true)]
    public static extern GhosttyResult terminal_continuation_alloc([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("uint8_t **")] byte** out_ptr, [NativeTypeName("size_t *")] nuint* out_len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_scroll_viewport", ExactSpelling = true)]
    public static extern GhosttyResult terminal_scroll_viewport([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyTerminalScrollViewport behavior);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_compression_activity", ExactSpelling = true)]
    public static extern GhosttyResult terminal_compression_activity([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("uint64_t *")] ulong* out_activity);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_compress", ExactSpelling = true)]
    public static extern GhosttyResult terminal_compress([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyTerminalCompressionMode mode, GhosttyTerminalCompressionResult* out_result);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_get", ExactSpelling = true)]
    public static extern GhosttyResult terminal_get([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyTerminalData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult terminal_get_multi([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyTerminalData *")] GhosttyTerminalData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_grid_ref", ExactSpelling = true)]
    public static extern GhosttyResult terminal_grid_ref([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyPoint point, GhosttyGridRef* out_ref);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_grid_ref_track", ExactSpelling = true)]
    public static extern GhosttyResult terminal_grid_ref_track([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyPoint point, [NativeTypeName("GhosttyTrackedGridRef *")] GhosttyTrackedGridRefImpl** out_ref);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_point_from_grid_ref", ExactSpelling = true)]
    public static extern GhosttyResult terminal_point_from_grid_ref([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttyGridRef *")] GhosttyGridRef* @ref, GhosttyPointTag tag, GhosttyPointCoordinate* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_grid_ref_cell", ExactSpelling = true)]
    public static extern GhosttyResult grid_ref_cell([NativeTypeName("const GhosttyGridRef *")] GhosttyGridRef* @ref, [NativeTypeName("GhosttyCell *")] ulong* out_cell);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_grid_ref_row", ExactSpelling = true)]
    public static extern GhosttyResult grid_ref_row([NativeTypeName("const GhosttyGridRef *")] GhosttyGridRef* @ref, [NativeTypeName("GhosttyRow *")] ulong* out_row);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_grid_ref_graphemes", ExactSpelling = true)]
    public static extern GhosttyResult grid_ref_graphemes([NativeTypeName("const GhosttyGridRef *")] GhosttyGridRef* @ref, [NativeTypeName("uint32_t *")] uint* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_grid_ref_hyperlink_uri", ExactSpelling = true)]
    public static extern GhosttyResult grid_ref_hyperlink_uri([NativeTypeName("const GhosttyGridRef *")] GhosttyGridRef* @ref, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_grid_ref_style", ExactSpelling = true)]
    public static extern GhosttyResult grid_ref_style([NativeTypeName("const GhosttyGridRef *")] GhosttyGridRef* @ref, GhosttyStyle* out_style);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_tracked_grid_ref_free", ExactSpelling = true)]
    public static extern void tracked_grid_ref_free([NativeTypeName("GhosttyTrackedGridRef")] GhosttyTrackedGridRefImpl* @ref);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_tracked_grid_ref_has_value", ExactSpelling = true)]
    public static extern bool tracked_grid_ref_has_value([NativeTypeName("GhosttyTrackedGridRef")] GhosttyTrackedGridRefImpl* @ref);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_tracked_grid_ref_point", ExactSpelling = true)]
    public static extern GhosttyResult tracked_grid_ref_point([NativeTypeName("GhosttyTrackedGridRef")] GhosttyTrackedGridRefImpl* @ref, GhosttyPointTag tag, GhosttyPointCoordinate* out_point);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_tracked_grid_ref_set", ExactSpelling = true)]
    public static extern GhosttyResult tracked_grid_ref_set([NativeTypeName("GhosttyTrackedGridRef")] GhosttyTrackedGridRefImpl* @ref, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyPoint point);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_tracked_grid_ref_snapshot", ExactSpelling = true)]
    public static extern GhosttyResult tracked_grid_ref_snapshot([NativeTypeName("GhosttyTrackedGridRef")] GhosttyTrackedGridRefImpl* @ref, GhosttyGridRef* out_ref);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z15ghostty_osc_newPK16GhosttyAllocatorPP20GhosttyOscParserImpl", ExactSpelling = true)]
    public static extern GhosttyResult osc_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttyOscParser *")] GhosttyOscParserImpl** parser);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z16ghostty_osc_freeP20GhosttyOscParserImpl", ExactSpelling = true)]
    public static extern void osc_free([NativeTypeName("GhosttyOscParser")] GhosttyOscParserImpl* parser);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z17ghostty_osc_resetP20GhosttyOscParserImpl", ExactSpelling = true)]
    public static extern void osc_reset([NativeTypeName("GhosttyOscParser")] GhosttyOscParserImpl* parser);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z15ghostty_osc_setP20GhosttyOscParserImpl16GhosttyOscOptionPKv", ExactSpelling = true)]
    public static extern GhosttyResult osc_set([NativeTypeName("GhosttyOscParser")] GhosttyOscParserImpl* parser, GhosttyOscOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z16ghostty_osc_nextP20GhosttyOscParserImplh", ExactSpelling = true)]
    public static extern void osc_next([NativeTypeName("GhosttyOscParser")] GhosttyOscParserImpl* parser, [NativeTypeName("uint8_t")] byte @byte);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z15ghostty_osc_endP20GhosttyOscParserImplh", ExactSpelling = true)]
    [return: NativeTypeName("GhosttyOscCommand")]
    public static extern GhosttyOscCommandImpl* osc_end([NativeTypeName("GhosttyOscParser")] GhosttyOscParserImpl* parser, [NativeTypeName("uint8_t")] byte terminator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z24ghostty_osc_command_typeP21GhosttyOscCommandImpl", ExactSpelling = true)]
    public static extern GhosttyOscCommandType osc_command_type([NativeTypeName("GhosttyOscCommand")] GhosttyOscCommandImpl* command);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z24ghostty_osc_command_dataP21GhosttyOscCommandImpl21GhosttyOscCommandDataPv", ExactSpelling = true)]
    public static extern GhosttyResult osc_command_data([NativeTypeName("GhosttyOscCommand")] GhosttyOscCommandImpl* command, GhosttyOscCommandData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_new", ExactSpelling = true)]
    public static extern GhosttyResult sgr_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttySgrParser *")] GhosttySgrParserImpl** parser);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_free", ExactSpelling = true)]
    public static extern void sgr_free([NativeTypeName("GhosttySgrParser")] GhosttySgrParserImpl* parser);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_reset", ExactSpelling = true)]
    public static extern void sgr_reset([NativeTypeName("GhosttySgrParser")] GhosttySgrParserImpl* parser);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_set_params", ExactSpelling = true)]
    public static extern GhosttyResult sgr_set_params([NativeTypeName("GhosttySgrParser")] GhosttySgrParserImpl* parser, [NativeTypeName("const uint16_t *")] ushort* @params, [NativeTypeName("const char *")] sbyte* separators, [NativeTypeName("size_t")] nuint len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_next", ExactSpelling = true)]
    public static extern bool sgr_next([NativeTypeName("GhosttySgrParser")] GhosttySgrParserImpl* parser, GhosttySgrAttribute* attr);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_unknown_full", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint sgr_unknown_full(GhosttySgrUnknown unknown, [NativeTypeName("const uint16_t **")] ushort** ptr);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_unknown_partial", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint sgr_unknown_partial(GhosttySgrUnknown unknown, [NativeTypeName("const uint16_t **")] ushort** ptr);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_attribute_tag", ExactSpelling = true)]
    public static extern GhosttySgrAttributeTag sgr_attribute_tag([NativeTypeName("const GhosttySgrAttribute *")] GhosttySgrAttribute* attr);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sgr_attribute_value", ExactSpelling = true)]
    public static extern GhosttySgrAttributeValue* sgr_attribute_value(GhosttySgrAttribute* attr);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_style_default", ExactSpelling = true)]
    public static extern void style_default(GhosttyStyle* style);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_style_is_default", ExactSpelling = true)]
    public static extern bool style_is_default([NativeTypeName("const GhosttyStyle *")] GhosttyStyle* style);

    [NativeTypeName("#define GHOSTTY_STYLE_FLAG_BOLD ((GhosttyStyleFlags)(1u << 0))")]
    public const ushort GHOSTTY_STYLE_FLAG_BOLD = ((ushort)(1U << 0));

    [NativeTypeName("#define GHOSTTY_STYLE_FLAG_ITALIC ((GhosttyStyleFlags)(1u << 1))")]
    public const ushort GHOSTTY_STYLE_FLAG_ITALIC = ((ushort)(1U << 1));

    [NativeTypeName("#define GHOSTTY_STYLE_FLAG_FAINT ((GhosttyStyleFlags)(1u << 2))")]
    public const ushort GHOSTTY_STYLE_FLAG_FAINT = ((ushort)(1U << 2));

    [NativeTypeName("#define GHOSTTY_STYLE_FLAG_BLINK ((GhosttyStyleFlags)(1u << 3))")]
    public const ushort GHOSTTY_STYLE_FLAG_BLINK = ((ushort)(1U << 3));

    [NativeTypeName("#define GHOSTTY_STYLE_FLAG_INVERSE ((GhosttyStyleFlags)(1u << 4))")]
    public const ushort GHOSTTY_STYLE_FLAG_INVERSE = ((ushort)(1U << 4));

    [NativeTypeName("#define GHOSTTY_STYLE_FLAG_INVISIBLE ((GhosttyStyleFlags)(1u << 5))")]
    public const ushort GHOSTTY_STYLE_FLAG_INVISIBLE = ((ushort)(1U << 5));

    [NativeTypeName("#define GHOSTTY_STYLE_FLAG_STRIKETHROUGH ((GhosttyStyleFlags)(1u << 6))")]
    public const ushort GHOSTTY_STYLE_FLAG_STRIKETHROUGH = ((ushort)(1U << 6));

    [NativeTypeName("#define GHOSTTY_STYLE_FLAG_OVERLINE ((GhosttyStyleFlags)(1u << 7))")]
    public const ushort GHOSTTY_STYLE_FLAG_OVERLINE = ((ushort)(1U << 7));

    [NativeTypeName("#define GHOSTTY_STYLE_UNDERLINE_SHIFT 8")]
    public const int GHOSTTY_STYLE_UNDERLINE_SHIFT = 8;

    [NativeTypeName("#define GHOSTTY_STYLE_UNDERLINE_MASK ((GhosttyStyleFlags)(0x7u << GHOSTTY_STYLE_UNDERLINE_SHIFT))")]
    public const ushort GHOSTTY_STYLE_UNDERLINE_MASK = ((ushort)(0x7U << 8));

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sys_set", ExactSpelling = true)]
    public static extern GhosttyResult sys_set(GhosttySysOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_sys_log_stderr", ExactSpelling = true)]
    public static extern void sys_log_stderr(void* userdata, GhosttySysLogLevel level, [NativeTypeName("const uint8_t *")] byte* scope, [NativeTypeName("size_t")] nuint scope_len, [NativeTypeName("const uint8_t *")] byte* message, [NativeTypeName("size_t")] nuint message_len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_get", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_get([NativeTypeName("GhosttyKittyGraphics")] GhosttyKittyGraphicsImpl* graphics, GhosttyKittyGraphicsData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_animation_tick", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_animation_tick([NativeTypeName("GhosttyKittyGraphics")] GhosttyKittyGraphicsImpl* graphics, [NativeTypeName("uint64_t")] ulong now_ms, [NativeTypeName("uint64_t *")] ulong* next_ms);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_image", ExactSpelling = true)]
    [return: NativeTypeName("GhosttyKittyGraphicsImage")]
    public static extern GhosttyKittyGraphicsImageImpl* kitty_graphics_image([NativeTypeName("GhosttyKittyGraphics")] GhosttyKittyGraphicsImpl* graphics, [NativeTypeName("uint32_t")] uint image_id);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_image_get", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_image_get([NativeTypeName("GhosttyKittyGraphicsImage")] GhosttyKittyGraphicsImageImpl* image, GhosttyKittyGraphicsImageData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_image_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_image_get_multi([NativeTypeName("GhosttyKittyGraphicsImage")] GhosttyKittyGraphicsImageImpl* image, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyKittyGraphicsImageData *")] GhosttyKittyGraphicsImageData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_iterator_new", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_iterator_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttyKittyGraphicsPlacementIterator *")] GhosttyKittyGraphicsPlacementIteratorImpl** out_iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_iterator_free", ExactSpelling = true)]
    public static extern void kitty_graphics_placement_iterator_free([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_iterator_set", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_iterator_set([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, GhosttyKittyGraphicsPlacementIteratorOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_next", ExactSpelling = true)]
    public static extern bool kitty_graphics_placement_next([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_get", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_get([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, GhosttyKittyGraphicsPlacementData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_get_multi([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyKittyGraphicsPlacementData *")] GhosttyKittyGraphicsPlacementData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_rect", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_rect([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, [NativeTypeName("GhosttyKittyGraphicsImage")] GhosttyKittyGraphicsImageImpl* image, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttySelection* out_selection);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_pixel_size", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_pixel_size([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, [NativeTypeName("GhosttyKittyGraphicsImage")] GhosttyKittyGraphicsImageImpl* image, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("uint32_t *")] uint* out_width, [NativeTypeName("uint32_t *")] uint* out_height);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_grid_size", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_grid_size([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, [NativeTypeName("GhosttyKittyGraphicsImage")] GhosttyKittyGraphicsImageImpl* image, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("uint32_t *")] uint* out_cols, [NativeTypeName("uint32_t *")] uint* out_rows);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_viewport_pos", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_viewport_pos([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, [NativeTypeName("GhosttyKittyGraphicsImage")] GhosttyKittyGraphicsImageImpl* image, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("int32_t *")] int* out_col, [NativeTypeName("int32_t *")] int* out_row);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_source_rect", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_source_rect([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, [NativeTypeName("GhosttyKittyGraphicsImage")] GhosttyKittyGraphicsImageImpl* image, [NativeTypeName("uint32_t *")] uint* out_x, [NativeTypeName("uint32_t *")] uint* out_y, [NativeTypeName("uint32_t *")] uint* out_width, [NativeTypeName("uint32_t *")] uint* out_height);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_kitty_graphics_placement_render_info", ExactSpelling = true)]
    public static extern GhosttyResult kitty_graphics_placement_render_info([NativeTypeName("GhosttyKittyGraphicsPlacementIterator")] GhosttyKittyGraphicsPlacementIteratorImpl* iterator, [NativeTypeName("GhosttyKittyGraphicsImage")] GhosttyKittyGraphicsImageImpl* image, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyKittyGraphicsPlacementRenderInfo* out_info);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_mode_report_encode", ExactSpelling = true)]
    public static extern GhosttyResult mode_report_encode(GhosttyMode mode, GhosttyModeReportState state, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_paste", ExactSpelling = true)]
    public static extern GhosttyResult terminal_paste([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttyPaste *")] GhosttyPaste* paste, bool* out_pasted);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_paste_is_safe", ExactSpelling = true)]
    public static extern bool paste_is_safe([NativeTypeName("const char *")] sbyte* data, [NativeTypeName("size_t")] nuint len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_paste_encode", ExactSpelling = true)]
    public static extern GhosttyResult paste_encode([NativeTypeName("char *")] sbyte* data, [NativeTypeName("size_t")] nuint data_len, bool bracketed, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_cell_get", ExactSpelling = true)]
    public static extern GhosttyResult cell_get([NativeTypeName("GhosttyCell")] ulong cell, GhosttyCellData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_cell_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult cell_get_multi([NativeTypeName("GhosttyCell")] ulong cell, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyCellData *")] GhosttyCellData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_row_get", ExactSpelling = true)]
    public static extern GhosttyResult row_get([NativeTypeName("GhosttyRow")] ulong row, GhosttyRowData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_row_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult row_get_multi([NativeTypeName("GhosttyRow")] ulong row, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttyRowData *")] GhosttyRowData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_new", ExactSpelling = true)]
    public static extern GhosttyResult search_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttySearch *")] GhosttySearchImpl** out_search, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_free", ExactSpelling = true)]
    public static extern void search_free([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_tick", ExactSpelling = true)]
    public static extern GhosttyResult search_tick([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search, GhosttySearchStatus* out_status);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_feed", ExactSpelling = true)]
    public static extern GhosttyResult search_feed([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_run", ExactSpelling = true)]
    public static extern GhosttyResult search_run([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_select_next", ExactSpelling = true)]
    public static extern GhosttyResult search_select_next([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_select_prev", ExactSpelling = true)]
    public static extern GhosttyResult search_select_prev([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_set", ExactSpelling = true)]
    public static extern GhosttyResult search_set([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search, GhosttySearchOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_get", ExactSpelling = true)]
    public static extern GhosttyResult search_get([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search, GhosttySearchData data, void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_search_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult search_get_multi([NativeTypeName("GhosttySearch")] GhosttySearchImpl* search, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttySearchData *")] GhosttySearchData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_event_new", ExactSpelling = true)]
    public static extern GhosttyResult selection_gesture_event_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttySelectionGestureEvent *")] GhosttySelectionGestureEventImpl** out_event, GhosttySelectionGestureEventType type);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_event_free", ExactSpelling = true)]
    public static extern void selection_gesture_event_free([NativeTypeName("GhosttySelectionGestureEvent")] GhosttySelectionGestureEventImpl* @event);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_event_set", ExactSpelling = true)]
    public static extern GhosttyResult selection_gesture_event_set([NativeTypeName("GhosttySelectionGestureEvent")] GhosttySelectionGestureEventImpl* @event, GhosttySelectionGestureEventOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_event", ExactSpelling = true)]
    public static extern GhosttyResult selection_gesture_event([NativeTypeName("GhosttySelectionGesture")] GhosttySelectionGestureImpl* gesture, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("GhosttySelectionGestureEvent")] GhosttySelectionGestureEventImpl* @event, GhosttySelection* out_selection);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_new", ExactSpelling = true)]
    public static extern GhosttyResult selection_gesture_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttySelectionGesture *")] GhosttySelectionGestureImpl** out_gesture);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_free", ExactSpelling = true)]
    public static extern void selection_gesture_free([NativeTypeName("GhosttySelectionGesture")] GhosttySelectionGestureImpl* gesture, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_reset", ExactSpelling = true)]
    public static extern void selection_gesture_reset([NativeTypeName("GhosttySelectionGesture")] GhosttySelectionGestureImpl* gesture, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_get", ExactSpelling = true)]
    public static extern GhosttyResult selection_gesture_get([NativeTypeName("GhosttySelectionGesture")] GhosttySelectionGestureImpl* gesture, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttySelectionGestureData data, void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_selection_gesture_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult selection_gesture_get_multi([NativeTypeName("GhosttySelectionGesture")] GhosttySelectionGestureImpl* gesture, [NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttySelectionGestureData *")] GhosttySelectionGestureData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_select_word", ExactSpelling = true)]
    public static extern GhosttyResult terminal_select_word([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttyTerminalSelectWordOptions *")] GhosttyTerminalSelectWordOptions* options, GhosttySelection* out_selection);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_select_word_between", ExactSpelling = true)]
    public static extern GhosttyResult terminal_select_word_between([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttyTerminalSelectWordBetweenOptions *")] GhosttyTerminalSelectWordBetweenOptions* options, GhosttySelection* out_selection);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_select_line", ExactSpelling = true)]
    public static extern GhosttyResult terminal_select_line([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttyTerminalSelectLineOptions *")] GhosttyTerminalSelectLineOptions* options, GhosttySelection* out_selection);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_select_all", ExactSpelling = true)]
    public static extern GhosttyResult terminal_select_all([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttySelection* out_selection);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_select_output", ExactSpelling = true)]
    public static extern GhosttyResult terminal_select_output([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttyGridRef *")] GhosttyGridRef* @ref, GhosttySelection* out_selection);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_selection_adjust", ExactSpelling = true)]
    public static extern GhosttyResult terminal_selection_adjust([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttySelection* selection, GhosttySelectionAdjust adjustment);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_selection_order", ExactSpelling = true)]
    public static extern GhosttyResult terminal_selection_order([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttySelection *")] GhosttySelection* selection, GhosttySelectionOrder* out_order);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_selection_ordered", ExactSpelling = true)]
    public static extern GhosttyResult terminal_selection_ordered([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttySelection *")] GhosttySelection* selection, GhosttySelectionOrder desired, GhosttySelection* out_selection);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_selection_contains", ExactSpelling = true)]
    public static extern GhosttyResult terminal_selection_contains([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttySelection *")] GhosttySelection* selection, GhosttyPoint point, bool* out_contains);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_terminal_selection_equal", ExactSpelling = true)]
    public static extern GhosttyResult terminal_selection_equal([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttySelection *")] GhosttySelection* a, [NativeTypeName("const GhosttySelection *")] GhosttySelection* b, bool* out_equal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_size_report_encode", ExactSpelling = true)]
    public static extern GhosttyResult size_report_encode(GhosttySizeReportStyle style, [NativeTypeName("const GhosttySizeReportSize *")] GhosttySizeReportSize* size, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_encode", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_encode([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, GhosttyWriter writer);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_encode_buf", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_encode_buf([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("uint8_t *")] byte* buf, [NativeTypeName("size_t")] nuint buf_len, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_encode_alloc", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_encode_alloc([NativeTypeName("GhosttyTerminal")] GhosttyTerminalImpl* terminal, [NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("uint8_t **")] byte** out_ptr, [NativeTypeName("size_t *")] nuint* out_len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_new", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_decoder_new([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttySnapshotDecoder *")] GhosttySnapshotDecoderImpl** decoder, GhosttyReader reader);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_new_buf", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_decoder_new_buf([NativeTypeName("const GhosttyAllocator *")] GhosttyAllocator* allocator, [NativeTypeName("GhosttySnapshotDecoder *")] GhosttySnapshotDecoderImpl** decoder, [NativeTypeName("const uint8_t *")] byte* ptr, [NativeTypeName("size_t")] nuint len);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_free", ExactSpelling = true)]
    public static extern void snapshot_decoder_free([NativeTypeName("GhosttySnapshotDecoder")] GhosttySnapshotDecoderImpl* decoder);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_set", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_decoder_set([NativeTypeName("GhosttySnapshotDecoder")] GhosttySnapshotDecoderImpl* decoder, GhosttySnapshotDecoderOption option, [NativeTypeName("const void *")] void* value);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_ready", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_decoder_ready([NativeTypeName("GhosttySnapshotDecoder")] GhosttySnapshotDecoderImpl* decoder, [NativeTypeName("GhosttyTerminal *")] GhosttyTerminalImpl** terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_next", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_decoder_next([NativeTypeName("GhosttySnapshotDecoder")] GhosttySnapshotDecoderImpl* decoder);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_decode", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_decoder_decode([NativeTypeName("GhosttySnapshotDecoder")] GhosttySnapshotDecoderImpl* decoder, [NativeTypeName("GhosttyTerminal *")] GhosttyTerminalImpl** terminal);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_get", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_decoder_get([NativeTypeName("GhosttySnapshotDecoder")] GhosttySnapshotDecoderImpl* decoder, GhosttySnapshotDecoderData data, void* @out);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_snapshot_decoder_get_multi", ExactSpelling = true)]
    public static extern GhosttyResult snapshot_decoder_get_multi([NativeTypeName("GhosttySnapshotDecoder")] GhosttySnapshotDecoderImpl* decoder, [NativeTypeName("size_t")] nuint count, [NativeTypeName("const GhosttySnapshotDecoderData *")] GhosttySnapshotDecoderData* keys, void** values, [NativeTypeName("size_t *")] nuint* out_written);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_unicode_codepoint_width", ExactSpelling = true)]
    [return: NativeTypeName("uint8_t")]
    public static extern byte unicode_codepoint_width([NativeTypeName("uint32_t")] uint cp);

    [DllImport("ghostty-vt", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ghostty_unicode_grapheme_width", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint unicode_grapheme_width([NativeTypeName("const uint32_t *")] uint* cps, [NativeTypeName("size_t")] nuint len, [NativeTypeName("uint8_t *")] byte* width);
}
