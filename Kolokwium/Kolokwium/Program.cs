using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Zadanie1
            string path = @"data_banknote_authentication.txt";
            string[] lines = File.ReadAllLines(path);
            double[][] data = new double[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(',');
                data[i] = new double[temp.Length];

                for (int j = 0; j < temp.Length; j++)
                {
                    data[i][j] = Convert.ToDouble(temp[j].Replace('.', ','));
                }
            }

            Normalization normalization = new Normalization(); // Normalizacja

            for (int i = 0; i < 4; i++)
            {
                data = normalization.DoNormalize(data, i, 1, 0);
            }
            data = normalization.Shuffle(data);

            //Zadanie2
            SoftSets softSets = new SoftSets();
            softSets.Approximation(data, lines.Length);
            Console.WriteLine("Max = " + softSets.MaxResult);
            Console.WriteLine("Authentic = " + softSets.Authentic);
            Console.WriteLine("Nonauthentic = " + softSets.Nonauthentic);

            //Zadanie3
            double[][] data70;
            double[][] data30;
            double[][] expectedValue70;
            double[][] expectedValue30;
            double[][] trainData70;
            double[][] dataToCheck30;

            data70 = new double[(int)(data.Length * 0.7)][];
            data30 = new double[data.Length - data70.Length][];

            for (int i = 0; i < (int)(data.Length * 0.7); i++)
            {
                data70[i] = new double[data[i].Length];
                for (int j = 0; j < data[0].Length; j++)
                {
                    data70[i][j] = data[i][j];
                }
            }

            for (int i = 0; i < data30.Length; i++)
            {
                data30[i] = new double[data[i].Length];
                for (int j = 0; j < data[0].Length; j++)
                {
                    data30[i][j] = data[data30.Length + i][j];
                }
            }

            trainData70 = new double[data70.Length][];
            expectedValue70 = new double[data70.Length][];

            for (int i = 0; i < data70.Length; i++)
            {
                trainData70[i] = new double[8];
                expectedValue70[i] = new double[2];
                for (int j = 0; j < 5; j++)
                {
                    trainData70[i][j] = data70[i][j];
                }
                for (int j = 0; j < 2; j++)
                {
                    expectedValue70[i][j] = data70[i][j + 3];
                }
            }

            dataToCheck30 = new double[data30.Length][];
            expectedValue30 = new double[data30.Length][];

            for (int i = 0; i < data30.Length; i++)
            {
                dataToCheck30[i] = new double[5];
                expectedValue30[i] = new double[2];
                for (int j = 0; j < 5; j++)
                {
                    dataToCheck30[i][j] = data30[i][j];
                }
                for (int j = 0; j < 2; j++)
                {
                    expectedValue30[i][j] = data30[i][j + 3];
                }
            }

            Network network = new Network(8, 4, 4, 2);

            network.PushExpectedValue(expectedValue70);
            network.Train(trainData70, 0.1);
            network.SaveWeightsToFile();

            Console.ReadKey();
        }
    }
}
