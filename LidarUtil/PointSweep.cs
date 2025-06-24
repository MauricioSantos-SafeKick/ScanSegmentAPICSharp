using System.Drawing;
using System.Security.AccessControl;

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

      var theta = Conversions.RawThetaToRads(segments[i].Modules[0].Beams[0][0].Theta);
      var r = segments[i].Modules[0].Beams[0][0].Echoes[0].Distance;

      Console.WriteLine(new PolarPoint(r, theta));
    }
  }

}
