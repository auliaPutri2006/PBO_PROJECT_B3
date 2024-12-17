using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using PBO_PROJECT_B3.context;
using PBO_PROJECT_B3.core;

namespace PBO_PROJECT_B3.view
{
    public partial class V_Login : Form
    {
        public V_Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

            string input_pengguna = tbLogin_username.Text.Trim();
            string pass_pengguna = tbLogin_Password.Text.Trim();

            // Validasi input kosong
            if (string.IsNullOrWhiteSpace(input_pengguna) || string.IsNullOrWhiteSpace(pass_pengguna))
            {
                MessageBox.Show("Masukkan username dan password.");
                return;
            }
            else
            {
                try
                {
                    // Periksa apakah username dan password cocok dengan adminUtama
                    if (input_pengguna == "adminUtama" && pass_pengguna == "admin123")
                    {
                        // Jika admin utama, buka form v_addadmin
                        this.Hide();
                        V_AddAdmin v_addadmin5 = new V_AddAdmin();
                        v_addadmin5.Show();
                        return; // Hentikan eksekusi lebih lanjut
                    }

                    // Jika bukan admin utama, lanjutkan proses login
                    DataTable dt = C_admin.loginadmin(input_pengguna, pass_pengguna);

                    if (dt.Rows.Count > 0)
                    {
                        // Ambil status ID untuk validasi
                        int statusId = Convert.ToInt32(dt.Rows[0]["status_id"]);

                        if (statusId == 2  || statusId == 3) // Status pending
                        {
                            MessageBox.Show("Akun Anda dalam status pending atau nonaktif. Hubungi superadmin untuk mengaktifkannya.");
                            return;
                        }

                        // Jika login berhasil, ambil informasi user
                        int Iduser = Convert.ToInt32(dt.Rows[0]["id"]);
                        string username = dt.Rows[0]["username_admin"].ToString();

                        // Tampilkan username di field login (opsional)
                        this.tbLogin_username.Text = username;

                        // Buka dashboard
                        this.Hide();
                        FormDasboard formDasboard1 = new FormDasboard();
                        formDasboard1.Show();
                    }
                    else
                    {
                        // Jika username atau password salah
                        MessageBox.Show("Username atau password salah.");
                    }
                }
                catch (Exception ex)
                {
                    // Tangani error
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
                }
            }



        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            V_Forget v_forget = new V_Forget();
            v_forget.Show();
            this.Hide();
        }
    }
}
