using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE.Models
{
    public class VendaItem
    {
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public Produtos Produto { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }

        public double ValorTotal { get; set; }




    }
}
