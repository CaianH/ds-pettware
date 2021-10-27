using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public double ValorcomDesconto { get; set; }
        public double Valortotal { get; set; }
        public string FormaPagamento { get; set; }
        public Funcionarios Funcionario { get; set; }
        public Cliente Cliente { get; set; }

        public List<VendaItem> Itens { get; set; } = new List<VendaItem>();
    }
}
