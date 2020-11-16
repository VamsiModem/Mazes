using Mazes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mazes.Algorithms
{
    public class BinaryTreeAlgorithm : IAlgorithm
    {
        private readonly IGrid _grid;

        public BinaryTreeAlgorithm(IGrid grid)
        {
            _grid = grid;
        }
        public void Run()
        {
            foreach(var cell in _grid.Cells())
            {
                var neighbours = new List<ICell>();
                var random = new Random();
                if (cell.North is ICell) neighbours.Add(cell.North);
                if (cell.East is ICell) neighbours.Add(cell.East);
                var index = random.Next(neighbours.Count);
                if (index > neighbours.Count - 1) continue;
                var neighbour = neighbours[index];
                cell.Link(neighbour);
            }
        }
    }
}
