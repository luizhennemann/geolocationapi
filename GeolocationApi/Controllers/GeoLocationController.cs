using GeolocationApi.GeoLocationService.Interfaces;
using GeolocationApi.Models;
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

        [Route("calculatedistancehaversine")]
        public ActionResult<double> CalculateDistanceHaversine([FromBody] DistanceTwoPointsRequest request)
        {
            try
            {
                _logger.LogInformation($"Calculating Distance Haversine between {request.PointA.X}, {request.PointA.Y} and {request.PointB.X}, {request.PointB.Y}");

                var distance = _geoLocationCalculator
                    .CaculateDistanceHaversine(request.PointA, request.PointB, request.MeasuringUnit);

                return Ok(distance);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong calculating Distance Haversine: {ex}");
            }

            return BadRequest();
        }

        [Route("calculatedistancesphericallawofcosines")]
        public ActionResult<double> CalculateDistanceSphericalLawOfCosines([FromBody] DistanceTwoPointsRequest request)
        {
            try
            {
                _logger.LogInformation($"Calculating Spherical Law of Cosines between {request.PointA.X}, {request.PointA.Y} and {request.PointB.X}, {request.PointB.Y}");

                var distance = _geoLocationCalculator
                    .CalculateDistanceSphericalLawOfCosines(request.PointA, request.PointB, request.MeasuringUnit);

                return Ok(distance);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong calculating Spherical Law of Cosines: {ex}");
            }

            return BadRequest();
        }

        [Route("calculateearthprojectionpythagoras")]
        public ActionResult<double> CalculateEarthProjectionPythagoras([FromBody] DistanceTwoPointsRequest request)
        {
            try
            {
                _logger.LogInformation($"Calculating Earth Projection Pythagoras between {request.PointA.X}, {request.PointA.Y} and {request.PointB.X}, {request.PointB.Y}");

                var distance = _geoLocationCalculator
                    .CalculateEarthProjectionPythagoras(request.PointA, request.PointB, request.MeasuringUnit);

                return Ok(distance);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong calculating Earth Projection Pythagoras: {ex}");
            }

            return BadRequest();
        }
    }
}
