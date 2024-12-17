using Npgsql;
using PBO_PROJECT_B3.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBO_PROJECT_B3.core;

namespace PBO_PROJECT_B3.context
{
    internal class C_produk
    {

        public class ProdukController
        {
            // Fungsi untuk menambah produk
            public void TambahProduk(M_Produk produk)
            {
                try
                {
                    string query = "INSERT INTO produk (nama_produk, harga_produk, stok_produk, id_jenis_produk, tanggal_datang, gambar_produk) " +
                                   "VALUES (@nama_produk, @harga_produk, @stok_produk, @id_jenis_produk, @tanggal_datang, @gambar_produk)";

                    var parameters = new NpgsqlParameter[]
                    {
            new NpgsqlParameter("@nama_produk", produk.nama_produk),
            new NpgsqlParameter("@harga_produk", produk.harga_produk),
            new NpgsqlParameter("@stok_produk", produk.stok_produk),
            new NpgsqlParameter("@id_jenis_produk", produk.id_jenis_produk),
            new NpgsqlParameter("@tanggal_datang", produk.tanggal_datang),
            new NpgsqlParameter("@gambar_produk", produk.gambar_produk) // Simpan path gambar
                    };

                    DBconnection.queryExecutor(query, parameters);
                }
                catch (Exception e)
                {
                    throw new Exception($"Error saat menambahkan produk: {e.Message}");
                }
            }

            public List<Dictionary<string, object>> LoadProduk()
            {
                try
                {
                    // Query untuk mengambil data produk
                    string query = "SELECT produk.nama_produk, produk.harga_produk, produk.stok_produk, jenis_produk.nama_jenis_produk, " +
                                   "produk.tanggal_datang, produk.gambar_produk " +
                                   "FROM produk " +
                                   "JOIN jenis_produk ON produk.id_jenis_produk = jenis_produk.id";

                    // Eksekusi query
                    DataTable produkList = DBconnection.queryExecutor(query);

                    // Proses hasil query ke dalam list dictionary
                    var produkData = new List<Dictionary<string, object>>();
                    foreach (DataRow row in produkList.Rows)
                    {
                        var data = new Dictionary<string, object>
            {
                { "nama_produk", row["nama_produk"].ToString() },
                { "nama_jenis_produk", row["nama_jenis_produk"].ToString() },
                { "stok_produk", Convert.ToInt32(row["stok_produk"]) },
                { "tanggal_datang", Convert.ToDateTime(row["tanggal_datang"]) },
                { "harga_produk", Convert.ToDecimal(row["harga_produk"]) }
            };

                        // Proses gambar_produk (pastikan path gambar absolut)
                        string gambarPath = row["gambar_produk"].ToString(); // Ambil path gambar yang sudah absolut
                        if (File.Exists(gambarPath))
                        {
                            data["gambar_produk"] = Image.FromFile(gambarPath); // Menyimpan gambar sebagai objek Image
                        }
                        else
                        {
                            data["gambar_produk"] = null; // Atau gunakan gambar default jika gambar tidak ditemukan
                        }

                        // Tambahkan data ke list
                        produkData.Add(data);
                    }

                    return produkData; // Kembalikan data produk
                }
                catch (Exception ex)
                {
                    throw new Exception($"Gagal memuat produk: {ex.Message}");
                }
            }



