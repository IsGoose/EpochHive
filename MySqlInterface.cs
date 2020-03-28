using EpochHive.Results;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpochHive
{
    public class MySqlInterface
    {
        public static MySqlConnection Connection;
        public static DatabaseConnectionResult ConnectToDatabase()
        {
            var result = new DatabaseConnectionResult();
            try
            {
                string connectionString = $"Server={Configuration.Host};Database={Configuration.Schema};Uid:{Configuration.Username};Pwd={Configuration.Password}";
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
                result.Success = Connection.State == ConnectionState.Open;
                result.Message = result.Result = $"Connected to MySql Server Version {Connection.ServerVersion} Successfully";
            }
            catch(Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
                result.Result = false;
            }

            return result;
        }
    

    }
}
