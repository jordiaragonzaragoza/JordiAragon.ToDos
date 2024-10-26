namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Mappers.V1
{
    using AutoMapper;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Controllers.V1;

    public class Mapper : Profile
    {
        public Mapper()
        {
            this.MapAccount();
            this.MapContributor();
            this.MapProject();
            this.MapToDoItem();
        }
    }
}
