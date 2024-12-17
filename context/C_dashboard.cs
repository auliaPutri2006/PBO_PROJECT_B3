using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBO_PROJECT_B3.model;
using PBO_PROJECT_B3.core;
using System.Data;
using Npgsql;

namespace PBO_PROJECT_B3.context
{
    internal class C_dashboard : DBconnection
    {

        public static DataTable AllTransaksi()
        {
            string query = "SELECT dt.id AS id_detail_transaksi, t.id AS id_transaksi, t.tanggal_transaksi, a.username_admin AS nama_admin, p.nama_produk, dt.sub_total, dt.jumlah_produk " +
                           "FROM transaksi t " +
                           "JOIN detail_transaksi dt ON t.id = dt.id_transaksi " +
                           "JOIN produk p ON dt.id_produk = p.id " +
                           "JOIN administrator a ON t.id_admin = a.id";

            DataTable dataTransaksi = DBconnection.queryExecutor(query);
            return dataTransaksi;
        }
        public static DataTable FilterTransaksiByDate(DateTime selectedDate)
        {
            string query = "SELECT dt.id AS id_detail_transaksi, t.id AS id_transaksi, t.tanggal_transaksi, a.username_admin AS nama_admin, p.nama_produk, dt.sub_total, dt.jumlah_produk " +
                           "FROM transaksi t " +
                           "JOIN detail_transaksi dt ON t.id = dt.id_transaksi " +
                           "JOIN produk p ON dt.id_produk = p.id " +
                           "JOIN administrator a ON t.id_admin = a.id " +
                           "WHERE DATE(t.tanggal_transaksi) = @selectedDate " + // Space added here
                           "ORDER BY dt.id ASC";

            var parameters = new[]
            {
        new NpgsqlParameter("@selectedDate", selectedDate.Date)
    };

            DataTable filteredData = DBconnection.queryExecutor(query, parameters);
            return filteredData;
        }

        public static int CountAllTransaksi()
        {
            string query = "SELECT COUNT(id) FROM transaksi";
            object result = DBconnection.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }
        public static int CalculateTotalSubTotal()
        {
            string query = "SELECT SUM(sub_total) FROM detail_transaksi";
            object result = DBconnection.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        public static int CalculateTotalProduk()
        {
            string query = "SELECT SUM(jumlah_produk) FROM detail_transaksi";
            object result = DBconnection.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

    }
}

