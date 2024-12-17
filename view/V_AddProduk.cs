using PBO_PROJECT_B3.context;
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
using System.Windows.Forms.Design;
using static PBO_PROJECT_B3.context.C_produk;

namespace PBO_PROJECT_B3.view
{
    public partial class V_AddProduk : Form
    {
        private ProdukController _produkController;
        public V_AddProduk()
        {
            InitializeComponent();
            _produkController = new ProdukController(); // Inisialisasi controller
            LoadProduk(); // Panggil fungsi untuk memuat data
        }

        private void LoadProduk()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight; // Alur dari kiri ke kanan
                flowLayoutPanel1.WrapContents = true; // Pindah ke baris berikutnya jika penuh
                flowLayoutPanel1.AutoScroll = true; // Tambahkan scroll jika konten melebihi ukuran panel

                //flowLayoutPanel1.Controls.Clear(); // Kosongkan panel sebelum mengisi

                //var produkList = _produkController.LoadProduk(); // Panggil dari Controller
                var produkList = _produkController.LoadProduk();

                foreach (var produk in produkList)
                {

                    Panel panelProduk = new Panel
                    {
                        Size = new Size(330, 250),
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10),
                        BackColor = Color.DarkOliveGreen
                    };

                    if (produk.ContainsKey("gambar_produk"))
                    {
                        var gambarProduk = produk["gambar_produk"];

                        if (gambarProduk != null)
                        {
                            // Buat PictureBox dan atur propertinya
                            PictureBox pictureBox = new PictureBox
                            {
                                Size = new Size(100, 100),
                                Location = new Point(10, 10),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Image = (Image)gambarProduk // Langsung gunakan objek Image
                            };

                            // Menambahkan PictureBox ke panel
                            panelProduk.Controls.Add(pictureBox);
                        }
                        else
                        {
                            MessageBox.Show("Gambar tidak ditemukan.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data gambar tidak tersedia.");
                    }



                    int xLabel = 120; // Posisi horizontal untuk label di kiri
                    int xLabelRight = 200; // Posisi horizontal untuk elemen di kanan (jarak lebih dekat)
                    int yPosition = 30; // Posisi vertikal awal

                    // Nama Produk
                    Label lblNama = new Label
                    {
                        Text = "Nama Produk",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Location = new Point(xLabel, yPosition),
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    panelProduk.Controls.Add(lblNama);

                    TextBox txtNama = new TextBox
                    {
                        Text = produk.GetValueOrDefault("nama_produk", "Tidak Ada Data").ToString(),
                        Size = new Size(110, 25),
                        Location = new Point(xLabel, yPosition + 20)
                    };
                    panelProduk.Controls.Add(txtNama);

                    yPosition += 50;

                    // Kategori
                    Label lblKategori = new Label
                    {
                        Text = "Kategori",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Location = new Point(xLabel, yPosition),
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    panelProduk.Controls.Add(lblKategori);

                    TextBox txtKategori = new TextBox
                    {
                        Text = produk.GetValueOrDefault("nama_jenis_produk", "Tidak Ada Data").ToString(),
                        Size = new Size(110, 25),
                        Location = new Point(xLabel, yPosition + 20)
                    };
                    panelProduk.Controls.Add(txtKategori);

                    yPosition += 50;

                    // Tanggal Datang
                    Label lblTanggal = new Label
                    {
                        Text = "Tanggal Datang",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Location = new Point(10, yPosition),
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    panelProduk.Controls.Add(lblTanggal);

                    TextBox txtTanggal = new TextBox
                    {
                        Text = produk.ContainsKey("tanggal_datang") ? Convert.ToDateTime(produk["tanggal_datang"]).ToString("dd/MM/yyyy") : "Tidak Ada Data",
                        Size = new Size(110, 25),
                        Location = new Point(10, yPosition + 20)
                    };
                    panelProduk.Controls.Add(txtTanggal);

                    // Stok (di samping Tanggal Datang)
                    Label lblStok = new Label
                    {
                        Text = "Stok",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Location = new Point(xLabelRight, yPosition),
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    panelProduk.Controls.Add(lblStok);

                    TextBox txtStok = new TextBox
                    {
                        Text = produk.GetValueOrDefault("stok_produk", "Tidak Ada Data").ToString(),
                        Size = new Size(110, 25),
                        Location = new Point(xLabelRight, yPosition + 20)
                    };
                    panelProduk.Controls.Add(txtStok);

                    yPosition += 50;

                    // Harga
                    Label lblHarga = new Label
                    {
                        Text = "Harga",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Location = new Point(10, yPosition),
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    panelProduk.Controls.Add(lblHarga);

                    TextBox txtHarga = new TextBox
                    {
                        Text = produk.GetValueOrDefault("harga_produk", "Tidak Ada Data").ToString(),
                        Size = new Size(110, 25),
                        Location = new Point(10, yPosition + 20)
                    };
                    panelProduk.Controls.Add(txtHarga);

                    // Batas Opname (di samping Harga)
                    Label lblOpname = new Label
                    {
                        Text = "Batas Opname",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Location = new Point(xLabelRight, yPosition),
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    panelProduk.Controls.Add(lblOpname);




                    DateTime tanggalDatang;
                    string tanggalDatangStr = produk.GetValueOrDefault("tanggal_datang", "").ToString();
                    bool isTanggalValid = DateTime.TryParse(tanggalDatangStr, out tanggalDatang); // Validasi tanggal


                    TextBox txtOpname = new TextBox
                    {
                        Text = produk.GetValueOrDefault("batas_opname", "Tidak Ada Data").ToString(),
                        Size = new Size(110, 25),
                        Location = new Point(xLabelRight, yPosition + 20),
                        ReadOnly = true

                    };


                    if (isTanggalValid)
                    {
                        // Hitung selisih hari antara tanggal sekarang dan tanggal datang
                        TimeSpan selisihHari = DateTime.Now - tanggalDatang;

                        // Jika lebih dari 3 hari, tampilkan teks merah
                        if (selisihHari.Days > 3)
                        {
                            txtOpname.Text = "Melebihi 3 Hari";
                            txtOpname.ForeColor = Color.Red; // Ubah warna teks menjadi merah
                            txtOpname.BackColor = Color.White; // Pastikan background tetap putih
                        }
                        else
                        {
                            txtOpname.Text = $"{3 - selisihHari.Days} Hari Lagi";
                            txtOpname.ForeColor = Color.Green; // Teks hijau untuk kondisi aman
                        }
                    }
                    else
                    {
                        // Jika tanggal tidak valid, tampilkan pesan default
                        txtOpname.Text = "Tanggal Tidak Valid";
                        txtOpname.ForeColor = Color.Gray;
                    }

                    panelProduk.Controls.Add(txtOpname);

                    // Tambahkan panel produk ke FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(panelProduk);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            subTambah_produk subTambah_Produk = new subTambah_produk();
            subTambah_Produk.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            V_subEditProduk subV_editproduk = new V_subEditProduk();
            subV_editproduk.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                V_Login v_login3 = new V_Login();
                v_login3.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDasboard formDasboard2 = new FormDasboard();
            formDasboard2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            V_AddCategory v_AddCategory3 = new V_AddCategory();
            v_AddCategory3.Show();
            this.Hide();
        }

        private void btnformdashboard_transaksi_Click(object sender, EventArgs e)
        {
            V_Transaksi v_transaksi4 = new V_Transaksi();
            v_transaksi4.Show();
            this.Hide();
        }
    }
}
