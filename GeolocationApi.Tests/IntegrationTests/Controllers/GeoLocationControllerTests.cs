using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace GeolocationApi.Tests.IntegrationTests.Controllers
{
    public class GeoLocationControllerTests : IClassFixture<WebApplicationFactory<GeolocationApi.Startup>>
    {
        private readonly HttpClient _client;

        public GeoLocationControllerTests(WebApplicationFactory<GeolocationApi.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        //CalculateDistanceHaversine
        [InlineData("/api/geolocation/calculatedistancehaversine/53.297975/-6.372663/41.385101/-81.440440/Kilometers", 5536.3386822666853)]
        [InlineData("/api/geolocation/calculatedistancehaversine/53.297975/-6.372663/41.385101/-81.440440/Miles", 3440.3335179867854)]
        [InlineData("/api/geolocation/calculatedistancehaversine/53.349722/-6.260278/-22.908333/-43.196388/Kilometers", 9194.9632269246922)]
        [InlineData("/api/geolocation/calculatedistancehaversine/53.349722/-6.260278/-22.908333/-43.196388/Miles", 5713.8376103272412)]
        //CalculateDistanceSphericalLawOfCosines
        [InlineData("/api/geolocation/calculatedistancesphericallawofcosines/53.297975/-6.372663/41.385101/-81.440440/Kilometers", 5536.3386822666871)]
        [InlineData("/api/geolocation/calculatedistancesphericallawofcosines/53.297975/-6.372663/41.385101/-81.440440/Miles", 3440.3335179867863)]
        [InlineData("/api/geolocation/calculatedistancesphericallawofcosines/53.349722/-6.260278/-22.908333/-43.196388/Kilometers", 9194.96322692469)]
        [InlineData("/api/geolocation/calculatedistancesphericallawofcosines/53.349722/-6.260278/-22.908333/-43.196388/Miles", 5713.83761032724)]
        //CalculateEarthProjectionPythagoras
        [InlineData("/api/geolocation/calculateearthprojectionpythagoras/53.297975/-6.372663/41.385101/-81.440440/Kilometers", 5809.2968123283918)]
        [InlineData("/api/geolocation/calculateearthprojectionpythagoras/53.297975/-6.372663/41.385101/-81.440440/Miles", 3609.952296344075)]
        [InlineData("/api/geolocation/calculateearthprojectionpythagoras/53.349722/-6.260278/-22.908333/-43.196388/Kilometers", 9359.9005700095568)]
        [InlineData("/api/geolocation/calculateearthprojectionpythagoras/53.349722/-6.260278/-22.908333/-43.196388/Miles", 5816.3312441795379)]
        public async Task When_calling_api_and_calculating_distances_then_return_the_expected_result_accordingly_to_the_endpoint(
            string url, double expectedResult)
        {
            var response = await _client.GetAsync(url);

            double.TryParse(response.Content.ReadAsStringAsync().Result, out double result);

            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal(expectedResult, result);
        }
    }
}
