namespace PBO_PROJECT_B3.view
{
    partial class FormDasboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDasboard));
            panel1 = new Panel();
            label1 = new Label();
            close3 = new Button();
            panel2 = new Panel();
            btnformdashboard_transaksi = new Button();
            btnAddCategory = new Button();
            btLogout = new Button();
            button5 = new Button();
            button3 = new Button();
            button1 = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel4 = new Panel();
            button2 = new Button();
            panel7 = new Panel();
            pictureBox4 = new PictureBox();
            tbDashboard_produk = new TextBox();
            panel6 = new Panel();
            pictureBox3 = new PictureBox();
            tbTransaksi_pendapatan = new TextBox();
            panel5 = new Panel();
            pictureBox2 = new PictureBox();
            tbDashboard_transaksi = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dtpDashboard = new DateTimePicker();
            datagrid_formdashboard = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)datagrid_formdashboard).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(close3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1047, 52);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(544, 23);
            label1.TabIndex = 4;
            label1.Text = "MENAGEMENT DIGITAL SYSTEM  MELINJO : MEGAMIN";
            label1.Click += label1_Click;
            // 
            // close3
            // 
            close3.BackColor = Color.Red;
            close3.FlatAppearance.BorderColor = Color.Black;
            close3.FlatStyle = FlatStyle.Flat;
            close3.ForeColor = Color.White;
            close3.Location = new Point(970, 13);
            close3.Name = "close3";
            close3.Size = new Size(56, 25);
            close3.TabIndex = 3;
            close3.Text = "X";
            close3.UseVisualStyleBackColor = false;
            close3.Click += close2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkOliveGreen;
            panel2.Controls.Add(btnformdashboard_transaksi);
            panel2.Controls.Add(btnAddCategory);
            panel2.Controls.Add(btLogout);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 52);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 628);
            panel2.TabIndex = 1;
            // 
            // btnformdashboard_transaksi
            // 
            btnformdashboard_transaksi.FlatAppearance.BorderSize = 0;
            btnformdashboard_transaksi.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            btnformdashboard_transaksi.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            btnformdashboard_transaksi.FlatStyle = FlatStyle.Flat;
            btnformdashboard_transaksi.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnformdashboard_transaksi.ForeColor = Color.Transparent;
            btnformdashboard_transaksi.Location = new Point(28, 369);
            btnformdashboard_transaksi.Name = "btnformdashboard_transaksi";
            btnformdashboard_transaksi.Size = new Size(188, 30);
            btnformdashboard_transaksi.TabIndex = 30;
            btnformdashboard_transaksi.Text = "Add Transaction\r\n\r\n";
            btnformdashboard_transaksi.UseVisualStyleBackColor = true;
            btnformdashboard_transaksi.Click += btnformdashboard_transaksi_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.FlatAppearance.BorderSize = 0;
            btnAddCategory.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            btnAddCategory.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddCategory.ForeColor = Color.Transparent;
            btnAddCategory.Location = new Point(28, 316);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(188, 30);
            btnAddCategory.TabIndex = 29;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btLogout
            // 
            btLogout.BackColor = Color.OliveDrab;
            btLogout.FlatAppearance.BorderSize = 0;
            btLogout.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            btLogout.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            btLogout.FlatStyle = FlatStyle.Flat;
            btLogout.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btLogout.ForeColor = Color.Transparent;
            btLogout.Location = new Point(28, 576);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(188, 30);
            btLogout.TabIndex = 21;
            btLogout.Text = "Logout";
            btLogout.UseVisualStyleBackColor = false;
            btLogout.Click += button6_Click;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            button5.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.Transparent;
            button5.Location = new Point(3, 352);
            button5.Name = "button5";
            button5.Size = new Size(1047, 680);
            button5.TabIndex = 20;
            button5.Text = "Add Category";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            button3.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(28, 262);
            button3.Name = "button3";
            button3.Size = new Size(188, 30);
            button3.TabIndex = 18;
            button3.Text = "Add Product";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            button1.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(28, 213);
            button1.Name = "button1";
            button1.Size = new Size(188, 30);
            button1.TabIndex = 16;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(67, 113);
            label2.Name = "label2";
            label2.Size = new Size(108, 18);
            label2.TabIndex = 15;
            label2.Text = "Welcome back";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(67, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(108, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(250, 52);
            panel3.Name = "panel3";
            panel3.Size = new Size(797, 628);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(button2);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(dtpDashboard);
            panel4.Controls.Add(datagrid_formdashboard);
            panel4.Dock = DockStyle.Fill;
            panel4.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(797, 628);
            panel4.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkOliveGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(85, 214);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 12;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkOliveGreen;
            panel7.Controls.Add(pictureBox4);
            panel7.Controls.Add(tbDashboard_produk);
            panel7.Location = new Point(580, 38);
            panel7.Name = "panel7";
            panel7.Size = new Size(196, 144);
            panel7.TabIndex = 11;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(50, 10);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(100, 62);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // tbDashboard_produk
            // 
            tbDashboard_produk.Location = new Point(40, 87);
            tbDashboard_produk.Name = "tbDashboard_produk";
            tbDashboard_produk.Size = new Size(125, 28);
            tbDashboard_produk.TabIndex = 0;
            tbDashboard_produk.TextChanged += tbDashboard_produk_TextChanged;
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkOliveGreen;
            panel6.Controls.Add(pictureBox3);
            panel6.Controls.Add(tbTransaksi_pendapatan);
            panel6.Location = new Point(328, 38);
            panel6.Name = "panel6";
            panel6.Size = new Size(194, 144);
            panel6.TabIndex = 10;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(51, 10);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 62);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // tbTransaksi_pendapatan
            // 
            tbTransaksi_pendapatan.Location = new Point(40, 87);
            tbTransaksi_pendapatan.Name = "tbTransaksi_pendapatan";
            tbTransaksi_pendapatan.Size = new Size(125, 28);
            tbTransaksi_pendapatan.TabIndex = 0;
            tbTransaksi_pendapatan.TextChanged += tbTransaksi_pendapatan_TextChanged;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkOliveGreen;
            panel5.Controls.Add(pictureBox2);
            panel5.Controls.Add(tbDashboard_transaksi);
            panel5.Location = new Point(63, 38);
            panel5.Name = "panel5";
            panel5.Size = new Size(215, 144);
            panel5.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(57, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // tbDashboard_transaksi
            // 
            tbDashboard_transaksi.Location = new Point(44, 87);
            tbDashboard_transaksi.Name = "tbDashboard_transaksi";
            tbDashboard_transaksi.Size = new Size(125, 28);
            tbDashboard_transaksi.TabIndex = 0;
            tbDashboard_transaksi.TextChanged += tbDashboard_transaksi_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(587, 14);
            label5.Name = "label5";
            label5.Size = new Size(189, 21);
            label5.TabIndex = 8;
            label5.Text = "Total Produk Terjual";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(342, 13);
            label4.Name = "label4";
            label4.Size = new Size(170, 21);
            label4.TabIndex = 6;
            label4.Text = "Total Pendapatan ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(62, 14);
            label3.Name = "label3";
            label3.Size = new Size(151, 21);
            label3.TabIndex = 4;
            label3.Text = "Total Transaksi ";
            // 
            // dtpDashboard
            // 
            dtpDashboard.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDashboard.Location = new Point(511, 213);
            dtpDashboard.Name = "dtpDashboard";
            dtpDashboard.Size = new Size(250, 25);
            dtpDashboard.TabIndex = 2;
            dtpDashboard.ValueChanged += dtpDashboard_ValueChanged;
            // 
            // datagrid_formdashboard
            // 
            datagrid_formdashboard.AllowUserToAddRows = false;
            datagrid_formdashboard.AllowUserToDeleteRows = false;
            datagrid_formdashboard.BackgroundColor = Color.DarkOliveGreen;
            datagrid_formdashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid_formdashboard.Location = new Point(62, 262);
            datagrid_formdashboard.Name = "datagrid_formdashboard";
            datagrid_formdashboard.ReadOnly = true;
            datagrid_formdashboard.RowHeadersWidth = 51;
            datagrid_formdashboard.Size = new Size(699, 319);
            datagrid_formdashboard.TabIndex = 0;
            datagrid_formdashboard.CellContentClick += dataGridView1_CellContentClick;
            // 
            // FormDasboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 680);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDasboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDasboard";
            Load += FormDasboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)datagrid_formdashboard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button close3;
        private Panel panel2;
        private Button button1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button button3;
        private Button button5;
        private Button btLogout;
        private Panel panel3;
        private Panel panel4;
        private Button btnAddCategory;
        private Button btnformdashboard_transaksi;
        private DateTimePicker dtpDashboard;
        private DataGridView datagrid_formdashboard;
        private Label label3;
        private Label label4;
        private Panel panel6;
        private Panel panel5;
        private TextBox tbDashboard_transaksi;
        private Label label5;
        private Panel panel7;
        private TextBox tbDashboard_produk;
        private TextBox tbTransaksi_pendapatan;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button button2;
    }
}