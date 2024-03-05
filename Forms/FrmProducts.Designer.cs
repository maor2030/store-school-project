namespace MaorSaban215713587.Forms
{
    partial class FrmProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProducts));
            this.newProduct = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.pSearch = new System.Windows.Forms.Label();
            this.pDelete = new System.Windows.Forms.Button();
            this.productsCategory = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maorSaban215713587DataSet = new MaorSaban215713587.MaorSaban215713587DataSet();
            this.productsTableAdapter = new MaorSaban215713587.MaorSaban215713587DataSetTableAdapters.ProductsTableAdapter();
            this.maorSaban215713587DataSet1 = new MaorSaban215713587.MaorSaban215713587DataSet1();
            this.productsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter1 = new MaorSaban215713587.MaorSaban215713587DataSet1TableAdapters.ProductsTableAdapter();
            this.pedit = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.productsCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maorSaban215713587DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maorSaban215713587DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // newProduct
            // 
            this.newProduct.Location = new System.Drawing.Point(536, 364);
            this.newProduct.Name = "newProduct";
            this.newProduct.Size = new System.Drawing.Size(75, 23);
            this.newProduct.TabIndex = 27;
            this.newProduct.Text = "New";
            this.newProduct.UseVisualStyleBackColor = true;
            this.newProduct.Click += new System.EventHandler(this.newProduct_Click);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(390, 415);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(75, 23);
            this.forward.TabIndex = 25;
            this.forward.Text = ">";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(294, 415);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 24;
            this.back.Text = "<";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(78, 369);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(258, 20);
            this.searchTextBox.TabIndex = 23;
            this.searchTextBox.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // pSearch
            // 
            this.pSearch.AutoSize = true;
            this.pSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pSearch.Location = new System.Drawing.Point(12, 367);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(60, 20);
            this.pSearch.TabIndex = 22;
            this.pSearch.Text = "Search";
            this.pSearch.Click += new System.EventHandler(this.pSearch_Click);
            // 
            // pDelete
            // 
            this.pDelete.Location = new System.Drawing.Point(455, 364);
            this.pDelete.Name = "pDelete";
            this.pDelete.Size = new System.Drawing.Size(75, 23);
            this.pDelete.TabIndex = 28;
            this.pDelete.Text = "Delete";
            this.pDelete.UseVisualStyleBackColor = true;
            this.pDelete.Click += new System.EventHandler(this.pDelete_Click);
            // 
            // productsCategory
            // 
            this.productsCategory.Controls.Add(this.pictureBox5);
            this.productsCategory.Controls.Add(this.pictureBox4);
            this.productsCategory.Controls.Add(this.pictureBox3);
            this.productsCategory.Controls.Add(this.pictureBox2);
            this.productsCategory.Controls.Add(this.pictureBox1);
            this.productsCategory.Location = new System.Drawing.Point(2, 12);
            this.productsCategory.Name = "productsCategory";
            this.productsCategory.Size = new System.Drawing.Size(710, 139);
            this.productsCategory.TabIndex = 21;
            this.productsCategory.TabStop = false;
            this.productsCategory.Text = "Category";
            this.productsCategory.Enter += new System.EventHandler(this.productsCategory_Enter);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(602, 44);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(100, 54);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 30;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(453, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(143, 103);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 29;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(303, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(144, 103);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(153, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(144, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(700, 187);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.maorSaban215713587DataSet;
            this.productsBindingSource.CurrentChanged += new System.EventHandler(this.productsBindingSource_CurrentChanged);
            // 
            // maorSaban215713587DataSet
            // 
            this.maorSaban215713587DataSet.DataSetName = "MaorSaban215713587DataSet";
            this.maorSaban215713587DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // maorSaban215713587DataSet1
            // 
            this.maorSaban215713587DataSet1.DataSetName = "MaorSaban215713587DataSet1";
            this.maorSaban215713587DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsBindingSource1
            // 
            this.productsBindingSource1.DataMember = "Products";
            this.productsBindingSource1.DataSource = this.maorSaban215713587DataSet1;
            this.productsBindingSource1.CurrentChanged += new System.EventHandler(this.productsBindingSource1_CurrentChanged);
            // 
            // productsTableAdapter1
            // 
            this.productsTableAdapter1.ClearBeforeFill = true;
            // 
            // pedit
            // 
            this.pedit.Location = new System.Drawing.Point(617, 364);
            this.pedit.Name = "pedit";
            this.pedit.Size = new System.Drawing.Size(75, 23);
            this.pedit.TabIndex = 30;
            this.pedit.Text = "Edit";
            this.pedit.UseVisualStyleBackColor = true;
            this.pedit.Click += new System.EventHandler(this.pedit_Click);
            // 
            // FrmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pedit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pDelete);
            this.Controls.Add(this.newProduct);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.back);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.pSearch);
            this.Controls.Add(this.productsCategory);
            this.Name = "FrmProducts";
            this.Text = "FrmOrders";
            this.Load += new System.EventHandler(this.FrmOrders_Load);
            this.productsCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maorSaban215713587DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maorSaban215713587DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newProduct;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label pSearch;
        private System.Windows.Forms.Button pDelete;
        private System.Windows.Forms.GroupBox productsCategory;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MaorSaban215713587DataSet maorSaban215713587DataSet;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private MaorSaban215713587DataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
        private MaorSaban215713587DataSet1 maorSaban215713587DataSet1;
        private System.Windows.Forms.BindingSource productsBindingSource1;
        private MaorSaban215713587DataSet1TableAdapters.ProductsTableAdapter productsTableAdapter1;
        private System.Windows.Forms.Button pedit;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}