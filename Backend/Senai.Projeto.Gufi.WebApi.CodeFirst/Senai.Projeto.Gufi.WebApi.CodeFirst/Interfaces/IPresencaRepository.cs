using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();

        void Cadastrar(Presenca novaPresenca);

        void Atualizar(int id, Presenca presencaAtualizado);

        void Deletar(int id);

        Presenca BuscarPorId(int id);
    }
}
