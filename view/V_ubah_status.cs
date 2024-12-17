using PBO_PROJECT_B3.core;
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
using PBO_PROJECT_B3.model;

namespace PBO_PROJECT_B3.view
{
    public partial class ubah_status : Form
    {
        public ubah_status()
        {
            InitializeComponent();
        }

        private void btnAddcategory_addAdmin_Click(object sender, EventArgs e)
        {
            V_AddAdmin v_AddAdmin4 = new V_AddAdmin();
            v_AddAdmin4.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable data = C_adminBiasa.all();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = data;
            ;
        }

        private void btnTambahAdmin_Click(object sender, EventArgs e)
        {
            // Get inputs
            int idPengguna = int.Parse(tbAddkonfir_id.Text.Trim());
            string selectedStatus = cbstatus_konfir.Text.Trim();

            // Call controller to update status
            C_adminBiasa.UpdateAdministratorStatus(idPengguna, selectedStatus);

            // Notify user
            MessageBox.Show("Status berhasil diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear inputs
            tbAddkonfir_id.Clear();
            cbstatus_konfir.SelectedIndex = -1;

        }

        private void close5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();


            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                V_Login v_login2 = new V_Login();
                v_login2.Show();
                this.Hide();
            }
        }
    }
}
