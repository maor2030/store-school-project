using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // Add OleDb namespace for database access

namespace MaorSaban215713587.Forms
{
    public partial class FrmOrderDetails : Form
    {
        public Panel mainPanel; // Store a reference to FrmMain
        public int id;
        private int currentRowIndex = -1;
        private DataTable associatedProducts; // Declare associatedProducts as a class-level variable
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
        public FrmOrderDetails(int id)
        {
            this.id = id;
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DisplayAssociatedProducts();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = searchTextBox.Text.Trim().ToLower(); // Get the text from textBox8 and convert to lowercase for case-insensitive search

            DataTable filteredTable = associatedProducts.Clone(); // Create a copy of the original table structure

            foreach (DataRow row in associatedProducts.Rows)
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
        private void DisplayAssociatedProducts()
        {
            // Establish a connection to your Access database
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Define a SQL query to retrieve associated products from the "orderDetails" table
                string query = "SELECT * FROM orderDetails WHERE orderCode = @orderCode";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderCode", id);

                    // Create a DataTable to hold the results
                    associatedProducts = new DataTable();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        // Fill the DataTable with results
                        adapter.Fill(associatedProducts);

                        // Set the filtered DataTable as the DataSource for dataGridView1
                        dataGridView1.DataSource = associatedProducts;

                        // Update other controls or display relevant information
                    }
                }
            }
        } 

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmPurchase form
            FrmOrders productsForm = new FrmOrders();
            productsForm.mainPanel = mainPanel;

            // Clear the main panel before adding the new form
            mainPanel.Controls.Clear();

            // Set the parent of the purchase form to the main form
            productsForm.TopLevel = false;
            productsForm.FormBorderStyle = FormBorderStyle.None;
            productsForm.Dock = DockStyle.Fill;

            // Add the purchase form to the main panel
            mainPanel.Controls.Add(productsForm);

            // Show the purchase form
            productsForm.Show();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void arrB_Click(object sender, EventArgs e)
        {
            // Check if the first row has the "Arrived" column set to "No"
            if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[0].Cells["arrived"].Value.ToString().Equals("No", StringComparison.OrdinalIgnoreCase))
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Start a transaction to ensure consistency between updates
                    using (OleDbTransaction transaction = connection.BeginTransaction())
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            string arrivedValue = row.Cells["Arrived"].Value.ToString();
                            if (arrivedValue.Equals("No", StringComparison.OrdinalIgnoreCase))
                            {
                                // Retrieve the product code and quantity from the row
                                string itemCode = row.Cells["productCode"].Value.ToString();
                                int quantity = Convert.ToInt32(row.Cells["amount"].Value);

                                // Define a SQL query to update the stock of the associated product
                                string updateProductQuery = "UPDATE Products SET Stock = Stock + @quantity WHERE itemCode = @itemCode";

                                using (OleDbCommand updateProductCommand = new OleDbCommand(updateProductQuery, connection, transaction))
                                {
                                    updateProductCommand.Parameters.AddWithValue("@quantity", quantity);
                                    updateProductCommand.Parameters.AddWithValue("@productCode", itemCode);

                                    // Execute the update query for the product
                                    updateProductCommand.ExecuteNonQuery();
                                }

                                // Update the "Arrived" column in the "orderDetails" table
                                string updateArrivedQuery = "UPDATE orderDetails SET Arrived = 'Yes' WHERE orderCode = @orderCode";

                                int orderDetailID = Convert.ToInt32(row.Cells["orderCode"].Value);

                                using (OleDbCommand updateArrivedCommand = new OleDbCommand(updateArrivedQuery, connection, transaction))
                                {
                                    updateArrivedCommand.Parameters.AddWithValue("@orderCode", orderDetailID);

                                    // Execute the update query for "Arrived"
                                    updateArrivedCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        // Commit the transaction to save changes
                        transaction.Commit();
                    }
                }

                // Refresh the DataGridView to reflect the changes
                DisplayAssociatedProducts();
            }
            else
            {
                MessageBox.Show("This order has already arrived.");
            }
        }
    }
}
