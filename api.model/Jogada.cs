using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Jogada
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Jogo Jogo { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Erros { get; set; }
        public int? Acertos { get; set; }
        public int? Pontos { get; set; }
        public string Tempo { get; set; }
        public int? Fases { get; set; }
    }
}