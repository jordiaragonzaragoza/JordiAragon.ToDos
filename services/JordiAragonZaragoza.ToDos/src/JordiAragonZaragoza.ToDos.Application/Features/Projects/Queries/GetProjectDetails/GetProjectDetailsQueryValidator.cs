namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Queries.GetProjectDetails
{
    using System;
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries;

    public class GetProjectDetailsQueryValidator : AbstractValidator<GetProjectDetailsQuery>
    {
        public GetProjectDetailsQueryValidator()
        {
            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}