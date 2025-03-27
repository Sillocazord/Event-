using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus_api_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoeventoRepository;
        public TipoEventoController(ITipoEventoRepository eventoRepository)
        {
            _tipoeventoRepository = eventoRepository;
        }

        /// <summary>
        /// Endpoint para listar tipos de eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get() 
        {
            try
            {
                return Ok(_tipoeventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }

        /// <summary>
        /// Endpoint para cadastras novos tipos de eventos
        /// </summary>
        /// <param name="novoTipoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                _tipoeventoRepository.Cadastro(novoTipoEvento);
                return StatusCode(201, novoTipoEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para buscar tipos de eventos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public ActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tipoeventoRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        /// <summary>
        /// Endpoint para deletar tipos de eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id) 
        {
            try
            {
                _tipoeventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoeventoRepository.Atualizar(id, tipoEvento);
                return StatusCode(204, tipoEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
       
    }
}
