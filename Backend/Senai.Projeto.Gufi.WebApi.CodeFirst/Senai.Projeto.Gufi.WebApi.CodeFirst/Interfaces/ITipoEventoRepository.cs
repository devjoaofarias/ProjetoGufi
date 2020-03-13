using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces
{
    interface ITipoEventoRepository
    {
        List<TipoEvento> Listar();

        void Cadastrar(TipoEvento novoTipoEvento);

        void Atualizar(int id, TipoEvento tipoEventoAtualizado);

        void Deletar(int id);

        TipoEvento BuscarPorId(int id);
    }
}
