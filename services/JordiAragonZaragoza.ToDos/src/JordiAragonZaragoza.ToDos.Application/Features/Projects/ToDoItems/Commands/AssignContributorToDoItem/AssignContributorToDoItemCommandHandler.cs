namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.AssignContributorToDoItem
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class AssignContributorToDoItemCommandHandler : ICommandHandler<AssignContributorToDoItemCommand>
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IReadRepository<Contributor> contributorRepository;

        public AssignContributorToDoItemCommandHandler(
            IRepository<Project> projectRepository,
            IReadRepository<Contributor> contributorRepository)
        {
            this.projectRepository = projectRepository;
            this.contributorRepository = contributorRepository;
        }

        public async Task<Result> Handle(AssignContributorToDoItemCommand request, CancellationToken cancellationToken)
        {
            var existingContributor = await this.contributorRepository.GetByIdAsync(ContributorId.Create(request.ContributorId), cancellationToken);
            if (existingContributor is null)
            {
                return Result.NotFound($"{nameof(Contributor)}: {request.ContributorId} not found.");
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

            existingToDoItem.AssignContributor(ContributorId.Create(request.ContributorId));

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);

            return Result.Success();
        }
    }
}