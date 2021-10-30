using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class DespesasDAO : IDAO<Despesas>
    {
        private static conexao conn;


        public DespesasDAO()
        {
            conn = new conexao();
        }

        public void Delete(Despesas t)
        {
            throw new NotImplementedException();
        }

        public Despesas GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Despesas t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO despesas (tipo_desp, nome_desp) " +
                    "VALUES  (@tipo despesa, @nome despesa)";

               
                query.Parameters.AddWithValue("@tipo despesa", t.TipoDespesa);
                query.Parameters.AddWithValue("@nome despesa", t.NomeDespesa);
               


                var result = query.ExecuteNonQuery();



            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public List<Despesas> List()
        {
            try
            {
                List<Despesas> list = new List<Despesas>();

                var query = conn.Query();

                query.CommandText = "SELECT * FROM Despesas";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Despesas()
                    {

                        Id = reader.GetInt32("cod_forn"),
                        TipoDespesa = reader.GetString("nome_desp"),
                        NomeDespesa = reader.GetString("email_desp"),

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

        public void Update(Despesas t)
        {
            throw new NotImplementedException();
        }
    }
}