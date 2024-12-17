using PBO_PROJECT_B3.context;
using PBO_PROJECT_B3.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PBO_PROJECT_B3.context.C_produk;




namespace PBO_PROJECT_B3.view
{
    public partial class V_Transaksi : Form
    {
        private ProdukController _produkController;
        private readonly C_Transaksi _controller;

        public V_Transaksi()
        {
            InitializeComponent();
            _produkController = new ProdukController();
            _controller = new C_Transaksi();

            // Load produk dan data administrator
            LoadProdukToFlowPanel();
            LoadComboBoxData();


        }

        private void LoadProdukToFlowPanel()
        {
            flowLayoutPanel3.Controls.Clear();

            flowLayoutPanel3.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel3.WrapContents = true;
            flowLayoutPanel3.AutoScroll = true;

            try
            {
                var produkList = _produkController.LoadProduk();

                foreach (var produk in produkList)
                {
                    int stokProduk = produk.ContainsKey("stok_produk") ? Convert.ToInt32(produk["stok_produk"]) : 0;
                    Panel produkPanel = new Panel
                    {
                        Size = new Size(350, 350),
                        BackColor = Color.DarkOliveGreen,
                        Margin = new Padding(10),
                        Tag = stokProduk // Simpan stok di properti Tag
                    };

                    // Gambar produk
                    PictureBox pbGambar = new PictureBox
                    {
                        Size = new Size(155, 148),
                        Location = new Point(98, 11),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = produk.ContainsKey("gambar_produk") ? produk["gambar_produk"] as Image : null
                    };
                    produkPanel.Controls.Add(pbGambar);

                    // Nama produk
                    produkPanel.Controls.Add(new Label
                    {
                        Text = "Nama Produk",
                        Location = new Point(12, 183),
                        AutoSize = true,
                        Font = new Font("Arial Rounded MT", 10, FontStyle.Bold),
                        ForeColor = Color.White,
                    });
                    produkPanel.Controls.Add(new TextBox
                    {
                        Text = produk.ContainsKey("nama_produk") ? produk["nama_produk"].ToString() : "Nama Tidak Ada",
                        Size = new Size(151, 27),
                        Location = new Point(12, 206),
                    });

                    // Harga produk
                    produkPanel.Controls.Add(new Label
                    {
                        Text = "Harga Produk",
                        Location = new Point(184, 183),
                        AutoSize = true,
                        Font = new Font("Arial Rounded MT", 10, FontStyle.Bold),
                        ForeColor = Color.White,
                    });
                    produkPanel.Controls.Add(new TextBox
                    {
                        Text = produk.ContainsKey("harga_produk")
                            ? $"Rp {Convert.ToDecimal(produk["harga_produk"]):N0}"
                            : "Harga Tidak Ada",
                        Size = new Size(151, 27),
                        Location = new Point(184, 206),
                    });

                    // Jumlah pesanan
                    TextBox tbTransaksi_pesanan = new TextBox
                    {
                        Location = new Point(104, 271),
                        Size = new Size(139, 27),
                        Text = "0",
                        Enabled = stokProduk > 0 // Disabled jika stok habis

                    };
                    tbTransaksi_pesanan.KeyPress += TbTransaksi_pesanan_KeyPress;
                    produkPanel.Controls.Add(new Label
                    {
                        Text = "Pesanan",
                        Location = new Point(135, 245),
                        Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Bold),
                        ForeColor = Color.White
                    });
                    produkPanel.Controls.Add(tbTransaksi_pesanan);

                    // Label untuk stok
                    produkPanel.Controls.Add(new Label
                    {
                        Text = $"Stok: {stokProduk}",
                        Location = new Point(12, 240),
                        AutoSize = true,
                        Font = new Font("Arial Rounded MT Bold", 9F),
                        ForeColor = stokProduk > 0 ? Color.White : Color.Red
                    });

                    

                    // Tombol tambah
                    Button btnTambah = new Button
                    {
                        Text = "+",
                        Font = new Font("Arial Rounded MT Bold", 12F),
                        Location = new Point(249, 271),
                        Size = new Size(48, 27),
                    };

                    // Tambahkan event handler untuk tombol tambah
                    btnTambah.Click += (s, e) =>
                    {
                        if (int.TryParse(tbTransaksi_pesanan.Text, out int current))
                        {
                            tbTransaksi_pesanan.Text = (current + 1).ToString();
                        }
                    };

                    // Tambahkan tombol tambah ke panel produk
                    produkPanel.Controls.Add(btnTambah);

                    // Tombol kurang
                    Button btnKurang = new Button
                    {
                        Text = "-",
                        Font = new Font("Arial Rounded MT Bold", 12F),
                        Location = new Point(50, 271),
                        Size = new Size(48, 27),
                    };

                    // Tambahkan event handler untuk tombol kurang
                    btnKurang.Click += (s, e) =>
                    {
                        if (int.TryParse(tbTransaksi_pesanan.Text, out int current) && current > 0)
                        {
                            tbTransaksi_pesanan.Text = (current - 1).ToString();
                        }
                    };

                    // Tambahkan tombol kurang ke panel produk
                    produkPanel.Controls.Add(btnKurang);

                    flowLayoutPanel3.Controls.Add(produkPanel);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                List<M_Administrator> administrators = _controller.GetAdministrators();

                cbTansaksi_admin.DataSource = administrators;
                cbTansaksi_admin.DisplayMember = "username_admin";
                cbTansaksi_admin.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading administrators: {ex.Message}");
            }
        }

