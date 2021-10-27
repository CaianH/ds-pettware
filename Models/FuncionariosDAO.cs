using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;
using MySql.Data.MySqlClient;
using PETTWARE.DataBase;

namespace PETTWARE.Models
{
    class FuncionariosDAO : IDAO<Funcionarios>
    {
        /*
         * insert
         * update
         * delete
         * list (select * from funcionario)
         * getbyid(int id) (select * from funcionario where cod_func = 1)
        */
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
            throw new NotImplementedException();
        }

        public List<Funcionarios> List()
        {
            try
            {
                List<Funcionarios> list = new List<Funcionarios>();

                var query = conn.Query();

                query.CommandText = "SELECT * FROM Funcionario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionarios()
                    {
                        Codigo = reader.GetInt32("cod_func"),
                        Nome = reader.GetString("nome_func"),


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

        public void Update(Funcionarios t)
        {
            throw new NotImplementedException();
        }
    }
}
