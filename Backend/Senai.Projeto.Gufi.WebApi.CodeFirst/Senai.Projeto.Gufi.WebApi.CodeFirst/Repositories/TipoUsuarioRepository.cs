using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);
            tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(to => to.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuario.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioApagado = new TipoUsuario();
            tipoUsuarioApagado = BuscarPorId(id);
            ctx.TipoUsuario.Remove(tipoUsuarioApagado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}

