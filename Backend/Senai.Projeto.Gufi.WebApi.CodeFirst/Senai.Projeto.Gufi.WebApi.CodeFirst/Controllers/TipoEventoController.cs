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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepositroy;

        public TipoEventoController()
        {
            _tipoEventoRepositroy = new TipoEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoEventoRepositroy.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _tipoEventoRepositroy.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post (TipoEvento novoTipoEvento)
        {
            _tipoEventoRepositroy.Cadastrar(novoTipoEvento);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put (int id, TipoEvento tipoEventoAtualizado)
        {
            TipoEvento tipoEventoBuscado =_tipoEventoRepositroy.BuscarPorId(id);

            if(tipoEventoBuscado != null)
            {
                try
                {
                    _tipoEventoRepositroy.Atualizar(id, tipoEventoAtualizado);
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
        public IActionResult Delete (int id)
        {
            TipoEvento tipoEventoBuscado = _tipoEventoRepositroy.BuscarPorId(id);

            if(tipoEventoBuscado == null)
            {
                return NotFound();
            }
            _tipoEventoRepositroy.Deletar(id);
            return StatusCode(200);
        }
    }
}
