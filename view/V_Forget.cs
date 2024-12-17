using PBO_PROJECT_B3.context;
using PBO_PROJECT_B3.core;
using PBO_PROJECT_B3.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBO_PROJECT_B3.view
{
    public partial class V_Forget : Form
    {
        public V_Forget()
        {
            InitializeComponent();
        }

        private void close2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            V_Login v_login = new V_Login();

            v_login.Show();
            this.Hide();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            string usernameLama = tbreset_UsernameLama.Text;
            string passwordLama = tbreset_PasswordLama.Text;
            string passwordBaru = tbreset_PasswordBaru.Text;

            if (string.IsNullOrWhiteSpace(usernameLama) || string.IsNullOrWhiteSpace(passwordLama) || string.IsNullOrWhiteSpace(passwordBaru))
            {
                MessageBox.Show("Harap isi semua kolom.");
                return;
            }

            try
            {
                DataTable dt = C_adminBiasa.LoginAdmin(usernameLama, passwordLama);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Username atau password lama salah.");
                    return;
                }

                int id = Convert.ToInt32(dt.Rows[0]["id"]);

                M_Administrator editAdmin = new M_Administrator
                {
                    id = id,
                    username_admin = usernameLama, 
                    pass_admin = passwordBaru      
                };

                C_adminBiasa.UpdateStatusToPending(editAdmin);
                MessageBox.Show("Perubahan Anda sedang diproses. Status akun Anda: Pending.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
