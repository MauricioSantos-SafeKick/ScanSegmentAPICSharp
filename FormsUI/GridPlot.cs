using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LidarUtil;
using Microsoft.VisualBasic.CompilerServices;
using static System.Drawing.Color;

namespace FormsUI;

internal class GridPlot
{
  private readonly Bitmap _bitmap;
  private readonly Graphics _graphics;
  private readonly Graphics _pictureBoxGraphics;
  private readonly PictureBox _pictureBox;

  private readonly Pen _gridPen = new(Gray, 1.0f);
  private readonly Pen _linePen = new(Black, 1.0f);

  // Temporary fixed constant for grid size.
  private const double L = 0.25;
  private double _pixelsPerX;
  private double _pixelsPerY;

  public GridPlot(PictureBox pb, List<XyPoint> points)
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

    _pixelsPerX = _bitmap.Width / 40;
    _pixelsPerX = _bitmap.Height / 40;
    PlotGrid();
    PlotPoints(points);
  }

  private void PlotGrid()
  {
    _graphics.Clear(White);
    // Draw horizontal lines
    for (var y = 0; y < _bitmap.Height; y += 20)
    {
      _graphics.DrawLine(_gridPen, 0, y, _bitmap.Width, y);
    }
    // Draw vertical lines
    for (var x = 0; x < _bitmap.Width; x += 20)
    {
      _graphics.DrawLine(_gridPen, x, 0, x, _bitmap.Height);
    }
    // Refresh the PictureBox to show the grid
    _pictureBoxGraphics.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));
  }

  private void PlotPoints(List<XyPoint> points)
  {
    for (var i = 0; i < points.Count - 1; i++)
    {
      // Convert the point to pixel coordinates
      var x = (int)(points[i].X / L * 20 + _bitmap.Width / 2);
      var y = (int)(_bitmap.Height / 2 - points[i].Y / L * 20);


      // Draw the point
      //_graphics.FillEllipse(Black, x - 2, y - 2, 4, 4);
    }
    // Refresh the PictureBox to show the points
    _pictureBoxGraphics.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));
  }

  internal void Paint(object? sender, PaintEventArgs e)
  {
    e.Graphics.DrawImage(_bitmap, 0, 0);
  }
}
