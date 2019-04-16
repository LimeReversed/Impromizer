using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
// Adding Svenska tells this form that "Words" refers to the Ord class.
// This way I can also have a Engelska class without having to change too much
using Svenska;

// Svenska 
namespace Headline_Randomizer
{
    public partial class Form1 : Form
    {
        // Creating objects to be able to reach their properties
        PresentationWindow presentationWindow = new PresentationWindow();
        Random r = new Random();
        int position;
        

        public Form1()
        {
            InitializeComponent();

            // Show the second window at a precise location relative to the main window.
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);

            presentationWindow.Show();

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

        #endregion

        // 
        // Tab: Rubriker
        //

        private void btnGenerate1_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneId = Words.someone.RandomizeId();
            int adjectiveId = Words.adjective.RandomizeId();
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

                presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.noun.SingularObest(someoneNr))} ");
                Words.noun.Used(someoneNr);

                int verbNr = Words.verb.RandomizeId();
                int somethingNr = Words.something.RandomizeId();
                int adjectiveNr = Words.adjective.RandomizeId();

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

                presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.noun.SingularObest(someoneNr))} ");
                Words.noun.Used(someoneNr);

                int verbNr = Words.verb.RandomizeId();
                int someoneNr2 = Words.someone.RandomizeId();
                int adjectiveNr = Words.adjective.RandomizeId();

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
            int someoneNr = Words.someone.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.noun.SingularObest(someoneNr))} tror att ");
            Words.noun.Used(someoneNr);

            int someoneNr2 = Words.someone.RandomizeId();
            int somethingNr = Words.something.RandomizeId();
            presentationWindow.tbxResult.AppendText($"{Words.noun.Plural(someoneNr2)} är {Words.noun.Plural(somethingNr)}");

            Words.noun.Used(someoneNr2);
            Words.noun.Used(somethingNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate4_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneNr = Words.someone.RandomizeId();
            int somethingNr = Words.something.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.noun.Plural(someoneNr))} behöver mer {Words.noun.Plural(somethingNr)}");
            Words.noun.Used(somethingNr);
            Words.noun.Used(someoneNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate5_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int jokeNameNr = Words.jokeName.RandomizeId();
            int nobelNr = Words.nobelPrize.RandomizeId();
            int verbNr = Words.verb.RandomizeId();
            int somethingNr = Words.something.RandomizeId();

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

        // 
        // Tab: Scen
        //

        // Save settings
      
        // 
        // Tab: Övrigt
        //

        private void btnGenerate8_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                int verbNr = Words.verb.RandomizeId();
                int someoneNr = Words.someone.RandomizeId();

                presentationWindow.tbxResult.AppendText($"Är du trött på att {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(someoneNr)}?");

                Words.noun.Used(someoneNr);
                Words.verb.Used(verbNr);
                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
            else if (slant == 1)
            {
                int verbNr = Words.verb.RandomizeId();
                int somethingNr = Words.something.RandomizeId();

                presentationWindow.tbxResult.AppendText($"Är du trött på att {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(somethingNr)}?");

                Words.noun.Used(somethingNr);
                Words.verb.Used(verbNr);
                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
        }

        private void btnClear2_Click(object sender, EventArgs e)
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
            if (customTabControl1.ActiveIndex == 1)
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
            //tb.Text = tb.Text.Replace("  ", " ");
            FixText.AdjustSize(tb);
            Db.recentStrings.Add(tb.Text);
            position = Db.recentStrings.Count - 1;
            Words.FreeNeeded(loadNr);
            
        }


        //
        // MenuStrip
        //

        private void lekarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.tabControl1.SelectedIndex = 1;
            help.Show();
        }

        private void hjälpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.tabControl1.SelectedIndex = 0;
            help.Show();
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
                FixText.AdjustSize(presentationWindow.tbxResult);
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
                FixText.AdjustSize(presentationWindow.tbxResult);
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

        

        // 
        // Tillfällig
        //

    }

}



