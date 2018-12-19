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
            List<string> artistNameList = new List<string>();
            List<string> artistSurnameList = new List<string>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM pota4187.Artist", conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    for (int i = 0; dr.Read(); i++)
                    {
                        artistNameList.Add(dr[1].ToString());
                    }

                    foreach (string s in artistNameList)
                    {
                        Console.WriteLine(s);
                    }
                    dr.Close();
                    Console.ReadKey();
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                Console.ReadKey();
                throw;
            }

        }
    }
}
