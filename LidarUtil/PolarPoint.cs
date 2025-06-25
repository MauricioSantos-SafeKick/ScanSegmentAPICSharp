using Compact;
using static System.Math;
using static LidarUtil.Conversions;

namespace LidarUtil;

public class PolarPoint
{
  public double R { get; set; }
  /// <summary>
  /// radians
  /// </summary>
  public double Theta { get; set; }

  public PolarPoint(double r, double theta)
  {
    if (r < 0)
      throw new("R must be greater than zero.");

    if (theta is < -2 * PI or > 2 * PI)
      throw new("Theta must be between -2π and 2π.");

    R = r;
    Theta = theta;
  }

  public static PolarPoint FromBeam(Beam beam)
  {
    var theta = RawThetaToRads(beam.Theta);
    var r = beam.Echoes[0].Distance;

    return new(r, theta);
  }

  public override string ToString() => $"r = {R} mm, theta = {Theta:F2} rad";
}