            // Ubah Produk
            public void UbahProduk(M_Produk produk)
            {
                try
                {
                    // Validasi input
                    if (produk == null)
                    {
                        throw new ArgumentNullException(nameof(produk), "Produk tidak boleh null.");
                    }

                    if (produk.id <= 0)
                    {
                        throw new ArgumentException("ID produk tidak valid.", nameof(produk.id));
                    }

                    string query = "UPDATE produk SET nama_produk = @nama_produk, harga_produk = @harga_produk, stok_produk = @stok_produk, " +
                                   "id_jenis_produk = @id_jenis_produk, tanggal_datang = @tanggal_datang, gambar_produk = @gambar_produk " +
                                   "WHERE id = @id";

                    var parameters = new NpgsqlParameter[]
                    {
            new NpgsqlParameter("@id", produk.id),
            new NpgsqlParameter("@nama_produk", produk.nama_produk),
            new NpgsqlParameter("@harga_produk", produk.harga_produk),
            new NpgsqlParameter("@stok_produk", produk.stok_produk),
            new NpgsqlParameter("@id_jenis_produk", produk.id_jenis_produk),
            new NpgsqlParameter("@tanggal_datang", produk.tanggal_datang),
            new NpgsqlParameter("@gambar_produk", produk.gambar_produk) 
                    };

                    DBconnection.queryExecutor(query, parameters);
                }
                catch (ArgumentNullException ex)
                {
                    throw new Exception($"Input tidak valid: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    throw new Exception($"Kesalahan pada parameter: {ex.Message}");
                }
                catch (Exception e)
                {
                    throw new Exception($"Error saat mengubah produk: {e.Message}");
                }
            }


            // Hapus Produk
            public void HapusProduk(int id)
            {
                try
                {
                    string query = "DELETE FROM produk WHERE id = @id";
                    var parameters = new NpgsqlParameter[]
                    {
                    new NpgsqlParameter("@id", id)
                    };

                    DBconnection.queryExecutor(query, parameters);
                }
                catch (Exception e)
                {
                    throw new Exception($"Error saat menghapus produk: {e.Message}");
                }
            }

            // Cari Produk berdasarkan ID
            

            // Method untuk memperbarui gambar produk
            public void UpdateGambarProduk(M_Produk produk)
            {
                try
                {
                    // Query untuk memperbarui gambar_produk berdasarkan id
                    string query = "UPDATE produk SET gambar_produk = @gambar_produk WHERE id = @id";

                    // Parameter untuk query
                    var parameters = new NpgsqlParameter[]
                    {
            new NpgsqlParameter("@id", produk.id), // ID produk
            new NpgsqlParameter("@gambar_produk", produk.gambar_produk) // Path gambar produk
                    };

                    // Eksekusi query
                    DBconnection.queryExecutor(query, parameters);

                    // Jika berhasil
                    Console.WriteLine($"Gambar produk dengan ID {produk.id} berhasil diperbarui.");
                }
                catch (Exception e)
                {
                    // Jika terjadi error
                    throw new Exception($"Error saat memperbarui gambar produk: {e.Message}");
                }
            }

            public List<M_Produk> CariProduk(string nama_produk)
            {
                try
                {
                    string query = "SELECT * FROM produk WHERE nama_produk ILIKE @nama_produk";
                    var parameters = new NpgsqlParameter[]
                    {
            new NpgsqlParameter("@nama_produk", $"%{nama_produk}%")
                    };

                    // Eksekusi query dan dapatkan hasil
                    DataTable dataTable = DBconnection.queryExecutor(query, parameters);
                    List<M_Produk> produkList = new();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        produkList.Add(new M_Produk
                        {
                            id = Convert.ToInt32(row["id"]),
                            nama_produk = row["nama_produk"].ToString(),
                            harga_produk = Convert.ToInt32(row["harga_produk"]),
                            stok_produk = Convert.ToInt32(row["stok_produk"]),
                            id_jenis_produk = Convert.ToInt32(row["id_jenis_produk"]),
                            tanggal_datang = Convert.ToDateTime(row["tanggal_datang"]),
                            gambar_produk = row["gambar_produk"].ToString()
                        });
                    }

                    return produkList;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Terjadi kesalahan saat mencari produk: {ex.Message}");
                }
            }



            // Cari Produk berdasarkan Nama
            public void CariDanUbahProduk(string nama_produk, M_Produk produkBaru)
            {
                try
                {
                    // Cari produk berdasarkan nama
                    var produkList = CariProduk(nama_produk);

                    if (produkList.Count == 0)
                    {
                        MessageBox.Show("Produk dengan nama tersebut tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (produkList.Count > 1)
                    {
                        MessageBox.Show("Terdapat lebih dari satu produk dengan nama yang sama. Harap spesifik!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Produk ditemukan
                    M_Produk produkLama = produkList[0];

                    // Konfirmasi untuk memastikan pengguna ingin mengubah data
                    var confirmResult = MessageBox.Show(
                        $"Apakah Anda yakin ingin mengubah data produk '{produkLama.nama_produk}'?",
                        "Konfirmasi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Salin ID produk lama ke produk baru untuk memastikan perubahan dilakukan pada produk yang benar
                        produkBaru.id = produkLama.id;

                        // Panggil fungsi untuk mengubah data produk
                        UbahProduk(produkBaru);

                        MessageBox.Show("Data produk berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}


