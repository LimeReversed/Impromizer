using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SQLite;



namespace Headline_Randomizer
{
    public class Db
    {
        static public List<Custom> choicesList = new List<Custom>();
        static public List<string> recentStrings = new List<string>();
        static public Random r = new Random();
        // If I want to be able to write to the database I need to have it a folder that allowed writing to files. The root directory, which will be put in Program Files
        // does not allow this. So I had to copy the database to a documents folder when the app is initializing and and here now I need to have the connection string
        // point to that documents folder.

        static public string connectionString;
        //static public string connectionString = $"Data Source= {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer\\{Db.GetDatabaseName()}";
        static public string backupString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = " + AppDomain.CurrentDomain.BaseDirectory + "WordsDatabaseBackup.mdf; Integrated Security=True";
        static public string factoryResetString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = " + AppDomain.CurrentDomain.BaseDirectory + "WordsDatabaseFactory.mdf; Integrated Security=True";

        static public void DefaultTable(string table, string connectionString, string fromString)
        {
            // Remove all items from the selected table at the string you want to update. 
            Db.Command($"TRUNCATE TABLE[{table}];", connectionString);

            using (SQLiteConnection connection = new SQLiteConnection(fromString))
            {
                connection.Open();
                // Select all from the table from the database you want o take info from. 
                using (SQLiteCommand command = new SQLiteCommand($"SELECT * FROM {table}", connection))
                {
                    int row = 1;
                    SQLiteDataReader reader = command.ExecuteReader();

                    // Goes through all rows
                    while (reader.Read())
                    {
                        // Goes through all colums of current row. 
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            // if curent row is the first column (After Id), then insert, mening crete new row. 
                            if (i == 1)
                            {
                                Db.Command($"INSERT INTO {table} ([{reader.GetName(i)}]) VALUES ('{reader.GetValue(i)}')", connectionString);
                            }

                            // If a row has already been added you don't want to create a new one for the second column. 
                            // So you just update the other column in the existing row. 
                            else
                            {
                                Db.Command($"UPDATE {table} SET [{reader.GetName(i)}] = '{reader.GetValue(i)}' WHERE Id = {row}", connectionString);
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
        } // This might be language independent when it takes from a backupdatabase, not text files

        static public void Command(string commandstring, string connectionString)
        {

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(commandstring, connection))
                {
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        

        static public string GetValue(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Db.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    string value = "";
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        value = reader.GetValue(0).ToString();
                    }

                    reader.Close();
                    connection.Close();
                    return value;
                }
            }
        }

        static public string RandomizeValue(string selectStatement, string restOfQuery)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Db.connectionString))
            {
                connection.Open();

                // Get the amount of rows,
                using (SQLiteCommand command = new SQLiteCommand($"SELECT COUNT(*) {restOfQuery}", connection))
                {
                    int rowCount = Convert.ToInt32(command.ExecuteScalar());

                    // Change the query from amount of rows to whatever the parameters say. 
                    command.CommandText = $"{selectStatement} {restOfQuery}";
                    
                    string value = "";
                    SQLiteDataReader reader = command.ExecuteReader();

                    int i = Db.r.Next(0, rowCount);
                    int j = 0;

                    // Go through all rows until you reach the one with the Id randomized when the i 
                    // variable was initialized. And then get the Id of that row.
                    while (reader.Read())
                    {
                        if (j == i)
                        {
                            value = reader.GetValue(0).ToString();
                            reader.Close();
                            connection.Close();
                            return value;
                        }
                        else { j++; }
                    }

                    reader.Close();
                    connection.Close();
                    return value;

                }
            }
        }

        
    }

}
