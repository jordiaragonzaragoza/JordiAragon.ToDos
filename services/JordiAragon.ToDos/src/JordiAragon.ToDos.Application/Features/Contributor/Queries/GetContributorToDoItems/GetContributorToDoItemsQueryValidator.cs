namespace JordiAragon.ToDos.Application.Features.Contributor.Queries.GetContributorToDoItems
{
    using System;
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Queries;

    public class GetContributorToDoItemsQueryValidator : AbstractValidator<GetContributorToDoItemsQuery>
    {
        public GetContributorToDoItemsQueryValidator()
        {
            this.RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}