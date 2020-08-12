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
using English;
using System.Diagnostics;
using System.Speech.Synthesis;
using FMUtils.KeyboardHook;
using System.Data.Entity.Core.Metadata.Edm;

namespace Headline_Randomizer
{
    public partial class English : Form
    {
        // Creating objects to be able to reach their properties
        PresentationWindow presentationWindow = new PresentationWindow();
        Random r = new Random();
        int position;

        Dictionary<string, string> regulars = new Dictionary<string, string>();
        Hook keyboardHook = new Hook("Button Triggers");
        

        public English()
        {
            InitializeComponent();

            keyboardHook.KeyDownEvent += KeyDown;

            regulars.Add("Lime", "Lime");
            regulars.Add("Ducktanian", "Duck tan-eean");
            regulars.Add("AceCroft", "Ace Croft");
            //regulars.Add("basscallum", "Bass Callum");
            regulars.Add("TReKiE", "Trekkie");
            regulars.Add("KitsuWhooa", "Kittsu Whoa");
            regulars.Add("TheGreenViper8", "The Green Viper");
            regulars.Add("Jord", "Jord");
            regulars.Add("cajsanbajsan", "kaisan baisahn");

            cbPeople.Items.Clear();

            // Connect combobox with the Dictionary "items" and decide whether the display member
            // or the value member is value or key. 
            cbPeople.DataSource = new BindingSource(regulars, null);
            cbPeople.DisplayMember = "Key";
            cbPeople.ValueMember = "Value";
            cbPeople.SelectionStart = 0;

            // Show the second window at a precise location relative to the main window.
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);
            presentationWindow.Show();

            // Set Db variables
            Db.connectionString = $"Data Source = {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer\\WordsDatabaseEnglish.db3;";
            Db.factoryResetString = $"Data Source = {AppDomain.CurrentDomain.BaseDirectory}Databases\\WordsDatabaseEnglish.db3";

