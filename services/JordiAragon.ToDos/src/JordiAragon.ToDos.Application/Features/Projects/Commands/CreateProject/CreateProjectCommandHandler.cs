namespace JordiAragon.ToDos.Application.Features.Projects.Commands.CreateProject
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using Volo.Abp.Guids;

    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Guid>
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IGuidGenerator guidGenerator;

        public CreateProjectCommandHandler(
            IRepository<Project> projectRepository,
            IGuidGenerator guidGenerator)
        {
            this.projectRepository = projectRepository;
            this.guidGenerator = guidGenerator;
        }

        public async Task<Result<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var newProject = Project.Create(
                id: ProjectId.Create(this.guidGenerator.Create()),
                name: request.Name,
                priority: Priority.None,
                color: Color.White);

            var result = await this.projectRepository.AddAsync(newProject, cancellationToken);

            if (result is null)
            {
                return Result.Error($"{nameof(Project)}: {newProject.Id} was not created.");
            }

            return Result.Success(result.Id.Value);
        }
    }
}