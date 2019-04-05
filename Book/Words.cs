using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Headline_Randomizer;

namespace English
{
    public abstract class Words
    {
        // Creating static object of the word classes to be called when using their mwthods
        static public Adjectives adjective = new Adjectives();
        static public Verbs verb = new Verbs();
        static public Someone someone = new Someone();
        static public Something something = new Something();
        static public JokeNames jokeName = new JokeNames();
        static public NobelPrizes nobelPrize = new NobelPrizes();
        static public Location location = new Location();
        static public Relation relation = new Relation();
        static public Status status = new Status();

        // Virtual methods here to be able to reach them through List<Words>
        public virtual string KänslaPlural()
        {
            return "";
        }

        public virtual string KänslaSingular()
        {
            return "";
        }

        public virtual string BasForm(int id)
        {
            return "";
        }

        public virtual string Presens(int id)
        {
            return "";
        }

        public virtual string Perfekt(int id)
        {
            return "";
        }

        public virtual string SForm()
        {
            return "";
        }

        public virtual string IngForm()
        {
            return "";
        }

        public virtual string Singular(int adjectiveId, int nounId)
        {
            return "";
        }

        public virtual string Plural(int adjectiveId, int nounId)
        {
            return "";
        }

        public virtual string Plural(int id)
        {
            return "";
        }

        public virtual string Singular(int id)
        {
            return "";
        }

        public virtual string Name(int id)
        {
            return "";
        }

        public virtual string Prize(int id)
        {
            return "";
        }

        public virtual string PostVerbs(int id)
        {
            return "";
        }

        public virtual string Request(int id)
        {
            return "";
        }

        public virtual string AOrAn()
        {
            return "";
        }

        public virtual string EnEllerEtt(int id)
        {
            return "";
        }

        public virtual string DinEllerDitt(int id, bool singular)
        {
            return "";
        }

        public virtual string EttForm(int id)
        {
            return "";
        }

        public virtual string EnForm(int id)
        {
            return "";
        }

        public virtual string Descriptive()
        {
            return "";
        }

        public virtual string Känsla()
        {
            return "";
        }

        public virtual string HighStatus(int id)
        {
            return "";
        }

        public virtual string LowStatus(int id)
        {
            return "";
        }

        public virtual string Feeling(int id)
        {
            return "";
        }

        public virtual int RandomizeId()
        {
            return 404;
        }

        public virtual void Used(int idNr) { }

    }

    // Words
    // Verbs
    public class Verbs : Words
    {
        public override int RandomizeId()
        {
            //return Db.GetValue($"SELECT TOP 1 * FROM TblVerb WHERE Used = 0 ORDER BY NEWID()");
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblVerb WHERE Used = 0 {Db.QueryRestrictions()}")}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblVerb SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
        }

        public override string BasForm(int id)
        {
            return Db.GetValue($"SELECT BaseForm FROM TblVerb WHERE Id = {id}");
        }

        public override string Presens(int id)
        {
            return Db.GetValue($"SELECT Presens FROM TblVerb WHERE Id = {id}");
        }

        public override string Perfekt(int id)
        {
            return Db.GetValue($"SELECT Perfekt FROM TblVerb WHERE Id = {id}");
        }

        public override string Request(int id)
        {
            return Db.GetValue($"SELECT Request FROM TblVerb WHERE Id = {id}");
        }

        public override string PostVerbs(int id)
        {
            if (Db.GetValue($"SELECT PostVerb FROM TblVerb WHERE Id = {id}") == "")
            {
                return "";
            }
            else
            {
                return $"{Db.GetValue($"SELECT PostVerb FROM TblVerb WHERE Id = {id}")} ";
            }


        }

        //public override string SForm()
        //{
        //    return sForm;
        //}

        //public override string IngForm()
        //{
        //    return ingForm;
        //}

        //// Swedish Constructor
        //public Verbs(string basForm, string presens, string perfekt, string postVerbs, string request) : base()
        //{
        //    this.basForm = basForm;
        //    this.presens = presens;
        //    this.perfekt = perfekt;
        //    this.postVerbs = postVerbs;
        //    this.request = request;
        //}

        //// English Constructor
        //public Verbs(string basForm, string sForm, string ingForm) : base()
        //{
        //    this.basForm = basForm;
        //    this.sForm = sForm;
        //    this.ingForm = ingForm;
        //}

        public Verbs()
        {

        }
    }

    // Nouns
    public abstract class Nouns : Words
    {
        public override string DinEllerDitt(int id, bool singular)
        {
            if (singular)
            {
                return Db.GetValue($"SELECT [din/ditt] FROM TblPreSubstantiv WHERE Id IN (SELECT [Pre Substantiv] FROM TblNouns WHERE Id = {id})");
            }
            else
            {
                return Db.GetValue($"SELECT [din/ditt plural] FROM TblPreSubstantiv WHERE Id IN (SELECT [Pre Substantiv] FROM TblNouns WHERE Id = {id})");
            }
        }

