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
    public partial class V_AddCategory : Form
    {
        public V_AddCategory()
        {
            InitializeComponent();
        }

        private void close4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();


            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                V_Login v_login3 = new V_Login();
                v_login3.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDasboard formdashboard4 = new FormDasboard();
            formdashboard4.Show();
            this.Hide();
        }

        private void btnTambahAdmin_Click(object sender, EventArgs e)
        {
            string nama_jenis_produk = tbAddcategory_njp.Text.Trim();



            if (string.IsNullOrWhiteSpace(nama_jenis_produk))
            {
                MessageBox.Show("Masukkan nama jenis produk.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (C_JenisProduk.IsNamaJenisProdukExists(nama_jenis_produk))
            {
                MessageBox.Show("Nama Jenis Produk sudah ada. Silakan Tambahkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            M_Jenis_produk jenis_Baru = new M_Jenis_produk
            {
                nama_jenis_produk = nama_jenis_produk,
            };


            try
            {
                C_JenisProduk.create(jenis_Baru);
                MessageBox.Show("Jenis Produk berhasil ditambahkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable data = C_JenisProduk.all();

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = data;
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapuscategory_Click(object sender, EventArgs e)
        {

        }

        private void btnPerbaruicategory_Click(object sender, EventArgs e)
        {
            string nama_jenis_produkLama = tbAddcategory_njpLama.Text.Trim();
            string nama_jenis_produkBaru = tbPerbarui_njpcategory.Text.Trim();

            if (string.IsNullOrWhiteSpace(nama_jenis_produkLama) || string.IsNullOrWhiteSpace(nama_jenis_produkBaru))
            {
                MessageBox.Show("Harap isi semua kolom.");
                return;
            }

            try
            {

                DataTable dt = C_JenisProduk.checkNJP((nama_jenis_produkLama));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Nama jenis Produk Lama tidak ditemukan.");
                    return;
                }


                int id = Convert.ToInt32(dt.Rows[0]["id"]);


                M_Jenis_produk editJenisProduk = new M_Jenis_produk
                {
                    id = id,
                    nama_jenis_produk = nama_jenis_produkBaru,
                };

                C_JenisProduk.update(editJenisProduk);

                MessageBox.Show("Nama jenis produk berhasil diperbarui.");

                tbAddcategory_njpLama.Clear();
                tbPerbarui_njpcategory.Clear();



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddcategory_addAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnaddcategory_addproduct_Click(object sender, EventArgs e)
        {
            V_AddProduk v_addproduk9 = new V_AddProduk();
            v_addproduk9.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            V_Transaksi v_transaksi5 = new V_Transaksi();
            v_transaksi5.Show();
            this.Hide();
        }
    }

}
