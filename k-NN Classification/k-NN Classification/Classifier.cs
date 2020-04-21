using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_NN_Classification
{
    class Classifier
    {
        private string pathData { get; set; }
        private string pathParameter { get; set; }
        private InputCollection inputCollection = new InputCollection();
        private List<double> objectToClassifiy = new List<double>();

        public Classifier(string pathData, string pathParameter)
        {
            this.pathData = pathData;
            this.pathParameter = pathParameter;
            LoadData(pathData);
            LoadParameter();
        }

        public string Solve()
        {
            List<Object> objects = inputCollection.GetObjects();
            List<KeyVal<string, double>> vector = new List<KeyVal<string, double>>();
            for (int i = 0; i < objects.Count; i++)
            {
                string name = objects[i].name;
                double value = GetLenght(objectToClassifiy, objects[i].parameters);
                KeyVal<string, double> keyval = new KeyVal<string, double>(name, value);
                vector.Add(keyval);
            }

            var result = vector.OrderBy(x => x.Value).Take((int)(vector.Count() * 0.1)).ToList();

            return GetType(result);
        }

        private void LoadData(string path)
        {
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                inputCollection.AddObject(tmp.ToList());
            }
        }

        private void LoadParameter()
        {
            string data = File.ReadAllText(pathParameter);
            List<string> tmp = data.Split(',').ToList();

            for (int i = 0; i < tmp.Count; i++)
            {
                objectToClassifiy.Add(Convert.ToDouble(tmp[i]));
            }
        }

        private double GetLenght(List<double> x, List<double> y)
        {
            double result = 0;
            for (int i = 0; i < x.Count; i++)
            {
                result += Math.Pow(x[i] - y[i], 2);
            }

            return Math.Sqrt(result);
        }

        private string GetType(List<KeyVal<string, double>> data)
        {
            List<string> types = new List<string>();
            List<int> count = new List<int>();
            foreach (var item in data)
            {
                if (!types.Contains(item.Name))
                {
                    types.Add(item.Name);
                    count.Add(1);
                }
                else
                {
                    count[types.IndexOf(item.Name)] += 1;
                }
            }
            return types[count.IndexOf(count.Max())];
        }
    }
}
