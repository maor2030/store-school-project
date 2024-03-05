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
    public partial class FrmnewSupplier : Form
    {
        public string id;
        public Panel main;
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb;";
        public FrmnewSupplier()
        {
            InitializeComponent();
        }

        private void pcode_Click(object sender, EventArgs e)
        {

        }

        private void FrmnewSupplier_Load(object sender, EventArgs e)
        {
            // Check if you have an existing itemCode
            if (id != null)
            {
                // Create a connection to the database
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Define your SQL query using a parameterized query to prevent SQL injection
                    string query = "SELECT * FROM Suppliers WHERE Id = @Id";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Replace "PrimaryKeyColumn" and "YourTableName" with your actual primary key column and table name.
                        command.Parameters.AddWithValue("@Id", id);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assuming you have textboxes for displaying the columns
                                idinput.Text = reader["Id"].ToString();
                                nameinput.Text = reader["FullName"].ToString();
                                addressinput.Text = reader["address"].ToString();
                                cityinput.Text = reader["city"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmPurchase form
            FrmSuppliers productsForm = new FrmSuppliers();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                //deleting the previoud item
                if (this.id != null)
                {
                    string deleteQuery = "DELETE FROM Suppliers WHERE id = @Id";

                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", this.id);
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }
                    this.id = null;
                }

                string id = idinput.Text;
                string fullName = nameinput.Text;
                string address = addressinput.Text;
                string city = cityinput.Text;
                string active = "Yes";

                string insertQuery = "INSERT INTO Suppliers (id, fullName, address, city, active) VALUES " +
                    "(@Id, @fullName, @address, @city, @active)";

                using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@active", active);

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }

            // Create an instance of the FrmPurchase form
            FrmSuppliers productsForm = new FrmSuppliers();
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
}
