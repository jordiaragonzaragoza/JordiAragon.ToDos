namespace JordiAragonZaragoza.ToDos.Application.Mappers
{
    using AutoMapper;
    using JordiAragonZaragoza.ToDos.Application.Features.Contributors.Queries;
    using JordiAragonZaragoza.ToDos.Application.Features.Projects.Queries;
    using JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Queries;

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
