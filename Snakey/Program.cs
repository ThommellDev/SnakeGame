#if DEBUG
using System.Runtime.InteropServices;

[DllImport("kernel32.dll")]
static extern bool AllocConsole();

// Allocate a console window
AllocConsole();
#endif

using var game = new Snakey.Game1();
game.Run();