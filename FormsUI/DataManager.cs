using System;
using Compact;
using LidarUtil;

namespace FormsUI
{
  internal class DataManager
  {
    /// <summary>
    /// Fetches data from the UDP, treats them and draws them on the grid.
    /// </summary>
    internal List<XyPoint> FetchRawData()
    {
      var ret = new List<XyPoint>();
      List<CompactSegment> segments;

      try
      {
        segments = SegmentFetcher.ReceiveCompactSegments(port: 2115, numberOfSegments: 20).ToList();
      }
      catch (Exception e)
      {
        MessageBox.Show("Unable to fetch data. Details: \n" + e.Message);
        return ret;
      }

      var singleFrameSegments = PointSweep.GetSegmentsOfASingleFrame(segments);
      ret = PointSweep.PointsFromSegments(singleFrameSegments);

      return ret;
    }

    internal List<XyPoint> FetchSmoothedData(int period)
    {
      if (period is < 1 or > 10)
      {
        MessageBox.Show("Period must be between 1 and 100.");
        return [];
      }

      var points = FetchRawData();
      var averageList = new List<XyPoint>(period);

      for (var i = 0; i < points.Count; i++)
      {
        averageList.Add(points[i]);
        if (averageList.Count > period)
          averageList.RemoveAt(0);


        var avgX = averageList.Average(p => p.X);
        var avgY = averageList.Average(p => p.Y);
        points[i] = new(avgX, avgY);
      }

      return points;
    }
  }
}
