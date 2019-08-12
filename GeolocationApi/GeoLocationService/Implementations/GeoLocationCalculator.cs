using System;
using System.Drawing;
using GeolocationApi.Enumerations;
using GeolocationApi.GeoLocationService.Interfaces;

namespace GeolocationApi.GeoLocationService.Implementations
{
    public class GeoLocationCalculator : IGeoLocationCalculator
    {
        public double CaculateDistanceHaversine(PointF pointA, PointF pointB, MeasuringUnit measuringUnit)
        {
            double radiansLatitudeA = pointA.X * ToRadians();
            double radiansLatitudeB = pointB.X * ToRadians();

            double degreesLatitudeHalf = (radiansLatitudeB - radiansLatitudeA) / 2;
            double degreesLongitudeHalf = Math.PI * (pointB.Y - pointA.Y) / 360;

            double tempResultA = Math.Sin(degreesLatitudeHalf);
            tempResultA *= tempResultA;

            double tempResultB = Math.Sin(degreesLongitudeHalf);
            tempResultB *= tempResultB * Math.Cos(radiansLatitudeA) * Math.Cos(radiansLatitudeB);

            double centralAngle = 2 * Math.Atan2(Math.Sqrt(tempResultA + tempResultB), Math.Sqrt(1 - tempResultA - tempResultB));

            return centralAngle * GetRadiusByMeasuringUnit(measuringUnit);
        }

        public double CalculateDistanceSphericalLawOfCosines(PointF pointA, PointF pointB, MeasuringUnit measuringUnit)
        {
            double radiansLatitudeA = pointA.X * ToRadians();
            double radiansLatitudeB = pointB.X * ToRadians();
            double radiansLongitudeA = pointA.Y * ToRadians();
            double radiansLongitudeB = pointB.Y * ToRadians();

            double centralAngle = Math.Acos(Math.Sin(radiansLatitudeA) * Math.Sin(radiansLatitudeB) +
                    Math.Cos(radiansLatitudeA) * Math.Cos(radiansLatitudeB) * Math.Cos(radiansLongitudeB - radiansLongitudeA));

            return centralAngle * GetRadiusByMeasuringUnit(measuringUnit);
        }

        public double CalculateEarthProjectionPythagoras(PointF pointA, PointF pointB, MeasuringUnit measuringUnit)
        {
            double radiansLatitudeA = pointA.X * ToRadians();
            double radiasnLatitudeB = pointB.X * ToRadians();
            double degreesLatitude = (radiasnLatitudeB - radiansLatitudeA);
            double degreesLongitude = (pointB.Y - pointA.Y) * ToRadians();

            double tempResult = (degreesLongitude) * Math.Cos((radiansLatitudeA + radiasnLatitudeB) / 2);

            double centralAngle = Math.Sqrt(tempResult * tempResult + degreesLatitude * degreesLatitude);

            return centralAngle * GetRadiusByMeasuringUnit(measuringUnit);
        }

        private static double ToRadians() => Math.PI / 180;

        private static double GetRadiusByMeasuringUnit(MeasuringUnit unit) => unit == MeasuringUnit.Kilometers ? 6371 : 3959;
    }
}
