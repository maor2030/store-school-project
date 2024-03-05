using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaorSaban215713587.Forms
{
    public partial class FrmnewProduct : Form
    {
        public string itemCode;
        public Panel main;
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb;";
        public FrmnewProduct()
        {
            InitializeComponent();
        }

        private void FrmnewProduct_Load(object sender, EventArgs e)
        {
            PopulateCategoryComboBox();
            PopulateSupplierComboBox();

            // Check if you have an existing itemCode
            if (itemCode != null)
            {
                // Create a connection to the database
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Define your SQL query using a parameterized query to prevent SQL injection
                    string query = "SELECT * FROM Products WHERE itemCode = @ItemCode";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Replace "PrimaryKeyColumn" and "YourTableName" with your actual primary key column and table name.
                        command.Parameters.AddWithValue("@ItemCode", itemCode);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assuming you have textboxes for displaying the columns
                                nameinput.Text = reader["pname"].ToString();
                                colorinput.Text = reader["pcolor"].ToString();
                                genderinput.Text = reader["gender"].ToString();
                                priceinput.Text = reader["price"].ToString();
                                companyinput.Text = reader["company"].ToString();

                                // Retrieve the category from the database and set it in the ComboBox
                                string categoryFromDatabase = reader["category"].ToString();
                                categoryComboBox.SelectedItem = categoryFromDatabase;

                                // Retrieve the supplierId from the database
                                string supplierIdFromDatabase = reader["supplierId"].ToString();

                                // Find the corresponding KeyValuePair in the supplierCombo and set it as the selected item
                                foreach (KeyValuePair<string, string> supplier in supplierCombo.Items)
                                {
                                    if (supplier.Key == supplierIdFromDatabase)
                                    {
                                        supplierCombo.SelectedItem = supplier;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmPurchase form
            FrmProducts productsForm = new FrmProducts();
            productsForm.mainPanel = main;

            // Clear the main panel before adding the new form
            main.Controls.Clear();

            // Set the parent of the purchase form to the main form
            productsForm.TopLevel = false;
            productsForm.FormBorderStyle = FormBorderStyle.None;
            productsForm.Dock = DockStyle.Fill;

            // Add the purchase form to the main panel
            main.Controls.Add(productsForm);

            // Show the purchase form
            productsForm.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                int code = GetNextItemCode(connection);

                // Delete the previous item
                if (itemCode != null)
                {
                    DeleteItem(connection, itemCode);
                    itemCode = null;
                }

                string pGender = genderinput.Text;
                string pName = nameinput.Text;
                string pColor = colorinput.Text;
                string pCategory = categoryComboBox.SelectedItem?.ToString();
                string supplierId = null;

                // Retrieve the selected supplierId from the combo box
                if (supplierCombo.SelectedItem != null)
                {
                    KeyValuePair<string, string> selectedSupplier = (KeyValuePair<string, string>)supplierCombo.SelectedItem;
                    supplierId = selectedSupplier.Key;
                }

                string pCompany = companyinput.Text;
                int stock = 0, price;

                if (string.IsNullOrWhiteSpace(pGender) || string.IsNullOrWhiteSpace(pName) || string.IsNullOrWhiteSpace(pColor) ||
                    string.IsNullOrWhiteSpace(pCategory) || string.IsNullOrWhiteSpace(supplierId) || string.IsNullOrWhiteSpace(pCompany) ||
                    !int.TryParse(priceinput.Text, out price) || price < 0 || price > 10000)
                {
                    MessageBox.Show("Please fill in all required fields, ensure that price is a valid integer, and it is within the range of 0 to 10000.");
                    return;
                }

                InsertProduct(connection, code, pColor, price, pGender, pName, pCompany, pCategory, stock, supplierId);

                connection.Close();

                // Create an instance of the FrmPurchase form
                FrmProducts productsForm = new FrmProducts();
                productsForm.mainPanel = main;

                // Clear the main panel before adding the new form
                main.Controls.Clear();

                // Set the parent of the purchase form to the main form
                productsForm.TopLevel = false;
                productsForm.FormBorderStyle = FormBorderStyle.None;
                productsForm.Dock = DockStyle.Fill;

                // Add the purchase form to the main panel
                main.Controls.Add(productsForm);

                // Show the purchase form
                productsForm.Show();
            }
        }

        private int GetNextItemCode(OleDbConnection connection)
        {
            // Determine the maximum itemCode in the Products table
            string maxItemCodeQuery = "SELECT MAX(itemCode) FROM Products";
            using (OleDbCommand maxItemCodeCommand = new OleDbCommand(maxItemCodeQuery, connection))
            {
                object maxItemCodeResult = maxItemCodeCommand.ExecuteScalar();

                if (maxItemCodeResult != DBNull.Value)
                {
                    return Convert.ToInt32(maxItemCodeResult) + 1;
                }
            }

            return 1; // Default value for code if there are no existing records
        }

        private void DeleteItem(OleDbConnection connection, string itemCode)
        {
            string deleteQuery = "DELETE FROM Products WHERE itemCode = @itemCode";

            using (OleDbCommand cmd = new OleDbCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@itemCode", itemCode);
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }

        private void InsertProduct(OleDbConnection connection, int code, string pColor, int price, string pGender, string pName, string pCompany, string pCategory, int stock, string supplierId)
        {
            string insertQuery = "INSERT INTO Products (itemCode, pcolor, price, gender, pname, company, category, stock, supplierId) VALUES " +
                "(@itemCode, @pcolor, @price, @gender, @pname, @company, @category, @stock, @supplierId)";

            using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@itemCode", code);
                cmd.Parameters.AddWithValue("@pcolor", pColor);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@gender", pGender);
                cmd.Parameters.AddWithValue("@pname", pName);
                cmd.Parameters.AddWithValue("@company", pCompany);
                cmd.Parameters.AddWithValue("@category", pCategory);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@supplierId", supplierId);

                cmd.ExecuteNonQuery();
            }
        }

        private void categoryinput_TextChanged(object sender, EventArgs e)
        {

        }
        private void PopulateCategoryComboBox()
        {
            // You can add your category options from your database or hard-code them.
            // Here's an example of adding hardcoded options:
            categoryComboBox.Items.Add("מוקסין");
            categoryComboBox.Items.Add("ספורט");
            categoryComboBox.Items.Add("נעל סירה");
            categoryComboBox.Items.Add("מגפון");
            // Add more categories as needed
        }
        private void PopulateSupplierComboBox()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, FullName FROM Suppliers"; // Adjust the table and column names accordingly
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string supplierId = reader["Id"].ToString();
                            string fullName = reader["FullName"].ToString();
                            supplierCombo.Items.Add(new KeyValuePair<string, string>(supplierId, fullName));
                        }
                    }
                }
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void companyinput_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
