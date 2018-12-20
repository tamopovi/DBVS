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
            //string selectQuery = "SELECT @nr, @painting, @setCode, @fText, @name FROM pota4187.Specimen";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT Nr, Painting, setCode, fText, name FROM pota4187.Specimen", conn);
                    /*
                    cmd.Parameters.AddWithValue("nr", "nr");
                    cmd.Parameters.AddWithValue("painting", "painting");
                    cmd.Parameters.AddWithValue("setCode", "setcode");
                    cmd.Parameters.AddWithValue("fText", "ftext");
                    cmd.Parameters.AddWithValue("name", "name");
                    */
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    for (int i = 0; dr.Read(); i++)
                    {
                        Console.WriteLine(dr[0]);
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
            string insertCardCommand = "INSERT INTO pota4187.Card VALUES (@name, @type, @cost, @text, @color);";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand inCommand = new NpgsqlCommand(insertCardCommand, connection);
                    try
                    {
                        inCommand.Parameters.AddWithValue("name", name);
                        inCommand.Parameters.AddWithValue("type", type);
                        inCommand.Parameters.AddWithValue("cost", cost);
                        inCommand.Parameters.AddWithValue("text", text);
                        inCommand.Parameters.AddWithValue("color", color);

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

        public void InsertSpecimen()
        {
            Console.WriteLine("Inserting specimen:");

            Console.Write("Nr: ");
            int nr = Convert.ToInt32(Console.ReadLine());

            Console.Write("Painting: ");
            string painting = Console.ReadLine();

            Console.Write("Set Code: ");
            string setCode = Console.ReadLine();

            Console.Write("Flavor Text: ");
            string fText = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();
            string insertCardCommand = "INSERT INTO pota4187.Specimen VALUES (@nr, @painting, @setCode, @ftext, @name);";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand inCommand = new NpgsqlCommand(insertCardCommand, connection);
                    try
                    {
                        inCommand.Parameters.AddWithValue("name", name);
                        inCommand.Parameters.AddWithValue("nr", nr);
                        inCommand.Parameters.AddWithValue("setCode", setCode);
                        inCommand.Parameters.AddWithValue("fText", fText);
                        inCommand.Parameters.AddWithValue("painting", painting);

                        inCommand.ExecuteNonQuery();
                        Console.WriteLine($"Inserted values ('{nr}','{painting}',{setCode},'{fText}','{name}')");
                    }
                    catch (PostgresException ex)
                    {
                        Console.WriteLine("Insertion failed.");
                        if (ex.Code == "42703")
                            Console.WriteLine("pgException: you might be inserting a wrong data type");

                        if (ex.Code == "23505")
                            Console.WriteLine("integrityException: specimen would not be unique, select different number in set");

                        if (ex.Code == "P0001")
                            Console.WriteLine("caughtTrigger: set cannot contain more than one card of the same name");

                        if (ex.Code == "23503")
                            Console.WriteLine("foreignKeyException: painting, set or card does not exist");
                        //Console.WriteLine(ex.Code);
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

        public void UpdateCardType()
        {
            Console.WriteLine("Updating card type:");
            Console.Write("Which card would you like to update ? ");
            string name = Console.ReadLine();

            //Console.Write("What would you like to change about the card ? ");
            //string updatingColumn = Console.ReadLine();

            Console.Write("What should be the new value ? ");
            string updatedValue = Console.ReadLine();

            string updateCommand = "UPDATE pota4187.Card SET Type = @updatedValue WHERE name = @name";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand upCommand = new NpgsqlCommand(updateCommand, connection);
                    try
                    {
                        //upCommand.Parameters.AddWithValue("updatingColumn", updatingColumn);
                        upCommand.Parameters.AddWithValue("updatedValue", updatedValue);
                        upCommand.Parameters.AddWithValue("name", name);

                        upCommand.ExecuteNonQuery();
                        Console.WriteLine("Update successful.");
                    }
                    catch (PostgresException ex)
                    {
                        if (ex.Code == "22P02")
                            Console.WriteLine("dataException: cost must be a positive number");
                        if (ex.Code == "23514")
                            Console.WriteLine("checkException: cost cannot be negative");
                        /*if (ex.Code == "42703")
                            Console.WriteLine($"accessException: card doesn't have a '{updatingColumn}' column");
                        if (ex.Code == "42601")
                            Console.WriteLine($"accessException: card doesn't have a '{updatingColumn}' column");
                        //Console.WriteLine(ex.Code);
                        //Console.WriteLine(ex.ToString());
                        */
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

        //public void

        public void UpdateSpecimenNr()
        {
            Console.WriteLine("Updating specimen nr:");
            Console.WriteLine("Would you like to see the specimen list first ?");
            string seeList = Console.ReadLine();
            if (seeList.ToLower() == "yes")
                ShowSpecimenList();
            Console.WriteLine("Which specimen would you like to update ?");
            Console.Write("Number in set: ");
            int numberInSet = Convert.ToInt32(Console.ReadLine());

            Console.Write("Set code: ");
            string setCode = Console.ReadLine();

            Console.Write("What is the new value ? ");
            int updatedValue = Convert.ToInt32(Console.ReadLine());
            string updateCommand = "UPDATE pota4187.Specimen SET Nr = @updatedValue WHERE Nr = @numberInSet AND SetCode = @setCode";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand upCommand = new NpgsqlCommand(updateCommand, connection);
                    try
                    {
                        upCommand.Parameters.AddWithValue("updatedValue", updatedValue);
                        upCommand.Parameters.AddWithValue("numberInSet", numberInSet);
                        upCommand.Parameters.AddWithValue("setCode", setCode);
                        upCommand.ExecuteNonQuery();
                        Console.WriteLine("Update successful.");
                    }
                    catch (PostgresException ex)
                    {
                        if (ex.Code == "22P02")
                            Console.WriteLine("dataException: cost must be a positive number");
                        if (ex.Code == "23514")
                            Console.WriteLine("checkException: cost cannot be negative");
                        //Console.WriteLine(ex.Code);
                        if (ex.Code == "P0001")
                            Console.WriteLine("caught trigger");
                        /*if (ex.Code == "42703")
                            Console.WriteLine($"accessException: card doesn't have a '{updatingColumn}' column");
                        if (ex.Code == "42601")
                            Console.WriteLine($"accessException: card doesn't have a '{updatingColumn}' column");
                        Console.WriteLine(ex.Code);
                        //Console.WriteLine(ex.ErrorCode);
                        //Console.WriteLine(ex.ToString());
                        */
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

        public void DeleteSpecimen()
        {
            Console.WriteLine("Deleting specimen:");
            Console.WriteLine("Would you like to see the specimen list first ?");
            string seeList = Console.ReadLine();
            if (seeList.ToLower() == "yes")
                ShowSpecimenList();

            Console.WriteLine("Which specimen would you like to delete from DB ?");

            Console.Write("Number in set: ");
            int numberInSet = Convert.ToInt32(Console.ReadLine());

            Console.Write("Set code: ");
            string setCode = Console.ReadLine();
            string deleteCommand = "DELETE FROM pota4187.Specimen WHERE Nr = @numberInSet AND SetCode = @setCode";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand deCommand = new NpgsqlCommand(deleteCommand, connection);
                    try
                    {
                        deCommand.Parameters.AddWithValue("numberInSet", numberInSet);
                        deCommand.Parameters.AddWithValue("setCode", setCode);
                        deCommand.ExecuteNonQuery();
                        Console.WriteLine("Deletion successful.");
                    }
                    catch (PostgresException ex)
                    {
                        if (ex.Code == "22P02")
                            Console.WriteLine("dataException: cost must be a positive number");
                        if (ex.Code == "23514")
                            Console.WriteLine("checkException: cost cannot be negative");
                        //Console.WriteLine(ex.Code);
                        if (ex.Code == "P0001")
                            Console.WriteLine("caught trigger");
                    }
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
