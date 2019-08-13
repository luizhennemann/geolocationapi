using GeolocationApi.Enumerations;
using GeolocationApi.GeoLocationService.Interfaces;
using System;

namespace GeolocationApi.GeoLocationService.Implementations
{
    public class GeoLocationCalculator : IGeoLocationCalculator
    {
        public double CalculateDistanceHaversine(double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit)
        {
            double radiansLatitudeA = latitudeA * ToRadians();
            double radiansLatitudeB = latitudeB * ToRadians();

            double degreesLatitudeHalf = (radiansLatitudeB - radiansLatitudeA) / 2;
            double degreesLongitudeHalf = Math.PI * (longitudeB - longitudeA) / 360;

            double tempResultA = Math.Sin(degreesLatitudeHalf);
            tempResultA *= tempResultA;

            double tempResultB = Math.Sin(degreesLongitudeHalf);
            tempResultB *= tempResultB * Math.Cos(radiansLatitudeA) * Math.Cos(radiansLatitudeB);

            double centralAngle = 2 * Math.Atan2(Math.Sqrt(tempResultA + tempResultB), Math.Sqrt(1 - tempResultA - tempResultB));

            return centralAngle * GetRadiusByMeasuringUnit(measuringUnit);
        }

        public double CalculateDistanceSphericalLawOfCosines(double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit)
        {
            double radiansLatitudeA = latitudeA * ToRadians();
            double radiansLatitudeB = latitudeB * ToRadians();
            double radiansLongitudeA = longitudeA * ToRadians();
            double radiansLongitudeB = longitudeB * ToRadians();

            double centralAngle = Math.Acos(Math.Sin(radiansLatitudeA) * Math.Sin(radiansLatitudeB) +
                    Math.Cos(radiansLatitudeA) * Math.Cos(radiansLatitudeB) * Math.Cos(radiansLongitudeB - radiansLongitudeA));

            return centralAngle * GetRadiusByMeasuringUnit(measuringUnit);
        }

        public double CalculateEarthProjectionPythagoras(double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit)
        {
            double radiansLatitudeA = latitudeA * ToRadians();
            double radiansLatitudeB = latitudeB * ToRadians();
            double degreesLatitude = (radiansLatitudeB - radiansLatitudeA);
            double degreesLongitude = (longitudeB - longitudeA) * ToRadians();

            double tempResult = (degreesLongitude) * Math.Cos((radiansLatitudeA + radiansLatitudeB) / 2);

            double centralAngle = Math.Sqrt(tempResult * tempResult + degreesLatitude * degreesLatitude);

            return centralAngle * GetRadiusByMeasuringUnit(measuringUnit);
        }

        private static double ToRadians() => Math.PI / 180;

        private static double GetRadiusByMeasuringUnit(MeasuringUnit unit) => unit == MeasuringUnit.Kilometers ? 6371 : 3959;
    }
}
