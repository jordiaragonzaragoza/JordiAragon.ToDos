namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Commands.UpdateProjectDetails
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

    public class UpdateProjectDetailsCommandValidator : AbstractValidator<UpdateProjectDetailsCommand>
    {
        public UpdateProjectDetailsCommandValidator()
        {
            this.RuleFor(v => v.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

            this.RuleFor(x => x.Priority)
                .Must(this.ValidatePriority).WithMessage("Priority supplied is not supported.");
        }

        private bool ValidatePriority(PriorityInputDto priority)
        {
            if (!Priority.TryFromValue(priority.Value, out Priority _)
                || !Priority.TryFromName(priority.Name, out Priority _))
            {
                return false;
            }

            return true;
        }
    }
}