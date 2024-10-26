namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Position
{
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public class Location : BaseValueObject
    {
        // Required by EF
        private Location()
        {
        }

        private Location(
            Coordinates coordinates,
            string address,
            string countryCode,
            string regionCode,
            string locality,
            string postalCode)
        {
            this.Coordinates = coordinates;
            this.Address = address;
            this.CountryCode = countryCode;
            this.RegionCode = regionCode;
            this.Locality = locality;
            this.PostalCode = postalCode;
        }

        public Coordinates Coordinates { get; init; }

        public string Address { get; init; }

        public string CountryCode { get; init; }

        public string RegionCode { get; init; }

        public string Locality { get; init; }

        public string PostalCode { get; init; }

        public static Location CreateByCoordinates(Coordinates coordinates)
        {
            return new Location(coordinates, null, null, null, null, null);
        }

        public static Location Create(
            Coordinates coordinates,
            string address,
            string countryCode,
            string regionCode,
            string locality,
            string postalCode)
        {
            return new Location(coordinates, address, countryCode, regionCode, locality, postalCode);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Coordinates;
            yield return this.Address;
            yield return this.CountryCode;
            yield return this.RegionCode;
            yield return this.Locality;
            yield return this.PostalCode;
        }
    }
}