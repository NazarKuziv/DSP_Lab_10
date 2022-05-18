using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP_Lab_10
{
    internal class Weighted_graphs
    {
        private int[,] matrix = null;
        private int n = 0;
        private int m = 0;
        public int GetM() { return this.m; }
        public int GetN() { return this.n; }
        public int[,] GetMatrix(){return this.matrix;}

        
        public int[,] CreateMatrix(FileViewer file, int[,] graf)
        {
            this.n = file.GetN();
            this.m = file.GetM();

            int iterator = 0;
            int In = int.MaxValue;

            int[] N = OrderN(n);
            int[,] matrix = new int[n + 1, n + 1];           
            bool isEqual = false;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    isEqual = false;
                    
                    int[] V = { N[i], N[j] };
                    for (int k = 1; k <= m; k++)
                    {
                        if ((V[0] == graf[k, 0]) && (V[1] == graf[k, 1]))
                        {
                            isEqual = true;
                            iterator = k;
                            break;
                        }
                    }
                    if (isEqual)
                    {
                        matrix[i, j] = graf[iterator, 2];
                    }
                    else if (i == j)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = In;
                    }
                }
            }
            this.matrix = graf;
            return matrix;
        }
        public int[] OrderN(int n)
        {
            int[] order = new int[n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                order[i] = i;
            }
            return order;
        }
        public void printMatrix(int[,] matrix, FileViewer file)
        {
            Console.Write("   |");
            for (int j = 1; j < file.GetN() + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 1; i < file.GetN() + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < file.GetN() + 1; j++)
                {
                    if (matrix[i, j] == int.MaxValue)
                    {
                        Console.Write("   |");
                    }
                    else
                        Console.Write($"{matrix[i, j],2} |");
                }
                Console.WriteLine();
            }
        }
    }
}
