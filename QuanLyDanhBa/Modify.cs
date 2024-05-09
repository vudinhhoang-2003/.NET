//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;

//namespace QuanLyDanhBa
//{
//    class Modify
//    {
//        SqlDataAdapter dataAdapter; //sẽ truy xuất dữ liệu vào bảng

//        public Modify() 
//        { 

//        }
//       //Dataset sẽ trả về nhiều bảng
//        //Datatable sẽ trả về 1 bảng
//        public DataTable getAllNguoiDung()
//        { 
//            //DataTable dataTable = new DataTable();
//            string query = "select hoTen, soDienThoai, idCoQuan, ghiChu from tblNguoiDung";
//            using (SqlConnection sqlConnection = Connection.getConnection())
//            {
//                sqlConnection.Open();
//                dataAdapter = new SqlDataAdapter(query, sqlConnection);
//                dataAdapter.Fill(dataTable);

//                sqlConnection.Close();
//            }
//            return new DataTable(); 
//        }
//    }
//}
