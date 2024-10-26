namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Queries.GetProjectToDosAsCsv
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries;

    public class GetProjectToDosAsCsvFileQueryValidator : AbstractValidator<GetProjectToDosAsCsvFileQuery>
    {
        public GetProjectToDosAsCsvFileQueryValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}