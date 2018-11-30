using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headline_Randomizer
{
    public class Custom
    {
        public string ToAddedTbx { get; set; }
        public string WordClassChoice { get; set; }
        public string FormChoice { get; set; }
        public decimal FromValue { get; set; }
        public decimal ToValue { get; set; }
        public string CustomString { get; set; }

        // For adding custom words
        public Custom(string toAddedTbx, string wordClassChoice, string formChoice)
        {
            this.ToAddedTbx = toAddedTbx;
            this.WordClassChoice = wordClassChoice;
            this.FormChoice = formChoice;
        }

        // For adding custom number
        public Custom(string toAddedTbx, decimal fromValue, decimal toValue)
        {
            this.ToAddedTbx = toAddedTbx;
            this.FromValue = fromValue;
            this.ToValue = toValue;
        }

        // For add custom string
        public Custom(string toAddedTbx, string customString)
        {
            this.ToAddedTbx = toAddedTbx;
            this.CustomString = customString;
        }

        public Custom()
        {
        }
    }
}
