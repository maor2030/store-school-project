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
    public partial class FrmSuppliers : Form
    {
        private int currentRowIndex = -1;
        bool selected = false;
        private DataTable productsTable; // Store the original products data
        private DataTable filteredDataTable; // Store the filtered data
        private DataTable savedDataTable; // Store the saved data
        public Panel mainPanel; // Store a reference to FrmMain
        public FrmSuppliers()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Initialize the saved data DataTable
            savedDataTable = new DataTable();
            savedDataTable.Columns.Add("id", typeof(string));
            savedDataTable.Columns.Add("fullName", typeof(string));
            savedDataTable.Columns.Add("address", typeof(string));
            savedDataTable.Columns.Add("city", typeof(string));
            savedDataTable.Columns.Add("active", typeof(string));
            // Add more columns as needed for the saved data

            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
            string query = "SELECT * From Suppliers";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void newProduct_Click(object sender, EventArgs e)//create new supplier
        {
            // Create an instance of the FrmnewProduct form
            FrmnewSupplier newProductForm = new FrmnewSupplier();
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

        private void FrmSuppliers_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }
        private void PopulateDataGridView(string condition = "")
        {
            // Your connection string to the Access database.
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Suppliers";

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

        private void pedit_Click(object sender, EventArgs e)
        {
            FrmnewSupplier newProductForm = new FrmnewSupplier();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index; // Get the index of the selected row

                // Check if the selected row has the required number of cells
                if (dataGridView1.RowCount  > index && index >= 0 && dataGridView1.Rows[index].Cells.Count > 0)
                {
                    newProductForm.id = dataGridView1.Rows[index].Cells["id"].Value.ToString();
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

        private void pDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string idToUpdate = (string)selectedRow.Cells["Id"].Value;

                string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
                string updateQuery = "UPDATE Suppliers SET active = 'No' WHERE Id = @Id";

                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", idToUpdate);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Supplier status updated to 'No'.");
                            selectedRow.Cells["Active"].Value = "No"; // Update the DataGridView "Active" cell
                        }
                        else
                        {
                            MessageBox.Show("Supplier not found or could not be updated.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to update.");
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

        private void back_Click(object sender, EventArgs e)
        {
            if (currentRowIndex > 0)
            {
                currentRowIndex--;
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

        private void searchTextBox_TextChanged(object sender, EventArgs e)
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


            // Iterate through savedDataTable and apply green background to corresponding rows in the filtered DataGridView
            foreach (DataRow savedRow in savedDataTable.Rows)
            {
                string itemCode = (string)savedRow["Id"];
                foreach (DataGridViewRow filteredRow in dataGridView1.Rows)
                {
                    if ((string)filteredRow.Cells["Id"].Value == itemCode)
                    {
                        filteredRow.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (selected)
            {
                MessageBox.Show("Already selected a supplier.");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int i = dataGridView1.SelectedRows[0].Index; // Get the index of the selected row
                if ( i >= 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Check if the "Active" column is set to "No"
                    string activeStatus = selectedRow.Cells["active"].Value.ToString();
                    if (activeStatus == "No")
                    {
                        MessageBox.Show("This supplier is not active and cannot be selected.");
                    }
                    else
                    {
                        // Change the background color of the selected row to green
                        selectedRow.DefaultCellStyle.BackColor = Color.Green;

                        // Save the selected row to the saved data DataTable
                        DataRow newRow = savedDataTable.NewRow();
                        newRow["id"] = selectedRow.Cells["id"].Value.ToString();
                        newRow["fullName"] = selectedRow.Cells["fullName"].Value.ToString();
                        newRow["address"] = selectedRow.Cells["address"].Value.ToString();
                        newRow["city"] = selectedRow.Cells["city"].Value.ToString();
                        newRow["active"] = selectedRow.Cells["active"].Value.ToString();
                        // Add more columns as needed for the saved data

                        savedDataTable.Rows.Add(newRow);
                        forward_Click(sender, e);
                        selected = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid item.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid item.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int i = dataGridView1.SelectedRows[0].Index; // Get the index of the selected row
                if (i >= 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Remove the green background from the selected row
                    selectedRow.DefaultCellStyle.BackColor = Color.White;

                    // Get the itemCode of the selected row
                    string id = (string)selectedRow.Cells["id"].Value;

                    // Find and delete the corresponding row in the saved data DataTable
                    DataRow[] rowsToDelete = savedDataTable.Select("id = '" + id + "'");

                    foreach (DataRow rowToDelete in rowsToDelete)
                    {
                        savedDataTable.Rows.Remove(rowToDelete);
                    }
                    selected = false;
                    forward_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please select a valid item.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid item.");
            }
        }

        private void newOrder_Click(object sender, EventArgs e)
        {
            if (savedDataTable.Rows.Count > 0)
            {
                // Create an instance of the FrmPurchase form
                FrmSupplierProducts buyPage = new FrmSupplierProducts();
                buyPage.productsTable = savedDataTable;
                buyPage.mainPanel = mainPanel;

                // Clear the main panel before adding the new form
                mainPanel.Controls.Clear();

                // Set the parent of the purchase form to the main form
                buyPage.TopLevel = false;
                buyPage.FormBorderStyle = FormBorderStyle.None;
                buyPage.Dock = DockStyle.Fill;

                // Add the purchase form to the main panel
                mainPanel.Controls.Add(buyPage);

                // Show the purchase form
                buyPage.Show();
            }
            else
            {
                MessageBox.Show("No supplier selected.");
            }
        }
    }
}
