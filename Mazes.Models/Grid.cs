using System;
using System.Collections.Generic;
using System.Text;

namespace Mazes.Models
{
    public class Grid : IGrid
    {
        private Cell[,] _grid;
        public Grid(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;
            _grid = new Cell[rows, cols];
            PrepareGrid();
            ConfigureCells();
        }
        public ICell this[int row, int col]{
            get{
                if(row >= 0 && row < Rows && col >= 0 && col < Columns)
                {
                    return _grid[row, col];
                }
                return null;
            }
        }
        public int Rows { get; }
        public int Columns { get; }
        public ICell RandomCell
        {
            get
            {
                Random random = new Random();
                int randomRow = random.Next(Rows);
                int randomCol = random.Next(Columns);
                return _grid[randomRow, randomCol];
            }
        }
        public int Size => Rows * Columns;

        private void PrepareGrid()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    _grid[row, col] = new Cell(row, col);
                }
            }
        }
        public IEnumerable<ICell> Cells()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    yield return _grid[row, col];
                }
            }
        }

        public IEnumerable<ICell[]> Row()
        {
            for (int row = 0; row < Rows; row++)
            {
                List<ICell> cells = new List<ICell>();
                for (int col = 0; col < Columns; col++)
                {
                    cells.Add(_grid[row, col]);
                }
                yield return cells.ToArray();
            }
        }
        private void ConfigureCells()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    var cell = _grid[row, col];
                    cell.North = row - 1 < 0 ? null : _grid[row - 1, col];
                    cell.South = row + 1 >= Rows ? null : _grid[row + 1, col];
                    cell.East = col + 1 >= Columns ? null : _grid[row, col + 1];
                    cell.West = col - 1 < 0 ? null : _grid[row, col - 1]; ;
                }
            }
        }

        public override string ToString()
        {
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            var output = new StringBuilder("╔");
            for (var i = 0; i < Columns; i++)
            {
                if(i == Columns - 1)
                    output.Append("═══╗");
                else
                    output.Append("═══╦");
            }
            output.AppendLine();
            for(int col = 0; col < Columns; col++)
            {
                var top = "║";
                var bottom = "╬";
                for (int row = 0; row < Rows; row++)
                {
                    const string body = "   ";
                    var cell = _grid[row, col];
                    var east = cell.IsLinked(cell.East) ? " " : "║";
                    top += body + east;
                    var south = cell.IsLinked(cell.South) ? "   " : "═══";
                    string corner = "╬";
                    if (col == Columns - 1 && row == 0)
                        bottom = "╚";
                    else if (row == 0)
                        bottom = "╠";

                    if (col == Columns - 1 && row < Rows - 1)
                        corner = "╩";
                    else if(col == Columns - 1)
                        corner = "╝";
                    else if(row == Rows - 1)
                        corner = "╣";
                    bottom += south + corner;
                }
                output.AppendLine(top);
                output.AppendLine(bottom);
            }
            return output.ToString();
        }
    }
}
