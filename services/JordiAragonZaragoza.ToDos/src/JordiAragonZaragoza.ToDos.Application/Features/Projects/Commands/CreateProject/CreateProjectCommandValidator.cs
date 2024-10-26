namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Commands.CreateProject
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications;

    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        private readonly IReadRepository<Project> projectRepository;

        public CreateProjectCommandValidator(IReadRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;

            this.RuleFor(v => v.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MustAsync(this.ValidateUniqueNameAsync).WithMessage("The specified name already exists.");
        }

        public async Task<bool> ValidateUniqueNameAsync(string name, CancellationToken cancellationToken)
        {
            var result = await this.projectRepository.CountAsync(new ProjectByNameSpec(name), cancellationToken);
            if (result > 0)
            {
                return false;
            }

            return true;
        }
    }
}