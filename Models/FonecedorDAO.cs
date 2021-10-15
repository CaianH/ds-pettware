using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using PETTWARE.DataBase;



namespace PETTWARE.Models
{
    class FonecedorDAO : IDAO<Fornecedor>
    {

        private static conexao conn;

        public FonecedorDAO()
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
                query.CommandText = "INSERT INTO fornecedor (cnpj_forn, nome_forn, telefone_forn, email, representante_forn) " +
                    "VALUES  (@cnpj, @nome, @telefone, @email, @representante)";

                query.Parameters.AddWithValue("@cnpj", t. CNPJ);
                query.Parameters.AddWithValue("@nome", t.NomeForn);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@email", t. Email);
                query.Parameters.AddWithValue("@representante", t. RepresentanteForn);

                var result = query.ExecuteNonQuery();



            } catch (Exception e)
            {

            } finally
            {
                conn.Close();
            }
        }

        public List<Fornecedor> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Fornecedor t)
        {
            throw new NotImplementedException();
        }
    }
}
