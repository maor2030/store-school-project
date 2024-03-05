using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // Import the OleDb namespace for Access database operations


namespace MaorSaban215713587.Forms
{
    public partial class FrmBuyPage : Form
    {
        public DataTable productsTable; // Store the original products data
        public Panel mainPanel;
        public List<int> amounts;

        int total = 0;

        public FrmBuyPage()
        {
            InitializeComponent();
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            amounts = new List<int>();
        }
        private int CalculateTotal()
        {
            int total = 0;
            int index = 0;

            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
            {
                int price;
                if (row.Cells["Price"].Value != null && int.TryParse(row.Cells["Price"].Value.ToString(), out price))
                {
                    total += price * amounts[index];
                }
                index++;
            }

            return total;
        }

        private void products_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Store_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmPurchase form
            FrmPurchase productsForm = new FrmPurchase();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmBuyPage_Load(object sender, EventArgs e)
        {
            // Assuming you've added a DataGridView named dataGridViewProducts to your form
            dataGridViewProducts.AutoGenerateColumns = false; // Disable automatic column generation

            // Loop through the columns in your DataTable and create corresponding DataGridView columns
            foreach (DataColumn column in productsTable.Columns)
            {
                dataGridViewProducts.Columns.Add(column.ColumnName, column.ColumnName);
            }

            // Add a new DataGridViewTextBoxColumn for the "Amount" column
            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Amount"
            };
            dataGridViewProducts.Columns.Add(amountColumn);

            // Loop through the rows in your DataTable and add them to the DataGridView
            for (int i = 0; i < productsTable.Rows.Count; i++)
            {
                DataRow row = productsTable.Rows[i];
                DataGridViewRow dataGridViewRow = new DataGridViewRow();

                // Add cells from the DataRow
                foreach (var item in row.ItemArray)
                {
                    dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = item });
                }

                // Add the corresponding "Amount" value from the amounts list
                int amountValue = amounts.Count > i ? amounts[i] : 0;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = amountValue });

                dataGridViewProducts.Rows.Add(dataGridViewRow);
            }

            // Set the AutoSizeColumnsMode property to Fill
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            total = CalculateTotal();
            Total.Text = "Final Price: " + total;
        }

        private void Total_Click(object sender, EventArgs e)
        {

        }

        private void endB_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    OleDbTransaction transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    // Generate a unique ID
                    string getMaxOrderCodeQuery = "SELECT MAX(code) FROM purchases";
                    command.CommandText = getMaxOrderCodeQuery;
                    object result = command.ExecuteScalar();

                    int code = (result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;

                    // Insert the purchase
                    string insertPurchaseQuery = "INSERT INTO purchases (code, DatePurchase) VALUES (@code, @DatePurchase)";
                    command.CommandText = insertPurchaseQuery;
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@DatePurchase", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                    for (int i = 0; i < dataGridViewProducts.Rows.Count; i++)
                    {
                        DataGridViewRow row = dataGridViewProducts.Rows[i];
                        int itemCode = Convert.ToInt32(row.Cells["itemCode"].Value); // Replace with your actual column name

                        int amount = amounts[i];
                        // Update the stock in the products table
                        string updateQuery = "UPDATE Products SET stock = stock - @Amount WHERE itemCode = @itemCode";
                        command.CommandText = updateQuery;
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@itemCode", itemCode);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        // Create a new row in the purchaseDetails table
                        string insertPurchaseDetailsQuery = "INSERT INTO purchaseDetails (codePurchase, itemCode, amount) " +
                            "VALUES (@codePurchase, @itemCode, @amount)";
                        command.CommandText = insertPurchaseDetailsQuery;
                        command.Parameters.AddWithValue("@codePurchase", code);
                        command.Parameters.AddWithValue("@itemCode", itemCode);
                        command.Parameters.AddWithValue("@amount", amount);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }

                    transaction.Commit();
                }
            }

            FrmPrint purchaseForm = new FrmPrint();
            purchaseForm.mainPanel = mainPanel;
            purchaseForm.productsTable = productsTable;
            purchaseForm.amounts = amounts;

            mainPanel.Controls.Clear();
            purchaseForm.TopLevel = false;
            purchaseForm.FormBorderStyle = FormBorderStyle.None;
            purchaseForm.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(purchaseForm);
            purchaseForm.Show();
        }
    }

}
