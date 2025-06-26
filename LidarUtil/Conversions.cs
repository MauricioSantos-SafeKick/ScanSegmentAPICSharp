namespace LidarUtil;

internal static class Conversions
{
  public static double RawThetaToRads(double rawTheta) => (rawTheta - 16384.0) / 5215;

}
