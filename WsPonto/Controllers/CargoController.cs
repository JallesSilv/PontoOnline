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

namespace WsPonto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoRepository repository;

        public CargoController(ICargoRepository _repository)
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
        //[Authorize(Roles = "Administrador")]        
        [HttpGet("GetAll")]
        [EnableCors("AlowsCors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(repository.ObterListaCargo());
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
        [EnableCors("AlowsCors")]
        [HttpGet("GetId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetId(Guid pChave )
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pToken"></param>
        /// <returns></returns>
        /// <response code="200">Retorno Ok</response>
        /// <response code="404">Item Null</response>  
        //[ApiVersion("1.0")]
        [EnableCors("AlowsCors")]
        [HttpPut("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Edit(Guid pChave, [FromBody]Cargo pCargo)
        {
            try
            {
                repository.Edit(pChave, pCargo);
                return Ok("Alterado com Sucesso!!");
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
        [EnableCors("AlowsCors")]
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cargo> Create(Cargo pCargo)
        {
            try
            {
                var result = repository.Create(pCargo);
                return Created("Gravado", result);
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
        [EnableCors("AlowsCors")]
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(Guid pChave)
        {
            try
            {
               repository.DeleteId(pChave);

                return Ok($"Excluido com Sucesso: Id:{pChave}");
            }
            catch (Exception error)
            {

                return BadRequest($@"Erro: {error.Message} ");
            }
        }


    }
}
