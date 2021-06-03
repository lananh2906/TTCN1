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
    public partial class FrmNhanVien : Form
    {
        DataTable tblnhanvien;
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblnhanhvien";
            tblnhanvien = Functions.GetDataToTable(sql);  ; //Đọc dữ liệu từ bảng
            dgvNhanVien.DataSource = tblnhanvien; //Nguồn dữ liệu            
            


            dgvNhanVien.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["HoTen"].Value.ToString();
            txtNamSinh.Text = dgvNhanVien.CurrentRow.Cells["NamSinh"].Value.ToString();
            txtQueQuan.Text = dgvNhanVien.CurrentRow.Cells["QueQuan"].Value.ToString();
            txtGioiTinh.Text = dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value.ToString();
            txtSdt.Text = dgvNhanVien.CurrentRow.Cells["SDT"].Value.ToString();
            txtMaCV.Text = dgvNhanVien.CurrentRow.Cells["MaCV"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;

            txtMaNV.Enabled = true;
            txtMaNV.Focus();
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtNamSinh.Text = "";
            txtQueQuan.Text = "";
            txtGioiTinh.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            txtMaCV.Text = "";

            //txtDonGiaNhap.Enabled = false;
            // txtDonGiaBan.Enabled = false;


        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "UPDATE tblnhanhvien SET MaNV='" + txtMaNV.Text +
                "',HoTen='" + txtTenNV.Text +
                "',NamSinh='" + txtNamSinh.Text +
                "',QueQuan='" + txtQueQuan.Text +
                "',GioiTinh='" + txtGioiTinh.Text +
                "',SDT='" + txtSdt.Text +
                "',Email='" + txtEmail.Text +
                "',MaCV='" + txtMaCV.Text + "' WHERE MaNV='" + txtMaNV.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql;
                sql = "DELETE tblnhanhvien WHERE MaNV='" + txtMaNV.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO tblnhanhvien(MaNV,HoTen,NamSinh,QueQuan,GioiTinh,Email,SDT,MaCV) VALUES ('" + txtMaNV.Text.Trim() + "','" + txtTenNV.Text.Trim() + "','" + txtNamSinh.Text + "','" + txtQueQuan.Text + "','" + txtGioiTinh.Text + "','"  + txtEmail.Text + "','" + txtSdt.Text + "','"  +  txtMaCV.Text.Trim() + "')";

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
