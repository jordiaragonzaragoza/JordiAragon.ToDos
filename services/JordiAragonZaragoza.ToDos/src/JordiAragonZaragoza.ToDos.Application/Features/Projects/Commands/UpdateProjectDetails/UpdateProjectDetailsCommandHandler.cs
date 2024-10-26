namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Commands.UpdateProjectDetails
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class UpdateProjectDetailsCommandHandler : ICommandHandler<UpdateProjectDetailsCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public UpdateProjectDetailsCommandHandler(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(UpdateProjectDetailsCommand request, CancellationToken cancellationToken)
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
            existingProject.SetPriority(Priority.FromValue(request.Priority.Value));

            var newColor = Color.FromRgb(Intensity.FromScalar(request.Color.Red), Intensity.FromScalar(request.Color.Green), Intensity.FromScalar(request.Color.Blue));

            existingProject.SetColor(newColor);

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success();
        }
    }
}