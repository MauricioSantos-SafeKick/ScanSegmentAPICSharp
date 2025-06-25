using System;
using Compact;
using LidarUtil;

namespace FormsUI
{
  internal class DataManager
  {
    internal enum DataFormat
    {
      Raw,
      Smoothed
    }

    internal int SmoothingPeriod { get; set; } = 5; // Default smoothing period

    internal List<XyPoint> FetchData(DataFormat dataFormat)
    {
      return dataFormat switch
      {
        DataFormat.Raw => FetchRawData(),
        DataFormat.Smoothed => FetchSmoothedData(),
        _ => throw new ArgumentOutOfRangeException(nameof(dataFormat), dataFormat, null)
      };
    }

    /// <summary>
    /// Fetches data from the UDP, treats them and draws them on the grid.
    /// </summary>
    internal List<XyPoint> FetchRawData()
    {
      var segments = SegmentFetcher.ReceiveCompactSegments(port: 2115, numberOfSegments: 20).ToList();
      var singleFrameSegments = PointSweep.GetSegmentsOfASingleFrame(segments);
      var ret = PointSweep.PointsFromSegments(singleFrameSegments);

      return ret;
    }

    internal List<XyPoint> FetchSmoothedData()
    {
      if (SmoothingPeriod is < 1 or > 10)
        throw new("Period must be between 1 and 100.");

      var points = FetchRawData();
      var averageList = new List<XyPoint>(SmoothingPeriod);

      for (var i = 0; i < points.Count; i++)
      {
        averageList.Add(points[i]);
        if (averageList.Count > SmoothingPeriod)
          averageList.RemoveAt(0);


        var avgX = averageList.Average(p => p.X);
        var avgY = averageList.Average(p => p.Y);
        points[i] = new(avgX, avgY);
      }

      return points;
    }
  }
}
