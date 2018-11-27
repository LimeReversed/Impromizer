using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// Svenska 
namespace Headline_Randomizer
{
    public partial class Form1 : Form
    {
        // Creating objects to be able to reach their properties
        PresentationWindow presentationWindow = new PresentationWindow();
        Lists list = new Lists();
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();

            // Loading lists from file
            list.LoadNeeded(1);

            // Show the second window at a precise location relative to the main window.
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);
            presentationWindow.Show();
        }

        private void MoveWindow1(object sender, EventArgs e)
        {
            // The Presentation window will always be under the main window.
            // Location of the main window plus it's size in the Y-axis so that it's directly below. 
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void btnGenerate1_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int liveNounNr = r.Next(0, list.someone.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);
            int nr2 = r.Next(1, 11);
            int nr1 = r.Next(1, (nr2 + 2));

            presentationWindow.tbxResult.Text = $"{nr1} av {nr2} tycker att {list.someone[liveNounNr].Plural()} är {list.adjective[adjectiveNr].Plural()}";

            // Use method to adjust size of string. 
            list.AdjustSize(presentationWindow);

            // Remove used words
            list.adjective.RemoveAt(adjectiveNr);
            list.someone.RemoveAt(liveNounNr);

            // Reload the lists that need reloading...
            list.LoadNeeded(1);

        }

        private void btnGenerate1_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate1.BackgroundImage = Properties.Resources._3outof5button_image;
        }

        private void btnGenerate1_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate1.BackgroundImage = Properties.Resources._3outof5buttonhover_image;
        }

        private void btnGenerate2_MouseDown(object sender, MouseEventArgs e)
        {
            BtnGenerate2.BackgroundImage = Properties.Resources.newsbutton_image;
        }

        private void btnGenerate2_MouseUp(object sender, MouseEventArgs e)
        {
            BtnGenerate2.BackgroundImage = Properties.Resources.newsbuttonbig_image;
        }

        private void btnGenerate3_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate3.BackgroundImage = global::Headline_Randomizer.Properties.Resources.thinksbutton_image;
        }

        private void btnGenerate3_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate3.BackgroundImage = global::Headline_Randomizer.Properties.Resources.thinksbuttonbig_image;
        }

        private void btnGenerate4_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate4.BackgroundImage = global::Headline_Randomizer.Properties.Resources.adjectivesbutton_image;
        }

        private void btnGenerate4_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate4.BackgroundImage = global::Headline_Randomizer.Properties.Resources.adjectivesbuttonbig_image;
        }

        private void btnGenerate5_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate5.BackgroundImage = global::Headline_Randomizer.Properties.Resources.Nobelbutton_image;
        }

        private void btnGenerate5_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate5.BackgroundImage = global::Headline_Randomizer.Properties.Resources.Nobelbuttonbig_image;
        }

        private void BtnGenerate2_Click(object sender, EventArgs e)
        {
            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                presentationWindow.tbxResult.Text = "";
                int liveNounNr = r.Next(0, list.someone.Count);

                char firstLetter = list.someone[liveNounNr].Singular()[0];
                string firstLetterStr = Convert.ToString(firstLetter);

                presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.someone[liveNounNr].Singular().Substring(1, list.someone[liveNounNr].Singular().Length - 1)} ");
                list.someone.RemoveAt(liveNounNr);

                int verbNr = r.Next(0, list.verb.Count);
                int deadNounNr = r.Next(0, list.something.Count);
                int adjectiveNr = r.Next(0, list.adjective.Count);

                presentationWindow.tbxResult.AppendText($"{list.verb[verbNr].Presens()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.adjective[adjectiveNr].Singular(list.something, deadNounNr)} {list.something[deadNounNr].Singular()}");

                list.AdjustSize(presentationWindow);
                list.verb.RemoveAt(verbNr);
                list.something.RemoveAt(deadNounNr);
                list.adjective.RemoveAt(adjectiveNr);

                list.LoadNeeded(1);
            }
            else if (slant == 1)
            {
                presentationWindow.tbxResult.Text = "";
                int liveNounNr = r.Next(0, list.someone.Count);

                char firstLetter = list.someone[liveNounNr].Singular()[0];
                string firstLetterStr = Convert.ToString(firstLetter);

                presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.someone[liveNounNr].Singular().Substring(1, list.someone[liveNounNr].Singular().Length - 1)} ");
                list.someone.RemoveAt(liveNounNr);

                int liveNounNr2 = r.Next(0, list.someone.Count);
                int verbNr = r.Next(0, list.verb.Count);
                int adjectiveNr = r.Next(0, list.adjective.Count);

                presentationWindow.tbxResult.AppendText($"{list.verb[verbNr].Presens()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.adjective[adjectiveNr].Singular(list.someone, liveNounNr2)} {list.someone[liveNounNr2].Singular()}");

                list.AdjustSize(presentationWindow);
                list.someone.RemoveAt(liveNounNr2);
                list.verb.RemoveAt(verbNr);
                list.adjective.RemoveAt(adjectiveNr);

                list.LoadNeeded(1);
            }
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int liveNounNr = r.Next(0, list.someone.Count);

            // Get the first letter of the first livenoun
            char firstLetter = list.someone[liveNounNr].Singular()[0];
            string firstLetterStr = Convert.ToString(firstLetter);

            presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.someone[liveNounNr].Singular().Substring(1, list.someone[liveNounNr].Singular().Length - 1)} tror att ");
            list.someone.RemoveAt(liveNounNr);

            int liveNounNr2 = r.Next(0, list.someone.Count);
            int deadNounNr = r.Next(0, list.something.Count);
            presentationWindow.tbxResult.AppendText($"{list.someone[liveNounNr2].Plural()} är {list.something[deadNounNr].Plural()}");

            list.AdjustSize(presentationWindow);
            list.someone.RemoveAt(liveNounNr2);
            list.something.RemoveAt(deadNounNr);


            list.LoadNeeded(1);
        }

        private void btnGenerate4_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int liveNounNr = r.Next(0, list.someone.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);

            char firstLetter = list.adjective[adjectiveNr].Plural()[0];
            string firstLetterStr = Convert.ToString(firstLetter);

            presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.adjective[adjectiveNr].Plural().Substring(1, list.adjective[adjectiveNr].Plural().Length - 1)} {list.someone[liveNounNr].Plural()} ");
            list.someone.RemoveAt(liveNounNr);
            list.adjective.RemoveAt(adjectiveNr);

            int liveNounNr2 = r.Next(0, list.someone.Count);
            int adjectiveNr2 = r.Next(0, list.adjective.Count);
            int verbNr = r.Next(0, list.verb.Count);

            presentationWindow.tbxResult.AppendText($"{list.verb[verbNr].Presens()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.adjective[adjectiveNr2].Plural()} {list.someone[liveNounNr2].Plural()}");

            list.AdjustSize(presentationWindow);
            list.someone.RemoveAt(liveNounNr2);
            list.adjective.RemoveAt(adjectiveNr2);
            list.verb.RemoveAt(verbNr);
            list.LoadNeeded(1);
        }

        private void btnGenerate5_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int jokeNameNr = r.Next(0, list.jokeName.Count);
            int nobelNr = r.Next(0, list.nobelPrize.Count);
            int verbNr = r.Next(0, list.verb.Count);
            int deadNounNr = r.Next(0, list.something.Count);

            presentationWindow.tbxResult.AppendText($"{list.jokeName[jokeNameNr].Name()} vann {list.nobelPrize[nobelNr].Prize()} för att ha {list.verb[verbNr].Imperfekt()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.something[deadNounNr].Plural()}");

            list.AdjustSize(presentationWindow);
            list.jokeName.RemoveAt(jokeNameNr);
            list.nobelPrize.RemoveAt(nobelNr);
            list.verb.RemoveAt(verbNr);
            list.something.RemoveAt(deadNounNr);
            list.LoadNeeded(1);
        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbForms.Items.Clear();
            if (cbBook.Text == "Adjektiv")
            {
                cbForms.Items.Add("Singular");
                cbForms.Items.Add("Plural");
            }
            else if (cbBook.Text == "Döda substantiv")
            {
                cbForms.Items.Add("Singular");
                cbForms.Items.Add("Plural");
            }
            else if (cbBook.Text == "Skämtnamn")
            {
                cbForms.Items.Add("Name");
            }
            else if (cbBook.Text == "Levande substantiv")
            {
                cbForms.Items.Add("Singular");
                cbForms.Items.Add("Plural");
            }
            else if (cbBook.Text == "Verb")
            {
                cbForms.Items.Add("Basform");
                cbForms.Items.Add("Presens");
                cbForms.Items.Add("Imperfekt");
                cbForms.Items.Add("Efter verb");
            }
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (cbBook.Text == "" || cbForms.Text == "")
            {
                MessageBox.Show("Both options need to be chosen");
            }
            else
            {
                    Lists newcombo = new Lists(cbBook.Text, cbBook.Text, cbForms.Text);
                    list.choicesList.Add(newcombo);
            }

            tbxAdded.Text = "";
            foreach (Lists element in list.choicesList)
            {

                tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ForAdded}");
            }
        }

        private void btnAddNr_Click(object sender, EventArgs e)
        {
            Lists newcombo = new Lists("#", nupFrom.Value, nupTo.Value);
            list.choicesList.Add(newcombo);

            tbxAdded.Text = "";
            foreach (Lists element in list.choicesList)
            {
                tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ForAdded}");
            }
        }

        private void btnAddCustom_Click(object sender, EventArgs e)
        {
            if (tbxCustom.Text == "")
            {
                MessageBox.Show("Write some text in the textbox first.");
            }
            else
            {
                Lists newcombo = new Lists("custom", tbxCustom.Text.Trim());
                list.choicesList.Add(newcombo);
            }

            tbxAdded.Text = "";
            foreach (Lists element in list.choicesList)
            {

                tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ForAdded}");
            }
        }

        private void nupFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nupFrom.Value > nupTo.Value - 1) nupFrom.Value = nupTo.Value - 1;
        }

        private void nupTo_ValueChanged(object sender, EventArgs e)
        {
            if (nupFrom.Value > nupTo.Value - 1) nupTo.Value = nupFrom.Value + 1;
        }

        string sparaPostVerb = "";

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
             foreach (Lists element in list.choicesList)
             {
                if (element.BookChoice == "Adjektiv")
                {
                    int rNr = r.Next(0, list.adjective.Count);
                    if (element.FormChoice == "Singular")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.adjective[rNr].Singular()} ");
                    }
                    else if (element.FormChoice == "Plural")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.adjective[rNr].Plural()} ");
                    }
                    list.adjective.RemoveAt(rNr);
                }
                else if (element.BookChoice == "Döda substantiv")
                {
                    int rNr = r.Next(0, list.something.Count);

                    if (element.FormChoice == "Singular")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.something[rNr].Singular()} ");
                    }
                    else if (element.FormChoice == "Plural")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.something[rNr].Plural()} ");
                    }
                    list.something.RemoveAt(rNr);
                }
                else if (element.BookChoice == "Skämtnamn" && element.FormChoice == "Name")
                {
                    int rNr = r.Next(0, list.jokeName.Count);
                    presentationWindow.tbxResult.AppendText($"{list.jokeName[rNr].Name()} ");
                    list.jokeName.RemoveAt(rNr);
                }
                else if (element.BookChoice == "Levande substantiv")
                {
                    int rNr = r.Next(0, list.someone.Count);

                    if (element.FormChoice == "Singular")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.someone[rNr].Singular()} ");
                    }
                    else if (element.FormChoice == "Plural")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.someone[rNr].Plural()} ");
                    }
                    list.someone.RemoveAt(rNr);
                }
                else if (element.BookChoice == "Verb")
                {
                    int rNr = r.Next(0, list.verb.Count);
                    

                    if (element.FormChoice == "Basform")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.verb[rNr].BasForm()} ");
                        sparaPostVerb = list.verb[rNr].PostVerbs();
                    }
                    else if (element.FormChoice == "Presens")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.verb[rNr].Presens()} ");
                        sparaPostVerb = list.verb[rNr].PostVerbs();
                    }
                    else if (element.FormChoice == "Imperfekt")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.verb[rNr].Imperfekt()} ");
                        sparaPostVerb = list.verb[rNr].PostVerbs();
                    }
                    else if (element.FormChoice == "Efter verb")
                    {
                        presentationWindow.tbxResult.AppendText($"{(sparaPostVerb == "-" ? "" : $"{sparaPostVerb} ")}");
                    }
                    list.verb.RemoveAt(rNr);
                }
                else if (element.ForAdded == "custom")
                {
                    presentationWindow.tbxResult.AppendText($"{element.Custom} ");
                }
                else if (element.ForAdded == "#")
                {
                    int rNr = r.Next(Convert.ToInt32(element.FromValue), Convert.ToInt32(element.ToValue));
                    presentationWindow.tbxResult.AppendText($"{Convert.ToString(rNr)} ");
                }

                char firstLetter = presentationWindow.tbxResult.Text[0];
                string firstLetterStr = Convert.ToString(firstLetter);
                string theRest = presentationWindow.tbxResult.Text.Substring(1, presentationWindow.tbxResult.Text.Length - 1);

                presentationWindow.tbxResult.Text = $"{firstLetterStr.ToUpper()}{theRest}";
                presentationWindow.tbxResult.Font = new Font("Adobe Fan Heiti Std", 24, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                presentationWindow.tbxResult.Location = new System.Drawing.Point(10, 23);
                list.LoadNeeded(5);
             }
             
        }

        private void btnCustomClear_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            tbxCustom.Text = "";
            tbxAdded.Text = "";
            list.choicesList.Clear();
        }

        private void btnGenerate6_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int verbNr = r.Next(0, list.verb.Count);
            int liveNounNr = r.Next(0, list.someone.Count);

            presentationWindow.tbxResult.AppendText($"Kom ihåg, {list.verb[verbNr].Request()} alltid {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.DinDittDina(list.someone, liveNounNr, "plural")} {list.someone[liveNounNr].Plural()}");

            list.verb.RemoveAt(verbNr);
            list.someone.RemoveAt(liveNounNr);
            list.LoadNeeded(1);
            list.AdjustSize(presentationWindow);
        }

        private void btnGenerate7_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int deadNounNr = r.Next(0, list.something.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);

            presentationWindow.tbxResult.AppendText($"Lycka är {list.adjective[adjectiveNr].Plural(list.something, deadNounNr)} {list.something[deadNounNr].Plural()}");

            list.something.RemoveAt(deadNounNr);
            list.adjective.RemoveAt(adjectiveNr);
            list.LoadNeeded(1);
            list.AdjustSize(presentationWindow);
        }

        private void btnGenerate8_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                int verbNr = r.Next(0, list.verb.Count);
                int liveNounNr = r.Next(0, list.someone.Count);

                presentationWindow.tbxResult.AppendText($"Är du trött på att {list.verb[verbNr].BasForm()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.someone[liveNounNr].Plural()}? Vi har lösningen för dig!");

                list.someone.RemoveAt(liveNounNr);
                list.verb.RemoveAt(verbNr);
                list.LoadNeeded(1);
                list.AdjustSize(presentationWindow);
            }
            else if (slant == 1)
            {
                int verbNr = r.Next(0, list.verb.Count);
                int deadNounNr = r.Next(0, list.something.Count);

                presentationWindow.tbxResult.AppendText($"Är du trött på att {list.verb[verbNr].BasForm()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.something[deadNounNr].Plural()}? Vi har lösningen för dig!");

                list.something.RemoveAt(deadNounNr);
                list.verb.RemoveAt(verbNr);
                list.LoadNeeded(1);
                list.AdjustSize(presentationWindow);
            }
            
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void Generate6_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate6.BackgroundImage = global::Headline_Randomizer.Properties.Resources.Remembersmall_image;
        }

        private void Generate6_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate6.BackgroundImage = global::Headline_Randomizer.Properties.Resources.Rememberbig_image;
        }

        private void Generate7_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate7.BackgroundImage = global::Headline_Randomizer.Properties.Resources.Happinesssmall;
        }

        private void Generate7_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate7.BackgroundImage = global::Headline_Randomizer.Properties.Resources.Happinessbig;
        }

        private void Generate8_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate8.BackgroundImage = global::Headline_Randomizer.Properties.Resources.tiredofsmall_image;
        }

        private void Generate8_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate8.BackgroundImage = global::Headline_Randomizer.Properties.Resources.tiredofbig_image;
        }

        private void Tabchanged(object sender, EventArgs e)
        {
            if (customTabControl1.ActiveIndex == 1)
            {
                customTabControl1.Size = new Size(614, 233);
            }
            else if (customTabControl1.ActiveIndex == 2)
            {
                customTabControl1.Size = new Size(614, 135);
            }
            else
            {
                customTabControl1.Size = new Size(614, 332);
            }
        }

        private void btnRensa3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void btnGenerate9_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                int adjectiveNr = r.Next(0, list.adjective.Count);
                int liveNounNr = r.Next(0, list.someone.Count);

                presentationWindow.tbxResult.AppendText($"Husmorstips, {list.DinDittDina(list.someone, liveNounNr, "plural")} {list.someone[liveNounNr].Plural()} kan aldrig vara för {list.adjective[adjectiveNr].Plural()}");

                list.someone.RemoveAt(liveNounNr);
                list.adjective.RemoveAt(adjectiveNr);
                list.LoadNeeded(1);
                list.AdjustSize(presentationWindow);
            }
            else if (slant == 1)
            {
                int adjectiveNr = r.Next(0, list.adjective.Count);
                int deadNounNr = r.Next(0, list.something.Count);

                presentationWindow.tbxResult.AppendText($"Husmorstips, {list.DinDittDina(list.something, deadNounNr, "plural")} {list.something[deadNounNr].Plural()} kan aldrig vara för {list.adjective[adjectiveNr].Plural(list.something, deadNounNr)}");

                list.something.RemoveAt(deadNounNr);
                list.adjective.RemoveAt(adjectiveNr);
                list.LoadNeeded(1);
                list.AdjustSize(presentationWindow);
            }
        }
    }

    class Lists
    {
        public string ForAdded { get; set; }
        public string BookChoice { get; set; }
        public string FormChoice { get; set; }
        public decimal FromValue { get; set; }
        public decimal ToValue { get; set; }
        public string Custom { get; set; }

        public Lists(string forAdded, string bookChoice, string formChoice)
        {
            this.ForAdded = forAdded;
            this.BookChoice = bookChoice;
            this.FormChoice = formChoice;
        }

        public Lists(string forAdded, decimal fromValue, decimal toValue)
        {
            this.ForAdded = forAdded;
            this.FromValue = fromValue;
            this.ToValue = toValue;
        }

        public Lists(string forAdded, string custom)
        {
            this.ForAdded = forAdded;
            this.Custom = custom;
        }

        public string EnOrEtt(List<Book> lista, int nr)
        {
            if (lista[nr].EnDin() == EnEttDinDitt.EnDina)
            {
                return "en";
            }
            else if (lista[nr].EnDin() == EnEttDinDitt.EttDina)
            {
                return "ett";
            }
            else { return ""; }
        }

        public string DinDittDina(List<Book> lista, int nr, string pluralOrSingular)
        {
            if (pluralOrSingular == "singular")
            {
                if (lista[nr].EnDin() == EnEttDinDitt.EnDina || lista[nr].EnDin() == EnEttDinDitt.DinDin)
                {
                    return "din";
                }
                else if (lista[nr].EnDin() == EnEttDinDitt.EttDina || lista[nr].EnDin() == EnEttDinDitt.DittDitt)
                {
                    return "ditt";
                }
                else { return ""; }
            }
            else if (pluralOrSingular == "plural")
            {
                if (lista[nr].EnDin() == EnEttDinDitt.EnDina || lista[nr].EnDin() == EnEttDinDitt.EttDina)
                {
                    return "dina";
                }
                else if (lista[nr].EnDin() == EnEttDinDitt.DinDin)
                {
                    return "din";
                }
                else if (lista[nr].EnDin() == EnEttDinDitt.DittDitt)
                {
                    return "ditt";
                }
                else { return ""; }
            }
            else { return ""; }

        }

        

        public Lists()
        {
        }

        public List<Book> verb = new List<Book>();
        public List<Book> something = new List<Book>();
        public List<Book> someone = new List<Book>();
        public List<Book> jokeName = new List<Book>();
        public List<Book> adjective = new List<Book>();
        public List<Book> nobelPrize = new List<Book>();
        public List<Lists> choicesList = new List<Lists>();

        public EnEttDinDitt ConvertToEnum(string namn)
        {
            if (namn == "en/dina")
            { return EnEttDinDitt.EnDina; }
            else if (namn == "ett/dina")
            {
                return EnEttDinDitt.EttDina;
            }
            else if (namn == "din/din")
            {
                return EnEttDinDitt.DinDin;
            }
            else if (namn == "ditt/ditt")
            {
                return EnEttDinDitt.DittDitt;
            }
            else { return 0; }
        }

    public void LoadNeeded(int amount)
        {
            if (verb.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\verb basform.txt");
                StreamReader sr2 = new StreamReader(@"Text\verbs presens.txt");
                StreamReader sr3 = new StreamReader(@"Text\verbs imperfekt.txt");
                StreamReader sr4 = new StreamReader(@"Text\post verbs.txt");
                StreamReader sr5 = new StreamReader(@"Text\verb request.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;
                string fileRow4;
                string fileRow5;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null) && ((fileRow4 = sr4.ReadLine()) != null) && ((fileRow5 = sr5.ReadLine()) != null))
                {
                    Verbs vread = new Verbs(fileRow, fileRow2, fileRow3, fileRow4, fileRow5);
                    verb.Add(vread);
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
                sr4.Close();
                sr5.Close();
            }

            if (something.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\dödasubstantivsing.txt");
                StreamReader sr2 = new StreamReader(@"Text\dödasubstantivplural.txt");
                StreamReader sr3 = new StreamReader(@"Text\DSub EnEttDinDitt.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
                {
                    Something vread = new Something(fileRow, fileRow2, ConvertToEnum(fileRow3));
                    something.Add(vread);
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
            }

            if (someone.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\levandesubstantivsing.txt");
                StreamReader sr2 = new StreamReader(@"Text\levandesubstantivplural.txt");
                StreamReader sr3 = new StreamReader(@"Text\LSub EnEttDinDitt.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
                {
                    Someone vread = new Someone(fileRow, fileRow2, ConvertToEnum(fileRow3));
                    someone.Add(vread);
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
            }

            if (adjective.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\adjektivsingular.txt");
                StreamReader sr2 = new StreamReader(@"Text\adjektivplural.txt");
                StreamReader sr3 = new StreamReader(@"Text\adjektivEttForm.txt");
                StreamReader sr4 = new StreamReader(@"Text\adjektivplural.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;
                string fileRow4;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null) && ((fileRow4 = sr4.ReadLine()) != null))
                {
                    Adjectives vread = new Adjectives(fileRow, fileRow2, fileRow3, ConvertToEnum(fileRow4));
                    adjective.Add(vread);
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
                sr4.Close();
            }

            if (jokeName.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\jokenames2.txt");

                string fileRow;

                while ((fileRow = sr.ReadLine()) != null)
                {
                    JokeNames vread = new JokeNames(fileRow);
                    jokeName.Add(vread);
                }
                sr.Close();
            }

            if (nobelPrize.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\nobelprizes2.txt");

                string fileRow;

                while ((fileRow = sr.ReadLine()) != null)
                {
                    NobelPrizes vread = new NobelPrizes(fileRow);
                    nobelPrize.Add(vread);
                }
                sr.Close();
            }
        }

        // Method for sizing text automatically
        private float GetFontSize(TextBox label, string text, int margin, float min_size, float max_size)
        {
            // Only bother if there's text.
            if (text.Length == 0) return min_size;

            // See how much room we have, allowing a bit
            // for the Label's internal margin.
            int wid = label.Width - margin;
            int hgt = label.Height - margin;

            // Make a Graphics object to measure the text.
            using (Graphics gr = label.CreateGraphics())
            {
                while (max_size - min_size > 0.1f)
                {
                    float pt = (min_size + max_size) / 2f;
                    using (Font test_font =
                        new Font(label.Font.FontFamily, pt))
                    {
                        // See if this font is too big.
                        SizeF text_size =
                            gr.MeasureString(text, test_font);
                        if ((text_size.Width > wid) ||
                            (text_size.Height > hgt))
                            max_size = pt;
                        else
                            min_size = pt;
                    }
                }
                return min_size;
            }
        }

        public void AdjustSize(PresentationWindow form2)
        {
            if (form2.tbxResult.Text.Count() > 35)
            {
                int middleChar = form2.tbxResult.Text.Count() / 2;
                while (form2.tbxResult.Text[middleChar] != 32)
                {
                    middleChar = middleChar + 1;
                }
                form2.tbxResult.Text = form2.tbxResult.Text.Insert(middleChar + 1, "\r\n");

                form2.tbxResult.Location = new System.Drawing.Point(10, 8);
                form2.tbxResult.Font = new System.Drawing.Font("Adobe Fan Heiti Std", GetFontSize(form2.tbxResult, form2.tbxResult.Text, 3, 1f, 100f), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                form2.tbxResult.Font = new System.Drawing.Font("Adobe Fan Heiti Std", GetFontSize(form2.tbxResult, form2.tbxResult.Text, 3, 1f, 100f), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                form2.tbxResult.Location = new System.Drawing.Point(10, 25);
            }
        }

    }

    abstract class Book
    {
        // Virtual variables here to be able to reach them through List<Book>
        public virtual string BasForm()
        {
            return "";
        }

        public virtual string Presens()
        {
            return "";
        }

        public virtual string Imperfekt()
        {
            return "";
        }

        public virtual string Singular()
        {
            return "";
        }

        public virtual string Singular(List<Book> nounList, int nounNr)
        {
            return "";
        }

        public virtual string Plural(List<Book> nounList, int nounNr)
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

        public virtual EnEttDinDitt EnDin()
        {
            return 0;
        }

        public virtual string EttForm()
        {
            return "";
        }

        public virtual string EnForm()
        {
            return "";
        }
    }

    // Words
    class Verbs : Book
    {
        protected string basForm;
        protected string presens;
        protected string imperfekt;
        protected string postVerbs;
        protected string request;

        // Override variables for the verb specific virtual variables here to catch them.
        public override string BasForm()
        {
            return basForm;
        }

        public override string Presens()
        {
            return presens;
        }

        public override string Imperfekt()
        {
            return imperfekt;
        }

        public override string Request()
        {
            return request;
        }

        public override string PostVerbs()
        {
            return postVerbs;
        }

        // One empty and one filled konstructor. One to create a Verbs object without having
        // to enter meaningless data and one for when I want to create an object and add to list.  
        public Verbs() { }

        public Verbs(string basForm, string presens, string imperfekt, string postVerbs, string request) : base()
        {
            this.basForm = basForm;
            this.presens = presens;
            this.imperfekt = imperfekt;
            this.postVerbs = postVerbs;
            this.request = request;
        }

    }

    abstract class Nouns : Book
    {
        protected string singular;
        protected string plural;
        protected EnEttDinDitt enDin;

        public override EnEttDinDitt EnDin()
        {
                return enDin;
        }

        public override string Singular()
        {
            return singular;
        }

        public override string Plural()
        {
            return plural;
        }

        public Nouns() { }

        public Nouns(string singular, string plural, EnEttDinDitt enDin) : base()
        {
            this.singular = singular;
            this.plural = plural;
            this.enDin = enDin;
        }

        
    }

    class Something : Nouns
    {
        public Something() { }

        public Something(string singular, string plural, EnEttDinDitt enDin) : base(singular, plural, enDin)
        {
        }

    }

    class Someone : Nouns
    {
        public Someone() { }

        public Someone(string singular, string plural, EnEttDinDitt enDin) : base(singular, plural, enDin)
        {
        }

    }

    class Adjectives : Book
    {
        protected string ettForm;
        protected string enForm;
        protected string plural;
        protected EnEttDinDitt enDin;

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

        public override string Singular(List<Book> nounList, int nounNr) // Behöver ett andra nummer hör för att komma åt stället i adjektivlistan
        {
            if (nounList[nounNr].EnDin() == EnEttDinDitt.EnDina || nounList[nounNr].EnDin() == EnEttDinDitt.DinDin)
                return $"{this.enForm}";
            else if (nounList[nounNr].EnDin() == EnEttDinDitt.EttDina || nounList[nounNr].EnDin() == EnEttDinDitt.DittDitt)
            {
                return $"{this.ettForm}";
            }
            else { return ""; }
        }

        public override string Plural(List<Book> nounList, int nounNr)
        {

              if (nounList[nounNr].EnDin() == EnEttDinDitt.EnDina || nounList[nounNr].EnDin() == EnEttDinDitt.EttDina)
                    return $"{this.plural}";
              else if (nounList[nounNr].EnDin() == EnEttDinDitt.DittDitt)
                {
                    return $"{this.ettForm}";
                }
              else if (nounList[nounNr].EnDin() == EnEttDinDitt.DinDin)
                {
                    return $"{this.plural}";
                }
              else { return ""; }
        }

        public Adjectives() { }

        public Adjectives(string enForm, string plural, string ettForm, EnEttDinDitt enDin) : base()
        {
            this.enForm = enForm;
            this.plural = plural;
            this.enDin = enDin;
            this.ettForm = ettForm;
        }
    }

    // Names
    abstract class Names : Book
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

    class JokeNames : Names
    {
        public JokeNames() { }

        public JokeNames(string name) : base (name)
        {
        }

    }

    // Nobel prize
    class NobelPrizes : Book
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
    public enum Indefinite { EnOrAn, EttOrA, Tomt }
    public enum Genitive { DinDina, DittDina, DinDin, DittDitt }
}
