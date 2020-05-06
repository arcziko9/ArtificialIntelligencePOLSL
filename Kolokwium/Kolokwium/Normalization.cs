using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    public class Normalization
    {
        static double Normalize(double value, double min, double max, double nmax, double nmin) //Normalizowanko
        {
            double x = ((value - min) / (max - min)) * (nmax - nmin);
            return x;
        }

        public double[][] DoNormalize(double[][] data, int column, double nmax, double nmin)
        {
            double max = FindMaxValue(data, column);
            double min = FindMinValue(data, column);
            double[][] temp = data;

            for (int i = 0; i < data.Length; i++)
            {
                temp[i][column] = Normalize(temp[i][column], min, max, nmax, nmin);
            }
            return data;
        }

        public double[][] Shuffle(double[][] data) // Tasowanko
        {
            Random random = new Random();
            for (int i = data.Length - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                double[] temp = data[i];
                data[i] = data[swapIndex];
                data[swapIndex] = temp;
            }
            return data;
        }
        private static double FindMaxValue(double[][] data, int k)
        {
            double max = data[0][k];
            for (int i = 0; i < data.Length; i++)
            {
                if (max < data[i][k])
                {
                    max = data[i][k];
                }
            }
            return max;
        }

        private static double FindMinValue(double[][] data, int k)
        {
            double min = data[0][k];
            for (int i = 0; i < data.Length; i++)
            {
                if (min > data[i][k])
                {
                    min = data[i][k];
                }
            }
            return min;
        }
    }
}
