using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Headline_Randomizer;

namespace English
{
    public abstract class Words
    {
        // Create a static object for all needed classes. 
        public static Adjectives adjective = new Adjectives();
        public static Verbs verb = new Verbs();
        public static Someone someone = new Someone();
        public static Something something = new Something();
        public static Nouns noun = new Nouns();
        //public static Plats location = new Plats();
        public static NobelPrizes nobelPrize = new NobelPrizes();
        public static JokeNames jokeName = new JokeNames();
        //public static Status status = new Status();
        //public static Uppdrag uppdrag = new Uppdrag();

        //public static void FreeNeededRelations(int antal)
        //{
        //    string used = "Used";
        //    using (SQLiteConnection connection = new SQLiteConnection(Db.connectionString))
        //    {
        //        connection.Open();
        //        SQLiteCommand command = new SQLiteCommand();
        //        command.Connection = connection;
        //        int antalRader = 0;

        //        // Adjektiv relation
        //        command.CommandText = $"SELECT COUNT(*) FROM TblAdjectives WHERE {used} = 0 AND [Relation] = 'True' {QueryRestrictions()}";
        //        antalRader = (Int32)command.ExecuteScalar();

        //        if (antalRader < antal)
        //        {
        //            string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblAdjectives WHERE [Relation] = 'True' ORDER BY Id ASC");
        //            string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblAdjectives WHERE [Relation] = 'True' ORDER BY Id DESC");
        //            command.CommandText = $"UPDATE TblAdjectives SET {used} = 0 WHERE [Relation] = 'True' AND Id BETWEEN {rad1} AND {sistaRad}";
        //            command.ExecuteNonQuery();
        //        }

        //        // Relation Verb
        //        command.CommandText = $"SELECT COUNT(*) FROM TblVerbs WHERE [Relation] = 'True' AND {used} = 0 {QueryRestrictions()}";
        //        antalRader = (Int32)command.ExecuteScalar();

        //        if (antalRader < antal)
        //        {
        //            string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblVerbs WHERE [Relation] = 'True' ORDER BY Id ASC");
        //            string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblVerbs WHERE [Relation] = 'True' ORDER BY Id DESC");
        //            command.CommandText = $"UPDATE TblVerbs SET {used} = 0 WHERE [Relation] = 'True' AND Id BETWEEN {rad1} AND {sistaRad}";
        //            command.ExecuteNonQuery();
        //        }

        //        connection.Close();
        //    }
        //}

        // Sees to that only allowed words come up. 
        static public string QueryRestrictions()
        {
            string restriction = $"AND [Suitable for] IN('Children', 'Adolescents', 'Adults')";
            return restriction;
        }

