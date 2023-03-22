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
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong()
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
            string query = "select * from LoaiPhong";
            DataSet ds = kn.LayDuLieu(query, "LoaiPhong");
            dgvLoaiPhong.DataSource = ds.Tables["LoaiPhong"];
        }
        public void clearData()
        {
            txtMaLoaiPhong.Text = "";
            txtTenLoaiPhong.Text = "";

            txtMaLoaiPhong.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaLoaiPhong.Text = dgvLoaiPhong.Rows[row].Cells["MaLoaiPhong"].Value.ToString();
                txtTenLoaiPhong.Text = dgvLoaiPhong.Rows[row].Cells["TenLoaiPhong"].Value.ToString();

                txtMaLoaiPhong.Enabled = false;
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
            string query = string.Format("insert into LoaiPhong(MaLoaiPhong,TenLoaiPhong)Values('{0}','{1}')",txtMaLoaiPhong.Text, txtTenLoaiPhong.Text);
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
            string query = string.Format("update LoaiPhong set TenLoaiPhong = '{1}' where MaLoaiPhong = '{0}'", txtMaLoaiPhong.Text, txtTenLoaiPhong.Text);
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
            string query = string.Format("delete from LoaiPhong where MaLoaiPhong = '{0}'",txtMaLoaiPhong.Text);
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
            string query = string.Format("select * from LoaiPhong where TenLoaiPhong like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "LoaiPhong");
            dgvLoaiPhong.DataSource = ds.Tables["LoaiPhong"];
        }
    }
}
