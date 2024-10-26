namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.ReasignToDoItemToProject
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

    public class ReasignToDoItemToProjectCommandHandler : ICommandHandler<ReasignToDoItemToProjectCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public ReasignToDoItemToProjectCommandHandler(
            IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(ReasignToDoItemToProjectCommand request, CancellationToken cancellationToken)
        {
            var destinationProject = await this.projectRepository.GetByIdAsync(ProjectId.Create(request.DestinatioProjectId), cancellationToken);
            if (destinationProject is null)
            {
                return Result.NotFound($"{nameof(Project)}: {request.DestinatioProjectId} not found.");
            }

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

            existingToDoItem.ReasignProject(ProjectId.Create(request.DestinatioProjectId));

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success();
        }
    }
}