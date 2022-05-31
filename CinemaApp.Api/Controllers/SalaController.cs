using AutoMapper;
using CinemaApp.Application.Requests;
using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaRepository _repository;
        private readonly IMapper _mapper;

        public SalaController(ISalaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetSalas());
        }

        [HttpPost]
        public IActionResult Post(CreateSalaRequest request)
        {
            var sala = _mapper.Map<Sala>(request);
            //var sala = new Sala
            //{
            //    Activa = request.Activa,
            //    Capacidad = (int)request.Capacidad,
            //    EsDinamix = request.EsDinamix,
            //    Nomenclatura = request.Nomenclatura,
            //};

            _repository.InsertSala(sala);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateSalaRequest request)
        {
            var sala = new Sala
            {
                IdSala = request.IdSala,
                Activa = request.Activa,
                Capacidad = request.Capacidad,
                EsDinamix = request.EsDinamix,
                Nomenclatura = request.Nomenclatura,
            };

            _repository.UpdateSala(sala);
            return Ok();
        }
    }
}
