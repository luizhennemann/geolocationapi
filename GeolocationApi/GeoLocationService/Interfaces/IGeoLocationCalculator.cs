using GeolocationApi.Enumerations;

namespace GeolocationApi.GeoLocationService.Interfaces
{
    public interface IGeoLocationCalculator
    {
        double CalculateDistanceHaversine(double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit);

        double CalculateDistanceSphericalLawOfCosines(double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit);

        double CalculateEarthProjectionPythagoras(double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit);
    }
}
