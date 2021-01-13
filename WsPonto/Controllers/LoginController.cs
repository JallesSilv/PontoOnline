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
        [EnableCors("AlowsCors")]
        [AllowAnonymous]
        [Route("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Authenticate([FromBody] Login pLogin)
        {
            try
            {
                var usuario = contexto.ObterToken(pLogin);

                if (usuario == null)
                {
                    return BadRequest("Usuário ou Senha não localizado!!");
                }

                var access_token = TokenServices.GenerateToken(usuario);

                usuario.Senha = "";
                return Created("api/Authenticate", new
                {
                    //usuario = usuario,
                    access_token = access_token
                });

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);


        [HttpGet]
        [Route("Administrador")]
        //[AllowAnonymous]
        [Authorize(Roles = "Administrador")]
        public string Administrador() => "teste ok ";


        [AllowAnonymous]
        [EnableCors("AlowsCors")]
        //[ApiVersion("1.0")]
        [HttpPost]
        [Route("Post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioAtivo = "";// contexto.ObterUsuario(usuario.Cpf, usuario.Senha);
                if (usuarioAtivo != null)
                {
                    return BadRequest("Usuário já cadastrado!!");
                }
                else
                {
                    //contexto.Adicionar(usuario);
                    return Created("api/usuario", usuario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
