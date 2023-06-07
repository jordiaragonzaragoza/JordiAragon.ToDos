namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Commands.DeleteToDoItem
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;

    public class DeleteToDoItemCommandHandler : ICommandHandler<DeleteToDoItemCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public DeleteToDoItemCommandHandler(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var existingProject = await this.projectRepository.FirstOrDefaultAsync(new ProjectWithItemsByIdSpec(ProjectId.Create(request.ProjectId)), cancellationToken);
            if (existingProject is null)
            {
                return Result.NotFound($"{nameof(Project)}: {request.ProjectId} not found.");
            }

            existingProject.RemoveItem(ToDoItemId.Create(request.Id));

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success();
        }
    }
}