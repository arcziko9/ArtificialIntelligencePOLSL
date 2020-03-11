using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ModyfikacjaObrazu
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap btm = new Bitmap(@"D:\IrisDatabase\photo.png");
            for(int i = 0; i < btm.Width; i++)
            {
                for (int j = 0; j < btm.Height; j++)
                {
                    Color pxl = btm.GetPixel(i, j);
                    int avg = (pxl.R + pxl.G + pxl.B) / 3;
                    btm.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                }
            }
            btm.Save(@"D:\IrisDatabase\Newphoto.png");
        }
    }
}
