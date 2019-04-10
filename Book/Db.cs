using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace Headline_Randomizer
{
    public class Db
    {
        static public List<Custom> choicesList = new List<Custom>();
        static public List<string> recentStrings = new List<string>();
        static public Random r = new Random();
        static public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\Tresorit\Headline Randomizer\Headline Randomizer\Headline Randomizer Svenska 2.1\WordsDatabase.mdf; Integrated Security=True";
        static public string backupString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\Tresorit\Headline Randomizer\Headline Randomizer\Headline Randomizer Svenska 2.1\WordsDatabaseBackup.mdf; Integrated Security=True";
        static public string factoryResetString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\Tresorit\Headline Randomizer\Headline Randomizer\Headline Randomizer Svenska 2.1\WordsDatabaseFactory.mdf; Integrated Security=True";
        //@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = " + AppDomain.CurrentDomain.BaseDirectory + "WordsDatabase.mdf; Integrated Security=True";

        static public void DefaultTable(string table, string connectionString, string fromString)
        {
            // Remove all items from the selected table at the string you want to update. 
            Db.Command($"TRUNCATE TABLE[{table}];", connectionString);

            using (SqlConnection connection = new SqlConnection(fromString))
            {
                connection.Open();
                // Select all from the table from the database you want o take info from. 
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {table}", connection))
                {
                    int row = 1;
                    SqlDataReader reader = command.ExecuteReader();

                    // Goes through all rows
                    while (reader.Read())
                    {
                        // Goes through all colums of current row. 
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            // if curent row is the first column (After Id), then insert, mening crete new row. 
                            if (i == 1)
                            {
                                Db.Command($"INSERT INTO {table} ([{reader.GetName(i)}]) VALUES ('{reader.GetSqlValue(i)}')", connectionString);
                            }

                            // If a row has already been added you don't want to create a new one for the second column. 
                            // So you just update the other column in the existing row. 
                            else
                            {
                                Db.Command($"UPDATE {table} SET [{reader.GetName(i)}] = '{reader.GetSqlValue(i)}' WHERE Id = {row}", connectionString);
                            }
                        }
                        row++;
                    }

                    reader.Close();
                    connection.Close();
                }
            }
        }

        static public void LoadFromBackup()
        {
            DefaultTable("TblAdjectives", Db.connectionString, Db.backupString);
            DefaultTable("TblJokeNames", Db.connectionString, Db.backupString);
            DefaultTable("TblMissions", Db.connectionString, Db.backupString);
            DefaultTable("TblNobelPrizes", Db.connectionString, Db.backupString);
            DefaultTable("TblNouns", Db.connectionString, Db.backupString);
            DefaultTable("TblSavedResults", Db.connectionString, Db.backupString); // Or not?
            DefaultTable("TblStatus", Db.connectionString, Db.backupString);
            DefaultTable("TblVerbs", Db.connectionString, Db.backupString);
        }

        static public void SaveToBackup()
        {
            DefaultTable("TblAdjectives", Db.backupString, Db.connectionString);
            DefaultTable("TblJokeNames", Db.backupString, Db.connectionString);
            DefaultTable("TblMissions", Db.backupString, Db.connectionString);
            DefaultTable("TblNobelPrizes", Db.backupString, Db.connectionString);
            DefaultTable("TblNouns", Db.backupString, Db.connectionString);
            DefaultTable("TblSavedResults", Db.backupString, Db.connectionString); // Or not?
            DefaultTable("TblStatus", Db.backupString, Db.connectionString);
            DefaultTable("TblVerbs", Db.backupString, Db.connectionString);
        }

        static public void DefaultAll()
        {
            DefaultTable("TblAdjectives", Db.connectionString, Db.factoryResetString);
            DefaultTable("TblJokeNames", Db.connectionString, Db.factoryResetString);
            DefaultTable("TblMissions", Db.connectionString, Db.factoryResetString);
            DefaultTable("TblNobelPrizes", Db.connectionString, Db.factoryResetString);
            DefaultTable("TblNouns", Db.connectionString, Db.factoryResetString);
            DefaultTable("TblSavedResults", Db.connectionString, Db.factoryResetString); // Or not?
            DefaultTable("TblStatus", Db.connectionString, Db.factoryResetString);
            DefaultTable("TblVerbs", Db.connectionString, Db.factoryResetString);

            //!fileRow.EndOf<stream
            //fileForRead.ReadLine()

            //if (word == "verbs" || word == "all")
            //{
            //    Db.Command("TRUNCATE TABLE[TblVerbs];");

            //    StreamReader sr = new StreamReader(@"Text\verb basform.txt");
            //    StreamReader sr2 = new StreamReader(@"Text\verbs presens.txt");
            //    StreamReader sr3 = new StreamReader(@"Text\verbs perfekt.txt");
            //    StreamReader sr4 = new StreamReader(@"Text\post verbs.txt");
            //    StreamReader sr5 = new StreamReader(@"Text\verb request.txt");

            //    string fileRow;
            //    string fileRow2;
            //    string fileRow3;
            //    string fileRow4;
            //    string fileRow5;

            //    while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null) && ((fileRow4 = sr4.ReadLine()) != null) && ((fileRow5 = sr5.ReadLine()) != null))
            //    {
            //        Db.Command($"INSERT INTO TblVerbs (Infinitiv, Uppmaning, Perfekt, Presens, Preposition, [Relation], Lämpligt för, Använt) VALUES ('{fileRow}', '{fileRow5}', '{fileRow3}', '{fileRow2}', '{fileRow4}', '0', 0, 0)");
            //    }
            //    sr.Close();
            //    sr2.Close();
            //    sr3.Close();
            //    sr4.Close();
            //    sr5.Close();
            //}

            //if (word == "nouns" || word == "all")
            //{
            //    Db.Command("TRUNCATE TABLE[TblNouns];");

            //    StreamReader sr = new StreamReader(@"Text\dödasubstantivsing.txt");
            //    StreamReader sr2 = new StreamReader(@"Text\dödasubstantivplural.txt");
            //    StreamReader sr3 = new StreamReader(@"Text\DSub EnEttDinDitt.txt");

            //    string fileRow;
            //    string fileRow2;
            //    string fileRow3;

            //    while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
            //    {
            //        Db.Command($"INSERT INTO TblNouns ([Singular obestämd], [Singular bestämd], Plural, Benämner, Lämpligt för, Använt) VALUES ('{fileRow}', 0, '{fileRow2}', 0, 0, 0)");
            //    }
            //    sr.Close();
            //    sr2.Close();
            //    sr3.Close();
            //}

            //if (word == "nouns" || word == "all")
            //{

            //    StreamReader sr = new StreamReader(@"Text\levandesubstantivsing.txt");
            //    StreamReader sr2 = new StreamReader(@"Text\levandesubstantivplural.txt");
            //    StreamReader sr3 = new StreamReader(@"Text\LSub EnEttDinDitt.txt");

            //    string fileRow;
            //    string fileRow2;
            //    string fileRow3;

            //    while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
            //    {
            //        Db.Command($"INSERT INTO TblNouns ([Singular obestämd], [Singular bestämd], Plural, Benämner, Lämpligt för, Använt) VALUES ('{fileRow}', 0, '{fileRow2}', 1, 0, 0)");
            //    }
            //    sr.Close();
            //    sr2.Close();
            //    sr3.Close();
            //}

            //if (word == "adjective" || word == "all")
            //{
            //    Db.Command("TRUNCATE TABLE[TblAdjectives];");

            //    StreamReader sr = new StreamReader(@"Text\adjektivsingular.txt");
            //    StreamReader sr2 = new StreamReader(@"Text\adjektivplural.txt");
            //    StreamReader sr3 = new StreamReader(@"Text\adjektivEttForm.txt");

            //    string fileRow;
            //    string fileRow2;
            //    string fileRow3;

            //    while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
            //    {
            //        Db.Command($"INSERT INTO TblAdjectives ([N-genus], [T-genus], Plural, Använt) VALUES ('{fileRow}', '{fileRow3}', '{fileRow2}', '0')");
            //    }
            //    sr.Close();
            //    sr2.Close();
            //    sr3.Close();

            //}

            //if (word == "jokename" || word == "all")
            //{
            //    Db.Command("TRUNCATE TABLE[TblJokeNames];");

            //    StreamReader sr = new StreamReader(@"Text\jokenames2.txt");

            //    string fileRow;

            //    while ((fileRow = sr.ReadLine()) != null)
            //    {
            //        Db.Command($"INSERT INTO TblJokeNames (Namn, Använt) VALUES ('{fileRow}', '0')");
            //    }
            //    sr.Close();
            //}

            //if (word == "nobelprize" || word == "all")
            //{
            //    Db.Command("TRUNCATE TABLE[TblNobelPrizes];");

            //    StreamReader sr = new StreamReader(@"Text\nobelprizes2.txt");

            //    string fileRow;

            //    while ((fileRow = sr.ReadLine()) != null)
            //    {
            //        Db.Command($"INSERT INTO TblNobelPrizes (Pris, Använt) VALUES ('{fileRow}', '0')");
            //    }
            //    sr.Close();
            //}

            //if (location.Count <= amount)
            //{
            //    StreamReader sr = new StreamReader(@"Text\location.txt");

            //    string fileRow;

            //    while ((fileRow = sr.ReadLine()) != null)
            //    {
            //        Location vread = new Location(fileRow);
            //        location.Add(vread);
            //    }
            //    sr.Close();
            //}

            //if (statusförhållande.Count <= amount)
            //{
            //    StreamReader sr1 = new StreamReader(@"Text\relation statusförhållande.txt");

            //    string fileRow1;

            //    while ((fileRow1 = sr1.ReadLine()) != null)
            //    {
            //        Relation vread = new Relation(fileRow1);
            //        statusförhållande.Add(vread);
            //    }
            //    sr1.Close();
            //}

            //if (relationKänsla.Count <= amount)
            //{
            //    StreamReader sr1 = new StreamReader(@"Text\relation känsla olika.txt");
            //    StreamReader sr2 = new StreamReader(@"Text\relation känsla samma.txt");

            //    string fileRow1, fileRow2;

            //    while ((fileRow1 = sr1.ReadLine()) != null && (fileRow2 = sr2.ReadLine()) != null)
            //    {
            //        Relation vread = new Relation(fileRow1, fileRow2);
            //        relationKänsla.Add(vread);
            //    }
            //    sr1.Close();
            //    sr2.Close();
            //}

        } // This might be language independent when it takes from a backupdatabase, not text files

        static public void Command(string commandstring, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandstring, connection))
                {
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        

        static public string GetValue(string query)
        {
            using (SqlConnection connection = new SqlConnection(Db.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string value = "";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        value = reader.GetSqlValue(0).ToString();
                    }

                    connection.Close();
                    reader.Close();
                    return value;
                }
            }
        }

        static public string RandomizeValue(string selectStatement, string restOfQuery)
        {
            using (SqlConnection connection = new SqlConnection(Db.connectionString))
            {
                connection.Open();

                // Get the amount of rows,
                using (SqlCommand command = new SqlCommand($"SELECT COUNT(*) {restOfQuery}", connection))
                {
                    int rowCount = (Int32)command.ExecuteScalar();

                    // Change the query from amount of rows to whatever the parameters say. 
                    command.CommandText = $"{selectStatement} {restOfQuery}";
                    
                    string value = "";
                    SqlDataReader reader = command.ExecuteReader();

                    int i = Db.r.Next(0, rowCount);
                    int j = 0;

                    // Go through all rows until you reach the one with the Id randomized when the i 
                    // variable was initialized. And then get the Id of that row. 
                    while (reader.Read())
                    {

                        if (j == i)
                        {
                            return value = reader.GetSqlValue(0).ToString();
                        }
                        else { j++; }
                    }

                    connection.Close();
                    reader.Close();
                    return "";

                }
            }
        }

        // Sees to that only allowed words come up. 
        static public string QueryRestrictions()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            StringBuilder builder = new StringBuilder();

            if (config.AppSettings.Settings["SuitableForChildren"].Value == "1")
            {
                builder.Append("'Barn', ");
            }
            if (config.AppSettings.Settings["SuitableForAdolescents"].Value == "1")
            {
                builder.Append("'Ungdomar', ");
            }
            if (config.AppSettings.Settings["SuitableForAdults"].Value == "1")
            {
                builder.Append("'Vuxna', ");
            }
            if (config.AppSettings.Settings["SuitableForunoffendable"].Value == "1")
            {
                builder.Append("'Okränkbara', ");
            }

            builder.Remove(builder.Length - 2, 2);
            string restriction = $"AND [Lämpligt för] IN({builder.ToString()})";
            return restriction;
        }
    }

}
