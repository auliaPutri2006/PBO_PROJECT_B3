using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBO_PROJECT_B3.model;
using System.Data.Common;
using PBO_PROJECT_B3.core;

namespace PBO_PROJECT_B3.context
{
    public static class AdministratorContext // Tambahkan kelas untuk membungkus metode
    {
        public static void UpdateStatus(int id, int statusId)
        {
            string query = "UPDATE administrator SET status_id = @status_id WHERE id = @id";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlDbType.Integer) { Value = id },
                new NpgsqlParameter("@status_id", NpgsqlDbType.Integer) { Value = statusId }
            };

            DBconnection.queryExecutor(query, parameters);
        }
    }
}

