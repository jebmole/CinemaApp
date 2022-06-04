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

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] GetSalaByIdRequest request)
        {
            return Ok(_repository.GetSalaById(request.Id));
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

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] DeleteSalaRequest request)
        {
            _repository.DeleteSala(request.Id);
            return Ok();
        }
    }
}
