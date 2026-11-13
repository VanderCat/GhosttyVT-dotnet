using System.Text;
using GhosttyVT.Interop;

namespace GhosttyVT.Examples.Raylib;

public class Program {
    public unsafe static int Main(string[] args) {
        using var terminal = new GhosttyTerminal(80, 24);
        // Feed VT data into the terminal
        terminal.VtWrite("Hello, World!\r\n"u8);
 
        // ANSI color codes: ESC[1;32m = bold green, ESC[0m = reset
        terminal.VtWrite("\x1b[1;32mGreen Text\x1b[0m\r\n"u8);
 
        // Cursor positioning: ESC[1;1H = move to row 1, column 1
        terminal.VtWrite("\x1b[1;1HTop-left corner\r\n"u8);
 
        // Cursor movement: ESC[5B = move down 5 lines
        terminal.VtWrite("\x1b[5B"u8);
        terminal.VtWrite("Moved down!\r\n"u8);
 
        // Erase line: ESC[2K = clear entire line
        terminal.VtWrite("\x1b[2K"u8);
        terminal.VtWrite("New content\r\n"u8);
 
        // Multiple lines
        terminal.VtWrite("Line A\r\nLine B\r\nLine C\r\n"u8);
        
        using var formatter = GhosttyFormatter.FromTerminal(terminal);
 
        var emit = GhosttyFormatterFormat.PLAIN;
        formatter.Set(GhosttyFormatterOption.EMIT, ref emit);
        
        var trim = true;
        formatter.Set(GhosttyFormatterOption.TRIM, ref trim);
 
        var buf = formatter.Format();

        using (var stdout = Console.OpenStandardOutput()) {
            stdout.Write(buf);
        }
        Console.WriteLine();

        return 0;
    }
}