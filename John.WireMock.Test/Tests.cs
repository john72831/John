

using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace John.WireMock.Test
{
    public class Tests : IClassFixture<IntegrationTestAppFactory<Program>>, IAsyncLifetime
    {
        private readonly IntegrationTestAppFactory<Program> _factory;
        private readonly Fixture _fixture = new();
        private readonly WireMockServer _wireMockServer;

        public Tests(IntegrationTestAppFactory<Program> factory)
        {
            _factory = factory;
            _wireMockServer = _factory.Services.GetRequiredService<WireMockServer>();
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async void Test1()
        {
            // Arrange
            var expectedString = "Hello from WireMock!!!";
            var httpClient = _factory.CreateClient();
            _wireMockServer
                .Given(Request.Create().WithPath("/innertest").UsingGet())
                .RespondWith(Response.Create().WithBody(expectedString));

            // Act
            var response = await httpClient.GetAsync($"/test");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var body = await response.Content.ReadAsStringAsync();
            body.Should().Be(expectedString);
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}