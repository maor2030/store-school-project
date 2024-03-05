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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin f = new FrmLogin();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmPurchase form
            FrmPurchase purchaseForm = new FrmPurchase();
            purchaseForm.mainPanel = main;

            // Clear the main panel before adding the new form
            main.Controls.Clear();

            // Set the parent of the purchase form to the main form
            purchaseForm.TopLevel = false;
            purchaseForm.FormBorderStyle = FormBorderStyle.None;
            purchaseForm.Dock = DockStyle.Fill;

            // Add the purchase form to the main panel
            main.Controls.Add(purchaseForm);

            // Show the purchase form
            purchaseForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmPurchase form
            FrmOrders purchaseForm = new FrmOrders();
            purchaseForm.mainPanel = main;

            // Clear the main panel before adding the new form
            main.Controls.Clear();

            // Set the parent of the purchase form to the main form
            purchaseForm.TopLevel = false;
            purchaseForm.FormBorderStyle = FormBorderStyle.None;
            purchaseForm.Dock = DockStyle.Fill;

            // Add the purchase form to the main panel
            main.Controls.Add(purchaseForm);

            // Show the purchase form
            purchaseForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Create an instance of the FrmPurchase form
            FrmSuppliers purchaseForm = new FrmSuppliers();
            purchaseForm.mainPanel = main;

            // Clear the main panel before adding the new form
            main.Controls.Clear();

            // Set the parent of the purchase form to the main form
            purchaseForm.TopLevel = false;
            purchaseForm.FormBorderStyle = FormBorderStyle.None;
            purchaseForm.Dock = DockStyle.Fill;

            // Add the purchase form to the main panel
            main.Controls.Add(purchaseForm);

            // Show the purchase form
            purchaseForm.Show();
        }

        private void main_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
