using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Evento eventoAtualizado)
        {
            Evento eventoBuscado = ctx.Evento.Find(id);
            eventoBuscado.AcessoLivro = eventoAtualizado.AcessoLivro;
            eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
            eventoBuscado.Descricao = eventoAtualizado.Descricao;
            eventoBuscado.IdEvento = eventoAtualizado.IdEvento;
            eventoBuscado.IdInstituicao = eventoAtualizado.IdInstituicao;
            eventoBuscado.IdInstituicaoNavigation = eventoAtualizado.IdInstituicaoNavigation;
            eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            eventoBuscado.IdTipoEventoNavigation = eventoAtualizado.IdTipoEventoNavigation;
            eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
            eventoBuscado.Presenca = eventoAtualizado.Presenca;

            ctx.SaveChanges();
        }

        public Evento BuscarPorId(int id)
        {
            return ctx.Evento.FirstOrDefault(to => to.IdEvento == id);
        }

        public void Cadastrar(Evento novoEvento)
        {
            ctx.Evento.Add(novoEvento);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Evento eventoApagado = new Evento();
            eventoApagado = BuscarPorId(id);
            ctx.Evento.Remove(eventoApagado);
            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }
    }
}