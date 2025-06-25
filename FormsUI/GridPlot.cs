using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Drawing.Color;

namespace FormsUI;

internal class GridPlot
{
  private readonly Bitmap _bitmap;
  private readonly Graphics _graphics;
  private readonly Graphics _pictureBoxGraphics;
  private readonly PictureBox _pictureBox;

  private readonly Pen _linePen = new(Black, 1.0f);

  // Temporary fixed constant for grid size.
  private const double L = 0.25;

  public GridPlot(PictureBox pb)
  {
    _bitmap?.Dispose();
    _graphics?.Dispose();
    _pictureBoxGraphics?.Dispose();

    _pictureBox = pb;
    _bitmap = new(pb.Width, pb.Height);
    _graphics = Graphics.FromImage(_bitmap);
    _pictureBoxGraphics = pb.CreateGraphics();
    _graphics.SmoothingMode = SmoothingMode.Default;
    _pictureBoxGraphics.SmoothingMode = SmoothingMode.Default;

    PlotGrid();
  }

  private void PlotGrid()
  {
    _graphics.Clear(Gray);
    // Draw horizontal lines
    for (var y = 0; y < _bitmap.Height; y += 20)
    {
      _graphics.DrawLine(_linePen, 0, y, _bitmap.Width, y);
    }
    // Draw vertical lines
    for (var x = 0; x < _bitmap.Width; x += 20)
    {
      _graphics.DrawLine(_linePen, x, 0, x, _bitmap.Height);
    }
    // Refresh the PictureBox to show the grid
    _pictureBoxGraphics.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));
  }

  internal void Paint(object? sender, PaintEventArgs e)
  {
    e.Graphics.DrawImage(_bitmap, 0, 0);
  }
}
