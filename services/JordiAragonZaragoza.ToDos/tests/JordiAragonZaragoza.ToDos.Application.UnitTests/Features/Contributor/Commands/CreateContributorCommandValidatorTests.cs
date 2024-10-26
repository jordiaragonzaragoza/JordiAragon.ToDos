namespace JordiAragonZaragoza.ToDos.Application.UnitTests.Features.Contributor.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragonZaragoza.ToDos.Application.Features.Contributors.Commands.CreateContributor;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate.Specifications;
    using Moq;
    using Xunit;

    public class CreateContributorCommandValidatorTests
    {
        private readonly Mock<IReadRepository<Contributor>> contributorRepositoryMock;
        private readonly CreateContributorCommandValidator validator;

        public CreateContributorCommandValidatorTests()
        {
            this.contributorRepositoryMock = new Mock<IReadRepository<Contributor>>();
            this.validator = new CreateContributorCommandValidator(this.contributorRepositoryMock.Object);
        }

        [Fact]
        public async Task Should_Not_Have_Error_When_Command_Is_Valid()
        {
            // Given
            var command = new CreateContributorCommand("JordiAragon");

            this.contributorRepositoryMock.Setup(
                x => x.CountAsync(It.IsAny<ContributorByNameSpec>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(0);

            // When
            var validationResult = await this.validator.ValidateAsync(command);

            // Then
            validationResult.IsValid.Should().BeTrue();
            validationResult.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task Should_Have_Error_When_Command_Name_Is_Empty()
        {
            // Given
            var command = new CreateContributorCommand(string.Empty);

            // When
            var validationResult = await this.validator.ValidateAsync(command);

            // Then
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().ContainSingle();
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Name is required.");
        }

        [Fact]
        public async Task Should_Have_Error_When_Command_Name_Is_Too_Long()
        {
            // Given
            var command = new CreateContributorCommand(new string('a', 201));

            // When
            var validationResult = await this.validator.ValidateAsync(command);

            // Then
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().ContainSingle();
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Name must not exceed 200 characters.");
        }

        [Fact]
        public async Task Should_Have_Error_When_Command_Name_Is_Too_Short()
        {
            // Given
            var command = new CreateContributorCommand("a");

            // When
            var validationResult = await this.validator.ValidateAsync(command);

            // Then
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().ContainSingle();
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "Name must be at least 2 characters.");
        }

        [Fact]
        public async Task Given_A_Existing_Contributor_When_Execute_CreateContributorCommand_It_Should_Fail_Validation()
        {
            // Given
            var existingContributorName = "Existing Contributor";
            var createContributorCommand = new CreateContributorCommand(existingContributorName);

            this.contributorRepositoryMock
                .Setup(repo => repo.CountAsync(It.IsAny<ContributorByNameSpec>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // When
            var validationResult = await this.validator.ValidateAsync(createContributorCommand);

            // Then
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().ContainSingle(error => error.ErrorMessage == "The specified name already exists.");
        }

        [Fact]
        public async Task Given_A_Non_Existing_Contributor_When_Execute_CreateContributorCommand_It_Should_Pass_Validation()
        {
            // Given
            var nonExistingContributorName = "Non-existing Contributor";
            var createContributorCommand = new CreateContributorCommand(nonExistingContributorName);

            this.contributorRepositoryMock
                .Setup(repo => repo.CountAsync(It.IsAny<ContributorByNameSpec>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(0);

            // When
            var validationResult = await this.validator.ValidateAsync(createContributorCommand);

            // Then
            validationResult.IsValid.Should().BeTrue();
            validationResult.Errors.Should().BeEmpty();
        }
    }
}