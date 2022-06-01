using AutoMapper;
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
            _repository.InsertSala(sala);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateSalaRequest request)
        {
            var sala = _mapper.Map<Sala>(request);
            _repository.UpdateSala(sala);
            return Ok();
        }
    }
}
