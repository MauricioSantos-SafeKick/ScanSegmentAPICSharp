//
// Copyright (c) 2024 SICK AG
// SPDX-License-Identifier: MIT
//
using Compact;
using System.Net;
using System.Net.Sockets;
using LidarUtil;

static class Example
{
  /// <summary>
  /// Receive `numberOfSegments` Compact segments on the given UDP `port` and convert the received data into CompactSegment objects.
  /// </summary>
  /// <remarks>
  /// This example does not include exception handling. Any exceptions will be reported to the console and the program will exit.
  /// </remarks>
  /// <param name="port">Port for incoming data.</param>
  /// <param name="numberOfSegments">The number of segments to read.</param>
  /// <returns>An enumerable CompactSegment objects</returns>
  private static IEnumerable<CompactSegment> ReceiveCompactSegments(int port, int numberOfSegments)
  {
    using var udpClient = new UdpClient(port);

    Console.WriteLine($"Waiting to receive {numberOfSegments} Compact segments on UDP port {port}.");
    Console.WriteLine("Press Ctrl+C to cancel.");

    var ep = new IPEndPoint(IPAddress.Any, port);
    for (var i = 0; i < numberOfSegments; i++)
    {
      // Receive UDP packet and convert to compact frame
      var receivedData = udpClient.Receive(ref ep);
      Console.WriteLine($"Received segment {i + 1}.");
      yield return CompactDeserializer.Convert(receivedData);
    }
  }

  /// <summary>
  /// An example how to receive and parse Compact telegrams from a SICK sensor.
  /// </summary>
  public static void Main()
  {
    var segments = ReceiveCompactSegments(port: 2115, numberOfSegments: 200).ToList();
    PointSweep.PrintSameAnglePoint(segments);

    //// Receive and collect 20 Compact segments
    //var i = FindStartOfFrame(segments);
    //var singleFrameSegments = segments.Skip(i).Take(10).ToList();
    //var points = new List<PolarPoint>();

    //foreach (var segment in segments)
    //{
    //  try
    //  {
    //    var startAngle = segment.Modules[0].MetaData.ThetaStart[0];
    //    foreach (var module in segment.Modules)
    //      foreach (var beam in module.Beams)
    //      {
    //        var theta = (beam[0].Theta - 16387.0) / 5215.0;
    //        var r = beam[0].Echoes[0].Distance;
    //        var point = new PolarPoint(r, theta);
    //        Console.WriteLine(point);
    //      }
    //    var endAngle = segment.Modules.Last().MetaData.ThetaStop[0];
    //    var frameNumber = segment.Modules[0].MetaData.FrameNumber;
    //    var segmentCounter = segment.Modules[0].MetaData.SegmentCounter;
    //    var distance = segment.Modules[0].Beams[6][0].Echoes[0].Distance; // Distance of the first echo of the 7th beam in the first layer of the first module
    //  }
    //  catch (Exception e)
    //  {
    //    Console.WriteLine(e);
    //  }

    //}
  }

  static int FindStartOfFrame(List<CompactSegment> segments)
  {
    return segments.FindIndex(s => (Math.Abs(s.Modules[0].MetaData.ThetaStart[0] - (-2.40855)) < 1e-3));
  }
}
