using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using PETTWARE.DataBase;


namespace PETTWARE.Models
{
    class CaixaDAO
    {
        private static conexao conn;

        public CaixaDAO()
        {
            conn = new conexao();
        }

        public void Insert(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO caixa (receitatotal_caixa, despesatotal_caixa, lucro_caixa, debito_caixa )" +
                    "VALUES ( @receitatotal, @despesatotal, @lucro, @debito)";


                query.Parameters.AddWithValue("@receitatotal", t.receitatotal);
                query.Parameters.AddWithValue("@despesatotal", t.despesatotal);
                query.Parameters.AddWithValue("@lucro", t.lucro);
                query.Parameters.AddWithValue("@debito", t.debito);
              

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
    }
}
