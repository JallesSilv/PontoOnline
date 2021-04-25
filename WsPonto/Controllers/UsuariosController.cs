using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contratos;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.ServiceToken;

namespace WsPonto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository contexto;
        
            
        public UsuariosController(IUsuarioRepository _contexto)
        {
            contexto = _contexto;
        }

        [HttpGet("administrador")]
        [Authorize(Roles = "Administrador")]
        public string Employee() => "Funcionário";


        [EnableCors("AlowsCors")]
        [HttpGet("GetAll")]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                var teste = contexto.ObterTodos();
                return Ok(teste);
            }
            catch (Exception error)
            {

                return BadRequest($@"Erro: {error.ToString()} ");
            }
        }

        [EnableCors("AlowsCors")]
        [HttpGet("GetId")]
        [Authorize]
        public IActionResult GetId([FromQuery]  Guid pChave)
        {
            try
            {
                var usuario = contexto.UsuarioChave(pChave);

                if (usuario == null)
                {
                    return BadRequest("Usuário ou Senha não localizado!!");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [EnableCors("AlowsCors")]
        [HttpPost("GetUserByAccessToken")]
        public ActionResult<Usuario> GetUserByAccessToken([FromBody] string accessToken)
        {
            try
            {
                Usuario user = contexto.GetUserFromAccessToken(accessToken);

                if (user != null)
                {
                    return user;
                }
                return null;
            }
            catch
            {
                return BadRequest($"");
            }
            
        }
    }
}
