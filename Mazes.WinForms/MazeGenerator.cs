using Mazes.Algorithms;
using Mazes.Models;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Drawing;
using System.Windows.Forms;

namespace Mazes.WinForms
{
    public class 
        MazeGenerator : Form
    {
        public MazeGenerator()
        {
            Text = "Maze Generator";
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1547, 897);
            var splitContainer = new SplitContainer()
            {
                FixedPanel = FixedPanel.Panel1,
                SplitterDistance = 600,
                Dock = DockStyle.Fill,
                IsSplitterFixed = true
            };
            var skiaView = new SKControl()
            {
                Dock = DockStyle.Fill
            };
            //skiaView.MouseDown += DoMouseClick;
            //skiaView.MouseMove += DoMouseClick;
            //skiaView.Resize += (s, e) => _game.SetSize(skiaView.Width, skiaView.Height);
            
            skiaView.PaintSurface += (s, e) => {
                var grid = new Grid(40,40);
                new BinaryTreeAlgorithm(grid).Run();
                new GridRenderer(grid).Render(e.Surface);
            };
            //splitContainer.Panel1.Controls.Add(buttonPanel);
           
            splitContainer.Panel2.Controls.Add(skiaView);
            splitContainer.Panel2.Padding = new Padding(5);
            Controls.Add(splitContainer);
        }

    }
}
