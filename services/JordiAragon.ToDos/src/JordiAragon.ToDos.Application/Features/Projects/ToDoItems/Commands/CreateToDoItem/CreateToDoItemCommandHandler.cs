namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Commands.CreateToDoItem
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using Volo.Abp.Guids;

    public class CreateToDoItemCommandHandler : ICommandHandler<CreateToDoItemCommand, Guid>
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IGuidGenerator guidGenerator;

        public CreateToDoItemCommandHandler(
            IRepository<Project> projectRepository,
            IDateTime dateTime,
            IGuidGenerator guidGenerator)
        {
            this.projectRepository = projectRepository;
            this.guidGenerator = guidGenerator;
        }

        public async Task<Result<Guid>> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var existingProject = await this.projectRepository.GetByIdAsync(ProjectId.Create(request.ProjectId), cancellationToken);
            if (existingProject is null)
            {
                return Result.NotFound($"{nameof(Project)}: {request.ProjectId} not found.");
            }

            var newToDoItem = existingProject.AddItem(ToDoItemId.Create(this.guidGenerator.Create()), request.Title, null);

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success(newToDoItem.Id.Value);
        }
    }
}