namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.SetLocationToDoItem
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class SetLocationToDoItemCommandValidator : AbstractValidator<SetLocationToDoItemCommand>
    {
        public SetLocationToDoItemCommandValidator()
        {
            this.RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Latitude must be in range [-90; 90]");

            this.RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be in range [-180; 180]");
        }
    }
}