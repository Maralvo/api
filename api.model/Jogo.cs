using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public long Versao { get; set; }
        public int Fases { get; set; }
    }
}