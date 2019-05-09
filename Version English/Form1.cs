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

            // Cheopy the new Databasefile. If the folder already exists, then only copy file. If it doesn't then create the folder too.  
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer";
            if (!Directory.Exists($"{path}"))
            {
                Directory.CreateDirectory($"{path}");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseEnglish.db3",
                                    $"{path}\\WordsDatabaseEnglish.db3", true);
            }
            else if (Directory.Exists($"{path}")
                    && !File.Exists($"{path}\\WordsDatabaseEnglish.db3"))
            {
                // Sometimes the app gives me an error when an old database log is there after I copied a new database to that folder. The soution is to delete the log. 
                File.Delete($"{path}\\WordsDatabaseEnglish_log.ldf");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseEnglish.db3",
                                    $"{path}\\WordsDatabaseEnglish.db3", true);
            }
            else if (Directory.Exists($"{path}")
                    && File.Exists($"{path}\\WordsDatabaseEnglish.db3"))
            {

            }
            else
            {
                MessageBox.Show($"Databasen could not be copied and might not work correctly. Try reinstalling.");
            }

            // Show the second window at a precise location relative to the main window.
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);

            presentationWindow.Show();

            Db.connectionString = $"Data Source= {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer\\WordsDatabaseEnglish.db3";

            Words.FreeNeeded(1000);
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
            int adjectiveId = Words.adjective.RandomizeId();
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
            int verbNr = Words.verb.RandomizeId();
            int nounNr = Words.noun.RandomizeId();
            int adjectiveNr = Words.adjective.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.noun.Singular(someoneNr))} {Words.verb.SForm(verbNr)}{Words.verb.Preposition(verbNr)}{Words.adjective.Descriptive(adjectiveNr)} {Words.noun.Singular(nounNr)}");

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
            int verbNr = Words.verb.RandomizeId();
            List<string> politiker = new List<string>
            {
                "Democrat", "Liberal", "Conservative", "Republican", "The King",
                "The Queen"
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
            int verbNr = Words.verb.RandomizeId();
            int somethingNr = Words.something.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{Words.jokeName.Name(jokeNameNr)} won the {Words.nobelPrize.Prize(nobelNr)} for {Words.verb.IngForm(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(somethingNr)}");

            Words.jokeName.Used(jokeNameNr);
            Words.nobelPrize.Used(nobelNr);
            Words.verb.Used(verbNr);
            Words.noun.Used(somethingNr);
            EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        //private void btnGenerate6_Click(object sender, EventArgs e)
        //{
        //    presentationWindow.tbxResult.Text = "";

        //    int verbNr = r.Next(0, list.verb.Count);
        //    int someoneNr = r.Next(0, list.someone.Count);

        //    presentationWindow.tbxResult.AppendText($"Remember, always {list.verb[verbNr].BasForm()} your {list.someone[someoneNr].Plural()}");

        //    list.verb.RemoveAt(verbNr);
        //    list.someone.RemoveAt(someoneNr);
        //    Lists.SaveToFile(presentationWindow.tbxResult.Text);
        //    list.LoadNeeded(1);
        //    FixText.AdjustSize(presentationWindow.tbxResult);
        //}

        //private void btnGenerate7_Click(object sender, EventArgs e)
        //{
        //    presentationWindow.tbxResult.Text = "";
        //    int somethingNr = r.Next(0, list.something.Count);
        //    int adjectiveNr = r.Next(0, list.adjective.Count);

        //    presentationWindow.tbxResult.AppendText($"Happiness is {list.adjective[adjectiveNr].Descriptive()} {list.something[somethingNr].Plural()}");

        //    list.something.RemoveAt(somethingNr);
        //    list.adjective.RemoveAt(adjectiveNr);
        //    Lists.SaveToFile(presentationWindow.tbxResult.Text);
        //    list.LoadNeeded(1);
        //    FixText.AdjustSize(presentationWindow.tbxResult);
        //}

        //private void btnGenerate8_Click(object sender, EventArgs e)
        //{
        //    presentationWindow.tbxResult.Text = "";

        //    int slant = r.Next(0, 2);

        //    if (slant == 0)
        //    {
        //        int adjectiveNr = r.Next(0, list.adjective.Count);
        //        int someoneNr = r.Next(0, list.someone.Count);

        //        presentationWindow.tbxResult.AppendText($"Protip, your {list.someone[someoneNr].Plural()} can never be too {list.adjective[adjectiveNr].Descriptive()}");

        //        list.someone.RemoveAt(someoneNr);
        //        list.adjective.RemoveAt(adjectiveNr);
        //        Lists.SaveToFile(presentationWindow.tbxResult.Text);
        //        list.LoadNeeded(1);
        //        FixText.AdjustSize(presentationWindow.tbxResult);
        //    }
        //    else if (slant == 1)
        //    {
        //        int adjectiveNr = r.Next(0, list.adjective.Count);
        //        int somethingNr = r.Next(0, list.something.Count);

        //        presentationWindow.tbxResult.AppendText($"Protip, your {list.something[somethingNr].Plural()} can never be too {list.adjective[adjectiveNr].Descriptive()}");

        //        list.something.RemoveAt(somethingNr);
        //        list.adjective.RemoveAt(adjectiveNr);
        //        Lists.SaveToFile(presentationWindow.tbxResult.Text);
        //        list.LoadNeeded(1);
        //        FixText.AdjustSize(presentationWindow.tbxResult);
        //    }
            
        //}

        public void EndingRitual(int loadNr, TextBox tb, ref int position)
        {
            //tb.Text = tb.Text.Replace("  ", " ");
            FixText.AdjustSize(tb);
            Db.recentStrings.Add(tb.Text);
            position = Db.recentStrings.Count - 1;
            Words.FreeNeeded(loadNr);
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

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
            
        }

        private void btnGenerate9_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int verbNr = Words.verb.RandomizeId();
            int nounNr = Words.noun.RandomizeId();

            presentationWindow.tbxResult.AppendText($"Are you tired of {Words.verb.IngForm(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.Plural(nounNr)}?");

            Words.noun.Used(nounNr);
            Words.verb.Used(verbNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

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

        private void btnClear3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        public static void SaveToFile(string text)
        {
            string text2 = $"{text}.     ";
            StreamWriter sw = new StreamWriter($"OnSteam.txt");

            sw.WriteLine(text2);

            sw.Close();
        }
    }
}
