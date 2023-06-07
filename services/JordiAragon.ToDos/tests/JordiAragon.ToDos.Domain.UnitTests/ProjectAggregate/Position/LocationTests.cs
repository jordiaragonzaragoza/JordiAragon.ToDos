namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate.Position
{
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Position;
    using Xunit;

    public class LocationTests
    {
        [Fact]
        public void CreateByCoordinates_Should_Be_Equal_To_Passed_Parameters()
        {
            var coordinates = Coordinates.Create(
                (Latitude)37.1773f,
                (Longitude)(-3.5985f));

            var location = Location.CreateByCoordinates(coordinates);

            location.Coordinates.Should().Be(coordinates);
            location.Address.Should().BeNull();
            location.CountryCode.Should().BeNull();
            location.RegionCode.Should().BeNull();
            location.Locality.Should().BeNull();
            location.PostalCode.Should().BeNull();
        }

        [Fact]
        public void Create_Should_Be_Equal_To_Passed_Parameters()
        {
            var coordinates = Coordinates.Create(
                (Latitude)37.1773f,
                (Longitude)(-3.5985f));

            var address = "address";
            var countryCode = "countryCode";
            var regionCode = "regionCode";
            var locality = "locality";
            var postalCode = "postalCode";

            var location = Location.Create(
                coordinates,
                address,
                countryCode,
                regionCode,
                locality,
                postalCode);

            location.Coordinates.Should().Be(coordinates);
            location.Address.Should().Be(address);
            location.CountryCode.Should().Be(countryCode);
            location.RegionCode.Should().Be(regionCode);
            location.Locality.Should().Be(locality);
            location.PostalCode.Should().Be(postalCode);
        }
    }
}