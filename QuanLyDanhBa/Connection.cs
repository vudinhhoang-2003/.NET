using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyDanhBa
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-3PTRNDJ\SQLEXPRESS;Initial Catalog=danhBa;Integrated Security=True;Trust Server Certificate=True";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
