using System;

namespace MaorSaban215713587.Forms
{
    partial class FrmnewProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmnewProduct));
            this.pcolor = new System.Windows.Forms.Label();
            this.pname = new System.Windows.Forms.Label();
            this.pcategory = new System.Windows.Forms.Label();
            this.pgender = new System.Windows.Forms.Label();
            this.nameinput = new System.Windows.Forms.TextBox();
            this.genderinput = new System.Windows.Forms.TextBox();
            this.colorinput = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pprice = new System.Windows.Forms.Label();
            this.priceinput = new System.Windows.Forms.TextBox();
            this.pcompany = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.companyinput = new System.Windows.Forms.TextBox();
            this.supplierCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pcolor
            // 
            this.pcolor.AutoSize = true;
            this.pcolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pcolor.Location = new System.Drawing.Point(148, 102);
            this.pcolor.Name = "pcolor";
            this.pcolor.Size = new System.Drawing.Size(63, 25);
            this.pcolor.TabIndex = 5;
            this.pcolor.Text = "Color";
            // 
            // pname
            // 
            this.pname.AutoSize = true;
            this.pname.BackColor = System.Drawing.Color.Transparent;
            this.pname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pname.Location = new System.Drawing.Point(148, 56);
            this.pname.Name = "pname";
            this.pname.Size = new System.Drawing.Size(68, 25);
            this.pname.TabIndex = 6;
            this.pname.Text = "Name";
            // 
            // pcategory
            // 
            this.pcategory.AutoSize = true;
            this.pcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pcategory.Location = new System.Drawing.Point(401, 152);
            this.pcategory.Name = "pcategory";
            this.pcategory.Size = new System.Drawing.Size(99, 25);
            this.pcategory.TabIndex = 7;
            this.pcategory.Text = "Category";
            // 
            // pgender
            // 
            this.pgender.AutoSize = true;
            this.pgender.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pgender.Location = new System.Drawing.Point(401, 57);
            this.pgender.Name = "pgender";
            this.pgender.Size = new System.Drawing.Size(83, 25);
            this.pgender.TabIndex = 10;
            this.pgender.Text = "Gender";
            // 
            // nameinput
            // 
            this.nameinput.Location = new System.Drawing.Point(247, 56);
            this.nameinput.Name = "nameinput";
            this.nameinput.Size = new System.Drawing.Size(100, 20);
            this.nameinput.TabIndex = 12;
            // 
            // genderinput
            // 
            this.genderinput.Location = new System.Drawing.Point(512, 62);
            this.genderinput.Name = "genderinput";
            this.genderinput.Size = new System.Drawing.Size(100, 20);
            this.genderinput.TabIndex = 14;
            // 
            // colorinput
            // 
            this.colorinput.Location = new System.Drawing.Point(247, 105);
            this.colorinput.Name = "colorinput";
            this.colorinput.Size = new System.Drawing.Size(100, 20);
            this.colorinput.TabIndex = 17;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(399, 331);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(320, 331);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pprice
            // 
            this.pprice.AutoSize = true;
            this.pprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pprice.Location = new System.Drawing.Point(150, 146);
            this.pprice.Name = "pprice";
            this.pprice.Size = new System.Drawing.Size(61, 25);
            this.pprice.TabIndex = 21;
            this.pprice.Text = "Price";
            // 
            // priceinput
            // 
            this.priceinput.Location = new System.Drawing.Point(247, 152);
            this.priceinput.Name = "priceinput";
            this.priceinput.Size = new System.Drawing.Size(100, 20);
            this.priceinput.TabIndex = 22;
            // 
            // pcompany
            // 
            this.pcompany.AutoSize = true;
            this.pcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pcompany.Location = new System.Drawing.Point(397, 102);
            this.pcompany.Name = "pcompany";
            this.pcompany.Size = new System.Drawing.Size(103, 25);
            this.pcompany.TabIndex = 23;
            this.pcompany.Text = "Company";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(512, 158);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryComboBox.TabIndex = 25;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // companyinput
            // 
            this.companyinput.Location = new System.Drawing.Point(512, 108);
            this.companyinput.Name = "companyinput";
            this.companyinput.Size = new System.Drawing.Size(100, 20);
            this.companyinput.TabIndex = 24;
            this.companyinput.TextChanged += new System.EventHandler(this.companyinput_TextChanged);
            // 
            // supplierCombo
            // 
            this.supplierCombo.FormattingEnabled = true;
            this.supplierCombo.Location = new System.Drawing.Point(247, 200);
            this.supplierCombo.Name = "supplierCombo";
            this.supplierCombo.Size = new System.Drawing.Size(121, 21);
            this.supplierCombo.TabIndex = 27;
            this.supplierCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(150, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Supplier";
            // 
            // FrmnewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.supplierCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.companyinput);
            this.Controls.Add(this.pcompany);
            this.Controls.Add(this.priceinput);
            this.Controls.Add(this.pprice);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.colorinput);
            this.Controls.Add(this.genderinput);
            this.Controls.Add(this.nameinput);
            this.Controls.Add(this.pgender);
            this.Controls.Add(this.pcategory);
            this.Controls.Add(this.pname);
            this.Controls.Add(this.pcolor);
            this.Name = "FrmnewProduct";
            this.Text = "FrmnewProduct";
            this.Load += new System.EventHandler(this.FrmnewProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label pcolor;
        private System.Windows.Forms.Label pname;
        private System.Windows.Forms.Label pcategory;
        private System.Windows.Forms.Label pgender;
        private System.Windows.Forms.TextBox nameinput;
        private System.Windows.Forms.TextBox genderinput;
        private System.Windows.Forms.TextBox colorinput;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label pprice;
        private System.Windows.Forms.TextBox priceinput;
        private System.Windows.Forms.Label pcompany;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.TextBox companyinput;
        private System.Windows.Forms.ComboBox supplierCombo;
        private System.Windows.Forms.Label label1;
    }
}