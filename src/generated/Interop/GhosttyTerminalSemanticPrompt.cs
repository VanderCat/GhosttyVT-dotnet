namespace GhosttyVT.Interop;

public partial struct GhosttyTerminalSemanticPrompt
{
    public GhosttySemanticPromptKind kind;

    public GhosttySemanticPromptPromptKind prompt_kind;

    public bool has_exit_code;

    [NativeTypeName("int32_t")]
    public int exit_code;

    public GhosttyString command;

    public GhosttyString error;
}
