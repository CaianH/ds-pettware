using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class ServicoDAO : IDAO<Servico>
    {
        private static conexao conn;

        public ServicoDAO()
        {
            conn = new conexao();
        }
        public void Delete(Servico t)
        {
            throw new NotImplementedException();
        }

        public Servico GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Servico t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Servico ( nome_serv,preconormal_serv, precocomdesconto_serv)" +
                    "VALUES ( @nome, @preconormal, @precocomdesconto)";

  
                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@preconormal", t.PrecoNormal);
                query.Parameters.AddWithValue("@precocomdesconto", t.PrecoComDesconto);

                var result = query.ExecuteNonQuery();
            } catch (Exception e)
            {
                throw e;
            } finally
            {
                conn.Close();
            }
        }

        public List<Servico> List()
        {
            try
            {
                List<Servico> list = new List<Servico>();

                var query = conn.Query();

                query.CommandText = "SELECT * FROM Servico";

                MySqlDataReader reader = query.ExecuteReader();

                while(reader.Read())
                {
                    list.Add(new Servico() { 
                    Id = reader.GetInt32("cod_serv"),
                    Nome = reader.GetString("nome_serv"),
                    PrecoNormal = reader.GetDouble("preconormal_serv"),
                    PrecoComDesconto = reader.GetDouble("precocomdesconto_serv")

                    });
                }

                return list;
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

        public void Update(Servico t)
        {
            throw new NotImplementedException();
        }
    }
}
