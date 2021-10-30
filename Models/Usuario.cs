using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public Funcionarios Funcionario { get; set; }

        private static Usuario _instance;
        private Usuario() { }

        public static Usuario GetInstance()
        {
            if (_instance == null)
                _instance = new Usuario();

            return _instance;
        }

        public static bool Login(string usuario,string senha)
        {
            var user = new UsuarioDAO().GetByUsuario(usuario, senha);

            if (user != null)
                return true;

            return false;
        }
    }
}
