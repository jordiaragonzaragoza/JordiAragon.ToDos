namespace JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Responses
{
    public record class LocationResponse(
        float Latitude,
        float Longitude,
        string Address,
        string CountryCode,
        string RegionCode,
        string Locality,
        string PostalCode);
}