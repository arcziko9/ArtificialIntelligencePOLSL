using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Data
    {
        public static void ReadData(string path,ref double[][] data)
        {
            string[] lines = File.ReadAllLines(path);
            data = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                data[i] = new double[tmp.Length + 2];
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(tmp[j]);
                }
                if (tmp[4] == "Iris-setosa")
                {
                    data[i][4] = 1;
                    data[i][5] = 0;
                    data[i][6] = 0;

                }
                else if (tmp[4] == "Iris-versicolor")
                {
                    data[i][4] = 0;
                    data[i][5] = 1;
                    data[i][6] = 0;
                }
                else
                {
                    data[i][4] = 0;
                    data[i][5] = 0;
                    data[i][6] = 1;
                }
            }
        }

        public static void Shuffle(ref double[][] data)
        {
            Random random = new Random();
            for (int i = data.Length - 1; i >= 0; i--)
            {
                int r = random.Next(0, data.Length);
                for (int j = 0; j < data[i].Length; j++)
                {
                    double tmp = data[i][j];
                    data[i][j] = data[r][j];
                    data[r][j] = tmp;
                }
            }
        }

        private static double FindMax(double[][] data, int columnIndex)
        {
            double max = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][columnIndex] > max)
                {
                    max = data[i][columnIndex];
                }
            }
            return max;
        }

        private static double FindMin(double[][] data, int columnIndex)
        {
            double min = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][columnIndex] < min)
                {
                    min = data[i][columnIndex];
                }
            }
            return min;
        }

        public static void Normalize(ref double[][] data)
        {
            double minValue = 0;
            double maxValue = 1;
            double min = 0;
            double max = 0;
            for (int i = 0; i < data[0].Length - 3; i++)
            {
                min = FindMin(data, i);
                max = FindMax(data, i);
                for (int j = 0; j < data.Length; j++)
                {
                    double temp = 0;
                    temp = (data[j][i] - min) / (max - min) * (maxValue - minValue);
                    data[j][i] = temp;
                }
            }
        }
        public static void PrintArray(double[][] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                for (int x = 0; x < 7; x++)
                {
                    Console.Write(array[j][x] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
