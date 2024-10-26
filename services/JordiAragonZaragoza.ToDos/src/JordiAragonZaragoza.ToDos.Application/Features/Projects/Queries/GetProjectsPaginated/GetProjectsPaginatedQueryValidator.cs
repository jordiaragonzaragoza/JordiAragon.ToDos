namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Queries.GetProjectsPaginated
{
    using System;
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries;

    public class GetProjectsPaginatedQueryValidator : AbstractValidator<GetProjectsPaginatedQuery>
    {
        public GetProjectsPaginatedQueryValidator()
        {
            this.RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            this.RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}