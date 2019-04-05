﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
// Since this is a different namespace I need to add Headline_Randomizer here to 
// connect to things that are there. 
using Headline_Randomizer;

namespace Svenska
{

    public abstract class Words
    {
        // Create a static object for all needed classes. 
        public static Adjektiv adjective = new Adjektiv();
        public static Verb verb = new Verb();
        public static Någon someone = new Någon();
        public static Något something = new Något();
        public static Substantiv noun = new Substantiv();
        public static Plats location = new Plats();
        public static NobelPris nobelPrize = new NobelPris();
        public static SkämtNamn jokeName = new SkämtNamn();
        public static Status status = new Status();

        public static void FreeNeeded(int antal)
        {
            string used = "Använt";
            using (SqlConnection connection = new SqlConnection(Db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                int antalRader = 0;

                // Adjective
                command.CommandText = $"SELECT COUNT(*) FROM TblAdjectives WHERE {used} = 0 {Db.QueryRestrictions()}";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    // Sort Ascending to get the first item. 
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblAdjectives ORDER BY Id ASC");
                    // Sort descending to get the last item. 
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblAdjectives ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblAdjectives SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Adjektiv relation
                command.CommandText = $"SELECT COUNT(*) FROM TblAdjectives WHERE {used} = 0 AND [Relation] = 'True' {Db.QueryRestrictions()}";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblAdjectives WHERE [Relation] = 'True' ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblAdjectives WHERE [Relation] = 'True' ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblAdjectives SET {used} = 0 WHERE [Relation] = 'True' AND Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Someone
                command.CommandText = $"SELECT COUNT(*) FROM TblNouns WHERE Benämner IN ('Någon', 'Någon & Något') AND {used} = 0 {Db.QueryRestrictions()}";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblNouns WHERE Benämner IN ('Någon', 'Någon & Något') ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblNouns WHERE Benämner IN ('Någon', 'Någon & Något') ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblNouns SET {used} = 0 WHERE Benämner IN ('Någon', 'Någon & Något') AND Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Something
                command.CommandText = $"SELECT COUNT(*) FROM TblNouns WHERE Benämner IN ('Något', 'Någon & Något') AND {used} = 0 {Db.QueryRestrictions()}";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblNouns WHERE Benämner IN ('Något', 'Någon & Något') ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblNouns WHERE Benämner IN ('Något', 'Någon & Något') ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblNouns SET {used} = 0 WHERE Benämner IN ('Något', 'Någon & Något') AND Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Plats
                command.CommandText = $"SELECT COUNT(*) FROM TblNouns WHERE Benämner IN ('Plats', 'Någon & Plats') AND {used} = 0 {Db.QueryRestrictions()}";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblNouns WHERE Benämner IN ('Plats', 'Någon & Plats') ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblNouns WHERE Benämner IN ('Plats', 'Någon & Plats') ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblNouns SET {used} = 0 WHERE Benämner IN ('Plats', 'Någon & Plats') AND Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Verb
                command.CommandText = $"SELECT COUNT(*) FROM TblVerbs WHERE {used} = 0 {Db.QueryRestrictions()}";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblVerbs ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblVerbs ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblVerbs SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Relation Verb
                command.CommandText = $"SELECT COUNT(*) FROM TblVerbs WHERE [Relation] = 'True' AND {used} = 0 {Db.QueryRestrictions()}";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblVerbs WHERE [Relation] = 'True' ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblVerbs WHERE [Relation] = 'True' ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblVerbs SET {used} = 0 WHERE [Relation] = 'True' AND Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Nobel Prize
                command.CommandText = $"SELECT COUNT(*) FROM TblNobelPrizes WHERE {used} = 0";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblNobelPrizes ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblNobelPrizes ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblNobelPrizes SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Joke Names
                command.CommandText = $"SELECT COUNT(*) FROM TblJokeNames WHERE {used} = 0 {Db.QueryRestrictions()}";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblJokeNames ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblJokeNames ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblJokeNames SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }

                // Status
                command.CommandText = $"SELECT COUNT(*) FROM TblStatus WHERE {used} = 0";
                antalRader = (Int32)command.ExecuteScalar();

                if (antalRader < antal)
                {
                    string rad1 = Db.GetValue("SELECT TOP 1 Id FROM TblStatus ORDER BY Id ASC");
                    string sistaRad = Db.GetValue("SELECT TOP 1 Id FROM TblStatus ORDER BY Id DESC");
                    command.CommandText = $"UPDATE TblStatus SET {used} = 0 WHERE Id BETWEEN {rad1} AND {sistaRad}";
                    command.ExecuteNonQuery();
                }
                connection.Close();
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
    public class Verb : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerbs WHERE Använt = 0 {Db.QueryRestrictions()}")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblVerbs SET Använt = 1 WHERE Id = {id}", Db.connectionString);
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

        public string Infinitiv(int id)
        {
            return Db.GetValue($"SELECT Infinitiv FROM TblVerbs WHERE Id = {id}");
        }

        public string Uppmaning(int id)
        {
            return Db.GetValue($"SELECT Uppmaning FROM TblVerbs WHERE Id = {id}");
        }

        public string Perfekt(int id)
        {
            return Db.GetValue($"SELECT Perfekt FROM TblVerbs WHERE Id = {id}");
        }

        public string Presens(int id)
        {
            return Db.GetValue($"SELECT Presens FROM TblVerbs WHERE Id = {id}");
        }

        public int RandomizeRelation()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerbs WHERE Använt = 0 AND [Relation] = 'True' {Db.QueryRestrictions()}")}");
        }
    }

    public class Adjektiv : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE Använt = 0 {Db.QueryRestrictions()}")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblAdjectives SET Använt = 1 WHERE Id = {id}", Db.connectionString);
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

        public string Plural(int id)
        {
            return $"{Db.GetValue($"SELECT Plural FROM TblAdjectives WHERE Id = {id}")}";
        }

        public string NGenus(int id)
        {
            return Db.GetValue($"SELECT [N-genus] FROM TblAdjectives WHERE Id = {id}");
        }

        public string TGenus(int id)
        {
            return Db.GetValue($"SELECT [T-genus] FROM TblAdjectives WHERE Id = {id}");
        }

        public string Automatic(int adjectiveId, int nounId, bool singular)
        {
            if (singular)
            {
                string genus = Db.GetValue($"SELECT Genus FROM TblNouns WHERE Id = {nounId}");

                if (genus == @"N-genus" || genus == @"N-undantag")
                    return Db.GetValue($"SELECT [N-genus] FROM TblAdjectives WHERE Id = {adjectiveId}");
                else if (genus == @"T-genus" || genus == @"T-undantag")
                {
                    return Db.GetValue($"SELECT [T-genus] FROM TblAdjectives WHERE Id = {adjectiveId}");
                }
                else { return ""; }
            }

            else
            {
                string genus = Db.GetValue($"SELECT Genus FROM TblNouns WHERE Id = {nounId}");

                if (genus == @"N-genus" || genus == @"T-genus")
                    return Db.GetValue($"SELECT Plural FROM TblAdjectives WHERE Id = {adjectiveId}");

                else if (genus == @"T-undantag")
                {
                    return Db.GetValue($"SELECT [T-genus] FROM TblAdjectives WHERE Id = {adjectiveId}");
                }

                else if (genus == @"N-undantag")
                {
                    return Db.GetValue($"SELECT [N-genus] FROM TblAdjectives WHERE Id = {adjectiveId}");
                }

                else { return ""; }
            }
        }

        public int RandomizeRelation()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE Använt = 0 AND [Relation] = 'True' {Db.QueryRestrictions()}")}");
        }
    }

    public class Substantiv : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Använt = 0 AND Benämner IN ('Något', 'Någon', 'Någon & Något') {Db.QueryRestrictions()}")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblNouns SET Använt = 1 WHERE Id = {id}", Db.connectionString);
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

        public string EnEllerEtt(int id)
        {
            //Koppla Primary key Id med foreign key Genus
            return Db.GetValue($"SELECT [en/ett] FROM TblGenus WHERE Id IN (SELECT [Genus] FROM TblNouns WHERE Id = {id})");
        }

        public string DinEllerDitt(int id, bool singular)
        {
            if (singular)
            {
                return Db.GetValue($"SELECT [din/ditt] FROM TblGenus WHERE Id IN (SELECT [Genus] FROM TblNouns WHERE Id = {id})");
            }
            else
            {
                return Db.GetValue($"SELECT [din/ditt plural] FROM TblGenus WHERE Id IN (SELECT [Genus] FROM TblNouns WHERE Id = {id})");
            }
        }

        public string SingularObest(int id)
        {
            return $"{Db.GetValue($"SELECT [Singular obestämd] FROM TblNouns WHERE Id = {id}")}";
        }

        public string SingularBest(int id)
        {
            return $"{Db.GetValue($"SELECT [Singular bestämd] FROM TblNouns WHERE Id = {id}")}";
        }

        public string Plural(int id)
        {
            return $"{Db.GetValue($"SELECT Plural FROM TblNouns WHERE Id = {id}")}";
        }
    }

    public class Någon : Substantiv
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Använt = 0 AND Benämner IN ('Någon', 'Någon & Något') {Db.QueryRestrictions()}")}");
        }

    }

    public class Något : Substantiv
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Använt = 0 AND Benämner IN ('Något', 'Någon & Något') {Db.QueryRestrictions()}")}");
        }
    }

    public class Plats : Substantiv
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Använt = 0 AND Benämner IN ('Plats', 'Någon & Plats') {Db.QueryRestrictions()}")}");
        }
    }

    public class NobelPris : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNobelPrizes WHERE Använt = 0")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblNobelPrizes SET Använt = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Prize(int id)
        {
            return $"{Db.GetValue($"SELECT Pris FROM TblNobelPrizes WHERE Id = {id}")}";
        }
    }

    public class SkämtNamn : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblJokeNames WHERE Använt = 0 {Db.QueryRestrictions()}")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblJokeNames SET Använt = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Name(int id)
        {
            return $"{Db.GetValue($"SELECT Namn FROM TblJokeNames WHERE Id = {id}")}";
        }
    }

    public class Status : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblStatus WHERE Använt = 0")}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblStatus SET Använt = 1 WHERE Id = {idNr}", Db.connectionString);
        }

        public string HighStatus(int id)
        {
            return Db.GetValue($"SELECT Högstatus FROM TblStatus WHERE Id = { id }");
        }

        public string LowStatus(int id)
        {
            return Db.GetValue($"SELECT Lågstatus FROM TblStatus WHERE Id = { id }");
        }
    }
}
  

