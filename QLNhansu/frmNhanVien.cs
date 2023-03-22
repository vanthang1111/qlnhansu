using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaTro
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmHeThong frm = new frmHeThong();
            frm.Show();
            this.Hide();
        }
        KetNoi kn = new KetNoi();
        public void getData()
        {
            string query = "select * from NhanVien";
            DataSet ds = kn.LayDuLieu(query, "NhanVien");
            dgvNhanVien.DataSource = ds.Tables["NhanVien"];
        }
        public void clearData()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtGioiTinh.Text = "";
            txtNgaySinh.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtNgayVaoLam.Text = "";


            txtMaNV.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNV.Text = dgvNhanVien.Rows[row].Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[row].Cells["TenNhanVien"].Value.ToString();
                txtGioiTinh.Text = dgvNhanVien.Rows[row].Cells["GioiTinh"].Value.ToString();
                txtNgaySinh.Text = dgvNhanVien.Rows[row].Cells["NgaySinh"].Value.ToString();
                txtSDT.Text = dgvNhanVien.Rows[row].Cells["SDT"].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[row].Cells["DiaChi"].Value.ToString();
                txtNgayVaoLam.Text = dgvNhanVien.Rows[row].Cells["NgayVaoLam"].Value.ToString();


                txtMaNV.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                btnTaoMoi.Enabled = true;
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into NhanVien(MaNhanVien,TenNhanVien,GioiTinh,NgaySinh,SDT,DiaChi,NgayVaoLam)Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',)", 
                txtMaNV.Text, txtTenNV.Text, txtGioiTinh.Text, txtNgaySinh.Text, txtSDT.Text, txtDiaChi.Text, txtNgayVaoLam.Text);
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Thành Công");
                getData();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format("update NhanVien set TenNhanVien = '{1}',GioiTinh = '{2}',NgaySinh = '{3}',SDT = '{4}',DiaChi = '{5}',NgayVaoLam ='{6}'  where MaLoaiPhong = '{0}'", 
                txtMaNV.Text, txtTenNV.Text, txtGioiTinh.Text, txtNgaySinh.Text, txtSDT.Text, txtDiaChi.Text, txtNgayVaoLam.Text);
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa Thành Công");
                getData();
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format("delete from NhanVien where MaNhanVien = '{0}'", txtMaNV.Text);
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành Công");
                getData();
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from NhanVien where TenNhanVien like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "NhanVien");
            dgvNhanVien.DataSource = ds.Tables["NhanVien"];
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
