using LidarUtil;

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
      // Get points
      var points = new List<XyPoint>
      {
        new(0, 0),
        new(1, 1),
        new(2, 2),
        new(3, 3),
        new(4, 4),
        new(5, 5)
      };
      Application.Run(new Form1(points));
    }
  }
}