        public override string EnEllerEtt(int id)
        {
            // Koppla Primary key Id med foreign key Pre Substantiv
            return Db.GetValue($"SELECT [en/ett] FROM TblPreSubstantiv WHERE Id IN (SELECT [Pre Substantiv] FROM TblNouns WHERE Id = {id})");
        }

        public override string Plural(int id)
        {
            return Db.GetValue($"SELECT Plural FROM TblNouns WHERE Id = {id}");
        }

        public override string Singular(int id)
        {
            return Db.GetValue($"SELECT Singular FROM TblNouns WHERE Id = {id}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblNouns SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
        }
    }

    // Noun - Something
    public class Something : Nouns
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNouns WHERE Used = 0 AND Animated = 0 {Db.QueryRestrictions()}")}");
        }
    }

    // Noun - Someone
    public class Someone : Nouns
    {
        public override int RandomizeId()
        {
            string restrictions = Db.QueryRestrictions();
            return Convert.ToInt32($"{Db.RandomizeValue("SELECT Id", "FROM TblNouns WHERE Used = 0 AND Animated = 1" + " " + restrictions)}");
        }

        //public Someone() : base()
        //{

        //}

    }

    // Adjectives
    public class Adjectives : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblAdjective WHERE Used = 0 {Db.QueryRestrictions()}")}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblAdjective SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
        }

        public override string EttForm(int id)
        {
            return Db.GetValue($"SELECT EttForm FROM TblAdjective WHERE Id = {id}");
        }

        public override string EnForm(int id)
        {
            return Db.GetValue($"SELECT EnForm FROM TblAdjective WHERE Id = {id}");
        }

        public override string Plural(int id)
        {
            return Db.GetValue($"SELECT Plural FROM TblAdjective WHERE Id = {id}");
        }

        //public override string Descriptive()
        //{
        //    return descriptive;
        //}


        // Compares current adjective with the right noun and returns the right adjective
        public override string Singular(int adjectiveId, int nounId)
        {
            string preSub = Db.GetValue($"SELECT [Pre Substantiv] FROM TblNouns WHERE Id = {nounId}");

            if (preSub == @"din/dina" || preSub == @"din/din")
                return Db.GetValue($"SELECT EnForm FROM TblAdjective WHERE Id = {adjectiveId}");
            else if (preSub == @"ditt/dina" || preSub == @"ditt/ditt")
            {
                return Db.GetValue($"SELECT EttForm FROM TblAdjective WHERE Id = {adjectiveId}");
            }
            else { return ""; }
        }

        public override string Plural(int adjectiveId, int nounId)
        {

            string preSub = Db.GetValue($"SELECT [Pre Substantiv] FROM TblNouns WHERE Id = {nounId}");

            if (preSub == @"din/dina" || preSub == @"ditt/dina")
                return Db.GetValue($"SELECT Plural FROM TblAdjective WHERE Id = {adjectiveId}");

            else if (preSub == @"ditt/ditt")
            {
                return Db.GetValue($"SELECT EttForm FROM TblAdjective WHERE Id = {adjectiveId}");
            }

            else if (preSub == @"din/din")
            {
                return Db.GetValue($"SELECT EnForm FROM TblAdjective WHERE Id = {adjectiveId}");
            }

            else { return ""; }
        }

        //// Swedish Constructor
        //public Adjectives(string enForm, string plural, string ettForm) : base()
        //{
        //    this.enForm = enForm;
        //    this.plural = plural;
        //    this.ettForm = ettForm;
        //}

        ////English constructor
        //public Adjectives(string descriptive) : base()
        //{
        //    this.descriptive = descriptive;
        //}

        public Adjectives()
        {

        }
    }

    // Names
    public abstract class Names : Words
    {
    }

    // Joke Names
    public class JokeNames : Names
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblJokeNames WHERE Used = 0 {Db.QueryRestrictions()}")}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblJokeNames SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
        }

        public override string Name(int id)
        {
            return Db.GetValue($"SELECT Name FROM TblJokeNames WHERE Id = { id }");
        }

    }

    public class Location : Names
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblPlats WHERE Used = 0 {Db.QueryRestrictions()}")}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblPlats SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
        }

        public override string Name(int id)
        {
            return Db.GetValue($"SELECT Plats FROM TblPlats WHERE Id = { id }");
        }
    }

    // Nobel prize
    public class NobelPrizes : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblNobelPrizes WHERE Used = 0")}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblNobelPrizes SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
        }

        public override string Prize(int id)
        {
            return Db.GetValue($"SELECT Prize FROM TblNobelPrizes WHERE Id = { id }");
        }
    }

    public class Relation : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblRelation WHERE Used = 0")}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblRelation SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
        }

        public override string Feeling(int id)
        {
            return Db.GetValue($"SELECT Känsla FROM TblRelation WHERE Id = { id }");
        }
    }

    public class Status : Words
    {
        public override int RandomizeId()
        {
            return Convert.ToInt32($"{Db.RandomizeValue("Select Id", $"FROM TblStatus WHERE Used = 0")}");
        }

        public override void Used(int idNr)
        {
            Db.Command($"UPDATE TblStatus SET Used = 1 WHERE Id = {idNr}", Db.connectionString);
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
