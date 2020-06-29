using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using English;

namespace Headline_Randomizer
{
    class SentenceBuilder
    {
        public static Random r = new Random();

        public static string BuildJudgement(string target, bool targetRequiresAre, bool positive)
        {
            string primaryWhereStatement = positive ? "AND Positive = 1" : "AND Negative = 1";
            string secondaryWhereStatement = "AND Positive = 1";
            string isOrAre = targetRequiresAre ? "are" : "is";
            int coinToss = r.Next(0, 5);

            if (coinToss == 0)
            {
                int nounNr = Words.noun.RandomizeId("TblNouns INNER JOIN TblPolarityOfNouns ON TblNouns.Id = TblPolarityOfNouns.Id", primaryWhereStatement);
                int adjectiveNr = Words.adjective.RandomizeId(nounNr, "TblAdjectives INNER JOIN TblPolarityOfAdjectives ON TblAdjectives.Id = TblPolarityOfAdjectives.Id", primaryWhereStatement);
                string thatOrWho = Words.noun.IsPerson(nounNr) ? "who" : "that";

                return $"{target} {isOrAre}{Words.noun.AOrAn(nounNr)}{Words.noun.Singular(nounNr)} {thatOrWho} is {Words.adjective.Descriptive(adjectiveNr)}";
            }
            else if (coinToss == 1)
            {
                int adjectiveNr = Words.adjective.RandomizeId(0, "TblAdjectives INNER JOIN TblPolarityOfAdjectives ON TblAdjectives.Id = TblPolarityOfAdjectives.Id", primaryWhereStatement);
                return $"{target} {isOrAre} {Words.adjective.Descriptive(adjectiveNr)}";
            }
            else if (coinToss == 2)
            {
                int nounNr = Words.noun.RandomizeId("TblNouns INNER JOIN TblPolarityOfNouns ON TblNouns.Id = TblPolarityOfNouns.Id", primaryWhereStatement);
                return $"{target} {isOrAre}{Words.noun.AOrAn(nounNr)}{Words.noun.Singular(nounNr)}";
            }
            else if (coinToss == 3)
            {
                int nounNr = Words.noun.RandomizeId("TblNouns INNER JOIN TblPolarityOfNouns ON TblNouns.Id = TblPolarityOfNouns.Id", primaryWhereStatement);
                int verbNr = Words.verb.RandomizeId(nounNr, "TblVerbs INNER JOIN TblPolarityOfVerbs ON TblVerbs.Id = TblPolarityOfVerbs.Id", secondaryWhereStatement);
                return $"{target} {(targetRequiresAre ? Words.verb.BaseForm(verbNr) : Words.verb.SForm(verbNr))}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(nounNr)}";
            }
            else
            {
                return SentenceBuilder.BuildRelation("I", false, Common.FirstLetterLower(target), targetRequiresAre, positiveStatement: primaryWhereStatement);
            }

        }

         public static string BuildRelation(string subject, bool subjectRequiresSForm, string target, bool targetRequiresAre, string preVerb = "think", string positiveStatement = null)
        {
            string result = "";
            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                string fromStatement = "TblVerbs INNER JOIN TblRelationVerbs ON TblVerbs.Id = TblRelationVerbs.Id INNER JOIN TblPolarityOfVerbs " +
                    "ON TblRelationVerbs.Id = TblPolarityOfVerbs.id";
                int verbNr = Words.verb.RandomizeId(0, fromStatement, positiveStatement);
                string verb = subjectRequiresSForm ? Words.verb.SForm(verbNr) : Words.verb.BaseForm(verbNr);
                string preposition = Words.verb.Preposition(verbNr);

                result = $"{subject} {verb}{preposition}{target}";
            }
            else
            {
                string fromStatement = "TblAdjectives INNER JOIN TblRelationAdjectives ON TblAdjectives.Id = TblRelationAdjectives.Id INNER JOIN TblPolarityOfAdjectives " +
                    "ON TblRelationAdjectives.Id = TblPolarityOfAdjectives.id";
                int aNr = Words.adjective.RandomizeId(0, fromStatement, positiveStatement);
                string adjective = Words.adjective.Descriptive(aNr);
                string preposition = Words.adjective.Preposition(aNr);

                switch (preposition)
                {
                    case " ":
                        result = $"{subject} {preVerb} that {target} {(targetRequiresAre ? "are" : "is")} {adjective}";
                        break;

                    default:
                        result = $"{subject} {(subjectRequiresSForm ? "is" : "am")} {adjective}{preposition}{target}";
                        break;
                }
            }

            return result;
        }
    }
}
