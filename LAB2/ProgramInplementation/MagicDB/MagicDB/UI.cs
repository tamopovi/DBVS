using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicDB
{
    class UI
    {
        string connectionString = "";
        public UI(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Launch()
        {
            DataMethods DM = new DataMethods(connectionString); string input = "";
            Console.WriteLine("Welcome to MagicDB!\n");
            Console.WriteLine("Command list: (not case sensitive)");
            Console.WriteLine(new String('*', 35));
            Console.WriteLine("show artist list");
            Console.WriteLine("show specimen list");
            Console.WriteLine("card search");
            Console.WriteLine("insert card");
            Console.WriteLine("insert specimen");
            Console.WriteLine("update card type");
            Console.WriteLine("update specimen number");
            Console.WriteLine("delete specimen");
            Console.WriteLine("exit");
            Console.WriteLine(new String('*', 35));
            Console.WriteLine();
            while (input != "exit")
            {
                Console.Write("MagicDB> ");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "show artist list":
                        DM.ShowArtistList();
                        break;
                    case "card search":
                        {
                            DM.CardSearch();
                        }
                        break;
                    case "insert card":
                        {
                            DM.InsertCard();
                        }
                        break;
                    case "update card type":
                        {
                            DM.UpdateCardType();
                        }
                        break;
                    case "update specimen number":
                        {
                            DM.UpdateSpecimenNr();
                        }
                        break;
                    case "show specimen list":
                        {
                            DM.ShowSpecimenList();
                        }
                        break;
                    case "delete specimen":
                        {
                            DM.DeleteSpecimen();
                        }
                        break;
                    case "insert specimen":
                        {
                            DM.InsertSpecimen();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
