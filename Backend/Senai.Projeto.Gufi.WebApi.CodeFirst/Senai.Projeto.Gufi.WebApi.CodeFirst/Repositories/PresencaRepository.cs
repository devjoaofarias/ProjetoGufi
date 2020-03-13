using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Presenca presencaAtualizada)
        {
            Presenca presencaBuscada = ctx.Presenca.Find(id);
            presencaBuscada.IdEvento = presencaAtualizada.IdEvento;
            presencaBuscada.IdEventoNavigation = presencaAtualizada.IdEventoNavigation;
            presencaBuscada.IdPresenca = presencaAtualizada.IdPresenca;
            presencaBuscada.IdUsuario = presencaAtualizada.IdUsuario;
            presencaBuscada.IdUsuarioNavigation = presencaAtualizada.IdUsuarioNavigation;
            presencaBuscada.Situacao = presencaAtualizada.Situacao;

            ctx.SaveChanges();
        }

        public Presenca BuscarPorId(int id)
        {
            return ctx.Presenca.FirstOrDefault(to => to.IdPresenca == id);
        }

        public void Cadastrar(Presenca novaPresenca)
        {
            ctx.Presenca.Add(novaPresenca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Presenca presencaApagada = new Presenca();
            presencaApagada = BuscarPorId(id);
            ctx.Presenca.Remove(presencaApagada);
            ctx.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.ToList();
        }
    }
}
