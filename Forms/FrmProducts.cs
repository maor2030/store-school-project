using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;  // Add this line
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace MaorSaban215713587.Forms
{

    public partial class FrmProducts : Form
    {
        private int currentRowIndex = -1;
        private DataTable productsTable; // Store the original products data
        private DataTable filteredDataTable; // Store the filtered data
       // private DataTable savedDataTable; // Store the saved data
        public Panel mainPanel; // Store a reference to FrmMain




        private void PopulateDataGridView(string condition = "")
        {
            // Your connection string to the Access database.
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products";

                if (!string.IsNullOrEmpty(condition))
                {
                    query += " WHERE category = @Condition";
                }

                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(condition))
                    {
                        cmd.Parameters.AddWithValue("@Condition", condition);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    filteredDataTable = new DataTable();
                    adapter.Fill(filteredDataTable);

                    dataGridView1.DataSource = filteredDataTable;
                }
            }
        }

        public FrmProducts()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
            string query = "SELECT * From Products";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        productsTable = ds.Tables[0]; // Store the original data
                        dataGridView1.DataSource = productsTable;
                    }
                    else
                    {
                        // Handle the case where no data is retrieved from the database.
                        MessageBox.Show("No data found.");
                    }
                }
            }
        }

        private void FrmOrders_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PopulateDataGridView("מגפון");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PopulateDataGridView("מוקסין");
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            string filterText = searchTextBox.Text.Trim().ToLower(); // Get the text from textBox8 and convert to lowercase for case-insensitive search

            DataTable filteredTable = productsTable.Clone(); // Create a copy of the original table structure

            foreach (DataRow row in productsTable.Rows)
            {
                bool rowContainsFilterText = false;
                foreach (var item in row.ItemArray)
                {
                    if (item.ToString().ToLower().Contains(filterText))
                    {
                        rowContainsFilterText = true;
                        break;
                    }
                }

                if (rowContainsFilterText)
                {
                    filteredTable.ImportRow(row);
                }
            }

            dataGridView1.DataSource = filteredTable;
        }

        private void newProduct_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmnewProduct form
            FrmnewProduct newProductForm = new FrmnewProduct();
            newProductForm.main = mainPanel;

            // Set the parent of the newProductForm to the main form
            newProductForm.TopLevel = false;
            newProductForm.FormBorderStyle = FormBorderStyle.None;
            newProductForm.Dock = DockStyle.Fill; // Set the Dock property

            // Clear the main form before adding the new form
            mainPanel.Controls.Clear();

            // Add the newProductForm to the main form's main panel
            mainPanel.Controls.Add(newProductForm);

            // Show the newProductForm
            newProductForm.Show();
        }

        private void pSave_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int idToUpdate = Convert.ToInt32(selectedRow.Cells["itemCode"].Value);

                string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
                string updateQuery = "UPDATE Products SET stock = 0 WHERE itemCode = @itemCode";

                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@itemCode", idToUpdate);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item stock is now 0.");
                            selectedRow.Cells["stock"].Value = 0; // Update the DataGridView stock cell
                        }
                        else
                        {
                            MessageBox.Show("Item not found or could not be updated.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to update.");
            }
        }


        private void back_Click(object sender, EventArgs e)
        {
            if (currentRowIndex > 0)
            {
                currentRowIndex--;
                SelectRowByIndex(currentRowIndex);
            }
        }

        private void forward_Click(object sender, EventArgs e)
        {
            if (currentRowIndex < dataGridView1.Rows.Count - 1)
            {
                currentRowIndex++;
                SelectRowByIndex(currentRowIndex);
            }
        }
        private void SelectRowByIndex(int index)
        {
            if (index >= 0 && index < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[index].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0]; // Select the first cell in the row
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update the currentRowIndex when the user clicks a cell in the DataGridView
            if (e.RowIndex >= 0)
            {
                currentRowIndex = e.RowIndex;
            }
            else
            {
                currentRowIndex = -1; // No row is selected
            }
        }

        private void pedit_Click(object sender, EventArgs e)
        {
            FrmnewProduct newProductForm = new FrmnewProduct();
            if (dataGridView1.SelectedRows.Count > 0) // Check if at least one row is selected
            {
                int index = dataGridView1.SelectedRows[0].Index; // Get the index of the selected row

                // Check if the selected row has the required number of cells
                if (index >= 0 && dataGridView1.Rows[index].Cells.Count > 0)
                {
                    newProductForm.itemCode = dataGridView1.Rows[index].Cells[0].Value.ToString();

                    newProductForm.main = mainPanel;

                    // Set the parent of the newProductForm to the main form
                    newProductForm.TopLevel = false;
                    newProductForm.FormBorderStyle = FormBorderStyle.None;
                    newProductForm.Dock = DockStyle.Fill; // Set the Dock property

                    // Clear the main form before adding the new form
                    mainPanel.Controls.Clear();

                    // Add the newProductForm to the main form's main panel
                    mainPanel.Controls.Add(newProductForm);

                    // Show the newProductForm
                    newProductForm.Show();
                }
                else
                {
                    // Handle the case where the selected row doesn't have enough cells
                    MessageBox.Show("Selected item is invalid.");
                }
            }
            else
            {
                // Handle the case where no rows are selected
                MessageBox.Show("No item is selected.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PopulateDataGridView("ספורט");

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PopulateDataGridView("נעל סירה");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }



        private void pcount_Click(object sender, EventArgs e)
        {

        }

        private void pSearch_Click(object sender, EventArgs e)
        {

        }

        private void productsCategory_Enter(object sender, EventArgs e)
        {

        }

        private void productsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void productsBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
