using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaorSaban215713587.Forms
{
    public partial class FrmPrint : Form
    {
        public Panel mainPanel;
        public DataTable productsTable; // Store the saved data
        public List<int> amounts;//save the amounts
        public FrmPrint()
        {
            InitializeComponent();
            // Subscribe to the CellFormatting event
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
            printPreviewDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult prbutton = printDialog1.ShowDialog();
            if (prbutton.Equals(DialogResult.OK))
            {
                printDocument1.Print();
            }

        }

        private void FrmPrint_Load(object sender, EventArgs e)
        {
            // Assuming you've added a DataGridView named dataGridViewProducts to your form
            dataGridView1.AutoGenerateColumns = false; // Disable automatic column generation

            // Loop through the columns in your DataTable and create corresponding DataGridView columns
            foreach (DataColumn column in productsTable.Columns)
            {
                dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
            }

            // Add a new DataGridViewTextBoxColumn for the "Amount" column
            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Amount"
            };
            dataGridView1.Columns.Add(amountColumn);

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

                dataGridView1.Rows.Add(dataGridViewRow);
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

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Pen P = new Pen(Brushes.Black, 2.5f);

            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(10, 10));

            e.Graphics.DrawString("Summary", new Font("Tahoma", 14,
                FontStyle.Bold), Brushes.Red, new Point(420, 100));


            e.Graphics.DrawLine(P, new Point(420, 120), new Point(683, 120));


            int i = 0, j;
            int w = 50, h = 150;
            //לולאה שסופרת מספר עמודות, מציירת ריבוע, מציירת מסגרת ורושמת כותרות

            while (i < dataGridView1.Columns.Count)
            {
                // ציור ריבוע בצבע אפור

                e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(w, h, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

                //ציור מסגרת לריבוע בצבע אפור

                e.Graphics.DrawRectangle(P, new Rectangle(w, h, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

                //הדפסת טקסט בתוך הכותרת
                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(w + 30, h, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

                i++;
                w = w + 100;
            }

            i = 0;
            while (i < dataGridView1.Rows.Count - 1)
            {

                //חישוב הפיקסלים-שמציינים מיקום הטבלה בדוח, גובה כל שורה הוא 22 פיקסלים

                w = 50; h += 23;
                j = 0;
                while (j < dataGridView1.Columns.Count)
                {
                    e.Graphics.DrawRectangle(P, new Rectangle(w, h,
                    dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[j].FormattedValue.ToString(), dataGridView1.Font, Brushes.Black, new Rectangle(w + 4, h + 3, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));

                    j++;
                    w = w + 100;
                }
                i++;
            }
        }
    }
}
