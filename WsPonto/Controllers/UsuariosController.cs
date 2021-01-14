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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ChaveId"></param>
        /// <returns></returns>
        [HttpPost]
        //[AllowAnonymous]
        [EnableCors("AlowsCors")]
        [Route("Get")]
        [Authorize(Roles = "administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Get(Int64 pId)
        {
            try
            {
                var usuario = contexto.ObterChave(pId);

                if (usuario == null)
                {
                    return BadRequest("Usuário ou Senha não localizado!!");
                }

                return Ok(usuario);

                //var access_token = TokenServices.GenerateToken(usuario);

                //usuario.Senha = "";
                //return Created("api/Authenticate", new
                //{
                //    //usuario = usuario,
                //    access_token = access_token
                //});

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
