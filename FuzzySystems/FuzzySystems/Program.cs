﻿using System;

namespace FuzzySystems
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"bazaIris.txt";

            double[][] data;
            DataFlowers dataFlowers = new DataFlowers();
            Normalization normalization = new Normalization();

            data = dataFlowers.ReadData(path);

            for (int i = 0; i < 3; i++)
            {
                data = normalization.DoNormalize(data, i, 1, 0);
            }

            Logic logic = new Logic();
            logic.FuzzyLogic(data);
            Console.ReadKey();

        }

    }
}

