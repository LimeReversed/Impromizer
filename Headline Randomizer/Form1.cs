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
            int liveNounNr = r.Next(0, list.liveNoun.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);
            int nr2 = r.Next(1, 11);
            int nr1 = r.Next(1, (nr2 + 2));

            presentationWindow.tbxResult.Text = $"{nr1} out of {nr2} agree {list.liveNoun[liveNounNr].Plural} are {list.adjective[adjectiveNr].Descriptive}";

            // Use method to adjust size of string. 
            list.AdjustSize(presentationWindow);

            // Remove used words
            list.adjective.RemoveAt(adjectiveNr);
            list.liveNoun.RemoveAt(liveNounNr);

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
            presentationWindow.tbxResult.Text = "";
            int liveNounNr = r.Next(0, list.liveNoun.Count);
            presentationWindow.tbxResult.AppendText($"According to {list.liveNoun[liveNounNr].Plural}, ");
            list.liveNoun.RemoveAt(liveNounNr);

            int liveNounNr2 = r.Next(0, list.liveNoun.Count);
            int verbNr = r.Next(0, list.verb.Count);
            int deadNounNr = r.Next(0, list.deadNoun.Count);
            presentationWindow.tbxResult.AppendText($"{list.liveNoun[liveNounNr2].Plural} {list.verb[verbNr].BaseForm} {list.deadNoun[deadNounNr].Plural}");

            list.AdjustSize(presentationWindow);
            list.liveNoun.RemoveAt(liveNounNr2);
            list.verb.RemoveAt(verbNr);
            list.deadNoun.RemoveAt(deadNounNr);

            list.LoadNeeded(1);
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int liveNounNr = r.Next(0, list.liveNoun.Count);

            // Get the first letter of the first livenoun
            char firstLetter = list.liveNoun[liveNounNr].Singular[0];
            string firstLetterStr = Convert.ToString(firstLetter);

            presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.liveNoun[liveNounNr].Singular.Substring(1, list.liveNoun[liveNounNr].Singular.Length - 1)} thinks ");
            list.liveNoun.RemoveAt(liveNounNr);

            int liveNounNr2 = r.Next(0, list.liveNoun.Count);
            int deadNounNr = r.Next(0, list.deadNoun.Count);
            presentationWindow.tbxResult.AppendText($"{list.liveNoun[liveNounNr2].Plural} are {list.deadNoun[deadNounNr].Plural}");

            list.AdjustSize(presentationWindow);
            list.liveNoun.RemoveAt(liveNounNr2);
            list.deadNoun.RemoveAt(deadNounNr);


            list.LoadNeeded(1);
        }

        private void btnGenerate4_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int liveNounNr = r.Next(0, list.liveNoun.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);

            char firstLetter = list.adjective[adjectiveNr].Descriptive[0];
            string firstLetterStr = Convert.ToString(firstLetter);

            presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.adjective[adjectiveNr].Descriptive.Substring(1, list.adjective[adjectiveNr].Descriptive.Length - 1)} {list.liveNoun[liveNounNr].Plural} ");
            list.liveNoun.RemoveAt(liveNounNr);
            list.adjective.RemoveAt(adjectiveNr);

            int liveNounNr2 = r.Next(0, list.liveNoun.Count);
            int adjectiveNr2 = r.Next(0, list.adjective.Count);
            int verbNr = r.Next(0, list.verb.Count);

            presentationWindow.tbxResult.AppendText($"{list.verb[verbNr].BaseForm} {list.adjective[adjectiveNr2].Descriptive} {list.liveNoun[liveNounNr2].Plural}");

            list.AdjustSize(presentationWindow);
            list.liveNoun.RemoveAt(liveNounNr2);
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
            int deadNounNr = r.Next(0, list.deadNoun.Count);

            presentationWindow.tbxResult.AppendText($"{list.jokeName[jokeNameNr].Name} wins the Nobel {list.nobelPrize[nobelNr].Prize} for {list.verb[verbNr].IngForm} {list.deadNoun[deadNounNr].Plural}");

            list.AdjustSize(presentationWindow);
            list.jokeName.RemoveAt(jokeNameNr);
            list.nobelPrize.RemoveAt(nobelNr);
            list.verb.RemoveAt(verbNr);
            list.deadNoun.RemoveAt(deadNounNr);
            list.LoadNeeded(1);
        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbForms.Items.Clear();
            if (cbBook.Text == "Adjective")
            {
                cbForms.Items.Add("Descriptive");
            }
            else if (cbBook.Text == "Dead noun")
            {
                cbForms.Items.Add("Singular");
                cbForms.Items.Add("Plural");
            }
            else if (cbBook.Text == "Joke name")
            {
                cbForms.Items.Add("Name");
            }
            else if (cbBook.Text == "Live noun")
            {
                cbForms.Items.Add("Singular");
                cbForms.Items.Add("Plural");
            }
            else if (cbBook.Text == "Verb")
            {
                cbForms.Items.Add("Base form");
                cbForms.Items.Add("-s form");
                cbForms.Items.Add("-ing form");
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
             foreach (Lists element in list.choicesList)
             {
                if (element.BookChoice == "Adjective" && element.FormChoice == "Descriptive")
                {
                    int rNr = r.Next(0, list.adjective.Count);
                    presentationWindow.tbxResult.AppendText($"{list.adjective[rNr].Descriptive} ");
                    list.adjective.RemoveAt(rNr);
                }
                else if (element.BookChoice == "Dead noun")
                {
                    int rNr = r.Next(0, list.deadNoun.Count);

                    if (element.FormChoice == "Singular")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.deadNoun[rNr].Singular} ");
                    }
                    else if (element.FormChoice == "Plural")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.deadNoun[rNr].Plural} ");
                    }
                    list.deadNoun.RemoveAt(rNr);
                }
                else if (element.BookChoice == "Joke name" && element.FormChoice == "Name")
                {
                    int rNr = r.Next(0, list.jokeName.Count);
                    presentationWindow.tbxResult.AppendText($"{list.jokeName[rNr].Name} ");
                    list.jokeName.RemoveAt(rNr);
                }
                else if (element.BookChoice == "Live noun")
                {
                    int rNr = r.Next(0, list.liveNoun.Count);

                    if (element.FormChoice == "Singular")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.liveNoun[rNr].Singular} ");
                    }
                    else if (element.FormChoice == "Plural")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.liveNoun[rNr].Plural} ");
                    }
                    list.liveNoun.RemoveAt(rNr);
                }
                else if (element.BookChoice == "Verb")
                {
                    int rNr = r.Next(0, list.verb.Count);
                    if (element.FormChoice == "Base form")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.verb[rNr].BaseForm} ");
                    }
                    else if (element.FormChoice == "-s form")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.verb[rNr].SForm} ");
                    }
                    else if (element.FormChoice == "-ing form")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.verb[rNr].IngForm} ");
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
            int liveNounNr = r.Next(0, list.liveNoun.Count);

            presentationWindow.tbxResult.AppendText($"Remember, always {list.verb[verbNr].BaseForm} your {list.liveNoun[liveNounNr].Plural}");

            list.verb.RemoveAt(verbNr);
            list.liveNoun.RemoveAt(liveNounNr);
            list.LoadNeeded(1);
            list.AdjustSize(presentationWindow);
        }

        private void btnGenerate7_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int deadNounNr = r.Next(0, list.deadNoun.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);

            presentationWindow.tbxResult.AppendText($"Happiness is {list.adjective[adjectiveNr].Descriptive} {list.deadNoun[deadNounNr].Plural}");

            list.deadNoun.RemoveAt(deadNounNr);
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
                int adjectiveNr = r.Next(0, list.adjective.Count);
                int liveNounNr = r.Next(0, list.liveNoun.Count);

                presentationWindow.tbxResult.AppendText($"Protip, your {list.liveNoun[liveNounNr].Plural} can never be too {list.adjective[adjectiveNr].Descriptive}");

                list.liveNoun.RemoveAt(liveNounNr);
                list.adjective.RemoveAt(adjectiveNr);
                list.LoadNeeded(1);
                list.AdjustSize(presentationWindow);
            }
            else if (slant == 1)
            {
                int adjectiveNr = r.Next(0, list.adjective.Count);
                int deadNounNr = r.Next(0, list.deadNoun.Count);

                presentationWindow.tbxResult.AppendText($"Protip, your {list.deadNoun[deadNounNr].Plural} can never be too {list.adjective[adjectiveNr].Descriptive}");

                list.deadNoun.RemoveAt(deadNounNr);
                list.adjective.RemoveAt(adjectiveNr);
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
            btnGenerate8.BackgroundImage = global::Headline_Randomizer.Properties.Resources.protipsmall;
        }

        private void Generate8_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate8.BackgroundImage = global::Headline_Randomizer.Properties.Resources.protipbig;
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

        private void btnGenerate9_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int liveNounNr = r.Next(0, list.liveNoun.Count);
            int verbNr = r.Next(0, list.verb.Count);

            presentationWindow.tbxResult.AppendText($"Are you tired of {list.verb[verbNr].IngForm} your {list.liveNoun[liveNounNr].Plural}? Well we have the solution for you!");

            list.liveNoun.RemoveAt(liveNounNr);
            list.verb.RemoveAt(verbNr);
            list.LoadNeeded(1);
            list.AdjustSize(presentationWindow);
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void btnGenerate9_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate9.BackgroundImage = global::Headline_Randomizer.Properties.Resources.tiredofsmall_image;
        }

        private void btnGenerate9_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate9.BackgroundImage = global::Headline_Randomizer.Properties.Resources.tiredofbig_image;
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

        public Lists()
        {
        }

        public List<Book> verb = new List<Book>();
        public List<Book> deadNoun = new List<Book>();
        public List<Book> liveNoun = new List<Book>();
        public List<Book> jokeName = new List<Book>();
        public List<Book> adjective = new List<Book>();
        public List<Book> nobelPrize = new List<Book>();
        public List<Lists> choicesList = new List<Lists>();

        public void LoadNeeded(int amount)
        {
            if (verb.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\verbs.txt");
                StreamReader sr2 = new StreamReader(@"Text\verbs2.txt");
                StreamReader sr3 = new StreamReader(@"Text\verbs3.txt");

                string fileRow;
                string fileRow2;
                string fileRow3;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
                {
                    Verbs vread = new Verbs(fileRow, fileRow2, fileRow3);
                    verb.Add(vread);
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
            }

            if (deadNoun.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\non-animatednouns.txt");
                StreamReader sr2 = new StreamReader(@"Text\non-animatednouns2.txt");

                string fileRow;
                string fileRow2;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null))
                {
                    DeadNouns vread = new DeadNouns(fileRow, fileRow2);
                    deadNoun.Add(vread);
                }
                sr.Close();
                sr2.Close();
            }

            if (liveNoun.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\animatednouns.txt");
                StreamReader sr2 = new StreamReader(@"Text\animatednouns2.txt");

                string fileRow;
                string fileRow2;

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null))
                {
                    LiveNouns vread = new LiveNouns(fileRow, fileRow2);
                    liveNoun.Add(vread);
                }
                sr.Close();
                sr2.Close();
            }

            if (adjective.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\adjectives.txt");

                string fileRow;

                while ((fileRow = sr.ReadLine()) != null)
                {
                    Adjectives vread = new Adjectives(fileRow);
                    adjective.Add(vread);
                }
                sr.Close();
            }

            if (jokeName.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\jokenames.txt");

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
                StreamReader sr = new StreamReader(@"Text\nobelprizes.txt");

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
        public virtual string Descriptive
        {
            get { return ""; }
            set { Descriptive = value; }
        }

        public virtual string BaseForm
        {
            get { return ""; }
            set { BaseForm = value; }
        }

        public virtual string SForm
        {
            get { return ""; }
            set { SForm = value; }
        }

        public virtual string IngForm
        {
            get { return ""; }
            set { IngForm = value; }
        }

        public virtual string Singular
        {
            get { return ""; }
            set { Singular = value; }
        }

        public virtual string Plural
        {
            get { return ""; }
            set { Plural = value; }
        }

        public virtual string Name
        {
            get { return ""; }
            set { Name = value; }
        }

        public virtual string Prize
        {
            get { return ""; }
            set { Name = value; }
        }
    }

    // Words
    class Verbs : Book
    {
        protected string baseForm;
        protected string sForm;
        protected string ingForm;

        // Override variables for the verb specific virtual variables here to catch them.
        public override string BaseForm
        {
            get { return this.baseForm; }
            set { this.baseForm = value; }
        }

        public override string SForm
        {
            get { return sForm; }
            set { sForm = value; }
        }

        public override string IngForm
        {
            get { return ingForm; }
            set { ingForm = value; }
        }

        // One empty and one filled konstructor. One to create a Verbs object without having
        // to enter meaningless data and one for when I want to create an object and add to list.  
        public Verbs() { }

        public Verbs(string baseForm, string sForm, string ingForm) : base()
        {
            this.baseForm = baseForm;
            this.sForm = sForm;
            this.ingForm = ingForm;
        }

    }

    abstract class Nouns : Book
    {
        protected string singular;
        protected string plural;

        public override string Singular
        {
            get
            {
                return this.singular;
            }
            set
            {
                this.singular = value;
            }
        }

        public override string Plural
        {
            get
            {
                return this.plural;
            }
            set
            {
                this.plural = value;
            }
        }

        public Nouns() { }

        public Nouns(string singular, string plural) : base()
        {
            this.Singular = singular;
            this.Plural = plural;
        }
    }

    class DeadNouns : Nouns
    {
        public DeadNouns() { }

        public DeadNouns(string singular, string plural) : base(singular, plural)
        {
        }

    }

    class LiveNouns : Nouns
    {
        public LiveNouns() { }

        public LiveNouns(string singular, string plural) : base(singular, plural)
        {
        }

    }

    class Adjectives : Book
    {
        public string descriptive;

        public Adjectives() { }

        public Adjectives(string descriptive) : base()
        {
            this.descriptive = descriptive;
        }

        public override string Descriptive
        {
            get
            {
                return this.descriptive;
            }
            set
            {
                this.descriptive = value;
            }

        }

    }

    // Names
    abstract class Names : Book
    {
        protected string name;

        public override string Name
        {
            get
            {
                return this.name;
            }
        
            set
            {
                this.name = value;
            }
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

        public override string Prize
        {
            get
            {
                return this.prize;
            }

            set
            {
                this.prize = value;
            }
        }

        public NobelPrizes()
        {
            
        }

        public NobelPrizes(string prize)
        {
            this.prize = prize;
        }
    }

}
