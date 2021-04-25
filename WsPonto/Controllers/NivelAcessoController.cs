using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contratos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WsPonto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelAcessoController : ControllerBase
    {
        private readonly INivelAcessoRepository repository;

        public NivelAcessoController(INivelAcessoRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pToken"></param>
        /// <returns></returns>
        /// <response code="200">Retorno Ok</response>
        /// <response code="404">Item Null</response>  
        //[ApiVersion("1.0")]
        [HttpGet("GetAll")]
        [EnableCors("AlowsCors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAll()
        {
            try
            {
                return Ok( repository.ObterTodos() );
            }
            catch (Exception error)
            {

                return BadRequest($@"Erro: {error.Message} ");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pToken"></param>
        /// <returns></returns>
        /// <response code="200">Retorno Ok</response>
        /// <response code="404">Item Null</response>  
        //[ApiVersion("1.0")]
        [HttpGet("GetId")]
        [EnableCors("AlowsCors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetId(Guid pChave)
        {
            try
            {
                return Ok(repository.ObterChave(pChave));
            }
            catch (Exception error)
            {

                return BadRequest($@"Erro: {error.Message} ");
            }
        }

    }
}