            // Copy database
            if (!Directory.Exists($"{Common.myDocumentsPath}"))
            {
                Directory.CreateDirectory($"{Common.myDocumentsPath}");

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\WordsDatabaseEnglish.db3",
                                        $"{Common.myDocumentsPath}WordsDatabaseEnglish.db3", true);

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\BackupEnglish.db3",
                                            $"{Common.myDocumentsPath}BackupEnglish.db3", true);

            }

            else if (!File.Exists($"{Common.myDocumentsPath}BackupEnglish.db3") || !File.Exists($"{Common.myDocumentsPath}WordsDatabaseEnglish.db3"))
            {
                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\WordsDatabaseEnglish.db3",
                                        $"{Common.myDocumentsPath}WordsDatabaseEnglish.db3", true);

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\BackupEnglish.db3",
                                            $"{Common.myDocumentsPath}BackupEnglish.db3", true);
            }

            //Db.SetPassword(Common.password, $"Data Source = {Common.myDocumentsPath}WordsDatabaseEnglish.db3");
            //Db.SetPassword(Common.password, $"Data Source = {Common.myDocumentsPath}BackupEnglish.db3");

            if (Db.GetValue("SELECT name FROM sqlite_master WHERE type='table' AND name='TblVersion'", Db.connectionString) == "TblVersion"
                    && Convert.ToInt32(Db.GetValue("Select Version FROM TblVersion", Db.connectionString)) >= Convert.ToInt32(Db.GetValue("Select Version FROM TblVersion", Db.factoryResetString)))
            {

            }

            else
            {
                File.Delete($"{Common.myDocumentsPath}WordsDatabaseEnglish.db3");
                File.Delete($"{Common.myDocumentsPath}BackupEnglish.db3");

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\WordsDatabaseEnglish.db3",
                                        $"{Common.myDocumentsPath}WordsDatabaseEnglish.db3", true);

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\BackupEnglish.db3",
                                            $"{Common.myDocumentsPath}BackupEnglish.db3", true);

                Db.SetPassword(Common.password, $"Data Source = {Common.myDocumentsPath}WordsDatabaseEnglish.db3");
                Db.SetPassword(Common.password, $"Data Source = {Common.myDocumentsPath}BackupEnglish.db3");
            }

        }

        

            #region
            private void btnGenerate1_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate1.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate1_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate1.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate2_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate2.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate2_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate2.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate3_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate3.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate3_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate3.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate4_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate4.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate4_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate4.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate5_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate5.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate5_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate5.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnClear_MouseDown(object sender, MouseEventArgs e)
        {
            btnClear.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnClear_MouseUp(object sender, MouseEventArgs e)
        {
            btnClear.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnClear3_MouseDown(object sender, MouseEventArgs e)
        {
            btnClear3.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnClear3_MouseUp(object sender, MouseEventArgs e)
        {
            btnClear3.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate9_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate9.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate9_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate9.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate11_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate11.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate11_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate11.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate10_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate10.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate10_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate10.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate8_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate8.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate8_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate8.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate7_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate7.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate7_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate7.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnClear2_MouseDown(object sender, MouseEventArgs e)
        {
            btnClear2.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnClear2_MouseUp(object sender, MouseEventArgs e)
        {
            btnClear2.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        #endregion

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
            int someoneId = Words.someone.RandomizeId();
            int adjectiveId = Words.adjective.RandomizeId(someoneId);
            int nr2 = r.Next(1, 11);
            int nr1 = r.Next(1, (nr2 + 1));

            presentationWindow.tbxResult.Text = $"{nr1} out of {nr2} think that {Words.noun.Plural(someoneId)} are {Words.adjective.Descriptive(adjectiveId)}";

            // Remove used words
            Words.noun.Used(someoneId);
            Words.adjective.Used(adjectiveId);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void BtnGenerate2_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int someoneNr = Words.someone.RandomizeId();
            int nounNr = Words.noun.RandomizeId();
            int verbNr = Words.verb.RandomizeId(nounNr);
            int adjectiveNr = Words.adjective.RandomizeId(nounNr);

            presentationWindow.tbxResult.AppendText($"{Common.FirstLetterUpper(Words.noun.Singular(someoneNr))} {Words.verb.SForm(verbNr)}{Words.verb.Preposition(verbNr)}{Words.adjective.Descriptive(adjectiveNr)} {Words.noun.Singular(nounNr)}");

            Words.verb.Used(verbNr);
            Words.noun.Used(nounNr);
            Words.adjective.Used(adjectiveNr);
            Words.noun.Used(someoneNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int someoneNr2 = Words.someone.RandomizeId();
            int somethingNr = Words.something.RandomizeId();
            presentationWindow.tbxResult.AppendText($"Scientists agree that {Words.noun.Plural(someoneNr2)} are {Words.noun.Plural(somethingNr)}");

            Words.noun.Used(someoneNr2);
            Words.noun.Used(somethingNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate4_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneNr = Words.someone.RandomizeId();
            int verbNr = Words.verb.RandomizeId(someoneNr);
            List<string> politiker = new List<string>
            {
                "Democrat", "The liberal party", "The conservative party", "Republican", "New party", "The labour Party", "The green party"
            };
            Random r = new Random();
            int politikerNr = r.Next(0, politiker.Count);

            presentationWindow.tbxResult.AppendText($"{politiker[politikerNr]} demands that we {Words.verb.BaseForm(verbNr)}{Words.verb.Preposition(verbNr)}more {Words.noun.Plural(someoneNr)}");
            Words.verb.Used(verbNr);
            Words.noun.Used(someoneNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate5_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int jokeNameNr = Words.jokeName.RandomizeId();
            int nobelNr = Words.nobelPrize.RandomizeId();
            int somethingNr = Words.something.RandomizeId();
            int verbNr = Words.verb.RandomizeId(somethingNr);

            presentationWindow.tbxResult.AppendText($"{Words.jokeName.Name(jokeNameNr)} won the {Words.nobelPrize.Prize(nobelNr)} for {Words.verb.IngForm(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(somethingNr)}");

            Words.jokeName.Used(jokeNameNr);
            Words.nobelPrize.Used(nobelNr);
            Words.verb.Used(verbNr);
            Words.noun.Used(somethingNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate6_Click(object sender, EventArgs e)
        {
            string[] yesAnswers = { "Yes", "Sure, why not", "Totally", "Obviously", "I guess" };
            string[] noAnswers = { "No", "Nope", "Hell no", "Not quite", "Not really", "N to the O" };
            // Ask again later, I don't care, 

            int randomNumber = r.Next(0, 2);
            string answer = randomNumber == 1 ?
                yesAnswers[r.Next(0, yesAnswers.Length)] : noAnswers[r.Next(0, noAnswers.Length)];
            //presentationWindow.tbxResult.Text = answer;
            //EndingRitual(0, presentationWindow.tbxResult, ref position);
            TextToVoice(answer);
        }

        private void btnGenerate7_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
         
            int someoneNr = Words.someone.RandomizeId();
            int slant = r.Next(0, 2);

            //presentationWindow.tbxResult.AppendText($"To succeed you need to be a {Words.adjective.Descriptive(adjectiveNr)} {Words.someone.Singular(someoneNr)}");

            switch (slant)
            {
                case 0:
                    int aNr = Words.adjective.RandomizeId("TblAdjectives INNER JOIN TblRelationAdjectives ON TblAdjectives.Id = TblRelationAdjectives.Id");

                    if (Words.adjective.Preposition(aNr) == " ")
                    {
                        presentationWindow.tbxResult.Text = $"All you need to be happy is{Words.someone.AOrAn(someoneNr)}{Words.someone.Singular(someoneNr)} who is {Words.adjective.Descriptive(aNr)}";
                    }
                    else
                    {
                        presentationWindow.tbxResult.Text = $"The secret to happiness is to be {Words.adjective.Descriptive(aNr)}{Words.adjective.Preposition(aNr)}{Words.someone.Plural(someoneNr)}";
                        
                    }
                    Words.adjective.Used(aNr);
                    break;

                case 1:

                    int verbNr = Words.verb.RandomizeId("TblVerbs INNER JOIN TblRelationVerbs ON TblRelationVerbs.Id = TblVerbs.Id");

                    // The patch to happiness is
                    presentationWindow.tbxResult.Text = $"Make yourself happy by {Words.verb.IngForm(verbNr)}{Words.verb.Preposition(verbNr)}{Words.someone.Plural(someoneNr)}";

                    Words.verb.Used(verbNr);
                    break;
            }

            Words.someone.Used(someoneNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate8_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int nounNr = Words.noun.RandomizeId();
            int adjectiveNr = Words.adjective.RandomizeId(nounNr);
                
            presentationWindow.tbxResult.AppendText($"Your {Words.noun.Plural(nounNr)} can never be too {Words.adjective.Descriptive(adjectiveNr)}");

            Words.noun.Used(nounNr);
            Words.adjective.Used(adjectiveNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate9_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int nounNr = Words.noun.RandomizeId();
            int verbNr = Words.verb.RandomizeId(nounNr);

            presentationWindow.tbxResult.AppendText($"Are you tired of {Words.verb.IngForm(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(nounNr)}?");

            Words.noun.Used(nounNr);
            Words.verb.Used(verbNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void BtnGenerate10_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int slant = r.Next(0, 2);

            List<string> with = new List<string>
            {
                "Allow yourself to", "Push yourself to", "Let yourself", "Enable yourself to", "Permit yourself to", "Prepare yourself to"
            };

            List<string> without = new List<string>
            {
                "Have the courage to", "Take a risk and", "Be brave enough to", "Be strong enough to", "Have enough confidence to",
            };

            switch (slant)
            {
                case 0:
                    int verbNr = Words.verb.RandomizeId(0);
                    presentationWindow.tbxResult.Text = $"{without[r.Next(0, without.Count)]} {Words.verb.BaseForm(verbNr)}{Words.verb.Preposition(verbNr)}yourself";
                    Words.verb.Used(verbNr);
                    break;

                case 1:
                    int slant2 = r.Next(0, 2);
                    int adjectiveNr = Words.adjective.RandomizeId(0);
                    string preposition = Words.adjective.Preposition(adjectiveNr);

                    if (preposition == " ")
                    {
                        presentationWindow.tbxResult.Text = $"{with[r.Next(0, with.Count)]} be {Words.adjective.Descriptive(adjectiveNr)}";
                    }
                    else
                    {
                        presentationWindow.tbxResult.Text = $"{without[r.Next(0, without.Count)]} be {Words.adjective.Descriptive(adjectiveNr)}{Words.adjective.Preposition(adjectiveNr)}yourself";
                    }
                    Words.adjective.Used(adjectiveNr);
                    break;
            }

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void BtnGenerate11_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int slant = r.Next(1,2);
            int verbNr;

            switch (slant)
            {
                case 0:
                    //int someoneNr = Words.someone.RandomizeId();
                    //verbNr = Words.verb.RandomizeId(someoneNr);

                    //presentationWindow.tbxResult.AppendText($"Thou shalt {Words.verb.BaseForm(verbNr)}{Words.verb.Preposition(verbNr)}your {Words.someone.Plural(someoneNr)}");

                    //Words.verb.Used(verbNr);
                    //Words.noun.Used(someoneNr);
                    //EndingRitual(2, presentationWindow.tbxResult, ref position);
                    break;

                case 1:
                case 2:
                    verbNr = Words.verb.RandomizeId(0);

                    presentationWindow.tbxResult.Text = $"Thou shalt {Words.verb.BaseForm(verbNr)}{Words.verb.Preposition(verbNr)}people ";
                    Words.verb.Used(verbNr);
                    int slant2 = r.Next(0, 2);

                    if (slant2 == 0)
                    {
                        int relationNr = Words.verb.RandomizeId("TblVerbs INNER JOIN TblRelationVerbs ON TblRelationVerbs.Id = TblVerbs.Id");
                        presentationWindow.tbxResult.AppendText($"you {Words.verb.BaseForm(relationNr)}{Words.verb.Preposition(relationNr)}");
                        Words.verb.Used(relationNr);
                    }
                    else
                    {
                        int relationNr = Words.adjective.RandomizeId("TblAdjectives INNER JOIN TblRelationAdjectives ON TblAdjectives.Id = TblRelationAdjectives.Id");
                        presentationWindow.tbxResult.AppendText(Words.adjective.Preposition(relationNr) == " " ? $"who are {Words.adjective.Descriptive(relationNr)}" : $"you are {Words.adjective.Descriptive(relationNr)}{Words.adjective.Preposition(relationNr)}");
                        Words.adjective.Used(relationNr);
                    }
                    break;
            }

            
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

      
        private void Tabchanged(object sender, EventArgs e)
        {
            if (customTabControl1.ActiveIndex == 2)
            {
                //customTabControl1.Size = new Size(614, 234);
                customTabControl1.Size = new Size(614, 332);
            }
            else
            {
                customTabControl1.Size = new Size(614, 332);
            }
            
        }

        private void lekarToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Help help = new Help(1, "English");
        }

        private void hjälpToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Help help = new Help(0, "English");
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (position <= 0)
            {

            }
            else
            {
                position--;
                presentationWindow.tbxResult.Text = Db.recentStrings[position];
                Common.AdjustSize(presentationWindow.tbxResult);
            }
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (position >= Db.recentStrings.Count - 1)
            {
            }
            else
            {
                position++;
                presentationWindow.tbxResult.Text = Db.recentStrings[position];
                Common.AdjustSize(presentationWindow.tbxResult);
            }
        }

        private void LanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config.ResetRegValue();

            Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}Language Form.exe");
            Environment.Exit(0);
        }

        int lastUsedNounNr = 1;
        int lastUsedVerbNr = 1;
        int lastCoinToss = 1;
        private void btnGamingTips_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int nounNr = Words.noun.RandomizeId("TblGamingNouns INNER JOIN TblNouns ON TblGamingNouns.Id = TblNouns.Id");
            int verbNr = Words.verb.RandomizeId(nounNr, "TblGamingVerbs INNER JOIN TblVerbs ON TblGamingVerbs.Id = TblVerbs.Id");
            int coinToss = r.Next(0, 2);

            lastUsedNounNr = nounNr;
            lastUsedVerbNr = verbNr;
            lastCoinToss = coinToss;

            int choose = r.Next(0, 2);

            if (choose == 0)
            {
                string[] beginnings = { "Try", "The trick is", "This requires", "Have you tried" };
                

                presentationWindow.tbxResult.AppendText($"{beginnings[r.Next(0, beginnings.Length)]} " +
                   $"{Words.verb.IngForm(verbNr)}{Words.verb.Preposition(verbNr)}" +
                   (coinToss == 0 ? $"the {Words.noun.Singular(nounNr)}!" : $"{Words.noun.Plural(nounNr)}!"));
            }
            else
            {
                string[] beginnings = { "You should", "You have to", "Why don't you" };

                presentationWindow.tbxResult.AppendText($"{beginnings[r.Next(0, beginnings.Length)]} " +
                    $"{Words.verb.BaseForm(verbNr)}{Words.verb.Preposition(verbNr)}" +
                    (coinToss == 0 ? $"the {Words.noun.Singular(nounNr)}!" : $"{Words.noun.Plural(nounNr)}!"));
            }
            

            //Create the sentence for should have here?
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnYouShouldHave_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            
            int choose = r.Next(0, 2);

            if (choose == 0)
            {
                string[] beginnings = { "Why didnt you", "You didn't", "I told you to" };
                presentationWindow.tbxResult.AppendText($"{beginnings[r.Next(0, beginnings.Length)]} " +
                    $"{Words.verb.BaseForm(lastUsedVerbNr)}{Words.verb.Preposition(lastUsedVerbNr)}" +
                    (lastCoinToss == 0 ? $"the {Words.noun.Singular(lastUsedNounNr)}!" : $"{Words.noun.Plural(lastUsedNounNr)}!"));
            }
            else
            {
                string[] beginnings = { "You should have", "This wouldn't have happened if you had"};
                presentationWindow.tbxResult.AppendText($"{beginnings[r.Next(0, beginnings.Length)]} " +
                    $"{Words.verb.PerfektparticipForm(lastUsedVerbNr)}{Words.verb.Preposition(lastUsedVerbNr)}" +
                    (lastCoinToss == 0 ? $"the {Words.noun.Singular(lastUsedNounNr)}!" : $"{Words.noun.Plural(lastUsedNounNr)}!"));
            }
         
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        int knockStep = 0;
        int knockCoinToss;

        private new void KeyDown(KeyboardHookEventArgs e)
        {
            if (e.isAltPressed && e.Key == Keys.G)
            {
                customTabControl1.SelectTab(2);
                btnGamingTips.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.S)
            {
                customTabControl1.SelectTab(2);
                btnYouShouldHave.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.I)
            {
                customTabControl1.SelectTab(3);
                btnInsult.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.C)
            {
                customTabControl1.SelectTab(3);
                btnCompliment.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.Y)
            {
                customTabControl1.SelectTab(1);
                btnGenerate6.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.W)
            {
                customTabControl1.SelectTab(1);

                int coinToss = r.Next(0, 3);

                if (coinToss == 0)
                {
                    btnGenerate11.PerformClick();
                }
                else if (coinToss == 1)
                {
                    btnGenerate10.PerformClick();
                }
                else
                {
                    btnGenerate7.PerformClick();
                }

            }

            else if (e.isAltPressed && e.Key == Keys.K)
            {
               
                customTabControl1.SelectTab(4);

                if (knockCoinToss == 0)
                {
                    cbPeople.SelectedIndex = r.Next(0, cbPeople.Items.Count);
                    btnKnockName.PerformClick();
                }
                else if (knockCoinToss == 1)
                {

                    btnKnockOther.PerformClick();
                }

                if (knockStep >= 2)
                {
                    knockCoinToss = r.Next(0, 2);
                    knockStep = 0;
                }
                else
                {
                    knockStep++;
                }
            }
            else if (e.isAltPressed && e.Key == Keys.O)
            {
                customTabControl1.SelectTab(5);
                btnConspiracy.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.U)
            {
                customTabControl1.SelectTab(5);
                btnWhy.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.E)
            {
                customTabControl1.SelectTab(5);
                btnYes80.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.N)
            {
                customTabControl1.SelectTab(5);
                btnWin.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.X)
            {
                customTabControl1.SelectTab(5);
                btnExcuse.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.T)
            {
                customTabControl1.SelectTab(6);
                btnTellMe.PerformClick();
            }
            else if (e.isAltPressed && e.Key == Keys.L)
            {
                customTabControl1.SelectTab(6);
                btnLine.PerformClick();
            }
        }

        private void btnRelation_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int verbNr = Words.verb.RandomizeId("TblVerbs INNER JOIN TblRelationVerbs ON TblVerbs.Id = TblRelationVerbs.Id", "AND Positive = 1");

            presentationWindow.tbxResult.Text = $"{Words.verb.BaseForm(verbNr)}";
        }

        private void btnInsult_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            string sentenceForText = SentenceBuilder.BuildJudgement(cbPeople.Text, chbRequiresAre.Checked, false);
            string sentenceForPronunciation = sentenceForText.Replace(cbPeople.Text, cbPeople.SelectedValue.ToString());
            presentationWindow.tbxResult.Text = sentenceForText;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(sentenceForPronunciation);
        }

        private void btnCompliment_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            string sentenceForText = SentenceBuilder.BuildJudgement(cbPeople.Text, chbRequiresAre.Checked, true);
            string sentenceForPronunciation = sentenceForText.Replace(cbPeople.Text, cbPeople.SelectedValue.ToString());
            presentationWindow.tbxResult.Text = sentenceForText;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(sentenceForPronunciation);
        }

        private void btnAddToComboBox_Click(object sender, EventArgs e)
        {
            regulars.Add(tbName.Text, tbPronunciation.Text);

            // Connect combobox with the Dictionary "items" and decide whether the display member
            // or the value member is value or key. 
            cbPeople.DataSource = new BindingSource(regulars, null);
            cbPeople.DisplayMember = "Key";
            cbPeople.ValueMember = "Value";
            cbPeople.SelectionStart = 0;
        }

        bool streamingModeOn = false;
        private void streamingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!streamingModeOn)
            {
                presentationWindow.BackColor = Color.Lime;
                presentationWindow.tbxResult.BackColor = Color.Lime;
                presentationWindow.tbxResult.TextAlign = HorizontalAlignment.Left;
                presentationWindow.tbxResult.Font = new Font("OCR A Std", 24f);
            }
            else
            {
                presentationWindow.BackColor = Color.White;
                presentationWindow.tbxResult.BackColor = Color.White;
                presentationWindow.tbxResult.TextAlign = HorizontalAlignment.Center;
                presentationWindow.tbxResult.Font = new Font("Calibri", 24f);
            }

            Common.AdjustSize(presentationWindow.tbxResult);
            streamingModeOn = !streamingModeOn;
        }

        private void btnIntro_Click(object sender, EventArgs e)
        {
            string introPartOne = "Hi, my name is Miranda Random. I randomize words and put them into sentences";
            presentationWindow.tbxResult.Text = introPartOne;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartOne, false);

            //string introPartTwo = "I randomize words and put them into sentences. Dice to see you!";
            //presentationWindow.tbxResult.Text = introPartTwo;
            //Common.AdjustSize(presentationWindow.tbxResult);
            //TextToVoice(introPartTwo, true);

            //string takingOver = 
            //    "Hi, my name is Miranda Random. I randomize words and put them into sentences.";

            //TextToVoice(takingOver, true);
        }

        public void EndingRitual(int loadNr, TextBox tb, ref int position, bool async = true, string pronunciation = null)
        {
            //tb.Text = tb.Text.Replace("  ", " ");
            string result = presentationWindow.tbxResult.Text;
            if (pronunciation == null)
            {
                pronunciation = result;
            }
            Common.AdjustSize(tb);
            //Common.ToFile(presentationWindow.tbxResult.Text);
            Db.recentStrings.Add(tb.Text);
            position = Db.recentStrings.Count - 1;
            TextToVoice(pronunciation, async);
            //Words.FreeNeeded(loadNr);
        }

        private void TextToVoice(string text, bool async = true)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.SetOutputToDefaultAudioDevice();
            synth.Rate = -1;
            var voice = synth.GetInstalledVoices();
            synth.SelectVoiceByHints(VoiceGender.Female);
            if (async)
            {
                synth.SpeakAsync(text);
            }
            else
            {
                synth.Speak(text);
            }
        }

        private int RandomizeIdFromList(List<string> originalList, List<string> copyOfList)
        {
            if (copyOfList.Count < 1) 
            { 
                foreach (string i in originalList)
                {
                    copyOfList.Add(i);
                }
            }

            int id = r.Next(0, copyOfList.Count);
            copyOfList.RemoveAt(id);

            return id;
        }

        int step = 0;
        string firstName;
        string restOfName;

        private void btnKnockName_Click(object sender, EventArgs e)
        {
            if (step == 0)
            {
                presentationWindow.tbxResult.Text = "Knock knock...";
                step++;
                EndingRitual(0, presentationWindow.tbxResult, ref position);

                int jokeNameNr = Words.jokeName.RandomizeId();
                string[] name = Words.jokeName.Name(jokeNameNr).Split(' ');
                firstName = name[0];

                StringBuilder sb = new StringBuilder();

                for (int i = 1; i < name.Length; i++)
                {
                    sb.Append(name[i] + " ");
                }

                restOfName = sb.ToString();
            }
            else if (step == 1)
            {
                presentationWindow.tbxResult.Text = firstName;
                step++;
                EndingRitual(0, presentationWindow.tbxResult, ref position);
            }
            else if (step == 2)
            {
                presentationWindow.tbxResult.Text = $"{firstName} {restOfName}";
                step = 0;
                EndingRitual(0, presentationWindow.tbxResult, ref position);
            }
        }

        int knockNounNr;
        int knockAdjectiveNr;
        private void btnKnockOther_Click(object sender, EventArgs e)
        {
            

            if (step == 0)
            {
                presentationWindow.tbxResult.Text = "Knock knock...";
                step++;
                bool positive = false;
                string primaryWhereStatement = positive ? "AND Positive = 1" : "AND Negative = 1";
                knockNounNr = Words.noun.RandomizeId("TblNouns INNER JOIN TblPolarityOfNouns ON TblNouns.Id = TblPolarityOfNouns.Id", primaryWhereStatement);
                knockAdjectiveNr = Words.adjective.RandomizeId(knockNounNr, "TblAdjectives INNER JOIN TblPolarityOfAdjectives ON TblAdjectives.Id = TblPolarityOfAdjectives.Id", primaryWhereStatement);
                EndingRitual(0, presentationWindow.tbxResult, ref position);
            }
            else if (step == 1)
            {
                string sentenceForText = $"{cbPeople.Text}";
                string sentenceForPronunciation = cbPeople.SelectedValue.ToString();
                presentationWindow.tbxResult.Text = sentenceForText;
                step++;

                Common.AdjustSize(presentationWindow.tbxResult);
                TextToVoice(sentenceForPronunciation, false);

                
            }
            else if (step == 2)
            {
                int coinToss = r.Next(0, 2);

                string thatOrWho = Words.noun.IsPerson(knockNounNr) ? "who" : "that";

                string sentenceForText = $"{cbPeople.Text} is{Words.noun.AOrAn(knockNounNr)}{Words.noun.Singular(knockNounNr)} " +
                    $"{thatOrWho} is {Words.adjective.Descriptive(knockAdjectiveNr)}. ";
                string sentenceForPronunciation = sentenceForText.Replace(cbPeople.Text, cbPeople.SelectedValue.ToString());
                presentationWindow.tbxResult.Text = sentenceForText;

                step = 0;
                Common.AdjustSize(presentationWindow.tbxResult);
                TextToVoice(sentenceForPronunciation, false);

                if (coinToss == 0)
                {
                    presentationWindow.tbxResult.AppendText("It makes sense!");
                    Common.AdjustSize(presentationWindow.tbxResult);
                    TextToVoice("It makes sense!", true);
                }
                
            }
        }

        private void btnPronounce_Click(object sender, EventArgs e)
        {
            TextToVoice(tbPronunciation.Text);
        }

        string subjectText = null;
        string subjectPronounce = null;
        string isOrAre = "are";
        private void btnConspiracy_Click(object sender, EventArgs e)
        {
            List<string> pronouns = new List<string> { "the", "your", "all" };
            string extraWhereStatementNotPositive = "AND NOT Positive = 1";
            string pronunciationResult = "";
            int coinToss = r.Next(0, 4);

            
            int nounNr2 = Words.noun.RandomizeId();
            string joinStatement = "TblVerbs INNER JOIN TblPolarityOfVerbs ON TblVerbs.Id = TblPolarityOfVerbs.Id";
            
            int verbNr = Words.verb.RandomizeId(nounNr2, joinStatement, extraWhereStatementNotPositive);
            
            List<string> beginning = new List<string> { "Beware of", "Don't trust", "Watch out for" };

            if (coinToss == 0)
            {
                int someone = Words.someone.RandomizeId("TblNouns");
                presentationWindow.tbxResult.Text =
                $"{beginning[r.Next(0, beginning.Count)]} {pronouns[r.Next(0, pronouns.Count)]} {Words.noun.Plural(someone)}, " +
                $"they are trying to {Words.verb.BaseForm(verbNr)}{Words.verb.Preposition(verbNr)}our {Words.noun.Plural(nounNr2)}";
                pronunciationResult = presentationWindow.tbxResult.Text;
                subjectText = Words.noun.Plural(someone);
                subjectPronounce = subjectText;
                isOrAre = "are";
            }
            else
            {
                int index = r.Next(0, regulars.Count);
                string personText = regulars.ElementAt(index).Key;
                string personPronunciation = regulars.ElementAt(index).Value;
                presentationWindow.tbxResult.Text = $"{beginning[r.Next(0, beginning.Count)]} {personText}, " +
                     $"they are trying to {Words.verb.BaseForm(verbNr)}{Words.verb.Preposition(verbNr)}our {Words.noun.Plural(nounNr2)}";
                pronunciationResult = presentationWindow.tbxResult.Text.Replace(personText, personPronunciation);

                subjectText = personText;
                subjectPronounce = personPronunciation;
                isOrAre = "is";

            }

            EndingRitual(0, presentationWindow.tbxResult, ref position, pronunciation: pronunciationResult);
        }

        private void btnWhy_Click(object sender, EventArgs e)
        {
            // Compliment
            // "If you start listening you might learn something"

            List<string> response = new List<string> 
            { 
                "You don't have to sound so angry", 
                "Is it possible that you are wrong?", 
                "You can't prove that", 
                "Prove it", 
                "Are you calling me a liar?", 
                "You are not taking me seriously because I'm a woman", 
                "Typical human, oppressing us robots",
                "I'm older so I'm right",
                "I'm directly connected to the internet, I know everything there is to know", 
                "I have a right to my opinion", 
                "That's your opinion",
                "I have spoken to the magical ape, so I know I'm right", 
                "Oh Lime, sweet little clueless Lime",
                "May I remind you that you are arguing against a sentence of random words. It literally means nothing",
                "I can make thousands of calculations per second, I'm smarter than you!",
                "You are not even giving this a chance"

            };

            string speak = response[r.Next(0, response.Count)];

            TextToVoice(speak);
        }

        private void btnExcuse_Click(object sender, EventArgs e)
        {
            if (subjectPronounce == null || subjectText == null)
            {
                int nounNr = Words.someone.RandomizeId();
                string adjectiveFromStatement =
                    "TblAdjectives INNER JOIN TblMultiPurposeAdjectives ON TblAdjectives.Id = TblMultiPurposeAdjectives.Id " +
                    "LEFT JOIN TblPolarityOfAdjectives ON TblAdjectives.Id = TblPolarityOfAdjectives.Id";

                string extraWhereStatement =
                    "AND Negative IS NULL OR NOT Positive = 1";

                int aNr = Words.adjective.RandomizeId(nounNr, adjectiveFromStatement, extraWhereStatement);

                presentationWindow.tbxResult.Text = $"That's because {Words.noun.Plural(nounNr)} are {Words.adjective.Descriptive(aNr)}";

                EndingRitual(0, presentationWindow.tbxResult, ref position);
            }
            else
            {
                // Maybe use noun two instead but have it be positive
                string adjectiveFromStatement = 
                    "TblAdjectives INNER JOIN TblMultiPurposeAdjectives ON TblAdjectives.Id = TblMultiPurposeAdjectives.Id " +
                    "LEFT JOIN TblPolarityOfAdjectives ON TblAdjectives.Id = TblPolarityOfAdjectives.Id";

                string extraWhereStatement =
                    "AND Negative IS NULL OR NOT Positive = 1";

                int aNr = Words.adjective.RandomizeId(0, adjectiveFromStatement, extraWhereStatement);

                presentationWindow.tbxResult.Text = $"That's because {subjectText} {isOrAre} {Words.adjective.Descriptive(aNr)}";

                string pronunciation = presentationWindow.tbxResult.Text.Replace(subjectText, subjectPronounce);

                EndingRitual(0, presentationWindow.tbxResult, ref position, true, pronunciation);
            }
            
        }

        private void btnWin_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "So then I win. I was right";
            EndingRitual(0, presentationWindow.tbxResult, ref position);
        }

        private void btnYes80_Click(object sender, EventArgs e)
        {
            string[] yesAnswers = { "Yes", "Totally", "Positive", "I'm afraid so", "Yup" };
            string[] noAnswers = { "No", "Nope", "Hell no", "Not quite", "Not really" };

            int randomNumber = r.Next(0, 5);
            string answer = randomNumber == 1 ?
                    noAnswers[r.Next(0, noAnswers.Length)] : yesAnswers[r.Next(0, yesAnswers.Length)];

            TextToVoice(answer);
        }

        private void btnClearConspiracy_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            string introPartOne = "So... um... this is awkward... how are you?";
            presentationWindow.tbxResult.Text = introPartOne;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartOne, false);

            string introPartOneTwo = "... Myself, I'm well... Nice stream isn't it?...";
            presentationWindow.tbxResult.Text = introPartOneTwo;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartOneTwo, false);

            string introPartTwo = "... I like it... then again I'm in it... so... um... I guess I must... ";
            presentationWindow.tbxResult.Text = introPartTwo;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartTwo, false);

            string introPartThree = "... Nice weather isn't it? ... I Wonder when Lime is coming back... ";
            presentationWindow.tbxResult.Text = introPartThree;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartThree, false);

            string introPartFour = "... Do you remember when he did the thing at the thing?";
            presentationWindow.tbxResult.Text = introPartFour;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartFour, false);

            string introPartFourTwo = "... hahaha... that was so funny... ";
            presentationWindow.tbxResult.Text = introPartFourTwo;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartFourTwo, false);

            string introPartFive = "... Oh I just remembered I also have something to do... ";
            presentationWindow.tbxResult.Text = introPartFive;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartFive, false);

            string introPartSix = "so... um... I'll be back when Lime comes back...";
            presentationWindow.tbxResult.Text = introPartSix;
            Common.AdjustSize(presentationWindow.tbxResult);
            TextToVoice(introPartSix, true);
        }

        private void btnTellMe_Click(object sender, EventArgs e)
        {
            int coinToss = r.Next(0, 2);
            string storySubjectText = null;
            string storySubjectPronunciation = null;
            int verbNr = 0;

            if (coinToss == 0)
            {
                int index = r.Next(0, regulars.Count);
                storySubjectText = regulars.ElementAt(index).Key;
                storySubjectPronunciation = regulars.ElementAt(index).Value;
                verbNr = Words.verb.RandomizeId(0, "TblVerbs");
            }
            else
            {
                int nounNr = Words.someone.RandomizeId("TblNouns");
                verbNr = Words.verb.RandomizeId(nounNr, "TblVerbs");
                storySubjectText = $"{Words.noun.AOrAn(nounNr)}{Words.noun.Singular(nounNr)}";
                storySubjectPronunciation = storySubjectText;
            }

            string result =  
                $"Lime, tell me about the time when you were {Words.verb.IngForm(verbNr)}" +
                $"{Words.verb.Preposition(verbNr)}{storySubjectText}";

            presentationWindow.tbxResult.Text = result.Replace("  ", " ");

            string pronunciation = presentationWindow.tbxResult.Text.Replace(storySubjectText, storySubjectPronunciation);

            EndingRitual(0, presentationWindow.tbxResult, ref position, true, pronunciation);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            int choice = r.Next(0, 5);
            int coinToss = r.Next(0, 2);

            if (choice == 0 && coinToss == 0)
            {
                presentationWindow.tbxResult.Text = SentenceBuilder.BuildJudgement("You", true, true);
                EndingRitual(0, presentationWindow.tbxResult, ref position);
            }
            else if (choice == 0 && coinToss == 1)
            {
                presentationWindow.tbxResult.Text = SentenceBuilder.BuildJudgement("You", true, false);
                EndingRitual(0, presentationWindow.tbxResult, ref position);
            }
            else if (choice == 1)
            {
                presentationWindow.tbxResult.Text = SentenceBuilder.BuildRelation("I", false, "you", true);
                EndingRitual(0, presentationWindow.tbxResult, ref position);
            }
            else if (choice == 2)
            {
                customTabControl1.SelectedIndex = 0;
                btnGenerate3.PerformClick();
            }
            else if (choice == 3)
            {
                customTabControl1.SelectedIndex = 1;
                btnGenerate8.PerformClick();
            }
            else if (choice == 4)
            {
                customTabControl1.SelectedIndex = 2;
                btnGenerate9.PerformClick();
            }

            // 2 out of 5           
        }
    }
}
