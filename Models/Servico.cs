using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double PrecoNormal { get; set; }
        public double PrecoComDesconto { get; set; }
    }
}
