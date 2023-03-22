using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLNhaTro
{
    internal class KetNoi
    {
        private string con_str = "Data Source=TRUNGNGUYEN\\SQLEXPRESS;Initial Catalog=QuanLyQuanTro;Integrated Security=True";

        public DataSet LayDuLieu(string query, string table_name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(con_str);
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, table_name);
                return ds;
            }
            catch
            {
            }
            return null;
        }

        public bool ThucThi(string query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int soluong = cmd.ExecuteNonQuery();
                conn.Close();
                return soluong > 0;
            }
            catch
            {
            }
            return false;
        }
    }
}
