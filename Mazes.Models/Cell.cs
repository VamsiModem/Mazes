using System;
using System.Collections.Generic;

namespace Mazes.Models
{
    public class Cell : ICell
    {
        public HashSet<ICell> Links { get; }
        public int Row { get;}
        public int Column { get;}
        public ICell North { get; set; }
        public ICell South { get; set; }
        public ICell East { get; set; }
        public ICell West { get; set; }
        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
            Links = new HashSet<ICell>();
        }

        public void Link(ICell cell, bool biDirectional = true)
        {
            if (cell is null) return;
            if (!Links.Contains(cell))
                Links.Add(cell);
            if (biDirectional)
                cell.Link(this, false);
        }
        public void Unlink(ICell cell, bool biDirectional = true)
        {
            if (cell is null) return;
            if (!Links.Contains(cell))
                Links.Remove(cell);
            if (biDirectional)
                cell.Unlink(this, false);
        }

        public bool IsLinked(ICell cell)
        {
            return Links.Contains(cell);
        }

        public List<ICell> GetNeighbours()
        {
            var neighbours = new List<ICell>();
            if (North is ICell) neighbours.Add(North);
            if (South is ICell) neighbours.Add(South);
            if (East is ICell) neighbours.Add(East);
            if (West is ICell) neighbours.Add(West);
            return neighbours;
        }
    }
}
