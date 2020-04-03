using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_NN_Classification
{
    class Program
    {
        static void Main(string[] args)
        {
        string pathData = @"D:\Politechnika\Semestr4\ArtificialIntelligencePOLSL\k-NN Classification\k-NN Classification\bazaIris.txt";
        string pathParameter = @"D:\Politechnika\Semestr4\ArtificialIntelligencePOLSL\k-NN Classification\k-NN Classification\parameter.txt";
        Classifier classifier = new Classifier(pathData, pathParameter);
        Console.WriteLine(classifier.Solve());
        Console.ReadKey();
        }
    }
}
