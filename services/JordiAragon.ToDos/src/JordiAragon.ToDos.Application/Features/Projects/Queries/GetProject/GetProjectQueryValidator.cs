namespace JordiAragon.ToDos.Application.Features.Projects.Queries.GetProject
{
    using System;
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries;

    public class GetProjectQueryValidator : AbstractValidator<GetProjectQuery>
    {
        public GetProjectQueryValidator()
        {
            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}