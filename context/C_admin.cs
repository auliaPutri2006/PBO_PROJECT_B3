using Npgsql;
using NpgsqlTypes;
using PBO_PROJECT_B3.model;
using PBO_PROJECT_B3.core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace PBO_PROJECT_B3.core
{
    internal class C_admin : DBconnection
    {
        private static string table = "administrator";

        public static DataTable all()
        {
            string query = $"SELECT ad.username_admin, ad.pass_admin, s.nama_status FROM {table} ad JOIN status s ON ad.status_id = s.id";
            DataTable dataAdministrator = queryExecutor(query);
            return dataAdministrator;
        }

        public static DataTable read(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id = @id";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlDbType.Integer) { Value = id }
            };
            DataTable dataAdministrator = queryExecutor(query, parameters);
            return dataAdministrator;

        }
        public static void create(M_Administrator newAdmin)
        {
            
                
              string query = $"INSERT INTO {table} (username_admin, pass_admin, status_id) VALUES (@username_admin, @pass_admin, @status_id)";

                
                NpgsqlParameter[] parameters =
                {
        new NpgsqlParameter("@username_admin", NpgsqlDbType.Varchar) { Value = newAdmin.username_admin },
        new NpgsqlParameter("@pass_admin", NpgsqlDbType.Varchar) { Value = newAdmin.pass_admin },
        new NpgsqlParameter("@status_id", NpgsqlDbType.Integer) { Value = newAdmin.status_id }
    };

                try
                {
                    
                    commandExecutor(query, parameters);
                }
                catch (NpgsqlException npgsqlEx)
                {
                    
                    throw new Exception($"Kesalahan database: {npgsqlEx.Message}", npgsqlEx);
                }
                catch (Exception ex)
                {
                    
                    throw new Exception($"Terjadi kesalahan: {ex.Message}", ex);
                }
            }

            public static void delete(string username, string password)
        {
            string query = $"DELETE FROM {table} WHERE username_admin = @username_admin AND pass_admin = @pass_admin";
            NpgsqlParameter[] parameters =
            {
            new NpgsqlParameter("@username_admin", NpgsqlDbType.Varchar) { Value = username },
            new NpgsqlParameter("@pass_admin", NpgsqlDbType.Varchar) { Value = password }
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_Administrator editAdmin)
        {
            string query = $"UPDATE {table} SET username_admin = @username_admin, pass_admin = @pass_admin WHERE id = @id";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlDbType.Integer){Value = editAdmin.id },
                new NpgsqlParameter("@username_admin", NpgsqlDbType.Varchar){Value = editAdmin.username_admin},
                new NpgsqlParameter("@pass_admin", NpgsqlDbType.Varchar){Value = editAdmin.pass_admin},
            };
            commandExecutor(query, parameters);
        }
        public static DataTable dataadmin(string inputs)
        {
            string query = "SELECT * FROM administrator WHERE username_admin = @username_admin";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@username_admin", inputs){NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar}
            };
            return queryExecutor(query, parameters);

        }
        public static  DataTable loginadminByUsername(string username_admin)
        {
            string query = "SELECT id, username_admin FROM administrator WHERE username_admin = @inputs";
            NpgsqlParameter[] parameters =
            {
            new NpgsqlParameter("@inputs", DbType.String) {Value = username_admin},
            };
            return queryExecutor(query, parameters);
        }
        public static bool IsUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM administrator WHERE username_admin = @username";
            NpgsqlParameter[] parameters =
            {
        new NpgsqlParameter("@username", NpgsqlDbType.Varchar) { Value = username }
    };

            try
            {
                object result = ExecuteScalar(query, parameters);
                int count = Convert.ToInt32(result); 
                return count > 0; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Terjadi kesalahan saat memeriksa username: {ex.Message}", ex);
            }
        }





        public static DataTable loginadmin(string username, string password)
        {
            string query = "SELECT id, username_admin, status_id FROM administrator WHERE username_admin = @username AND pass_admin = @password";
            NpgsqlParameter[] parameters =
            {
        new NpgsqlParameter("@username", NpgsqlDbType.Varchar) { Value = username },
        new NpgsqlParameter("@password", NpgsqlDbType.Varchar) { Value = password }
    };

            return DBconnection.queryExecutor(query, parameters);
        }
        


    }

}
 
