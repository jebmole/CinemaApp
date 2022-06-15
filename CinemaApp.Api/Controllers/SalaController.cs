using CinemaApp.Application.Interfaces;
using CinemaApp.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _service;

        public SalaController(ISalaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetSalas());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] GetSalaByIdRequest request)
        {
            return Ok(_service.GetSalaById(request.Id));
        }

        [HttpPost]
        public IActionResult Post(CreateSalaRequest request)
        {
            _service.InsertSala(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateSalaRequest request)
        {
            _service.UpdateSala(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] DeleteSalaRequest request)
        {
            _service.DeleteSala(request.Id);
            return Ok();
        }
    }
}
