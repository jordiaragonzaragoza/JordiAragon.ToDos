namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Commands.RemoveContributorToDoItem
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class RemoveContributorToDoItemCommandHandler : ICommandHandler<RemoveContributorToDoItemCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public RemoveContributorToDoItemCommandHandler(
            IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(RemoveContributorToDoItemCommand request, CancellationToken cancellationToken)
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

            existingToDoItem.RemoveContributor();

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success();
        }
    }
}