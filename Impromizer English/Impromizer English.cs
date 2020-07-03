﻿using System;
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

namespace Headline_Randomizer
{
    public partial class English : Form
    {
        // Creating objects to be able to reach their properties
        PresentationWindow presentationWindow = new PresentationWindow();
        Random r = new Random();
        int position;
        
        public English()
        {
            InitializeComponent();

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
            presentationWindow.tbxResult.Text = answer;
            EndingRitual(0, presentationWindow.tbxResult, ref position);
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

        public void EndingRitual(int loadNr, TextBox tb, ref int position)
        {
            //tb.Text = tb.Text.Replace("  ", " ");
           
            TextToVoice(presentationWindow.tbxResult.Text);
            Common.AdjustSize(tb);
            Common.ToFile(presentationWindow.tbxResult.Text);
            Db.recentStrings.Add(tb.Text);
            position = Db.recentStrings.Count - 1;
            //Words.FreeNeeded(loadNr);
        }

        private void TextToVoice(string text)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.SetOutputToDefaultAudioDevice();
            synth.Rate = -1;
            var voice = synth.GetInstalledVoices();
            synth.SelectVoiceByHints(VoiceGender.Female);
            synth.SpeakAsync(text);
        }

        private void Tabchanged(object sender, EventArgs e)
        {
            if (customTabControl1.ActiveIndex == 2)
            {
                customTabControl1.Size = new Size(614, 234);
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

        private void English_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.G)
            {
                customTabControl1.SelectTab(2);
                btnGamingTips.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.S)
            {
                customTabControl1.SelectTab(2);
                btnYouShouldHave.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.I)
            {
                customTabControl1.SelectTab(3);
                btnInsult.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.C)
            {
                customTabControl1.SelectTab(3);
                btnCompliment.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.Y)
            {
                customTabControl1.SelectTab(1);
                btnGenerate6.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.W)
            {
                customTabControl1.SelectTab(1);

                int coinToss = r.Next(0, 2);

                if (coinToss == 0) 
                {
                    btnGenerate11.PerformClick();
                }
                else
                {
                    btnGenerate7.PerformClick();
                }
 
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

            presentationWindow.tbxResult.Text = SentenceBuilder.BuildJudgement(cbPeople.Text, chbRequiresAre.Checked, false);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnCompliment_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            presentationWindow.tbxResult.Text = SentenceBuilder.BuildJudgement(cbPeople.Text, chbRequiresAre.Checked, true);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnAddToComboBox_Click(object sender, EventArgs e)
        {
            cbPeople.Items.Add(cbPeople.Text);
        }

        bool streamingModeOn = false;
        private void streamingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!streamingModeOn)
            {
                presentationWindow.BackColor = Color.Lime;
                presentationWindow.tbxResult.BackColor = Color.Lime;
                presentationWindow.tbxResult.TextAlign = HorizontalAlignment.Left;
                presentationWindow.tbxResult.Font = new Font("OCR A Std", 24);
            }
            else
            {
                presentationWindow.BackColor = Color.White;
                presentationWindow.tbxResult.BackColor = Color.White;
                presentationWindow.tbxResult.TextAlign = HorizontalAlignment.Center;
                presentationWindow.tbxResult.Font = new Font("Calibri", 24);
            }

            Common.AdjustSize(presentationWindow.tbxResult);
            streamingModeOn = !streamingModeOn;
        }
    }
}
