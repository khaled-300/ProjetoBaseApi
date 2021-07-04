using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoBase.Model;
using ProjetoBase.Service.Interfaces;
using System.Text.Json;
using System;
using System.Net;


namespace ProjetoBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private ILogger<UsuarioController> _logger;

        private IUsuarioService UsuarioService;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            UsuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
            {
            try
            {
                var retorno = UsuarioService.GetUsuarios();
                return StatusCode((int)HttpStatusCode.OK, JsonSerializer.Serialize(retorno));
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpPut]
        public IActionResult AddUsuario([FromBody] Usuario request)
        {
            try
            {
                UsuarioService.AddUsuario(request);

                return StatusCode((int)HttpStatusCode.OK, "Usuario foi criado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

        }


        [HttpPost]
        public IActionResult UpdateUsuario([FromBody] Usuario request)
        {
            try
            {

                UsuarioService.UpdateUsuario(request);

                return StatusCode((int)HttpStatusCode.OK, "Usuario foi atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

        }


        [HttpDelete]
        public IActionResult DeleteUsuario([FromBody] Usuario request)
        {
            try
            {
                UsuarioService.DeleteUsuario(request);

                return StatusCode((int)HttpStatusCode.OK, "Usuario deletado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

        }

    }
}
