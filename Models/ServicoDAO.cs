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
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Servico WHERE cod_serv = @id";

                query.Parameters.AddWithValue("@id", t.Id);
                

                var result = query.ExecuteNonQuery();
            } catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public Servico GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Servico WHERE cod_serv = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum Registro encontrado");

                var servico = new Servico();

                while (reader.Read())
                {
                    servico.Id = reader.GetInt32("cod_serv");
                    servico.Nome = reader.GetString("nome_serv");
                    servico.PrecoNormal = reader.GetDouble("preconormal_serv");
                    servico.PrecoComDesconto = reader.GetDouble("precocomdesconto_serv");
                }
                return servico;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
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
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE Servico SET nome_serv = @nome, preconormal_serv = @preconormal," +
                    " precocomdesconto_serv = @precocomdesconto" +
                    " WHERE cod_serv = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@preconormal", t.PrecoNormal);
                query.Parameters.AddWithValue("@precocomdesconto", t.PrecoComDesconto);

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização de registro falhou");
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
    
    }
}
