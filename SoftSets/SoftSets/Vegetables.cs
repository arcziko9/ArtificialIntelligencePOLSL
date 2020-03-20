using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSets
{
    class Vegetables
    {
        private Dictionary<string, int> scores;
        public enum Parameters
        {
            Fresh,
            Frozen,
            Spicy,
            Sweet,
            Green,
            Red,
            Local,
            Tropical,
            Leafy,
            Tuberous
        }

        private readonly Dictionary<string, List<Parameters>> types = new Dictionary<string, List<Parameters>>()
        {
            {"Peppers",new List<Parameters>() {Parameters.Fresh, Parameters.Sweet, Parameters.Green, Parameters.Red, Parameters.Spicy} },
            {"Apple", new List<Parameters>() {Parameters.Fresh, Parameters.Sweet, Parameters.Red } },
            {"Spinach", new List<Parameters>() {Parameters.Frozen, Parameters.Green} },
            {"Parsley", new List<Parameters>() {Parameters.Fresh, Parameters.Green} },
            {"Pitaya", new List<Parameters>() {Parameters.Fresh, Parameters.Sweet, Parameters.Red, Parameters.Tropical} }
        };

        private Dictionary<string, int> InitializeScore()
        {
            var scores = new Dictionary<string, int>();
            foreach (var item in types)
            {
                scores.Add(item.Key, 0);
            }
            return scores;
        }

        private Dictionary<string, int> PickBest()
        {
            int bestScore = 0;
            var best = new Dictionary<string, int>();
            foreach (var item in scores)
            {
                if(item.Value > bestScore)
                {
                    bestScore = item.Value;
                    best.Clear();
                    best.Add(item.Key, item.Value);
                }
                else if(item.Value == bestScore)
                {
                    best.Add(item.Key, item.Value);
                }
            }
            return best;
        }


        public Vegetables(params Parameters[] parameters)
        {
            scores = InitializeScore();
            foreach (var parameter in parameters)
            {
                foreach (var type in types)
                {
                    if (type.Value.Contains(parameter))
                    {
                        scores[type.Key]++;
                    }
                }
            }
        }

        public override string ToString()
        {
            string val = "";
            var best = PickBest();
            foreach (var item in best)
            {
                val += $"{item.Key} - {item.Value}\n";
            }

            return val;
        }
    }
}
