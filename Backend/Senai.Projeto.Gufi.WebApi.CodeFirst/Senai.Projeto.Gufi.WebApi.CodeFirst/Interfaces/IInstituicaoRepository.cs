using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Listar();

        void Cadastrar(Instituicao novaInstituicao);

        void Atualizar(int id, Instituicao instituicaoAtualizada);

        void Deletar(int id);

        Instituicao BuscarPorId(int id);
    }
}
