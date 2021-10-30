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
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO cliente (nome_cli, cpf_cli, rg_cli, datanasc_cli, email_cli, telefone_cli, naturalidade_cli, nacionalidade_cli" +
                    "VALUES (@nome, @cpf, @rg, @datanasc, @telefone, @email, @naturaldade, @nacionalidade)";

                query.Parameters.AddWithValue("@nome", t.nome);
                query.Parameters.AddWithValue("@cpf", t.cpf);
                query.Parameters.AddWithValue("@rg", t.rg);
                query.Parameters.AddWithValue("@datanasc", t.datanasc.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@telefone", t.telefone);
                query.Parameters.AddWithValue("@email", t.email);
                query.Parameters.AddWithValue("@naturalidade", t.naturalidade);
                query.Parameters.AddWithValue("@nacionalidade", t.nacionalidade);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("o registro esta faltando");

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
