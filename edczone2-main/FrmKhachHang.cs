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
    public partial class FrmKhachHang : Form
    {
        DataTable tblkhachhang;
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dgvkhachhang_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = dgvkhachhang.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvkhachhang.CurrentRow.Cells["TenKH"].Value.ToString();
            txtDiaChi.Text = dgvkhachhang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSdt.Text = dgvkhachhang.CurrentRow.Cells["SDT"].Value.ToString();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblkhachhang";
            tblkhachhang = Functions.GetDataToTable(sql);

            //Đọc dữ liệu từ bảng
            dgvkhachhang.DataSource = tblkhachhang; //Nguồn dữ liệu            



            dgvkhachhang.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
            
    }
}
