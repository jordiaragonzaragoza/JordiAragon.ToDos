namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Commands.DeleteProjects
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class DeleteProjectsCommandHandler : ICommandHandler<DeleteProjectsCommand>
    {
        private readonly IRepository<Project> projectRepository;

        public DeleteProjectsCommandHandler(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result> Handle(DeleteProjectsCommand request, CancellationToken cancellationToken)
        {
            var result = await this.projectRepository.ListAsync(cancellationToken);
            await this.projectRepository.DeleteRangeAsync(result, cancellationToken);

            return Result.Success();
        }
    }
}