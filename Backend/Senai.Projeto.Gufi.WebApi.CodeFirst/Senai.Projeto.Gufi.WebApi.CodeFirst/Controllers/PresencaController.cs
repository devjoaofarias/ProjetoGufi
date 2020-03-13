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

    public class PresencaController : ControllerBase
    {
        private IPresencaRepository _presencaRepository;

        public PresencaController()
        {
            _presencaRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_presencaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _presencaRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Presenca novaPresenca)
        {
            _presencaRepository.Cadastrar(novaPresenca);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put(int id, Presenca presencaAtualizada)
        {
            Presenca presencaBuscada = _presencaRepository.BuscarPorId(id);

            if (presencaBuscada != null)
            {
                try
                {
                    _presencaRepository.Atualizar(id, presencaAtualizada);
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
            Presenca presencaBuscada = _presencaRepository.BuscarPorId(id);

            if (presencaBuscada == null)
            {
                return NotFound();
            }
            _presencaRepository.Deletar(id);
            return StatusCode(200);
        }
    }
}
