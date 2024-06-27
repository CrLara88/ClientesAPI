using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EdenredTest.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using EdenredTest.Model.Authentication;
using System.Text;
using EdenredTest.Model.Authentication.Interfaces;
using EdenredTest.Model.Interfaces;


namespace EdenredTest.Controllers
{
    /// <summary>
    /// Controlador para autenticar usuarios y generar token JWT
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly IManejoJwt _manejoJwt;
        private readonly IClientDao _iClientDao;

        public AutenticacionController(IManejoJwt manejoJwt, IClientDao iClientDao)
        {
            this._manejoJwt = manejoJwt;
            this._iClientDao = iClientDao;
        }

        /// <summary>
        /// Endpoint que permite autenticar a un usuario, mediante email y password, 
        /// para generar el token correspondiente 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Éxito al autenticar usuario</response>
        /// <response code="401">Usuario no autorizado para consumir endopoints de clientes</response>
        [HttpPost]
        [Route("Validar")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public IActionResult Validar([FromBody] User request) 
        {
            ResultObj resultObj = new();

            if (_iClientDao.ValidateUser(request.Email, request.Password, ref resultObj))
            {
                var tokenResult = this._manejoJwt.GenerarToken(request.Email, request.Password);

                return StatusCode(StatusCodes.Status200OK, new { Token = tokenResult });
            }
            else 
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { Token = "" });
            }
        }
    }
}
