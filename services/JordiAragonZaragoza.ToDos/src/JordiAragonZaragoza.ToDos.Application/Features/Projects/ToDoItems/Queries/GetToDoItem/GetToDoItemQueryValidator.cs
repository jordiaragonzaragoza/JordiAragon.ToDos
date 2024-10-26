namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Queries.GetToDoItem
{
    using System;
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public class GetToDoItemQueryValidator : AbstractValidator<GetToDoItemQuery>
    {
        public GetToDoItemQueryValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}