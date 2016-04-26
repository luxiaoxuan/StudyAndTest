using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXXCommon
{
    public class ImageUtility
    {
        public static bool CompareBitmap(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1.Width != bmp2.Width ||
                bmp1.Height != bmp2.Height)
            {
                return false;
            }

            for (var w = 0; w < bmp1.Width; w++)
            {
                for (var h = 0; h < bmp1.Height; h++)
                {
                    var color1 = bmp1.GetPixel(w, h);
                    var color2 = bmp2.GetPixel(w, h);
                    if (color1 != color2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
