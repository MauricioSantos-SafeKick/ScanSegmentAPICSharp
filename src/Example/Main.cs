//
// Copyright (c) 2024 SICK AG
// SPDX-License-Identifier: MIT
//
using Compact;
using System.Net;
using System.Net.Sockets;
using LidarUtil;
using static LidarUtil.SegmentFetcher;

static class Example
{
  

  /// <summary>
  /// An example how to receive and parse Compact telegrams from a SICK sensor.
  /// </summary>
  public static void Main()
  {
    var segments = ReceiveCompactSegments(port: 2115, numberOfSegments: 20).ToList();

    var singleFrameSegments = PointSweep.GetSegmentsOfASingleFrame(segments);
    PointSweep.PrintAllPoints(singleFrameSegments);

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
}
