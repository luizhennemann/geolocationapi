using GeolocationApi.Enumerations;
using System.Drawing;

namespace GeolocationApi.GeoLocationService.Interfaces
{
    public interface IGeoLocationCalculator
    {
        double CaculateDistanceHaversine(PointF pointA, PointF pointB, MeasuringUnit measuringUnit);

        double CalculateDistanceSphericalLawOfCosines(PointF pointA, PointF pointB, MeasuringUnit measuringUnit);

        double CalculateEarthProjectionPythagoras(PointF pointA, PointF pointB, MeasuringUnit measuringUnit);
    }
}
