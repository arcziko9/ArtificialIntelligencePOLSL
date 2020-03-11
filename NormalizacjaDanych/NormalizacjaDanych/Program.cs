using System;
using System.Collections.Generic;
using System.Linq;

namespace NormalizacjaDanych
{
    class Program
    {
         static List<double> Normalize(List<double> data)
        {
            List<double> normalizeData = new List<double>();
            double minValue = 0;
            double maxValue = 1;
            double min = data.Min();
            double max = data.Max();
            for(int i = 0; i < data.Count(); i++)
            {
                double temp = 0;
                temp = (data[i] - min) / (max - min) * (maxValue - minValue);
                normalizeData.Add(temp);
            }
            return normalizeData;
        }

        static void Main(string[] args)
        {
            List<double> data = new List<double>() { 1.2, 2.5, 3.8, 4.4, 5.4, 6.2, 12.4 };
            Console.WriteLine("Before normalize: ");
            foreach (var item in data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nAfter normalize: ");
            List<double> normalizationData = Normalize(data);
            foreach (var item in normalizationData)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }
    }
}
