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
    public partial class frmNguoiDung : Form
    {
        public frmNguoiDung()
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
            string query = "select * from NguoiDung";
            DataSet ds = kn.LayDuLieu(query, "NguoiDung");
            dgvNguoiDung.DataSource = ds.Tables["NguoiDung"];
        }
        public void clearData()
        {
            txtID.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";


            txtID.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }
        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtID.Text = dgvNguoiDung.Rows[row].Cells["IdNguoiDung"].Value.ToString();
                txtTaiKhoan.Text = dgvNguoiDung.Rows[row].Cells["TaiKhoan"].Value.ToString();
                txtMatKhau.Text = dgvNguoiDung.Rows[row].Cells["MatKhau"].Value.ToString();


                txtID.Enabled = false;
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
            string query = string.Format("insert into NguoiDung(IdNguoiDung,TaiKhoan,MatKhau)Values('{0}','{1}','{2}')", 
                txtID.Text, txtTaiKhoan.Text,txtMatKhau.Text);
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
            string query = string.Format("update NguoiDung set TaiKhoan = '{1}', MatKhau = '{2}' where IdNguoiDung = '{0}'", 
                txtID.Text, txtTaiKhoan.Text, txtMatKhau.Text);
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
            string query = string.Format("delete from NguoiDung where IdNguoiDung = '{0}'", txtID.Text);
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
            string query = string.Format("select * from NguoiDung where TaiKhoan like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "NguoiDung");
            dgvNguoiDung.DataSource = ds.Tables["NguoiDung"];
        }
    }
}
