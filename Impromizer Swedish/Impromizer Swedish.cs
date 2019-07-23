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
using Microsoft.Win32;


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
            Db.connectionString = $"Data Source = {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer\\WordsDatabaseSwedish.db3";
            Db.backupString = $"Data Source = {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer\\BackupSwedish.db3";
            Db.factoryResetString = $"Data Source = {AppDomain.CurrentDomain.BaseDirectory}Databases\\WordsDatabaseSwedish.db3";

            if (!Directory.Exists($"{Common.myDocumentsPath}"))
            {
                Directory.CreateDirectory($"{Common.myDocumentsPath}");

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\WordsDatabaseSwedish.db3",
                                        $"{Common.myDocumentsPath}WordsDatabaseSwedish.db3", true);

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\BackupSwedish.db3",
                                            $"{Common.myDocumentsPath}BackupSwedish.db3", true);

            }

            else if (!File.Exists($"{Common.myDocumentsPath}BackupSwedish.db3") && File.Exists($"{Common.myDocumentsPath}WordsDatabaseSwedish.db3"))
            {
                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\BackupSwedish.db3",
                                            $"{Common.myDocumentsPath}BackupSwedish.db3", true);
            }

            else if (!File.Exists($"{Common.myDocumentsPath}WordsDatabaseSwedish.db3") && File.Exists($"{Common.myDocumentsPath}BackupSwedish.db3"))
            {
                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\WordsDatabaseSwedish.db3",
                                        $"{Common.myDocumentsPath}WordsDatabaseSwedish.db3", true);
            }

            else if (!File.Exists($"{Common.myDocumentsPath}WordsDatabaseSwedish.db3") && !File.Exists($"{Common.myDocumentsPath}BackupSwedish.db3"))
            {
                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\WordsDatabaseSwedish.db3",
                                        $"{Common.myDocumentsPath}WordsDatabaseSwedish.db3", true);

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\BackupSwedish.db3",
                                            $"{Common.myDocumentsPath}BackupSwedish.db3", true);
            }


            // Check existance and version of the Db, copy if newer and give options if modified. 
            if (Db.GetValue("SELECT name FROM sqlite_master WHERE type='table' AND name='TblVersion'", Db.connectionString) == "TblVersion"
                && Convert.ToInt32(Db.GetValue("Select Version FROM TblVersion", Db.connectionString)) < Convert.ToInt32(Db.GetValue("Select Version FROM TblVersion", Db.factoryResetString)) 
                && Convert.ToInt32(Db.GetValue("Select Modified FROM TblVersion", Db.connectionString)) == 1)
            {
                string title = "Fråga";
                string message = "Appen har uppdaterats och den nya databasen innehåller fler ord. Vill du behålla eventuella ändringar i " +
                    "den äldre databasen? Detta inkluderar ord som användaren kan ha raderat, ändrat och/eller lagt till. Om du trycker på 'Yes' " +
                    "kommer den äldre databasen uppdateras med de nya orden, men i övrig förbli som den var. Om du trycker på 'No' kommer " +
                    "alla ändringar förloras och databasen återställas till fabriksinställningarna för den senaste versionen.";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Db.TransferNewWords("TblAdjectives", Db.connectionString, Db.factoryResetString);
                    Db.TransferNewWords("TblJokeNames", Db.connectionString, Db.factoryResetString);
                    Db.TransferNewWords("TblMissions", Db.connectionString, Db.factoryResetString);
                    Db.TransferNewWords("TblNobelPrizes", Db.connectionString, Db.factoryResetString);
                    Db.TransferNewWords("TblSavedResults", Db.connectionString, Db.factoryResetString);
                    Db.TransferNewWords("TblNouns", Db.connectionString, Db.factoryResetString);
                    Db.TransferNewWords("TblStatus", Db.connectionString, Db.factoryResetString);
                    Db.TransferNewWords("TblVerbs", Db.connectionString, Db.factoryResetString);

                    Db.Command($"UPDATE TblVersion SET Version = {Db.GetValue("Select Version FROM TblVersion", Db.factoryResetString)}", Db.connectionString);
                }

                // Vad händer om man gjort ändrinar men tagit bort backup grejen, då går den inte igenom detta. Då får man väl starta om?
                // Eller låt detta vara sin egen if statement
                else
                {
                    File.Delete($"{Common.myDocumentsPath}WordsDatabaseSwedish.db3");
                    System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\WordsDatabaseSwedish.db3",
                                        $"{Common.myDocumentsPath}WordsDatabaseSwedish.db3", true);
                }
                
            }

            else if (Db.GetValue("SELECT name FROM sqlite_master WHERE type='table' AND name='TblVersion'", Db.connectionString) == "TblVersion" 
                    && Convert.ToInt32(Db.GetValue("Select Version FROM TblVersion", Db.connectionString)) >= Convert.ToInt32(Db.GetValue("Select Version FROM TblVersion", Db.factoryResetString)))
            {

            }

            else
            {

                File.Delete($"{Common.myDocumentsPath}WordsDatabaseSwedish.db3");

                System.IO.File.Copy($"{Common.baseDirectoryPath}Databases\\WordsDatabaseSwedish.db3",
                                    $"{Common.myDocumentsPath}WordsDatabaseSwedish.db3", true);
            }

            Words.FreeNeeded(1000);


            // Load settings
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Lime the fruit\\Impromizer");
            string[] array = rk.GetValueNames();
            List<string> participants = new List<string>();

            // Add saved participants to list (Participant 1, Participant 2 etc)
            foreach (string element in array)
            {
                if (element.Contains("Participant"))
                {
                    participants.Add(element);
                }
                        
            }

            // Use that list to add the corresponding names to combobox.   
            foreach (string element in participants)
            {
                cbParticipants.Items.Add(Config.GetRegValue(element, "0"));
            }

            RelationChanged();
            lblParticipants.Text = (cbParticipants.Items.Count < 1 ? "Lägg till delttagare" : $"Lägg till deltagare (Antal: {cbParticipants.Items.Count})");

            cbRelation.SelectedIndex = Convert.ToInt32(Config.GetRegValue("RelationChoice", "0"));
            cbMission.SelectedIndex = Convert.ToInt32(Config.GetRegValue("MissionChoice", "1"));


            //Hide/Show Items exclusive to the full version
            // Add items that are either visible or not depending on version, then loop through them setting
            // them as visible or not visible. 
            List<Control> fullVersionItems = new List<Control>
            {
                btnGenerateRelation, btnGenerateMission, btnGenerateLocation, lblMissionChoice, lblParticipants,
                lblRelationChoice, btnAddParticipant, btnRemoveParticipant, btnhide, btnClearScene, cbParticipants, cbMission, cbRelation,
                groupBox5, groupBox6, groupBox7, groupBox8, btnGenerate, btnUndo, btnCustomClear
            };

            for (int i = 0; i < fullVersionItems.Count; i++)
            {
                fullVersionItems[i].Enabled = Common.fullVersion;
                fullVersionItems[i].Visible = Common.fullVersion;
            }

            inställningarToolStripMenuItem.Enabled = Common.fullVersion;
            inställningarToolStripMenuItem.Visible = Common.fullVersion;
            savedResultsStripMenuItem.Visible = Common.fullVersion;
            savedResultsStripMenuItem.Enabled = Common.fullVersion;
            lblPaidOnly.Visible = !Common.fullVersion;
            lblPaidOnly2.Visible = !Common.fullVersion;
            this.Text = Common.fullVersion ? "Impromizer" : "Impromizer (Free)";

            // Make "TbxResult_TextChanged" subscribe to the "TextChanged" event in the presentationWindow-Form.   
            presentationWindow.tbxResult.TextChanged += new System.EventHandler(this.TbxResult_TextChanged);
        }

        // Activates when text changes in a textbox in the presentationWindow. 
        private void TbxResult_TextChanged(object sender, System.EventArgs e)
        {
            savedResultsStripMenuItem.ForeColor = Color.White;
            if (Db.GetValue($"SELECT Mening FROM TblSavedResults WHERE Mening = '{presentationWindow.tbxResult.Text}'", Db.connectionString) == presentationWindow.tbxResult.Text 
                && presentationWindow.tbxResult.Text != "")
            {
                savedResultsStripMenuItem.ForeColor = Color.Yellow;
            }
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

        private void btnGenerate8_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate8.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate8_MouseUp(object sender, MouseEventArgs e)
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

        private void btnGenerate7_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate7.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate9_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate9.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate9_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate9.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate7_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate7.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate10_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate10.Font = new Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate10_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate10.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate11_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate11.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnGenerate11_MouseUp(object sender, MouseEventArgs e)
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

        private void btnGenerate2_Click(object sender, EventArgs e)
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

        private void btnGenerate11_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int verbNr = Words.verb.RandomizeId(0);

            presentationWindow.tbxResult.Text = $"Du skall {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}dem ";
            presentationWindow.tbxResult.AppendText(Sentences.BuildRelation("du", "", "som är", "", "du är", "", "Presens", false, 0, true, 0, r.Next(0, 2)));

            Words.verb.Used(verbNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate10_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            // Olika starter på meningen som innehåller "dig" eller "dig själv". För att inte det ska vara med två gånger. 
            List<string> with = new List<string>
            {
                "Tillåt dig själv att", "Unna dig att", "Ge dig själv möjligheten att", "Förbered dig på att"
            };

            List<string> without = new List<string>
            {
                "Våga", "Ta chansen att", "Var modig nog att", "Var stark nog att", "Ha självförtroende nog att"
            };

            presentationWindow.tbxResult.Text = Sentences.BuildRelation($"{without[r.Next(0, without.Count)]}", "dig själv", $"{with[r.Next(0, with.Count)]} vara", "",
                                             $"{without[r.Next(0, without.Count)]} vara", "dig själv", "Infinitiv", true, 0, true, 0, r.Next(0, 2));
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate7_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int someoneNr = Words.someone.RandomizeId();

            // Skapa array med början av mening och slutet av mening som sedan ska in i BuildRelation.  
            string[,] relationBits = new string[3, 2] 
            {
                {$"Gör dig själv lycklig genom att", $"{Words.someone.Plural(someoneNr)}"},
                {$"Allt du behöver för lycka är{Words.someone.EnEllerEtt(someoneNr)}{Words.someone.SingularObest(someoneNr)} som är", ""},
                {$"Nyckeln till lycka är att vara", $"{Words.someone.Plural(someoneNr)}"}
            };

            presentationWindow.tbxResult.Text = Sentences.BuildRelation(relationBits[0,0], relationBits[0, 1], relationBits[1, 0], relationBits[1, 1], relationBits[2, 0], relationBits[2, 1],
                                    "Infinitiv", true, someoneNr, true, 0, r.Next(0, 2));
          

            Words.someone.Used(someoneNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate8_Click(object sender, EventArgs e)
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
        
        // Create needed variables
        bool relationPressed = false;
        int pressAmount = 0;
        List<string> relationList = new List<string>();

        private void CbParticipants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbParticipants.Items.Count == 1)
            {
                btnGenerateRelation.Text = $"Relation \r\n (Visa {cbParticipants.Items[0]})";
            }
        }

        private void BtnAddParticipant_Click(object sender, EventArgs e)
        {
            cbParticipants.BackColor = Color.White;
            cbParticipants.Items.Add(cbParticipants.Text);
            lblParticipants.Text = (cbParticipants.Items.Count < 1 ? "Lägg till delttagare" : $"Lägg till deltagare (Antal: {cbParticipants.Items.Count})");
            RelationChanged();
            cbParticipants.Text = "";
            cbParticipants.Focus();
            SaveParticipants();
        }

        void RelationChanged()
        {
            relationList.Clear();
            relationPressed = false;
            pressAmount = 0;
            btnGenerateRelation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);

            if (cbParticipants.Items.Count == 0)
            {
                btnGenerateRelation.Text = "Relation";
            }

            // If relationtype is emotions show one name on button. 
            else if (cbRelation.SelectedIndex == 0 || (cbRelation.SelectedIndex == 1 && cbParticipants.Items.Count == 1))
            {
                btnGenerateRelation.Text = $"Relation \r\n (Visa {cbParticipants.Items[0]})";
            }

            // If relationtype is status show two names. 
            else if (cbRelation.SelectedIndex == 1 && cbParticipants.Items.Count > 1)
            {
                btnGenerateRelation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnGenerateRelation.Text = $"Relation \r\n (Visa {cbParticipants.Items[0]} \r\n och {cbParticipants.Items[1]})";
            }
        }

        private void BtnRemoveParticipant_Click(object sender, EventArgs e)
        {
            cbParticipants.Items.Remove(cbParticipants.Text);

            lblParticipants.Text = (cbParticipants.Items.Count < 1 ? "Lägg till delttagare" : $"Lägg till deltagare (Antal: {cbParticipants.Items.Count})");
            RelationChanged();
            SaveParticipants();
            if (cbParticipants.Items.Count > 0)
            {
                cbParticipants.SelectedIndex = 0;
            }
            else
            {
                cbParticipants.Text = "Skriv in namn...";
            }
        }

        private void CbRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            RelationChanged();
            Config.SaveRegValue("RelationChoice", $"{cbRelation.SelectedIndex}");
        }

        private void CbMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            relationList.Clear();
            Config.SaveRegValue("MissionChoice", $"{cbMission.SelectedIndex}");
        }

        private void BtnClearScene_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            RelationChanged();
        }

        private void Btnhide_Click_1(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }

        private void btnGenerateRelation_Click(object sender, EventArgs e)
        {
            // Reset button padding
            btnGenerateRelation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);

            switch (cbRelation.SelectedIndex)
            {
                // Case känslorelationer
                case 0:

                    int slant = r.Next(0, 2);
                    StringBuilder builder = new StringBuilder();

                    // If no participants are entered, prompt the user to do so. 
                    if (cbParticipants.Items.Count < 1)
                    {
                        cbParticipants.BackColor = Color.Pink;
                        cbParticipants.Text = "Skriv in deltagare...";
                    }

                    // If relationbutton has been pressed then show the relationships of the next person in
                    // the list that has been created the first press. 
                    else if (relationPressed && pressAmount < relationList.Count)
                    {
                        presentationWindow.tbxResult.Text = "";
                        presentationWindow.tbxResult.Text = relationList[pressAmount];
                        pressAmount++;
                        EndingRitual(3, presentationWindow.tbxResult, ref position);
                        btnGenerateRelation.Text = (pressAmount > relationList.Count - 1 ? "Relation \r\n (Tryck på rensa)" : $"Relation \r\n (Visa {cbParticipants.Items[pressAmount].ToString()})");
                    }

                    // If the relationshipbutton has not been pressed then create relationships for each
                    // participant to all other participants. 
                    else if (!relationPressed)
                    {
                        presentationWindow.tbxResult.Text = "";

                        // Go through all the participants
                        for (int i = 0; i < cbParticipants.Items.Count; i++)
                        {
                            slant = r.Next(0, 2);

                            // First participants refers to the person with the feelings to the other people. 
                            string firstParticipant = cbParticipants.Items[i].ToString();
                            builder.Append($"{firstParticipant} ");
                            int k = i;

                            // Loop the same number of times that there are participants (- the first person) 
                            // so that the first person gets a relationship with the rest of the participants. 
                            // Then when it starts again the second person gets a relationship with the rest and so on. 
                            for (int j = cbParticipants.Items.Count == 1 ? -1 : 0; j < cbParticipants.Items.Count - 1; j++)
                            {
                                // The j-loop goes through all other participants and the k variable 
                                // sees to that the j-loop can start at the second to last item in the list of 
                                // participants and then start from the beginning of that list but still go through
                                // the required amount of participants. 
                                k = (k == cbParticipants.Items.Count - 1 ? k = 0 : k = k + 1);

                                // Randomize either adjective relationship or verb relationship. 

                                string[,] relationBits = new string[3, 2]
                                {
                                    {"", $"{(cbParticipants.Items.Count == 1 ? "sig själv" : $"{cbParticipants.Items[k]}")}"},
                                    {$"tycker {(cbParticipants.Items.Count == 1 ? "sig vara" : $"att {cbParticipants.Items[k]} är")}", ""},
                                    {"är", $"{(cbParticipants.Items.Count == 1 ? "sig själv" : $"{cbParticipants.Items[k]}")}"}
                                };

                                builder.Append(Sentences.BuildRelation(relationBits[0, 0], relationBits[0, 1], relationBits[1, 0], relationBits[1, 1], relationBits[2, 0], relationBits[2, 1],
                                    "Presens", true, 0, true, 0, r.Next(0,2)));
                                builder.Append($"{(j == cbParticipants.Items.Count - 3 ? " och " : ", ")}");

                                slant = r.Next(0, 2);
                                Words.FreeNeeded(2);
                            }

                            // Clean up spaces and extra symbols
                            builder.Remove(builder.Length - 2, 2);
                            builder.Replace("  ", " ");
                            builder.Replace(" ,", ",");

                            relationList.Add(builder.ToString());
                            presentationWindow.tbxResult.Text = $"{relationList[0]}";
                            builder.Clear();
                        }
                        relationPressed = true;
                        pressAmount++;
                        EndingRitual(2, presentationWindow.tbxResult, ref position);
                        btnGenerateRelation.Text = $"{(cbParticipants.Items.Count == 1 ? "Relation \r\n (Tryck på rensa)" : $"Relation \r\n (Visa {cbParticipants.Items[pressAmount]}")}";
                    }
                    else
                    {
                    }

                    break;

                // Case Status
                case 1:

                    if (cbParticipants.Items.Count < 1)
                    {
                        cbParticipants.BackColor = Color.Pink;
                        cbParticipants.Text = "Skriv in deltagare...";
                    }

                    else if (cbParticipants.Items.Count > 0 && pressAmount < cbParticipants.Items.Count - 1 || pressAmount == 0)
                    {
                        int statusId = Words.status.RandomizeId();

                        // Show the statusrelationship pf the next pair.
                        presentationWindow.tbxResult.Text = $"{cbParticipants.Items[pressAmount]} är {Words.status.LowStatus(statusId)} och{(cbParticipants.Items.Count == 1 ? " " : $" {cbParticipants.Items[pressAmount + 1]} ")}{Words.status.HighStatus(statusId)}";

                        Words.status.Used(statusId);

                        pressAmount++;

                        // If there are more or equal to two participants left then write out in the buttontext who are up next. 
                        if (pressAmount <= cbParticipants.Items.Count - 2)
                        {
                            btnGenerateRelation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            btnGenerateRelation.Text = $"Relation \r\n (Visa {cbParticipants.Items[pressAmount]} \r\n och {cbParticipants.Items[pressAmount + 1]})";
                        }
                        else
                        {
                            btnGenerateRelation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
                            btnGenerateRelation.Text = $"Relation \r\n (Tryck på rensa)";
                        }
                        Words.FreeNeeded(2);
                        EndingRitual(2, presentationWindow.tbxResult, ref position);
                    }

                    else
                    {

                    }

                    break;
            }
        }

        private void btnGenerateMission_Click(object sender, EventArgs e)
        {
            switch (cbMission.SelectedIndex)
            {
                // Absurd missions
                case 0:

                    presentationWindow.tbxResult.Text = "";
                    int nounNr = Words.noun.RandomizeId();
                    int verbNr = Words.verb.RandomizeId(nounNr);

                    presentationWindow.tbxResult.Text = $"Ni ska {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.EnEllerEtt(nounNr)}{Words.noun.SingularObest(nounNr)}";

                    Words.verb.Used(verbNr);
                    Words.noun.Used(nounNr);
                    EndingRitual(3, presentationWindow.tbxResult, ref position);

                    break;

                // Case scenen slutar med att...
                case 1:

                    presentationWindow.tbxResult.Text = "";
                    verbNr = Words.verb.RandomizeId();

                    if (cbParticipants.Items.Count < 1)
                    {
                        cbParticipants.BackColor = Color.Pink;
                        cbParticipants.Text = "Skriv in deltagare...";
                    }

                    else
                    {
                        cbParticipants.SelectedIndex = r.Next(0, cbParticipants.Items.Count);
                        string name1 = cbParticipants.Text;
                        string name2 = cbParticipants.Text;
                        int slant = r.Next(0,2);

                        // Sees to that the same name does not show up twice. 
                        while (name1 == name2)
                        {
                            cbParticipants.SelectedIndex = r.Next(0, cbParticipants.Items.Count);
                            name2 = cbParticipants.Items.Count == 1 ? "sig själv" : cbParticipants.Text;
                        }

                        switch (slant)
                        {
                            case 0:
                                presentationWindow.tbxResult.Text = $"Scenen slutar med att {name1} {Words.verb.Presens(verbNr)}{Words.verb.Preposition(verbNr)}{name2}";
                                break;

                            case 1:
                                string[,] relationBits = new string[3, 2]
                              {
                                    {"", ""},
                                    {$"Scenen slutar med att {name1} tycker {(cbParticipants.Items.Count == 1 ? "sig vara" : $"att {name2} är")}", ""},
                                    {$"Scenen slutar med att {name1} är", $"{name2}"}
                              };

                                presentationWindow.tbxResult.Text = Sentences.BuildRelation(relationBits[0, 0], relationBits[0, 1], relationBits[1, 0], relationBits[1, 1], relationBits[2, 0], relationBits[2, 1],
                                    "Presens", true, 0, true, 0, 1);
                                break;
                        }
                        
                    }


                    Words.verb.Used(verbNr);
                    EndingRitual(3, presentationWindow.tbxResult, ref position);

                    break;

                // Case förskrivet uppdrag
                case 2:
                    int MId = Words.uppdrag.RandomizeId();

                    presentationWindow.tbxResult.Text = $"{Words.uppdrag.Beskrivning(MId)}";

                    Words.uppdrag.Used(MId);
                    EndingRitual(1, presentationWindow.tbxResult, ref position);

                    break;
            }
        }

        private void btnGenerateLocation_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int locationNr = Words.location.RandomizeId();
            presentationWindow.tbxResult.Text = $"Ni är{Words.location.Preposition(locationNr)}{Words.location.SingularBest(locationNr)}";

            Words.location.Used(locationNr);
            EndingRitual(3, presentationWindow.tbxResult, ref position);
        }

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
            switch (customTabControl1.ActiveIndex)
            {
                case 2:
                    customTabControl1.Size = new Size(614, 332);
                    this.AcceptButton = btnAddParticipant;
                    break;

                case 4:
                    customTabControl1.Size = new Size(614, 135);
                    break;

                default:
                    customTabControl1.Size = new Size(614, 332);
                    break;
            }
            if (customTabControl1.ActiveIndex == 4)
            {
                
            }
            else
            {
                customTabControl1.Size = new Size(614, 332);
            }
        }

        public void EndingRitual(int loadNr, TextBox tb, ref int position)
        {
            presentationWindow.tbxResult.Text = tb.Text.Replace("  ", " ");
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
            Config.ResetRegValue();

            Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}Language Form.exe");
            Environment.Exit(0);
        }

        private void InställningarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        
        // 
        // Tab: Egen mening
        //

        // Needed variables
        bool nounsAdded = false;
        bool verbsAdded = false;
        bool adjectivesAdded = false;

        // Events

        // Add different items, depending on the current choices. 
        private void cbForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Needed to remove for example pink color after wrong choice. 
            cbConnect.Items.Clear();
            cbConnect.Enabled = false;
            cbConnect.Text = "";
            cbForms.BackColor = Color.White;
            btnAddWord.ForeColor = Color.Gray;

            if ((cbWords.Text == "Någon" || cbWords.Text == "Något" || cbWords.Text == "Plats")
                    && (cbForms.Text == "En eller Ett" || cbForms.Text == "Din eller Ditt" || cbForms.Text == "Preposition"))
            {
                cbConnect.Text = "Välj...";
                cbConnect.Enabled = true;
                if (nounsAdded == true)
                {
                    cbConnect.Items.Add("Syfta till tidigare substantiv");
                }
                cbConnect.Items.Add("Syfta till nästa substantiv");
            }

            else if (cbWords.Text == "Verb" && cbForms.Text == "Preposition")
            {
                cbConnect.Text = "Välj...";
                cbConnect.Enabled = true;

                if (verbsAdded == true)
                {

                    cbConnect.Items.Add("Syfta till tidigare verb");
                }
                cbConnect.Items.Add("Syfta till nästa verb");
            }

            //else if (cbWords.Text == "Verb" && cbForms.Text != "Preposition")
            //{
            //    cbConnect.Text = "Välj...";
            //    cbConnect.Enabled = true;

            //    if (nounsAdded == true)
            //    {
            //        cbConnect.Items.Add("Syfta till tidigare substantiv");
            //    }

            //    cbConnect.Items.Add("Syfta inte");
            //    cbConnect.Items.Add("Syfta till nästa substantiv");
            //    cbConnect.SelectedIndex = 0;
            //}

            else if (cbWords.Text == "Adjektiv" && cbForms.Text == "Preposition")
            {
                cbConnect.Text = "Välj...";
                cbConnect.Enabled = true;

                if (adjectivesAdded == true)
                {

                    cbConnect.Items.Add("Syfta till tidigare adjektiv");
                }
                cbConnect.Items.Add("Syfta till nästa adjektiv");
            }

            else if (cbWords.Text == "Adjektiv" && cbForms.Text == "Automatisk")
            {
                cbConnect.Text = "Välj...";
                cbConnect.Enabled = true;

                if (nounsAdded == true)
                {

                    cbConnect.Items.Add("Syfta till tidigare substantiv");

                }

                //if (cbForms.Text != "Automatisk")
                //{
                //    cbConnect.Items.Add("Syfta inte");
                //}

                cbConnect.Items.Add("Syfta till nästa substantiv");
                cbConnect.SelectedIndex = 0;
            }

            if (cbWords.Text != "Välj..." && cbForms.Text != "Välj..." && cbConnect.Text != "Välj...")
            {
                btnAddWord.ForeColor = Color.White;
            }

            
        }

        private void cbConnect_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddWord.ForeColor = Color.Gray;

            cbConnect.BackColor = Color.White;

            if (cbWords.Text != "Välj..." && cbForms.Text != "Välj..." && cbConnect.Text != "Välj...")
            {
                btnAddWord.ForeColor = Color.White;
            }


        }

        void SaveParticipants()
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Lime the fruit\\Impromizer");

            // Create a list of all value names in the registry for this app. 
            string[] array = rk.GetValueNames();

            // Delete all
            foreach (string element in array)
            {
                if (element.Contains("Participant"))
                {
                    Config.DeleteRegValue(element);
                }
            }

            // Save existing items in combobox. 
            for (int i = 0; i < cbParticipants.Items.Count; i++)
            {

                Config.SaveRegValue($"Participant {i}", $"{cbParticipants.Items[i]}");
            }
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            // If the used missed making a choice, mark what they missed in pink. 
            if (cbWords.Text == "Välj...")
            {
                cbWords.BackColor = Color.Pink;
            }
            else if (cbForms.Text == "Välj...")
            {
                cbForms.BackColor = Color.Pink;
            }
            else if (cbConnect.Text == "Välj...")
            {
                cbConnect.BackColor = Color.Pink;
            }
            else
            {
                // If all is clear, then add to ChoiceList. 
                Custom newItem = new Custom(cbWords.Text, cbForms.Text, cbConnect.Text, 0, 0, Custom.choicesList.Count);
                Custom.choicesList.Add(newItem);

                
            }

            // Write out all choices made in the "Added wors/numbers" textbox
            tbxAdded.Text = "";
            foreach (Custom element in Custom.choicesList)
            {
                if (element.WordChoice == "Nr" || element.WordChoice == "Skämtnamn" || element.CustomString == true)
                {
                    tbxAdded.AppendText($"{(Custom.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice}");
                }
                else
                {
                    tbxAdded.AppendText($"{(Custom.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice} ({element.FormChoice})");
                }
            }

            // Keep tabs on whether Nouns and verbs have been added. 
            if (cbWords.Text == "Någon" || cbWords.Text == "Något" || cbWords.Text == "Plats")
            {
                nounsAdded = true;
            }
            else if (cbWords.Text == "Verb")
            {
                verbsAdded = true;
            }
            else if (cbWords.Text == "Adjektiv")
            {
                adjectivesAdded = true;
            }

            if ((cbWords.Text == "Verb" || cbWords.Text == "Adjektiv") && (cbForms.Text != "Välj..." && cbConnect.Text != "Välj..."))
            { 
                    cbForms.SelectedIndex = 4;
                    cbConnect.SelectedIndex = 0;

            }
        }

        private void btnAddNr_Click(object sender, EventArgs e)
        {
            Custom newcombo = new Custom("Nr", nupFrom.Value, nupTo.Value);
            Custom.choicesList.Add(newcombo);

            tbxAdded.Text = "";
            foreach (Custom element in Custom.choicesList)
            {
                if (element.WordChoice == "Nr" || element.WordChoice == "Skämtnamn" || element.CustomString == true)
                {
                    tbxAdded.AppendText($"{(Custom.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice}");
                }
                else
                {
                    tbxAdded.AppendText($"{(Custom.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice} ({element.FormChoice})");
                }
            }
        }

        private void btnAddCustom_Click(object sender, EventArgs e)
        {
            if (tbxCustom.Text == "")
            {
                tbxCustom.BackColor = Color.Pink;
            }
            else
            {
                Custom newcombo = new Custom(tbxCustom.Text.Trim(), true);
                Custom.choicesList.Add(newcombo);
            }

            tbxAdded.Text = "";
            foreach (Custom element in Custom.choicesList)
            {
                if (element.WordChoice == "Nr" || element.WordChoice == "Skämtnamn" || element.CustomString == true)
                {
                    tbxAdded.AppendText($"{(Custom.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice}");
                }
                else
                {
                    tbxAdded.AppendText($"{(Custom.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice} ({element.FormChoice})");
                }
            }
        }


        private void nupFrom_ValueChanged(object sender, EventArgs e)
        {
            // "FromValue" should always be under "ToValue"
            if (nupFrom.Value > nupTo.Value - 1) nupFrom.Value = nupTo.Value - 1;
        }


        private void nupTo_ValueChanged(object sender, EventArgs e)
        {
            if (nupFrom.Value > nupTo.Value - 1) nupTo.Value = nupFrom.Value + 1;
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";


            // Update all relevant objects on the choicelist with RandomId. 
            foreach (Custom element in Custom.choicesList)
            {
                if (element.WordChoice == "Någon" && (element.FormChoice != "En eller Ett"
                    || element.FormChoice != "Din eller Ditt" || element.FormChoice != "Preposition"))
                {
                    // Add randomId to the Id-variable in the current instance.
                    // Then set that word to used and reload if needed. 
                    element.Id = Words.someone.RandomizeId();
                    Words.noun.Used(element.Id);
                    Words.FreeNeeded(1);
                }

                else if (element.WordChoice == "Något" && (element.FormChoice != "En eller Ett"
                        && element.FormChoice != "Din eller Ditt" && element.FormChoice != "Preposition"))
                {
                    element.Id = Words.something.RandomizeId();
                    Words.noun.Used(element.Id);
                    Words.FreeNeeded(1);
                }

                else if (element.WordChoice == "Plats" && (element.FormChoice != "En eller Ett"
                        && element.FormChoice != "Din eller Ditt" && element.FormChoice != "Preposition"))
                {
                    element.Id = Words.location.RandomizeId();
                    Words.noun.Used(element.Id);
                    Words.FreeNeeded(1);
                }

                else if (element.WordChoice == "Adjektiv" && element.FormChoice != "Preposition")
                {
                    element.Id = Words.adjective.RandomizeId();
                    Words.adjective.Used(element.Id);
                    Words.FreeNeeded(1);
                }

                else if (element.WordChoice == "Verb" && element.FormChoice != "Preposition")
                {
                    element.Id = Words.verb.RandomizeId();
                    Words.verb.Used(element.Id);
                    Words.FreeNeeded(1);
                }

                else if (element.WordChoice == "Skämtnamn")
                {
                    element.Id = Words.jokeName.RandomizeId();
                    Words.jokeName.Used(element.Id);
                    Words.FreeNeeded(1);
                }

                else { }
            }

            foreach (Custom element in Custom.choicesList)
            {
                if (element.WordChoice == "Adjektiv" && element.FormChoice != "Preposition" && element.ConnectionChoice == "Syfta till nästa substantiv")
                {
                    

                    for (int i = element.PositionNr; i < Custom.choicesList.Count; i++)
                    {
                        if (Custom.choicesList[i].WordChoice == "Någon" || Custom.choicesList[i].WordChoice == "Något" || Custom.choicesList[i].WordChoice == "Plats")
                        {
                            element.Id = Words.adjective.RandomizeId(Custom.choicesList[i].Id);
                            Words.adjective.Used(element.Id);
                            Words.FreeNeeded(1);
                            break;
                        }
                    }
                }

                else if (element.WordChoice == "Adjektiv" && element.FormChoice != "Preposition" && element.ConnectionChoice == "Syfta till tidigare substantiv")
                {

                    for (int i = element.PositionNr; i < Custom.choicesList.Count; i--)
                    {
                        if (Custom.choicesList[i].WordChoice == "Någon" || Custom.choicesList[i].WordChoice == "Något" || Custom.choicesList[i].WordChoice == "Plats")
                        {
                            element.Id = Words.adjective.RandomizeId(Custom.choicesList[i].Id);
                            Words.adjective.Used(element.Id);
                            Words.FreeNeeded(1);
                            break;
                        }
                    }
                }

                else if (element.WordChoice == "Verb" && element.FormChoice != "Preposition" && element.ConnectionChoice == "Syfta till nästa substantiv")
                {


                    for (int i = element.PositionNr; i < Custom.choicesList.Count; i++)
                    {
                        if (Custom.choicesList[i].WordChoice == "Någon" || Custom.choicesList[i].WordChoice == "Något" || Custom.choicesList[i].WordChoice == "Plats")
                        {
                            element.Id = Words.verb.RandomizeId(Custom.choicesList[i].Id);
                            Words.verb.Used(element.Id);
                            Words.FreeNeeded(1);
                            break;
                        }
                    }
                }

                else if (element.WordChoice == "Verb" && element.FormChoice != "Preposition" && element.ConnectionChoice == "Syfta till tidigare substantiv")
                {


                    for (int i = element.PositionNr; i < Custom.choicesList.Count; i--)
                    {
                        if (Custom.choicesList[i].WordChoice == "Någon" || Custom.choicesList[i].WordChoice == "Något" || Custom.choicesList[i].WordChoice == "Plats")
                        {
                            element.Id = Words.verb.RandomizeId(Custom.choicesList[i].Id);
                            Words.verb.Used(element.Id);
                            Words.FreeNeeded(1);
                            break;
                        }
                    }
                }


            }

            // When the RanomizedId has been added, then figure out which of them 
            // the below should be connected to.
            foreach (Custom element in Custom.choicesList)
            {
                if (element.WordChoice == "Verb" && element.FormChoice == "Preposition" && element.ConnectionChoice == "Syfta till nästa verb")
                {
                    // Go from where the current item is in the choicesList and move up until it 
                    // reaches the next verb. 
                    for (int i = element.PositionNr; i < Custom.choicesList.Count; i++)
                    {
                        if (Custom.choicesList[i].WordChoice == "Verb" && Custom.choicesList[i].FormChoice != "Preposition")
                        {
                            // Insert the position of this verb into the current instance. 
                            element.ConnectionPosition = i;
                            break;
                        }
                    }
                }

                else if (element.WordChoice == "Verb" && element.FormChoice == "Preposition" && element.ConnectionChoice == "Syfta till tidigare verb")
                {
                    // Here we go down instead of up. 
                    for (int i = element.PositionNr; i >= 0; i--)
                    {
                        if (Custom.choicesList[i].WordChoice == "Verb" && Custom.choicesList[i].FormChoice != "Preposition")
                        {
                            element.ConnectionPosition = i;
                            break;
                        }
                    }
                }

                else if (element.ConnectionChoice == "Syfta till nästa substantiv"
                            && (element.WordChoice == "Något" || element.WordChoice == "Någon" || element.WordChoice == "Plats")
                                && (element.FormChoice == "En eller Ett" || element.FormChoice == "Din eller Ditt"
                                || element.FormChoice == "Preposition")
                            || (element.WordChoice == "Adjektiv" && element.FormChoice == "Automatisk" && element.ConnectionChoice == "Syfta till nästa substantiv"))
                {
                    for (int i = element.PositionNr; i < Custom.choicesList.Count; i++)
                    {
                        if (!nounsAdded)
                        {
                            MessageBox.Show("Adjektivet syftar inte till något substantiv. Meningen är kanske inte korrekt.");
                        }
                        else if (
                            (Custom.choicesList[i].WordChoice == "Någon" || Custom.choicesList[i].WordChoice == "Något" || Custom.choicesList[i].WordChoice == "Plats")
                                && (Custom.choicesList[i].FormChoice != "En eller Ett" && Custom.choicesList[i].FormChoice != "Preposition"
                                 && Custom.choicesList[i].FormChoice != "Din eller Ditt" && Custom.choicesList[i].FormChoice != "Plats")
                                 || (Custom.choicesList[i].WordChoice == "Något" && Custom.choicesList[i].FormChoice == "Plats"))
                        {
                            element.ConnectionPosition = i;
                            break;
                        }
                    }
                }

                else if (element.ConnectionChoice == "Syfta till tidigare substantiv"
                            && (element.WordChoice == "Något" || element.WordChoice == "Någon" || element.WordChoice == "Plats")
                                && (element.FormChoice == "En eller Ett" || element.FormChoice == "Din eller Ditt"
                                || element.FormChoice == "Preposition")
                        || (element.WordChoice == "Adjektiv" && element.FormChoice == "Automatisk" && element.ConnectionChoice == "Syfta till tidigare substantiv"))
                {

                    for (int i = element.PositionNr; i >= 0; i--)
                    {
                        if (!nounsAdded)
                        {
                            MessageBox.Show("Adjektivet syftar inte till något substantiv. Meningen är kanske inte korrekt.");
                        }
                        else if (
                            (Custom.choicesList[i].WordChoice == "Någon" || Custom.choicesList[i].WordChoice == "Något" || Custom.choicesList[i].WordChoice == "Plats")
                                && (Custom.choicesList[i].FormChoice != "En eller Ett" && Custom.choicesList[i].FormChoice != "Preposition"
                                 && Custom.choicesList[i].FormChoice != "Din eller Ditt" && Custom.choicesList[i].FormChoice != "Plats")
                                 || (Custom.choicesList[i].WordChoice == "Något" && Custom.choicesList[i].FormChoice == "Plats"))
                        {
                            element.ConnectionPosition = i;
                            break;
                        }
                    }
                }

                if (element.WordChoice == "Adjektiv" && element.FormChoice == "Preposition" && element.ConnectionChoice == "Syfta till nästa adjektiv")
                {
                    for (int i = element.PositionNr; i < Custom.choicesList.Count; i++)
                    {
                        if (Custom.choicesList[i].WordChoice == "Adjektiv" && Custom.choicesList[i].FormChoice != "Preposition")
                        {
                            element.ConnectionPosition = i;
                            break;
                        }
                    }
                }

                else if (element.WordChoice == "Adjektiv" && element.FormChoice == "Preposition" && element.ConnectionChoice == "Syfta till tidigare adjektiv")
                {
                    for (int i = element.PositionNr; i >= 0; i--)
                    {
                        if (Custom.choicesList[i].WordChoice == "Adjektiv" && Custom.choicesList[i].FormChoice != "Preposition")
                        {
                            element.ConnectionPosition = i;
                            break;
                        }
                    }
                }

                else { }
            }

            // After RandomIds have been added and we know what they should be connected to...
            // ... it's time to write them out in the correct order. 
            foreach (Custom element in Custom.choicesList)
            {
                try
                {
                    if (element.FormChoice == "En eller Ett")
                    {
                        int nr = Custom.choicesList[element.ConnectionPosition].Id;
                        presentationWindow.tbxResult.AppendText($"{Words.noun.EnEllerEtt(nr)} ");
                    }
                }
                catch
                {
                    MessageBox.Show("En/Ett försöker syfta till ett substantiv som inte finns. Försök igen!");
                }

                if (element.WordChoice == "Adjektiv")
                {
                    try
                    {
                        if (element.FormChoice == "N-genus")
                        {
                            presentationWindow.tbxResult.AppendText($"{Words.adjective.NGenus(element.Id)} ");
                        }

                        else if (element.FormChoice == "T-genus")
                        {
                            presentationWindow.tbxResult.AppendText($"{Words.adjective.TGenus(element.Id)} ");
                        }

                        else if (element.FormChoice == "Plural")
                        {
                            presentationWindow.tbxResult.AppendText($"{Words.adjective.Plural(element.Id)} ");
                        }

                        else if (element.FormChoice == "Automatisk")
                        {
                            // Take the Id of the position in choiceList that we earlier
                            // decided that the current adjective should be connected to. 
                            // And get the Id of that Noun. Then set that to nounId because
                            // that's easier to read. 
                            int nounId = Custom.choicesList[element.ConnectionPosition].Id;

                            if (Custom.choicesList[element.ConnectionPosition].FormChoice == "Singular obestämd" || Custom.choicesList[element.ConnectionPosition].FormChoice == "Singular bestämd")
                            {
                                // Write it out. element.Id is the current adjective ID Nr. 
                                presentationWindow.tbxResult.AppendText($"{Words.adjective.Automatic(element.Id, nounId, true)} ");
                            }
                            else if (Custom.choicesList[element.ConnectionPosition].FormChoice == "Plural")
                            {
                                presentationWindow.tbxResult.AppendText($"{Words.adjective.Automatic(element.Id, nounId, false)} ");
                            }
                        }

                        else if (element.FormChoice == "Preposition")
                        {
                            int adjectiveId = Custom.choicesList[element.ConnectionPosition].Id;
                            presentationWindow.tbxResult.AppendText($"{Words.adjective.Preposition(adjectiveId)}");
                        }
                        // Tar bort adjektivet så det inte kan användas sen igen. Det skapar fel Nej det är fortfarande problem
                        // de andra har ingen used, varför?
                        // Bara randomize id tar hänsyn till used. 

                        //Words.adjective.Used(element.Id);
                    }
                    catch
                    {
                        MessageBox.Show("Ett Adjektiv försöker syfta till ett substantiv som inte finns. Försök igen!");
                    }
                }

                else if ((element.WordChoice == "Något" || element.WordChoice == "Någon" || element.WordChoice == "Plats") && element.FormChoice == "Singular obestämd")
                {
                    presentationWindow.tbxResult.AppendText($"{Words.noun.SingularObest(element.Id)} ");
                }

                else if ((element.WordChoice == "Något" || element.WordChoice == "Någon" || element.WordChoice == "Plats") && element.FormChoice == "Singular bestämd")
                {
                    presentationWindow.tbxResult.AppendText($"{Words.noun.SingularBest(element.Id)} ");
                }

                else if ((element.WordChoice == "Något" || element.WordChoice == "Någon" || element.WordChoice == "Plats") && element.FormChoice == "Plural")
                {
                    presentationWindow.tbxResult.AppendText($"{Words.noun.Plural(element.Id)} ");
                }

                else if ((element.WordChoice == "Något" || element.WordChoice == "Någon" || element.WordChoice == "Plats") && element.FormChoice == "Preposition")
                {
                    int nounId = Custom.choicesList[element.ConnectionPosition].Id;
                    presentationWindow.tbxResult.AppendText($"{Words.noun.Preposition(nounId)}");
                }

                else if (element.WordChoice == "Skämtnamn")
                {
                    presentationWindow.tbxResult.AppendText($"{Words.jokeName.Name(element.Id)} ");
                }

                else if (element.WordChoice == "Verb")
                {
                    if (element.FormChoice == "Infinitiv")
                    {
                        presentationWindow.tbxResult.AppendText($"{Words.verb.Infinitiv(element.Id)} ");
                    }
                    else if (element.FormChoice == "Presens")
                    {
                        presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(element.Id)} ");
                    }
                    else if (element.FormChoice == "Uppmaning")
                    {
                        presentationWindow.tbxResult.AppendText($"{Words.verb.Uppmaning(element.Id)} ");
                    }
                    else if (element.FormChoice == "Perfekt")
                    {
                        presentationWindow.tbxResult.AppendText($"{Words.verb.Perfekt(element.Id)} ");
                    }
                    else if (element.FormChoice == "Preposition")
                    {
                        int verbId = Custom.choicesList[element.ConnectionPosition].Id;
                        presentationWindow.tbxResult.AppendText($"{Words.verb.Preposition(verbId)}");
                    }
                }

                else if (element.CustomString)
                {
                    presentationWindow.tbxResult.AppendText($"{element.WordChoice} ");
                }

                else if (element.WordChoice == "Nr")
                {
                    // Randomize a number between set "FromValue" and "ToValue". 
                    // ToValue is +1 because the Randomizer object demands (From and including) - (To but not including).
                    // So it needs to be one over set ToValue. 
                    int rNr = r.Next(Convert.ToInt32(element.FromValue), Convert.ToInt32(element.ToValue + 1));
                    presentationWindow.tbxResult.AppendText($"{Convert.ToString(rNr)} ");
                }
            }

            string toUpper = Common.FirstLetterUpper(presentationWindow.tbxResult.Text);
            // Sometimes there's an extra space. This removes that. 
            toUpper = toUpper.Replace("  ", " ");
            presentationWindow.tbxResult.Text = toUpper;
            EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        private void btnCustomClear_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            tbxCustom.Text = "";
            tbxAdded.Text = "";
            Custom.choicesList.Clear();
            nounsAdded = false;
            verbsAdded = false;
            adjectivesAdded = false;
            cbForms.Text = "Välj...";
            cbConnect.Enabled = false;
            cbConnect.Text = "";
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (Custom.choicesList.Count < 1)
            {

            }
            else
            {
                Custom.choicesList.RemoveAt(Custom.choicesList.Count - 1);
                tbxAdded.Text = "";
                foreach (Custom element in Custom.choicesList)
                {
                    if (element.WordChoice == "Nr" || element.WordChoice == "Skämtnamn" || element.CustomString == true)
                    {
                        tbxAdded.AppendText($"{(Custom.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice}");
                    }
                    else
                    {
                        tbxAdded.AppendText($"{(Custom.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice} ({element.FormChoice})");
                    }
                }
            }
        }

        private void cbWords_TextUpdate(object sender, EventArgs e)
        {
            cbWords.Text = "Välj...";
        }

        private void cbForms_TextUpdate(object sender, EventArgs e)
        {
            cbForms.Text = "Välj...";
        }

        private void cbConnect_TextUpdate(object sender, EventArgs e)
        {
            cbConnect.Text = "Välj...";
        }

        private void tbxCustom_TextChanged(object sender, EventArgs e)
        {
            if (tbxCustom.Text == "")
            {
                btnAddCustom.ForeColor = Color.Gray;
            }
            else
            {
                btnAddCustom.ForeColor = Color.White;
                tbxCustom.BackColor = Color.White;
            }
        }

        private void CbWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddWord.ForeColor = Color.Gray;
            cbForms.Items.Clear();
            cbForms.Enabled = true;
            cbConnect.Enabled = false;
            cbConnect.Text = "";
            cbWords.BackColor = Color.White;

            if (cbWords.Text == "Adjektiv")
            {
                cbForms.Text = "Välj...";
                cbForms.Items.Add("N-genus");
                cbForms.Items.Add("T-genus");
                cbForms.Items.Add("Plural");
                cbForms.Items.Add("Automatisk");
                cbForms.Items.Add("Preposition");
            }
            else if (cbWords.Text == "Något")
            {
                cbForms.Text = "Välj...";
                cbForms.Items.Add("Singular obestämd");
                cbForms.Items.Add("Singular bestämd");
                cbForms.Items.Add("Plural");
                cbForms.Items.Add("En eller Ett");
                //cbForms.Items.Add("Din eller Ditt");
            }
            else if (cbWords.Text == "Någon")
            {
                cbForms.Text = "Välj...";
                cbForms.Items.Add("Singular obestämd");
                cbForms.Items.Add("Singular bestämd");
                cbForms.Items.Add("Plural");
                cbForms.Items.Add("En eller Ett");
                //cbForms.Items.Add("Din eller Ditt");
            }
            else if (cbWords.Text == "Plats")
            {
                cbForms.Text = "Välj...";
                cbForms.Items.Add("Singular obestämd");
                cbForms.Items.Add("Singular bestämd");
                cbForms.Items.Add("Plural");
                cbForms.Items.Add("Preposition");
                cbForms.Items.Add("En eller Ett");
                //cbForms.Items.Add("Din eller Ditt");

            }
            else if (cbWords.Text == "Skämtnamn")
            {
                cbForms.Enabled = false;
                cbForms.Text = "";
            }
            else if (cbWords.Text == "Verb")
            {
                cbForms.Text = "Välj...";
                cbForms.Items.Add("Infinitiv");
                cbForms.Items.Add("Uppmaning");
                cbForms.Items.Add("Perfekt");
                cbForms.Items.Add("Presens");
                cbForms.Items.Add("Preposition");
            }

            if (cbWords.Text != "Välj..." && cbForms.Text != "Välj..." && cbConnect.Text != "Välj...")
            {
                btnAddWord.ForeColor = Color.White;
            }
        }

        private void SavedResultsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savedResultsStripMenuItem.ForeColor == Color.White && presentationWindow.tbxResult.Text != "")
            {
                Db.Command($"INSERT INTO TblSavedResults (Mening) VALUES ('{presentationWindow.tbxResult.Text}')", Db.connectionString);
                savedResultsStripMenuItem.ForeColor = Color.Yellow;
            }
            else if (savedResultsStripMenuItem.ForeColor == Color.Yellow && presentationWindow.tbxResult.Text != "")
            {
                Db.Command($"DELETE FROM TblSavedResults WHERE Mening = '{presentationWindow.tbxResult.Text}'", Db.connectionString);
                savedResultsStripMenuItem.ForeColor = Color.White;
            }
        }


        // 
        // Tillfällig
        //

        // Testing things
        //private void BtnTest_Click(object sender, EventArgs e)
        //{
        //    int i = 2;

        //    if (i == 1 && Db.GetValue("SELECT Version FROM Tbllkj LIMIT 1", Db.connectionString) == "1")
        //    {
        //        MessageBox.Show("If");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Else");
        //    }
        //}

    }

}



