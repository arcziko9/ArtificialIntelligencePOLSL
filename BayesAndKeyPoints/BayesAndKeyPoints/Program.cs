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
       
           Harris(@"D:\Politechnika\Semestr4\ArtificialIntelligencePOLSL\BayesAndKeyPoints\BayesAndKeyPoints\photo.png");
           Kmeans(@"D:\Politechnika\Semestr4\ArtificialIntelligencePOLSL\BayesAndKeyPoints\BayesAndKeyPoints\photo.png");

            var bayes = new Bayes();
            bayes.LoadData(@"D:\Politechnika\Semestr4\ArtificialIntelligencePOLSL\BayesAndKeyPoints\BayesAndKeyPoints\GoForAWalk.txt");
            bayes.Learn();
            bayes.Predict("Sunny", "Cool", "Normal", "Weak");
            bayes.Predict("Rain", "Hot", "Mild", "Strong");
        }

        static void Harris(string imagePath)
        {
            var srcImage = new Image<Gray, byte>(imagePath);
            var cornerImage = new Image<Gray, float>(srcImage.Size);
            var thresholdImage = new Image<Gray, byte>(srcImage.Size);
            CvInvoke.CornerHarris(srcImage, cornerImage, 5, 5, 0.01);
            CvInvoke.Threshold(cornerImage, thresholdImage, 0.0001, 255.0, Emgu.CV.CvEnum.ThresholdType.BinaryInv);
            thresholdImage.Save($"corner-{imagePath}");
        }

        static void Kmeans(string imagePath)
        {
            Bgr[] clusterColors = new Bgr[] {
                new Bgr(0,0,255),
                new Bgr(0, 255, 0),
                new Bgr(255, 100, 100),
                new Bgr(255,0,255),
                new Bgr(133,0,99),
                new Bgr(130,12,49),
                new Bgr(0, 255, 255)
            };

            var srcImage = new Image<Bgr, float>(imagePath);
            Matrix<float> samples = new Matrix<float>(srcImage.Rows * srcImage.Cols, 1, 3);
            Matrix<int> finalClusters = new Matrix<int>(srcImage.Rows * srcImage.Cols, 1);

            for (int y = 0; y < srcImage.Rows; y++)
            {
                for (int x = 0; x < srcImage.Cols; x++)
                {
                    samples.Data[y + x * srcImage.Rows, 0] = (float)srcImage[y, x].Blue;
                    samples.Data[y + x * srcImage.Rows, 1] = (float)srcImage[y, x].Green;
                    samples.Data[y + x * srcImage.Rows, 2] = (float)srcImage[y, x].Red;
                }
            }

            MCvTermCriteria term = new MCvTermCriteria(100, 0.5)
            {
                Type = TermCritType.Eps | TermCritType.Iter
            };

            int clusterCount = 5;
            int attempts = 5;
            CvInvoke.Kmeans(samples, clusterCount, finalClusters, term, attempts, KMeansInitType.PPCenters);

            Image<Bgr, float> outputImage = new Image<Bgr, float>(srcImage.Size);
            for (int y = 0; y < srcImage.Rows; y++)
            {
                for (int x = 0; x < srcImage.Cols; x++)
                {
                    PointF p = new PointF(x, y);
                    outputImage.Draw(new CircleF(p, 1.0f), clusterColors[finalClusters[y + x * srcImage.Rows, 0]], 1);
                }
            }

            outputImage.Save($"kmeans-{imagePath}");
            Console.ReadKey();
        }
    }
}