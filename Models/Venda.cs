﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE
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
    }
}
