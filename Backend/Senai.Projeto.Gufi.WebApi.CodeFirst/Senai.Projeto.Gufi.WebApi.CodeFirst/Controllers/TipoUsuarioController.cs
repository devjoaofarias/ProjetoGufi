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

    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _tipoUsuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
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
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound();
            }
            _tipoUsuarioRepository.Deletar(id);
            return StatusCode(200);
        }
    }
}

