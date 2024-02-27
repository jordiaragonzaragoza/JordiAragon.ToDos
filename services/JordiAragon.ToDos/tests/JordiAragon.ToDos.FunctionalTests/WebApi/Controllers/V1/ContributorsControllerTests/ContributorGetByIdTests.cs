namespace JordiAragon.ToDos.FunctionalTests.WebApi.Controllers.V1.ContributorsControllerTests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Ardalis.HttpClientTestExtensions;
    using JordiAragon.ToDos.Infrastructure.EntityFramework;
    using JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Contributors.Responses;
    using Xunit;

    [Collection("Sequential")]
    public class ContributorGetByIdTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient client;

        public ContributorGetByIdTests(CustomWebApplicationFactory<Program> factory)
        {
            this.client = factory.CreateClient();
        }

        ////[Fact] Disabled until fix authorization test.
        public async Task ReturnsSeedContributorGivenId()
        {
            var result = await this.client.GetAndDeserializeAsync<ContributorResponse>($"api/v1/contributors/{SeedData.Contributor1.Id.Value}");

            Assert.Equal(SeedData.Contributor1.Id.Value, result.Id);
            Assert.Equal(SeedData.Contributor1.Name, result.Name);
        }

        /*
        [Fact]
        public async Task ReturnsNotFoundGivenId0()
        {
            string route = GetContributorByIdRequest.BuildRoute(0);
            _ = await this.client.GetAndEnsureNotFoundAsync(route);
        }*/
    }
}