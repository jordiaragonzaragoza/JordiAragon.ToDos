namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Controllers.V1
{
    using System.Collections.Generic;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.SharedKernel.Presentation.WebApi.Contracts;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Requests;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Responses;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Mappers.V1;

    public static class ToDoItemsMapperExtension
    {
        public static void MapToDoItem(this Mapper maps)
        {
            // Requests to queries or commands.
            maps.CreateMap<GetToDoItemsPaginatedRequest, GetToDoItemsPaginatedQuery>();
            maps.CreateMap<CreateToDoItemRequest, CreateToDoItemCommand>();
            maps.CreateMap<UpdateToDoItemRequest, UpdateToDoItemCommand>();
            maps.CreateMap<UpdateToDoItemDetailRequest, UpdateToDoItemDetailCommand>();
            maps.CreateMap<SetLocationToDoItemRequest, SetLocationToDoItemCommand>();

            // OutputDtos to responses.
            maps.CreateMap<LocationOutputDto, LocationResponse>();
            maps.CreateMap<ToDoItemOutputDto, ToDoItemResponse>();
            maps.CreateMap<ToDoItemDetailsOutputDto, ToDoItemDetailsResponse>();
            maps.CreateMap<PaginatedCollectionOutputDto<ToDoItemOutputDto>, PaginatedCollectionResponse<ToDoItemResponse>>();
            maps.CreateMap<Result<ToDoItemOutputDto>, Result<ToDoItemResponse>>();
            maps.CreateMap<Result<ToDoItemDetailsOutputDto>, Result<ToDoItemDetailsResponse>>();
            maps.CreateMap<Result<IEnumerable<ToDoItemOutputDto>>, Result<IEnumerable<ToDoItemResponse>>>();
            maps.CreateMap<Result<IEnumerable<ToDoItemDetailsOutputDto>>, Result<IEnumerable<ToDoItemDetailsResponse>>>();
            maps.CreateMap<Result<PaginatedCollectionOutputDto<ToDoItemOutputDto>>, Result<PaginatedCollectionResponse<ToDoItemResponse>>>();
        }
    }
}