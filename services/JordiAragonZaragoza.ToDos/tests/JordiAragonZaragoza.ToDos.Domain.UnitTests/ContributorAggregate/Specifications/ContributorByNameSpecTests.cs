namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ContributorAggregate.Specifications
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate.Specifications;
    using Xunit;

    public class ContributorByNameSpecTests
    {
        [Fact]
        public void Given_A_Contributor_Name_And_A_Contributor_List_When_Apply_A_Query_With_ContributorByNameSpec_It_Should_Be_Found()
        {
            // Given
            var name = "test name";

            var contributor1 = Contributor.Create(ContributorId.Create(Guid.NewGuid()), name);
            var contributor2 = Contributor.Create(ContributorId.Create(Guid.NewGuid()), "John");
            var contributor3 = Contributor.Create(ContributorId.Create(Guid.NewGuid()), "Susan");

            var contributors = new List<Contributor>() { contributor1, contributor2, contributor3 };

            var spec = new ContributorByNameSpec(name);

            // When
            var evaluatedList = spec.Evaluate(contributors);

            // Then
            evaluatedList.Should()
                         .ContainSingle(c => c == contributor1)
                         .And.NotContain(c => c == contributor2)
                         .And.NotContain(c => c == contributor3);
        }
    }
}