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

    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_instituicaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _instituicaoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            _instituicaoRepository.Cadastrar(novaInstituicao);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put(int id, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

            if (instituicaoBuscada != null)
            {
                try
                {
                    _instituicaoRepository.Atualizar(id, instituicaoAtualizada);
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
            Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

            if (instituicaoBuscada == null)
            {
                return NotFound();
            }
            _instituicaoRepository.Deletar(id);
            return StatusCode(200);
        }
    }
}
