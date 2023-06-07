namespace JordiAragon.ToDos.IntegrationTests.Features.Projects.Commands
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Commands;
    using Xunit;

    [Collection("IntegrationTests")]
    public class CreateProjectTests
    {
        private readonly TestingFixture fixture;

        public CreateProjectTests(TestingFixture fixture)
        {
            this.fixture = fixture;
        }

        ////[Fact] Disabled until TestingFixture ready.
        public async Task ShouldRequireMinimumFields()
        {
            await this.fixture.ResetState();

            var command = new CreateProjectCommand(null);
            await FluentActions.Invoking(() => this.fixture.SendAsync(command)).Should().ThrowAsync<Exception>();
        }
    }
}