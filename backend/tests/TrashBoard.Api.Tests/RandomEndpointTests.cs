using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TrashBoard.Api;

using Xunit;

namespace TrashBoard.Api.Tests;

public class RandomEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public RandomEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(_ => { });
    }

    [Fact]
    public async Task GetRandom_Returns_Value_Between_1_And_100()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/random");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var payload = await response.Content.ReadFromJsonAsync<RandomResponse>();
        payload.Should().NotBeNull();
        payload!.value.Should().BeInRange(1, 100);
    }

    private sealed record RandomResponse(int value);
}


