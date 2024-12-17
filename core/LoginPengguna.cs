using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql; 

namespace PBO_PROJECT_B3.core
{
    internal class LoginPengguna
    {
        public static bool Login(string input_pengguna, string pass_pengguna)
        {
            try
            {
                string query = "SELECT * FROM pengguna WHERE (nama_pengguna = @input OR username_pengguna = @input OR telp_pengguna = @input OR email_pengguna = @input) AND pwuser = @password";

                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@input", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = input_pengguna },
                    new NpgsqlParameter("@password", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = pass_pengguna },
                };

                DataTable result = DBconnection.queryExecutor(query, parameters);

                if (result.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Login gagal! Username atau password salah.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Terjadi kesalahan: {e.Message}");
                return false;
            }
            }
        }
    }

