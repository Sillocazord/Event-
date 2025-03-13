using Eventplus_api_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus_api_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoeventoRepository;
        public TipoEventoController(ITipoEventoRepository eventoRepository)
        {
            _tipoeventoRepository = eventoRepository;
        }

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




    }
}
