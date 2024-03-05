using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb; // Add OleDb namespace for database access
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace MaorSaban215713587.Forms
{
    public partial class FrmSupplierProducts : Form
    {
        public Panel mainPanel;
        private DataTable associatedProducts; // Declare associatedProducts as a class-level variable
        public string id;
        public DataTable productsTable; // Store the original products data
        private DataTable savedDataTable; // Store the saved data
        private int currentRowIndex = -1;
        List<int> amounts;//save the amounts
        public FrmSupplierProducts()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            amounts = new List<int>();

            // Initialize the saved data DataTable
            savedDataTable = new DataTable();
            savedDataTable.Columns.Add("itemCode", typeof(int));
            savedDataTable.Columns.Add("pcolor", typeof(string));
            savedDataTable.Columns.Add("price", typeof(int));
            savedDataTable.Columns.Add("gender", typeof(string));
            savedDataTable.Columns.Add("pname", typeof(string));
            savedDataTable.Columns.Add("company", typeof(string));
            savedDataTable.Columns.Add("category", typeof(string));
            savedDataTable.Columns.Add("stock", typeof(int));
            savedDataTable.Columns.Add("supplierId", typeof(string));
            // Add more columns as needed for the saved data
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmPurchase form
            FrmSuppliers productsForm = new FrmSuppliers();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = searchTextBox.Text.Trim().ToLower();

            if (associatedProducts != null)
            {
                DataTable filteredTable = associatedProducts.Clone();

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


                // Iterate through savedDataTable and apply green background to corresponding rows in the filtered DataGridView
                foreach (DataRow savedRow in savedDataTable.Rows)
                {
                    int itemCode = Convert.ToInt32(savedRow["itemCode"]);
                    foreach (DataGridViewRow filteredRow in dataGridView1.Rows)
                    {
                        if (Convert.ToInt32(filteredRow.Cells["itemCode"].Value) == itemCode)
                        {
                            filteredRow.DefaultCellStyle.BackColor = Color.Green;
                        }
                    }
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int i = dataGridView1.SelectedRows[0].Index; // Get the index of the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Check if the row is already selected (green background)
                if (selectedRow.DefaultCellStyle.BackColor == Color.Green)
                {
                    MessageBox.Show("This item is already selected.");
                }
                else
                {
                    // Assuming "amount" is the name of the DataGridViewTextBoxCell column
                    DataGridViewTextBoxCell boxCell = selectedRow.Cells["amount"] as DataGridViewTextBoxCell;

                    if (boxCell != null)
                    {
                        if (int.TryParse(boxCell.Value?.ToString(), out int quantity) && quantity >= 1 && quantity <= 1000)
                        {
                            // Valid input, set the cell value and background color
                            selectedRow.DefaultCellStyle.BackColor = Color.Green;

                            // Save the selected row to the saved data DataTable
                            DataRow newRow = savedDataTable.NewRow();
                            newRow["itemCode"] = Convert.ToInt32(selectedRow.Cells["itemCode"].Value);
                            newRow["pcolor"] = selectedRow.Cells["pcolor"].Value.ToString();
                            newRow["price"] = Convert.ToInt32(selectedRow.Cells["price"].Value);
                            newRow["gender"] = selectedRow.Cells["gender"].Value.ToString();
                            newRow["pname"] = selectedRow.Cells["pname"].Value.ToString();
                            newRow["company"] = selectedRow.Cells["company"].Value.ToString();
                            newRow["category"] = selectedRow.Cells["category"].Value.ToString();
                            newRow["stock"] = Convert.ToInt32(selectedRow.Cells["stock"].Value);
                            newRow["supplierId"] = selectedRow.Cells["supplierId"].Value.ToString();
                            // Add more columns as needed for the saved data

                            savedDataTable.Rows.Add(newRow);
                            pcount.Text = "Products: " + savedDataTable.Rows.Count;
                            forward_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid quantity between 1 and 1000.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected row's amount hasn't been changed.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid item.");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
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
                    int itemCode = Convert.ToInt32(selectedRow.Cells["itemCode"].Value);

                    // Find and delete the corresponding row in the saved data DataTable
                    DataRow[] rowsToDelete = savedDataTable.Select("itemCode = " + itemCode);

                    foreach (DataRow rowToDelete in rowsToDelete)
                    {
                        savedDataTable.Rows.Remove(rowToDelete);
                    }
                    pcount.Text = "Products: " + savedDataTable.Rows.Count;
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

        private void back_Click(object sender, EventArgs e)
        {
            if (currentRowIndex > 0)
            {
                currentRowIndex--;
                SelectRowByIndex(currentRowIndex);
            }
        }
        private void DisplayAssociatedProducts()
        {
            if (productsTable.Rows.Count > 0)
            {
                // Establish a connection to your Access database
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Extract the id from the first row
                    id = productsTable.Rows[0]["Id"].ToString();

                    // Define a SQL query to retrieve associated products
                    string query = "SELECT * FROM Products WHERE supplierId = @SupplierId";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", id);

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
        }

        private void FrmSupplierProducts_Load(object sender, EventArgs e)
        {
            DisplayAssociatedProducts();
        }

        private void cob_Click(object sender, EventArgs e)
        {
            if (savedDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Please select an item.");
                return;
            }
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                using (OleDbTransaction transaction = connection.BeginTransaction())
                {
                    int orderCode = 0; // Initialize to a default value

                    // Get the maximum order code
                    string getMaxOrderCodeQuery = "SELECT MAX(code) FROM Orders";
                    using (OleDbCommand getMaxOrderCodeCommand = new OleDbCommand(getMaxOrderCodeQuery, connection, transaction))
                    {
                        object result = getMaxOrderCodeCommand.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            orderCode = Convert.ToInt32(result) + 1;
                        }
                    }

                    // Create a new row in the "Orders" table
                    string insertOrderQuery = "INSERT INTO Orders (code, orderDate, arrivalDate, supplierId) " +
                                              "VALUES (@code, @orderDate, @arrivalDate, @supplierId)";
                    using (OleDbCommand orderCommand = new OleDbCommand(insertOrderQuery, connection, transaction))
                    {
                        orderCommand.Parameters.AddWithValue("@code", orderCode);
                        orderCommand.Parameters.AddWithValue("@orderDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        orderCommand.Parameters.AddWithValue("@arrivalDate", DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss"));//DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss")
                        orderCommand.Parameters.AddWithValue("@supplierId", id); // Provide a value for @supplierId
                        orderCommand.ExecuteNonQuery();
                    }

                    //find the amounts
                    foreach (DataRow savedRow in savedDataTable.Rows)
                    {
                        int itemCode = Convert.ToInt32(savedRow["itemCode"]);

                        foreach (DataGridViewRow filteredRow in dataGridView1.Rows)
                        {
                            if (Convert.ToInt32(filteredRow.Cells["itemCode"].Value) == itemCode)
                            {
                                amounts.Add(Convert.ToInt32(filteredRow.Cells["amount"].Value));
                            }
                        }
                    }

                    int i = 0;
                    // Iterate through the rows in savedDataTable
                    foreach (DataRow savedRow in savedDataTable.Rows)
                    {
                        // Create a new row in the "OrderDetails" table
                        string insertSubTableRowQuery = "INSERT INTO orderDetails (orderCode, productCode, amount, arrived) " +
                                                        "VALUES (@orderCode, @productCode, @amount, @arrived)";
                        using (OleDbCommand subTableRowCommand = new OleDbCommand(insertSubTableRowQuery, connection, transaction))
                        {
                            subTableRowCommand.Parameters.AddWithValue("@orderCode", orderCode);
                            subTableRowCommand.Parameters.AddWithValue("@productCode", savedRow["itemCode"]);
                            subTableRowCommand.Parameters.AddWithValue("@amount", amounts[i]); // need to update according to user input
                            subTableRowCommand.Parameters.AddWithValue("@arrived", "No"); // need to create button
                            subTableRowCommand.ExecuteNonQuery();
                        }
                        i++;
                    }

                    // Commit the transaction
                    transaction.Commit();
                    MessageBox.Show("Order created");       
                }
            }
            // Create an instance of the FrmPurchase form
            FrmPrint purchaseForm = new FrmPrint();
            purchaseForm.mainPanel = mainPanel;
            purchaseForm.productsTable = savedDataTable;
            purchaseForm.amounts = amounts;

            // Clear the main panel before adding the new form
            mainPanel.Controls.Clear();

            // Set the parent of the purchase form to the main form
            purchaseForm.TopLevel = false;
            purchaseForm.FormBorderStyle = FormBorderStyle.None;
            purchaseForm.Dock = DockStyle.Fill;

            // Add the purchase form to the main panel
            mainPanel.Controls.Add(purchaseForm);

            // Show the purchase form
            purchaseForm.Show();
        }

        private void pSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
