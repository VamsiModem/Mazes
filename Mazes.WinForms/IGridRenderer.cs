using SkiaSharp;

namespace Mazes.WinForms
{
    public interface IGridRenderer
    {
        void Render(SKSurface surface);
    }
}