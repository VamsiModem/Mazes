using Mazes.Algorithms;
using Mazes.Models;
using System;
using System.Text;

namespace Mazes.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(10,10);
            new BinaryTreeAlgorithm(grid).Run();
            System.Console.WriteLine(grid.ToString());
            System.Console.ReadLine();
        }
    }
}
