using System.Text;
using GhosttyVT.Interop;

namespace GhosttyVT;

public static class GhosttyBuildInfo {
    private unsafe static T GetInfo<T>(Interop.GhosttyBuildInfo value) where T : unmanaged {
        var tmp = stackalloc T[1];
        Ghostty.build_info(value, tmp);
        return *tmp;
    }
    
    static unsafe GhosttyBuildInfo() {
        SIMD = GetInfo<bool>(Interop.GhosttyBuildInfo.SIMD);
        KittyGraphics = GetInfo<bool>(Interop.GhosttyBuildInfo.KITTY_GRAPHICS);
        TmuxControlMode = GetInfo<bool>(Interop.GhosttyBuildInfo.TMUX_CONTROL_MODE);
        Optimize = GetInfo<GhosttyOptimizeMode>(Interop.GhosttyBuildInfo.OPTIMIZE);
        var versionString = GetInfo<GhosttyString>(Interop.GhosttyBuildInfo.VERSION_STRING);
        VersionString = Encoding.UTF8.GetString(versionString.ptr, (int)versionString.len);
        VersionMajor = GetInfo<IntPtr>(Interop.GhosttyBuildInfo.VERSION_MAJOR);
        VersionMinor = GetInfo<IntPtr>(Interop.GhosttyBuildInfo.VERSION_MINOR);
        VersionPatch = GetInfo<IntPtr>(Interop.GhosttyBuildInfo.VERSION_PATCH);
        var versionPre = GetInfo<GhosttyString>(Interop.GhosttyBuildInfo.VERSION_PRE);
        VersionPre = Encoding.UTF8.GetString(versionPre.ptr, (int)versionPre.len);
        var versionBuild = GetInfo<GhosttyString>(Interop.GhosttyBuildInfo.VERSION_BUILD);
        VersionBuild = Encoding.UTF8.GetString(versionBuild.ptr, (int)versionBuild.len);
        FeatureSnapshot = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_SNAPSHOT);
        FeatureFormatter = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_FORMATTER);
        FeatureSelection = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_SELECTION);
        FeatureSearch = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_SEARCH);
        FeatureRenderState = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_RENDER_STATE);
        FeatureInputEncode = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_INPUT_ENCODE);
        FeatureColor = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_COLOR);
        FeatureGridIntrospection = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_GRID_INTROSPECTION);
        FeatureGlyphProtocol = GetInfo<bool>(Interop.GhosttyBuildInfo.FEATURE_GLYPH_PROTOCOL);
    }

    /// <summary>
    /// Whether SIMD-accelerated code paths are enabled.
    /// </summary>
    public static readonly bool SIMD;
    
    /// <summary>
    /// Whether this build includes the kitty_graphics feature, which provides the Kitty graphics protocol and the
    /// ghostty_kitty_graphics_* functions. It is always false on targets without an operating system, such as
    /// wasm32-freestanding.
    /// </summary>
    public static readonly bool KittyGraphics;
    
    /// <summary>
    /// Whether tmux control mode support is available.
    /// </summary>
    public static readonly bool TmuxControlMode;

    /// <summary>
    /// The optimization mode the library was built with.
    /// </summary>
    public static readonly GhosttyOptimizeMode Optimize;

    /// The full version string (e.g. "1.2.3" or "1.2.3-dev+abcdef").
    public static readonly string VersionString;

    /// The major version number.
    public static readonly nint VersionMajor;

    /// The minor version number.
    public static readonly nint VersionMinor;

    /// The patch version number.
    public static readonly nint VersionPatch;

    /// The pre metadata string (e.g. "alpha", "beta", "dev"). Has zero length if no pre metadata is present.
    public static readonly string VersionPre;

    ///The build metadata string (e.g. commit hash). Has zero length if no build metadata is present.
    public static readonly string VersionBuild;

    ///Whether this build includes the snapshot feature, which provides the <see cref="GhosttySnapshot"/> functions. 
    public static readonly bool FeatureSnapshot;

    ///Whether this build includes the formatter feature, which provides the <see cref="GhosttyFormatter"/> functions.
    public static readonly bool FeatureFormatter;

    ///Whether this build includes the selection feature, which provides the ghostty_terminal_select_*,
    /// ghostty_terminal_selection_* and ghostty_selection_gesture_* functions.
    public static readonly bool FeatureSelection;

    ///Whether this build includes the search feature, which provides the <see cref="GhosttySearch"/> functions.
    public static readonly bool FeatureSearch;

    ///Whether this build includes the render_state feature, which provides the <see cref="RenderState"/> functions.
    public static readonly bool FeatureRenderState;

    /// Whether this build includes the input_encode feature, which provides the key, mouse, focus and paste encoding
    /// functions. See Optional Features for the full list.
    public static readonly bool FeatureInputEncode;

    ///Whether this build includes the color feature, which provides the <see cref="GhosttyColor"/> functions.
    public static readonly bool FeatureColor;

    ///Whether this build includes the grid_introspection feature, which provides the <see cref="GhosttyGridRef"/>,
    /// <see cref="GhosttyTrackedGridRef"/>, ghostty_cell_get* and ghostty_row_get* functions.
    /// See Optional Features for the full list.
    public static readonly bool FeatureGridIntrospection;

    ///Whether this build includes the glyph_protocol feature, which lets applications register custom glyphs with
    /// Ghostty's glyph protocol. It has no functions of its own.
    public static readonly bool FeatureGlyphProtocol;
}