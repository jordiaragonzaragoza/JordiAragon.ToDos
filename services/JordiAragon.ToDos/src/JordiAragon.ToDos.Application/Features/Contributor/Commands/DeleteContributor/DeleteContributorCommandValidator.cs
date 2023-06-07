namespace JordiAragon.ToDos.Application.Features.Contributor.Commands.DeleteContributor
{
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Commands;

    public class DeleteContributorCommandValidator : AbstractValidator<DeleteContributorCommand>
    {
        public DeleteContributorCommandValidator()
        {
            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}