using GeolocationApi.Enumerations;
using System.Drawing;

namespace GeolocationApi.Models
{
    public class DistanceTwoPointsRequest
    {
        public PointF PointA { get; set; }

        public PointF PointB { get; set; }

        public MeasuringUnit MeasuringUnit { get; set; }
    }
}
