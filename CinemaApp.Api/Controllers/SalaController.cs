using CinemaApp.Application.Interfaces;
using CinemaApp.Application.Requests;
using CinemaApp.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace CinemaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [Produces("application/json")]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _service;

        public SalaController(ISalaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna un listado con todas las salas registradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<SalaResponse>))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ProblemDetails))]
        public IActionResult Get()
        {
            return Ok(_service.GetSalas());
        }

        /// <summary>
        /// Permite consultar la información de una sala por su id
        /// </summary>
        /// <param name="request">Identificador de la sala a buscar</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SalaResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get([FromRoute] GetSalaByIdRequest request)
        {
            return Ok(_service.GetSalaById(request.Id));
        }

        /// <summary>
        /// Permite insertar una sala
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post(CreateSalaRequest request)
        {
            _service.InsertSala(request);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Put(UpdateSalaRequest request)
        {
            _service.UpdateSala(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Delete([FromRoute] DeleteSalaRequest request)
        {
            _service.DeleteSala(request.Id);
            return Ok();
        }
    }
}
