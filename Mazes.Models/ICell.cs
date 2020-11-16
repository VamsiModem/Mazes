using System.Collections.Generic;

namespace Mazes.Models
{
    public interface ICell
    {
        int Column { get; }
        int Row { get; }
        ICell East { get; set; }
        ICell North { get; set; }
        ICell South { get; set; }
        ICell West { get; set; }
        HashSet<ICell> Links { get; }
        List<ICell> GetNeighbours();
        bool IsLinked(ICell cell);
        void Link(ICell cell, bool biDirectional = true);
        void Unlink(ICell cell, bool biDirectional = true);
    }
}