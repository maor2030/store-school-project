namespace MaorSaban215713587.Forms
{
    partial class FrmnewSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmnewSupplier));
            this.cityinput = new System.Windows.Forms.TextBox();
            this.pcompany = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.addressinput = new System.Windows.Forms.TextBox();
            this.idinput = new System.Windows.Forms.TextBox();
            this.nameinput = new System.Windows.Forms.TextBox();
            this.pname = new System.Windows.Forms.Label();
            this.pcolor = new System.Windows.Forms.Label();
            this.pcode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // cityinput
            // 
            this.cityinput.Location = new System.Drawing.Point(522, 145);
            this.cityinput.Name = "cityinput";
            this.cityinput.Size = new System.Drawing.Size(100, 20);
            this.cityinput.TabIndex = 41;
            // 
            // pcompany
            // 
            this.pcompany.AutoSize = true;
            this.pcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pcompany.Location = new System.Drawing.Point(407, 139);
            this.pcompany.Name = "pcompany";
            this.pcompany.Size = new System.Drawing.Size(49, 25);
            this.pcompany.TabIndex = 40;
            this.pcompany.Text = "City";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(326, 315);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(406, 315);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // addressinput
            // 
            this.addressinput.Location = new System.Drawing.Point(247, 142);
            this.addressinput.Name = "addressinput";
            this.addressinput.Size = new System.Drawing.Size(100, 20);
            this.addressinput.TabIndex = 35;
            // 
            // idinput
            // 
            this.idinput.Location = new System.Drawing.Point(247, 87);
            this.idinput.Name = "idinput";
            this.idinput.Size = new System.Drawing.Size(100, 20);
            this.idinput.TabIndex = 33;
            // 
            // nameinput
            // 
            this.nameinput.Location = new System.Drawing.Point(522, 88);
            this.nameinput.Name = "nameinput";
            this.nameinput.Size = new System.Drawing.Size(100, 20);
            this.nameinput.TabIndex = 31;
            // 
            // pname
            // 
            this.pname.AutoSize = true;
            this.pname.BackColor = System.Drawing.Color.Transparent;
            this.pname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pname.Location = new System.Drawing.Point(407, 85);
            this.pname.Name = "pname";
            this.pname.Size = new System.Drawing.Size(106, 25);
            this.pname.TabIndex = 28;
            this.pname.Text = "Full name";
            // 
            // pcolor
            // 
            this.pcolor.AutoSize = true;
            this.pcolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pcolor.Location = new System.Drawing.Point(158, 139);
            this.pcolor.Name = "pcolor";
            this.pcolor.Size = new System.Drawing.Size(91, 25);
            this.pcolor.TabIndex = 27;
            this.pcolor.Text = "Address";
            // 
            // pcode
            // 
            this.pcode.AutoSize = true;
            this.pcode.BackColor = System.Drawing.Color.Transparent;
            this.pcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pcode.Location = new System.Drawing.Point(158, 87);
            this.pcode.Name = "pcode";
            this.pcode.Size = new System.Drawing.Size(29, 25);
            this.pcode.TabIndex = 26;
            this.pcode.Text = "Id";
            // 
            // FrmnewSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cityinput);
            this.Controls.Add(this.pcompany);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.addressinput);
            this.Controls.Add(this.idinput);
            this.Controls.Add(this.nameinput);
            this.Controls.Add(this.pname);
            this.Controls.Add(this.pcolor);
            this.Controls.Add(this.pcode);
            this.Name = "FrmnewSupplier";
            this.Text = "FrmnewSupplier";
            this.Load += new System.EventHandler(this.FrmnewSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox cityinput;
        private System.Windows.Forms.Label pcompany;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox addressinput;
        private System.Windows.Forms.TextBox idinput;
        private System.Windows.Forms.TextBox nameinput;
        private System.Windows.Forms.Label pname;
        private System.Windows.Forms.Label pcolor;
        private System.Windows.Forms.Label pcode;
    }
}