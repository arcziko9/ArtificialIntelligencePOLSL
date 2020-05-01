using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"bazaIris.txt";

            string[] lines = File.ReadAllLines(path);

            double[][] data = new double[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(',');

                data[i] = new double[temp.Length + 2];

                for (int j = 0; j < temp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(temp[j].Replace('.', ','));
                }

                for (int k = 0; k < 3; k++)
                {
                    if (temp[4] == "Iris-setosa")
                    {
                        data[i][4] = 0;
                        data[i][5] = 0;
                        data[i][6] = 1;
                    }
                    else if (temp[4] == "Iris-versicolor")
                    {
                        data[i][4] = 0;
                        data[i][5] = 1;
                        data[i][6] = 0;
                    }
                    else if (temp[4] == "Iris-virginica")
                    {
                        data[i][4] = 1;
                        data[i][5] = 0;
                        data[i][6] = 0;
                    }
                }

            }

            Normalization normalization = new Normalization();

            for (int i = 0; i < 3; i++)
            {
                data = normalization.DoNormalize(data, i, 1, 0);
            }

            data = normalization.Shuffle(data);


            double[][] expectedValue = new double[data.Length][];
            double[][] trainData = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                trainData[i] = new double[4];
                expectedValue[i] = new double[3];
                for (int j = 0; j < 4; j++)
                {
                    trainData[i][j] = data[i][j];
                }
                for (int j = 0; j < 3; j++)
                {
                    expectedValue[i][j] = data[i][j + 4];
                }
            }


            Network network = new Network(4, 2, 4, 3);
            network.PushExpectedValue(expectedValue);

            network.Train(trainData, 0.15);

            double[] whatFlower = { 5.9, 3.0, 5.1, 1.8 };
            network.PushInputValues(whatFlower);

            List<double> output = network.GetOutputs();
            int index = output.IndexOf(output.Max());

            if (index == 0) Console.Write("Iris-setosa");
            else if (index == 1) Console.Write("Iris-versicolor");
            else if (index == 2) Console.Write("Iris-virginica");


            Console.ReadKey();
        }
    }
}
