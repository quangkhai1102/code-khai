using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace làm_việc_nhóm_3
{
    internal class function
    {
        // Kết nối cơ sở dữ liệu
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-4RB4QAK\\QUANGKHAI; Initial Catalog=QLikhachsan; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";
            return con;
        }

        // Lấy dữ liệu từ cơ sở dữ liệu
        public DataSet GetData(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = getConnection()) // Sử dụng "using" để đảm bảo đóng kết nối
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }

        // Cập nhật dữ liệu (INSERT, UPDATE, DELETE)
        public void setData(string query, string message)
        {
            try
            {
                using (SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        // Thông báo thành công
                        MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lấy dữ liệu cho ComboBox
        public SqlDataReader getForCombo(string query)
        {
            SqlDataReader sdr = null;
            try
            {
                SqlConnection con = getConnection();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // Đóng kết nối khi SqlDataReader đóng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sdr;
        }
    }
}
