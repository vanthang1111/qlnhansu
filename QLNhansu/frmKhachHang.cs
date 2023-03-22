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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
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
            string query = "select * from KhachHang";
            DataSet ds = kn.LayDuLieu(query, "KhachHang");
            dgvKhachHang.DataSource = ds.Tables["KhachHang"];
        }
        public void clearData()
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtGioiTinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";



            txtMaKhach.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaKhach.Text = dgvKhachHang.Rows[row].Cells["MaKhachHang"].Value.ToString();
                txtTenKhach.Text = dgvKhachHang.Rows[row].Cells["TenKhachHang"].Value.ToString();
                txtGioiTinh.Text = dgvKhachHang.Rows[row].Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[row].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dgvKhachHang.Rows[row].Cells["SDT"].Value.ToString();


                txtMaKhach.Enabled = false;
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
            string query = string.Format("insert into KhachHang(MaKhachHang,TenKhachHang,GioiTinh,DiaChi,SDT)Values('{0}','{1}','{2}','{3}','{4}')", 
                txtMaKhach.Text, txtTenKhach.Text,txtGioiTinh.Text,txtDiaChi.Text,txtSDT.Text);
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
            string query = string.Format("update KhachHang set TenKhachHang = '{1}',GioiTinh = '{2}',DiaChi = '{3}',SDT = '{4}' where MaKhachHang = '{0}'", 
                txtMaKhach.Text, txtTenKhach.Text, txtGioiTinh.Text, txtDiaChi.Text, txtSDT.Text);
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
            string query = string.Format("delete from KhachHang where MaKhachHang = '{0}'", txtMaKhach.Text);
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
            string query = string.Format("select * from KhachHang where TenKhachHang like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "KhachHang");
            dgvKhachHang.DataSource = ds.Tables["KhachHang"];
        }
    }
}
