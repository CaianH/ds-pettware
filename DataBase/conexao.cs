using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace PETTWARE.DataBase
{
    class conexao
    {
        private static string host = "localhost";

        private static string port = "3308";

        private static string user = "root";

        private static string password = "120394ll";

        private static string dbname = "bd_pettware";

        private static MySqlConnection connection;

        private static MySqlCommand command;
        
        public conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={host};database={dbname};port={port};user={user};password={password};SSL Mode=None") ;
                connection.Open();
                
            } catch (Exception)
            {
                throw;
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            } catch (Exception)
            {
                throw;
            }
        }

        public void Close()
        {
            connection.Close();
        }

    }
}
