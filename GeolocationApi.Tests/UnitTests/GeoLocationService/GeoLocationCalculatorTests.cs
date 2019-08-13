using GeolocationApi.Enumerations;
using GeolocationApi.GeoLocationService.Implementations;
using GeolocationApi.GeoLocationService.Interfaces;
using Xunit;

namespace GeoLocationApi.UnitTests.GeoLocationServiceTests
{
    public class GeoLocationCalculatorTests
    {
        private readonly IGeoLocationCalculator _sut;

        public GeoLocationCalculatorTests()
        {
            _sut = new GeoLocationCalculator();
        }

        [Theory]
        [InlineData(53.297975, -6.372663, 41.385101, -81.440440, MeasuringUnit.Kilometers, 5536.3386822666853)]
        [InlineData(53.297975, -6.372663, 41.385101, -81.440440, MeasuringUnit.Miles, 3440.3335179867854)]
        [InlineData(53.349722, -6.260278, -22.908333, -43.196388, MeasuringUnit.Kilometers, 9194.9632269246922)]
        [InlineData(53.349722, -6.260278, -22.908333, -43.196388, MeasuringUnit.Miles, 5713.8376103272412)]
        public void When_calculating_distance_haversine_then_return_the_expected_result_accordingly(
            double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit, double expectedResult)
        {
            var result = _sut.CalculateDistanceHaversine(latitudeA, longitudeA, latitudeB, longitudeB, measuringUnit);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(53.297975, -6.372663, 41.385101, -81.440440, MeasuringUnit.Kilometers, 5536.3386822666871)]
        [InlineData(53.297975, -6.372663, 41.385101, -81.440440, MeasuringUnit.Miles, 3440.3335179867863)]
        [InlineData(53.349722, -6.260278, -22.908333, -43.196388, MeasuringUnit.Kilometers, 9194.96322692469)]
        [InlineData(53.349722, -6.260278, -22.908333, -43.196388, MeasuringUnit.Miles, 5713.83761032724)]
        public void When_calculating_distance_spherical_law_of_cousines_then_return_the_expected_result_accordingly(
            double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit, double expectedResult)
        {
            var result = _sut.CalculateDistanceSphericalLawOfCosines(latitudeA, longitudeA, latitudeB, longitudeB, measuringUnit);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(53.297975, -6.372663, 41.385101, -81.440440, MeasuringUnit.Kilometers, 5809.2968123283918)]
        [InlineData(53.297975, -6.372663, 41.385101, -81.440440, MeasuringUnit.Miles, 3609.952296344075)]
        [InlineData(53.349722, -6.260278, -22.908333, -43.196388, MeasuringUnit.Kilometers, 9359.9005700095568)]
        [InlineData(53.349722, -6.260278, -22.908333, -43.196388, MeasuringUnit.Miles, 5816.3312441795379)]
        public void When_calculating_earth_projection_pythagoras_then_return_the_expected_result_accordingly(
            double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasuringUnit measuringUnit, double expectedResult)
        {
            var result = _sut.CalculateEarthProjectionPythagoras(latitudeA, longitudeA, latitudeB, longitudeB, measuringUnit);

            Assert.Equal(expectedResult, result);
        }
    }
}
