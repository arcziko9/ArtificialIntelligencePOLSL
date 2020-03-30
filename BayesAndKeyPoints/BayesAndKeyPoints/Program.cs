using System;
using System.Drawing;
using BayesAndKeyPoints;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Graphics_and_Detectors
{
    class Program
    {
        static void Main(string[] args)
        {
     

            var bayes = new Bayes();
            bayes.LoadData(@"D:\Politechnika\Semestr4\ArtificialIntelligencePOLSL\BayesAndKeyPoints\BayesAndKeyPoints\GoForAWalk.txt");
            bayes.Learn();
            bayes.Predict("Sunny", "Cool", "Weak");
            bayes.Predict("Rainy", "Hot", "Strong");

            var keyPoints = new KeyPoints();
            keyPoints.AddMask();
            keyPoints.PotencialPoints(5000);

            Console.ReadKey();
        }
 
    }
}