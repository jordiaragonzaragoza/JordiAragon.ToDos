namespace JordiAragon.ToDos.Application.Mappers
{
    using AutoMapper;
    using JordiAragon.ToDos.Application.Features.Contributors.Queries;
    using JordiAragon.ToDos.Application.Features.Projects.Queries;
    using JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Queries;

    public class Mapper : Profile
    {
        public Mapper()
        {
            this.MapToDoItems();
            this.MapProjects();
            this.MapContributors();
        }
    }
}
