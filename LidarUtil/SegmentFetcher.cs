using System.Net;
using System.Net.Sockets;
using Compact;

namespace LidarUtil;

public class SegmentFetcher
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
  public static IEnumerable<CompactSegment> ReceiveCompactSegments(int port, int numberOfSegments)
  {
    using var udpClient = new UdpClient(port);
    
    var ep = new IPEndPoint(IPAddress.Any, port);
    for (var i = 0; i < numberOfSegments; i++)
    {
      // Receive UDP packet and convert to compact frame
      var receivedData = udpClient.Receive(ref ep);
      yield return CompactDeserializer.Convert(receivedData);
    }
  }
}
