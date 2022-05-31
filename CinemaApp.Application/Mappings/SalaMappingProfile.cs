using AutoMapper;
using CinemaApp.Application.Requests;
using CinemaApp.Domain.Entities;

namespace CinemaApp.Application.Mappings
{
    public class SalaMappingProfile : Profile
    {
        public SalaMappingProfile()
        {
            CreateMap<Sala, CreateSalaRequest>();
            CreateMap<CreateSalaRequest, Sala>();
        }
    }
}
