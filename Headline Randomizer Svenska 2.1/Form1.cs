using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data.SqlClient;

// Svenska 
namespace Headline_Randomizer
{
    public partial class Form1 : Form
    {
        // Creating objects to be able to reach their properties
        PresentationWindow presentationWindow = new PresentationWindow();
        //Lists list = new Lists();
        Random r = new Random();
        int position;


        public Form1()
        {
            InitializeComponent();

            // Show the second window at a precise location relative to the main window.
            presentationWindow.Location = new Point(Location.X + 8, Location.Y + Size.Height);
            presentationWindow.Show();
        }

        // __________________________________
        // Click animation eventhandlers
        //

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

        private void btnGenerate10_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate10.BackgroundImage = global::Headline_Randomizer.Properties.Resources.locationbuttonsmall;
        }

        private void btnGenerate10_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate10.BackgroundImage = global::Headline_Randomizer.Properties.Resources.locationbuttonbig;
        }

        private void btnGenerate11_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate11.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationbutton_lång4;
        }

        private void btnGenerate11_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate11.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationbutton_lång_small;
        }

        private void btnGenerate12_MouseDown(object sender, MouseEventArgs e)
        {
            btnGenerate12.BackgroundImage = global::Headline_Randomizer.Properties.Resources.protipsmall;
        }

        private void btnGenerate12_MouseUp(object sender, MouseEventArgs e)
        {
            btnGenerate12.BackgroundImage = global::Headline_Randomizer.Properties.Resources.protipbig;
        }

        private void RelationRight_MounseDown(object sender, MouseEventArgs e)
        {
            btnRelationRight.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationarrowright_small;
        }

        private void RelationRight_MounseUp(object sender, MouseEventArgs e)
        {
            btnRelationRight.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationarrowright;
        }

        private void RelationLeft_MounseDown(object sender, MouseEventArgs e)
        {
            btnRelationLeft.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationarrowleft_small;
        }

        private void RelationLeft_MounseUp(object sender, MouseEventArgs e)
        {
            btnRelationLeft.BackgroundImage = global::Headline_Randomizer.Properties.Resources.relationarrowleft;
        }


        // __________________
        // Tab: Rubriker
        //

        private void btnGenerate1_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneId = Words.someone.RandomizeId();
            int adjectiveId = Words.adjective.RandomizeId();
            int nr2 = r.Next(1, 11);
            int nr1 = r.Next(1, (nr2 + 2));

            presentationWindow.tbxResult.Text = $"{nr1} av {nr2} tycker att {Words.someone.Plural(someoneId)} är {Words.adjective.Plural(adjectiveId)}";

            // Remove used words
            Words.someone.Used(someoneId);
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

                presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.someone.Singular(someoneNr))} ");
                Words.someone.Used(someoneNr);

                int verbNr = Words.verb.RandomizeId();
                int somethingNr = Words.something.RandomizeId();
                int adjectiveNr = Words.adjective.RandomizeId();

                presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(verbNr)} {Words.verb.PostVerbs(verbNr)}{Words.adjective.Singular(adjectiveNr, somethingNr)} {Words.something.Singular(somethingNr)}");

                Words.verb.Used(verbNr);
                Words.something.Used(somethingNr);
                Words.adjective.Used(adjectiveNr);

                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
            else if (slant == 1)
            {
                presentationWindow.tbxResult.Text = "";
                int someoneNr = Words.someone.RandomizeId();

                presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.someone.Singular(someoneNr))} ");
                Words.someone.Used(someoneNr);

                int verbNr = Words.verb.RandomizeId();
                int someoneNr2 = Words.someone.RandomizeId();
                int adjectiveNr = Words.adjective.RandomizeId();

                presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(verbNr)} {Words.verb.PostVerbs(verbNr)}{Words.adjective.Singular(adjectiveNr, someoneNr2)} {Words.something.Singular(someoneNr2)}");

                Words.verb.Used(verbNr);
                Words.someone.Used(someoneNr2);
                Words.adjective.Used(adjectiveNr);

                EndingRitual(2, presentationWindow.tbxResult, ref position);
            }
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneNr = Words.someone.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.someone.Singular(someoneNr))} tror att ");
            Words.someone.Used(someoneNr);

            int someoneNr2 = Words.someone.RandomizeId();
            int somethingNr = Words.something.RandomizeId();
            presentationWindow.tbxResult.AppendText($"{Words.someone.Plural(someoneNr2)} är {Words.something.Plural(somethingNr)}");

            Words.someone.Used(someoneNr2);
            Words.something.Used(somethingNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate4_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
            int someoneNr = Words.someone.RandomizeId();
            int adjectiveNr = Words.adjective.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{FixText.FirstLetterUpper(Words.adjective.Plural(adjectiveNr))} {Words.someone.Plural(someoneNr)} ");
            Words.adjective.Used(adjectiveNr);
            Words.someone.Used(someoneNr);

            int someoneNr2 = Words.someone.RandomizeId();
            int adjectiveNr2 = Words.adjective.RandomizeId();
            int verbNr = Words.verb.RandomizeId();

            presentationWindow.tbxResult.AppendText($"{Words.verb.Presens(verbNr)} {Words.verb.PostVerbs(verbNr)}{Words.adjective.Plural(adjectiveNr2)} {Words.someone.Plural(someoneNr2)}");

            Words.adjective.Used(adjectiveNr2);
            Words.someone.Used(someoneNr2);
            Words.verb.Used(verbNr);

            EndingRitual(2, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate5_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";
            //    int jokeNameNr = r.Next(0, list.jokeName.Count);
            //    int nobelNr = r.Next(0, list.nobelPrize.Count);
            //    int verbNr = r.Next(0, list.verb.Count);
            //    int somethingNr = r.Next(0, list.something.Count);

            //    presentationWindow.tbxResult.AppendText($"{list.jokeName[jokeNameNr].Name()} vann {list.nobelPrize[nobelNr].Prize()} för att ha {list.verb[verbNr].Perfekt()} {list.verb[verbNr].PostVerbs()}{list.something[somethingNr].Plural()}");

            //    list.jokeName.RemoveAt(jokeNameNr);
            //    list.nobelPrize.RemoveAt(nobelNr);
            //    list.verb.RemoveAt(verbNr);
            //    list.something.RemoveAt(somethingNr);
            //    EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            presentationWindow.tbxResult.Text = "";
        }


        // ________________
        // Tab: Visdom
        //

        private void btnGenerate6_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";

            //    int verbNr = r.Next(0, list.verb.Count);
            //    int someoneNr = r.Next(0, list.someone.Count);

            //    presentationWindow.tbxResult.AppendText($"Kom ihåg, {list.verb[verbNr].Request()} alltid {list.verb[verbNr].PostVerbs()}{list.someone[someoneNr].DinEllerDitt("plural")} {list.someone[someoneNr].Plural()}");

            //    list.verb.RemoveAt(verbNr);
            //    list.someone.RemoveAt(someoneNr);
            //    EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate7_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";
            //    int somethingNr = r.Next(0, list.something.Count);
            //    int adjectiveNr = r.Next(0, list.adjective.Count);

            //    presentationWindow.tbxResult.AppendText($"Lycka är {list.adjective[adjectiveNr].Plural(list.something, somethingNr)} {list.something[somethingNr].Plural()}");

            //    list.something.RemoveAt(somethingNr);
            //    list.adjective.RemoveAt(adjectiveNr);
            //    EndingRitual(1, presentationWindow.tbxResult, ref position);
        }

        private void btnGenerate9_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";

            //    int slant = r.Next(0, 2);

            //    if (slant == 0)
            //    {
            //        int adjectiveNr = r.Next(0, list.adjective.Count);
            //        int someoneNr = r.Next(0, list.someone.Count);

            //        presentationWindow.tbxResult.AppendText($"Husmorstips, {list.someone[someoneNr].DinEllerDitt("plural")} {list.someone[someoneNr].Plural()} kan aldrig vara för {list.adjective[adjectiveNr].Plural()}");

            //        list.someone.RemoveAt(someoneNr);
            //        list.adjective.RemoveAt(adjectiveNr);
            //        EndingRitual(1, presentationWindow.tbxResult, ref position);
            //    }
            //    else if (slant == 1)
            //    {
            //        int adjectiveNr = r.Next(0, list.adjective.Count);
            //        int somethingNr = r.Next(0, list.something.Count);

            //        presentationWindow.tbxResult.AppendText($"Husmorstips, {list.something[somethingNr].DinEllerDitt("plural")} {list.something[somethingNr].Plural()} kan aldrig vara för {list.adjective[adjectiveNr].Plural(list.something, somethingNr)}");

            //        list.something.RemoveAt(somethingNr);
            //        list.adjective.RemoveAt(adjectiveNr);
            //        EndingRitual(1, presentationWindow.tbxResult, ref position);
            //    }
        }

        private void btnRensa3_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";
        }


        // ______________
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

        private void btnRensa_Click(object sender, EventArgs e)
        {
            //    //scene.Clear();
            //    //sceneitems.Clear();
            //    presentationWindow.tbxResult.Text = "";
            //    PNr = 1;
            //    statusPNr = 1;
            //    //locationString = "";
            //    //relationString = "";
            //    //missionString = "";
            //    //locationPressed = false;
            //    //relationPressed = false;
            //    //missionPressed = false;

        }

        //int nr = 0;
        private void RelationRight(object sender, EventArgs e)
        {
            //    nr++;
            //    if (nr == 0)
            //    {
            //        btnGenerate11.Text = "&Relation\r\n(Alla samma)";
            //        btnRelationRight.Enabled = true;
            //        btnRelationLeft.Enabled = false;
            //        btnRelationRight.Visible = true;
            //        btnRelationLeft.Visible = false;
            //    }
            //    else if (nr == 1)
            //    {
            //        btnGenerate11.Text = "&Relation\r\n(Alla olika)";
            //        btnRelationRight.Enabled = true;
            //        btnRelationLeft.Enabled = true;
            //        btnRelationRight.Visible = true;
            //        btnRelationLeft.Visible = true;
            //    }
            //    else if (nr == 2)
            //    {
            //        btnGenerate11.Text = "&Relation\r\n(Statusförhållanden)";
            //        btnRelationRight.Enabled = false;
            //        btnRelationLeft.Enabled = true;
            //        btnRelationRight.Visible = false;
            //        btnRelationLeft.Visible = true;
            //    }
            //    else if (nr > 2)
            //    {
            //        nr = 2;
            //    }
        }

        private void RelationLeft(object sender, EventArgs e)
        {
            //    nr--;
            //    if (nr == 0)
            //    {
            //        btnGenerate11.Text = "&Relation\r\n(Alla samma)";
            //        btnRelationRight.Enabled = true;
            //        btnRelationLeft.Enabled = false;
            //        btnRelationRight.Visible = true;
            //        btnRelationLeft.Visible = false;
            //    }
            //    else if (nr == 1)
            //    {
            //        btnGenerate11.Text = "&Relation\r\n(Alla olika)";
            //        btnRelationRight.Enabled = true;
            //        btnRelationLeft.Enabled = true;
            //        btnRelationRight.Visible = true;
            //        btnRelationLeft.Visible = true;
            //    }
            //    else if (nr == 2)
            //    {
            //        btnGenerate11.Text = "&Relation\r\n(Statusförhållanden)";
            //        btnRelationRight.Enabled = false;
            //        btnRelationLeft.Enabled = true;
            //        btnRelationRight.Visible = false;
            //        btnRelationLeft.Visible = true;
            //    }
            //    else if (nr < 0)
            //    {
            //        nr = 0;
            //    }
        }


        // ________________
        // Tab: Övrigt
        //

        private void btnGenerate8_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";

            //    int slant = r.Next(0, 2);

            //    if (slant == 0)
            //    {
            //        int verbNr = r.Next(0, list.verb.Count);
            //        int someoneNr = r.Next(0, list.someone.Count);

            //        presentationWindow.tbxResult.AppendText($"Är du trött på att {list.verb[verbNr].BasForm()} {list.verb[verbNr].PostVerbs()}{list.someone[someoneNr].Plural()}?");

            //        list.someone.RemoveAt(someoneNr);
            //        list.verb.RemoveAt(verbNr);
            //        EndingRitual(1, presentationWindow.tbxResult, ref position);
            //    }
            //    else if (slant == 1)
            //    {
            //        int verbNr = r.Next(0, list.verb.Count);
            //        int somethingNr = r.Next(0, list.something.Count);

            //        presentationWindow.tbxResult.AppendText($"Är du trött på att {list.verb[verbNr].BasForm()} {list.verb[verbNr].PostVerbs()}{list.something[somethingNr].Plural()}?");

            //        list.something.RemoveAt(somethingNr);
            //        list.verb.RemoveAt(verbNr);
            //        EndingRitual(1, presentationWindow.tbxResult, ref position);

            //    }
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";
        }


        // _____________________
        // Tab: Egen mening
        //

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    cbForms.Items.Clear();
            //    if (cbBook.Text == "Adjektiv")
            //    {
            //        cbForms.Items.Add("Singular");
            //        cbForms.Items.Add("Plural");
            //    }
            //    else if (cbBook.Text == "Substantiv - Något")
            //    {
            //        cbForms.Items.Add("Singular");
            //        cbForms.Items.Add("Plural");
            //    }
            //    else if (cbBook.Text == "Substantiv - Någon")
            //    {
            //        cbForms.Items.Add("Singular");
            //        cbForms.Items.Add("Plural");
            //    }
            //    else if (cbBook.Text == "Skämtnamn")
            //    {
            //        cbForms.Items.Add("Name");
            //    }
            //    else if (cbBook.Text == "Verb")
            //    {
            //        cbForms.Items.Add("Basform");
            //        cbForms.Items.Add("Presens");
            //        cbForms.Items.Add("perfekt");
            //        cbForms.Items.Add("Efter verb");
            //    }
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            //    if (cbBook.Text == "" || cbForms.Text == "")
            //    {
            //        MessageBox.Show("Both options need to be chosen");
            //    }
            //    else
            //    {
            //        Custom newcombo = new Custom(cbBook.Text, cbBook.Text, cbForms.Text);
            //        list.choicesList.Add(newcombo);
            //    }

            //    tbxAdded.Text = "";
            //    foreach (Custom element in list.choicesList)
            //    {
            //        if (element.ToAddedTbx == "custom")
            //        {
            //            tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.CustomString}");
            //        }
            //        else
            //        {
            //            tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ToAddedTbx}");
            //        }
            //    }
        }

        private void btnAddNr_Click(object sender, EventArgs e)
        {
            //    Custom newcombo = new Custom("Nr", nupFrom.Value, nupTo.Value);
            //    list.choicesList.Add(newcombo);

            //    tbxAdded.Text = "";
            //    foreach (Custom element in list.choicesList)
            //    {
            //        if (element.ToAddedTbx == "custom")
            //        {
            //            tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.CustomString}");
            //        }
            //        else
            //        {
            //            tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ToAddedTbx}");
            //        }
            //    }
        }

        private void btnAddCustom_Click(object sender, EventArgs e)
        {
            //    if (tbxCustom.Text == "")
            //    {
            //        MessageBox.Show("Write some text in the textbox first.");
            //    }
            //    else
            //    {
            //        Custom newcombo = new Custom("custom", tbxCustom.Text.Trim());
            //        list.choicesList.Add(newcombo);
            //    }

            //    tbxAdded.Text = "";
            //    foreach (Custom element in list.choicesList)
            //    {
            //        if (element.ToAddedTbx == "custom")
            //        {
            //            tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.CustomString}");
            //        }
            //        else
            //        {
            //            tbxAdded.AppendText($"{(list.choicesList.IndexOf(element) == 0 ? "" : " + ")}{element.ToAddedTbx}");
            //        }
            //    }
        }

        private void nupFrom_ValueChanged(object sender, EventArgs e)
        {
            //    if (nupFrom.Value > nupTo.Value - 1) nupFrom.Value = nupTo.Value - 1;
        }

        private void nupTo_ValueChanged(object sender, EventArgs e)
        {
            //    if (nupFrom.Value > nupTo.Value - 1) nupTo.Value = nupFrom.Value + 1;
        }

        //string sparaPostVerb = "";

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";
            //    foreach (Custom element in list.choicesList)
            //    {
            //        if (element.WordClassChoice == "Adjektiv")
            //        {
            //            int rNr = r.Next(0, list.adjective.Count);
            //            if (element.FormChoice == "Singular")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.adjective[rNr].Singular()} ");
            //            }
            //            else if (element.FormChoice == "Plural")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.adjective[rNr].Plural()} ");
            //            }
            //            list.adjective.RemoveAt(rNr);
            //        }
            //        else if (element.WordClassChoice == "Substantiv - Något")
            //        {
            //            int rNr = r.Next(0, list.something.Count);

            //            if (element.FormChoice == "Singular")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.something[rNr].Singular()} ");
            //            }
            //            else if (element.FormChoice == "Plural")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.something[rNr].Plural()} ");
            //            }
            //            list.something.RemoveAt(rNr);
            //        }
            //        else if (element.WordClassChoice == "Skämtnamn" && element.FormChoice == "Name")
            //        {
            //            int rNr = r.Next(0, list.jokeName.Count);
            //            presentationWindow.tbxResult.AppendText($"{list.jokeName[rNr].Name()} ");
            //            list.jokeName.RemoveAt(rNr);
            //        }
            //        else if (element.WordClassChoice == "Substantiv - Någon")
            //        {
            //            int rNr = r.Next(0, list.someone.Count);

            //            if (element.FormChoice == "Singular")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.someone[rNr].Singular()} ");
            //            }
            //            else if (element.FormChoice == "Plural")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.someone[rNr].Plural()} ");
            //            }
            //            list.someone.RemoveAt(rNr);
            //        }
            //        else if (element.WordClassChoice == "Verb")
            //        {
            //            int rNr = r.Next(0, list.verb.Count);


            //            if (element.FormChoice == "Basform")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.verb[rNr].BasForm()} ");
            //                sparaPostVerb = list.verb[rNr].PostVerbs();
            //            }
            //            else if (element.FormChoice == "Presens")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.verb[rNr].Presens()} ");
            //                sparaPostVerb = list.verb[rNr].PostVerbs();
            //            }
            //            else if (element.FormChoice == "Perfekt")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{list.verb[rNr].Perfekt()} ");
            //                sparaPostVerb = list.verb[rNr].PostVerbs();
            //            }
            //            else if (element.FormChoice == "Efter verb")
            //            {
            //                presentationWindow.tbxResult.AppendText($"{(sparaPostVerb == "-" ? "" : $"{sparaPostVerb} ")}");
            //                if (presentationWindow.tbxResult.Text.Contains(" "))
            //                {
            //                    presentationWindow.tbxResult.Text = presentationWindow.tbxResult.Text.Replace("  ", " ");
            //                }
            //            }
            //            list.verb.RemoveAt(rNr);
            //        }
            //        else if (element.ToAddedTbx == "custom")
            //        {
            //            presentationWindow.tbxResult.AppendText($"{element.CustomString} ");
            //        }
            //        else if (element.ToAddedTbx == "Nr")
            //        {
            //            int rNr = r.Next(Convert.ToInt32(element.FromValue), Convert.ToInt32(element.ToValue));
            //            presentationWindow.tbxResult.AppendText($"{Convert.ToString(rNr)} ");
            //        }

            //        char firstLetter = presentationWindow.tbxResult.Text[0];
            //        string firstLetterStr = Convert.ToString(firstLetter);
            //        string theRest = presentationWindow.tbxResult.Text.Substring(1, presentationWindow.tbxResult.Text.Length - 1);

            //        presentationWindow.tbxResult.Text = $"{firstLetterStr.ToUpper()}{theRest}";

            //    }
            //    EndingRitual(5, presentationWindow.tbxResult, ref position);
        }

        private void btnCustomClear_Click(object sender, EventArgs e)
        {
            //    presentationWindow.tbxResult.Text = "";
            //    tbxCustom.Text = "";
            //    tbxAdded.Text = "";
            //    list.choicesList.Clear();
        }

        ////StringBuilder scene = new StringBuilder();
        ////string locationString = "";
        ////string relationString = "";
        ////string missionString = "";
        ////bool locationPressed = false;
        ////bool relationPressed = false;
        ////bool missionPressed = false;
        ////List<string> sceneitems = new List<string>();

        ////string WriteOut()
        ////{
        ////    scene.Clear();

        ////    if (sceneitems.Count == 1)
        ////    {
        ////        scene.Append(sceneitems[0]);
        ////    }
        ////    else if (sceneitems.Count == 2)
        ////    {
        ////        scene.Append($"{sceneitems[0]} och {sceneitems[1]}");
        ////    }
        ////    else if (sceneitems.Count == 3)
        ////    {
        ////        scene.Append($"{sceneitems[0]}, {sceneitems[1]} och {sceneitems[2]}");
        ////    }

        ////    return FixText.FirstLetterUpper(scene.ToString());
        ////}


        //
        // Metoder
        //

        public void EndingRitual(int loadNr, TextBox tb, ref int position)
        {
            Db.ResetUsed(loadNr);
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


        // ___________
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
            //    if (position <= 0)
            //    {

            //    }
            //    else
            //    {
            //        position--;
            //        presentationWindow.tbxResult.Text = list.results[position];
            //        FixText.AdjustSize(presentationWindow.tbxResult);
            //        // Vad händer när trycka på rensa?
            //    }
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    if (position >= list.results.Count - 1)
            //    {
            //    }
            //    else
            //    {
            //        position++;
            //        presentationWindow.tbxResult.Text = list.results[position];
            //        FixText.AdjustSize(presentationWindow.tbxResult);
            //    }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }


        // _______________
        // Tillfällig
        //

        private void button1_Click(object sender, EventArgs e)
        {
            tbxCustom.Text = Words.verb.RandomizeId().ToString();

        }
    }

}



