using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    public class SoftSets
    {
        private int authentic = 0;
        private int nonauthentic = 0;
        private double maxResult = 0;

        public int Authentic { get { return authentic; } private set { authentic = value; } }
        public int Nonauthentic { get { return nonauthentic; } private set { nonauthentic = value; } }
        public double MaxResult { get { return maxResult; } private set { maxResult = value; } }

        public void Approximation(double[][] data, int length) // Zaokrąglenie
        {
            double[][] temp = data;
            double[] array = new double[length];
            double[] Mask = new double[4] { 0.5, 0.7, 0.8, 0.7 };
            double[,] results = new double[length, 2];


            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    data[i][j] = Convert.ToInt32(Math.Round(data[i][j]));
                }
            }


            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    results[i, 0] += data[i][j] * Mask[j];
                }
                results[i, 1] = temp[i][4];
            }

            for (int i = 0; i < length; i++)
            {
                array[i] = results[i, 0];
            }

            MaxResult = array.Max();

            for (int i = 0; i < length; i++)
            {
                if (results[i, 0] == MaxResult)
                {
                    switch (results[i, 1])
                    {
                        case 1:
                            Authentic++;
                            break;
                        case 0:
                            Nonauthentic++;
                            break;
                    }
                }
            }
        }
    }
}
