using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
         GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            usuarioBuscado.DataNascimento = usuarioAtualizado.DataNascimento;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Genero = usuarioAtualizado.Genero;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            usuarioBuscado.IdTipoUsuarioNavigation = usuarioAtualizado.IdTipoUsuarioNavigation;
            usuarioBuscado.IdUsuario = usuarioAtualizado.IdUsuario;
            usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            usuarioBuscado.Presenca = usuarioAtualizado.Presenca;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(to => to.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioApagado = new Usuario();
            usuarioApagado = BuscarPorId(id);
            ctx.Usuario.Remove(usuarioApagado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}

    }
}
