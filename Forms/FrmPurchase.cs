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

    public partial class FrmPurchase : Form
    {
        private int currentRowIndex = -1;
        private DataTable productsTable; // Store the original products data
        private DataTable filteredDataTable; // Store the filtered data
        private DataTable savedDataTable; // Store the saved data
        List<int> amounts ;//save the amounts
        public Panel mainPanel;

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
        }

        public FrmPurchase()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


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
            amounts = new List<int>();

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
        private void FrmPurchase_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PopulateDataGridView("ספורט");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            PopulateDataGridView("מוקסין");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PopulateDataGridView("נעל סירה");
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            PopulateDataGridView("מגפון");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void pictureBox6_Click_1(object sender, EventArgs e)
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
                    // Assuming "amount" is the name of the ComboBox column
                    DataGridViewComboBoxCell comboBoxCell = selectedRow.Cells["amount"] as DataGridViewComboBoxCell;

                    if (comboBoxCell != null && !string.IsNullOrEmpty(comboBoxCell.Value?.ToString()))
                    {
                        int selectedAmount = int.Parse(comboBoxCell.Value.ToString());
                        int stock = int.Parse(selectedRow.Cells["stock"].Value.ToString());

                        if (selectedAmount <= stock)
                        {
                            // Change the background color of the selected row to green
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
                            forward_Click_1(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Selected amount is higher than the available stock.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid item with a value in the ComboBox.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid item.");
            }
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int i = dataGridView1.SelectedRows[0].Index; // Get the index of the selected row
                if ( i >= 0)
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
                    forward_Click_1(sender, e);
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

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            if (savedDataTable.Rows.Count > 0)
            {
                // get the amounts
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
                // Create an instance of the FrmPurchase form
                FrmBuyPage buyPage = new FrmBuyPage();
                buyPage.productsTable = savedDataTable;
                buyPage.mainPanel = mainPanel;
                buyPage.amounts = amounts;

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
                MessageBox.Show("No items selected.");
            }
        }

        private void forward_Click_1(object sender, EventArgs e)
        {
            if (currentRowIndex < dataGridView1.Rows.Count)
            {
                currentRowIndex++;
                SelectRowByIndex(currentRowIndex);
            }
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            if (currentRowIndex > 0)
            {
                currentRowIndex--;
                SelectRowByIndex(currentRowIndex);
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
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewComboBoxColumn comboBoxColumn = dataGridView1.Columns["amount"] as DataGridViewComboBoxColumn;
                if (comboBoxColumn != null)
                {
                    // Check if the ComboBox items are already populated
                    if (comboBoxColumn.Items.Count == 0)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            comboBoxColumn.Items.Add(i.ToString());
                        }
                    }
                }
            }
        }
    }
}
