using PBO_PROJECT_B3.context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PBO_PROJECT_B3.context.C_produk;

namespace PBO_PROJECT_B3.view
{
    public partial class V_subEditProduk : Form
    {
        private ProdukController _produkController = new ProdukController();

        public V_subEditProduk()
        {
            InitializeComponent();
            LoadJenisProduk();
        }

        private void LoadJenisProduk()
        {
            try
            {
                
                DataTable dtJenisProduk = C_JenisProduk.comboBox();

                if (dtJenisProduk == null || dtJenisProduk.Rows.Count == 0)
                {
                    MessageBox.Show("Data jenis produk tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbsubEditpdk_jenis.DataSource = null;
                    return;
                }

               
                cbsubEditpdk_jenis.DataSource = dtJenisProduk;
                cbsubEditpdk_jenis.DisplayMember = "nama_jenis_produk"; 
                cbsubEditpdk_jenis.ValueMember = "id";                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kesalahan saat memuat jenis produk: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbsubEditpdk_jenis.DataSource = null;
            }
        }

        private void btn_browser2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                openFileDialog.Title = "Pilih Gambar Produk";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    try
                    {
                        pb_fotoproduk2.Image = Image.FromFile(selectedImagePath);
                        pb_fotoproduk2.ImageLocation = selectedImagePath; // Simpan lokasi gambar
                        pb_fotoproduk2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Gagal memuat gambar: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tidak ada gambar yang dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input nama produk lama
                string namaProdukLama = tbsubeditpdk_namaLama.Text.Trim();
                if (string.IsNullOrEmpty(namaProdukLama))
                {
                    MessageBox.Show("Nama produk lama tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi input nama produk baru
                string namaProdukBaru = tbsubTambahpdk_namaBaru.Text.Trim();
                if (string.IsNullOrEmpty(namaProdukBaru))
                {
                    MessageBox.Show("Nama produk baru tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi stok produk
                if (!int.TryParse(tbSubEditpdk_stok.Text.Trim(), out int stokProduk) || stokProduk < 0)
                {
                    MessageBox.Show("Stok harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi jenis produk
                if (cbsubEditpdk_jenis.SelectedValue == null)
                {
                    MessageBox.Show("Pilih jenis produk terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idJenisProduk = Convert.ToInt32(cbsubEditpdk_jenis.SelectedValue);

                // Validasi tanggal produk
                DateTime tanggalProduk = dtsubEditpdk_tgl.Value;

                // Validasi gambar produk
                string gambarProdukPath = pb_fotoproduk2.ImageLocation;
                if (string.IsNullOrEmpty(gambarProdukPath) || !File.Exists(gambarProdukPath))
                {
                    MessageBox.Show("Pilih gambar produk yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cari produk lama berdasarkan nama
                var produkList = _produkController.CariProduk(namaProdukLama);
                if (produkList == null || produkList.Count == 0)
                {
                    MessageBox.Show("Produk tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (produkList.Count > 1)
                {
                    MessageBox.Show("Terdapat lebih dari satu produk dengan nama yang sama. Harap spesifik!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update produk
                var produk = produkList[0];
                produk.nama_produk = namaProdukBaru;
                produk.id_jenis_produk = idJenisProduk;
                produk.stok_produk = stokProduk;
                produk.tanggal_datang = tanggalProduk;
                produk.gambar_produk = gambarProdukPath;

                _produkController.UbahProduk(produk);

                MessageBox.Show("Data produk berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                V_subEditProduk v_subeditproduk7 = new V_subEditProduk();
                v_subeditproduk7.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            V_AddProduk v_addproduk3 = new V_AddProduk();
            v_addproduk3.Show();
            this.Hide();
        }
    }

}
