namespace JordiAragonZaragoza.ToDos.Application.Features.Contributor.Queries.GetContributorToDoItems
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Queries;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

    public class GetContributorToDoItemsQueryHandler : IQueryHandler<GetContributorToDoItemsQuery, IEnumerable<ToDoItemOutputDto>>
    {
        private readonly IReadRepository<ToDoItem> todoItemReadRepository;
        private readonly IMapper mapper;

        public GetContributorToDoItemsQueryHandler(
            IReadRepository<ToDoItem> todoItemReadRepository,
            IMapper mapper)
        {
            this.todoItemReadRepository = Guard.Against.Null(todoItemReadRepository, nameof(todoItemReadRepository));
            this.mapper = Guard.Against.Null(mapper, nameof(mapper));
        }

        // Not used aggregate root because its just a query. This can be done also using Dappr instead read repository and Specification.
        public async Task<Result<IEnumerable<ToDoItemOutputDto>>> Handle(GetContributorToDoItemsQuery request, CancellationToken cancellationToken)
        {
            var toDoItems = await this.todoItemReadRepository.ListAsync(new GetContributorToDoItemsSpec(ContributorId.Create(request.Id)), cancellationToken);
            if (!toDoItems.Any())
            {
                return Result.NotFound($"{nameof(ToDoItem)}/s not found.");
            }

            return Result.Success(this.mapper.Map<IEnumerable<ToDoItemOutputDto>>(toDoItems));
        }
    }
}