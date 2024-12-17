using PBO_PROJECT_B3.context;
using PBO_PROJECT_B3.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PBO_PROJECT_B3.context.C_produk;
//using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace PBO_PROJECT_B3.view
{
    public partial class subTambah_produk : Form
    {
        private ProdukController _produkController = new ProdukController();
        private string destinationPath = "";
        public subTambah_produk()
        {
            InitializeComponent();

            LoadJenisProduk();
        }
        private void LoadJenisProduk()
        {
            try
            {
                var jenisProdukList = new List<dynamic>();

                DataTable dtJenisProduk = C_JenisProduk.comboBox();
                foreach (DataRow row in dtJenisProduk.Rows)
                {
                    jenisProdukList.Add(new
                    {
                        Key = row["id"],
                        Value = row["nama_jenis_produk"].ToString()
                    });
                }


                cbsubTambahpdk_jenis.DataSource = jenisProdukList;
                cbsubTambahpdk_jenis.DisplayMember = "Value";
                cbsubTambahpdk_jenis.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat jenis produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input
                if (!int.TryParse(tbsubTambahpdk_stok.Text, out int stok) || stok < 0)
                {
                    MessageBox.Show("Stok harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(tbsubTambahpdk_harga.Text, out int harga) || harga < 0)
                {
                    MessageBox.Show("Harga harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idJenisProduk = Convert.ToInt32(cbsubTambahpdk_jenis.SelectedValue);

                if (cbsubTambahpdk_jenis.SelectedValue == null)
                {
                    MessageBox.Show("Pilih jenis produk terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(destinationPath))
                {
                    MessageBox.Show("Pilih gambar produk terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idjenisProduk = (int)cbsubTambahpdk_jenis.SelectedValue;
                // Membuat objek produk
                var produkBaru = new M_Produk
                {
                    nama_produk = tbsubTambahpdk_nama.Text,
                    harga_produk = harga,
                    stok_produk = stok,
                    id_jenis_produk = idJenisProduk,
                    tanggal_datang = dtsubTambahpdk_tgl.Value,
                    gambar_produk = destinationPath
                };
                _produkController.TambahProduk(produkBaru);



                // Panggil fungsi untuk menyimpan produk di database
                MessageBox.Show("Produk berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form setelah berhasil menyimpan
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            tbsubTambahpdk_nama.Clear();
            tbsubTambahpdk_harga.Clear();
            tbsubTambahpdk_stok.Clear();
            cbsubTambahpdk_jenis.SelectedIndex = 0;
            dtsubTambahpdk_tgl.Value = DateTime.Now;
            pb_fotoproduk.Image = null;
            destinationPath = ""; // Reset path gambar
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            V_AddProduk v_AddProduk7 = new V_AddProduk();
            v_AddProduk7.Show();
            this.Hide();
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(f.FileName))
                    {
                        string sourcePath = f.FileName;
                        string fileName = Path.GetFileName(sourcePath);
                        string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gambar_produk");

                        // Buat folder jika belum ada
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }

                        string destinationPath = Path.Combine(destinationFolder, fileName);

                        // Salin file ke folder tujuan
                        File.Copy(sourcePath, destinationPath, overwrite: true);

                        // Set path gambar produk ke absolute path
                        this.destinationPath = destinationPath;

                        // Tampilkan gambar di PictureBox
                        pb_fotoproduk.Image = System.Drawing.Image.FromFile(destinationPath);

                        // Simpan absolute path ke dalam database
                        var produkBaru = new M_Produk
                        {
                            gambar_produk = destinationPath // Menyimpan absolute path ke database
                        };

                        // Panggil fungsi untuk menyimpan produk (controller atau langsung query)
                        _produkController.UpdateGambarProduk(produkBaru);
                    }
                    else
                    {
                        MessageBox.Show("File gambar tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }








        private void btn_tambahpic_Click(object sender, EventArgs e)
        {

        }

        private void pb_fotoproduk_Click(object sender, EventArgs e)
        {

        }
    }
}
