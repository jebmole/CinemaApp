using CinemaApp.Application.Requests;
using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaRepository _repository;
        public SalaController(ISalaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetSalas());
        }

        [HttpPost]
        public IActionResult Post(CreateSalaRequest request)
        {
            var sala = new Sala
            {
                Activa = request.Activa,
                Capacidad = (int)request.Capacidad,
                EsDinamix = request.EsDinamix,
                Nomenclatura = request.Nomenclatura,
            };

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
