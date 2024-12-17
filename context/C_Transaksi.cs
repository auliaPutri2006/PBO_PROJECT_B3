using PBO_PROJECT_B3.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBO_PROJECT_B3.context;
using System.Data;
using PBO_PROJECT_B3.core;
using Npgsql;
using System.Data.Common;

namespace PBO_PROJECT_B3.context
{
    internal class C_Transaksi
    {
        // Dictionary untuk menyimpan data pesanan sementara
        private Dictionary<string, (int jumlahPesanan, int hargaProduk)> _pesananSementara;
        private Dictionary<int, string> _adminTerpilih;


        public C_Transaksi()
        {
            // Inisialisasi dictionary untuk pesanan sementara
            _pesananSementara = new Dictionary<string, (int jumlahPesanan, int hargaProduk)>();
            _adminTerpilih = new Dictionary<int, string>();

        }

        // Metode untuk mendapatkan administrator dari database
        public List<M_Administrator> GetAdministrators()
        {
            string query = "SELECT id, username_admin, pass_admin, status_id FROM administrator WHERE NOT (username_admin = @excludedUsername AND pass_admin = @excludedPassword)";
            var parameters = new[]
            {
        new NpgsqlParameter("@excludedUsername", "adminUtama"),
        new NpgsqlParameter("@excludedPassword", "admin123")
    };

            DataTable result = DBconnection.queryExecutor(query, parameters);

            List<M_Administrator> administrators = new List<M_Administrator>();
            foreach (DataRow row in result.Rows)
            {
                administrators.Add(new M_Administrator
                {
                    id = (int)row["id"],
                    username_admin = row["username_admin"].ToString(),
                    pass_admin = row["pass_admin"].ToString(),
                    status_id = (int)row["status_id"]
                });
            }

            return administrators;
        }

        // Metode untuk menambahkan pesanan ke dictionary
        public void TambahkanPesanan(string namaProduk, int jumlahPesanan, int hargaProduk)
        {
            if (_pesananSementara.ContainsKey(namaProduk))
            {
                var existingData = _pesananSementara[namaProduk];
                _pesananSementara[namaProduk] = (existingData.jumlahPesanan + jumlahPesanan, hargaProduk);
            }
            else
            {
                _pesananSementara[namaProduk] = (jumlahPesanan, hargaProduk);
            }
            
        }


        // Metode untuk mendapatkan semua pesanan sementara
        public Dictionary<string, (int jumlahPesanan, int hargaProduk)> GetPesananSementara()
        {
            // Mengembalikan salinan dictionary untuk mencegah modifikasi langsung
            return new Dictionary<string, (int jumlahPesanan, int hargaProduk)>(_pesananSementara);
        }

        public void SetAdminTerpilih(int id, string username)
        {
            _adminTerpilih.Clear(); // Clear existing admin data to ensure only one admin is selected
            _adminTerpilih[id] = username;
        }

        // Metode untuk mendapatkan admin terpilih
        public Dictionary<int, string> GetAdminTerpilih()
        {
            return new Dictionary<int, string>(_adminTerpilih);
        }

        public int GetProdukIdByName(string namaProduk)
        {
            string query = "SELECT id FROM produk WHERE nama_produk = @nama_produk";
            NpgsqlParameter[] parameters = {
        new NpgsqlParameter("@nama_produk", namaProduk)
        };

            object result = DBconnection.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int SimpanTransaksi(int idAdmin, Dictionary<string, (int jumlahPesanan, int hargaProduk)> pesananSementara, Func<string, int> getIdProdukByName)
        {
            int idTransaksiBaru;

            try
            {
                // Query untuk menyimpan transaksi
                string queryTransaksi = "INSERT INTO transaksi (tanggal_transaksi, id_admin) VALUES (@tanggal_transaksi, @id_admin) RETURNING id";
                var parametersTransaksi = new[]
                {
            new NpgsqlParameter("@tanggal_transaksi", DateTime.Now),
            new NpgsqlParameter("@id_admin", idAdmin)
        };

                // Simpan transaksi dan dapatkan ID transaksi baru
                idTransaksiBaru = Convert.ToInt32(DBconnection.ExecuteScalar(queryTransaksi, parametersTransaksi));

                // Simpan detail transaksi dan update stok produk
                foreach (var pesanan in pesananSementara)
                {
                    string namaProduk = pesanan.Key;
                    var detailPesanan = pesanan.Value;

                    // Dapatkan ID produk berdasarkan nama
                    int idProduk = getIdProdukByName(namaProduk);
                    if (idProduk == 0)
                        throw new Exception($"Produk '{namaProduk}' tidak ditemukan.");

                    // Query untuk menyimpan detail transaksi
                    string queryDetail = "INSERT INTO detail_transaksi (id_transaksi, id_produk, jumlah_produk, sub_total) " +
                                         "VALUES (@id_transaksi, @id_produk, @jumlah_produk, @sub_total)";
                    var parametersDetail = new[]
                    {
                new NpgsqlParameter("@id_transaksi", idTransaksiBaru),
                new NpgsqlParameter("@id_produk", idProduk),
                new NpgsqlParameter("@jumlah_produk", detailPesanan.jumlahPesanan),
                new NpgsqlParameter("@sub_total", detailPesanan.jumlahPesanan * detailPesanan.hargaProduk)
            };

                    DBconnection.commandExecutor(queryDetail, parametersDetail);

                    // Query untuk mengurangi stok produk
                    string queryUpdateStok = "UPDATE produk SET stok_produk = stok_produk - @jumlah_dibeli WHERE id = @id_produk";
                    var parametersUpdateStok = new[]
                    {
                new NpgsqlParameter("@jumlah_dibeli", detailPesanan.jumlahPesanan),
                new NpgsqlParameter("@id_produk", idProduk)
            };

                    DBconnection.commandExecutor(queryUpdateStok, parametersUpdateStok);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menyimpan transaksi: {ex.Message}", ex);
            }

            return idTransaksiBaru;
        }




    }
}