        public static void FreeNeeded(int antal)
        {
            try
            {
                int flag = 0;

                string used = "Used";
                using (SQLiteConnection connection = new SQLiteConnection(Db.connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = connection;
                    int antalRader = 0;
                    flag = 1;

                    // Adjective
                    command.CommandText = $"SELECT COUNT(*) FROM TblAdjectives WHERE {used} = 0 {QueryRestrictions()}";
                    antalRader = Convert.ToInt32(command.ExecuteScalar());

                    if (antalRader < antal)
                    {
                        // Sort Ascending to get the first item. 
                        string rad1 = Db.GetValue("SELECT Id FROM TblAdjectives ORDER BY Id ASC LIMIT 1");
                        // Sort descending to get the last item. 
                        string sistaRad = Db.GetValue("SELECT Id FROM TblAdjectives ORDER BY Id DESC LIMIT 1");
                        command.CommandText = $"UPDATE TblAdjectives SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                        command.ExecuteNonQuery();
                    }

                    flag = 2;

                    // Someone
                    command.CommandText = $"SELECT COUNT(*) FROM TblNouns WHERE [Term for] IN ('Someone', 'Someone/Something') AND {used} = 0 {QueryRestrictions()}";
                    antalRader = Convert.ToInt32(command.ExecuteScalar());

                    if (antalRader < antal)
                    {
                        string rad1 = Db.GetValue("SELECT Id FROM TblNouns WHERE [Term for] IN ('Someone', 'Someone/Something') ORDER BY Id ASC LIMIT 1");
                        string sistaRad = Db.GetValue("SELECT Id FROM TblNouns WHERE [Term for] IN ('Someone', 'Someone/Something') ORDER BY Id DESC LIMIT 1");
                        command.CommandText = $"UPDATE TblNouns SET {used} = 0 WHERE [Term for] IN ('Someone', 'Someone/Something') AND Id BETWEEN {rad1} AND {sistaRad}";
                        command.ExecuteNonQuery();
                    }

                    flag = 3;
                    // Something
                    command.CommandText = $"SELECT COUNT(*) FROM TblNouns WHERE [Term for] IN ('Someone', 'Someone/Something') AND {used} = 0 {QueryRestrictions()}";
                    antalRader = Convert.ToInt32(command.ExecuteScalar());

                    if (antalRader < antal)
                    {
                        string rad1 = Db.GetValue("SELECT Id FROM TblNouns WHERE [Term for] IN ('Someone', 'Someone/Something') ORDER BY Id ASC LIMIT 1");
                        string sistaRad = Db.GetValue("SELECT Id FROM TblNouns WHERE [Term for] IN ('Someone', 'Someone/Something') ORDER BY Id DESC LIMIT 1");
                        command.CommandText = $"UPDATE TblNouns SET {used} = 0 WHERE [Term for] IN ('Someone', 'Someone/Something') AND Id BETWEEN {rad1} AND {sistaRad}";
                        command.ExecuteNonQuery();
                    }

                    flag = 4;
                    // Plats
                    //command.CommandText = $"SELECT COUNT(*) FROM TblNouns WHERE Benämner IN ('Plats', 'Någon & Plats') AND {used} = 0 {QueryRestrictions()}";
                    //antalRader = Convert.ToInt32(command.ExecuteScalar());

                    //if (antalRader < antal)
                    //{
                    //    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblNouns WHERE Benämner IN ('Plats', 'Någon & Plats') ORDER BY Id ASC");
                    //    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblNouns WHERE Benämner IN ('Plats', 'Någon & Plats') ORDER BY Id DESC");
                    //    command.CommandText = $"UPDATE TblNouns SET {used} = 0 WHERE Benämner IN ('Plats', 'Någon & Plats') AND Id BETWEEN {rad1} AND {sistaRad}";
                    //    command.ExecuteNonQuery();
                    //}

                    flag = 5;
                    // Verb
                    command.CommandText = $"SELECT COUNT(*) FROM TblVerbs WHERE {used} = 0 {QueryRestrictions()}";
                    antalRader = Convert.ToInt32(command.ExecuteScalar());

                    if (antalRader < antal)
                    {
                        string rad1 = Db.GetValue("SELECT Id FROM TblVerbs ORDER BY Id ASC LIMIT 1");
                        string sistaRad = Db.GetValue("SELECT Id FROM TblVerbs ORDER BY Id DESC LIMIT 1");
                        command.CommandText = $"UPDATE TblVerbs SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                        command.ExecuteNonQuery();
                    }

                    flag = 6;
                    // Nobel Prize
                    command.CommandText = $"SELECT COUNT(*) FROM TblNobelPrizes WHERE {used} = 0";
                    antalRader = Convert.ToInt32(command.ExecuteScalar());

                    if (antalRader < antal)
                    {
                        string rad1 = Db.GetValue("SELECT Id FROM TblNobelPrizes ORDER BY Id ASC LIMIT 1");
                        string sistaRad = Db.GetValue("SELECT Id FROM TblNobelPrizes ORDER BY Id DESC LIMIT 1");
                        command.CommandText = $"UPDATE TblNobelPrizes SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                        command.ExecuteNonQuery();
                    }

                    flag = 7;
                    // Joke Names
                    command.CommandText = $"SELECT COUNT(*) FROM TblJokeNames WHERE {used} = 0 {QueryRestrictions()}";
                    antalRader = Convert.ToInt32(command.ExecuteScalar());

                    if (antalRader < antal)
                    {
                        string rad1 = Db.GetValue("SELECT Id FROM TblJokeNames ORDER BY Id ASC LIMIT 1");
                        string sistaRad = Db.GetValue("SELECT Id FROM TblJokeNames ORDER BY Id DESC LIMIT 1");
                        command.CommandText = $"UPDATE TblJokeNames SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                        command.ExecuteNonQuery();
                    }

                    flag = 8;
                    // Status
                    //command.CommandText = $"SELECT COUNT(*) FROM TblStatus WHERE {used} = 0";
                    //antalRader = Convert.ToInt32(command.ExecuteScalar());

                    //if (antalRader < antal)
                    //{
                    //    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblStatus ORDER BY Id ASC");
                    //    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblStatus ORDER BY Id DESC");
                    //    command.CommandText = $"UPDATE TblStatus SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                    //    command.ExecuteNonQuery();
                    //}

                    flag = 9;
                    // Missions
                    //command.CommandText = $"SELECT COUNT(*) FROM TblMissions WHERE {used} = 0 {QueryRestrictions()}";
                    //antalRader = Convert.ToInt32(command.ExecuteScalar());

                    //if (antalRader < antal)
                    //{
                    //    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblMissions ORDER BY Id ASC");
                    //    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblMissions ORDER BY Id DESC");
                    //    command.CommandText = $"UPDATE TblMissions SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                    //    command.ExecuteNonQuery();
                    //}

                    connection.Close();
                }
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show("error: " + Ex.ToString());
                System.Windows.Forms.MessageBox.Show("error: " + Ex.InnerException);
                System.Windows.Forms.MessageBox.Show("error: " + Ex.Source);
                System.Windows.Forms.MessageBox.Show("error: " + Ex.Message);
            }
        }

        public virtual int RandomizeId()
        {
            return 404;
        }

        public virtual void Used(int id)
        {

        }
    }

