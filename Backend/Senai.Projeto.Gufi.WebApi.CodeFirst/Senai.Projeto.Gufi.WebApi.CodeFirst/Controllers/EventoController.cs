using Microsoft.AspNetCore.Mvc;
using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces;
using Senai.Projeto.Gufi.WebApi.CodeFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _eventoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            _eventoRepository.Cadastrar(novoEvento);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put(int id, Evento eventoAtualizado)
        {
            Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

            if (eventoBuscado != null)
            {
                try
                {
                    _eventoRepository.Atualizar(id, eventoAtualizado);
                    return StatusCode(200);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return StatusCode(404);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

            if (eventoBuscado == null)
            {
                return NotFound();
            }
            _eventoRepository.Deletar(id);
            return StatusCode(200);
        }
    }
}
