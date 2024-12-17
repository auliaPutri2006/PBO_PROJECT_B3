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
using PBO_PROJECT_B3.core;

namespace PBO_PROJECT_B3.view
{
    public partial class FormDasboard : Form
    {
        public FormDasboard()
        {
            InitializeComponent();
            UpdateTransaksiCount();
            UpdateSubTotal();
            UpdateTotalProduk();



        }

        private void FormDasboard_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                V_Login v_login2 = new V_Login();
                v_login2.Show();
                this.Hide();
            }

        }

        private void close2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("apakah anda yakin untuk keluar?", "konfirmasi pesan"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            V_AddAdmin v_AddAdmin = new V_AddAdmin();

            v_AddAdmin.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            V_AddCategory v_addcategory1 = new V_AddCategory();
            v_addcategory1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ucAdminDashboard1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            V_AddProduk v_AddProduk = new V_AddProduk();
            v_AddProduk.Show();
            this.Hide();
        }

        private void btnformdashboard_transaksi_Click(object sender, EventArgs e)
        {
            V_Transaksi v_Transaksi = new V_Transaksi();
            v_Transaksi.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataTable data = C_dashboard.AllTransaksi();

            datagrid_formdashboard.DataSource = null;
            datagrid_formdashboard.DataSource = data;
        }

        private void dtpDashboard_ValueChanged(object sender, EventArgs e)
        {
            // Ambil tanggal yang dipilih dari DateTimePicker
            DateTime selectedDate = dtpDashboard.Value;

            // Ambil data transaksi yang difilter berdasarkan tanggal
            DataTable filteredData = C_dashboard.FilterTransaksiByDate(selectedDate);

            // Set data source untuk DataGridView
            datagrid_formdashboard.DataSource = filteredData;
        }

        private void tbDashboard_transaksi_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateTransaksiCount()
        {
            try
            {
                int totalTransaksi = C_dashboard.CountAllTransaksi();
                tbDashboard_transaksi.Text = totalTransaksi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSubTotal()
        {
            try
            {
                int totalSubTotal = C_dashboard.CalculateTotalSubTotal();
                tbTransaksi_pendapatan.Text = totalSubTotal.ToString("N0"); // Format angka dengan pemisah ribuan
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalProduk()
        {
            int totalJumlahProduk = C_dashboard.CalculateTotalProduk();
            tbDashboard_produk.Text = totalJumlahProduk.ToString("N0");

        }



        private void tbTransaksi_pendapatan_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDashboard_produk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
