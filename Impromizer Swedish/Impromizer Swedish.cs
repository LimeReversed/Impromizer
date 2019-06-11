using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Configuration;
// Adding Svenska tells this form that "Words" refers to the Ord class.
// This way I can also have a Engelska class without having to change too much
using Svenska;


// Svenska 
namespace Headline_Randomizer
{
    public partial class Swedish : Form
    {
        // Creating objects to be able to reach their properties
        PresentationWindow presentationWindow = new PresentationWindow();
        Random r = new Random();
        int position;
        

        public Swedish()
        {
            InitializeComponent();

            // Show the second window at a precise location relative to the main window.
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);
            presentationWindow.Show();

            // Set variables in Db so the swedish info is reachable through there. 
            Db.connectionString = $"Data Source= {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer\\WordsDatabaseSwedish.db3";

            Words.FreeNeeded(1000);
        }

        
        // 
        // Click animation eventhandlers
        //
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

        private void BtnGenerate8_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate8.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate8_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate8.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnClear2_MouseDown(object sender, MouseEventArgs e)
        {
            btnClear2.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnClear2_MouseUp(object sender, MouseEventArgs e)
        {
            btnClear2.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate7_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate7.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate9_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate9.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate9_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate9.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate7_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate7.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate10_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate10.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate10_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate10.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate11_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate11.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnGenerate11_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate11.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnClear3_MouseDown(object sender, MouseEventArgs e)
        {
            btnClear3.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnClear3_MouseUp(object sender, MouseEventArgs e)
        {
            btnClear3.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        #endregion

        // 
        // Tab: Rubriker
        //

        private void btnGenerate1_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneId = Words.someone.RandomizeId();
            int adjectiveId = Words.adjective.RandomizeId(someoneId);
            int nr2 = r.Next(1, 11);
            int nr1 = r.Next(1, (nr2 + 1));

            presentationWindow.tbxResult.Text = $"{nr1} av {nr2} tycker att {Words.noun.Plural(someoneId)} är {Words.adjective.Plural(adjectiveId)}";

             // Remove used words
            Words.noun.Used(someoneId);
            Words.adjective.Used(adjectiveId);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void BtnGenerate2_Click(object sender, EventArgs e)
        {   
            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                presentationWindow.tbxResult.Text = "";
                int someoneNr = Words.someone.RandomizeId();

                presentationWindow.tbxResult.AppendText($"{Common.FirstLetterUpper(Words.noun.SingularObest(someoneNr))} ");
                Words.noun.Used(someoneNr);

                int somethingNr = Words.something.RandomizeId();
                int verbNr = Words.verb.RandomizeId(somethingNr);
                int adjectiveNr = Words.adjective.RandomizeId(somethingNr);

                presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(verbNr)}{Words.verb.Preposition(verbNr)}{Words.adjective.Automatic(adjectiveNr, somethingNr, true)} {Words.noun.SingularObest(somethingNr)}");

                Words.verb.Used(verbNr);
                Words.noun.Used(somethingNr);
                Words.adjective.Used(adjectiveNr);

                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
            else if (slant == 1)
            {
                presentationWindow.tbxResult.Text = "";
                int someoneNr = Words.someone.RandomizeId();

                presentationWindow.tbxResult.AppendText($"{Common.FirstLetterUpper(Words.noun.SingularObest(someoneNr))} ");
                Words.noun.Used(someoneNr);

                int someoneNr2 = Words.someone.RandomizeId();
                int verbNr = Words.verb.RandomizeId(someoneNr2);
                int adjectiveNr = Words.adjective.RandomizeId(someoneNr2);

                presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(verbNr)}{Words.verb.Preposition(verbNr)}{Words.adjective.Automatic(adjectiveNr, someoneNr2, true)} {Words.noun.SingularObest(someoneNr2)}");

                Words.verb.Used(verbNr);
                Words.noun.Used(someoneNr2);
                Words.adjective.Used(adjectiveNr);

                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int someoneNr2 = Words.someone.RandomizeId();
            int somethingNr = Words.something.RandomizeId();
            presentationWindow.tbxResult.AppendText($"Forskare överens om att {Words.noun.Plural(someoneNr2)} är {Words.noun.Plural(somethingNr)}");

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
                "Moderaterna", "Liberalerna", "Kristdemokraterna", "Sverigedemokraterna", "Centerpartiet", "Socialdemokraterna", "Miljöpartiet",
                "Vänsterpartiet"
            };
            Random r = new Random();
            int politikerNr = r.Next(0, politiker.Count);

            presentationWindow.tbxResult.AppendText($"{politiker[politikerNr]} kräver att vi {Words.verb.Presens(verbNr)}{Words.verb.Preposition(verbNr)}fler {Words.noun.Plural(someoneNr)}");
            Words.verb.Used(verbNr);
            Words.noun.Used(someoneNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate5_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int somethingNr = Words.something.RandomizeId();
            int jokeNameNr = Words.jokeName.RandomizeId();
            int nobelNr = Words.nobelPrize.RandomizeId();
            int verbNr = Words.verb.RandomizeId(somethingNr);
            
            presentationWindow.tbxResult.AppendText($"{Words.jokeName.Name(jokeNameNr)} vann {Words.nobelPrize.Prize(nobelNr)} för att ha {Words.verb.Perfekt(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(somethingNr)}");

            Words.jokeName.Used(jokeNameNr);
            Words.nobelPrize.Used(nobelNr);
            Words.verb.Used(verbNr);
            Words.noun.Used(somethingNr);
            EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }


        // 
        // Tab: Visdom
        //

        private void BtnGenerate11_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int slant = r.Next(1, 2);
            int verbNr;

            switch (slant)
            {
                case 0:
                    //int someoneNr = Words.someone.RandomizeId();
                    //verbNr = Words.verb.RandomizeId(someoneNr);

                    //presentationWindow.tbxResult.AppendText($"Du skall {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}dina {Words.someone.Plural(someoneNr)}");

                    //Words.verb.Used(verbNr);
                    //Words.noun.Used(someoneNr);
                    //EndingRitual(2, presentationWindow.tbxResult, ref position);
                    break;

                case 1:
                case 2:
                    verbNr = Words.verb.RandomizeId(0);

                    presentationWindow.tbxResult.Text = $"Du skall {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}dem ";
                    Words.verb.Used(verbNr);
                    int slant2 = r.Next(0, 2);

                    if (slant2 == 0)
                    {
                        int relationNr = Words.verb.RandomizeRelation();
                        presentationWindow.tbxResult.AppendText($"du {Words.verb.Presens(relationNr)}{Words.verb.Preposition(relationNr)}");
                        Words.verb.Used(relationNr);
                    }
                    else
                    {
                        int relationNr = Words.adjective.RandomizeRelation();
                        presentationWindow.tbxResult.AppendText(Words.adjective.Preposition(relationNr) == " " ? $"som är {Words.adjective.Plural(relationNr)}" : $"du är {Words.adjective.NGenus(relationNr)}{Words.adjective.Preposition(relationNr)}");
                        Words.adjective.Used(relationNr);
                    }
                    break;

            }
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void BtnGenerate10_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int slant = r.Next(0, 2);

            List<string> with = new List<string>
            {
                "Tillåt dig själv att", "Unna dig att", "Ge dig själv möjligheten att", "Förbered dig på att"
            };

            List<string> without = new List<string>
            {
                "Våga", "Ta chansen att", "Var modig nog att", "Var stark nog att", "Ha självförtroende nog att"
            };

            switch (slant)
            {
                case 0:
                    int verbNr = Words.verb.RandomizeId(0);
                    presentationWindow.tbxResult.Text = $"{without[r.Next(0, without.Count)]} {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}dig själv";
                    Words.verb.Used(verbNr);
                    break;

                case 1:
                    int slant2 = r.Next(0, 2);
                    int adjectiveNr = Words.adjective.RandomizeId(0);
                    string preposition = Words.adjective.Preposition(adjectiveNr);

                    if (preposition == " ")
                    {
                        presentationWindow.tbxResult.Text = $"{with[r.Next(0, with.Count)]} vara {Words.adjective.NGenus(adjectiveNr)}";
                    }
                    else
                    {
                        presentationWindow.tbxResult.Text = $"{without[r.Next(0, without.Count)]} vara {Words.adjective.NGenus(adjectiveNr)}{Words.adjective.Preposition(adjectiveNr)}dig själv";
                    }
                    Words.adjective.Used(adjectiveNr);
                    break;
            }

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void BtnGenerate7_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int someoneNr = Words.someone.RandomizeId();
            int slant = r.Next(0, 2);

            //presentationWindow.tbxResult.AppendText($"To succeed you need to be a {Words.adjective.Descriptive(adjectiveNr)} {Words.someone.Singular(someoneNr)}");

            switch (slant)
            {
                case 0:
                    int aNr = Words.adjective.RandomizeRelation();

                    if (Words.adjective.Preposition(aNr) == " ")
                    {
                        presentationWindow.tbxResult.Text = $"Allt du behöver för lycka är {Words.someone.EnEllerEtt(someoneNr)} {Words.someone.SingularObest(someoneNr)} som är {Words.adjective.Automatic(aNr, someoneNr, true)}";
                    }
                    else
                    {
                        presentationWindow.tbxResult.Text = $"Nyckeln till lycka är att vara {Words.adjective.NGenus(aNr)}{Words.adjective.Preposition(aNr)}{Words.someone.Plural(someoneNr)}";

                    }
                    Words.adjective.Used(aNr);
                    break;

                case 1:

                    int verbNr = Words.verb.RandomizeRelation();


                    // The path to happiness is
                    presentationWindow.tbxResult.Text = $"Gör dig själv lycklig genom att {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}{Words.someone.Plural(someoneNr)}";

                    Words.verb.Used(verbNr);
                    break;
            }

            Words.someone.Used(someoneNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void BtnGenerate8_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int nounNr = Words.noun.RandomizeId();
            int adjectiveNr = Words.adjective.RandomizeId(nounNr);


            presentationWindow.tbxResult.AppendText($"{Common.FirstLetterUpper(Words.noun.DinEllerDitt(nounNr, false))} {Words.noun.Plural(nounNr)} kan aldrig vara för {Words.adjective.Automatic(adjectiveNr, nounNr, false)}");

            Words.noun.Used(nounNr);
            Words.adjective.Used(adjectiveNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        // 
        // Tab: Scen
        //

        // Save settings

        // 
        // Tab: Övrigt
        //

        private void btnGenerate9_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                int someoneNr = Words.someone.RandomizeId();
                int verbNr = Words.verb.RandomizeId(someoneNr);

                presentationWindow.tbxResult.AppendText($"Är du trött på att {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(someoneNr)}?");

                Words.noun.Used(someoneNr);
                Words.verb.Used(verbNr);
                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
            else if (slant == 1)
            {
                int somethingNr = Words.something.RandomizeId();
                int verbNr = Words.verb.RandomizeId(somethingNr);

                presentationWindow.tbxResult.AppendText($"Är du trött på att {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(somethingNr)}?");

                Words.noun.Used(somethingNr);
                Words.verb.Used(verbNr);
                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
        }

        private void BtnClear3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }


        // 
        // Tab: Egen mening
        //


        // 
        // Övrigt
        //

        private void MoveWindow1(object sender, EventArgs e)
        {
            // The Presentation window will always be under the main window.
            // Location of the main window plus it's size in the Y-axis so that it's directly below. 
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);
        }

        // CHange size of the box debending on the current tab. 
        private void Tabchanged(object sender, EventArgs e)
        {
            if (customTabControl1.ActiveIndex == 2)
            {
                customTabControl1.Size = new Size(614, 135);
            }
            else
            {
                customTabControl1.Size = new Size(614, 332);
            }

            //    if (customTabControl1.ActiveIndex == 1)
            //    {
            //        customTabControl1.Size = new Size(614, 233);
            //    }
            //    else if (customTabControl1.ActiveIndex == 2)
            //    {
            //        customTabControl1.Size = new Size(614, 332);
            //        Form1 form1 = this;
            //    }
            //    else if (customTabControl1.ActiveIndex == 3)
            //    {
            //        customTabControl1.Size = new Size(614, 135);
            //    }
            //    else
            //    {
            //        customTabControl1.Size = new Size(614, 332);
            //    }
        }

        public void EndingRitual(int loadNr, TextBox tb, ref int position)
        {
            Common.ToFile(presentationWindow.tbxResult.Text);
            Common.AdjustSize(tb);
            Db.recentStrings.Add(tb.Text);
            position = Db.recentStrings.Count - 1;
            Words.FreeNeeded(loadNr);
        }


        //
        // MenuStrip
        //

        private void lekarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help(1, "Swedish");
        }

        private void hjälpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help(0, "Swedish");
        }

        // White means that the sentence isn't already on the list and if so add to database. 
        private void saveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Btnhide_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SpråkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version.Reset();

            Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}Language Form.exe");
            Environment.Exit(0);
        }


        // 
        // Tillfällig
        //

    }

}



