// Form1.cs
using System;
using System.Collections.Generic;
using System.Data;
<<<<<<< HEAD
=======
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
>>>>>>> f3a665c1db34ca41f053395e2a56d16b45f94ab2
using System.Linq;
using System.Windows.Forms;

namespace QuanLyDanhBa
{
    public partial class Form1 : Form
    {
        private int Index = -1;

        private string connectionString = @"Data Source=VUHOANG\SQLEXPRESS;Initial Catalog=danhBa;Integrated Security=True;";
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        private void Form1_Load(object sender, EventArgs e)
=======


        #region Method
        private void LoadDataFormBase()
        {
            try
            {
                // Tạo kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tạo truy vấn SQL
                    string query = "SELECT hoTen, soDienThoai, idCoQuan, ghiChu FROM tblNguoiDung";

                    // Tạo đối tượng SqlDataAdapter và đổ dữ liệu vào DataTable
                    dataAdapter = new SqlDataAdapter(query, connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    dtgvPhoneBook.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void CreatColumnForDataGridView()
>>>>>>> f3a665c1db34ca41f053395e2a56d16b45f94ab2
        {
            CreatColumnForDataGridView();
            EnableControl(false, true);
            LoadListPhoneBook();
            btnSave.Enabled = btnHuy.Enabled = false;
        }

        private void CreatColumnForDataGridView()
        {
            dtgvPhoneBook.Columns.Clear();

            var colName = new DataGridViewTextBoxColumn();
            var colNumberPhone = new DataGridViewTextBoxColumn();
            var colOrganization = new DataGridViewTextBoxColumn();
            var colNote = new DataGridViewTextBoxColumn();

            colName.HeaderText = "Họ và tên";
            colNumberPhone.HeaderText = "Số điện thoại";
            colOrganization.HeaderText = "Cơ quan";
            colNote.HeaderText = "Ghi chú";

            colName.DataPropertyName = "Name";
            colNumberPhone.DataPropertyName = "NumberPhone";
            colOrganization.DataPropertyName = "Organization";
            colNote.DataPropertyName = "Note";

            colName.Width = 160;
            colNumberPhone.Width = 100;
            colOrganization.Width = 200;
            colNote.Width = 120;

            dtgvPhoneBook.Columns.AddRange(new DataGridViewColumn[] { colName, colNumberPhone, colOrganization, colNote });
        }

        private void LoadListPhoneBook()
        {
            dtgvPhoneBook.DataSource = ListPhoneBook.Instance.ListNumberPhone;
        }

        private void EnableControl(bool isEnableTextBox, bool isEnableDataGridView)
        {
            txbName.Enabled = txbNumberPhone.Enabled = txbOrganization.Enabled = txbNote.Enabled = isEnableTextBox;
            dtgvPhoneBook.Enabled = isEnableDataGridView;
        }

        private void ClearTextBox()
        {
<<<<<<< HEAD
            txbName.Text = txbNumberPhone.Text = txbOrganization.Text = txbNote.Text = "";
=======
            foreach (var item in this.Controls)
            {
                TextBox item1 = item as TextBox;
                if (item1 != null)
                {
                    item1.Clear();
                }
            }
        }
        #region Event
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            EnableControl(false, true);
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnHuy.Enabled = false;

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            EnableControl(false, true);
            CreatColumnForDataGridView();
            LoadListPhoneBook();
            LoadDataFormBase();


            btnSave.Enabled = btnHuy.Enabled = false;
>>>>>>> f3a665c1db34ca41f053395e2a56d16b45f94ab2
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableControl(true, false);
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = btnHuy.Enabled = true;
            Index = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Index < 0)
            {
                MessageBox.Show("Hãy chọn một bản ghi", "Cảnh báo");
                return;
            }

            EnableControl(true, false);
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = btnHuy.Enabled = true;

            var selectedPhoneBook = ListPhoneBook.Instance.ListNumberPhone[Index];
            txbName.Text = selectedPhoneBook.Name;
            txbNumberPhone.Text = selectedPhoneBook.NumberPhone;
            txbOrganization.Text = selectedPhoneBook.Organization;
            txbNote.Text = selectedPhoneBook.Note;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txbName.Text;
            var numberPhone = txbNumberPhone.Text;
            var organization = txbOrganization.Text;
            var note = txbNote.Text;

            if (Index < 0)
            {
                ListPhoneBook.Instance.Add(new PhoneBook(name, numberPhone, organization, note));
            }
            else
            {
                ListPhoneBook.Instance.Update(Index, new PhoneBook(name, numberPhone, organization, note));
            }

            EnableControl(false, true);
            LoadListPhoneBook();
            ClearTextBox();
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnHuy.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Index < 0)
            {
                MessageBox.Show("Hãy chọn một bản ghi", "Cảnh báo");
                return;
            }
            ListPhoneBook.Instance.Remove(Index);
            LoadListPhoneBook();
            ClearTextBox();
            Index = -1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            EnableControl(false, true);
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnHuy.Enabled = false;
            Index = -1;
        }

        private void dtgvPhoneBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Index = e.RowIndex;
            }
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {
            string search = txbName.Text.ToLower();
            if (!string.IsNullOrEmpty(search))
            {
                var listSearch = ListPhoneBook.Instance.ListNumberPhone
                    .Where(pb => pb.Name.ToLower().Contains(search))
                    .ToList();

                dtgvPhoneBook.DataSource = listSearch;
            }
            else
            {
                LoadListPhoneBook();
            }
        }
    }
}
