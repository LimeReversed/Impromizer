using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headline_Randomizer
{
    public abstract class Words
    {
        // Virtual methods here to be able to reach them through List<Words>
        public virtual string BasForm()
        {
            return "";
        }

        public virtual string Presens()
        {
            return "";
        }

        public virtual string Perfekt()
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

        public virtual string Singular()
        {
            return "";
        }

        public virtual string Singular(List<Words> nounList, int nounNr)
        {
            return "";
        }

        public virtual string Plural(List<Words> nounList, int nounNr)
        {
            return "";
        }

        public virtual string Plural()
        {
            return "";
        }

        public virtual string Name()
        {
            return "";
        }

        public virtual string Prize()
        {
            return "";
        }

        public virtual string PostVerbs()
        {
            return "";
        }

        public virtual string Request()
        {
            return "";
        }

        public virtual Indefinite EnEllerEttEnum()
        {
            return 0;
        }

        public virtual Indefinite AOrAnEnum()
        {
            return 0;
        }

        public virtual string AOrAn()
        {
            return "";
        }

        public virtual Genitive DinEllerDittEnum()
        {
            return 0;
        }

        public virtual string EnEllerEtt()
        {
            return "";
        }

        public virtual string DinEllerDitt(string pluralOrSingular)
        {
            return "";
        }

        public virtual string EttForm()
        {
            return "";
        }

        public virtual string EnForm()
        {
            return "";
        }

        public virtual string Descriptive()
        {
            return "";
        }
    }

    // Words
    // Verbs
    public class Verbs : Words
    {
        protected string basForm;
        protected string presens;
        protected string perfekt;
        protected string postVerbs;
        protected string request;
        protected string sForm;
        protected string ingForm;

        public override string BasForm()
        {
            return basForm;
        }

        public override string Presens()
        {
            return presens;
        }

        public override string Perfekt()
        {
            return perfekt;
        }

        public override string Request()
        {
            return request;
        }

        public override string PostVerbs()
        {
            if (postVerbs == "")
            {
                return "";
            }
            else
            {
                return $"{postVerbs} ";
            }
            
        }

        public override string SForm()
        {
            return sForm;
        }

        public override string IngForm()
        {
            return ingForm;
        }

        // Swedish Constructor
        public Verbs(string basForm, string presens, string perfekt, string postVerbs, string request) : base()
        {
            this.basForm = basForm;
            this.presens = presens;
            this.perfekt = perfekt;
            this.postVerbs = postVerbs;
            this.request = request;
        }

        // English Constructor
        public Verbs(string basForm, string sForm, string ingForm) : base()
        {
            this.basForm = basForm;
            this.sForm = sForm;
            this.ingForm = ingForm;
        }
    }

    // Nouns
    public abstract class Nouns : Words
    {
        protected string singular;
        protected string plural;
        protected Indefinite enEllerEtt;
        protected Genitive dinEllerDitt;
        protected Indefinite aOrAn;

        public override Indefinite AOrAnEnum()
        {
            return aOrAn;
        }

        public override Indefinite EnEllerEttEnum()
        {
            return enEllerEtt;
        }

        public override Genitive DinEllerDittEnum()
        {
            return dinEllerDitt;
        }

        // Compares with the current noun and returns the right genitive. 
        public override string AOrAn()
        {
            if (aOrAn == Indefinite.A)
            {
                return "a";
            }
            else if (aOrAn == Indefinite.An)
            {
                return "an";
            }
            else { return ""; }
        }

        // Compares with the current noun and returns the right indefinite. 
        public override string EnEllerEtt()
        {
            if (this.EnEllerEttEnum() == Indefinite.En)
            {
                return "en";
            }
            else if (this.EnEllerEttEnum() == Indefinite.Ett)
            {
                return "ett";
            }
            else { return ""; }
        }

        // Compares with the current noun and returns the right genitive. 
        public override string DinEllerDitt(string pluralOrSingular)
        {
            if (pluralOrSingular == "singular")
            {
                if (this.dinEllerDitt == Genitive.DinDina || this.dinEllerDitt == Genitive.DinDin)
                {
                    return "din";
                }
                else if (this.dinEllerDitt == Genitive.DittDina || this.dinEllerDitt == Genitive.DittDitt)
                {
                    return "ditt";
                }
                else { return ""; }
            }
            else if (pluralOrSingular == "plural")
            {
                if (this.dinEllerDitt == Genitive.DinDina || this.dinEllerDitt == Genitive.DittDina)
                {
                    return "dina";
                }
                else if (this.dinEllerDitt == Genitive.DinDin)
                {
                    return "din";
                }
                else if (this.dinEllerDitt == Genitive.DinDin)
                {
                    return "ditt";
                }
                else { return ""; }
            }
            else { return ""; }

        }

        public override string Singular()
        {
            return singular;
        }

        public override string Plural()
        {
            return plural;
        }

        // English Contructor - Turns string from txt to enum instantly without going through a separate method first. 
        public Nouns(string singular, string plural, string engindefinite, bool english) : base()
        {
            this.singular = singular;
            this.plural = plural;
            if (engindefinite == "a")
            {
                this.aOrAn = Indefinite.A;
            }
            else if (engindefinite == "an")
            {
                this.aOrAn = Indefinite.An;
            }
            else
            {
                this.aOrAn = Indefinite.Null;
            }
        }

        // Swedish Constructor - Turns string from txt to enum instantly without going through a separate method first. 
        public Nouns(string singular, string plural, string indefiniteAndGenitive) : base()
        {
            this.singular = singular;
            this.plural = plural;
            if (indefiniteAndGenitive == "en/dina")
            { this.enEllerEtt = Indefinite.En; this.dinEllerDitt = Genitive.DinDina; }
            else if (indefiniteAndGenitive == "ett/dina")
            { this.enEllerEtt = Indefinite.Ett; this.dinEllerDitt = Genitive.DittDina; }
            else if (indefiniteAndGenitive == "din/din")
            {
                this.enEllerEtt = Indefinite.Null; this.dinEllerDitt = Genitive.DinDin;
            }
            else if (indefiniteAndGenitive == "ditt/ditt")
            {
                this.enEllerEtt = Indefinite.Null; this.dinEllerDitt = Genitive.DittDitt;
            }
        }

        // Univeral cotructor for only sing and plu, specifically added for relations. 
        public Nouns(string singular, string plural) : base()
        {
            this.singular = singular;
            this.plural = plural;
        }

    }

    // Noun - Something
    public class Something : Nouns
    {
        public Something(string singular, string plural, string indefiniteAndGenitive) : base(singular, plural, indefiniteAndGenitive)
        {
        }

        public Something(string singular, string plural, string engIndefinite, bool english) : base(singular, plural, engIndefinite, english)
        {
        }

    }

    // Noun - Someone
    public class Someone : Nouns
    {
        public Someone(string singular, string plural, string indefiniteAndGenitive) : base(singular, plural, indefiniteAndGenitive)
        {
        }

        public Someone(string singular, string plural, string engIndefinite, bool english) : base(singular, plural, engIndefinite, english)
        {
        }

    }

    // Noun - Relatinship - Tänk om
    public class Relation : Nouns
    {
        public Relation(string singular, string plural) : base(singular, plural)
        {
        }
    }

    // Adjectives
    public class Adjectives : Words
    {
        protected string ettForm;
        protected string enForm;
        protected string plural;
        protected string descriptive;

        public override string EttForm()
        {
            return ettForm;
        }

        public override string EnForm()
        {
            return enForm;
        }

        public override string Plural()
        {
            return plural;
        }

        public override string Singular()
        {
            return enForm;
        }

        public override string Descriptive()
        {
            return descriptive;
        }

        // Compares current adjective with the right noun and returns the right adjective
        public override string Singular(List<Words> nounList, int nounNr)
        {
            if (nounList[nounNr].EnEllerEttEnum() == Indefinite.En || nounList[nounNr].DinEllerDittEnum() == Genitive.DinDin)
                return $"{this.enForm}";
            else if (nounList[nounNr].EnEllerEttEnum() == Indefinite.Ett || nounList[nounNr].DinEllerDittEnum() == Genitive.DittDitt)
            {
                return $"{this.ettForm}";
            }
            else { return ""; }
        }

        public override string Plural(List<Words> nounList, int nounNr)
        {

            if (nounList[nounNr].EnEllerEttEnum() == Indefinite.En || nounList[nounNr].EnEllerEttEnum() == Indefinite.Ett)
                return $"{this.plural}";
            else if (nounList[nounNr].DinEllerDittEnum() == Genitive.DittDitt)
            {
                return $"{this.ettForm}";
            }
            else if (nounList[nounNr].DinEllerDittEnum() == Genitive.DinDin)
            {
                return $"{this.enForm}";
            }
            else { return ""; }
        }

        // Swedish Constructor
        public Adjectives(string enForm, string plural, string ettForm) : base()
        {
            this.enForm = enForm;
            this.plural = plural;
            this.ettForm = ettForm;
        }

        //English constructor
        public Adjectives(string descriptive) : base()
        {
            this.descriptive = descriptive;
        }
    }

    // Names
    public abstract class Names : Words
    {
        protected string name;

        public override string Name()
        {
            return name;
        }

        public Names() { }

        public Names(string name) : base()
        {
            this.name = name;
        }
    }

    // Joke Names
    public class JokeNames : Names
    {
        public JokeNames() { }

        public JokeNames(string name) : base(name)
        {
        }

    }

    public class Location : Names
    {
        public override string Name()
        {
            return name;
        }

        public Location(string name) : base(name)
        {
            this.name = name;
        }
    }

    // Nobel prize
    public class NobelPrizes : Words
    {
        protected string prize;

        public override string Prize()
        {
            return prize;
        }

        public NobelPrizes()
        {

        }

        public NobelPrizes(string prize)
        {
            this.prize = prize;
        }
    }

    public enum Indefinite { En, Ett, Null, A, An }
    public enum Genitive { DinDina, DittDina, DinDin, DittDitt }
}
