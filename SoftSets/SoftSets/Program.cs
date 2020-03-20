using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trousers:");
            var personA = new Trousers(Trousers.Parameters.Jeans, Trousers.Parameters.Modern, Trousers.Parameters.Zipper);
            var personB = new Trousers(Trousers.Parameters.Jeans, Trousers.Parameters.Classic, Trousers.Parameters.Navy, Trousers.Parameters.Button);
            Console.WriteLine($"Person A wants:\n{personA.ToString()}");
            Console.WriteLine($"Person B wants:\n{personB.ToString()}");

            Console.WriteLine("\nVegetables:");
            var personC = new Vegetables(Vegetables.Parameters.Fresh, Vegetables.Parameters.Spicy, Vegetables.Parameters.Red);
            var personD = new Vegetables(Vegetables.Parameters.Fresh, Vegetables.Parameters.Tropical);
            Console.WriteLine($"Person C wants:\n{personC.ToString()}");
            Console.WriteLine($"Person D wants:\n{personD.ToString()}");

            Console.ReadKey();
        }   
    }
}
