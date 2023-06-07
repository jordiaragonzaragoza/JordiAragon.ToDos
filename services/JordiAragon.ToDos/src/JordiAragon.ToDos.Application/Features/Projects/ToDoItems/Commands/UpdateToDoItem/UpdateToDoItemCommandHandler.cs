namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Commands.UpdateToDoItem
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class UpdateToDoItemCommandHandler : ICommandHandler<UpdateToDoItemCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public UpdateToDoItemCommandHandler(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var existingProject = await this.projectRepository.FirstOrDefaultAsync(new ProjectWithItemsByIdSpec(ProjectId.Create(request.ProjectId)), cancellationToken);
            if (existingProject is null)
            {
                return Result.NotFound($"{nameof(Project)}: {request.ProjectId} not found.");
            }

            var existingToDoItem = existingProject.Items.FirstOrDefault(item => item.Id == ToDoItemId.Create(request.Id));
            if (existingToDoItem is null)
            {
                return Result.NotFound($"{nameof(ToDoItem)}: {request.Id} not found.");
            }

            if (request.IsDone)
            {
                existingToDoItem.MarkAsComplete();
            }
            else
            {
                existingToDoItem.MarkAsIncomplete();
            }

            existingToDoItem.UpdateTitle(request.Title);

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success();
        }
    }
}