using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Headline_Randomizer
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            
            // Load settings
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["SuitableForChildren"].Value == "1")
            {
                cbxChildren.Checked = true;
            }
            else
            {
                cbxChildren.Checked = false;
            }

            if (config.AppSettings.Settings["SuitableForAdolescents"].Value == "1")
            {
                cbxAdolescents.Checked = true;
            }
            else
            {
                cbxAdolescents.Checked = false;
            }

            if (config.AppSettings.Settings["SuitableForAdults"].Value == "1")
            {
                cbxAdults.Checked = true;
            }
            else
            {
                cbxAdults.Checked = false;
            }

            if (config.AppSettings.Settings["SuitableForunoffendable"].Value == "1")
            {
                cbxUnoffendable.Checked = true;
            }
            else
            {
                cbxUnoffendable.Checked = false;
            }
            if (config.AppSettings.Settings["LoadFromBackup"].Value == "0")
            {
                btnLoadFromBackup.Enabled = false;
            }
            else
            {
                btnLoadFromBackup.Enabled = true;
            }

            // Create a key and value for the Tabell combobox. This enables the user
            // to choose for example "Adjektiv" but the code gets "TblAdjektiv" from that. 
            // Dictionaty helps with that first paremeter is key the other is value. 
            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("Adjektiv", "TblAdjectives");
            items.Add("Förskrivna uppdrag", "TblMissions");
            items.Add("Nobelpriser", "TblNobelPrizes");
            items.Add("Skämtnamn", "TblJokeNames");
            items.Add("Sparade resultat", "TblSavedResults");
            items.Add("Status", "TblStatus");
            items.Add("Substantiv", "TblNouns");
            items.Add("Verb", "TblVerbs");

            cbTabell.Items.Clear();

            // Connect combobox with the Dictionary "items" and decide whether the display member
            // or the value member is value or key. 
            cbTabell.DataSource = new BindingSource(items, null);
            cbTabell.DisplayMember = "Key";
            cbTabell.ValueMember = "Value";

            cbTabell.SelectionStart = 0;
            UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
            UpdateLables($"{GetQuery()}");
            UpdateUpdateValue();

        }

        //
        // Necessary variables
        //

        // Needed to stop the current cell from changing while updating the GridView.
        // This because of the current_cell_change event.
        bool updateInProgress = false;

        List<Mix> mix = new List<Mix>();
        List<Mix> location = new List<Mix>();

        //
        // Methods
        //


        public void UpdateUpdateValue()
        {
            switch (DbDisplay.Columns[Convert.ToInt32(numChangeColumn.Value)].HeaderText)
            {
                case "Lämpligt för":
                    cbUpdateValue.Items.Clear();
                    cbUpdateValue.Items.Add("Barn");
                    cbUpdateValue.Items.Add("Ungdomar");
                    cbUpdateValue.Items.Add("Vuxna");
                    cbUpdateValue.Items.Add("Okränkbara");
                    cbUpdateValue.Text = "Välj värde...";
                    break;

                case "Relation":
                    cbUpdateValue.Items.Clear();
                    cbUpdateValue.Items.Add("True");
                    cbUpdateValue.Items.Add("False");
                    cbUpdateValue.Text = "Välj värde...";
                    break;

                case "Genus":
                    cbUpdateValue.Items.Clear();
                    cbUpdateValue.Items.Add("N-genus");
                    cbUpdateValue.Items.Add("T-genus");
                    cbUpdateValue.Items.Add("T-undantag");
                    cbUpdateValue.Items.Add("N-undantag");
                    cbUpdateValue.Text = "Välj värde...";
                    break;

                case "Benämner":
                    cbUpdateValue.Items.Clear();
                    cbUpdateValue.Items.Add("Någon");
                    cbUpdateValue.Items.Add("Något");
                    cbUpdateValue.Items.Add("Plats");
                    cbUpdateValue.Items.Add("Någon & Plats");
                    cbUpdateValue.Items.Add("Någon & Något");
                    cbUpdateValue.Text = "Välj värde...";
                    break;

                case "Använt":
                    cbUpdateValue.Items.Clear();
                    cbUpdateValue.Items.Add("True");
                    cbUpdateValue.Items.Add("False");
                    cbUpdateValue.Text = "Välj värde...";
                    break;

                default:
                    cbUpdateValue.Items.Clear();
                    cbUpdateValue.Text = "Skriv in värde...";
                    break;
            }

        }

        // Spread out the textboxes in "add row" depending on the size of the window. 
        public void Reposition()
        {
            // Calculate how much room there should be between each textbox. 
            // The size of the groupbox minus the total amount of space the textboxes take up
            // devided with the numbers of gaps between them. 
            int x = (gbAddRow.Size.Width - (130 * 5)) / 6;

            // J is needed for the items who are positioned inthe lower row. 
            int j = 0;

            // The textboxes has been added to a list, go through all of them. 
            for (int i = 0; i < location.Count; i++)
            {
                // If the first item is uppdrag or namn then the second item needs more distance 
                // since the first item is longer than the others. 
                if (i == 1 && (location[i - 1].Label.Text == "Uppdrag" || location[i - 1].Label.Text == "Namn"))
                {
                    int plus = (x*2 + 260);
                    location[i].Location = new Point(x + plus, 45);
                    location[i].Label.Location = new Point((x + plus) - 4, 25);
                }

                // The first 5 items is at a specific y location. 
                else if (i < 5)
                {
                    // Size of gap plus size of textox times the number of the iteration. 
                    int plus = (x + 130) * i;

                    // This aligns the textboxes side by side with the exact same distance. 
                    // The first iteration only gives x since i is 0.
                    // The second iteration takes the distance of the first x, plus the size of the 
                    // first textbox plus a second x amount and puts the second textbox after that. 
                    location[i].Location = new Point(x + plus, 45);
                    location[i].Label.Location = new Point((x + plus) - 4, 25);
                }
                
                else
                {
                    // Times J because we don't want the second row next to the first row. 
                    int plus = (x + 130) * j;
                    location[i].Location = new Point(x + plus, 97);
                    location[i].Label.Location = new Point((x + plus) - 4, 77);
                    j++;
                }

            }
            btnAddRow.Location = new Point(x + ((x + 130) * 4), 81);
        }

        public void UpdateGridView(string query)
        {
            
            updateInProgress = true;
            using (SqlConnection connection = new SqlConnection(Db.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    // Remove all columns
                    DbDisplay.Columns.Clear();

                    // Add the needed nr of columns. Use reader.FieldCount to figure out the needed nr.  
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //I first need to create this object, whetever it is, to have something to add
                        // in Columns.Add. 
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.Frozen = true;
                        DbDisplay.Columns.Add(column);
                    }

                    // Add info to the GridView cells from the database.

                    // Creating an array because it opens for the loop solution below. 
                    // Before i used: string[] row = new string[reader.FieldCount]; but then when I tried to sort
                    // the id in the gridview, it got sorted in a weird way. Because it was a string. 
                    // This way I'm creating a string that isn't locked to one type. 
                    var row = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        // While there are rows... 
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            // ...Go through all the columns in the current row... the add to the array.
                            // Var to prepare the variable for different types of content. 
                            var addToColumn = reader.GetSqlValue(i);
                            row[i] = addToColumn;

                            // If it the first iteration of the loop (where the column headers would be empty)
                            // name the columns based on the names of the columns in the database. 
                            if (DbDisplay.Columns[i].HeaderText == "")
                            {
                                DbDisplay.Columns[i].HeaderText = reader.GetName(i);
                            }
                        }
                        // Add the current row to the gridview. Had I not used the array then I would have had to
                        // write a lot more code. One reason is that I'd have to specify the GetSqlValue().
                        DbDisplay.Rows.Add(row);

                    }
                    DbDisplay.Columns[0].Visible = false;
                    reader.Close();
                }
                // Don't forget to close the connection. It created problems before. 
                connection.Close();
                updateInProgress = false;

                // So that you can't enter a value that is less or more than the actual Nr of rows/columns.
                numDeleteRow.Maximum = DbDisplay.RowCount;
                numChangeRow.Maximum = DbDisplay.RowCount;
                numChangeColumn.Maximum = DbDisplay.ColumnCount;

            }
        }

        // Sees to that only the needed number of textboxes show under "Add value" and that their labels are correct.  
        public void UpdateLables(string query)
        {
            using (SqlConnection connection = new SqlConnection(Db.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    mix.Clear();
                    // All the items added to a list. 
                    mix.Add(new Mix("text", lblColumn1, tbxAddColumn1, new Point(20, 45)));
                    mix.Add(new Mix("text", lblColumn2, tbxAddColumn2, new Point(164, 45)));
                    mix.Add(new Mix("text", lblColumn3, tbxAddColumn3, new Point(307, 45)));
                    mix.Add(new Mix("text", lblColumn4, tbxAddColumn4, new Point(451, 45)));
                    mix.Add(new Mix("text", lblColumn5, tbxAddColumn5, new Point(594, 45)));
                    mix.Add(new Mix("Benämner", lblTermFor, cbTermFor, new Point(20, 97)));
                    mix.Add(new Mix("Genus", lblGenus, cbGenus, new Point(164, 97)));
                    mix.Add(new Mix("Relation", lblRelation, cbRelation, new Point(307, 97)));
                    mix.Add(new Mix("Lämpligt för", lblCensur, cbCensur, new Point(451, 97)));

                    //Hide all
                    foreach (Mix element in mix)
                    {
                        if (element.Name == "text")
                        {
                            element.Label.Hide();
                            element.TextBox.Hide();
                        }
                        else
                        {
                            element.Label.Hide();
                            element.ComboBox.Hide();
                        }
                    }

                    location.Clear();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // If just a textbox then add to list and give name
                        if (reader.GetDataTypeName(i) == "nvarchar" && (reader.GetName(i) != "Benämner" && reader.GetName(i) != "Genus"
                            && reader.GetName(i) != "Mening" && reader.GetName(i) != "Uppdrag" && reader.GetName(i) != "Namn"))
                        {
                            location.Add(mix[i]);
                            location[i].TextBox.Visible = true;
                            location[i].Label.Visible = true;
                            location[i].Label.Text = reader.GetName(i);
                            location[i].TextBox.Size = new Size(131, 27);

                        }

                        // If textbox is mening, uppdrag or namn, then make it bigger. 
                        else if (reader.GetDataTypeName(i) == "nvarchar" && reader.GetName(i) == "Mening" || reader.GetName(i) == "Uppdrag" || reader.GetName(i) == "Namn")
                        {
                            location.Add(mix[i]);
                            location[i].TextBox.Visible = true;
                            location[i].Label.Visible = true;
                            location[i].Label.Text = reader.GetName(i);
                            location[i].TextBox.Size = new Size(274, 27);
                        }

                        // If it's a combobox then go through the mixlist and compare with what the current column in the database is. 
                        // WHen there is a match then add to locaiton list. 
                        else if (reader.GetDataTypeName(i) != "nvarchar" || (reader.GetName(i) == "Benämner" || reader.GetName(i) == "Genus"))
                        {
                            for (int j = 0; j < mix.Count; j++)
                            {
                                if (reader.GetName(i) == mix[j].Name)
                                {
                                    location.Add(mix[j]);
                                    location[i].ComboBox.Visible = true;
                                    location[i].Label.Visible = true;
                                }
                            }
                            
                        }
                        else
                        {
                            mix[i].Label.Visible = false;
                            try { mix[i].TextBox.Visible = false; }
                            catch { mix[i].ComboBox.Visible = false; }
                        }
                    }

                    Reposition();

                    reader.Close();
                }

                connection.Close();
            }

        }

        public string GetQuery()
        {
            switch (cbTabell.SelectedValue.ToString())
            {
                case "TblAdjectives":
                    return "SELECT [N-genus], [T-genus], Plural, Preposition, [Relation], [Lämpligt för] FROM TblAdjectives";

                case "TblNouns":
                    return "SELECT [Singular obestämd], [Singular bestämd], Plural, Preposition, Benämner, Genus, [Lämpligt för] FROM TblNouns";

                case "TblVerbs":
                    return "SELECT Infinitiv, Uppmaning, Perfekt, Presens, Preposition, [Relation], [Lämpligt för] FROM TblVerbs";

                case "TblNobelPrizes":
                    return "SELECT Pris FROM TblNobelPrizes";

                case "TblJokeNames":
                    return "SELECT Namn, [Lämpligt för] FROM TblJokeNames";

                case "TblSavedResults":
                    return "SELECT Mening FROM TblSavedResults";

                case "TblMissions":
                    return "SELECT Uppdrag, [Lämpligt för] FROM TblMissions";

                case "TblStatus":
                    return "SELECT Högstatus, Lågstatus FROM TblStatus";

                default:
                    return "";
            }
        }


        //
        // Events
        //

        private void btnChangeValue_Click(object sender, EventArgs e)
        {
            if (cbUpdateValue.Text == "Välj värde...")
            {
                cbUpdateValue.BackColor = Color.Pink;
            }
            else
            {
                updateInProgress = true;

                string column = DbDisplay.Columns[Convert.ToInt32(numChangeColumn.Value)].HeaderText;
                string Id = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[0].Value.ToString();

                Db.Command($"UPDATE {cbTabell.SelectedValue.ToString()} SET [{column}] = '{cbUpdateValue.Text}' WHERE Id = '{Id}'", Db.connectionString);

                updateInProgress = false;
                UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");

                if (Convert.ToInt32(numChangeRow.Value) < DbDisplay.Rows.Count)
                {
                    DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value)].Cells[Convert.ToInt32(numChangeColumn.Value)];
                }
                else
                {
                    DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[Convert.ToInt32(numChangeColumn.Value)];
                }
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            updateInProgress = true;

            // Get the value of the first column on the specified row, then use it in the query string. 
            string Id = DbDisplay.Rows[Convert.ToInt32(numDeleteRow.Value) - 1].Cells[0].Value.ToString();
            Db.Command($"DELETE FROM {cbTabell.SelectedValue.ToString()} WHERE Id = '{Id}'", Db.connectionString);
            
            updateInProgress = false;
            UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");

            // If the number of total rows is less than the number of the specified row, then don't
            // select the row after (because there are none left)
            if (DbDisplay.Rows.Count < Convert.ToInt32(numChangeRow.Value))
            {
                DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 2].Cells[Convert.ToInt32(numChangeColumn.Value) - 1];
            }
            // If there are rows left, then move to the next row. 
            else
            {
                DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[Convert.ToInt32(numChangeColumn.Value) - 1];
            }
            
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            updateInProgress = true;

            switch (cbTabell.SelectedValue)
            {
                case "TblAdjectives":

                        Db.Command($"INSERT INTO TblAdjectives VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{cbRelation.Text}', '{cbCensur.Text}', 0)", Db.connectionString);
                    
                    break;

                case "TblNouns":

                        Db.Command($"INSERT INTO TblNouns VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{cbTermFor.Text}', '{cbGenus.Text}','{cbCensur.Text}', 0)", Db.connectionString);
                    
                    break;

                case "TblVerbs":

                        Db.Command($"INSERT INTO TblVerbs VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{tbxAddColumn5.Text}', '{cbRelation.Text}','{cbCensur.Text}', 0)", Db.connectionString);
                    
                    break;

                case "TblJokeNames":
                    Db.Command($"INSERT INTO TblJokeNames VALUES ('{tbxAddColumn1.Text}', '{cbCensur.Text}', 0)", Db.connectionString);
                    break;

                case "TblMissions":
                    Db.Command($"INSERT INTO TblMissions VALUES ('{tbxAddColumn1.Text}', '{cbCensur.Text}', 0)", Db.connectionString);
                    break;

                case "TblNobelPrizes":
                    Db.Command($"INSERT INTO TblNobelPrizes VALUES ('{tbxAddColumn1.Text}', 0)", Db.connectionString);
                    break;

                case "TblSavedResults":
                    Db.Command($"INSERT INTO TblSavedResults VALUES ('{tbxAddColumn1.Text}')", Db.connectionString);
                    break;

                case "TblStatus":
                    Db.Command($"INSERT INTO TblStatus VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}', 0)", Db.connectionString);
                    break;
            }
            updateInProgress = false;
            UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
        }

        // Get information about row and column index and put it in the textboxes for changing value and deleting row. 
        // But only if another process is not in progress. 
        private void DbDisplay_CurrentCellChanged(object sender, EventArgs e)
        {
            if (updateInProgress)
            {

            }
            else
            {
                if (DbDisplay.CurrentCell == null)
                {

                }
                else
                {
                    numChangeColumn.Value = DbDisplay.CurrentCell.ColumnIndex;
                    numChangeRow.Value = DbDisplay.CurrentCell.RowIndex + 1;
                    numDeleteRow.Value = DbDisplay.CurrentCell.RowIndex + 1;
                }
            }
        }

        private void btnResetDb_Click(object sender, EventArgs e)
        {
            string message = "Vill du återställa databasen till originalinnehållet? Om du klickar ja raderas alla användarens ändringar i databasen.";
            string title = "Meddelande";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Db.DefaultAll();
            }
            else
            {
             
            }
            
        }

        private void btnSaveToBackup_Click(object sender, EventArgs e)
        {
            string message = "Är du säker på att du vill säkerhetskopiera? Om du trycker ja skapas en kopia av hur databasen ser ut nu";
            string title = "Meddelande";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Db.SaveToBackup();
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["LoadFromBackup"].Value = "1";
                config.Save();
                btnLoadFromBackup.Enabled = true;
            }
            else
            {

            }
        }

        private void btnLoadFromBackup_Click(object sender, EventArgs e)
        {
            string message = "Är du säker på att du vill återställa databasen från din säkerhetskopiering?";
            string title = "Meddelande";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Db.LoadFromBackup();
            }
            else
            {

            }
            
        }

        private void cbTabell_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DbDisplay.CurrentCell = DbDisplay.Rows[0].Cells[1];
            UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
            UpdateLables($"{GetQuery()}");
            UpdateUpdateValue();
        }

        private void numChangeColumn_ValueChanged(object sender, EventArgs e)
        {
            UpdateUpdateValue();
        }

        private void cbUpdateValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUpdateValue.BackColor = Color.White;
        }

        private void cbUpdateValue_TextUpdate(object sender, EventArgs e)
        {
            // I don't want them to be able to type in a custom value if there are items in the combobox. 
            if (cbUpdateValue.Items.Count > 0)
            {
                cbUpdateValue.Text = "Välj värde...";
            }
            else { }
            
        }

        private void Options_SizeChanged(object sender, EventArgs e)
        {
            Options options = this;
            Reposition();
        }

        private void cbxChildren_CheckedChanged(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (cbxChildren.Checked)
            {
                config.AppSettings.Settings["SuitableForChildren"].Value = "1";
            }
            else
            {
                config.AppSettings.Settings["SuitableForChildren"].Value = "0";
            }
            config.Save();
        }

        private void cbxAdolescents_CheckedChanged(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (cbxAdolescents.Checked)
            {
                config.AppSettings.Settings["SuitableForAdolescents"].Value = "1";
            }
            else
            {
                config.AppSettings.Settings["SuitableForAdolescents"].Value = "0";
            }
            config.Save();
        }

        private void cbxAdults_CheckedChanged(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (cbxAdults.Checked)
            {
                config.AppSettings.Settings["SuitableForAdults"].Value = "1";
            }
            else
            {
                config.AppSettings.Settings["SuitableForAdults"].Value = "0";
            }
            config.Save();
        }

        private void cbxUnoffendable_CheckedChanged(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (cbxUnoffendable.Checked)
            {
                config.AppSettings.Settings["SuitableForunoffendable"].Value = "1";
            }
            else
            {
                config.AppSettings.Settings["SuitableForunoffendable"].Value = "0";
            }

            config.Save();
        }

    }

    public class Mix
    {
        protected string name;
        protected Label label;
        protected TextBox textBox;
        protected ComboBox comboBox;
        protected Point location;

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public Label Label
        {
            get { return label; }

            set { label = value; }
        }

        public TextBox TextBox
        {
            get { return textBox; }

            set { textBox = value; }
        }

        public ComboBox ComboBox
        {
            get { return comboBox; }

            set { comboBox = value; }
        }

        public Point Location
        {
            get { return location; }

            set
            {
                location = value;

                // When looping through objects it's tedious to have ifstatements to decide
                // if I can go Combobox.Location or Textbox.Location. If I do what I do here
                // then I can just go element.Location and this if-statement takes that info and
                // sets it to the right item. 
                if (this.name == "text")
                {
                    this.textBox.Location = location;
                }
                else
                {
                    this.comboBox.Location = location;
                }
            }
        }

        public Mix(string name, Label label, TextBox textBox, Point location)
        {
            this.name = name;
            this.label = label;
            this.textBox = textBox;
            this.location = location;
            // Set the location to the textbox. That way I don't have to know whether
            // it's a textbox or combobox. 
            this.textBox.Location = location;
        }

        public Mix(string name, Label label, ComboBox comboBox, Point location)
        {
            this.name = name;
            this.label = label;
            this.comboBox = comboBox;
            this.location = location;
            this.comboBox.Location = location;
        }
    }
}
