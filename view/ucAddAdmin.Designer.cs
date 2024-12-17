namespace PBO_PROJECT_B3.view
{
    partial class ucAddAdmin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            tbAddAdmin_username = new TextBox();
            tbAddAdmin_password = new TextBox();
            label2 = new Label();
            btnTambahAdmin = new Button();
            btnPerbaruiAdmin = new Button();
            btnHapusAdmin = new Button();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnHapusAdmin);
            panel1.Controls.Add(btnPerbaruiAdmin);
            panel1.Controls.Add(btnTambahAdmin);
            panel1.Controls.Add(tbAddAdmin_password);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbAddAdmin_username);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(18, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 545);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(291, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(506, 545);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 32);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // tbAddAdmin_username
            // 
            tbAddAdmin_username.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbAddAdmin_username.Location = new Point(19, 65);
            tbAddAdmin_username.Name = "tbAddAdmin_username";
            tbAddAdmin_username.Size = new Size(209, 27);
            tbAddAdmin_username.TabIndex = 1;
            // 
            // tbAddAdmin_password
            // 
            tbAddAdmin_password.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbAddAdmin_password.Location = new Point(19, 148);
            tbAddAdmin_password.Name = "tbAddAdmin_password";
            tbAddAdmin_password.Size = new Size(209, 27);
            tbAddAdmin_password.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 115);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // btnTambahAdmin
            // 
            btnTambahAdmin.BackColor = Color.DarkOliveGreen;
            btnTambahAdmin.FlatAppearance.BorderColor = Color.DarkOliveGreen;
            btnTambahAdmin.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            btnTambahAdmin.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            btnTambahAdmin.FlatStyle = FlatStyle.Flat;
            btnTambahAdmin.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahAdmin.ForeColor = Color.White;
            btnTambahAdmin.Location = new Point(19, 212);
            btnTambahAdmin.Name = "btnTambahAdmin";
            btnTambahAdmin.Size = new Size(209, 42);
            btnTambahAdmin.TabIndex = 4;
            btnTambahAdmin.Text = "Tambah";
            btnTambahAdmin.UseVisualStyleBackColor = false;
            btnTambahAdmin.Click += btnTambahAdmin_Click;
            // 
            // btnPerbaruiAdmin
            // 
            btnPerbaruiAdmin.BackColor = Color.DarkOliveGreen;
            btnPerbaruiAdmin.FlatAppearance.BorderColor = Color.DarkOliveGreen;
            btnPerbaruiAdmin.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            btnPerbaruiAdmin.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            btnPerbaruiAdmin.FlatStyle = FlatStyle.Flat;
            btnPerbaruiAdmin.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPerbaruiAdmin.ForeColor = Color.White;
            btnPerbaruiAdmin.Location = new Point(19, 281);
            btnPerbaruiAdmin.Name = "btnPerbaruiAdmin";
            btnPerbaruiAdmin.Size = new Size(209, 42);
            btnPerbaruiAdmin.TabIndex = 5;
            btnPerbaruiAdmin.Text = "Perbarui";
            btnPerbaruiAdmin.UseVisualStyleBackColor = false;
            // 
            // btnHapusAdmin
            // 
            btnHapusAdmin.BackColor = Color.DarkOliveGreen;
            btnHapusAdmin.FlatAppearance.BorderColor = Color.DarkOliveGreen;
            btnHapusAdmin.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            btnHapusAdmin.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;
            btnHapusAdmin.FlatStyle = FlatStyle.Flat;
            btnHapusAdmin.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapusAdmin.ForeColor = Color.White;
            btnHapusAdmin.Location = new Point(19, 348);
            btnHapusAdmin.Name = "btnHapusAdmin";
            btnHapusAdmin.Size = new Size(209, 42);
            btnHapusAdmin.TabIndex = 6;
            btnHapusAdmin.Text = "Hapus";
            btnHapusAdmin.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 19);
            label3.Name = "label3";
            label3.Size = new Size(165, 20);
            label3.TabIndex = 7;
            label3.Text = "Data Semua Admin";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DarkOliveGreen;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(464, 466);
            dataGridView1.TabIndex = 8;
            // 
            // ucAddAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucAddAdmin";
            Size = new Size(819, 576);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnTambahAdmin;
        private TextBox tbAddAdmin_password;
        private Label label2;
        private TextBox tbAddAdmin_username;
        private Label label1;
        private Panel panel2;
        private Button btnHapusAdmin;
        private Button btnPerbaruiAdmin;
        private DataGridView dataGridView1;
        private Label label3;
    }
}
