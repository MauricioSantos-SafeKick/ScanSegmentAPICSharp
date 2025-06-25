using static System.Math;

namespace LidarUtil;

public class XyPoint
{
    // create x and y points
    public double X { get; set; }
    public double Y { get; set; }

    public XyPoint(double x, double y)
    {
      X = x;
      Y = y;
    }

    public static XyPoint FromPolar(double r, double theta)
    {
      var x = r * Cos(theta);
      var y = r * Sin(theta);

      return new(x, y);
    }

    public override string ToString() => $"x = {X:F2}, y = {Y:F2}";
}


