using LidarUtil;

namespace FormsUI
{
  public partial class Form1 : Form
  {
    private GridPlot _grid;

    public Form1()
    {
      InitializeComponent();
      _grid = new(GridPb, []);
    }

    private void GridPb_Paint(object sender, PaintEventArgs e)
    {
      _grid.Paint(sender, e);
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
      var segments = SegmentFetcher.ReceiveCompactSegments(port: 2115, numberOfSegments: 20).ToList();
      var singleFrameSegments = PointSweep.GetSegmentsOfASingleFrame(segments);
      var points = PointSweep.PointsFromSegments(singleFrameSegments);

      _grid.DrawGrid(points);
    }
  }
}
