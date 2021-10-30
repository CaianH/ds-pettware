using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE
{
    public class Produtos

    {

        public string Descricao { get; set; }

        public string Marca { get; set; }

        public int Peso { get; set; }

        public int Preco { get; set; }

        public double PrecoComDesconto { get; set; }

        public int QtdEmEstoque { get; set; }

        public int Codigo { get; set; }

        private bool _selected = false;

        public bool IsSelected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

    }
}
