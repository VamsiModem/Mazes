using Mazes.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mazes.WinForms
{
    public class GridRenderer : IGridRenderer
    {
        private readonly IGrid _grid;
        public GridRenderer(IGrid grid)
        {
            _grid = grid;
        }
        public void Render(SKSurface surface)
        {
            const int CellSize = 10;
            int width = _grid.Rows * CellSize;
            int height = _grid.Columns * CellSize;

            SKCanvas canvas = surface.Canvas;
            canvas.Translate(1, 1);
            canvas.Clear(SKColors.White);
            canvas.ClipRect(new SKRect(0, 0, width + 10, height + 10), SKClipOperation.Intersect);
            using var grid = new SKPaint
            {
                Color = SKColors.Gray,
                StrokeWidth = 2,
                Style = SKPaintStyle.Stroke
            };
            foreach (var cell in _grid.Cells())
            {
                int x1 = CellSize * cell.Column;
                int y1 = CellSize * cell.Row;
                int x2 = CellSize * (cell.Column + 1);
                int y2 = CellSize * (cell.Row + 1);

                if (cell.North == null)
                    canvas.DrawLine(x1, y1, x2, y1, grid);
                if (cell.West == null)
                    canvas.DrawLine(x1, y1, x1, y2, grid);
                if (!cell.IsLinked(cell.East))
                    canvas.DrawLine(x2, y1, x2, y2, grid);
                if (!cell.IsLinked(cell.South))
                    canvas.DrawLine(x1, y2, x2, y2, grid);
            }
        }
    }
}
