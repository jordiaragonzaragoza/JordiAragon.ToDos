namespace JordiAragon.ToDos.Application.Features.Contributors.Commands.UpdateContributor
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.ToDos.Domain.ContributorAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using Ardalis.GuardClauses;

    public class UpdateContributorCommandValidator : AbstractValidator<UpdateContributorCommand>
    {
        private readonly IReadRepository<Contributor> repositoryContributor;

        public UpdateContributorCommandValidator(IReadRepository<Contributor> repositoryContributor)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");

            this.RuleFor(v => v.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MustAsync(this.BeUniqueTitleAsync).WithMessage("The specified name already exists.");
        }

        public async Task<bool> BeUniqueTitleAsync(UpdateContributorCommand command, string name, CancellationToken cancellationToken)
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