using MediatR;
using Microsoft.AspNetCore.Mvc;
using Million.Sales.Application.Property.GetAll;
using Million.Sales.Application.Property.GetDetailsById;

namespace Million.Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Permite obtener todas las propiedades.
        /// </summary>
        /// <returns>Listado de todas las propiedades.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            try
            {
                var query = new GetAllPropertiesQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal error. {ex.Message}");
            }
        }

        /// <summary>
        /// Permite obtener los detalles de una propiedad en particular.
        /// </summary>
        /// <param name="id">Id de la propiedad</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyDetails(string id)
        {
            try
            {
                var query = new GetDetailsByIdQuery(id);
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal error. {ex.Message}");
            }
        }
    }
}
