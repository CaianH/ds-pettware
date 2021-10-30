using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class FuncionariosDAO : IDAO<Funcionarios>
    {
        private static conexao conn;

        public FuncionariosDAO()
        {
            conn = new conexao();
        }
        public void Delete(Funcionarios t)
        {
            throw new NotImplementedException();
        }

        public Funcionarios GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Funcionarios t)
        {
            try{
                var query = conn.Query();
                query.CommandText = "INSERT INTO funcionario (nome_func, cpf_func, rg_func, datanasc_func, telefone_func, email_func, naturalidade_func, nacionalidade_func, cod_end)" +
                    "VALUES (@nome, @cpf, @rg, @datanasc, @telefone, @email, @naturalidade, @nacionalidade)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.datanasc.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@naturalidade", t.Naturalidade);
                query.Parameters.AddWithValue("@nacionalidade", t.Nacionalidade);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("o registro esta faltando");

            }
            catch (Exception e)
            {
                throw e;
            } finally
            {
                conn.Close();
            }
        }

        public List<Funcionarios> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Funcionarios t)
        {
            throw new NotImplementedException();
        }
    }
}
