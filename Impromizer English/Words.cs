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

        public Random r = new Random();
        
        static public string[,] idQueries = UpdateIdQueries();
        //static public string[,] resetQueries = UpdateResetQueries();

        public static string SuitableFor()
        {
            return $"[Suitable for] IN ('Children', 'Adolescents', 'Adults')";
        }

        //static public string[,] UpdateResetQueries()
        //{
        //    string suitableFor = SuitableFor();

        //    string[,] resetQueries =
        //    {
        //        {"TblAdjectives", $"{suitableFor} AND Fits = 'Someone (Strict)'"},
        //        {"TblAdjectives", $"{suitableFor} AND Fits = 'Someone & Something'"},
        //        {"TblAdjectives", $"{suitableFor} AND Fits = 'Relation (Strict)'"},
        //        {"TblAdjectives", $"{suitableFor} AND Fits = 'Relation & Something'"},
        //        {"TblJokeNames", $"{suitableFor}"},
        //        {"TblMissions", $"{suitableFor}"},
        //        {"TblNobelPrizes", $"{suitableFor}"},
        //        {"TblNouns", $"{suitableFor} AND [Term for] = 'Someone'"},
        //        {"TblNouns", $"{suitableFor} AND [Term for] = 'Something'"},
        //        {"TblStatus", $"{suitableFor}"},
        //        {"TblVerbs", $"{suitableFor} AND Fits IN ('Someone (Strict)', 'Someone')"},
        //        {"TblVerbs", $"{suitableFor} AND Fits = 'Something'"},
        //        {"TblVerbs", $"{suitableFor} AND Fits = 'Someone & Something'"},
        //        {"TblVerbs", $"{suitableFor} AND Fits IN ('Relation (Strict)', 'Relation')"},
        //        {"TblVerbs", $"{suitableFor} AND Fits = 'Relation & Something'"},

        //    };

        //    return resetQueries;
        //}

        static public string[,] UpdateIdQueries()
        {
            string suitableFor = SuitableFor();

            string[,] idQueries =
            {
                // 0 = Adjectives that fits Something
                { "TblAdjectives", $"{suitableFor} AND NOT Fits IN ('Someone (Strict)', 'Relation (Strict)')" },
                // 1 = Adjectives that fits Someone
                { "TblAdjectives", $"{suitableFor} AND NOT Fits = 'Something (Strict)'"},
                // 2
                { "TblJokeNames", $"{suitableFor}"},
                // 3
                { "TblMissions", $"{suitableFor}"},
                // 4
                { "TblNobelPrizes", $"{suitableFor}"},
                // 5 = Nouns that are terms for Someone
                { "TblNouns", $"{suitableFor} AND [Term for] IN ('Someone', 'Someone & Something')"},
                // 6 = Nouns that are terms for Something
                { "TblNouns", $"{suitableFor} AND [Term for] IN ('Something', 'Someone & Something')"},
                // 7 = Nouns that are terms for location *** FIX *** This is a placeholder for location
                { "TblNouns", $"{suitableFor} AND [Term for] IN ('Something', 'Someone & Something')"},
                // 8
                { "TblStatus", $"{suitableFor}"},
                // 9 = Verbs that fits Something
                { "TblVerbs", $"{suitableFor} AND NOT Fits IN ('Someone (Strict)', 'Relation (Strict)')"},
                // 10
                { "TblVerbs", $"{suitableFor} AND NOT Fits = 'Something (Strict)'"},
                // 11 Relation Verbs
                { "TblVerbs", $"{suitableFor} AND Fits IN ('Relation (Strict)', 'Relation', 'Relation & Something')"},
                // 12 Relation Adjectives
                { "TblAdjectives", $"{suitableFor} AND Fits IN ('Relation (Strict)', 'Relation & Something')"}
            };

            return idQueries;
        }

        //static public void FreeNeeded(int limit)
        //{
        //    for (int i = 0; i < resetQueries.Length / 2; i++)
        //    {
        //        Db.SetMultiple(resetQueries[i, 0], resetQueries[i, 1], "Used = 0", limit);
        //    }
        //}

        public virtual int RandomizeId(string fromStatement = "")
        {
            return 404;
        }

        public virtual int RandomizeId(int nounId, string nonNounTable = "")
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
        public override int RandomizeId(string fromStatement = "TblVerbs")
        {
            int idNr = Convert.ToInt32($"{Db.RandomizeValue("TblVerbs", fromStatement, idQueries[10, 1])}");
            this.Used(idNr);
            return idNr;
        }

        public override int RandomizeId(int nounId, string fromStatement= "TblVerbs")
        {
            string termFor;

            if (nounId == 0)
            {
                termFor = "Someone";
            }
            else
            {
                termFor = Db.GetValue($"SELECT [Term for] FROM TblNouns WHERE Id = {nounId}", Db.connectionString);
            }

            int idNr = 0;

            if (termFor == "Someone" || termFor == "Someone & Location" || termFor == "Someone & Something")
            {
                idNr = Convert.ToInt32($"{Db.RandomizeValue("TblVerbs", fromStatement, idQueries[10, 1])}");
            }
            else if (termFor == "Something" || termFor == "Someone & Something")
            {
                idNr = Convert.ToInt32($"{Db.RandomizeValue("TblVerbs", fromStatement, idQueries[9, 1])}");
            }

            this.Used(idNr);
            return idNr;
        }

        public int RandomizeRelation()
        {
            int idNr = Convert.ToInt32($"{Db.RandomizeValue("TblVerbs", "TblVerbs", idQueries[11, 1])}");
            this.Used(idNr);
            return idNr;
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblVerbs SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Preposition(int id)
        {
            string prep = $"{Db.GetValue($"SELECT Preposition FROM TblVerbs WHERE Id = {id}", Db.connectionString)}";

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
            return Db.GetValue($"SELECT Base FROM TblVerbs WHERE Id = {id}", Db.connectionString);
        }

        public string IngForm(int id)
        {
            return Db.GetValue($"SELECT [-ing] FROM TblVerbs WHERE Id = {id}", Db.connectionString);
        }

        public string SForm(int id)
        {
            return Db.GetValue($"SELECT [-s] FROM TblVerbs WHERE Id = {id}", Db.connectionString);
        }

        public string PerfektparticipForm(int id)
        {
            return Db.GetValue($"SELECT Perfektparticip FROM TblVerbs WHERE Id = {id}", Db.connectionString);
        }
    }

    public class Adjectives : Words
    {
        public override int RandomizeId(string fromStatement = "TblAdjectives")
        {
            // *** FIX *** This now ignored Something (Strict)
            // Id queries only in the randomizedId -method that take a nounId?
            // Hur ska jag göra det tydligt att användaren själv inte behöver göra someone/something queryn?
            
            // Jag behöver kunna sätta in en whereStatement i RandomizeId för nuvarande lösningen av att kunna 
            // slumpa fram positiva och negativa relationer. Detta pga att jag inte vill behöva ha en tabell för positiva relationer
            // och en annan för negativa
            // whereStatementForJoinedTable
            // Secondarytable?
            // rename first parameter to primarytable? - Nope because they don't see that in RandomizeId

            // Glöm inte att skapa en ny branch innan du startar dessa ändringar. 
            // Eller alltså det skulle kunna vara möjligt att göra en where-statement på someone och something också
            // Och då kan kanske den som tar in nounId vara tydlig med att den löser det?
            // Used behövs inte
            // Inte suitable for
            // Maybe only have fromStatement be joinStatement?
            // Then where statement for join?


            int idNr = Convert.ToInt32($"{Db.RandomizeValue("TblAdjectives", fromStatement, idQueries[1,1])}");
            this.Used(idNr);
            return idNr;
        }

        public override int RandomizeId(int nounId, string fromStatement = "TblAdjectives")
        {
            string termFor;

            if (nounId == 0)
            {
                termFor = "Someone";
            }
            else
            {
                termFor = Db.GetValue($"SELECT [Term for] FROM TblNouns WHERE Id = {nounId}", Db.connectionString);
            }
            
            int idNr = 0;

            if (termFor == "Someone" || termFor == "Someone & Location" || termFor == "Someone & Something")
            {
                idNr = Convert.ToInt32($"{Db.RandomizeValue("TblAdjectives", fromStatement, idQueries[1, 1])}");
            }
            else if (termFor == "Something" || termFor == "Someone & Something")
            {
                idNr = Convert.ToInt32($"{Db.RandomizeValue("TblAdjectives", fromStatement, idQueries[0, 1])}");
            }

            this.Used(idNr);
            return idNr;
        }

        public int RandomizeRelation()
        {
            int idNr = Convert.ToInt32($"{Db.RandomizeValue("TblAdjectives", "TblAdjectives", idQueries[12, 1])}");
            this.Used(idNr);
            return idNr;
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblAdjectives SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Preposition(int id)
        {
            string prep = $"{Db.GetValue($"SELECT Preposition FROM TblAdjectives WHERE Id = {id}", Db.connectionString)}";
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
            return $"{Db.GetValue($"SELECT Descriptive FROM TblAdjectives WHERE Id = {id}", Db.connectionString)}";
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
    }

    public class Nouns : Words
    {
        public override int RandomizeId(string fromStatement = "TblNouns")
        {
            int slant = r.Next(0, 2);
            int result = slant == 0 ? someone.RandomizeId(fromStatement) : something.RandomizeId(fromStatement);
            return result;
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblNouns SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Preposition(int id)
        {
            string prep = $"{Db.GetValue($"SELECT Preposition FROM TblNouns WHERE Id = {id}", Db.connectionString)}";
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
            string result = Db.GetValue($"SELECT [A/An] FROM TblNouns WHERE Id = {id}", Db.connectionString);

            if (result == "")
            {
                return " ";
            }
            else
            {
                return $" {result} ";
            }
        }

        public string Singular(int id)
        {
            return $"{Db.GetValue($"SELECT [Singular] FROM TblNouns WHERE Id = {id}", Db.connectionString)}";
        }

        public string Plural(int id)
        {
            return $"{Db.GetValue($"SELECT Plural FROM TblNouns WHERE Id = {id}", Db.connectionString)}";
        }
    }

    public class Someone : Nouns
    {
        public override int RandomizeId(string fromStatement = "TblNouns")
        {
            int idNr = Convert.ToInt32($"{Db.RandomizeValue("TblNouns", fromStatement, idQueries[5, 1])}");
            this.Used(idNr);
            return idNr;
        }

    }

    public class Something : Nouns
    {
        public override int RandomizeId(string fromStatement = "TblNouns")
        {
            int idNr = Convert.ToInt32($"{Db.RandomizeValue("TblNouns", fromStatement, idQueries[6, 1])}");
            this.Used(idNr);
            return idNr;
        }
    }

    //public class Plats : Nouns
    //{
    //    public override int RandomizeId()
    //    {
    //        return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Used = 0 AND Benämner IN ('Plats', 'Någon & Plats') {QueryRestrictions()("AND")}")}");
    //    }
    //}

    public class NobelPrizes : Words
    {
        public override int RandomizeId(string fromStatement = "TblNobelPrizes")
        {
            int idNr = Convert.ToInt32($"{Db.RandomizeValue("TblNobelPrizes", fromStatement, idQueries[4,1])}");
            this.Used(idNr);
            return idNr;
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblNobelPrizes SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Prize(int id)
        {
            return $"{Db.GetValue($"SELECT Prize FROM TblNobelPrizes WHERE Id = {id}", Db.connectionString)}";
        }
    }

    public class JokeNames : Words
    {
        public override int RandomizeId(string fromStatement = "TblJokeNames")
        {
            int idNr = Convert.ToInt32($"{Db.RandomizeValue("TblJokeNames", fromStatement, idQueries[2,1])}");
            this.Used(idNr);
            return idNr;
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblJokeNames SET Used = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Name(int id)
        {
            return $"{Db.GetValue($"SELECT Name FROM TblJokeNames WHERE Id = {id}", Db.connectionString)}";
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
    //        return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblMissions WHERE Used = 0 {QueryRestrictions()("AND")}")}");
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
