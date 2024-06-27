using EdenredTest.Model.Dto;
using EdenredTest.Model.Interfaces;
using EdenredTest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EdenredTest.Controllers
{
    /// <summary>
    /// Controlador para administrar clientes
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientDao _iClientDao;

        public ClientController(IClientDao clientDao)
        {
            _iClientDao = clientDao;
        }

        /// <summary>
        /// Endpoint para la creación de clientes
        /// </summary>
        /// <param name="client"></param>
        /// <response code="200">Éxito en creación de cliente</response>
        /// <response code="400">Error al procesar petición</response>
        /// <response code="401">Usuario no autorizado para consumir endopoints de clientes</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPost("CreateClient")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateClient(ClientManagementDto client)
        {
            ResultObj resultObj = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _iClientDao.CreateClient(client, ref resultObj);

                if (resultObj.IsError)
                {
                    return StatusCode(500);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Endpoint para la actualización de un cliente en particular según su Id
        /// </summary>
        /// <param name="idClient"></param>
        /// <param name="clientManagementDto"></param>
        /// <response code="200">Éxito en actualización de cliente</response>
        /// <response code="400">Error al procesar petición</response>
        /// <response code="401">Usuario no autorizado para consumir endopoints de clientes</response>
        /// <response code="404">Cliente no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut("UpdateClientById/{idClient}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateClientById(int idClient, [FromBody] ClientManagementDto clientManagementDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ResultObj resultObj = new();

                Client client = _iClientDao.UpdateClient(idClient, clientManagementDto, ref resultObj);

                if (resultObj.IsError)
                {
                    return StatusCode(500);
                }

                if (client is null)
                {
                    return NotFound(clientManagementDto);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Endpoint que permite consultar un cliente por su Id
        /// </summary>
        /// <param name="idClient"></param>
        /// <response code="200">Éxito en consulta de cliente</response>
        /// <response code="401">Usuario no autorizado para consumir endopoints de clientes</response>
        /// <response code="404">Cliente no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("GetClientById/{idClient}")]
        [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetClientById(int idClient)
        {
            ResultObj resultObj = new();

            try
            {
                ClientDto clientDto = _iClientDao.GetClientById(idClient, ref resultObj);

                if (resultObj.IsError)
                {
                    return StatusCode(500);
                }

                if (clientDto is null)
                {
                    return NotFound();
                }

                return Ok(clientDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
     
    }
}
