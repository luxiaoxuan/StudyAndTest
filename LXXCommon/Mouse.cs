using System.Drawing;
using Input = Microsoft.Test.Input;

namespace LXXCommon
{
    public static class Mouse
    {
        private static double? _dpi = null;

        private static double? Dpi
        {
            get
            {
                if (!_dpi.HasValue)
                {
                    _dpi = DisplayUtility.GetScalingFactor();
                }
                return _dpi;
            }
        }


        public static void LeftClick()
        {
            Input.Mouse.Click(Input.MouseButton.Left);
        }

        public static void RightClick()
        {
            Input.Mouse.Click(Input.MouseButton.Right);
        }

        public static void MoveTo(Point p)
        {
            Input.Mouse.MoveTo(new Point((int)(p.X / Dpi), (int)(p.Y / Dpi)));
        }
    }
}
