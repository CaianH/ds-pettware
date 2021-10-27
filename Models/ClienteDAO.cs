using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class ClienteDAO : IDAO<Cliente>
    {
        private static conexao conn;

        public ClienteDAO()
        {
            conn = new conexao();
        }
        public void Delete(Cliente t)
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cliente t)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();

                var query = conn.Query();

                query.CommandText = "SELECT * FROM Cliente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Cliente()
                    {
                        Cod = reader.GetInt32("cod_cli"),
                        nome = reader.GetString("nome_cli"),


                    });
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Cliente t)
        {
            throw new NotImplementedException();
        }
    }
}
