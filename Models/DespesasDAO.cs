using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
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
                query.CommandText = "INSERT INTO despesas (tipo_desp, nome_desp, cod_caixa, valor_desp) " +
                    "VALUES  (@tipo despesa, @nome despesa, @valor)";

                query.Parameters.AddWithValue("@tipo despesa", t.TipoDespesa);
                query.Parameters.AddWithValue("@nome despesa", t.NomeDespesa);
                query.Parameters.AddWithValue("@valor", t. Valor);


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
    }

        public List<Despesas> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Despesas t)
        {
            throw new NotImplementedException();
        }
    
}
