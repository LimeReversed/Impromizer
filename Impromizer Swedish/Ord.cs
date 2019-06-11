using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
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
        public static Uppdrag uppdrag = new Uppdrag();

        public Random r = new Random();

        public static string[,] idQueries = UpdateIdQueries();
        public static string[,] resetQueries = UpdateResetQueries();
        
        public static string SuitableFor()
        {
            return $"[Lämpligt för] IN ('Barn', 'Ungdomar', 'Vuxna')";
        }

        static public string[,] UpdateResetQueries()
        {
            string suitableFor = SuitableFor();

            string[,] resetQueries =
            {
                {"TblAdjectives", $"{suitableFor} AND Passar = 'Någon (Strikt)'"},
                {"TblAdjectives", $"{suitableFor} AND Passar = 'Någon & Något'"},
                {"TblAdjectives", $"{suitableFor} AND Passar IN ('Relation (Strikt)', 'Relation')"},
                {"TblAdjectives", $"{suitableFor} AND Passar = 'Relation & Något'"},
                {"TblJokeNames", $"{suitableFor}"},
                {"TblMissions", $"{suitableFor}"},
                {"TblNobelPrizes", $"{suitableFor}"},
                {"TblNouns", $"{suitableFor} AND [Benämner] IN ('Någon', 'Någon & Plats')"},
                {"TblNouns", $"{suitableFor} AND [Benämner] = 'Något'"},
                {"TblStatus", $"{suitableFor}"},
                {"TblVerbs", $"{suitableFor} AND Passar IN ('Någon (Strikt)', 'Någon')"},
                {"TblVerbs", $"{suitableFor} AND Passar = 'Något'"},
                {"TblVerbs", $"{suitableFor} AND Passar = 'Någon & Något'"},
                {"TblVerbs", $"{suitableFor} AND Passar IN ('Relation (Strikt)', 'Relation')"},
            };

            return resetQueries;
        }

        static public string[,] UpdateIdQueries()
        {
            string suitableFor = SuitableFor();

            string[,] idQueries =
            {
                // 0 = Adjectives that fits Something
                { "TblAdjectives", $"{suitableFor} AND NOT Passar IN ('Någon (Strikt)', 'Relation (Strikt)')"},
                // 1 = Adjectives that fits Someone
                { "TblAdjectives", $"{suitableFor}"},
                // 2
                { "TblJokeNames", $"{suitableFor}"},
                // 3
                { "TblMissions", $"{suitableFor}"},
                // 4
                { "TblNobelPrizes", $"{suitableFor}"},
                // 5 = Nouns that are terms for Someone
                { "TblNouns", $"{suitableFor} AND Benämner IN ('Någon', 'Någon & Något', 'Någon & Plats')"},
                // 6 = Nouns that are terms for Something
                { "TblNouns", $"{suitableFor} AND Benämner IN ('Något', 'Någon & Något')"},
                // 7 = Nouns that are terms for location
                { "TblNouns", $"{suitableFor} AND Benämner IN ('Plats', 'Någon & Plats')"},
                // 8
                { "TblStatus", $"{suitableFor}"},
                // 9 = Verbs that fits Something
                { "TblVerbs", $"{suitableFor} AND NOT Passar IN ('Någon (Strikt)', 'Relation (Strikt)')"},
                // 10 = Verbs that fit Someone
                { "TblVerbs", $"{suitableFor}"},
                // 11 = Verb Relations
                { "TblVerbs", $"{suitableFor} AND Passar IN ('Relation', 'Relation (Strikt)')"},
                // 12 = Adjective Relations
                { "TblAdjectives", $"{suitableFor} AND Passar IN ('Relation', 'Relation (Strikt)', 'Relation & Något')"}
            };

            return idQueries;
        }

        static public void FreeNeeded(int limit)
        {
            for (int i = 0;  i < resetQueries.Length / 2; i++)
            {
                Db.SetMultiple(resetQueries[i, 0], resetQueries[i, 1], "Använt = 0", limit);
            }
        }

        public virtual int RandomizeId()
        {
            return 404;
        }

        public virtual int RandomizeId(int nounId)
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
            return Convert.ToInt32($"{Db.RandomizeValue($"Select Id", $"FROM TblVerbs WHERE {idQueries[10, 1]} AND Använt = 0")}");
        }

        public override int RandomizeId(int nounId)
        {
            string benämner;

            if (nounId == 0)
            {
                benämner = "Någon";
            }
            else
            {
                benämner = Db.GetValue($"SELECT Benämner FROM TblNouns WHERE Id = {nounId}");
            }

            int result = 0;

            if (benämner == "Någon" || benämner == "Någon & Plats" || benämner == "Någon & Något")
            {
                result = Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerbs WHERE {idQueries[10, 1]} AND Använt = 0")}");
            }
            else if (benämner == "Något" || benämner == "Någon & Något")
            {
                result = Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerbs WHERE {idQueries[9, 1]} AND Använt = 0")}");
            }

            return result;
        }

        public int RandomizeRelation()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerbs WHERE {idQueries[11,1]} AND Använt = 0")}");
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
    }

    public class Adjektiv : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE {idQueries[1,1]} AND Använt = 0")}");
        }

        public override int RandomizeId(int nounId)
        {
            string benämner;

            if (nounId == 0)
            {
                benämner = "Någon";
            }
            else
            {
                benämner = Db.GetValue($"SELECT Benämner FROM TblNouns WHERE Id = {nounId}");
            }

            int result = 0;

            if (benämner == "Någon" || benämner == "Någon & Plats" || benämner == "Någon & Något")
            {
                result = Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE {idQueries[1, 1]} AND Använt = 0")}");
            }
            else if (benämner == "Något" || benämner == "Någon & Något")
            {
                result = Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE {idQueries[0, 1]} AND Använt = 0")}");
            }

            return result;
        }

        public int RandomizeRelation()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE {idQueries[12, 1]} AND Använt = 0")}");
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
    }

    public class Substantiv : Words
    {
        public override int RandomizeId()
        {
            int slant = r.Next(0, 2);
            int result = slant == 0 ? someone.RandomizeId() : something.RandomizeId();
            return result;
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
            return Db.GetValue($"SELECT [En/Ett] FROM TblGenus WHERE Id IN (SELECT [Genus] FROM TblNouns WHERE Id = {id})");
        }

        public string DinEllerDitt(int id, bool singular)
        {
            if (singular)
            {
                return Db.GetValue($"SELECT [Din/Ditt] FROM TblGenus WHERE Id IN (SELECT Genus FROM TblNouns WHERE Id = {id})");
            }
            else
            {
                return Db.GetValue($"SELECT [Din/Ditt Plural] FROM TblGenus WHERE Id IN (SELECT Genus FROM TblNouns WHERE Id = {id})");
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
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE {idQueries[5,1]} AND Använt = 0")}");
        }

    }

    public class Något : Substantiv
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE {idQueries[6, 1]} AND Använt = 0")}");
        }
    }

    public class Plats : Substantiv
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE {idQueries[7, 1]} AND Använt = 0")}");
        }
    }

    public class NobelPris : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNobelPrizes WHERE {idQueries[4,1]} AND Använt = 0")}");
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
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblJokeNames WHERE {idQueries[2,1]} AND Använt = 0")}");
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
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblStatus WHERE {idQueries[8,1]} AND Använt = 0")}");
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

    public class Uppdrag : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblMissions WHERE {idQueries[3,1]} AND Använt = 0")}");
        }

        public override void Used(int id)
        {
            Db.Command($"UPDATE TblMissions SET Använt = 1 WHERE Id = {id}", Db.connectionString);
        }

        public string Beskrivning(int id)
        {
            return $"{Db.GetValue($"SELECT [Uppdrag] FROM TblMissions WHERE Id = {id}")}";
        }
    }
}
  