    // Verb is a part of words and in words the only methods are RandomizeId and Used
    // Because that's the only thing that they all have in common. 
    public class Verbs : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerbs WHERE Used = 0 {QueryRestrictions()}")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblVerbs SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Preposition(int id)
        {
            string prep = $"{Db.GetValue($"SELECT Preposition FROM TblVerbs WHERE Id = {id}")}";

            // If it returns "" then just return a space. If however it returns a preposition
            // then add a space before and after. That way when I insert it in a string
            // the amount of spaces is correct. I need to not add any spaces in that string though.  
            if (prep == "")
            {
                return " ";
            }
            else
            {
                return $" {prep} ";
            }
        }

        public string BaseForm(int id)
        {
            return Db.GetValue($"SELECT Base FROM TblVerbs WHERE Id = {id}");
        }

        public string IngForm(int id)
        {
            return Db.GetValue($"SELECT [-ing] FROM TblVerbs WHERE Id = {id}");
        }

        public string SForm(int id)
        {
            return Db.GetValue($"SELECT [-s] FROM TblVerbs WHERE Id = {id}");
        }

        public int RandomizeRelation()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerbs WHERE Used = 0 AND [Relation] = 'True' {QueryRestrictions()}")}");
        }
    }

    public class Adjectives : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE Used = 0 {QueryRestrictions()}")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblAdjectives SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Preposition(int id)
        {
            string prep = $"{Db.GetValue($"SELECT Preposition FROM TblAdjectives WHERE Id = {id}")}";
            if (prep == "")
            {
                return " ";
            }
            else
            {
                return $" {prep} ";
            }
        }

        public string Descriptive(int id)
        {
            return $"{Db.GetValue($"SELECT Descriptive FROM TblAdjectives WHERE Id = {id}")}";
        }

        //public string Automatic(int adjectiveId, int nounId, bool singular)
        //{
        //    if (singular)
        //    {
        //        string genus = Db.GetValue($"SELECT Genus FROM TblNouns WHERE Id = {nounId}");

        //        if (genus == @"N-genus" || genus == @"N-undantag")
        //            return Db.GetValue($"SELECT [N-genus] FROM TblAdjectives WHERE Id = {adjectiveId}");
        //        else if (genus == @"T-genus" || genus == @"T-undantag")
        //        {
        //            return Db.GetValue($"SELECT [T-genus] FROM TblAdjectives WHERE Id = {adjectiveId}");
        //        }
        //        else { return ""; }
        //    }

        //    else
        //    {
        //        string genus = Db.GetValue($"SELECT Genus FROM TblNouns WHERE Id = {nounId}");

        //        if (genus == @"N-genus" || genus == @"T-genus")
        //            return Db.GetValue($"SELECT Plural FROM TblAdjectives WHERE Id = {adjectiveId}");

        //        else if (genus == @"T-undantag")
        //        {
        //            return Db.GetValue($"SELECT [T-genus] FROM TblAdjectives WHERE Id = {adjectiveId}");
        //        }

        //        else if (genus == @"N-undantag")
        //        {
        //            return Db.GetValue($"SELECT [N-genus] FROM TblAdjectives WHERE Id = {adjectiveId}");
        //        }

        //        else { return ""; }
        //    }
        //}

        //public int RandomizeRelation()
        //{
        //    return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE Used = 0 AND [Relation] = 'True' {QueryRestrictions()}")}");
        //}
    }

    public class Nouns : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Used = 0 AND [Term for] IN ('Something', 'Someone', 'Someone/Something') {QueryRestrictions()}")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblNouns SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Preposition(int id)
        {
            string prep = $"{Db.GetValue($"SELECT Preposition FROM TblNouns WHERE Id = {id}")}";
            if (prep == "")
            {
                return " ";
            }
            else
            {
                return $" {prep} ";
            }
        }

        public string AOrAn(int id)
        {
            return Db.GetValue($"SELECT [A/An] FROM TblNouns WHERE Id = {id})");
        }

        public string Singular(int id)
        {
            return $"{Db.GetValue($"SELECT [Singular] FROM TblNouns WHERE Id = {id}")}";
        }

        public string Plural(int id)
        {
            return $"{Db.GetValue($"SELECT Plural FROM TblNouns WHERE Id = {id}")}";
        }
    }

    public class Someone : Nouns
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Used = 0 AND [Term for] IN ('Someone', 'Someone/Something') {QueryRestrictions()}")}");
        }

    }

    public class Something : Nouns
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Used = 0 AND [Term for] IN ('Someone', 'Someone/Something') {QueryRestrictions()}")}");
        }
    }

    //public class Plats : Nouns
    //{
    //    public override int RandomizeId()
    //    {
    //        return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Used = 0 AND Benämner IN ('Plats', 'Någon & Plats') {QueryRestrictions()}")}");
    //    }
    //}

    public class NobelPrizes : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNobelPrizes WHERE Used = 0")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblNobelPrizes SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Prize(int id)
        {
            return $"{Db.GetValue($"SELECT Prize FROM TblNobelPrizes WHERE Id = {id}")}";
        }
    }

    public class JokeNames : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblJokeNames WHERE Used = 0 {QueryRestrictions()}")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblJokeNames SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Name(int id)
        {
            return $"{Db.GetValue($"SELECT Name FROM TblJokeNames WHERE Id = {id}")}";
        }
    }

    //public class Status : Words
    //{
    //    public override int RandomizeId()
    //    {
    //        return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblStatus WHERE Used = 0")}");
    //    }

    //    public override void Used(int idNr)
    //    {
    //        Db.Command($"UPDATE TblStatus SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
    //    }

    //    public string HighStatus(int id)
    //    {
    //        return Db.GetValue($"SELECT Högstatus FROM TblStatus WHERE Id = { id }");
    //    }

    //    public string LowStatus(int id)
    //    {
    //        return Db.GetValue($"SELECT Lågstatus FROM TblStatus WHERE Id = { id }");
    //    }
    //}

    //public class Missions : Words
    //{
    //    public override int RandomizeId()
    //    {
    //        return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblMissions WHERE Used = 0 {QueryRestrictions()}")}");
    //    }

    //    public override void Used(int id)
    //    {
    //        Db.Command($"UPDATE TblMissions SET Used = 1 WHERE Id = {id}", Db.connectionString);
    //    }

    //    public string Beskrivning(int id)
    //    {
    //        return $"{Db.GetValue($"SELECT [Uppdrag] FROM TblMissions WHERE Id = {id}")}";
    //    }
    //}


}
