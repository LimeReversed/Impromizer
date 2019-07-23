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
        static public List<string> recentStrings = new List<string>();
        static public Random r = new Random();

        // The following variables are reached through here, but initiated remotely. The reason being
        // that the informaiton depends on whether it's the english or swedish version. So they are set
        // when either version starts.
        static public string connectionString;
        static public string backupString;
        static public string factoryResetString;

        static public void DefaultTable(string table, string connectionString, string fromString)
        {
            // Remove all items from the selected table at the string you want to update. 
            Command($"DELETE FROM {table}", connectionString);
            Command($"DELETE FROM SQLITE_SEQUENCE WHERE name = '{table}'", connectionString);

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
                                Command($"INSERT INTO {table} ([{reader.GetName(i)}]) VALUES ('{reader.GetValue(i)}')", connectionString);
                            }

                            // If a row has already been added you don't want to create a new one for the second column. 
                            // So you just update the other column in the existing row. 
                            else
                            {
                                Command($"UPDATE {table} SET [{reader.GetName(i)}] = '{reader.GetValue(i)}' WHERE Id = {row}", connectionString);
                            }
                        }
                        row++;
                    }

                    reader.Close();
                    connection.Close();
                }
            }
        }

        static public void TransferNewWords(string table, string connectionString, string fromString)
        {
            int existingVersion = Convert.ToInt32($"{Db.GetValue("SELECT Version FROM TblVersion", Db.connectionString)}");
            using (SQLiteConnection connection = new SQLiteConnection(fromString))
            {
                connection.Open();
                // Select all from the table from the database you want o take info from. 
                using (SQLiteCommand command = new SQLiteCommand($"SELECT * FROM {table} WHERE Version > {existingVersion}", connection))
                {
                    int row = 1;
                    SQLiteDataReader reader = command.ExecuteReader();

                    StringBuilder columns = new StringBuilder();
                    StringBuilder values = new StringBuilder();
                    // Goes through all rows
                    while (reader.Read())
                    {
                        // Goes through all colums of current row. Gets the column
                        // names and values. 
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            columns.Append($"[{reader.GetName(i)}], ");
                            values.Append($"'{reader.GetValue(i)}', ");
                        }

                        columns.Remove(columns.Length - 2, 2);
                        values.Remove(values.Length - 2, 2);

                        // Inserts Values to the correct columns. 
                        Db.Command($"INSERT INTO {table} ({columns}) VALUES ({values})", connectionString);
                        columns.Clear();
                        values.Clear();
                        row++;
                    }
                    
                    reader.Close();
                    connection.Close();
                }
            }
        }

        static public void LoadFromBackup(ProgressBar pBar)
        {
            pBar.PerformStep();
            DefaultTable("TblAdjectives", Db.connectionString, Db.backupString);
            pBar.PerformStep();
            DefaultTable("TblJokeNames", Db.connectionString, Db.backupString);
            pBar.PerformStep();
            DefaultTable("TblMissions", Db.connectionString, Db.backupString);
            pBar.PerformStep();
            DefaultTable("TblNobelPrizes", Db.connectionString, Db.backupString);
            pBar.PerformStep();
            DefaultTable("TblNouns", Db.connectionString, Db.backupString);
            pBar.PerformStep();
            DefaultTable("TblSavedResults", Db.connectionString, Db.backupString);
            pBar.PerformStep();
            DefaultTable("TblStatus", Db.connectionString, Db.backupString);
            pBar.PerformStep();
            DefaultTable("TblVerbs", Db.connectionString, Db.backupString);
        }

        static public void SaveToBackup(ProgressBar pBar)
        {
            pBar.PerformStep();
            DefaultTable("TblAdjectives", Db.backupString, Db.connectionString);
            pBar.PerformStep();
            DefaultTable("TblJokeNames", Db.backupString, Db.connectionString);
            pBar.PerformStep();
            DefaultTable("TblMissions", Db.backupString, Db.connectionString);
            pBar.PerformStep();
            DefaultTable("TblNobelPrizes", Db.backupString, Db.connectionString);
            pBar.PerformStep();
            DefaultTable("TblNouns", Db.backupString, Db.connectionString);
            pBar.PerformStep();
            DefaultTable("TblSavedResults", Db.backupString, Db.connectionString);
            pBar.PerformStep();
            DefaultTable("TblStatus", Db.backupString, Db.connectionString);
            pBar.PerformStep();
            DefaultTable("TblVerbs", Db.backupString, Db.connectionString);
        }

        static public void DefaultAll(ProgressBar pBar)
        {
            pBar.PerformStep();
            DefaultTable("TblAdjectives", Db.connectionString, Db.factoryResetString);
            pBar.PerformStep();
            DefaultTable("TblJokeNames", Db.connectionString, Db.factoryResetString);
            pBar.PerformStep();
            DefaultTable("TblMissions", Db.connectionString, Db.factoryResetString);
            pBar.PerformStep();
            DefaultTable("TblNobelPrizes", Db.connectionString, Db.factoryResetString);
            pBar.PerformStep();
            DefaultTable("TblNouns", Db.connectionString, Db.factoryResetString);
            pBar.PerformStep();
            DefaultTable("TblSavedResults", Db.connectionString, Db.factoryResetString);
            pBar.PerformStep();
            DefaultTable("TblStatus", Db.connectionString, Db.factoryResetString);
            pBar.PerformStep();
            DefaultTable("TblVerbs", Db.connectionString, Db.factoryResetString);
        }

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

        static public string GetValue(string query, string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
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

       
        //    catch (Exception Ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("error: " + Ex.ToString());
        //        System.Windows.Forms.MessageBox.Show("error: " + Ex.InnerException);
        //        System.Windows.Forms.MessageBox.Show("error: " + Ex.Source);
        //        System.Windows.Forms.MessageBox.Show("error: " + Ex.Message);
        //    }
        
        // If the requested value is below a certain number then it will set all target values to the requested value.  
        static public void SetMultiple(string tableName, string whereStatement, string setStatement, int limit)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Db.connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;
                int amountOfRows = 0;
                command.CommandText = $"SELECT COUNT(*) FROM {tableName} WHERE {whereStatement} AND {setStatement}";
                amountOfRows = Convert.ToInt32(command.ExecuteScalar());

                if (amountOfRows < limit)
                {
                    string row1 = Db.GetValue($"SELECT Id FROM {tableName} WHERE {whereStatement} ORDER BY Id ASC LIMIT 1", Db.connectionString);
                    string lastRow = Db.GetValue($"SELECT Id FROM {tableName} WHERE {whereStatement} ORDER BY Id DESC LIMIT 1", Db.connectionString);
                    command.CommandText = $"UPDATE {tableName} SET {setStatement} WHERE {whereStatement} AND Id BETWEEN {row1} AND {lastRow}";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
