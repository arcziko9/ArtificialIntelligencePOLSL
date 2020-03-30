using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        private static double[][] data;
        static void Main(string[] args)
        {
            string path = @"D:\Politechnika\Semestr4\ArtificialIntelligencePOLSL\Introduction\Introduction\photo.png";
            Color[][] matrix = Graphics.Macierz(path);
            Graphics.Sharp(matrix, path);
            Graphics.Gauss(matrix, path);
            Graphics.Blur(matrix, path);
            Graphics.EdgeDetection(matrix, path);


            Data.ReadData(@"D:\Politechnika\Semestr4\ArtificialIntelligencePOLSL\Introduction\Introduction\bazaIris.txt",ref data);
            Data.Normalize(ref data);
            Data.Shuffle(ref data);
            Data.PrintArray(data);
            Console.ReadKey();
        }
    }
}
