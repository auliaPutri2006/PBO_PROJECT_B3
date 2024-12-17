using PBO_PROJECT_B3.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBO_PROJECT_B3.model;
using PBO_PROJECT_B3.view;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using PBO_PROJECT_B3.context;


namespace PBO_PROJECT_B3.context
{
    internal class C_adminBiasa : DBconnection
    {
        private static string table = "administrator";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataAdministrator = queryExecutor(query);
            return dataAdministrator;
        }
        public static DataTable LoginAdmin(string username, string password)
        {
            string query = "SELECT * FROM administrator WHERE username_admin = @username AND pass_admin = @password";
            NpgsqlParameter[] parameters =
            {
            new NpgsqlParameter("@username", NpgsqlDbType.Varchar) { Value = username },
            new NpgsqlParameter("@password", NpgsqlDbType.Varchar) { Value = password }
        };

            DataTable dt = DBconnection.queryExecutor(query, parameters);

            if (dt.Rows.Count > 0)
            {
                int statusId = Convert.ToInt32(dt.Rows[0]["status_id"]);
                if (statusId == 2)
                {
                    throw new Exception("Akun Anda dalam status pending. Hubungi superadmin untuk mengaktifkannya.");
                }
            }

            return dt;
        }
        public static void UpdateStatusToPending(M_Administrator editAdmin)
        {
            string query = "UPDATE administrator SET username_admin = @username_admin, pass_admin = @pass_admin, status_id = @status_id WHERE id = @id";

            NpgsqlParameter[] parameters =
            {
        new NpgsqlParameter("@id", NpgsqlDbType.Integer) { Value = editAdmin.id },
        new NpgsqlParameter("@username_admin", NpgsqlDbType.Varchar) { Value = editAdmin.username_admin },
        new NpgsqlParameter("@pass_admin", NpgsqlDbType.Varchar) { Value = editAdmin.pass_admin },
        new NpgsqlParameter("@status_id", NpgsqlDbType.Integer) { Value = 2 }
    };

            DBconnection.queryExecutor(query, parameters);
        }

            public static void update2(M_Administrator editAdmin)
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

        public static int GetStatusId(string status)
        {
            return status.ToLower() switch
            {
                "aktif" => 1,
                "pending" => 2,
                "nonaktif" => 3,
                _ => throw new ArgumentException("Status yang dipilih tidak valid.")
            };
        }

        public static void UpdateAdministratorStatus(int id, string status)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID tidak valid. ID harus lebih besar dari 0.");
            }

            int statusId = GetStatusId(status);
            AdministratorContext.UpdateStatus(id, statusId);
        }


    }
}
