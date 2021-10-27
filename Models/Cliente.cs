using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE.Models
{
    public class Cliente
    {
        public int Cod { get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public DateTime datanasc { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

    }
}
