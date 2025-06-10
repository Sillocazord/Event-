using Azure;
using Azure.AI.ContentSafety;
using Eventplus_api_senai.Context;
using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ContentSafetyClient _contentSafetyClient;
        private readonly Event_Context _contexto;
       
        public FeedbackController(ContentSafetyClient contentSafetyClient,IFeedbackRepository feedbackRepository, Event_Context contexto)
        {
            _feedbackRepository = feedbackRepository;
            _contentSafetyClient = contentSafetyClient;
            _contexto = contexto;
        }


        /// <summary>
        /// Endpoint para cadastrar Feedback/ComentarioEventos
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Feedback feedback) 
        {
            try
            {
                Evento? eventoBuscado = _contexto.Evento.FirstOrDefault(e => e.EventoID == feedback.EventoID);
                if (eventoBuscado == null)
                {
                    return NotFound("Evento não encontrado");
                }

                if (eventoBuscado.DataEvento >= DateTime.UtcNow)
                {
                    return BadRequest("Não é possível comentar um evento que ainda não aconteceu!");
                }

                if (string.IsNullOrEmpty(feedback.Descricao)) 
                {
                    return BadRequest("O Texto a ser moderado não pode estar vazio!");
                }
                //Criar objeto de análise do content safety
                var request = new AnalyzeTextOptions(feedback.Descricao);

                //Chamar a API d Content Safety
                Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

                //Verificar se o texto analisado tem alguma severidade ou indecencia(ofensivo)
                bool temConteudoImpropio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);
                //caso aqui dê true, comentario exibe sera falso e não ira exiir porque é ofensivo, caso contrario, o comentario pode ser exibido
                //Se o conteudo for imprópio, não exibe, caso contrário, exibe
                feedback.Exibir = !temConteudoImpropio;

                //Cadastra de fato o comentário
                _feedbackRepository.Cadastrar(feedback);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }        
        }

        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetExibe(Guid id)
        {
            try
            {
                return Ok(_feedbackRepository.ListarSomenteExibe(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Endpoint para listar Feedbacks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_feedbackRepository.Listar(id));

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
        //[Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _feedbackRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
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
        [Authorize]
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

