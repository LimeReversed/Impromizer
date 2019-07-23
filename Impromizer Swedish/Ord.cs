// Since this is a different namespace I need to add Headline_Randomizer here to 
// connect to things that are there. 
using Headline_Randomizer;
using System;
using System.Text;

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
            if (Common.fullVersion)
            {
                StringBuilder builder = new StringBuilder();

                if (Config.GetRegValue("SuitableForChildren", "1") == "1")
                {
                    builder.Append("'Barn', ");
                }
                if (Config.GetRegValue("SuitableForAdolescents", "1") == "1")
                {
                    builder.Append("'Ungdomar', ");
                }
                if (Config.GetRegValue("SuitableForAdults", "1") == "1")
                {
                    builder.Append("'Vuxna', ");
                }
                if (Config.GetRegValue("SuitableForunoffendable", "0") == "1")
                {
                    builder.Append("'Okränkbara', ");
                }

                builder.Remove(builder.Length - 2, 2);
                string restriction = $"[Lämpligt för] IN({builder.ToString()})";
                return restriction;
            }

            else
            {
                return $"[Lämpligt för] IN ('Barn', 'Ungdomar', 'Vuxna')";
            }

        }

        // Här skapas en array med alla queries som behövs för att återställa de kategorier som behöver
        // återställas från "Använt" till oanvänt. Tanken är att ingen query ska titta på en kategori
        // som en anna query tittar på. Detta gör att vissa kan slås ihop och vissa inte kan det. 
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
                {"TblNouns", $"{suitableFor} AND [Benämner] = 'Plats'"},
                {"TblStatus", $"{suitableFor}"},
                {"TblVerbs", $"{suitableFor} AND Passar IN ('Någon (Strikt)', 'Någon')"},
                {"TblVerbs", $"{suitableFor} AND Passar = 'Något'"},
                {"TblVerbs", $"{suitableFor} AND Passar = 'Någon & Något'"},
                {"TblVerbs", $"{suitableFor} AND Passar IN ('Relation (Strikt)', 'Relation')"},
            };

            return resetQueries;
        }
         
        // Skapa array med queries som används för att generera ord. Detta för att slippa ändra på
        // flera olika ställen när jag vill uppdatera dessa queries. 
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

        // Loopa ovanstånede resetQueries för att frigöra de som behövs frigöras. 
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
                benämner = Db.GetValue($"SELECT Benämner FROM TblNouns WHERE Id = {nounId}", Db.connectionString);
            }

            int result = 0;

            if (benämner == "Någon" || benämner == "Någon & Plats" || benämner == "Någon & Något")
            {
                result = Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerbs WHERE {idQueries[10, 1]} AND Använt = 0")}");
            }
            else if (benämner == "Något" || benämner == "Någon & Något" || benämner == "Plats")
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

        public string Infinitiv(int id)
        {
            return Db.GetValue($"SELECT Infinitiv FROM TblVerbs WHERE Id = {id}", Db.connectionString);
        }

        public string Uppmaning(int id)
        {
            return Db.GetValue($"SELECT Uppmaning FROM TblVerbs WHERE Id = {id}", Db.connectionString);
        }

        public string Perfekt(int id)
        {
            return Db.GetValue($"SELECT Perfekt FROM TblVerbs WHERE Id = {id}", Db.connectionString);
        }

        public string Presens(int id)
        {
            return Db.GetValue($"SELECT Presens FROM TblVerbs WHERE Id = {id}", Db.connectionString);
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
                benämner = Db.GetValue($"SELECT Benämner FROM TblNouns WHERE Id = {nounId}", Db.connectionString);
            }

            int result = 0;

            if (benämner == "Någon" || benämner == "Någon & Plats" || benämner == "Någon & Något")
            {
                result = Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjectives WHERE {idQueries[1, 1]} AND Använt = 0")}");
            }
            else if (benämner == "Något" || benämner == "Någon & Något" || benämner == "Plats")
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
        public string Plural(int id)
        {
            return $"{Db.GetValue($"SELECT Plural FROM TblAdjectives WHERE Id = {id}", Db.connectionString)}";
        }

        public string NGenus(int id)
        {
            return Db.GetValue($"SELECT [N-genus] FROM TblAdjectives WHERE Id = {id}", Db.connectionString);
        }

        public string TGenus(int id)
        {
            return Db.GetValue($"SELECT [T-genus] FROM TblAdjectives WHERE Id = {id}", Db.connectionString);
        }

        public string Automatic(int adjectiveId, int nounId, bool singular)
        {
            if (singular)
            {
                string genus = nounId == 0 ? "N-genus" : $"{Db.GetValue($"SELECT Genus FROM TblNouns WHERE Id = {nounId}", Db.connectionString)}";

                if (genus == @"N-genus" || genus == @"N-undantag")
                    return Db.GetValue($"SELECT [N-genus] FROM TblAdjectives WHERE Id = {adjectiveId}", Db.connectionString);
                else if (genus == @"T-genus" || genus == @"T-undantag")
                {
                    return Db.GetValue($"SELECT [T-genus] FROM TblAdjectives WHERE Id = {adjectiveId}", Db.connectionString);
                }
                else { return ""; }
            }

            else
            {
                string genus = nounId == 0 ? "N-genus" : $"{Db.GetValue($"SELECT Genus FROM TblNouns WHERE Id = {nounId}", Db.connectionString)}";

                if (genus == @"N-genus" || genus == @"T-genus")
                    return Db.GetValue($"SELECT Plural FROM TblAdjectives WHERE Id = {adjectiveId}", Db.connectionString);

                else if (genus == @"T-undantag")
                {
                    return Db.GetValue($"SELECT [T-genus] FROM TblAdjectives WHERE Id = {adjectiveId}", Db.connectionString);
                }

                else if (genus == @"N-undantag")
                {
                    return Db.GetValue($"SELECT [N-genus] FROM TblAdjectives WHERE Id = {adjectiveId}", Db.connectionString);
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

        public string EnEllerEtt(int id)
        {
            //Koppla Primary key Id med foreign key Genus
            string result = Db.GetValue($"SELECT [En/Ett] FROM TblGenus WHERE Id IN (SELECT [Genus] FROM TblNouns WHERE Id = {id})", Db.connectionString);

            if (result == "")
            {
                return " ";
            }
            else
            {
                return $" {result} ";
            }
        }

        public string DinEllerDitt(int id, bool singular)
        {
            if (singular)
            {
                return Db.GetValue($"SELECT [Din/Ditt] FROM TblGenus WHERE Id IN (SELECT Genus FROM TblNouns WHERE Id = {id})", Db.connectionString);
            }
            else
            {
                return Db.GetValue($"SELECT [Din/Ditt Plural] FROM TblGenus WHERE Id IN (SELECT Genus FROM TblNouns WHERE Id = {id})", Db.connectionString);
            }
        }

        public string SingularObest(int id)
        {
            return $"{Db.GetValue($"SELECT [Singular obestämd] FROM TblNouns WHERE Id = {id}", Db.connectionString)}";
        }

        public string SingularBest(int id)
        {
            return $"{Db.GetValue($"SELECT [Singular bestämd] FROM TblNouns WHERE Id = {id}", Db.connectionString)}";
        }

        public string Plural(int id)
        {
            return $"{Db.GetValue($"SELECT Plural FROM TblNouns WHERE Id = {id}", Db.connectionString)}";
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
            return $"{Db.GetValue($"SELECT Pris FROM TblNobelPrizes WHERE Id = {id}", Db.connectionString)}";
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
            return $"{Db.GetValue($"SELECT Namn FROM TblJokeNames WHERE Id = {id}", Db.connectionString)}";
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
            return Db.GetValue($"SELECT Högstatus FROM TblStatus WHERE Id = { id }", Db.connectionString);
        }

        public string LowStatus(int id)
        {
            return Db.GetValue($"SELECT Lågstatus FROM TblStatus WHERE Id = { id }", Db.connectionString);
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
            return $"{Db.GetValue($"SELECT [Uppdrag] FROM TblMissions WHERE Id = {id}", Db.connectionString)}";
        }
    }

    // Låt mig presentera nya Scentences. Den här genererar inte bara ord som ovan utan bygger hela meningar. 
   
    public class Sentences
    {
        public static Random r = new Random();

        // När jag vill bygga relation ändras meningen på särskilda sätt när det är ett verb, ett adjektiv
        // eller ett adjektiv med en preposition. Istället för att skriva den här algoritmen flera gånger om
        // skapade jag istället en metod som fungerar vilken relation jag än vill bygga. Den tar emot parametrar
        // om vilken text som ska vara innan och efter de ovanstående variationerna och info om verbform
        // och den info som "adjective.Automatisk()" behöver. 
        public static string BuildRelation(string preVerb, string postVerb, string preA1, string postA1, string preA2, string postA2,
                        string verbForm, bool a1Singular, int a1NounNr, bool a2Singular, int a2NounNr, int slant)
        {
            string result = "";

            if (slant == 0)
            {
                int verbNr = Words.verb.RandomizeRelation();
                string verb = Db.GetValue($"SELECT [{verbForm}] FROM TblVerbs WHERE Id = {verbNr}", Db.connectionString);
                string preposition = Words.verb.Preposition(verbNr);

                result = $"{preVerb} {verb}{preposition}{postVerb}";

                Words.verb.Used(verbNr);
            }
            else
            {
                int aNr = Words.adjective.RandomizeRelation();
                string adjective = Words.adjective.Automatic(aNr, a1NounNr, a1Singular);
                string adjective2 = Words.adjective.Automatic(aNr, a2NounNr, a2Singular);
                string preposition = Words.adjective.Preposition(aNr);

                switch (preposition)
                {
                    case " ":
                        result = $"{preA1} {adjective} {postA1}";
                        break;

                    default:
                        result = $"{preA2} {adjective2}{preposition}{postA2}";
                        break;
                }

                Words.adjective.Used(aNr);
            }

            return result;
        }
    }
}
  

