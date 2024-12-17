using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBO_PROJECT_B3.model;
using PBO_PROJECT_B3.core;
using PBO_PROJECT_B3.view;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace PBO_PROJECT_B3.context
{
    internal class C_JenisProduk : DBconnection
    {
        public static string table = "jenis_produk";
        public static DataTable all()
        {
            string query = $"SELECT * FROM {table} ORDER BY id ASC";
            DataTable dataJenis = queryExecutor(query);
            return dataJenis;
        }

        public static DataTable comboBox()
        {
            string query = $"SELECT id,nama_jenis_produk from {table}";
            DataTable dataJenis = queryExecutor(query);
            return dataJenis;
        }

        public static DataTable comboBoxProduk(string nama_jenis_produk)
        {
            string query = $"SELECT p.nama_produk, p.harga_produk, p.stok_produk, jp.nama_jenis_produk " +
                           $"FROM produk p JOIN jenis_produk jp " +
                           $"ON p.id_jenis_produk = jp.id " +
                           $"WHERE jp.nama_jenis_produk = @nama_jenis_produk AND p.stok_produk > 0";
            NpgsqlParameter[] parameters =
            {
        new NpgsqlParameter("@nama_jenis_produk", NpgsqlDbType.Varchar) { Value = nama_jenis_produk }
    };
            return queryExecutor(query, parameters);
        }

        public static DataTable jenis_produk(string nama_jenis_produk)
        {
            string query = $"SELECT * FROM {table} WHERE nama_jenis_produk = @nama_jenis_produk";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_jenis_produk", NpgsqlDbType.Varchar) { Value = nama_jenis_produk },
            };
            DataTable dataProduk = queryExecutor(query, parameters);
            return dataProduk;
        }
        public static void create(M_Jenis_produk jenis_Baru)
        {
            string query = $"INSERT INTO {table} (nama_jenis_produk) values (@nama_jenis_produk)";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@nama_jenis_produk", NpgsqlDbType.Varchar) { Value = jenis_Baru.nama_jenis_produk } };
            commandExecutor(query, parameters);

        }
        public static DataTable checkNJP(string nama_jenis_produk)
        {
            string query = "SELECT id, nama_jenis_produk FROM jenis_produk WHERE nama_jenis_produk = @nama_jenis_produk";
            NpgsqlParameter[] parameters =
            {
            new NpgsqlParameter("@nama_jenis_produk", DbType.String) {Value = nama_jenis_produk},
            };
            return queryExecutor(query, parameters);
        }

        public static void update(M_Jenis_produk editJenisProduk)
        {
            string query = $"UPDATE {table} SET nama_jenis_produk = @nama_jenis_produk WHERE id= @id";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@id", NpgsqlDbType.Integer){Value = editJenisProduk.id },
                new NpgsqlParameter("@nama_jenis_produk", NpgsqlDbType.Varchar){Value = editJenisProduk.nama_jenis_produk}
            };
            commandExecutor(query, parameters);

        }

        public static bool IsNamaJenisProdukExists(string nama_jenis_produk)
        {
            string query = "SELECT COUNT(*) FROM jenis_produk WHERE nama_jenis_produk = @nama_jenis_produk";
            NpgsqlParameter[] parameters = {
            new NpgsqlParameter("@nama_jenis_produk", NpgsqlDbType.Varchar) { Value = nama_jenis_produk }
            };

            DataTable result = DBconnection.queryExecutor(query, parameters);

            return result.Rows[0].Field<Int64>(0) > 0;
        }
        public static void delete(string nama_jenis_produk)
        {
            string query = $"DELETE FROM {table} where nama_jenis_produk = @nama_jenis_produk";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@nama_jenis_produk", NpgsqlDbType.Varchar) { Value = nama_jenis_produk }
            };
            commandExecutor(query, parameters);
        }
    }

}
