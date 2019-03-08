﻿using System;
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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            cbTabell.SelectedIndex = 0;
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
                    //Before i used: string[] row = new string[reader.FieldCount]; but then when I tried to sort
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


                    List<TextBox> TextBoxes = new List<TextBox>();
                    TextBoxes.Add(tbxAddColumn1);
                    TextBoxes.Add(tbxAddColumn2);
                    TextBoxes.Add(tbxAddColumn3);
                    TextBoxes.Add(tbxAddColumn4);
                    TextBoxes.Add(tbxAddColumn5);
                    TextBoxes.Add(tbxAddColumn6);
                    TextBoxes.Add(tbxAddColumn7);
                    TextBoxes.Add(tbxAddColumn8);

                    // Hide all
                    for (int i = 0; i < 8; i++)
                    {
                        Lables[i].Hide();
                        TextBoxes[i].Hide();
                    }

                    // Show and name only a specified number of objects in the lists. 

                    int iterationCount = 0;
                    for (int i = 0; i < reader.FieldCount - 3; i++)
                    {
                        TextBoxes[i].Show();
                        Lables[i].Show();
                        Lables[i].Text = reader.GetName(i + 1);
                        iterationCount = i;
                    }

                    // When all necessary textboxes have been added, then I want the Censur level
                    // to appear next to the last textbox where ever it is. 
                    // So I just get the location info of the textbox that would have appeared next to it
                    // and set that location to the combobox instead. 
                    cbCensurLevel.Location = TextBoxes[iterationCount + 1].Location;
                    lblColumn9.Location = Lables[iterationCount + 1].Location;
                    lblColumn9.Text = "Censur level";

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

                case "Saved results":
                case "Sparade resultat":
                    return "TblSavedResults";

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
            if (numChangeColumn.Value == 1)
            {
                MessageBox.Show("Kolumnen 'Id' går inte att ändra");
            }
            else
            {
                updateInProgress = true;
                string column = DbDisplay.Columns[Convert.ToInt32(numChangeColumn.Value) - 1].HeaderText;
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
                    if (!short.TryParse(cbCensurLevel.Text[0].ToString(), out short result) || result > 2 || result < 0)
                    {
                        MessageBox.Show("Censor level kan bara bestå av ett värde från 0 - 2");
                    }
                    else
                    {
                        Db.Command($"INSERT INTO TblAdjective VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{result}', 0)");
                    }
                    break;

                case "Substantiv":

                    if (!short.TryParse(cbCensurLevel.Text[0].ToString(), out result) || result > 2 || result < 0)
                    {
                        MessageBox.Show("Censor level kan bara bestå av ett värde från 0 - 2");
                    }
                    else
                    {
                        Db.Command($"INSERT INTO TblNouns VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{tbxAddColumn5.Text}', '{tbxAddColumn6.Text}','{result}', 0)");
                    }
                    break;

                case "Verb":

                    if (!short.TryParse(cbCensurLevel.Text[0].ToString(), out result) || result > 2 || result < 0)
                    {
                        MessageBox.Show("Censor level kan bara bestå av ett värde från 0 - 2");
                    }
                    else
                    {
                        Db.Command($"INSERT INTO TblVerb VALUES ('{tbxAddColumn1.Text}', '{tbxAddColumn2.Text}','{tbxAddColumn3.Text}', " +
                        $"'{tbxAddColumn4.Text}', '{tbxAddColumn5.Text}', '{result}', 0)");
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
                if (DbDisplay.CurrentCell == null)
                {

                }
                else
                {
                    numChangeColumn.Value = DbDisplay.CurrentCell.ColumnIndex + 1;
                    numChangeRow.Value = DbDisplay.CurrentCell.RowIndex + 1;
                    numDeleteRow.Value = DbDisplay.CurrentCell.RowIndex + 1;
                }
            }
            
        }

        private void btnResetDb_Click(object sender, EventArgs e)
        {
            Db.ResetDefault("all");
        }
    }
}