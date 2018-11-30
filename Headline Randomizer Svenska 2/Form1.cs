using System;
using System.Collections.Generic;
using System.Drawing;
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
            int someoneNr = r.Next(0, list.someone.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);
            int nr2 = r.Next(1, 11);
            int nr1 = r.Next(1, (nr2 + 2));

            presentationWindow.tbxResult.Text = $"{nr1} av {nr2} tycker att {list.someone[someoneNr].Plural()} är {list.adjective[adjectiveNr].Plural()}";

            // Use method to adjust size of string. 
            FixText.AdjustSize(presentationWindow.tbxResult);

            // Remove used words
            list.adjective.RemoveAt(adjectiveNr);
            list.someone.RemoveAt(someoneNr);

            // Reload the lists that need reloading...
            list.LoadNeeded(1);
        }

        // Click animation eventhandlers
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

        private void BtnGenerate2_Click(object sender, EventArgs e)
        {
            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                presentationWindow.tbxResult.Text = "";
                int someoneNr = r.Next(0, list.someone.Count);

                char firstLetter = list.someone[someoneNr].Singular()[0];
                string firstLetterStr = Convert.ToString(firstLetter);

                presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.someone[someoneNr].Singular().Substring(1, list.someone[someoneNr].Singular().Length - 1)} ");
                list.someone.RemoveAt(someoneNr);

                int verbNr = r.Next(0, list.verb.Count);
                int somethingNr = r.Next(0, list.something.Count);
                int adjectiveNr = r.Next(0, list.adjective.Count);

                presentationWindow.tbxResult.AppendText($"{list.verb[verbNr].Presens()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.adjective[adjectiveNr].Singular(list.something, somethingNr)} {list.something[somethingNr].Singular()}");

                FixText.AdjustSize(presentationWindow.tbxResult);
                list.verb.RemoveAt(verbNr);
                list.something.RemoveAt(somethingNr);
                list.adjective.RemoveAt(adjectiveNr);

                list.LoadNeeded(1);
            }
            else if (slant == 1)
            {
                presentationWindow.tbxResult.Text = "";
                int someoneNr = r.Next(0, list.someone.Count);

                char firstLetter = list.someone[someoneNr].Singular()[0];
                string firstLetterStr = Convert.ToString(firstLetter);

                presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.someone[someoneNr].Singular().Substring(1, list.someone[someoneNr].Singular().Length - 1)} ");
                list.someone.RemoveAt(someoneNr);

                int someoneNr2 = r.Next(0, list.someone.Count);
                int verbNr = r.Next(0, list.verb.Count);
                int adjectiveNr = r.Next(0, list.adjective.Count);

                presentationWindow.tbxResult.AppendText($"{list.verb[verbNr].Presens()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.adjective[adjectiveNr].Singular(list.someone, someoneNr2)} {list.someone[someoneNr2].Singular()}");

                FixText.AdjustSize(presentationWindow.tbxResult);
                list.someone.RemoveAt(someoneNr2);
                list.verb.RemoveAt(verbNr);
                list.adjective.RemoveAt(adjectiveNr);

                list.LoadNeeded(1);
            }
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneNr = r.Next(0, list.someone.Count);

            // Get the first letter of the first livenoun
            char firstLetter = list.someone[someoneNr].Singular()[0];
            string firstLetterStr = Convert.ToString(firstLetter);

            presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.someone[someoneNr].Singular().Substring(1, list.someone[someoneNr].Singular().Length - 1)} tror att ");
            list.someone.RemoveAt(someoneNr);

            int someoneNr2 = r.Next(0, list.someone.Count);
            int somethingNr = r.Next(0, list.something.Count);
            presentationWindow.tbxResult.AppendText($"{list.someone[someoneNr2].Plural()} är {list.something[somethingNr].Plural()}");

            FixText.AdjustSize(presentationWindow.tbxResult);
            list.someone.RemoveAt(someoneNr2);
            list.something.RemoveAt(somethingNr);


            list.LoadNeeded(1);
        }

        private void btnGenerate4_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneNr = r.Next(0, list.someone.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);

            char firstLetter = list.adjective[adjectiveNr].Plural()[0];
            string firstLetterStr = Convert.ToString(firstLetter);

            presentationWindow.tbxResult.AppendText($"{firstLetterStr.ToUpper()}{list.adjective[adjectiveNr].Plural().Substring(1, list.adjective[adjectiveNr].Plural().Length - 1)} {list.someone[someoneNr].Plural()} ");
            list.someone.RemoveAt(someoneNr);
            list.adjective.RemoveAt(adjectiveNr);

            int someoneNr2 = r.Next(0, list.someone.Count);
            int adjectiveNr2 = r.Next(0, list.adjective.Count);
            int verbNr = r.Next(0, list.verb.Count);

            presentationWindow.tbxResult.AppendText($"{list.verb[verbNr].Presens()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.adjective[adjectiveNr2].Plural()} {list.someone[someoneNr2].Plural()}");

            FixText.AdjustSize(presentationWindow.tbxResult);
            list.someone.RemoveAt(someoneNr2);
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
            int somethingNr = r.Next(0, list.something.Count);

            presentationWindow.tbxResult.AppendText($"{list.jokeName[jokeNameNr].Name()} vann {list.nobelPrize[nobelNr].Prize()} för att ha {list.verb[verbNr].Perfekt()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.something[somethingNr].Plural()}");

            FixText.AdjustSize(presentationWindow.tbxResult);
            list.jokeName.RemoveAt(jokeNameNr);
            list.nobelPrize.RemoveAt(nobelNr);
            list.verb.RemoveAt(verbNr);
            list.something.RemoveAt(somethingNr);
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
            else if (cbBook.Text == "Substantiv - Något")
            {
                cbForms.Items.Add("Singular");
                cbForms.Items.Add("Plural");
            }
            else if (cbBook.Text == "Substantiv - Någon")
            {
                cbForms.Items.Add("Singular");
                cbForms.Items.Add("Plural");
            }
            else if (cbBook.Text == "Skämtnamn")
            {
                cbForms.Items.Add("Name");
            }
            else if (cbBook.Text == "Verb")
            {
                cbForms.Items.Add("Basform");
                cbForms.Items.Add("Presens");
                cbForms.Items.Add("perfekt");
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
                    Custom newcombo = new Custom(cbBook.Text, cbBook.Text, cbForms.Text);
                    list.choicesList.Add(newcombo);
            }

            tbxAdded.Text = "";
            foreach (Custom element in list.choicesList)
            {
                if (element.ToAddedTbx == "custom")
                {
                    tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.CustomString}");
                }
                else
                {
                    tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ToAddedTbx}");
                }
            }
        }

        private void btnAddNr_Click(object sender, EventArgs e)
        {
            Custom newcombo = new Custom("Nr", nupFrom.Value, nupTo.Value);
            list.choicesList.Add(newcombo);

            tbxAdded.Text = "";
            foreach (Custom element in list.choicesList)
            {
                if (element.ToAddedTbx == "custom")
                {
                    tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.CustomString}");
                }
                else
                {
                    tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ToAddedTbx}");
                }
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
                Custom newcombo = new Custom("custom", tbxCustom.Text.Trim());
                list.choicesList.Add(newcombo);
            }

            tbxAdded.Text = "";
            foreach (Custom element in list.choicesList)
            {
                if (element.ToAddedTbx == "custom")
                {
                    tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.CustomString}");
                }
                else
                {
                    tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ToAddedTbx}");
                }
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
             foreach (Custom element in list.choicesList)
             {
                if (element.WordClassChoice == "Adjektiv")
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
                else if (element.WordClassChoice == "Substantiv - Något")
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
                else if (element.WordClassChoice == "Skämtnamn" && element.FormChoice == "Name")
                {
                    int rNr = r.Next(0, list.jokeName.Count);
                    presentationWindow.tbxResult.AppendText($"{list.jokeName[rNr].Name()} ");
                    list.jokeName.RemoveAt(rNr);
                }
                else if (element.WordClassChoice == "Substantiv - Någon")
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
                else if (element.WordClassChoice == "Verb")
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
                    else if (element.FormChoice == "Perfekt")
                    {
                        presentationWindow.tbxResult.AppendText($"{list.verb[rNr].Perfekt()} ");
                        sparaPostVerb = list.verb[rNr].PostVerbs();
                    }
                    else if (element.FormChoice == "Efter verb")
                    {
                        presentationWindow.tbxResult.AppendText($"{(sparaPostVerb == "-" ? "" : $"{sparaPostVerb} ")}");
                    }
                    list.verb.RemoveAt(rNr);
                }
                else if (element.ToAddedTbx == "custom")
                {
                    presentationWindow.tbxResult.AppendText($"{element.CustomString} ");
                }
                else if (element.ToAddedTbx == "Nr")
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
            int someoneNr = r.Next(0, list.someone.Count);

            presentationWindow.tbxResult.AppendText($"Kom ihåg, {list.verb[verbNr].Request()} alltid {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.someone[someoneNr].DinEllerDitt("plural")} {list.someone[someoneNr].Plural()}");

            list.verb.RemoveAt(verbNr);
            list.someone.RemoveAt(someoneNr);
            list.LoadNeeded(1);
            FixText.AdjustSize(presentationWindow.tbxResult);
        }

        private void btnGenerate7_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int somethingNr = r.Next(0, list.something.Count);
            int adjectiveNr = r.Next(0, list.adjective.Count);

            presentationWindow.tbxResult.AppendText($"Lycka är {list.adjective[adjectiveNr].Plural(list.something, somethingNr)} {list.something[somethingNr].Plural()}");

            list.something.RemoveAt(somethingNr);
            list.adjective.RemoveAt(adjectiveNr);
            list.LoadNeeded(1);
            FixText.AdjustSize(presentationWindow.tbxResult);
        }

        private void btnGenerate8_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                int verbNr = r.Next(0, list.verb.Count);
                int someoneNr = r.Next(0, list.someone.Count);

                presentationWindow.tbxResult.AppendText($"Är du trött på att {list.verb[verbNr].BasForm()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.someone[someoneNr].Plural()}? Vi har lösningen för dig!");

                list.someone.RemoveAt(someoneNr);
                list.verb.RemoveAt(verbNr);
                list.LoadNeeded(1);
                FixText.AdjustSize(presentationWindow.tbxResult);
            }
            else if (slant == 1)
            {
                int verbNr = r.Next(0, list.verb.Count);
                int somethingNr = r.Next(0, list.something.Count);

                presentationWindow.tbxResult.AppendText($"Är du trött på att {list.verb[verbNr].BasForm()} {(list.verb[verbNr].PostVerbs() == "-" ? "" : $"{list.verb[verbNr].PostVerbs()} ")}{list.something[somethingNr].Plural()}? Vi har lösningen för dig!");

                list.something.RemoveAt(somethingNr);
                list.verb.RemoveAt(verbNr);
                list.LoadNeeded(1);
                FixText.AdjustSize(presentationWindow.tbxResult);
            }
            
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void Tabchanged(object sender, EventArgs e)
        {
            if (customTabControl1.ActiveIndex == 1)
            {
                customTabControl1.Size = new Size(614, 233);
            }
            else if (customTabControl1.ActiveIndex == 3)
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
                int someoneNr = r.Next(0, list.someone.Count);

                presentationWindow.tbxResult.AppendText($"Husmorstips, {list.someone[someoneNr].DinEllerDitt("plural")} {list.someone[someoneNr].Plural()} kan aldrig vara för {list.adjective[adjectiveNr].Plural()}");

                list.someone.RemoveAt(someoneNr);
                list.adjective.RemoveAt(adjectiveNr);
                list.LoadNeeded(1);
                FixText.AdjustSize(presentationWindow.tbxResult);
            }
            else if (slant == 1)
            {
                int adjectiveNr = r.Next(0, list.adjective.Count);
                int somethingNr = r.Next(0, list.something.Count);

                presentationWindow.tbxResult.AppendText($"Husmorstips, {list.something[somethingNr].DinEllerDitt("plural")} {list.something[somethingNr].Plural()} kan aldrig vara för {list.adjective[adjectiveNr].Plural(list.something, somethingNr)}");

                list.something.RemoveAt(somethingNr);
                list.adjective.RemoveAt(adjectiveNr);
                list.LoadNeeded(1);
                FixText.AdjustSize(presentationWindow.tbxResult);
            }
        }
    }

    class Lists
    {
        public Lists()
        {
        }

        public List<Words> verb = new List<Words>();
        public List<Words> something = new List<Words>();
        public List<Words> someone = new List<Words>();
        public List<Words> jokeName = new List<Words>();
        public List<Words> adjective = new List<Words>();
        public List<Words> nobelPrize = new List<Words>();
        public List<Custom> choicesList = new List<Custom>();

    public void LoadNeeded(int amount)
        {
            if (verb.Count <= amount)
            {
                StreamReader sr = new StreamReader(@"Text\verb basform.txt");
                StreamReader sr2 = new StreamReader(@"Text\verbs presens.txt");
                StreamReader sr3 = new StreamReader(@"Text\verbs perfekt.txt");
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
                    Something vread = new Something(fileRow, fileRow2, fileRow3);
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
                    Someone vread = new Someone(fileRow, fileRow2, fileRow3);
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

                while ((fileRow = sr.ReadLine()) != null && ((fileRow2 = sr2.ReadLine()) != null) && ((fileRow3 = sr3.ReadLine()) != null))
                {
                    Adjectives vread = new Adjectives(fileRow, fileRow2, fileRow3);
                    adjective.Add(vread);
                }
                sr.Close();
                sr2.Close();
                sr3.Close();
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

    }
}
