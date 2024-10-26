namespace JordiAragonZaragoza.ToDos.Application.Features.Contributors.Queries.GetContributor
{
    using System;
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Queries;

    public class GetContributorQueryValidator : AbstractValidator<GetContributorQuery>
    {
        public GetContributorQueryValidator()
        {
            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}