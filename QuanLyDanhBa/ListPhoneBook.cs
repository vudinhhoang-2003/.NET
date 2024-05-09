using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QuanLyDanhBa
{
    public class ListPhoneBook
    {
        private static ListPhoneBook instance;
        private List<PhoneBook> listNumberPhone;

        public List<PhoneBook> ListNumberPhone
        {
            get => listNumberPhone;
            set => listNumberPhone = value;
        }

        private ListPhoneBook()
        {
            listNumberPhone = new List<PhoneBook>();
            // Load data from database
            LoadDataFromDatabase();
        }

        public static ListPhoneBook Instance
        {
            get
            {
                if (instance == null)
                    instance = new ListPhoneBook();
                return instance;
            }
        }

        private void LoadDataFromDatabase()
        {
            string connectionString = @"Data Source=VUHOANG\\SQLEXPRESS;Initial Catalog=danhBa;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT hoTen, soDienThoai, idCoQuan, ghiChu FROM tblNguoiDung";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader["hoTen"].ToString();
                        string numberPhone = reader["soDienThoai"].ToString();
                        string organization = reader["idCoQuan"].ToString();
                        string note = reader["ghiChu"].ToString();

                        listNumberPhone.Add(new PhoneBook(name, numberPhone, organization, note));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
