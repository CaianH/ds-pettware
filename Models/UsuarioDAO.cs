using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class UsuarioDAO : IDAO<Usuario>
    {

        private static conexao conn;

        public UsuarioDAO()
        {
            conn = new conexao();
        }
        public Usuario GetByUsuario(string usuarioNome, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Usuario LEFT JOIN Funcionario ON Funcionario.cod_func = Funcionario.cod_func " +
                    "WHERE nome_usu = @usuario AND senha_usu = @senha";

                query.Parameters.AddWithValue("@usuario", usuarioNome);
                query.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader reader = query.ExecuteReader();

                Usuario usuario = null;

                while (reader.Read())
                {
                    usuario = Usuario.GetInstance();
                    usuario.Id = reader.GetInt32("cod_usu");
                    usuario.Nome = reader.GetString("nome_usu");
                    usuario.Funcionario = new Funcionarios() { Codigo = reader.GetInt32("cod_func"), Nome = reader.GetString("nome_func") };
                }

                return usuario;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public void Delete(Usuario t)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Usuario t)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
