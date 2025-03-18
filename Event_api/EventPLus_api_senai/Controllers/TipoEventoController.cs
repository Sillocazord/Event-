﻿using Eventplus_api_senai.Domais;
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


        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                _tipoeventoRepository.Cadastro(novoTipoEvento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        [HttpGet("BuscarPorId/{id}")]
        public ActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento tipoBuscado = _tipoeventoRepository.BuscarPorId(id);
                return Ok(tipoBuscado);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id) 
        {
            try
            {
                _tipoeventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        
        
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoeventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
       
    }
}
