namespace JordiAragon.ToDos.Application.Features.Projects.Commands.UpdateProject
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public UpdateProjectCommandHandler(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var existingProject = await this.projectRepository.GetByIdAsync(ProjectId.Create(request.Id), cancellationToken);
            if (existingProject is null)
            {
                return Result.NotFound($"{nameof(Project)}: {request.Id} not found.");
            }

            if (!existingProject.Name.Equals(request.Name))
            {
                var result = await this.projectRepository.CountAsync(new ProjectByNameSpec(request.Name), cancellationToken);
                if (result > 0)
                {
                    return Result.Error("The specified name already exists.");
                }
            }

            existingProject.UpdateName(request.Name);

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success();
        }
    }
}