using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSets
{
    class Trousers
    {
        private Dictionary<string, int> scores;
        public enum Parameters
        {
            Expensive,
            Cheap,
            Jeans,
            Sweatpants,
            Classic,
            Fit,
            Navy,
            Black,
            Button,
            Zipper,
            Modern
        }

        private Dictionary<string, List<Parameters>> types = new Dictionary<string, List<Parameters>>()
        {
            {"Classic", new List<Parameters>() {Parameters.Classic, Parameters.Jeans, Parameters.Navy, Parameters.Expensive } },
            {"Cool Jeans", new List<Parameters>() {Parameters.Jeans, Parameters.Black, Parameters.Zipper, Parameters.Modern } },
            {"Random Trousers", new List<Parameters>() {Parameters.Fit, Parameters.Cheap, Parameters.Button, Parameters.Modern } },
            {"Old School", new List<Parameters>() {Parameters.Classic, Parameters.Black, Parameters.Sweatpants} } 
        };

        private Dictionary<string, int> InitalizeScore()
        {
            var scores = new Dictionary<string, int>();
            foreach (var item in types)
            {
                scores.Add(item.Key, 0);
            }
            return scores;
        }

        public Trousers(params Parameters[] parameters)
        {
            scores = InitalizeScore();
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

        public override string ToString()
        {
            string value = "";
            var best = PickBest();
            foreach (var item in best)
            {
                value += $"{item.Key} - {item.Value}\n";
            }

            return value;
        }
    }
}
