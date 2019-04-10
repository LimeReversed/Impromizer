using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headline_Randomizer
{
    public class Custom
    {
        public string WordChoice { get; set; }
        public string FormChoice { get; set; }
        public string ConnectionChoice { get; set; }
        public decimal FromValue { get; set; }
        public decimal ToValue { get; set; }
        public bool CustomString { get; set; }
        public int PositionNr { get; set; }
        public int Id { get; set; }
        public int ConnectionPosition { get; set; }

        // For adding custom words
        public Custom(string wordChoice, string formChoice, string connectionChoice, int id, int connectionPosition, int positionNr)
        {
            this.WordChoice = wordChoice;
            this.FormChoice = formChoice;
            this.ConnectionChoice = connectionChoice;
            this.Id = id;
            this.PositionNr = positionNr;
            this.ConnectionPosition = connectionPosition;
        }

        // For adding custom number
        public Custom(string wordChoice, decimal fromValue, decimal toValue)
        {
            this.WordChoice = wordChoice;
            this.FromValue = fromValue;
            this.ToValue = toValue;
        }

        // For add custom string
        public Custom(string wordChoice, bool customString)
        {
            this.WordChoice = wordChoice;
            this.CustomString = true;
        }

        public Custom()
        {
        }
    }
}
