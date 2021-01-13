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

        //[AllowAnonymous]
        //[EnableCors("AlowsCors")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("User")]
        [Authorize(Roles = "Administrador")]
        public string Usuarios() => "teste ok ";
        

        //[HttpPost]
        ////[AllowAnonymous]
        //[EnableCors("AlowsCors")]
        //[Route("Usuarios")]
        //[Authorize(Roles = "Administrador, Funcionario")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult Gett(Usuario pValor)
        //{
        //    try
        //    {
        //        var usuario = contexto.ObterUsuario(pValor);

        //        if (usuario == null)
        //        {
        //            return BadRequest("Usuário ou Senha não localizado!!");
        //        }

        //        var access_token = TokenServices.GenerateToken(usuario);

        //        usuario.Senha = "";
        //        return Created("api/Authenticate", new
        //        {
        //            //usuario = usuario,
        //            access_token = access_token
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro: {ex.Message}");
        //    }
        //}
    }
}
