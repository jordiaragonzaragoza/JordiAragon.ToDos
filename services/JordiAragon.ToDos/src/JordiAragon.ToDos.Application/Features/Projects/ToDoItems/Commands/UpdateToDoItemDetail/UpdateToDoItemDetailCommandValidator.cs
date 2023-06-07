namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Commands.UpdateToDoItemDetail
{
    using System;
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class UpdateToDoItemDetailCommandValidator : AbstractValidator<UpdateToDoItemDetailCommand>
    {
        private readonly IDateTime dateTime;

        public UpdateToDoItemDetailCommandValidator(
            IDateTime dateTime)
        {
            this.dateTime = dateTime;

            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");

            this.RuleFor(v => v.Title)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200)
                .NotEmpty();

            this.RuleFor(x => x.Priority)
                .Must(this.ValidatePriority).WithMessage("Priority supplied is not supported.");

            this.RuleFor(x => x.ExpirationDateOnUtc)
                .Must(this.ValidateExpirationDateOnUtc).WithMessage("Expiration Date must be a future date.");
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

        private bool ValidateExpirationDateOnUtc(DateTime? expirationDateOnUtc)
        {
            if (expirationDateOnUtc.HasValue && expirationDateOnUtc.Value < this.dateTime.UtcNow)
            {
                return false;
            }

            return true;
        }
    }
}