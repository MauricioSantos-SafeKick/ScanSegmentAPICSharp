using LidarUtil;

namespace FormsUI
{
  public partial class Form1 : Form
  {
    private readonly GridPlot _grid;

    public Form1()
    {
      InitializeComponent();
      _grid = new(GridPb, []);
    }

    private void GridPb_Paint(object sender, PaintEventArgs e)
    {
      _grid.Paint(sender, e);
    }

    private void RefreshButton_Click(object sender, EventArgs e) => FetchAndDraw();

    private void RunStopButton_Click(object sender, EventArgs e)
    {
      RunStopButton.Text = RunStopButton.Text == "Run" ? "Stop" : "Run";
      if (RunStopButton.Text == "Stop")
        GridTimer.Start();
      else
        GridTimer.Stop();
    }

    /// <summary>
    /// Fetches data from the UDP, treats them and draws them on the grid.
    /// </summary>
    private void FetchAndDraw()
    {
      var segments = SegmentFetcher.ReceiveCompactSegments(port: 2115, numberOfSegments: 20).ToList();
      var singleFrameSegments = PointSweep.GetSegmentsOfASingleFrame(segments);
      var points = PointSweep.PointsFromSegments(singleFrameSegments);
      _grid.DrawGrid(points);
    }

    private void GridTimer_Tick(object sender, EventArgs e) => FetchAndDraw();
  }
}
