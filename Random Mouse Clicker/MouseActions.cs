//Original from http://pinvoke.net/default.aspx/user32.mouse_event

using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace Random_Mouse_Clicker
{
    public class MouseActions
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }

        // Performs a mouse click
        public static void MouseClick()
        {
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep((new Random()).Next(20, 30));
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

    }
}
