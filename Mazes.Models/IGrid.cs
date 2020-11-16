using System.Collections.Generic;

namespace Mazes.Models
{
    public interface IGrid
    {
        int Columns { get; }
        ICell RandomCell { get; }
        int Rows { get; }
        int Size { get; }

        IEnumerable<ICell> Cells();
        IEnumerable<ICell[]> Row();
    }
}