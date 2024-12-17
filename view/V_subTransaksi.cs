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

namespace PBO_PROJECT_B3.view
{
    public partial class V_subTransaksi : Form
    {
        private readonly C_Transaksi _controller;

        internal V_subTransaksi(C_Transaksi controller)
        {
            InitializeComponent();
            _controller = controller;
            loadtransaksitoflow();
            UpdateAdminTextBox();

            //LoadPesanan(); // Uncomment jika ingin memuat data pesanan di constructor
        }
        private void UpdateAdminTextBox()
        {
            var adminTerpilih = _controller.GetAdminTerpilih();

            tbsubTransaksi_admin.Text = adminTerpilih.Count > 0
                ? adminTerpilih.FirstOrDefault().Value
                : "";
        }

        public void loadtransaksitoflow()
        {

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;
            foreach (var pesanan in _controller.GetPesananSementara())
            {
                string namaProduk = pesanan.Key;
                int jumlahPesanan = pesanan.Value.jumlahPesanan;
                int hargaProduk = pesanan.Value.hargaProduk;
                int subTotal = jumlahPesanan * hargaProduk;

                // Buat panel untuk setiap pesanan
                Panel panel4 = new Panel
                {
                    BackColor = Color.DarkOliveGreen,
                    Location = new Point(3, 3),
                    Size = new Size(763, 148),
                    TabIndex = 0
                };
                Label lbsubTransaksi_qty = new Label
                {
                    AutoSize = true,
                    Font = new Font("Footlight MT Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    ForeColor = SystemColors.ButtonHighlight,
                    Location = new Point(39, 60),
                    Name = "lbsubTransaksi_qty",
                    Size = new Size(31, 19),
                    Text = "Qty"
                };

                Label lbSubTransaksi_nama = new Label
                {
                    AutoSize = true,
                    Font = new Font("Footlight MT Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    ForeColor = SystemColors.ButtonHighlight,
                    Location = new Point(252, 62),
                    Name = "lbSubTransaksi_nama",
                    Size = new Size(110, 19),
                    Text = "Nama Produk"
                };
                Label lbsubTransaksi_sub = new Label
                {
                    AutoSize = true,
                    Font = new Font("Footlight MT Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    ForeColor = SystemColors.ButtonHighlight,
                    Location = new Point(570, 62),
                    Name = "lbsubTransaksi_sub",
                    Size = new Size(73, 19),
                    Text = "Sub Total"
                };

                TextBox tbsubTransaksi_nama = new TextBox
                {
                    Location = new Point(169, 84),
                    Size = new Size(277, 27),
                    Font = new Font("Footlight MT Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Text = namaProduk
                };

                TextBox tbsubTransaksi_qty = new TextBox
                {
                    Location = new Point(21, 84),
                    Font = new Font("Footlight MT Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Text = jumlahPesanan.ToString()
                };

                TextBox tbsubTransaksi_total = new TextBox
                {
                    Location = new Point(516, 84),
                    Size = new Size(203, 27),
                    Font = new Font("Footlight MT Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Text = subTotal.ToString()
                };

                // Tambahkan kontrol ke panel
                panel4.Controls.Add(lbsubTransaksi_qty);
                panel4.Controls.Add(lbSubTransaksi_nama);
                panel4.Controls.Add(lbsubTransaksi_sub);
                panel4.Controls.Add(tbsubTransaksi_qty);
                panel4.Controls.Add(tbsubTransaksi_nama);
                panel4.Controls.Add(tbsubTransaksi_total);

                // Tambahkan panel ke FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel4);


            }
            //flowLayoutPanel1.Controls.Add(panel4);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsubTransaksi_back_Click(object sender, EventArgs e)
        {
            V_Transaksi v_transaksi5 = new V_Transaksi();
            v_transaksi5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil data admin terpilih
                var adminTerpilih = _controller.GetAdminTerpilih();
                if (adminTerpilih.Count == 0)
                {
                    MessageBox.Show("Pilih admin terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ambil ID admin pertama
                int idAdmin = adminTerpilih.FirstOrDefault().Key;

                // Ambil data pesanan sementara
                var pesananSementara = _controller.GetPesananSementara();
                if (pesananSementara.Count == 0)
                {
                    MessageBox.Show("Tidak ada pesanan untuk disimpan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Panggil metode SimpanTransaksi di controller
                int idTransaksiBaru = _controller.SimpanTransaksi(idAdmin, pesananSementara, _controller.GetProdukIdByName);

                // Tampilkan pesan sukses
                MessageBox.Show($"Transaksi berhasil disimpan dengan ID: {idTransaksiBaru}", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset data form jika diperlukan
                flowLayoutPanel1.Controls.Clear();
                tbsubTransaksi_admin.Text = string.Empty;
            }
            catch (Exception ex)
            {
                // Tampilkan pesan error jika terjadi kesalahan
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            V_Transaksi v_transaksiback = new V_Transaksi();
            v_transaksiback.Show();
            this.Hide();

        }

        private void tbsubTransaksi_admin_TextChanged(object sender, EventArgs e)
        {

            UpdateAdminTextBox();


        }

        private void button3_Click(object sender, EventArgs e)
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
