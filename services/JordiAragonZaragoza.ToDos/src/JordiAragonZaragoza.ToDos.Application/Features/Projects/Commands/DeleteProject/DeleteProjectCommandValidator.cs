namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Commands.DeleteProject
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;

    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}