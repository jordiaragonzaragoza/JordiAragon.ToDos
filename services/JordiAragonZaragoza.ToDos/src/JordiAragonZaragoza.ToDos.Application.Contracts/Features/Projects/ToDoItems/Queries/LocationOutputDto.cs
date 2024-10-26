namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries
{
    public record class LocationOutputDto
    {
        public float Latitude { get; init; }

        public float Longitude { get; init; }

        public string Address { get; init; }

        public string CountryCode { get; init; }

        public string RegionCode { get; init; }

        public string Locality { get; init; }

        public string PostalCode { get; init; }
    }
}