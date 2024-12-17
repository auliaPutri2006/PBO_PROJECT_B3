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
using PBO_PROJECT_B3.context;

namespace PBO_PROJECT_B3.view
{
    public partial class V_AddAdmin : Form
    {
        public V_AddAdmin()
        {
            InitializeComponent();
        }

        private void ucAddAdmin1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucAddAdmin1_Load_1(object sender, EventArgs e)
        {
            string input_pengguna = tbAddAdmin_username.Text.Trim();
            string pass_pengguna = tbAddAdmin_password.Text.Trim();


            if (string.IsNullOrWhiteSpace(input_pengguna) || string.IsNullOrWhiteSpace(pass_pengguna))
            {
                MessageBox.Show("Masukkan username dan password.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (C_admin.IsUsernameExists(input_pengguna))
            {
                MessageBox.Show("Username sudah ada. Silakan gunakan username lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            M_Administrator adminBaru = new M_Administrator
            {
                username_admin = input_pengguna,
                pass_admin = pass_pengguna
            };


            try
            {
                C_admin.create(adminBaru);
                MessageBox.Show("Username dan password berhasil ditambah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambahAdmin_Click(object sender, EventArgs e)
        {

            string input_pengguna = tbAddAdmin_username.Text.Trim();
            string pass_pengguna = tbAddAdmin_password.Text.Trim();


            string selectedStatus = cbstatus_add.Text.Trim();
            int statusId;


            if (selectedStatus.Equals("aktif", StringComparison.OrdinalIgnoreCase))
            {
                statusId = 1;
            }
            else if (selectedStatus.Equals("pending", StringComparison.OrdinalIgnoreCase))
            {
                statusId = 2;
            }
            else if (selectedStatus.Equals("nonaktif", StringComparison.OrdinalIgnoreCase))
            {
                statusId = 3;
            }
            else
            {
                MessageBox.Show("Status yang dipilih tidak valid. Silakan pilih status yang sesuai.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(input_pengguna) || string.IsNullOrWhiteSpace(pass_pengguna))
            {
                MessageBox.Show("Masukkan username dan password.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (C_admin.IsUsernameExists(input_pengguna))
            {
                MessageBox.Show("Username sudah ada. Silakan gunakan username lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            M_Administrator adminBaru = new M_Administrator
            {
                username_admin = input_pengguna,
                pass_admin = pass_pengguna,
                status_id = statusId
            };


            try
            {

                C_admin.create(adminBaru);
                MessageBox.Show("Username, password, dan status berhasil ditambah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbAddAdmin_password.Clear();
                tbAddAdmin_username.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPerbaruiAdmin_Click(object sender, EventArgs e)
        {
            string usernameLama = tbPerbarui_usernamaLama.Text;
            string usernameBaru = tbPerbarui_UsernameBaru.Text;
            string passwordBaru = tbPerbarui_Password.Text;

            if (string.IsNullOrWhiteSpace(usernameLama) || string.IsNullOrWhiteSpace(usernameBaru) || string.IsNullOrWhiteSpace(passwordBaru))
            {
                MessageBox.Show("Harap isi semua kolom.");
                return;
            }

            try
            {

                DataTable dt = C_admin.loginadminByUsername(usernameLama);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Username lama tidak ditemukan.");
                    return;
                }


                int id = Convert.ToInt32(dt.Rows[0]["id"]);


                M_Administrator editAdmin = new M_Administrator
                {
                    id = id,
                    username_admin = usernameBaru,
                    pass_admin = passwordBaru
                };

                C_admin.update(editAdmin);

                MessageBox.Show("Username dan password berhasil diperbarui.");

                tbPerbarui_usernamaLama.Clear();
                tbPerbarui_UsernameBaru.Clear();
                tbPerbarui_Password.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }

        }

        private void close3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();


            }
        }

        private void tbPerbarui_usernamaLama_TextChanged(object sender, EventArgs e)
        {

        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                V_Login v_login3 = new V_Login();
                v_login3.Show();
                this.Hide();
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable data = C_admin.all();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = data;
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnaddAdmin_Dashboard_Click(object sender, EventArgs e)
        {
          
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbstatus_add.DataSource = new List<string> { "aktif", "pending", "nonaktif" };

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ubah_status ubah_Status = new ubah_status();
            ubah_Status.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
