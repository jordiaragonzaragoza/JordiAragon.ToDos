namespace JordiAragon.ToDos.Application.Features.Projects.Commands.DeleteProject
{
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Commands;

    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}