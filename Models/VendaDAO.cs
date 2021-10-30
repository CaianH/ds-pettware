using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class VendaDAO : IDAO<Venda>
    {
        private static conexao conn;

        public VendaDAO()
        {
            conn = new conexao();
        }
        void IDAO<Venda>.Delete(Venda t)
        {
            throw new NotImplementedException();
        }

        Venda IDAO<Venda>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Venda ( cod_cli, cod_func, data_vend, valortotal_vend, " +
                    " formapagamento_vend)" +
                    "VALUES ( @codcli,@codfunc,@datavenda,@valortotal,@formapagamento)";


                query.Parameters.AddWithValue("@codcli", t.Cliente.Cod);
                query.Parameters.AddWithValue("@codfunc", t.Funcionario.Codigo);
                query.Parameters.AddWithValue("@datavenda", t.Data);
                query.Parameters.AddWithValue("@valortotal", t.Valortotal);
                query.Parameters.AddWithValue("@formapagamento", t.FormaPagamento);
                query.Parameters.AddWithValue("@precocomdesconto", t.ValorcomDesconto);


                var result = query.ExecuteNonQuery();

                long vendaId = query.LastInsertedId;

                InsertItens(vendaId, t.Itens);  
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

        private void InsertItens(long vendaId, List<VendaItem> itens)
        {

            foreach (VendaItem item in itens)
            {

                var query = conn.Query();
                query.CommandText = "INSERT INTO Venda_Produto ( cod_vend, cod_prod, qnt_vp )" +
                    "VALUES ( @codvenda,@codprod,@qnt)";


                query.Parameters.AddWithValue("@codvenda", vendaId);
                query.Parameters.AddWithValue("@codprod", item.Produto.Codigo);
                query.Parameters.AddWithValue("@qnt", item.Quantidade);
                


                var result = query.ExecuteNonQuery();
            }
        }

        List<Venda> IDAO<Venda>.List()
        {
            throw new NotImplementedException();
        }

        void IDAO<Venda>.Update(Venda t)
        {
            throw new NotImplementedException();
        }
    }
}
