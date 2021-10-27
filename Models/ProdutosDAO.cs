using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class ProdutosDAO : IDAO<Produtos>
    {
        private static conexao conn;

        public ProdutosDAO()
        {
            conn = new conexao();
        }
        public void Delete(Produtos t)
        {
            throw new NotImplementedException();
        }

        public Produtos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Produtos t)
        {
            throw new NotImplementedException();
        }

        public List<Produtos> List()
        {
            try
            {
                List<Produtos> list = new List<Produtos>();

                var query = conn.Query();

                query.CommandText = "SELECT * FROM Produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produtos()
                    {
                        Codigo = reader.GetInt32("cod_prod"),
                        Descricao = reader.GetString("descrição_prod"),
                        PrecoComDesconto = reader.GetDouble("precocomdesconto_serv")


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

        public void Update(Produtos t)
        {
            throw new NotImplementedException();
        }
    }
}