        private void cbTansaksi_admin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTansaksi_admin.SelectedItem is M_Administrator selectedAdmin)
            {
                // Simpan admin yang dipilih ke controller
                _controller.SetAdminTerpilih(selectedAdmin.id, selectedAdmin.username_admin);
            }
        }

        private void TbTransaksi_pesanan_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (sender is TextBox tbTransaksi && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnPerbaruicategory_Click(object sender, EventArgs e)
        {
            var adminTerpilih = _controller.GetAdminTerpilih();
            if (adminTerpilih.Count == 0)
            {
                MessageBox.Show("Pilih admin terlebih dahulu!");
                return;
            }

            foreach (Control panel in flowLayoutPanel3.Controls)
            {
                if (panel is Panel produkPanel)
                {
                    int stokProduk = Convert.ToInt32(produkPanel.Tag);
                    string namaProduk = string.Empty;
                    int jumlahPesanan = 0;
                    int hargaProduk = 0;
                    
                    

                    // Loop through the controls in the product panel
                    foreach (Control control in produkPanel.Controls)
                    {
                        switch (control)
                        {
                            case TextBox textBox when textBox.Location == new Point(12, 206):
                                // Ambil nama produk
                                namaProduk = textBox.Text;
                                break;

                            case TextBox tbPesanan when tbPesanan.Location == new Point(104, 271):
                                // Ambil jumlah pesanan
                                int.TryParse(tbPesanan.Text, out jumlahPesanan);
                                break;

                            case TextBox tbHarga when tbHarga.Location == new Point(184, 206):
                                // Ambil harga produk
                                string hargaText = tbHarga.Text.Replace("Rp", "").Replace(".", "").Trim();
                                int.TryParse(hargaText, out hargaProduk);
                                break;

                            

                        }
                    }

                    if (jumlahPesanan > stokProduk)
                    {
                        
                        MessageBox.Show($"Stok produk '{namaProduk}' tidak mencukupi. Sisa stok: {stokProduk}",
                                        "Stok Tidak Cukup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        V_Transaksi v_transi9 = new V_Transaksi();
                        v_transi9.Show();
                        this.Hide();

                        
                        
                    }
                    else if (jumlahPesanan > 0)
                    {
                        _controller.TambahkanPesanan(namaProduk, jumlahPesanan, hargaProduk);
                        V_subTransaksi v_SubTransaksi2 = new V_subTransaksi(_controller);
                        v_SubTransaksi2.Show();
                        this.Hide();
                    }

                }
            }

            //// Open V_subTransaksi form
            //V_subTransaksi v_SubTransaksi = new V_subTransaksi(_controller);
            //v_SubTransaksi.Show();
            //this.Hide();


        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnaddcategory_dashboard_Click(object sender, EventArgs e)
        {
            FormDasboard formDasboard3 = new FormDasboard();
            formDasboard3.Show();
            this.Hide();
        }

        private void btnaddcategory_addproduct_Click(object sender, EventArgs e)
        {
            V_AddProduk v_addproduk8 = new V_AddProduk();
            v_addproduk8.Show();
            this.Hide();
        }

        private void btnAddcategory_add_Click(object sender, EventArgs e)
        {
            V_AddCategory v_addcategory7 = new V_AddCategory();
            v_addcategory7.Show();
            this.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();


            }
        }
    }
}
