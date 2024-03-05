using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;  // Add this line
using System.Windows.Forms;

namespace MaorSaban215713587.Forms
{
    public partial class FrmOrders : Form
    {

        public Panel mainPanel;
        private DataTable productsTable; // Store the original products data
        private int currentRowIndex = -1;
        public FrmOrders()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MaorSaban215713587.accdb";
            string query = "SELECT Orders.*, Suppliers.FullName AS SupplierName " +
               "FROM Orders " +
               "LEFT JOIN Suppliers ON Orders.supplierId = Suppliers.ID";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        productsTable = ds.Tables[0]; // Store the original data

                        // Sort the DataTable by the "arrivalDate" column in ascending order
                        productsTable.DefaultView.Sort = "arrivalDate ASC";
                        productsTable = productsTable.DefaultView.ToTable();

                        dataGridView1.DataSource = productsTable;
                    }
                    else
                    {
                        // Handle the case where no data is retrieved from the database.
                        MessageBox.Show("No data found.");
                    }
                }
            }

            // Subscribe to the RowPrePaint event
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
        }

        private void FrmOrders_Load(object sender, EventArgs e)
        {

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

        private void conb_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Extract the "code" value from the selected row
                int codeValue = (int)selectedRow.Cells["code"].Value;

                // Create an instance of the FrmOrderDetails form
                FrmOrderDetails buyPage = new FrmOrderDetails(codeValue);//send the order id to the table thru constructor
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
                MessageBox.Show("No order selected.");
            }
        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["arrivalDate"].Value is string arrivalDateString && DateTime.TryParse(arrivalDateString, out DateTime arrivalDate))
                {
                    if (arrivalDate.Date == DateTime.Today)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else if (arrivalDate.Date < DateTime.Today)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void longer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Extract the "arrivalDate" value from the selected row
                string arrivalDateString = selectedRow.Cells["arrivalDate"].Value as string;

                if (!string.IsNullOrEmpty(arrivalDateString))
                {
                    DateTime arrivalDate = DateTime.Parse(arrivalDateString);

                    // Check if the arrival date is in the past
                    if (arrivalDate.Date < DateTime.Today)
                    {
                        // Display a message indicating that the order is overdue
                        MessageBox.Show("This order is overdue and cannot be delayed.");
                    }
                    else
                    {
                        // Add 1 week to the arrival date
                        DateTime newArrivalDate = arrivalDate.AddDays(7);

                        // Update the value in the DataTable
                        if (selectedRow.DataBoundItem is DataRowView rowView)
                        {
                            DataRow row = rowView.Row;
                            row["arrivalDate"] = newArrivalDate.ToString("yyyy-MM-dd HH:mm:ss");
                        }

                        // Refresh the DataGridView to reflect the changes
                        dataGridView1.Refresh();
                        MessageBox.Show("The arrival date has been delayed by 1 week.");
                    }
                }
                else
                {
                    MessageBox.Show("No order selected.");
                }
            }
        }
    }
}
