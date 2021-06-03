using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using EDCZONE.Class;


namespace EDCZONE
{
    public partial class FrmNhaCungCap : Form
    {
        DataTable tblncc;
        public FrmNhaCungCap()
        {
            InitializeComponent();
        }

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaNCC, TenNCC, DiaChi, SDT FROM tblncc";
            tblncc = Functions.GetDataToTable(sql); 
            
           
            //Đọc dữ liệu từ bảng
            dgvnhacc.DataSource = tblncc; //Nguồn dữ liệu            
            dgvnhacc.Columns[0].HeaderText = "Mã NCC ";
            dgvnhacc.Columns[1].HeaderText = "Tên NCC";
            dgvnhacc.Columns[2].HeaderText = "Địa Chỉ";
            dgvnhacc.Columns[3].HeaderText = "SDT";
           

            dgvnhacc.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvnhacc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvnhacc_Click(object sender, EventArgs e)
        {
           txtMaNCC.Text = dgvnhacc.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvnhacc.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtDiaChi.Text = dgvnhacc.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSdt.Text = dgvnhacc.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
       
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaNCC.Enabled = true;//cho phép nhập mới
            txtMaNCC.Focus();
        }
        private void ResetValue()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO tblncc VALUES(N'" +
                txtMaNCC.Text + "',N'" + txtTenNCC.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSdt.Text + "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
           
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "UPDATE tblncc SET TenNCC=N'" +
                txtTenNCC.Text.ToString() +
                "' WHERE MaNCC=N'" + txtMaNCC.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblncc WHERE MaNCC=N'" + txtMaNCC.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
