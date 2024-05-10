using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDanhBa
{
    public partial class Form1 : Form
    {
        string Status = "";
        int Index = -1;

        private string connectionString = @"Data Source=VUHOANG\SQLEXPRESS;Initial Catalog=danhBa;Integrated Security=True;";
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
        }



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
        {
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

        void LoadListPhoneBook()
        {
            //dtgvPhoneBook.DataSource = null;
            dtgvPhoneBook.DataSource = ListPhoneBook.Instance.ListNumberPhone;
           // dtgvPhoneBook.Refresh();

        }

        void EnableControl(bool isEnableTextBox, bool isEnableDataGridView)
        {
            txbName.Enabled = txbNumberPhone.Enabled = txbOrganization.Enabled = txbNote.Enabled = isEnableTextBox;
            dtgvPhoneBook.Enabled = isEnableDataGridView;
        }
        #endregion

        void ClearTextBox()
        {
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableControl(true, false);
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = btnHuy.Enabled = true;
            Status = "Add";
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

            txbName.Text = ListPhoneBook.Instance.ListNumberPhone[Index].Name;
            txbNumberPhone.Text = ListPhoneBook.Instance.ListNumberPhone[Index].NumberPhone;
            txbOrganization.Text = ListPhoneBook.Instance.ListNumberPhone[Index].Organization;
            txbNote.Text = ListPhoneBook.Instance.ListNumberPhone[Index].Note;

            Status = "Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txbName.Text;
            string numberPhone = txbNumberPhone.Text;
            string organization = txbOrganization.Text;
            string note = txbNote.Text;

            if (Status == "Add")
            {
                ListPhoneBook.Instance.ListNumberPhone.Add(new PhoneBook(name, numberPhone, organization, note));
            }

            if (Status == "Update")
            {
                ListPhoneBook.Instance.ListNumberPhone[Index].Name = txbName.Text;
                ListPhoneBook.Instance.ListNumberPhone[Index].NumberPhone = txbNumberPhone.Text;
                ListPhoneBook.Instance.ListNumberPhone[Index].Organization = txbOrganization.Text;
                ListPhoneBook.Instance.ListNumberPhone[Index].Note = txbNote.Text;

            }

            EnableControl(false, true);
            LoadListPhoneBook();
            ClearTextBox();
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnHuy.Enabled = false;
        }

        private void dtgvPhoneBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Index = e.RowIndex;
        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Index < 0)
            {
                MessageBox.Show("Hãy chọn một bản ghi", "Cảnh báo");
                return;
            }
            ListPhoneBook.Instance.ListNumberPhone.RemoveAt(Index);
            LoadListPhoneBook();
        }
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EnableControl(true, false);
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnSave.Enabled = false;
            btnHuy.Enabled = true;
        }


        private void txbName_TextChanged(object sender, EventArgs e)
        {
            string search = txbName.Text;
            if (search != "")
            {
                List<PhoneBook> listSearch = new List<PhoneBook>();
                foreach (var item in ListPhoneBook.Instance.ListNumberPhone)
                {
                    if (item.Name.ToLower().Contains(search.ToLower()))
                    {
                        listSearch.Add(item);
                    }
                }

                dtgvPhoneBook.DataSource = null;
                CreatColumnForDataGridView();
                dtgvPhoneBook.DataSource = listSearch;
            }
            else
            {
            //    dtgvPhoneBook.DataSource = null;
                LoadListPhoneBook();
            }

        }
        #endregion

    }
}