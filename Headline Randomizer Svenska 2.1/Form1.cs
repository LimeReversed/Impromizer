using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
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

            

            // Load scene settings
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            cbRelation.SelectedIndex = Convert.ToInt32(config.AppSettings.Settings["RelationChoice"].Value);
            cbMission.SelectedIndex = Convert.ToInt32(config.AppSettings.Settings["MissionChoice"].Value);

            try
            {
                for (int i = 0; i < config.AppSettings.Settings.Count; i++)
                {
                    cbParticipants.Items.Add(config.AppSettings.Settings[$"Participant {i}"].Value);
                }
            }
            catch
            {

            }

            RelationChanged();
            lblParticipants.Text = (cbParticipants.Items.Count < 1 ? "Lägg till delttagare" : $"Lägg till deltagare (Antal: {cbParticipants.Items.Count})");

            // Show the second window at a precise location relative to the main window.
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);
            presentationWindow.otherForm = this; // this classes instance
            presentationWindow.Show();

        }


        // 
        // Click animation eventhandlers
        //
        #region
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

        private void Generate9_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate9.BackgroundImage = global::Headline_Randomizer.Properties.Resources.husmorbuttonsmall;
        }

        private void Generate9_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate9.BackgroundImage = global::Headline_Randomizer.Properties.Resources.husmorbuttonbig;
        }

        //private void btnGenerate10_MouseDown(object sender, MouseEventArgs e)
        //{
        //    btnGenerate10.BackgroundImage = global::Headline_Randomizer.Properties.Resources.locationbuttonsmall;
        //}

        //private void btnGenerate10_MouseUp(object sender, MouseEventArgs e)
        //{
        //    btnGenerate10.BackgroundImage = global::Headline_Randomizer.Properties.Resources.locationbuttonbig;
        //}

        //private void btnGenerate11_MouseUp(object sender, MouseEventArgs e)
        //{
        //    btnGenerate11.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationbutton_lång4;
        //}

        //private void btnGenerate11_MouseDown(object sender, MouseEventArgs e)
        //{
        //    btnGenerate11.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationbutton_lång_small;
        //}

        //private void btnGenerate12_MouseDown(object sender, MouseEventArgs e)
        //{
        //    btnGenerate12.BackgroundImage = global::Headline_Randomizer.Properties.Resources.protipsmall;
        //}

        //private void btnGenerate12_MouseUp(object sender, MouseEventArgs e)
        //{
        //    btnGenerate12.BackgroundImage = global::Headline_Randomizer.Properties.Resources.protipbig;
        //}

        //private void RelationRight_MounseDown(object sender, MouseEventArgs e)
        //{
        //    btnRelationRight.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationarrowright_small;
        //}

        //private void RelationRight_MounseUp(object sender, MouseEventArgs e)
        //{
        //    btnRelationRight.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationarrowright;
        //}

        //private void RelationLeft_MounseDown(object sender, MouseEventArgs e)
        //{
        //    btnRelationLeft.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationarrowleft_small;
        //}

        //private void RelationLeft_MounseUp(object sender, MouseEventArgs e)
        //{
        //    btnRelationLeft.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationarrowleft;
        //}
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
            int nr1 = r.Next(1, (nr2 + 2));

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

                presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(verbNr)} {Words.verb.Preposition(verbNr)}{Words.adjective.Automatic(adjectiveNr, somethingNr, true)} {Words.noun.SingularObest(somethingNr)}");

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

                presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(verbNr)} {Words.verb.Preposition(verbNr)}{Words.adjective.Automatic(adjectiveNr, someoneNr2, true)} {Words.noun.SingularObest(someoneNr2)}");

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
            int adjectiveNr = Words.adjective.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.adjective.Plural(adjectiveNr))} {Words.noun.Plural(someoneNr)} ");
            Words.adjective.Used(adjectiveNr);
            Words.noun.Used(someoneNr);

            int someoneNr2 = Words.someone.RandomizeId();
            int adjectiveNr2 = Words.adjective.RandomizeId();
            int verbNr = Words.verb.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(verbNr)} {Words.verb.Preposition(verbNr)}{Words.adjective.Plural(adjectiveNr2)} {Words.noun.Plural(someoneNr2)}");

            Words.adjective.Used(adjectiveNr2);
            Words.noun.Used(someoneNr2);
            Words.verb.Used(verbNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate5_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int jokeNameNr = Words.jokeName.RandomizeId();
            int nobelNr = Words.nobelPrize.RandomizeId();
            int verbNr = Words.verb.RandomizeId();
            int somethingNr = Words.something.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{Words.jokeName.Name(jokeNameNr)} vann {Words.nobelPrize.Prize(nobelNr)} för att ha {Words.verb.Perfekt(verbNr)} {Words.verb.Preposition(verbNr)}{Words.noun.Plural(somethingNr)}");

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

        private void btnGenerate6_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int verbNr = Words.verb.RandomizeId();
            int someoneNr = Words.someone.RandomizeId();

            presentationWindow.tbxResult.AppendText($"Kom ihåg, {Words.verb.Uppmaning(verbNr)} alltid {Words.verb.Preposition(verbNr)}{Words.noun.DinEllerDitt(someoneNr, false)} {Words.noun.Plural(someoneNr)}");

            Words.verb.Used(verbNr);
            Words.noun.Used(someoneNr);
            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate7_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int somethingNr = Words.something.RandomizeId();
            int adjectiveNr = Words.adjective.RandomizeId();

            presentationWindow.tbxResult.AppendText($"Lycka är {Words.adjective.Automatic(adjectiveNr, somethingNr, false)} {Words.something.Plural(somethingNr)}");

            Words.noun.Used(somethingNr);
            Words.adjective.Used(adjectiveNr);
            EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate9_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";

            int slant = r.Next(0, 2);

            if (slant == 0)
            {
                int adjectiveNr = Words.adjective.RandomizeId();
                int someoneNr = Words.someone.RandomizeId();

                presentationWindow.tbxResult.AppendText($"Husmorstips, {Words.noun.DinEllerDitt(someoneNr, false)} {Words.noun.Plural(someoneNr)} kan aldrig vara för {Words.adjective.Automatic(adjectiveNr, someoneNr, false)}");

                Words.noun.Used(someoneNr);
                Words.adjective.Used(adjectiveNr);
                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
            else if (slant == 1)
            {
                int adjectiveNr = Words.adjective.RandomizeId();
                int somethingNr = Words.something.RandomizeId();

                presentationWindow.tbxResult.AppendText($"Husmorstips, {Words.noun.DinEllerDitt(somethingNr, false)} {Words.noun.Plural(somethingNr)} kan aldrig vara för {Words.adjective.Automatic(adjectiveNr, somethingNr, false)}");

                Words.noun.Used(somethingNr);
                Words.adjective.Used(adjectiveNr);
                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
        }

        private void btnRensa3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }


        // 
        // Tab: Scen
        //

        private void btnGenerate10_Click(object sender, EventArgs e)
        {
            //    //int locationNr = r.Next(0, list.location.Count);
            //    //string newLocation = $"ni är {list.location[locationNr].Name()}";

            //    //if (!locationPressed)
            //    //{
            //    //    sceneitems.Add(newLocation);
            //    //    locationString = newLocation;
            //    //    locationPressed = true;
            //    //}
            //    //else if (locationPressed)
            //    //{
            //    //        for (int i = 0; i < sceneitems.Count; i++)
            //    //        {
            //    //            if (sceneitems[i].Contains(locationString))
            //    //            {
            //    //                sceneitems[i] = newLocation;
            //    //            }
            //    //        }
            //    //    locationString = newLocation;
            //    //}


            //    //presentationWindow.tbxResult.Text = WriteOut();

            //    //list.location.RemoveAt(locationNr);
            //    //list.LoadNeeded(1);
            //    //FixText.AdjustSize(presentationWindow.tbxResult);

            //    presentationWindow.tbxResult.Text = "";
            //    int locationNr = r.Next(0, list.location.Count);
            //    presentationWindow.tbxResult.Text = $"Ni är {list.location[locationNr].Name()}";

            //    list.location.RemoveAt(locationNr);
            //    EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        //int PNr = 1;
        //int statusPNr = 1;
        private void btnGenerate11_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";
            //    if (btnGenerate11.Text == "&Relation\r\n(Alla samma)")
            //    {
            //        int känslaNr = r.Next(0, list.relationKänsla.Count);
            //        presentationWindow.tbxResult.Text = $"Ni {list.relationKänsla[känslaNr].KänslaPlural()} varandra";
            //        list.relationKänsla.RemoveAt(känslaNr);
            //    }

            //    else if (btnGenerate11.Text == "&Relation\r\n(Alla olika)" || btnGenerate11.Text == "&Relation\r\n(Alla olika - Tryck igen för fler)")
            //    {
            //        int känslaNr = r.Next(0, list.relationKänsla.Count);

            //        presentationWindow.tbxResult.Text = $"Person {PNr} {list.relationKänsla[känslaNr].KänslaSingular()} {PNr + 1}";
            //        list.relationKänsla.RemoveAt(känslaNr);

            //        int känslaNr2 = r.Next(0, list.relationKänsla.Count);
            //        presentationWindow.tbxResult.AppendText($", medan {PNr + 1} {CheckInte(list.relationKänsla[känslaNr2].KänslaSingular())} {PNr}");

            //        PNr++;

            //        list.relationKänsla.RemoveAt(känslaNr2);
            //        btnGenerate11.Text = "&Relation\r\n(Alla olika - Tryck igen för fler)";
            //    }

            //    else if (btnGenerate11.Text == "&Relation\r\n(Statusförhållanden)")
            //    {
            //        int statusNr = r.Next(0, list.statusförhållande.Count);
            //        presentationWindow.tbxResult.Text = $"Person {statusPNr} och {statusPNr + 1} är {list.statusförhållande[statusNr].StatusFörhållande()}";
            //        list.statusförhållande.RemoveAt(statusNr);
            //        statusPNr++;
            //    }
            //    EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate12_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";
            //    int verbNr = r.Next(0, list.verb.Count);
            //    int someoneNr = r.Next(0, list.someone.Count);
            //    int somethingNr = r.Next(0, list.something.Count);
            //    int slant = r.Next(0, 2);

            //    if (slant == 0)
            //    {
            //        presentationWindow.tbxResult.Text = $"Ni ska {list.verb[verbNr].BasForm()} {list.verb[verbNr].PostVerbs()}{list.someone[someoneNr].EnEllerEtt()}{list.someone[someoneNr].Singular()}";

            //        list.verb.RemoveAt(verbNr);
            //        list.someone.RemoveAt(someoneNr);
            //        EndingRitual(1, presentationWindow.tbxResult, ref position);
            //    }
            //    else if (slant == 1)
            //    {
            //        presentationWindow.tbxResult.Text = $"Ni ska {list.verb[verbNr].BasForm()} {list.verb[verbNr].PostVerbs()}{list.something[somethingNr].EnEllerEtt()}{list.something[somethingNr].Singular()}";

            //        list.verb.RemoveAt(verbNr);
            //        list.something.RemoveAt(somethingNr);
            //        EndingRitual(1, presentationWindow.tbxResult, ref position);
            //    }
        }


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

                presentationWindow.tbxResult.AppendText($"Är du trött på att {Words.verb.Infinitiv(verbNr)} {Words.verb.Preposition(verbNr)}{Words.noun.Plural(someoneNr)}?");

                Words.noun.Used(someoneNr);
                Words.verb.Used(verbNr);
                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
            else if (slant == 1)
            {
                int verbNr = Words.verb.RandomizeId();
                int somethingNr = Words.something.RandomizeId();

                presentationWindow.tbxResult.AppendText($"Är du trött på att {Words.verb.Infinitiv(verbNr)} {Words.verb.Preposition(verbNr)}{Words.noun.Plural(somethingNr)}?");

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

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
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
                cbForms.Items.Add("Preposition");
                cbForms.Items.Add("Plats");
                cbForms.Items.Add("En eller Ett");
                //cbForms.Items.Add("Din eller Ditt");
            }
            else if (cbWords.Text == "Någon")
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

        bool nounsAdded = false;
        bool verbsAdded = false;
        bool adjectivesAdded = false;

        // Add different items, depending on the current choices. 
        private void cbForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Needed to remove for example pink color after wrong choice. 
            cbConnect.Items.Clear();
            cbConnect.Enabled = false;
            cbConnect.Text = "";
            cbForms.BackColor = Color.White;
            btnAddWord.ForeColor = Color.Gray;

            if ((cbWords.Text == "Någon" || cbWords.Text == "Något") 
                    && (cbForms.Text == "En eller Ett" || cbForms.Text == "Din eller Ditt" || cbForms.Text == "Preposition") 
                || (cbWords.Text == "Adjektiv" && cbForms.Text == "Automatisk"))
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
                Custom newItem = new Custom(cbWords.Text, cbForms.Text, cbConnect.Text, 0, 0, Db.choicesList.Count);
                Db.choicesList.Add(newItem);
            }

            // Write out all choices made in the "Added wors/numbers" textbox
            tbxAdded.Text = "";
            foreach (Custom element in Db.choicesList)
            {
                if (element.WordChoice == "Nr" || element.CustomString == true)
                {
                    tbxAdded.AppendText($"{(Db.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice}");
                }
                else
                {
                    tbxAdded.AppendText($"{(Db.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice} ({element.FormChoice})");
                }
            }

            // Keep tabs on whether Nouns and verbs have been added. 
            if (cbWords.Text == "Någon" || cbWords.Text == "Något")
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
        }

        private void btnAddNr_Click(object sender, EventArgs e)
        {
            Custom newcombo = new Custom("Nr", nupFrom.Value, nupTo.Value);
            Db.choicesList.Add(newcombo);

            tbxAdded.Text = "";
            foreach (Custom element in Db.choicesList)
            {
                if (element.WordChoice == "Nr" || element.CustomString == true)
                {
                    tbxAdded.AppendText($"{(Db.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice}");
                }
                else
                {
                    tbxAdded.AppendText($"{(Db.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice} ({element.FormChoice})");
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
                Db.choicesList.Add(newcombo);
            }

            tbxAdded.Text = "";
            foreach (Custom element in Db.choicesList)
            {
                if (element.WordChoice == "Nr" || element.CustomString == true)
                {
                    tbxAdded.AppendText($"{(Db.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice}");
                }
                else
                {
                    tbxAdded.AppendText($"{(Db.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.WordChoice} ({element.FormChoice})");
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
            foreach (Custom element in Db.choicesList)
            {
                if (element.WordChoice == "Någon" && (element.FormChoice != "En eller Ett" 
                    || element.FormChoice != "Din eller Ditt" || element.FormChoice != "Preposition"))
                {
                    // Add randomId to the Id-variable in the current instance.
                    // Then set that word to used and reload if needed. 
                    element.Id = Words.someone.RandomizeId();
                    Words.noun.Used(element.Id);
                    Words.FreeNeeded(5);
                }

                else if (element.WordChoice == "Något" && (element.FormChoice != "En eller Ett" 
                        && element.FormChoice != "Plats" && element.FormChoice != "Din eller Ditt" && element.FormChoice != "Preposition"))
                {
                    element.Id = Words.something.RandomizeId();
                    Words.noun.Used(element.Id);
                    Words.FreeNeeded(5);
                }

                else if (element.WordChoice == "Något" && element.FormChoice == "Plats" && element.FormChoice != "Preposition")
                {
                    element.Id = Words.location.RandomizeId();
                    Words.noun.Used(element.Id);
                    Words.FreeNeeded(5);
                }

                else if (element.WordChoice == "Adjektiv" && element.FormChoice != "Preposition")
                {
                    element.Id = Words.adjective.RandomizeId();
                    Words.adjective.Used(element.Id);
                    Words.FreeNeeded(5);
                }

                else if (element.WordChoice == "Verb" && element.FormChoice != "Preposition")
                {
                    element.Id = Words.verb.RandomizeId();
                    Words.verb.Used(element.Id);
                    Words.FreeNeeded(5);
                }

                else if (element.WordChoice == "Skämtnamn")
                {
                    element.Id = Words.jokeName.RandomizeId();
                    Words.jokeName.Used(element.Id);
                    Words.FreeNeeded(5);
                }

                else { }
            }

            // When the RanomizedId has been added, then figure out which of them 
            // the below should be connected to.
            foreach (Custom element in Db.choicesList)
            {
                if (element.WordChoice == "Verb" && element.FormChoice == "Preposition" && element.ConnectionChoice == "Syfta till nästa verb")
                {
                    // Go from where the current item is in the choicesList and move up until it 
                    // reaches the next verb. 
                    for (int i = element.PositionNr; i < Db.choicesList.Count; i++)
                    {
                        if (Db.choicesList[i].WordChoice == "Verb" && Db.choicesList[i].FormChoice != "Preposition")
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
                        if (Db.choicesList[i].WordChoice == "Verb" && Db.choicesList[i].FormChoice != "Preposition")
                        {
                            element.ConnectionPosition = i;
                            break;
                        }
                    }
                }

                else if (element.ConnectionChoice == "Syfta till nästa substantiv" 
                            && (element.WordChoice == "Något" || element.WordChoice == "Någon")  
                                && (element.FormChoice == "En eller Ett" || element.FormChoice == "Din eller Ditt"
                                || element.FormChoice == "Preposition" || element.FormChoice == "Plats") 
                            || (element.WordChoice == "Adjektiv" && element.FormChoice == "Automatisk" && element.ConnectionChoice == "Syfta till nästa substantiv")) 
                     {
                        for (int i = element.PositionNr; i < Db.choicesList.Count; i++)
                        {
                            if (
                                (Db.choicesList[i].WordChoice == "Någon" || Db.choicesList[i].WordChoice == "Något") 
                                    && (Db.choicesList[i].FormChoice != "En eller Ett" && Db.choicesList[i].FormChoice != "Preposition"
                                     && Db.choicesList[i].FormChoice != "Din eller Ditt" && Db.choicesList[i].FormChoice != "Plats") 
                                     || (Db.choicesList[i].WordChoice == "Något" && Db.choicesList[i].FormChoice == "Plats"))
                            {
                                element.ConnectionPosition = i;
                                break;
                            }
                        }
                     }

                else if (element.ConnectionChoice == "Syfta till tidigare substantiv"
                            && (element.WordChoice == "Något" || element.WordChoice == "Någon") 
                                && (element.FormChoice == "En eller Ett" || element.FormChoice == "Din eller Ditt" 
                                || element.FormChoice == "Preposition" || element.FormChoice == "Plats") 
                        || (element.WordChoice == "Adjektiv" && element.FormChoice == "Automatisk" && element.ConnectionChoice == "Syfta till tidigare substantiv"))
                     {
                        for (int i = element.PositionNr; i >= 0; i--)
                        {
                            if (
                                (Db.choicesList[i].WordChoice == "Någon" || Db.choicesList[i].WordChoice == "Något")
                                    && (Db.choicesList[i].FormChoice != "En eller Ett" && Db.choicesList[i].FormChoice != "Preposition"
                                     && Db.choicesList[i].FormChoice != "Din eller Ditt" && Db.choicesList[i].FormChoice != "Plats")
                                     || (Db.choicesList[i].WordChoice == "Något" && Db.choicesList[i].FormChoice == "Plats"))
                        {
                                element.ConnectionPosition = i;
                                break;
                            }
                        }
                     }

                if (element.WordChoice == "Adjektiv" && element.FormChoice == "Preposition" && element.ConnectionChoice == "Syfta till nästa adjektiv")
                {
                    for (int i = element.PositionNr; i < Db.choicesList.Count; i++)
                    {
                        if (Db.choicesList[i].WordChoice == "Adjektiv" && Db.choicesList[i].FormChoice != "Preposition")
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
                        if (Db.choicesList[i].WordChoice == "Adjektiv" && Db.choicesList[i].FormChoice != "Preposition")
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
            foreach (Custom element in Db.choicesList)
            {
                try
                {
                    if (element.FormChoice == "En eller Ett")
                    {
                        int nr = Db.choicesList[element.ConnectionPosition].Id;
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
                            int nounId = Db.choicesList[element.ConnectionPosition].Id;

                            
                            if (Db.choicesList[element.ConnectionPosition].FormChoice == "Singular obestämd" || Db.choicesList[element.ConnectionPosition].FormChoice == "Singular bestämd")
                            {                     
                                // Write it out. element.Id is the current adjective ID Nr. 
                                presentationWindow.tbxResult.AppendText($"{Words.adjective.Automatic(element.Id, nounId, true)} ");
                            }
                            else if (Db.choicesList[element.ConnectionPosition].FormChoice == "Plural")
                            {
                                presentationWindow.tbxResult.AppendText($"{Words.adjective.Automatic(element.Id, nounId, false)} ");
                            }
                        }

                        else if (element.FormChoice == "Preposition")
                        {
                            int adjectiveId = Db.choicesList[element.ConnectionPosition].Id;
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

                else if ((element.WordChoice == "Något" || element.WordChoice == "Någon") && element.FormChoice == "Singular obestämd")
                {
                    presentationWindow.tbxResult.AppendText($"{Words.noun.SingularObest(element.Id)} ");
                }

                else if ((element.WordChoice == "Något" || element.WordChoice == "Någon") && element.FormChoice == "Singular bestämd")
                {
                    presentationWindow.tbxResult.AppendText($"{Words.noun.SingularBest(element.Id)} ");
                }

                else if ((element.WordChoice == "Något" || element.WordChoice == "Någon") && element.FormChoice == "Plural")
                {
                    presentationWindow.tbxResult.AppendText($"{Words.noun.Plural(element.Id)} ");
                }

                else if ((element.WordChoice == "Något" || element.WordChoice == "Någon") && element.FormChoice == "Preposition")
                {
                    int nounId = Db.choicesList[element.ConnectionPosition].Id;
                    presentationWindow.tbxResult.AppendText($"{Words.noun.Preposition(nounId)}");
                }
                
                else if (element.WordChoice == "Något" && element.FormChoice == "Plats")
                {
                    presentationWindow.tbxResult.AppendText($"{Words.location.SingularBest(element.Id)}");
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
                        int verbId = Db.choicesList[element.ConnectionPosition].Id;
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

            string toUpper = FixText.FirstLetterUpper(presentationWindow.tbxResult.Text);
            // Sometimes there's an extra space. This removes that. 
            toUpper = toUpper.Replace("  ", " ");
            presentationWindow.tbxResult.Text = toUpper;
            EndingRitual(5, presentationWindow.tbxResult, ref position);
        }

        private void btnCustomClear_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            tbxCustom.Text = "";
            tbxAdded.Text = "";
            Db.choicesList.Clear();
            nounsAdded = false;
            verbsAdded = false;
            adjectivesAdded = false;
            cbForms.Text = "Välj...";
            cbConnect.Enabled = false;
            cbConnect.Text = "";
        }

  
        //
        // Metoder
        //

        public void EndingRitual(int loadNr, TextBox tb, ref int position)
        {
            //tb.Text = tb.Text.Replace("  ", " ");
            Words.FreeNeeded(loadNr);
            FixText.AdjustSize(tb);
            Db.recentStrings.Add(tb.Text);
            position = Db.recentStrings.Count - 1;
        }

        string CheckInte(string sträng)
        {
            if (sträng.Contains("inte"))
            {
                sträng = sträng.Replace("inte", "");
                sträng = sträng.Trim();
                sträng = sträng.Insert(0, "inte ");
                sträng = sträng.Replace("  ", " ");
                return sträng;
            }
            else
            {
                return sträng;
            }

        }

        void RelationChanged()
        {
            vs.Clear();
            relationPressed = false;
            pressAmount = 0;
            btnGenerateRelation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);

            if (cbParticipants.Items.Count == 0)
            {
                btnGenerateRelation.Text = "Relation";
            }

            else if (cbRelation.SelectedIndex == 0 || (cbRelation.SelectedIndex == 1 && cbParticipants.Items.Count == 1))
            {
                btnGenerateRelation.Text = $"Relation \r\n (Visa {cbParticipants.Items[0]})";
            }

            else if (cbRelation.SelectedIndex == 1 && cbParticipants.Items.Count > 1)
            {
                btnGenerateRelation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnGenerateRelation.Text = $"Relation \r\n (Visa {cbParticipants.Items[0]} \r\n och {cbParticipants.Items[1]})";
            }
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

        private void Tabchanged(object sender, EventArgs e)
        {
            if (customTabControl1.ActiveIndex == 1)
            {
                customTabControl1.Size = new Size(614, 233);
            }
            else if (customTabControl1.ActiveIndex == 2)
            {
                customTabControl1.Size = new Size(614, 332);
                Form1 form1 = this;
                form1.AcceptButton = btnAddParticipant;
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
            Options options = new Options();
            options.Show();
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

        //
        // Save/Unsave results
        //

        private void saveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveResultToolStripMenuItem.ForeColor == Color.White && presentationWindow.tbxResult.Text != "")
            {
                Db.Command($"INSERT INTO TblSavedResults VALUES ('{presentationWindow.tbxResult.Text}')");
                // also to list?
                saveResultToolStripMenuItem.ForeColor = Color.Yellow;
            }
            else if (saveResultToolStripMenuItem.ForeColor == Color.Yellow && presentationWindow.tbxResult.Text != "")
            {
                Db.Command($"DELETE FROM TblSavedResults WHERE Lines = '{presentationWindow.tbxResult.Text}'");
                saveResultToolStripMenuItem.ForeColor = Color.White;
            }
        }

        
        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            cbParticipants.BackColor = Color.White;
            cbParticipants.Items.Add(cbParticipants.Text);
            lblParticipants.Text = (cbParticipants.Items.Count < 1 ? "Lägg till delttagare" : $"Lägg till deltagare (Antal: {cbParticipants.Items.Count})");
            UpdateConfig();
            RelationChanged();
            cbParticipants.Text = "";
            cbParticipants.Focus();
        }

        
        private void btnRemoveParticipant_Click(object sender, EventArgs e)
        {
            cbParticipants.Items.Remove(cbParticipants.Text);
            lblParticipants.Text = (cbParticipants.Items.Count < 1 ? "Lägg till delttagare" : $"Lägg till deltagare (Antal: {cbParticipants.Items.Count})");
            UpdateConfig();
            RelationChanged();
            if (cbParticipants.Items.Count > 0)
            {
                cbParticipants.SelectedIndex = 0;
            }
            else
            {
                cbParticipants.Text = "Skriv in namn...";
            }

        }

        void UpdateConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            for (int i = 0; i < config.AppSettings.Settings.Count; i++)
            {
                config.AppSettings.Settings.Remove($"Participant {i}");
            }

            for (int i = 0; i < cbParticipants.Items.Count; i++)
            {

                config.AppSettings.Settings.Add($"Participant {i}", $"{cbParticipants.Items[i]}");
            }

            config.Save();
        }

        private void btnGenerateLocation_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int locationNr = Words.location.RandomizeId();
            presentationWindow.tbxResult.Text = $"Ni är {Words.location.Preposition(locationNr)} {Words.location.SingularBest(locationNr)}";

            Words.location.Used(locationNr);
            EndingRitual(3, presentationWindow.tbxResult, ref position);
        }

        bool relationPressed = false;
        int pressAmount = 0;
        List<string> vs = new List<string>();

        private void btnGenerateRelation_Click(object sender, EventArgs e)
        {
            btnGenerateRelation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);

            switch (cbRelation.SelectedIndex)
            {
                case 0:

                    int slant = r.Next(0, 2);
                    StringBuilder builder = new StringBuilder();

                    if (cbParticipants.Items.Count < 1)
                    {
                        cbParticipants.BackColor = Color.Pink;
                        cbParticipants.Text = "Skriv in deltagare...";
                    }

                    else if (cbParticipants.Items.Count == 1 && slant == 0)
                    {
                        presentationWindow.tbxResult.Text = "";

                        int relationNr = Words.adjective.RandomizeRelation();

                        presentationWindow.tbxResult.Text = $"{cbParticipants.Items[0].ToString()} är {Words.adjective.NGenus(relationNr)}{Words.adjective.Preposition(relationNr)}sig själv";

                        Words.adjective.Used(relationNr);
                        EndingRitual(3, presentationWindow.tbxResult, ref position);
                    }

                    else if (cbParticipants.Items.Count == 1 && slant == 1)
                    {
                        presentationWindow.tbxResult.Text = "";

                        int relationNr = Words.verb.RandomizeRelation();

                        presentationWindow.tbxResult.Text = $"{cbParticipants.Items[0].ToString()} {Words.verb.Presens(relationNr)}{Words.verb.Preposition(relationNr)}sig själv";

                        Words.verb.Used(relationNr);
                        EndingRitual(3, presentationWindow.tbxResult, ref position);
                    }

                    
                    else if (cbParticipants.Items.Count > 1 && relationPressed && pressAmount < vs.Count)
                    {
                        presentationWindow.tbxResult.Text = "";
                        presentationWindow.tbxResult.Text = vs[pressAmount];
                        pressAmount++;
                        EndingRitual(3, presentationWindow.tbxResult, ref position);
                        btnGenerateRelation.Text = (pressAmount > vs.Count - 1 ? "Relation \r\n (Tryck på rensa)" : $"Relation \r\n (Visa {cbParticipants.Items[pressAmount].ToString()})");
                    }

                    else if (cbParticipants.Items.Count > 1 && !relationPressed)
                    {
                        presentationWindow.tbxResult.Text = "";
                        for (int i = 0; i < cbParticipants.Items.Count; i++)
                        {
                            slant = r.Next(0, 2);
                            string firstParticipant = cbParticipants.Items[i].ToString();
                            builder.Append($"{firstParticipant} ");
                            int k = i;
                            for (int j = 0; j < cbParticipants.Items.Count - 1; j++)
                            {
                                k = (k == cbParticipants.Items.Count - 1 ? k = 0 : k = k + 1);

                                if (slant == 0)
                                {
                                    int rNr = Words.adjective.RandomizeRelation();
                                    builder.Append($"är {Words.adjective.NGenus(rNr)}{Words.adjective.Preposition(rNr)}{cbParticipants.Items[k]}" +
                                        $"{(j == cbParticipants.Items.Count - 3 ? " och " : ", ")}");
                                    Words.adjective.Used(rNr);
                                }
                                else
                                {
                                    int rNr = Words.verb.RandomizeRelation();
                                    builder.Append($"{Words.verb.Presens(rNr)}{Words.verb.Preposition(rNr)}{cbParticipants.Items[k]}" +
                                        $"{(j == cbParticipants.Items.Count - 3 ? " och " : ", ")}");
                                    Words.verb.Used(rNr);

                                }
                                slant = r.Next(0, 2);
                                Words.FreeNeeded(2);
                            }
                            builder.Remove(builder.Length - 2, 2);
                            vs.Add(builder.ToString());
                            presentationWindow.tbxResult.Text = $"{vs[0]}";
                            builder.Clear();
                        }
                        relationPressed = true;
                        pressAmount++;
                        EndingRitual(3, presentationWindow.tbxResult, ref position);
                        btnGenerateRelation.Text = $"Relation \r\n (Visa {cbParticipants.Items[pressAmount]})";
                    }
                    else
                    {
                    }
                    
                    break;

                case 1:
                    
                    if (cbParticipants.Items.Count < 1)
                    {
                        cbParticipants.BackColor = Color.Pink;
                        cbParticipants.Text = "Skriv in deltagare...";
                    }

                    else if (cbParticipants.Items.Count == 1)
                    {
                        int statusId = Words.status.RandomizeId();

                        presentationWindow.tbxResult.Text = $"{cbParticipants.Items[0]} är {Words.status.LowStatus(statusId)} och {Words.status.HighStatus(statusId)}";

                        Words.status.Used(statusId);

                        EndingRitual(2, presentationWindow.tbxResult, ref position);
                    }

                    else if (cbParticipants.Items.Count > 1 && pressAmount < cbParticipants.Items.Count - 1)
                    {
                        int statusId = Words.status.RandomizeId();

                        presentationWindow.tbxResult.Text = $"{cbParticipants.Items[pressAmount]} är {Words.status.LowStatus(statusId)} och {cbParticipants.Items[pressAmount + 1]} {Words.status.HighStatus(statusId)}";

                        Words.status.Used(statusId);

                        pressAmount++;

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
                case 0:
                    
                     presentationWindow.tbxResult.Text = "";
                     int verbNr = Words.verb.RandomizeId();
                     int someoneNr = Words.someone.RandomizeId();
                     int somethingNr = Words.something.RandomizeId();
                     int slant = r.Next(0, 2);

                     if (slant == 0)
                     {
                        presentationWindow.tbxResult.Text = $"Ni ska {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.EnEllerEtt(someoneNr)} {Words.noun.SingularObest(someoneNr)}";

                        Words.verb.Used(verbNr);
                        Words.noun.Used(someoneNr);
                        EndingRitual(3, presentationWindow.tbxResult, ref position);
                     }

                    else if (slant == 1)
                    {
                        presentationWindow.tbxResult.Text = $"Ni ska {Words.verb.Infinitiv(verbNr)}{Words.verb.Preposition(verbNr)}{Words.noun.EnEllerEtt(somethingNr)} {Words.noun.SingularObest(somethingNr)}";

                        Words.verb.Used(verbNr);
                        Words.noun.Used(somethingNr);
                        EndingRitual(3, presentationWindow.tbxResult, ref position);
                    }
                    break;

                case 1:

                    presentationWindow.tbxResult.Text = "";
                    verbNr = Words.verb.RandomizeId();

                    if (cbParticipants.Items.Count < 1)
                    {
                        MessageBox.Show("Var god lägg till deltagare");
                    }
                    else if (cbParticipants.Items.Count == 1)
                    {
                        presentationWindow.tbxResult.Text = $"Scenen slutar med att {cbParticipants.Text}{Words.verb.Presens(verbNr)}{Words.verb.Preposition(verbNr)}sig själv";
                    }
                    else
                    {
                        cbParticipants.SelectedIndex = r.Next(0, cbParticipants.Items.Count);
                        string name1 = cbParticipants.Text;
                        string name2 = cbParticipants.Text;

                        while (name1 == name2)
                        {
                            cbParticipants.SelectedIndex = r.Next(0, cbParticipants.Items.Count);
                            name2 = cbParticipants.Text;
                        }

                        presentationWindow.tbxResult.Text = $"Scenen slutar med att {name1} {Words.verb.Presens(verbNr)}{Words.verb.Preposition(verbNr)}{name2}";
                    }
                    

                    Words.verb.Used(verbNr);
                    EndingRitual(3, presentationWindow.tbxResult, ref position);

                    break;

                case 2:
                    // Kod för färdigskriven mission. 
                    break;
            }
        }

        private void btnClearScene_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            RelationChanged();
        }

        private void cbRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            RelationChanged();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["RelationChoice"].Value = cbRelation.SelectedIndex.ToString();
            config.Save();
        }

        private void cbMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            vs.Clear();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["MissionChoice"].Value = cbMission.SelectedIndex.ToString();
            relationPressed = false;
            config.Save();
        }

        private void cbParticipants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbParticipants.Items.Count == 1)
            {
                btnGenerateRelation.Text = $"Relation \r\n (Visa {cbParticipants.Items[0]})";
            }
        }


        // 
        // Tillfällig
        //

    }

}



