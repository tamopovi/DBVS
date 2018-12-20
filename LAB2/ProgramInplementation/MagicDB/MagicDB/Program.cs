using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace MagicDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstring = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=h*!J45R^sntuz; Database=MagicDB;";
            UI userInterface = new UI(connstring);
            userInterface.Launch();
        }
    }
}
