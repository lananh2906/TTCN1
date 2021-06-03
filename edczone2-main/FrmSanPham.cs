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
    
    public partial class FrmSanPham : Form
    {
        DataTable tblsanpham;
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblsanpham";
            tblsanpham = Functions.GetDataToTable(sql);

            //Đọc dữ liệu từ bảng
            dgvsanpham.DataSource = tblsanpham; //Nguồn dữ liệu            
           


            dgvsanpham.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvsanpham.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvsanpham_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = dgvsanpham.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgvsanpham.CurrentRow.Cells["TenSP"].Value.ToString();
            txtSoLuong.Text = dgvsanpham.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtMoTa.Text = dgvsanpham.CurrentRow.Cells["MoTa"].Value.ToString();
            txtDonGia.Text = dgvsanpham.CurrentRow.Cells["DonGia"].Value.ToString();
            txtDVT.Text = dgvsanpham.CurrentRow.Cells["DVT"].Value.ToString();
            txtMaNCC.Text = dgvsanpham.CurrentRow.Cells["MaNCC"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            
            txtMaSP.Enabled = true;
            txtMaSP.Focus();
            txtSoLuong.Enabled = true;
            txtDonGia.Enabled = true;
            ResetValues();
            
        }
        private void ResetValues()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtMaNCC.Text = "";
            txtMoTa.Text= "";
            txtDVT.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
           
            //txtDonGiaNhap.Enabled = false;
            // txtDonGiaBan.Enabled = false;
            

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO tblsanpham(MaSP,TenSP,SoLuong,MoTa,DonGia,DVT,MaNCC) VALUES('" + txtMaSP.Text.Trim() + "','" + txtTenSP.Text.Trim() + "','" +  txtSoLuong.Text.Trim() + "','" + txtMoTa.Text + "','" + txtDonGia.Text + "','" + "','" + txtDVT.Text + txtMaNCC.Text + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaSP.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "UPDATE tblsanpham SET MaSP='" + txtMaSP.Text +
                "',TenSP='" + txtTenSP.Text +
                "',SoLuong='" + txtSoLuong.Text +
                "',MoTa='" + txtMoTa.Text +
                "',DonGia='" + txtDonGia.Text +
                "',DVT='" + txtDVT.Text +
                "',MaNCC='" + txtMaNCC.Text + "' WHERE MaSP='" + txtMaSP.Text + "'";
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
                sql = "DELETE tblsanpham WHERE MaSP='" + txtMaSP.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaSP.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

    }
}
