using LidarUtil;

namespace FormsUI
{
  public partial class Form1 : Form
  {
    private GridPlot _grid;

    public Form1(List<XyPoint> points)
    {
      InitializeComponent();
      _grid = new(GridPb, points);
    }

    private void GridPb_Paint(object sender, PaintEventArgs e)
    {
      _grid.Paint(sender, e);
    }
  }
}
