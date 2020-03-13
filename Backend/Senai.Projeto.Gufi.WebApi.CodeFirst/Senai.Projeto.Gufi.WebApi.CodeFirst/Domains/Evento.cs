using System;
using System.Collections.Generic;

namespace Senai.Projeto.Gufi.WebApi.CodeFirst.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }
        public int? IdInstituicao { get; set; }
        public int? IdTipoEvento { get; set; }
        public string NomeEvento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public bool? AcessoLivro { get; set; }

        public Instituicao IdInstituicaoNavigation { get; set; }
        public TipoEvento IdTipoEventoNavigation { get; set; }
        public ICollection<Presenca> Presenca { get; set; }
    }
}
