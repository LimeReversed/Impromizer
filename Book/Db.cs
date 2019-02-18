using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data.SqlClient;


namespace Headline_Randomizer
{
    public class Db
    {
        public Db()
        {
        }

       
        static public List<Custom> choicesList = new List<Custom>();
        static public List<string> recentStrings = new List<string>();

        static public void ResetDefault(string word)
        {
            //!fileRow.EndOf<stream
            //fileForRead.ReadLine()

            if (word == "verbs" || word == "all")
            {
                Db.Command("TRUNCATE TABLE[TblVerb];");

                StreamReader sr = new StreamReader(@"Text\verb basform.txt");
                StreamReader sr2 = new StreamReader(@"Text\verbs presens.txt");
                StreamReader sr3 = new StreamReader(@"Text\verbs perfekt.txt");
                StreamReader sr4 = new StreamReader(@"Text\post verbs.txt");
                StreamReader sr5 = new StreamReader(@"Text\verb request.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;
                string fileRow4;
                string fileRow5;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null) && ((fileRow4 = sr4.ReadLine()) != null) && ((fileRow5 = sr5.ReadLine()) != null))
                {
                    Db.Command($"INSERT INTO TblVerb (BaseForm, Request, Perfekt, Presens, PostVerb, Used) VALUES ('{fileRow}', '{fileRow5}', '{fileRow3}', '{fileRow2}', '{fileRow4}', '0')");
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
                sr4.Close();
                sr5.Close();
            }

            if (word == "nouns" || word == "all")
            {
                Db.Command("TRUNCATE TABLE[TblNouns];");

                StreamReader sr = new StreamReader(@"Text\dödasubstantivsing.txt");
                StreamReader sr2 = new StreamReader(@"Text\dödasubstantivplural.txt");
                StreamReader sr3 = new StreamReader(@"Text\DSub EnEttDinDitt.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
                {
                    Db.Command($"INSERT INTO TblNouns (Singular, Plural, Animated, Used) VALUES ('{fileRow}', '{fileRow2}', 0, 0)");
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
            }

            if (word == "nouns" || word == "all")
            {

                StreamReader sr = new StreamReader(@"Text\levandesubstantivsing.txt");
                StreamReader sr2 = new StreamReader(@"Text\levandesubstantivplural.txt");
                StreamReader sr3 = new StreamReader(@"Text\LSub EnEttDinDitt.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
                {
                    Db.Command($"INSERT INTO TblNouns (Singular, Plural, Animated, Used) VALUES ('{fileRow}', '{fileRow2}', '1', '0')");
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
            }

            if (word == "adjective" || word == "all")
            {
                Db.Command("TRUNCATE TABLE[TblAdjective];");

                StreamReader sr = new StreamReader(@"Text\adjektivsingular.txt");
                StreamReader sr2 = new StreamReader(@"Text\adjektivplural.txt");
                StreamReader sr3 = new StreamReader(@"Text\adjektivEttForm.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
                {
                    Db.Command($"INSERT INTO TblAdjective (EnForm, EttForm, Plural, Used) VALUES ('{fileRow}', '{fileRow3}', '{fileRow2}', '0')");
                }
                sr.Close();
                sr2.Close();
                sr3.Close();

            }

            //if (word == "jokename" || word == "all")
            //{
            //    StreamReader sr = new StreamReader(@"Text\jokenames2.txt");

            //    string fileRow;

            //    while ((fileRow = sr.ReadLine()) != null)
            //    {
            //        Db.Command($"INSERT INTO TblJokeNames (Name, Used) VALUES ('{fileRow}', '0')");
            //    }
            //    sr.Close();
            //}

            //if (word == "nobelprize" || word == "all")
            //{
            //    StreamReader sr = new StreamReader(@"Text\nobelprizes2.txt");

            //    string fileRow;

            //    while ((fileRow = sr.ReadLine()) != null)
            //    {
            //        Db.Command($"INSERT INTO TblNobelPrizes (Prize, Used) VALUES ('{fileRow}', '0')");
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

        }

        static public void Command(string commandstring)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\Tresorit\Headline Randomizer\Headline Randomizer\Headline Randomizer Svenska 2.1\WordsDatabase.mdf; Integrated Security=True";
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
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\Tresorit\Headline Randomizer\Headline Randomizer\Headline Randomizer Svenska 2.1\WordsDatabase.mdf; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
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

        static public string GetDataType(string query, int columnNr)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\Tresorit\Headline Randomizer\Headline Randomizer\Headline Randomizer Svenska 2.1\WordsDatabase.mdf; Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    string type = "";
                    while (reader.Read())
                    {
                        type = reader.GetName(columnNr);
                    }
                    connection.Close();
                    reader.Close();
                    return type;
                }
            }
        }
    }

}
