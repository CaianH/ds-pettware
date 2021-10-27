using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE.Models
{
    public class Venda
    {
        public int ID { get; set; }

        public int codCli { get; set; }

        public int codFunc { get; set; }

        public string data { get; set; }
        public string Produto { get; set; }

        public int Quantidade { get; set; }

        public string ValorUnitario { get; set; }

        public string ValorcomDesconto { get; set; }

        public Funcionarios Funcionario { get; set; }
        public Cliente Cliente { get; set; }
    }
}
