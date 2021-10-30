<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class ProdutosDAO : IDAO<Produtos>
    {
=======
﻿using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class ProdutosDAO : IDAO<Produtos>
    {
>>>>>>> main
        private static conexao conn;

        public ProdutosDAO()
        {
            conn = new conexao();
<<<<<<< HEAD
        }

        public void Delete(Produtos t)
        {
            throw new NotImplementedException();
        }

        public Produtos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Produtos t)
        {

            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO produtos (nome_prod, marca_prod, peso_prod, preco_prod, precocomdesconto_prod, qtdemestoque_prod) " +
                    "VALUES  (@nome, @marca, @peso, @preco, @precosomdesconto, @qtdemestoque)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@marca", t.Marca);
                query.Parameters.AddWithValue("@peso", t.Peso);
                query.Parameters.AddWithValue("@preco", t.Preco);
                query.Parameters.AddWithValue("@precosomdesconto", t.PrecoComDesconto);
                query.Parameters.AddWithValue("@qtdemestoque", t.QtdEmEstoque);



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

        public List<Produtos> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Produtos t)
        {
            throw new NotImplementedException();
        }
    }
}
=======
        }
        public void Delete(Produtos t)
        {
            throw new NotImplementedException();
        }

        public Produtos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Produtos t)
        {
            throw new NotImplementedException();
        }

        public List<Produtos> List()
        {
            try
            {
                List<Produtos> list = new List<Produtos>();

                var query = conn.Query();

                query.CommandText = "SELECT * FROM Produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produtos()
                    {
                        Codigo = reader.GetInt32("cod_prod"),
                        Descricao = reader.GetString("descrição_prod"),
                        PrecoComDesconto = reader.GetDouble("precocomdesconto_serv")


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

        public void Update(Produtos t)
        {
            throw new NotImplementedException();
        }
    }
}
>>>>>>> main
