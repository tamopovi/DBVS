using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;
namespace MagicDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: implement transactions
            UI userInterface = new UI(ConfigurationManager.ConnectionStrings["MDB"].ConnectionString.ToString());
            userInterface.Launch();
        }
    }
}
