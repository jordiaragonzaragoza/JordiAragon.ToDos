namespace JordiAragon.ToDos.Application.UnitTests.Features.Contributor.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragon.ToDos.Application.Features.Contributors.Commands.CreateContributor;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using Moq;
    using Volo.Abp.Guids;
    using Xunit;

    public class CreateContributorCommandHandlerTests
    {
        private readonly Mock<IRepository<Contributor>> repositoryContributorMock;
        private readonly Mock<IGuidGenerator> guidGeneratorMock;

        public CreateContributorCommandHandlerTests()
        {
            this.repositoryContributorMock = new();
            this.guidGeneratorMock = new();
        }

        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenContributor_Is_Not_Added()
        {
            // Given
            this.repositoryContributorMock.Setup(
                x => x.AddAsync(It.IsAny<Contributor>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Contributor)null);

            var guid = Guid.NewGuid();
            this.guidGeneratorMock.Setup(x => x.Create()).Returns(guid);

            var handler = new CreateContributorCommandHandler(
                this.repositoryContributorMock.Object,
                this.guidGeneratorMock.Object);

            var command = new CreateContributorCommand("JordiAragon");

            // When
            var result = await handler.Handle(command, default);

            // When
            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().HaveCount(1).And.Contain($"{nameof(Contributor)}: {guid} was not created.");
        }
    }
}