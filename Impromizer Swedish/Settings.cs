using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svenska;

namespace Headline_Randomizer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            // Load settings

            switch (Config.GetRegValue("SuitableForChildren", "1"))
            {
                case "1":
                    cbxChildren.Checked = true;
                    break;
                default:
                    cbxChildren.Checked = false;
                    break;
            }

            switch (Config.GetRegValue("SuitableForAdolescents", "1"))
            {
                case "1":
                    cbxAdolescents.Checked = true;
                    break;
                default:
                    cbxAdolescents.Checked = false;
                    break;
            }

            switch (Config.GetRegValue("SuitableForAdults", "1"))
            {
                case "1":
                    cbxAdults.Checked = true;
                    break;
                default:
                    cbxAdults.Checked = false;
                    break;
            }

            switch (Config.GetRegValue("SuitableForunoffendable", "0"))
            {
                case "1":
                    cbxUnoffendable.Checked = true;
                    break;
                default:
                    cbxUnoffendable.Checked = false;
                    break;
            }

            //if (config.AppSettings.Settings["LoadFromBackup"].Value == "0")
            //{
            //    btnLoadFromBackup.Enabled = false;
            //}
            //else
            //{
            //    btnLoadFromBackup.Enabled = true;
            //}

            // Create a key and value for the Tabell combobox. This enables the user
            // to choose for example "Adjektiv" but the code gets "TblAdjektiv" from that. 
            // Dictionaty helps with that first paremeter is key the other is value. 

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("Adjektiv", "TblAdjectives");
            //items.Add("Förskrivna uppdrag", "TblMissions");
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

            cbTermFor.SelectedIndex = 0;
            cbGenus.SelectedIndex = 0;
            cbRelation.SelectedIndex = 1;
            cbCensur.SelectedIndex = 0;
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

        // Vissa textboxar ska vara större ibland. Denna metod ser till att det är rätt. 
        private Size GetRequiredSize(string columnName)
        {
            List<string> plusSizedColumns = new List<string> {"Mening", "Uppdrag", "Namn"};
            Size size = new Size(131, 27);

            foreach (string element in plusSizedColumns)
            {
                if (columnName == element)
                {
                    size = new Size(274, 27);
                }
            }
       
            return size;
        } 

        // Kollar om columnen kräver en Combobox eller inte. 
        static public bool RequiresComboBox(string item)
        {
            List<string> ComboBoxItems = new List<string> { "Benämner", "Genus", "Passar", "Lämpligt för"};
            bool result = false;

            foreach (string element in ComboBoxItems)
            {
                if (item == element)
                {
                    result = true;
                }
            }

            return result;
        }

        // Behöver en metod som uppdaterar comboboxen som används för att ändra ett värde i databasen. 
        // Det behövs ibland förvalda alternativ så att det blir exakt rätt text. 
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

                case "Passar":
                    cbUpdateValue.Items.Clear();
                    cbUpdateValue.Items.Add("Någon (Strikt)");
                    cbUpdateValue.Items.Add("Någon");
                    cbUpdateValue.Items.Add("Relation");
                    cbUpdateValue.Items.Add("Relation (Strikt)");
                    cbUpdateValue.Items.Add("Relation & Något");
                    cbUpdateValue.Items.Add("Någon & Något");
                    cbUpdateValue.Items.Add("Något");
                    cbUpdateValue.Items.Add("Något (Strikt)");
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

            // J is needed for the items who are positioned in the lower row. 
            int j = 0;

            // The textboxes has been added to a list, go through all of them. 
            for (int i = 0; i < location.Count; i++)
            {
                // If the first item is uppdrag or namn then the second item needs more distance 
                // since the first item is longer than the others. 
                if (i == 1 && (location[i - 1].Label.Text == "Uppdrag" || location[i - 1].Label.Text == "Namn"))
                {
                    int plus = (x * 2 + 260);
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
            using (SQLiteConnection connection = new SQLiteConnection(Db.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    SQLiteDataReader reader = command.ExecuteReader();

                    // Remove all columns
                    DbDisplay.Columns.Clear();

                    // Add the needed nr of columns. Use reader.FieldCount to figure out the needed nr.  
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //I first need to create this object, whetever it is, to have something to add
                        // in Columns.Add. 
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.Frozen = true;
                        column.Name = reader.GetName(i);
                        column.HeaderText = reader.GetName(i);
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
                            var addToColumn = reader.GetValue(i);
                            row[i] = addToColumn;
                        }
                        // Add the current row to the gridview. Had I not used the array then I would have had to
                        // write a lot more code. One reason is that I'd have to specify the GetSqlValue().
                        DbDisplay.Rows.Add(row);

                    }
                    DbDisplay.Columns[0].Visible = false;
                    DbDisplay.Columns[DbDisplay.Columns.Count - 1].Visible = false;
                    DbDisplay.Columns[DbDisplay.Columns.Count - 2].Visible = false;
                    reader.Close();
                }
                // Don't forget to close the connection. It created problems before. 
                connection.Close();
                updateInProgress = false;

                // So that you can't enter a value that is less or more than the actual Nr of rows/columns.
                numDeleteRow.Maximum = DbDisplay.RowCount;
                numChangeRow.Maximum = DbDisplay.RowCount;
                // There are always three hidden columns
                numChangeColumn.Maximum = DbDisplay.ColumnCount - 3;
                numWriteColumn.Maximum = DbDisplay.ColumnCount - 3;

            }
        }

        // Sees to that only the needed number of textboxes show under "Add value" and that their labels are correct.  
        public void UpdateLables(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Db.connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    SQLiteDataReader reader = command.ExecuteReader();

                    mix.Clear();
                    // All the items added to a list. 
                    mix.Add(new Mix(lblColumn1, tbxAddColumn1, new Point(20, 45)));
                    mix.Add(new Mix(lblColumn2, tbxAddColumn2, new Point(164, 45)));
                    mix.Add(new Mix(lblColumn3, tbxAddColumn3, new Point(307, 45)));
                    mix.Add(new Mix(lblColumn4, tbxAddColumn4, new Point(451, 45)));
                    mix.Add(new Mix(lblColumn5, tbxAddColumn5, new Point(594, 45)));
                    mix.Add(new Mix(lblTermFor, cbTermFor, new Point(20, 97)));
                    mix.Add(new Mix(lblGenus, cbGenus, new Point(164, 97)));
                    mix.Add(new Mix(lblRelation, cbRelation, new Point(307, 97)));
                    mix.Add(new Mix(lblCensur, cbCensur, new Point(451, 97)));

                    //Hide all
                    foreach (Mix element in mix)
                    {
                        element.Label.Visible = false;
                        try { element.TextBox.Visible = false; }
                        catch { element.ComboBox.Visible = false; }
                    }

                    location.Clear();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // If just a textbox then add to list and give name
                        if (!RequiresComboBox(reader.GetName(i)))
                        {
                            location.Add(mix[i]);
                            location[i].TextBox.Visible = true;
                            location[i].Label.Visible = true;
                            location[i].Label.Text = reader.GetName(i);
                            location[i].TextBox.Size = GetRequiredSize(reader.GetName(i));

                        }

                        // If it's a combobox then go through the mixlist and compare with what the current column in the database is. 
                        // WHen there is a match then add to locaiton list. 
                        else if (RequiresComboBox(reader.GetName(i)))
                        {
                            for (int j = 0; j < mix.Count; j++)
                            {
                                if (reader.GetName(i) == mix[j].Label.Text)
                                {
                                    location.Add(mix[j]);
                                    location[i].ComboBox.Visible = true;
                                    location[i].Label.Visible = true;
                                }
                            }
                        }
                    }
                    reader.Close();
                }
                connection.Close();
            }
            Reposition();
        }

        public string GetQuery()
        {
            switch (cbTabell.SelectedValue.ToString())
            {
                case "TblAdjectives":
                    return "SELECT [N-genus], [T-genus], Plural, Preposition, [Passar], [Lämpligt för] FROM TblAdjectives";

                case "TblNouns":
                    return "SELECT [Singular obestämd], [Singular bestämd], Plural, Preposition, Benämner, Genus, [Lämpligt för] FROM TblNouns";

                case "TblVerbs":
                    return "SELECT Infinitiv, Uppmaning, Perfekt, Presens, Preposition, [Passar], [Lämpligt för] FROM TblVerbs";

                case "TblNobelPrizes":
                    return "SELECT Pris, [Lämpligt för] FROM TblNobelPrizes";

                case "TblJokeNames":
                    return "SELECT Namn, [Lämpligt för] FROM TblJokeNames";

                case "TblSavedResults":
                    return "SELECT Mening FROM TblSavedResults";

                case "TblMissions":
                    return "SELECT Uppdrag, [Lämpligt för] FROM TblMissions";

                case "TblStatus":
                    return "SELECT Högstatus, Lågstatus, [Lämpligt för] FROM TblStatus";

                default:
                    return "";
            }
        }

        // DbDisplay.Sort() två oarametrar varav en är av typen ListSortDirection som parametrar. 
        //Men det går bara att ta reda på befintlig sorteringsriktning som typen SortOrder. 
        // Den här metoden omvandlar till typen som Sort() behöver. 
        private ListSortDirection GetSortOrder(SortOrder order)
        {
            ListSortDirection direction = 0;

            switch (order)
            {
                case SortOrder.Ascending:
                    direction = ListSortDirection.Ascending;
                    break;

                case SortOrder.Descending:
                    direction = ListSortDirection.Descending;
                    break;
            }

            return direction;
        }


        //
        // Events
        //

        private void btnChangeValue_Click(object sender, EventArgs e)
        {
            if (cbUpdateValue.Text == "Välj värde..." || cbUpdateValue.Text == "Skriv in värde...")
            {
                cbUpdateValue.BackColor = Color.Pink;
            }
            else
            {
                cbUpdateValue.BackColor = Color.White;
                updateInProgress = true;
                string columnName = DbDisplay.SortedColumn == null ? "Id" : DbDisplay.SortedColumn.Name;
                SortOrder order = DbDisplay.SortOrder;
                ListSortDirection direction = GetSortOrder(order);

                string column = DbDisplay.Columns[Convert.ToInt32(numChangeColumn.Value)].HeaderText;
                string Id = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[0].Value.ToString();

                Db.Command($"UPDATE {cbTabell.SelectedValue.ToString()} SET [{column}] = '{cbUpdateValue.Text}', Version = 0 WHERE Id = '{Id}'", Db.connectionString);

                updateInProgress = false;
                UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
                DbDisplay.Sort(DbDisplay.Columns[columnName], direction);

                if (Convert.ToInt32(numChangeRow.Value) < DbDisplay.Rows.Count)
                {
                    DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value)].Cells[Convert.ToInt32(numChangeColumn.Value)];
                }
                else
                {
                    DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[Convert.ToInt32(numChangeColumn.Value)];
                }
                Db.Command("UPDATE TblVersion SET Modified = 1", Db.connectionString);
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {

            string columnName = DbDisplay.SortedColumn == null ? "Id" : DbDisplay.SortedColumn.Name;
            SortOrder order = DbDisplay.SortOrder;
            ListSortDirection direction = GetSortOrder(order);


            // Kolla att dbdiplay lämpligt för är barn och räkna bara barn i query för det är bara då jag vill att den ska reagera annars kan den ta bort. 

            // Target column
            int tC = DbDisplay.ColumnCount - 3;
            string message = "Det måste finnas minst 2 av typen av ord som du försöker ta bort";

            if (cbTabell.SelectedValue == "TblAdjectives" && DbDisplay.Rows[(Int32)numDeleteRow.Value - 1].Cells[tC].Value.ToString() == "Barn"
                                            && Convert.ToInt32(Db.GetValue($"SELECT COUNT(*) FROM TblAdjectives WHERE Passar = '{DbDisplay.Rows[(Int32)numDeleteRow.Value - 1].Cells[tC - 1].Value.ToString()}'", Db.connectionString)) < 3)
            {
                MessageBox.Show(message);
            }

            else if (cbTabell.SelectedValue == "TblVerbs" && DbDisplay.Rows[(Int32)numDeleteRow.Value - 1].Cells[tC].Value.ToString() == "Barn"
                                            && Convert.ToInt32(Db.GetValue($"SELECT COUNT(*) FROM TblVerbs WHERE Passar = '{DbDisplay.Rows[(Int32)numDeleteRow.Value - 1].Cells[tC - 1].Value.ToString()}'", Db.connectionString)) < 3)
            {
                MessageBox.Show(message);
            }

            else if (cbTabell.SelectedValue == "TblNouns" && DbDisplay.Rows[(Int32)numDeleteRow.Value - 1].Cells[tC].Value.ToString() == "Barn"
                                            && Convert.ToInt32(Db.GetValue($"SELECT COUNT(*) FROM TblNouns WHERE Benämner = '{DbDisplay.Rows[(Int32)numDeleteRow.Value - 1].Cells[tC - 2].Value.ToString()}'", Db.connectionString)) < 3)
            {
                MessageBox.Show(message);
            }

            else if (DbDisplay.Rows[(Int32)numDeleteRow.Value - 1].Cells[tC].Value.ToString() == "Barn" && Convert.ToInt32(Db.GetValue($"SELECT COUNT(*) FROM {cbTabell.SelectedValue}", Db.connectionString)) < 3)
            {
                MessageBox.Show(message);
            }

            else
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
                    DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 2].Cells[Convert.ToInt32(numChangeColumn.Value)];
                }
                // If there are rows left, then move to the next row. 
                else
                {
                    DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[Convert.ToInt32(numChangeColumn.Value)];
                }

                Db.Command("UPDATE TblVersion SET Modified = 1", Db.connectionString);
               
            }
            DbDisplay.Sort(DbDisplay.Columns[columnName], direction);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Db.GetValue($"SELECT COUNT(*) FROM {cbTabell.SelectedValue}", Db.connectionString)) > 999)
            {
                MessageBox.Show("Det går inte att lägga till fler ord i den här tabellen");
            }
            else
            {
                updateInProgress = true;

                string columnName = DbDisplay.SortedColumn.Name == null ? "Id" : DbDisplay.SortedColumn.Name;
                SortOrder order = DbDisplay.SortOrder;
                ListSortDirection direction = GetSortOrder(order);

                switch (cbTabell.SelectedValue)
                {
                    case "TblAdjectives":

                        Db.Command($"INSERT INTO TblAdjectives ([N-genus], [T-genus], Plural, Preposition, Passar, [Lämpligt för], Använt, Version) " +
                            $"VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{cbRelation.Text}', '{cbCensur.Text}', 0, 0)", Db.connectionString);

                        break;

                    case "TblNouns":

                        if (cbGenus.Text == "")
                        {

                        }
                        else
                        {
                            Db.Command($"INSERT INTO TblNouns ([Singular obestämd], [Singular bestämd], Plural, Preposition, Benämner, Genus, [Lämpligt för], " +
                                $"Använt, Version) VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                            $"'{tbxAddColumn4.Text}', '{cbTermFor.Text}', '{cbGenus.Text}','{cbCensur.Text}', 0, 0)", Db.connectionString);
                        }

                        break;

                    case "TblVerbs":

                        Db.Command($"INSERT INTO TblVerbs (Infinitiv, Uppmaning, Perfekt, Presens, Preposition, Passar, [Lämpligt för], Använt, Version)" +
                            $"VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{tbxAddColumn5.Text}', '{cbRelation.Text}','{cbCensur.Text}', 0, 0)", Db.connectionString);

                        break;

                    case "TblJokeNames":
                        Db.Command($"INSERT INTO TblJokeNames (Namn, [Lämpligt för], Använt, Version) " +
                            $"VALUES ('{tbxAddColumn1.Text}', '{cbCensur.Text}', 0, 0)", Db.connectionString);
                        break;

                    case "TblMissions":
                        Db.Command($"INSERT INTO TblMissions (Uppdrag, [Lämpligt för], Använt, Version)" +
                            $"VALUES ('{tbxAddColumn1.Text}', '{cbCensur.Text}', 0, 0)", Db.connectionString);
                        break;

                    case "TblNobelPrizes":
                        Db.Command($"INSERT INTO TblNobelPrizes (Pris, [Lämpligt för], Använt, Version) VALUES ('{tbxAddColumn1.Text}','{cbCensur.Text}', 0, 0)", Db.connectionString);
                        break;

                    case "TblSavedResults":
                        Db.Command($"INSERT INTO TblSavedResults (Mening, Version) VALUES ('{tbxAddColumn1.Text}', 0)", Db.connectionString);
                        break;

                    case "TblStatus":
                        Db.Command($"INSERT INTO TblStatus (Högstatus, Lågstatus, [Lämpligt för], Använt, Version) " +
                            $"VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}', '{cbCensur.Text}', 0, 0)", Db.connectionString);
                        break;
                }
                updateInProgress = false;
                UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
                DbDisplay.Sort(DbDisplay.Columns[columnName], direction);
                Db.Command("UPDATE TblVersion SET Modified = 1", Db.connectionString);
            }
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
                    numWriteColumn.Value = DbDisplay.CurrentCell.ColumnIndex;
                    numChangeRow.Value = DbDisplay.CurrentCell.RowIndex + 1;
                    numDeleteRow.Value = DbDisplay.CurrentCell.RowIndex + 1;
                }
            }
        }

        private void btnResetDb_Click(object sender, EventArgs e)
        {
            pBarDatabase.Value = 0;
            lblKlar.Visible = false;
            string message = "Vill du återställa databasen till originalinnehållet? Om du klickar ja raderas alla användarens ändringar i databasen.";
            string title = "Meddelande";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                Db.DefaultAll(pBarDatabase);
                UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
                pBarDatabase.Value = 100;
                lblKlar.Visible = true;
            }
            else
            {

            }

        }

        private void btnSaveToBackup_Click(object sender, EventArgs e)
        {
            pBarDatabase.Value = 0;
            lblKlar.Visible = false;
            string message = "Är du säker på att du vill säkerhetskopiera? Om du trycker ja skapas en kopia av hur databasen ser ut nu";
            string title = "Meddelande";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Db.SaveToBackup(pBarDatabase);
                //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.AppSettings.Settings["LoadFromBackup"].Value = "1";
                //config.Save();
                //btnLoadFromBackup.Enabled = true;
                UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
                pBarDatabase.Value = 100;
                lblKlar.Visible = true;
            }
            else
            {

            }
        }

        private void btnLoadFromBackup_Click(object sender, EventArgs e)
        {
            pBarDatabase.Value = 0;
            lblKlar.Visible = false;
            string message = "Är du säker på att du vill återställa databasen från din säkerhetskopiering?";
            string title = "Meddelande";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Db.LoadFromBackup(pBarDatabase);
                UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
                pBarDatabase.Value = 100;
                lblKlar.Visible = true;
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
            Settings settings = this;
            Reposition();
        }

        private void cbxChildren_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxChildren.Checked)
            {
                Config.SaveRegValue("SuitableForChildren", "1");
            }
            else
            {
                Config.SaveRegValue("SuitableForChildren", "0");
            }

            Words.idQueries = Words.UpdateIdQueries();
            Words.resetQueries = Words.UpdateResetQueries();
            Words.FreeNeeded(1000);
        }

        private void cbxAdolescents_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAdolescents.Checked)
            {
                Config.SaveRegValue("SuitableForAdolescents", "1");
            }
            else
            {
                Config.SaveRegValue("SuitableForAdolescents", "0");
            }

            Words.idQueries = Words.UpdateIdQueries();
            Words.resetQueries = Words.UpdateResetQueries();
            Words.FreeNeeded(1000);
        }

        private void cbxAdults_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAdults.Checked)
            {
                Config.SaveRegValue("SuitableForAdults", "1");
            }
            else
            {
                Config.SaveRegValue("SuitableForAdults", "0");
            }

            Words.idQueries = Words.UpdateIdQueries();
            Words.resetQueries = Words.UpdateResetQueries();
            Words.FreeNeeded(1000);
        }

        private void cbxUnoffendable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUnoffendable.Checked)
            {
                Config.SaveRegValue("SuitableForunoffendable", "1");
            }
            else
            {
                Config.SaveRegValue("SuitableForunoffendable", "0");
            }

            Words.idQueries = Words.UpdateIdQueries();
            Words.resetQueries = Words.UpdateResetQueries();
            Words.FreeNeeded(1000);
        }

        private void NumDeleteRow_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnSaveToTxt_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName == "")
            {

            }
            else
            {
                StreamWriter writer = new StreamWriter($"{saveFileDialog1.FileName}", false, Encoding.UTF8);

                using (SQLiteConnection connection = new SQLiteConnection(Db.connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand($"SELECT * FROM {cbTabell.SelectedValue}", connection))
                    {
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            writer.WriteLine(reader.GetValue((Int32)numWriteColumn.Value).ToString());
                        }


                        reader.Close();
                        connection.Close();
                        writer.Close();

                    }
                }
                MessageBox.Show("Filen sparades");
            }
        }

     
        private void NumChangeRow_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CbTabell_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class Mix
    {
        protected Label label;
        protected TextBox textBox;
        protected ComboBox comboBox;
        protected Point location;

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
                if (!Settings.RequiresComboBox(this.label.Text))
                {
                    this.textBox.Location = location;
                }
                else
                {
                    this.comboBox.Location = location;
                }
            }
        }

        public Mix(Label label, TextBox textBox, Point location)
        {
            this.label = label;
            this.textBox = textBox;
            this.location = location;
            // Set the location to the textbox. That way I don't have to know whether
            // it's a textbox or combobox. 
            this.textBox.Location = location;
        }

        public Mix(Label label, ComboBox comboBox, Point location)
        {
            this.label = label;
            this.comboBox = comboBox;
            this.location = location;
            this.comboBox.Location = location;
        }
    }
}
