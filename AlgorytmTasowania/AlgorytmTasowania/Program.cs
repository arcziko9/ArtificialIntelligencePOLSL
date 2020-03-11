using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorytmTasowania
{
    class Program
    {
        static List<int> Shuffle(List<int> list)
        {
            Random random = new Random();
            List<int> newList = new List<int>();
            while (list.Count() > 0)
            {
                int randomIndex = random.Next(0, list.Count());
                newList.Add(list[randomIndex]);
                list.RemoveAt(randomIndex);
            }
            return newList;
        }
        static void Main(string[] args)
        {             
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("Before shuffle: ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nAfter suffle: ");
            List<int> shuffleList = Shuffle(list);
            foreach (var item in shuffleList)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}