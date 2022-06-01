using AutoMapper;
using CinemaApp.Application.Requests;
using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Application.Mappings
{
    public class SalaMappingProfile : Profile
    {
        public SalaMappingProfile()
        {
            CreateMap<CreateSalaRequest, Sala>();
            CreateMap<Sala, CreateSalaRequest>();

            CreateMap<UpdateSalaRequest, Sala>();
            CreateMap<Sala, UpdateSalaRequest>();
        }
    }
}
