using System.Drawing;
using System.Security.AccessControl;
using static LidarUtil.Constants;
using static LidarUtil.Conversions;

namespace LidarUtil;
using Compact;

public static class PointSweep
{
  public static void PrintSameAnglePoint(List<CompactSegment> segments)
  {
    for (var i = 0; i < segments.Count; i++)
    {
      // 10 segments make a frame
      if (i % 10 != 0)
        continue;

      var theta = RawThetaToRads(segments[i].Modules[0].Beams[0][0].Theta);
      var r = segments[i].Modules[0].Beams[0][0].Echoes[0].Distance;

      Console.WriteLine(new PolarPoint(r, theta));
    }
  }

  public static void PrintAllPoints(List<CompactSegment> segments)
  {
    foreach (var point in 
             from segment in segments 
             from module in segment.Modules 
             from beam in module.Beams 
             let theta = RawThetaToRads(beam[0].Theta)
             let r = beam[0].Echoes[0].Distance 
             select new PolarPoint(r, theta))

      Console.WriteLine(point);
  }

  public static List<CompactSegment> GetSegmentsOfASingleFrame(List<CompactSegment> segments)
  {
    if (!FindStartOfFrame(segments, out var i))
      throw new("Unable to find start of frame.");

    if (!FindEndOfFrame(segments.Skip(i).ToList(), out var j))
      throw new("Unable to find end of frame.");

    return segments.Skip(i).Take(j).ToList();
  }

  private static bool FindStartOfFrame(List<CompactSegment> segments, out int i)
  {
    i = segments.FindIndex(s => Math.Abs(s.Modules[0].MetaData.ThetaStart[0] - -ThetaMax) < 1e-3);
    return i != -1;
  }

  private static bool FindEndOfFrame(List<CompactSegment> segments, out int i)
  {
    i = segments.FindIndex(s => Math.Abs(s.Modules[0].MetaData.ThetaStop[0] - ThetaMax) < 1e-3);
    return i != -1;
  }
}
