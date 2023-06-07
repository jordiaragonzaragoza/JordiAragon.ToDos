namespace JordiAragon.ToDos.Infrastructure.Mappers
{
    using AutoMapper;
    using JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps;

    public class Mapper : Profile
    {
        public Mapper()
        {
            this.MapGeolocation();
        }
    }
}