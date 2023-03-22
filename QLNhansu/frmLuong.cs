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
    public partial class frmLuong : Form
    {
        public frmLuong()
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
            string query = "select * from HoaDon";
            DataSet ds = kn.LayDuLieu(query, "HoaDon");
            dgvHoaDon.DataSource = ds.Tables["HoaDon"];
        }
        public void clearData()
        {
            txtMaHD.Text = "";
            txtMaPhong.Text = "";
            txtMaKhachHang.Text = "";
            txtMaNhanVien.Text = "";
            txtTongTien.Text = "";



            txtMaHD.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }

        internal void setMaNhanVien(object maNhanVient)
        {
            throw new NotImplementedException();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaHD.Text = dgvHoaDon.Rows[row].Cells["MaHoaDon"].Value.ToString();
                txtMaPhong.Text = dgvHoaDon.Rows[row].Cells["MaPhong"].Value.ToString();
                txtMaNhanVien.Text = dgvHoaDon.Rows[row].Cells["MaNhanVien"].Value.ToString();
                txtMaKhachHang.Text = dgvHoaDon.Rows[row].Cells["MaKhachHang"].Value.ToString();
                txtTongTien.Text = dgvHoaDon.Rows[row].Cells["TongTien"].Value.ToString();




                txtMaHD.Enabled = false;
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
        //
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into HoaDon(MaHoaDon,MaPhong,MaNhanVien,MaKhachHang,TongTien)Values('{0}','{1}','{2}','{3}',{4})", 
                txtMaHD.Text, txtMaPhong.Text,txtMaNhanVien.Text,txtMaKhachHang.Text,txtTongTien.Text);
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
            string query = string.Format("update HoaDon set MaPhong = '{1}',MaNhanVien = '{2}',MaKhachHang = '{3}',TongTien = {4} where MaHoaDon = '{0}'"
                ,txtMaHD.Text, txtMaPhong.Text, txtMaNhanVien.Text, txtMaKhachHang.Text, txtTongTien.Text);
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
            string query = string.Format("delete from HoaDon where MaHoaDon = '{0}'", txtMaHD.Text);
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
            string query = string.Format("select * from HoaDon where MaHoaDon like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "HoaDon");
            dgvHoaDon.DataSource = ds.Tables["HoaDon"];
        }
        //
        public void setMaPhong(string MaPhongt)
        {
            txtMaPhong.Text = MaPhongt;
        }
        public void setMaNhanVien(string MaNhanVient)
        {
            txtMaNhanVien.Text = MaNhanVient;
        }
        public void setKhachHang(string MaKhachHangt)
        {
            txtMaKhachHang.Text = MaKhachHangt;
        }
        //
        private void btnThemMaPhong_Click(object sender, EventArgs e)
        {
            frmThemPhong frm = new frmThemPhong(this);
            frm.Show();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void btnThemMaKhachHang_Click(object sender, EventArgs e)
        {

        }
    }
}
