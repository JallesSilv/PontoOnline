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
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository contexto;

        public LoginController(IUsuarioRepository _contexto)
        {
            contexto = _contexto;
        }

        
        [HttpPost]
        [AllowAnonymous]
        [EnableCors("AlowsCors")]
        [Route("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Authenticate([FromBody] Usuario user)
        {
            try
            {
                var usuario = await contexto.ObterToken(user);

                if (usuario == null)
                {
                    return BadRequest("Usuário ou Senha não localizado!!");
                }

                var access_token = TokenServices.GenerateToken(usuario);
                usuario = contexto.ObterChave(usuario.ChaveUsuario);
                usuario.Senha = "";

                return Created("api/Authenticate", new
                {
                    //user = usuario,
                    access_token = access_token
                });

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [EnableCors("AlowsCors")]
        [Route("Registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Registrar([FromBody] Usuario pLogin)
        {
            try
            {
                var usuario = await contexto.Registrar(pLogin);

                if (usuario == null)
                {
                    return BadRequest("Usuário ou Senha não localizado!!");
                }
                return Created("api/Authenticate", new
                {
                    usuario
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
    }
}
