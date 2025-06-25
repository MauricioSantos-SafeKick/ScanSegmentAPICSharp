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

    //internal List<XyPoint> FetchSmoothedData()
    //{
    //  var points = FetchRawData();


    //}
  }
}
