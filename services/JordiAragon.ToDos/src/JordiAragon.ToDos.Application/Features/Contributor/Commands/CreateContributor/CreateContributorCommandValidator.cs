namespace JordiAragon.ToDos.Application.Features.Contributors.Commands.CreateContributor
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using FluentValidation;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.ToDos.Domain.ContributorAggregate.Specifications;

    public class CreateContributorCommandValidator : AbstractValidator<CreateContributorCommand>
    {
        private readonly IReadRepository<Contributor> repositoryContributor;

        public CreateContributorCommandValidator(IReadRepository<Contributor> repositoryContributor)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));

            this.RuleFor(v => v.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MustAsync(this.BeUniqueTitleAsync).WithMessage("The specified name already exists.");
        }

        public async Task<bool> BeUniqueTitleAsync(string name, CancellationToken cancellationToken)
        {
            var result = await this.repositoryContributor.CountAsync(new ContributorByNameSpec(name), cancellationToken);
            if (result > 0)
            {
                return false;
            }

            return true;
        }
    }
}