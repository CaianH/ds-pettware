using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;


namespace PETTWARE.Models
{
    class FornecedorDAO : IDAO<Fornecedor>
    {
        private static conexao conn;

        public FornecedorDAO() 
        {
            conn = new conexao();
        }

        public void Delete(Fornecedor t)
        {
            throw new NotImplementedException();
        }

        public Fornecedor GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Fornecedor (cnpj_forn, nome_forn, telefone_forn, email, representante_forn)" +
                    "VALUES ( @cnpj, @nome, @telefone, @email, @representante)";


                query.Parameters.AddWithValue("@nome", t.NomeForn);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@cnpj", t.CNPJ);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@representante", t.RepresentanteForn);

                var result = query.ExecuteNonQuery();
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

        public List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();

                var query = conn.Query();

                query.CommandText = "SELECT * FROM Fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Fornecedor() { 
                   
                        id = reader.GetInt32("cod_forn"),
                        NomeForn = reader.GetString("nome_forn"),
                        Email= reader.GetString("email_forn"),
                        CNPJ= reader.GetString("cnpj_forn"),
                        Telefone = reader.GetString("telefone_forn"),
                        RepresentanteForn = reader.GetString("representante_forn"),

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

        public void Update(Fornecedor t)
        {
            throw new NotImplementedException();
        }
    }
}