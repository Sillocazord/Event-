using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus_api_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;

        }

        /// <summary>
        /// Endpoint para cadastrar Feedbackss
        /// </summary>
        /// <param name="novoFeedback"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Feedback novoFeedback)
        {
            try
            {
                _feedbackRepository.Cadastrar(novoFeedback);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }

        /// <summary>
        /// Endpoint para listar Feedbacks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(_feedbackRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para deletar Feedbacks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _feedbackRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception )
            {
                throw;
            }
        
        }
        
        /// <summary>
        /// Endpoint para buscar Feedbacks por Id dos usuarios
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <param name="EventoId"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorIdUsuario/{UsuarioId}")]
        public IActionResult GetById(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                Feedback novoFeedback = _feedbackRepository.BuscarPorIdUsuario(UsuarioId, EventoId);
                return Ok(novoFeedback);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }



    }
}
