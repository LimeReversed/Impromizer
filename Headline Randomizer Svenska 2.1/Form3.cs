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
            
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["AllowRegular"].Value == "1")
            {
                cbxRegular.Checked = true;
            }
            else
            {
                cbxRegular.Checked = false;
            }

            if (config.AppSettings.Settings["AllowViolence"].Value == "1")
            {
                cbxViolence.Checked = true;
            }
            else
            {
                cbxViolence.Checked = false;
            }

            if (config.AppSettings.Settings["AllowSex"].Value == "1")
            {
                cbxSex.Checked = true;
            }
            else
            {
                cbxSex.Checked = false;
            }

            if (config.AppSettings.Settings["AllowOffensive"].Value == "1")
            {
                cbxOffensive.Checked = true;
            }
            else
            {
                cbxOffensive.Checked = false;
            }

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
            cbTabell.DataSource = new BindingSource(items, null);
            cbTabell.DisplayMember = "Key";
            cbTabell.ValueMember = "Value";

            //cbTabell.SelectionStart = 0;
            //UpdateGridView($"SELECT * FROM {cbTabell.SelectedValue.ToString()}");
            //UpdateLables($"{GetQuery()}");
            //UpdateUpdateValue();

        }

        //
        // Necessary variables
        //

        // Needed to stop the current cell from changing while updating the GridView.
        // This because of the current_cell_change event.
        bool updateInProgress = false;

        //
        // Methods
        //


        public void UpdateUpdateValue()
        {
            switch (DbDisplay.Columns[Convert.ToInt32(numChangeColumn.Value)].HeaderText)
            {
                case "Censurkategori":
                    cbUpdateValue.Items.Clear();
                    cbUpdateValue.Items.Add("0");
                    cbUpdateValue.Items.Add("1");
                    cbUpdateValue.Text = "Välj värde...";
                    break;

                case "Passar relation":
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

        public void UpdateGridView(string query) // Move to Db? It's language independent but can I make more sense of having it htere?
            // Would be more future proof. // Den tiden den sorgen?
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
                // Don't forget to cluse the connection. It created problems before. 
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

                    List<Mix> mix = new List<Mix>
                    {
                        new Mix("text", lblColumn1, tbxAddColumn1, new Point(20, 45)),
                        new Mix("text", lblColumn2, tbxAddColumn2, new Point(164, 45)),
                        new Mix("text", lblColumn3, tbxAddColumn3, new Point(307, 45)),
                        new Mix("text", lblColumn4, tbxAddColumn4, new Point(451, 45)),
                        new Mix("text", lblColumn5, tbxAddColumn5, new Point(594, 45)),
                        new Mix("Benämner", lblTermFor, cbTermFor, new Point(20, 97)),
                        new Mix("Genus", lblGenus, cbGenus, new Point(164, 97)),
                        new Mix("Passar relation", lblRelation, cbRelation, new Point(307, 97)),
                        new Mix("Censurkategori", lblCensur, cbCensur, new Point(451, 97)),
                    };

                    // Hide all
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

                    // Show the items specified in the query 
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.GetDataTypeName(i) == "nvarchar" && (reader.GetName(i) != "Benämner" && reader.GetName(i) != "Genus"))
                        {
                            mix[i].Label.Show();
                            mix[i].Label.Text = reader.GetName(i);
                            mix[i].TextBox.Show();
                            mix[i].TextBox.Size = reader.GetName(i) == "Mening" || reader.GetName(i) == "Uppdrag" ? new Size(274, 27) : new Size(130, 27);
                        }
                        else
                        {
                            for (int y = i; y < mix.Count; y++)
                            {
                                if (reader.GetName(i) == mix[y].Name)
                                {
                                    if (reader.GetName(i - 1) == "Uppdrag")
                                    {
                                        mix[y].ComboBox.Location = mix[i + 1].Location;
                                        mix[y].Label.Location = mix[i + 1].Label.Location;
                                        mix[y].Label.Show();
                                        mix[i].Label.Text = reader.GetName(i);
                                    }
                                    else
                                    {
                                        mix[i].Label.Show();
                                        mix[i].Label.Text = reader.GetName(i);
                                        mix[y].ComboBox.Location = mix[i].Location;
                                    }
                                    mix[y].ComboBox.Visible = true;
                                }
                                else { }
                            }
                            
                        }
                    }

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
                    return "SELECT [N-genus], [T-genus], Plural, Preposition, [Passar relation], Censurkategori FROM TblAdjectives";

                case "TblNouns":
                    return "SELECT [Singular obestämd], [Singular bestämd], Plural, Preposition, Benämner, Genus, Censurkategori FROM TblNouns";

                case "TblVerbs":
                    return "SELECT Infinitiv, Uppmaning, Perfekt, Presens, Preposition, [Passar relation], Censurkategori FROM TblVerbs";

                case "TblNobelPrizes":
                    return "SELECT Pris FROM TblNobelPrizes";

                case "TblJokeNames":
                    return "SELECT Namn, Censurkategori FROM TblJokeNames";

                case "TblSavedResults":
                    return "SELECT Mening FROM TblSavedResults";

                case "TblMissions":
                    return "SELECT Uppdrag, Censurkategori FROM TblMissions";

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
                // No -1 on column because ID is hidden so I've constructed tbxcolumn to think the second is the first. 
                string column = DbDisplay.Columns[Convert.ToInt32(numChangeColumn.Value)].HeaderText;
                string Id = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[0].Value.ToString();

                if (column == "Censurkategori")
                {
                    if (!short.TryParse(cbUpdateValue.Text, out short result) || result > 2 || result < 0)
                    {
                        MessageBox.Show("Censor level kan bara bestå av ett värde från 0 - 2");
                    }
                    else
                    {
                        Db.Command($"UPDATE {cbTabell.SelectedValue.ToString()} SET [{column}] = '{result}' WHERE Id = '{Id}'");
                    }
                }
                else
                {
                    Db.Command($"UPDATE {cbTabell.SelectedValue.ToString()} SET [{column}] = '{cbUpdateValue.Text}' WHERE Id = '{Id}'");
                }


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
            Db.Command($"DELETE FROM {cbTabell.SelectedValue.ToString()} WHERE Id = '{Id}'");
            
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
                        $"'{tbxAddColumn4.Text}', '{cbRelation.Text}', '{cbCensur.Text}', 0)");
                    
                    break;

                case "TblNouns":

                        Db.Command($"INSERT INTO TblNouns VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{cbTermFor.Text}', '{cbGenus.Text}','{cbCensur.Text}', 0)");
                    
                    break;

                case "TblVerbs":

                        Db.Command($"INSERT INTO TblVerbs VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{tbxAddColumn5.Text}', {cbRelation.Text},'{cbCensur.Text}', 0)");
                    
                    break;

                case "TblJokeNames":
                    Db.Command($"INSERT INTO TblJokeNames VALUES ('{tbxAddColumn1.Text}', '{cbCensur.Text}', 0)");
                    break;

                case "TblMissions":
                    Db.Command($"INSERT INTO TblMissions VALUES ('{tbxAddColumn1.Text}', '{cbCensur.Text}', 0)");
                    break;

                case "TblNobelPrizes":
                    Db.Command($"INSERT INTO TblNobelPrizes VALUES ('{tbxAddColumn1.Text}', 0)");
                    break;

                case "TblSavedResults":
                    Db.Command($"INSERT INTO TblSavedResults VALUES ('{tbxAddColumn1.Text}')");
                    break;

                case "TblStatus":
                    Db.Command($"INSERT INTO TblStatus VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}', 0)");
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
            Db.DefaultAll();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (cbxRegular.Checked)
            {
                config.AppSettings.Settings["AllowRegular"].Value = "1";
            }
            else
            {
                config.AppSettings.Settings["AllowRegular"].Value = "0";
            }

            if (cbxViolence.Checked)
            {
                config.AppSettings.Settings["AllowViolence"].Value = "1";
            }
            else
            {
                config.AppSettings.Settings["AllowViolence"].Value = "0";
            }

            if (cbxSex.Checked)
            {
                config.AppSettings.Settings["AllowSex"].Value = "1";
            }
            else
            {
                config.AppSettings.Settings["AllowSex"].Value = "0";
            }

            if (cbxOffensive.Checked)
            {
                config.AppSettings.Settings["AllowOffensive"].Value = "1";
            }
            else
            {
                config.AppSettings.Settings["AllowOffensive"].Value = "0";
            }

            config.Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (cbUpdateValue.Items.Count > 0)
            {
                cbUpdateValue.Text = "Välj värde...";
            }
            else { }
            
        }

        private void Options_SizeChanged(object sender, EventArgs e)
        {
            int x = (gbAddRow.Size.Width - (130 * 5)) / 6;
            tbxAddColumn1.Location = new Point(x, 45);
            lblColumn1.Location = new Point(tbxAddColumn1.Location.X - 4, 25);
            tbxAddColumn2.Location = new Point(tbxAddColumn1.Location.X + 130 + x, 45);
            lblColumn2.Location = new Point(tbxAddColumn2.Location.X - 4, 25);
            tbxAddColumn3.Location = new Point(tbxAddColumn2.Location.X + 130 + x, 45);
            lblColumn3.Location = new Point(tbxAddColumn3.Location.X - 4, 25);
            tbxAddColumn4.Location = new Point(tbxAddColumn3.Location.X + 130 + x, 45);
            lblColumn4.Location = new Point(tbxAddColumn4.Location.X - 4, 25);
            tbxAddColumn5.Location = new Point(tbxAddColumn4.Location.X + 130 + x, 45);
            lblColumn5.Location = new Point(tbxAddColumn5.Location.X - 4, 25);

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

            set { location = value; }
        }

        public Mix(string name, Label label, TextBox textBox, Point location)
        {
            this.name = name;
            this.label = label;
            this.textBox = textBox;
            this.location = location;
        }

        public Mix(string name, Label label, ComboBox comboBox, Point location)
        {
            this.name = name;
            this.label = label;
            this.comboBox = comboBox;
            this.location = location;
        }
    }
}
