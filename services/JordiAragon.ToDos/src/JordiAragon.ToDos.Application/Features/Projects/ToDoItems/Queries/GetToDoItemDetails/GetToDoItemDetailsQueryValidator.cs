namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Queries.GetToDoItemDetails
{
    using System;
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public class GetToDoItemDetailsQueryValidator : AbstractValidator<GetToDoItemDetailsQuery>
    {
        public GetToDoItemDetailsQueryValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}