namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.UpdateToDoItemDetail
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class UpdateToDoItemDetailCommandHandler : ICommandHandler<UpdateToDoItemDetailCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public UpdateToDoItemDetailCommandHandler(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(UpdateToDoItemDetailCommand request, CancellationToken cancellationToken)
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

            existingToDoItem.UpdateTitle(request.Title);

            if (request.IsDone)
            {
                existingToDoItem.MarkAsComplete();
            }
            else
            {
                existingToDoItem.MarkAsIncomplete();
            }

            existingToDoItem.ChangeDescription(request.Description);

            existingToDoItem.SetPriority(Priority.FromValue(request.Priority.Value));

            existingToDoItem.SetExpirationDate(request.ExpirationDateOnUtc);

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success();
        }
    }
}