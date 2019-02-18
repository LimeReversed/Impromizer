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

namespace Headline_Randomizer
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
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

        public void UpdateGridView(string query)
        {
            updateInProgress = true;
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename = E:\Tresorit\Headline Randomizer\Headline Randomizer\Headline Randomizer Svenska 2.1\WordsDatabase.mdf; Integrated Security=True"))
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
                        DbDisplay.Columns.Add(column);
                    }

                    // Add info to the GridView cells from the database.

                    // Creating an array because it opens for the loop solution below. 
                    string[] row = new string[reader.FieldCount];
                    while (reader.Read())
                    {
                        // While there are rows... 
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            // ...Go through all the columns in the current row... the add to the array.
                            string addToColumn = reader.GetSqlValue(i).ToString();
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
                    reader.Close();
                }
                // Don't forget to cluse the connection. It created problems before. 
                connection.Close();
                updateInProgress = false;

                numDeleteRow.Maximum = DbDisplay.RowCount;
                numChangeRow.Maximum = DbDisplay.RowCount;
                numChangeColumn.Maximum = DbDisplay.ColumnCount;

            }
        }

        // Sees to that only the needed number of textboxes show under "Add value" and that their labels are correct.  
        public void UpdateLables(string query)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Tresorit\Headline Randomizer\Headline Randomizer\Headline Randomizer Svenska 2.1\WordsDatabase.mdf;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    // Create a list for labels and textboxes and stick them in there.
                    // That way you have them in order and can loop through them. 
                    List<Label> Lables = new List<Label>();
                    Lables.Add(lblColumn1);
                    Lables.Add(lblColumn2);
                    Lables.Add(lblColumn3);
                    Lables.Add(lblColumn4);
                    Lables.Add(lblColumn5);
                    Lables.Add(lblColumn6);
                    Lables.Add(lblColumn7);
                    Lables.Add(lblColumn8);
                    Lables.Add(lblColumn9);

                    List<TextBox> TextBoxes = new List<TextBox>();
                    TextBoxes.Add(tbxAddColumn1);
                    TextBoxes.Add(tbxAddColumn2);
                    TextBoxes.Add(tbxAddColumn3);
                    TextBoxes.Add(tbxAddColumn4);
                    TextBoxes.Add(tbxAddColumn5);
                    TextBoxes.Add(tbxAddColumn6);
                    TextBoxes.Add(tbxAddColumn7);
                    TextBoxes.Add(tbxAddColumn8);
                    TextBoxes.Add(tbxAddColumn9);

                    // Hide all
                    for (int i = 0; i < 9; i++)
                    {
                        Lables[i].Hide();
                        TextBoxes[i].Hide();
                    }

                    // Show and name only a specified number of objects in the lists. 
                    for (int i = 0; i < reader.FieldCount - 2; i++)
                    {
                        TextBoxes[i].Show();
                        Lables[i].Show();
                        Lables[i].Text = reader.GetName(i + 1);
                    }
                    reader.Close();
                }
                
                connection.Close();
            }

        }

        public string GetTableName()
        {
            switch (cbTabell.Text)
            {
                case "Adjektiv":
                case "Adjectives":
                    return "TblAdjective";

                case "Substantiv":
                case "Nouns":
                    return "TblNouns";

                case "Verb":
                case "Verbs":
                    return "TblVerb";

                case "Nobel priser":
                case "Nobel prizes":
                    return "TblNobelPrizes";

                case "Skämtnamn":
                case "Joke names":
                    return "TblJokeNames";

                default:
                    return "";
            }
        }


        //
        // Events
        //

        private void cbTabell_Changed(object sender, EventArgs e)
        {
                    UpdateGridView($"SELECT * FROM {GetTableName()}");
                    UpdateLables($"SELECT * FROM {GetTableName()}");
        }

        private void btnChangeValue_Click(object sender, EventArgs e)
        {

            updateInProgress = true;
            //string column = DbDisplay.Columns[Convert.ToInt32(tbxChangeColumn.Text) - 1].HeaderText;
            string column = DbDisplay.Columns[Convert.ToInt32(numChangeColumn.Value) - 1].HeaderText;
            //string Id = DbDisplay.Rows[Convert.ToInt32(tbxChangeRow.Text) - 1].Cells[0].Value.ToString();
            string Id = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[0].Value.ToString();

            if (column == "Censur level")
            {
                if (!short.TryParse(tbxChangeValue.Text, out short result) || result > 2 || result < 0)
                {
                    MessageBox.Show("Censor level kan bara bestå av ett värde från 0 - 2");
                }
                else
                {
                    Db.Command($"UPDATE {GetTableName()} SET [{column}] = '{result}' WHERE Id = '{Id}'");
                }
            }
            else
            {
                Db.Command($"UPDATE {GetTableName()} SET [{column}] = '{tbxChangeValue.Text}' WHERE Id = '{Id}'");
            }
            

            updateInProgress = false;
            UpdateGridView($"SELECT * FROM {GetTableName()}");

            if (Convert.ToInt32(numChangeRow.Value) < DbDisplay.Rows.Count)
            {
                DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value)].Cells[Convert.ToInt32(numChangeColumn.Value) - 1];
            }
            else
            {
                DbDisplay.CurrentCell = DbDisplay.Rows[Convert.ToInt32(numChangeRow.Value) - 1].Cells[Convert.ToInt32(numChangeColumn.Value) - 1];
            }
                
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            updateInProgress = true;

            // Get the value of the first column on the specified row, then use it in the query string. 
            string Id = DbDisplay.Rows[Convert.ToInt32(numDeleteRow.Value) - 1].Cells[0].Value.ToString();
            Db.Command($"DELETE FROM {GetTableName()} WHERE Id = '{Id}'");
            
            updateInProgress = false;
            UpdateGridView($"SELECT * FROM {GetTableName()}");

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
            
            switch (cbTabell.Text)
            {
                case "Adjektiv":

                    // If the textbox that needs to be a small number, is a small number, then continue. 
                    if (!short.TryParse(tbxAddColumn5.Text, out short result) || result > 2 || result < 0)
                    {
                        MessageBox.Show("Censor level kan bara bestå av ett värde från 0 - 2");
                    }
                    else
                    {
                        Db.Command($"INSERT INTO TblAdjective VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{tbxAddColumn5.Text}', 0)");
                    }
                    break;

                case "Substantiv":

                    if (!short.TryParse(tbxAddColumn6.Text, out result) || result > 2 || result < 0)
                    {
                        MessageBox.Show("Censor level kan bara bestå av ett värde från 0 - 2");
                    }
                    else
                    {
                        Db.Command($"INSERT INTO TblNouns VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{tbxAddColumn5.Text}', '{tbxAddColumn6.Text}','{tbxAddColumn7.Text}', 0)");
                    }
                    break;

                case "Verb":

                    if (!short.TryParse(tbxAddColumn6.Text, out result) || result > 2 || result < 0)
                    {
                        MessageBox.Show("Censor level kan bara bestå av ett värde från 0 - 2");
                    }
                    else
                    {
                        Db.Command($"INSERT INTO TblVerb VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{tbxAddColumn5.Text}', '{tbxAddColumn6.Text}', 0)");
                    }
                    break;
            }
            updateInProgress = false;
            UpdateGridView($"SELECT * FROM {GetTableName()}");
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
                //tbxChangeColumn.Text = (DbDisplay.CurrentCell.ColumnIndex + 1).ToString();
                //tbxChangeRow.Text = (DbDisplay.CurrentCell.RowIndex + 1).ToString();
                //tbxDeleteRow.Text = (DbDisplay.CurrentCell.RowIndex + 1).ToString();

                numChangeColumn.Value = DbDisplay.CurrentCell.ColumnIndex + 1;
                numChangeRow.Value = DbDisplay.CurrentCell.RowIndex + 1;
                numDeleteRow.Value = DbDisplay.CurrentCell.RowIndex + 1;

            }
            
        }

    }
}
