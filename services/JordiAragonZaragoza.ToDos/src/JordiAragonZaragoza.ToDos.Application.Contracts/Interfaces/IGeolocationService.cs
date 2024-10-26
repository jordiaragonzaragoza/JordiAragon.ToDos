namespace JordiAragonZaragoza.ToDos.Application.Contracts.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public interface IGeolocationService
    {
        Task<Result<GeocodeOutputDto>> GetGeocodeAsync(string addressSearch, CancellationToken cancellationToken = default);

        Task<Result<GeocodeOutputDto>> GetGeocodeAsync(float latitude, float longitude, CancellationToken cancellationToken = default);
    }
}