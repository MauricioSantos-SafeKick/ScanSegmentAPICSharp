namespace LidarUtil;

internal class PolarPoint
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

    if (theta < -2 * Math.PI || theta > 2 * Math.PI)
      throw new("Theta must be between -2π and 2π.");

    R = r;
    Theta = theta;
  }
}
