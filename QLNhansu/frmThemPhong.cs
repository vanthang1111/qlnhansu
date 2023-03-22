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
    public partial class frmThemPhong : Form
    {
        public frmThemPhong()
        {
            InitializeComponent();
        }
        public frmLuong frmTP;
        public frmThemPhong(frmLuong frm)
        {
            InitializeComponent();
            frmTP = frm;
        }
        KetNoi kn = new KetNoi();
        public void getData()
        {
            string query = "select * from Phong";
            DataSet ds = kn.LayDuLieu(query, "Phong");
            dgvThemPhong.DataSource = ds.Tables["Phong"];
        }
        private void frmThemPhong_Load(object sender, EventArgs e)
        {
            getData();
        }
        private void dgvThemPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string MaPhongt = dgvThemPhong.Rows[row].Cells["MaPhong"].Value.ToString();
            frmTP.setMaPhong(MaPhongt);
        }
    }
}
