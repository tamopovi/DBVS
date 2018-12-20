using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MagicDB
{
    class DataMethods
    {
        string connectionString;
        public DataMethods(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void ShowArtistList()
        {
            List<int> artistIDList = new List<int>();
            List<string> artistNameList = new List<string>();
            List<string> artistSurnameList = new List<string>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM pota4187.Artist", conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    for (int i = 0; dr.Read(); i++)
                    {
                        artistIDList.Add(Int32.Parse(dr[0].ToString()));
                        artistNameList.Add(dr[1].ToString());
                        artistSurnameList.Add(dr[2].ToString());
                    }
                    Console.WriteLine("ARTIST LIST:");
                    Console.WriteLine($"|{"ID",-3}|{"Name",-9}|{"Surname",-15}|");
                    Console.WriteLine(new String('-', 31));
                    for (int i = 0; i < artistIDList.Count; i++)
                    {
                        Console.WriteLine($"|{artistIDList[i],-3}|{artistNameList[i],-9}|{ artistSurnameList[i],-15}|");
                    }
                    Console.WriteLine(new String('-', 31));
                    dr.Close();
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                Console.ReadKey();
                throw;
            }
        }

        public void ShowSpecimenList()
        {
            List<int> nrList = new List<int>();
            List<string> paintingList = new List<string>();
            List<string> setCodeList = new List<string>();
            List<string> fTextList = new List<string>();
            List<string> nameList = new List<string>();
            const int fieldWidthLeftAligned = -18;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM pota4187.Specimen", conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    for (int i = 0; dr.Read(); i++)
                    {
                        nrList.Add(Int32.Parse(dr[0].ToString()));
                        paintingList.Add(dr[1].ToString());
                        setCodeList.Add(dr[2].ToString());
                        fTextList.Add(dr[3].ToString());
                        nameList.Add(dr[4].ToString());
                    }
                    Console.WriteLine("SPECIMEN LIST:");
                    Console.WriteLine($"|{"Nr",fieldWidthLeftAligned}|{"Painting",fieldWidthLeftAligned}|{"Set Code",fieldWidthLeftAligned}|{"Name",fieldWidthLeftAligned}");
                    Console.WriteLine(new String('-', 100));
                    for (int i = 0; i < nrList.Count; i++)
                    {
                        Console.WriteLine($"|{nrList[i],fieldWidthLeftAligned}|{paintingList[i],fieldWidthLeftAligned}|{setCodeList[i],fieldWidthLeftAligned}|{nameList[i],fieldWidthLeftAligned}");
                    }
                    Console.WriteLine(new String('-', 100));
                    dr.Close();
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                Console.ReadKey();
                throw;
            }
        }

        public void CardSearch()
        {
            string cardName = "";
            string cardType = "";
            string cardText = "";
            int cardCost = 0;
            string cardColor = "";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string inputCardName = "";
                    Console.WriteLine("CARD SEARCH:");
                    Console.Write("Enter a card you want more info about: ");
                    inputCardName = Console.ReadLine();
                    if (inputCardName == "exit search")
                        return;

                    NpgsqlCommand cmd = new NpgsqlCommand($"SELECT Extra.name, Extra.type, C.ctext, Extra.cost, Extra.color FROM pota4187.ExtraCardInfo Extra, pota4187.Card C WHERE Extra.name = C.name AND C.name = '{inputCardName}'", conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    for (int i = 0; dr.Read(); i++)
                    {
                        cardName = dr[0].ToString();
                        cardType = dr[1].ToString();
                        cardText = dr[2].ToString();
                        cardCost = Int32.Parse(dr[3].ToString());
                        cardColor = dr[4].ToString();
                    }
                    if (cardName == "")
                    {
                        Console.WriteLine("Card does not exist.");
                    }
                    else
                    {
                        Console.WriteLine("Output:");
                        Console.WriteLine(new String('-', 31));
                        Console.WriteLine("Name: " + cardName);
                        Console.WriteLine("Type: " + cardType);
                        Console.WriteLine("Card Text: " + cardText);
                        Console.WriteLine("Cost: " + cardCost);
                        Console.WriteLine("Color: " + cardColor);
                        Console.WriteLine(new String('-', 31));
                    }
                    dr.Close();

                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                Console.ReadKey();
                throw;
            }
        }

        public void InsertCard()
        {
            Console.WriteLine("Inserting card:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Type: ");
            string type = Console.ReadLine();

            Console.Write("Cost: ");
            int cost = Convert.ToInt32(Console.ReadLine());

            Console.Write("Card Text: ");
            string text = Console.ReadLine();

            Console.Write("Color: ");
            string color = Console.ReadLine();
            // 42703
            // 23514
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand inCommand = new NpgsqlCommand($"INSERT INTO pota4187.Card VALUES ('{name}','{type}',{cost},'{text}','{color}');", connection);
                    try
                    {
                        inCommand.ExecuteNonQuery();
                        Console.WriteLine($"Inserted values ('{name}','{type}',{cost},'{text}','{color}')");
                    }
                    catch (PostgresException ex)
                    {
                        if (ex.Code == "42703")
                            Console.WriteLine("pgException: you might be inserting a wrong data type");
                        if (ex.Code == "23514")
                            Console.WriteLine("checkException: cost cannot be negative.\nInsertion failed.");
                    }

                    //Console.WriteLine($"Inserted values ('{name}','{type}',{cost},'{text}','{color}')");
                }

            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                throw;
            }
        }

        public void UpdateCard()
        {
            Console.WriteLine("Updating card:");
            Console.Write("Which card would you like to update ? ");
            string name = Console.ReadLine();

            Console.Write("What would you like to change about the card ? ");
            string updatingColumn = Console.ReadLine();

            Console.Write("What should be the new value ? ");
            string updatedValue = Console.ReadLine();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand inCommand = new NpgsqlCommand($"UPDATE pota4187.Card SET {updatingColumn} = '{updatedValue}' WHERE name = '{name}'", connection);
                    try
                    {
                        inCommand.ExecuteNonQuery();
                        Console.WriteLine("Update successful.");
                    }
                    catch (PostgresException ex)
                    {
                        if (ex.Code == "22P02")
                            Console.WriteLine("dataException: cost must be a positive number");
                        if (ex.Code == "23514")
                            Console.WriteLine("checkException: cost cannot be negative");
                        if (ex.Code == "42703")
                            Console.WriteLine($"accessException: card doesn't have a '{updatingColumn}' column");
                        if (ex.Code == "42601")
                            Console.WriteLine($"accessException: card doesn't have a '{updatingColumn}' column");
                        //Console.WriteLine(ex.Code);
                        //Console.WriteLine(ex.ToString());
                    }

                    //Console.WriteLine($"Inserted values ('{name}','{type}',{cost},'{text}','{color}')");
                }

            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                throw;
            }
        }

        public void UpdateSpecimen()
        {
            Console.WriteLine("Updating specimen:");
            Console.WriteLine("Would you like to see the specimen list first ?");
            string seeList = Console.ReadLine();
            if (seeList.ToLower() == "yes")
                ShowSpecimenList();
            Console.WriteLine("Which specimen would you like to update ?");
            Console.Write("Number in set: ");
            int numberInSet = Convert.ToInt32(Console.ReadLine());

            Console.Write("Set code: ");
            string setCode = Console.ReadLine();

            Console.Write("What would you like to update about this specimen? ");
            string updatingColumn = Console.ReadLine();

            Console.Write("What is the new value ? ");
            string updatedValue = Console.ReadLine();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand inCommand = new NpgsqlCommand($"UPDATE pota4187.Specimen SET {updatingColumn} = '{updatedValue}' WHERE Nr = '{numberInSet}' AND SetCode = '{setCode}'", connection);
                    try
                    {
                        inCommand.ExecuteNonQuery();
                        Console.WriteLine("Update successful.");
                    }
                    catch (PostgresException ex)
                    {
                        if (ex.Code == "22P02")
                            Console.WriteLine("dataException: cost must be a positive number");
                        if (ex.Code == "23514")
                            Console.WriteLine("checkException: cost cannot be negative");
                        if (ex.Code == "42703")
                            Console.WriteLine($"accessException: card doesn't have a '{updatingColumn}' column");
                        if (ex.Code == "42601")
                            Console.WriteLine($"accessException: card doesn't have a '{updatingColumn}' column");
                        if (ex.Code == "P0001")
                            Console.WriteLine("caught trigger");
                        Console.WriteLine(ex.Code);
                        //Console.WriteLine(ex.ErrorCode);
                        //Console.WriteLine(ex.ToString());
                    }

                    //Console.WriteLine($"Inserted values ('{name}','{type}',{cost},'{text}','{color}')");
                }

            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                throw;
            }
        }
    }
}
