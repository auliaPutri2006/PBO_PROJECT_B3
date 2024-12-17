namespace PBO_PROJECT_B3.view
{
    partial class V_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_Login));
            panel1 = new Panel();
            Lb_login = new Label();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btn_Login = new Button();
            tbLogin_Password = new TextBox();
            tbLogin_username = new TextBox();
            label1 = new Label();
            close = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(Lb_login);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btn_Login);
            panel1.Controls.Add(tbLogin_Password);
            panel1.Controls.Add(tbLogin_username);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(49, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 463);
            panel1.TabIndex = 0;
            // 
            // Lb_login
            // 
            Lb_login.AutoSize = true;
            Lb_login.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Lb_login.ForeColor = Color.DarkOliveGreen;
            Lb_login.Location = new Point(327, 378);
            Lb_login.Name = "Lb_login";
            Lb_login.Size = new Size(77, 18);
            Lb_login.TabIndex = 8;
            Lb_login.Text = "Click Here";
            Lb_login.Click += label3_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(203, 378);
            label2.Name = "label2";
            label2.Size = new Size(118, 18);
            label2.TabIndex = 7;
            label2.Text = "Reset Password";
            label2.Click += label2_Click_1;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(154, 272);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(154, 220);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(245, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.DarkOliveGreen;
            btn_Login.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(154, 317);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(306, 48);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // tbLogin_Password
            // 
            tbLogin_Password.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbLogin_Password.Location = new Point(203, 272);
            tbLogin_Password.Name = "tbLogin_Password";
            tbLogin_Password.PasswordChar = '*';
            tbLogin_Password.Size = new Size(257, 30);
            tbLogin_Password.TabIndex = 2;
            // 
            // tbLogin_username
            // 
            tbLogin_username.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbLogin_username.Location = new Point(203, 220);
            tbLogin_username.Name = "tbLogin_username";
            tbLogin_username.Size = new Size(257, 30);
            tbLogin_username.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(203, 156);
            label1.Name = "label1";
            label1.Size = new Size(175, 27);
            label1.TabIndex = 0;
            label1.Text = "Login Account";
            // 
            // close
            // 
            close.BackColor = Color.Red;
            close.FlatAppearance.BorderColor = Color.Black;
            close.FlatStyle = FlatStyle.Flat;
            close.ForeColor = Color.White;
            close.Location = new Point(625, 12);
            close.Name = "close";
            close.Size = new Size(56, 25);
            close.TabIndex = 1;
            close.Text = "X";
            close.UseVisualStyleBackColor = false;
            close.Click += close_Click;
            // 
            // V_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOliveGreen;
            ClientSize = new Size(693, 531);
            Controls.Add(close);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "V_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button close;
        private Label label1;
        private Button btn_Login;
        private TextBox tbLogin_Password;
        private TextBox tbLogin_username;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label2;
        private Label Lb_login;
    }
}