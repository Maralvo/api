using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Usuario
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int? Pontos { get; set; }
    }
}