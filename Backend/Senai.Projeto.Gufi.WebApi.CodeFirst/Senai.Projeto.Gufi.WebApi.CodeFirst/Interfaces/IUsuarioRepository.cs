using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario usuarioAtualizado);

        void Deletar(int id);

        Usuario BuscarPorId(int id);
    }
}
