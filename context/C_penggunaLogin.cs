using Npgsql;
using PBO_PROJECT_B3.core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBO_PROJECT_B3.context
{
    internal class C_penggunaLogin : DBconnection
    {
        public static DataTable getdatadirinama(string username_pengguna)
        {
            string query = "SELECT id FROM pengguna WHERE username_pengguna = @username_pengguna";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@username_pengguna", username_pengguna) { NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar }
            };
            return queryExecutor(query, parameters);
        }
    }
}
