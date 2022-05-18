using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP_Lab_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            FileViewer file = new FileViewer();
            int[,] graf = file.ReadFile();
            Weighted_graphs WeightedGra = new Weighted_graphs();

            int[,] Grapf = WeightedGra.CreateMatrix(file, graf);
            Console.WriteLine("Зважений граф:\n");
            WeightedGra.printMatrix(Grapf, file);

        }
    }
}
