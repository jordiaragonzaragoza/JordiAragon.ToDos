namespace JordiAragonZaragoza.ToDos.Infrastructure.Mappers
{
    using AutoMapper;
    using JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps;

    public class Mapper : Profile
    {
        public Mapper()
        {
            this.MapGeolocation();
        }
    }
}