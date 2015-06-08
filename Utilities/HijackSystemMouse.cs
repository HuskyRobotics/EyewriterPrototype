using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Mouse = System.Windows.Forms.Cursor;
using Screen = System.Windows.Forms.Screen;


namespace Utilities
{
    public static class HijackSystemMouse
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MouseEvent_Move = 0x0001;
        private const int MouseEvent_LeftButtonDown = 0x0002;
        private const int MouseEvent_LeftButtonUp = 0x0004;
        private const int MouseEvent_RightButtonDown = 0x0008;
        private const int MouseEvent_RightButtonUp = 0x0010;
        private const int MouseEvent_MiddleButtonDown = 0x0020;
        private const int MouseEvent_MiddleButtonUp = 0x0040;
        private const int MouseEvent_Absolute = 0x8000;
        private const int INT_MIN = int.MinValue;
        private const int INT_MAX = int.MaxValue;


        public static float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }


        public static void MoveSystemMouseTo(int xDelta, int yDelta)
        {
            mouse_event(MouseEvent_Move, xDelta, yDelta, 0, 0);
        }

        public static void MoveSystemMouseToExactly(int x, int y)
        {
            System.Windows.Forms.Cursor.Position = new Point(x, y);           
        }

        public static void LeftClick()
        {
            mouse_event(MouseEvent_LeftButtonDown, Mouse.Position.X, Mouse.Position.Y, 0, 0);
            mouse_event(MouseEvent_LeftButtonUp,   Mouse.Position.X, Mouse.Position.Y, 0, 0);
        }

        public static void LeftButtonDown()
        {
            mouse_event(MouseEvent_LeftButtonDown,Mouse.Position.X,Mouse.Position.Y, 0, 0);
        }

        public static void LeftButtonUp()
        {
            mouse_event(MouseEvent_LeftButtonUp,Mouse.Position.X,Mouse.Position.Y, 0, 0);
        }

        public static void RightClick()
        {
            mouse_event(MouseEvent_RightButtonDown,Mouse.Position.X,Mouse.Position.Y, 0, 0);
            mouse_event(MouseEvent_RightButtonUp, Mouse.Position.X, Mouse.Position.Y, 0, 0);
        }

        public static void RightDown()
        {
            mouse_event(MouseEvent_RightButtonDown,Mouse.Position.X,Mouse.Position.Y, 0, 0);
        }

        public static void RightUp()
        {
            mouse_event(MouseEvent_RightButtonUp,Mouse.Position.X,Mouse.Position.Y, 0, 0);
        }

    }
}
