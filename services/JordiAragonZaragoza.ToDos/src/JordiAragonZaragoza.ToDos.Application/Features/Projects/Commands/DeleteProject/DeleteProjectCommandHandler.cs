namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Commands.DeleteProject
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public DeleteProjectCommandHandler(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.projectRepository.GetByIdAsync(ProjectId.Create(request.Id), cancellationToken);
            if (entity is null)
            {
                return Result.NotFound($"{nameof(Project)}: {request.Id} not found.");
            }

            await this.projectRepository.DeleteAsync(entity, cancellationToken);

            return Result.Success();
        }
    }
}