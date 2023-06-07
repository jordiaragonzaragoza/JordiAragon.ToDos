namespace JordiAragon.ToDos.Application.Features.Projects.Queries.GetProjectToDosAsCsv
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragon.ToDos.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;

    public class GetProjectToDosAsCsvFileQueryHandler : IQueryHandler<GetProjectToDosAsCsvFileQuery, FileOutputDto>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;
        private readonly ICsvFileBuilderService csvFileBuilderService;

        public GetProjectToDosAsCsvFileQueryHandler(
            IReadRepository<Project> projectRepository,
            ICsvFileBuilderService csvFileBuilderService,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
            this.csvFileBuilderService = csvFileBuilderService;
        }

        public async Task<Result<FileOutputDto>> Handle(GetProjectToDosAsCsvFileQuery request, CancellationToken cancellationToken)
        {
            var project = await this.projectRepository.FirstOrDefaultAsync(new ProjectExtendedByIdSpec(ProjectId.Create(request.ProjectId)), cancellationToken);
            if (project is null)
            {
                return Result.NotFound($"{nameof(Project)} {request.ProjectId} not found.");
            }

            if (!project.Items.Any())
            {
                return Result.NotFound($"{nameof(ToDoItem)}/s not found for {nameof(Project)} {request.ProjectId}.");
            }

            var toDoItems = this.mapper.Map<IEnumerable<ToDoItemOutputDto>>(project.Items);

            var fileDownloadName = $"ToDoItemsFromProject{project.Name}";
            var fileContents = this.csvFileBuilderService.BuildTodoItemsFile(toDoItems);
            var contentType = "text/csv";

            var outputDto = new FileOutputDto(fileContents, contentType, fileDownloadName);

            return Result.Success(outputDto);
        }
    }
}