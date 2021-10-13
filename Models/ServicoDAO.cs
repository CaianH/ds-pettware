using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
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
            throw new NotImplementedException();
        }

        public void Update(Servico t)
        {
            throw new NotImplementedException();
        }
    }
}
