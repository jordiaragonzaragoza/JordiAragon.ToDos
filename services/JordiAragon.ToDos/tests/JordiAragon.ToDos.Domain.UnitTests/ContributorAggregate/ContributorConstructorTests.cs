namespace JordiAragon.ToDos.Domain.UnitTest.ContributorAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using Xunit;

    public class ContributorConstructorTests
    {
        [Fact]
        public void Given_Valid_Arguments_When_Creating_A_Contributor_It_Should_Be_Created()
        {
            // Given
            var id = ContributorId.Create(Guid.NewGuid());
            var name = "test name";

            // When
            var contributor = Contributor.Create(id, name);

            // Then
            contributor.Should().NotBeNull();
            contributor.Name.Should().Be(name);
            contributor.Id.Should().Be(id);
        }

        [Fact]
        public void Given_A_Null_Name_When_Creating_A_Contributor_It_Should_Throw_An_ArgumentNullException()
        {
            Func<Contributor> contributor = () => Contributor.Create(ContributorId.Create(Guid.NewGuid()), null);
            contributor.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'name')");
        }

        [Fact]
        public void Given_An_Empty_Name_When_Creating_A_Contributor_It_Should_Throw_An_ArgumentNullException()
        {
            Func<Contributor> contributor = () => Contributor.Create(ContributorId.Create(Guid.NewGuid()), string.Empty);
            contributor.Should().Throw<ArgumentException>().WithMessage("Required input name was empty. (Parameter 'name')");
        }
    }
}