#if DEBUG
using System.Runtime.InteropServices;

// UNCOMMENT THIS IF YOURE ON WINDOWS!
// comment this if youre on linux!
[DllImport("kernel32.dll")]
static extern bool AllocConsole();


// UNCOMMENT THIS IF YOURE ON WINDOWS!
// comment this if youre on linux!
AllocConsole();
#endif

using var game = new Snakey.Game1();
game.Run();