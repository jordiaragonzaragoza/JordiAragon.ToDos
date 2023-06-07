namespace JordiAragon.ToDos.Application.Features.Contributor.Queries.GetContributorsPaginated
{
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Queries;

    public class GetContributorsPaginatedQueryValidator : AbstractValidator<GetContributorsPaginatedQuery>
    {
        public GetContributorsPaginatedQueryValidator()
        {
            this.RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            this.RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}