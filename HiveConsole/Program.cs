using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpochHive;
using EpochHive.Exceptions;
using Newtonsoft.Json;

namespace HiveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Configuration.Load();

                var result = MySqlInterface.ConnectToDatabase();
                Console.WriteLine(result.Message);
            }
            catch(BaseException e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.ErrorMessage);
            }
            
            
        }
    }
}
