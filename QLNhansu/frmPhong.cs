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
    public partial class frmPhong : Form
    {
        public frmPhong()
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
            string query = "select * from Phong";
            DataSet ds = kn.LayDuLieu(query, "Phong");
            dgvPhong.DataSource = ds.Tables["Phong"];
        }
        public void getComboLoaiPhong()
        {
            string query = "select * from LoaiPhong";
            DataSet ds = kn.LayDuLieu(query, "LoaiPhong");
            cmbMaLoaiPhong.DataSource = ds.Tables["LoaiPhong"];
            cmbMaLoaiPhong.DisplayMember = "TenLoaiPhong"; // Du Lieu Hien Thi cmb
            cmbMaLoaiPhong.ValueMember = "MaLoaiPhong"; // Du Lieu Duoc Dung Tu cmb

        }
        public void clearData()
        {
            txtMaPhong.Text = "";
            cmbMaLoaiPhong.Text = "";
            txtTenPhong.Text = "";
            txtGiaPhong.Text = "";
            txtTinhTrang.Text = "";
            txtMoTa.Text = "";

            txtMaPhong.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            getComboLoaiPhong();
            getData();
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaPhong.Text = dgvPhong.Rows[row].Cells["MaPhong"].Value.ToString();
                cmbMaLoaiPhong.SelectedValue = dgvPhong.Rows[row].Cells["MaLoaiPhong"].Value.ToString();
                txtTenPhong.Text = dgvPhong.Rows[row].Cells["TenPhong"].Value.ToString();
                txtGiaPhong.Text = dgvPhong.Rows[row].Cells["GiaPhong"].Value.ToString();
                txtTinhTrang.Text = dgvPhong.Rows[row].Cells["TinhTrang"].Value.ToString();
                txtMoTa.Text = dgvPhong.Rows[row].Cells["MoTa"].Value.ToString();


                txtMaPhong.Enabled = false;
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
            string query = string.Format("insert into Phong(MaPhong,MaLoaiPhong,TenPhong,GiaPhong,TinhTrang,MoTa)Values('{0}','{1}','{2}',{3},'{4}','{5}')"
                ,txtMaPhong.Text, cmbMaLoaiPhong.SelectedValue.ToString(), txtTenPhong.Text,txtGiaPhong.Text,txtTinhTrang.Text,txtMoTa.Text);
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
            string query = string.Format("update Phong set MaLoaiPhong = '{1}',TenPhong = '{2}',GiaPhong = {3},TinhTrang = '{4}',MoTa = '{5}' where MaPhong = '{0}'"
                , txtMaPhong.Text, cmbMaLoaiPhong.SelectedValue.ToString(), txtTenPhong.Text, txtGiaPhong.Text, txtTinhTrang.Text, txtMoTa.Text);
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
            string query = string.Format("delete from Phong where MaPhong = '{0}'", txtMaPhong.Text);
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

        private void txtTim_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from Phong where TenPhong like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "Phong");
            dgvPhong.DataSource = ds.Tables["Phong"];
        }
    }
}
