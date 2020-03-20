using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PhotoFiltr
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap btm = new Bitmap(@"D:\IrisDatabase\photo.png");
            Bitmap btmF = new Bitmap(btm.Width, btm.Height);

            int redSume, greenSume, blueSume;

            double[][] kernel = new double[3][];
            kernel[0] = new double[] { -1, -1, -1};
            kernel[1] = new double[] { -1, 8, -1};
            kernel[2] = new double[] { -1, -1, -1};

            for (int i = 0; i < btm.Width; i++)
            {
                for (int j = 0; i < btm.Height; i++)
                {
                    redSume = 0;
                    greenSume = 0;
                    blueSume = 0;
                    for (int k = 0; k < Size; k++)
                    {
                        for (int l = 0; l < Size; l++)
                        {

                        }
                    }
                }
            }
            if (redSume > 255) redSume = 255;
            else if (redSume < 0) redSume = 0;
            if (greenSume > 255) greenSume = 255;
            else if (greenSume < 0) gsume = 0;
            if (bsume > 255) bsume = 255;
            else if (bsume < 0) bsume = 0;
        } 
    }
}
