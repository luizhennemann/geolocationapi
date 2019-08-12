using GeolocationApi.Enumerations;
using GeolocationApi.GeoLocationService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GeolocationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoLocationController : ControllerBase
    {
        private readonly IGeoLocationCalculator _geoLocationCalculator;
        private readonly ILogger<GeoLocationController> _logger;

        public GeoLocationController(IGeoLocationCalculator geoLocationCalculator, ILoggerFactory loggerFactory)
        {
            _geoLocationCalculator = geoLocationCalculator;
            _logger = loggerFactory.CreateLogger<GeoLocationController>();
        }

        [HttpGet]
        [Route("CalculateDistanceHaversine/{latitudeA}/{longitudeA}/{latitudeB}/{longitudeB}/{measuringUnit}")]
        public ActionResult<double> CalculateDistanceHaversine(double latitudeA, double longitudeA, double latitudeB, double longitudeB, string measuringUnit)
        {
            try
            {
                _logger.LogInformation($"Calculating Distance Haversine between {latitudeA}, {longitudeA} and {latitudeB}, {longitudeB}");

                var distance = _geoLocationCalculator
                    .CaculateDistanceHaversine(latitudeA, longitudeA, latitudeB, longitudeB, GetMeasuringUnitEnum(measuringUnit));

                return Ok(distance);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong calculating Distance Haversine: {ex}");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("CalculateDistanceSphericalLawOfCosines/{latitudeA}/{longitudeA}/{latitudeB}/{longitudeB}/{measuringUnit}")]
        public ActionResult<double> CalculateDistanceSphericalLawOfCosines(double latitudeA, double longitudeA, double latitudeB, double longitudeB, string measuringUnit)
        {
            try
            {
                _logger.LogInformation($"Calculating Spherical Law of Cosines between {latitudeA}, {longitudeA} and {latitudeB}, {longitudeB}.");

                var distance = _geoLocationCalculator
                    .CalculateDistanceSphericalLawOfCosines(latitudeA, longitudeA, latitudeB, longitudeB, GetMeasuringUnitEnum(measuringUnit));

                return Ok(distance);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong calculating Spherical Law of Cosines: {ex}");
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("CalculateEarthProjectionPythagoras/{latitudeA}/{longitudeA}/{latitudeB}/{longitudeB}/{measuringUnit}")]
        public ActionResult<double> CalculateEarthProjectionPythagoras(double latitudeA, double longitudeA, double latitudeB, double longitudeB, string measuringUnit)
        {
            try
            {
                _logger.LogInformation($"Calculating Earth Projection Pythagoras between {latitudeA}, {longitudeA} and {latitudeB}, {longitudeB}.");

                var distance = _geoLocationCalculator
                    .CalculateEarthProjectionPythagoras(latitudeA, longitudeA, latitudeB, longitudeB, GetMeasuringUnitEnum(measuringUnit));

                return Ok(distance);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong calculating Earth Projection Pythagoras: {ex}");
            }

            return BadRequest();
        }

        private static MeasuringUnit GetMeasuringUnitEnum(string measuringUnit) => (MeasuringUnit)Enum.Parse(typeof(MeasuringUnit), measuringUnit);
    }
}
