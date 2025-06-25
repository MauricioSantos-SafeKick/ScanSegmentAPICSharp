using LidarUtil;
using Compact;

namespace FormsUI
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();
      var segments = SegmentFetcher.ReceiveCompactSegments(port: 2115, numberOfSegments: 20).ToList();
      var singleFrameSegments = PointSweep.GetSegmentsOfASingleFrame(segments);
      var points = PointSweep.PointsFromSegments(singleFrameSegments);

      Application.Run(new Form1(points));
    }
  }
}
