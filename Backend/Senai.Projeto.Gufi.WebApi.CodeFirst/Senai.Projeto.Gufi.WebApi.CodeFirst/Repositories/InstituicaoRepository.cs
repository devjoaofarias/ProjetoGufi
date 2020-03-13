using Senai.Projeto.Gufi.WebApi.CodeFirst.Domains;
using Senai.Projeto.Gufi.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.Find(id);
            instituicaoBuscada.Cnpj = instituicaoAtualizada.Cnpj;
            instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;
            instituicaoBuscada.Evento = instituicaoAtualizada.Evento;
            instituicaoBuscada.IdInstituicao = instituicaoAtualizada.IdInstituicao;
            instituicaoBuscada.NomeFantasia = instituicaoAtualizada.NomeFantasia;
            
            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicao.FirstOrDefault(to => to.IdInstituicao == id);
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicao.Add(novaInstituicao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Instituicao instituicaoApagada = new Instituicao();
            instituicaoApagada = BuscarPorId(id);
            ctx.Instituicao.Remove(instituicaoApagada);
            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
