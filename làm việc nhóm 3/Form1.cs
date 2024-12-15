using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace làm_việc_nhóm_3
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối đến SQL Server
            string connectionString = "Data Source=DESKTOP-4RB4QAK\\QUANGKHAI;Initial Catalog=QLikhachsan;Integrated Security=True;TrustServerCertificate=True;";

            // Kiểm tra trường nhập liệu
            if (string.IsNullOrWhiteSpace(txtusername.Text) && string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu bị bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtusername.Text))
            {
                MessageBox.Show("Tên đăng nhập bị bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Mật khẩu bị bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Câu truy vấn kiểm tra tài khoản
                    string query = "SELECT COUNT(*) FROM Nhanvien WHERE Tennguoidung = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số truy vấn để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@username", txtusername.Text.Trim());

                        // Thực thi truy vấn và lấy kết quả
                        int usernameExists = (int)cmd.ExecuteScalar();

                        if (usernameExists > 0)
                        {
                            // Kiểm tra mật khẩu
                            query = "SELECT COUNT(*) FROM Nhanvien WHERE Tennguoidung = @username AND Matkhau = @password";

                            using (SqlCommand passwordCmd = new SqlCommand(query, conn))
                            {
                                passwordCmd.Parameters.AddWithValue("@username", txtusername.Text.Trim());
                                passwordCmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim());

                                int passwordValid = (int)passwordCmd.ExecuteScalar();

                                if (passwordValid > 0)
                                {
                                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Chuyển sang form dashboard
                                    dashboard ds = new dashboard();
                                    this.Hide();
                                    ds.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Mật khẩu sai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtpassword.Clear();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập sai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtusername.Clear();
                            txtpassword.Clear();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Hàm xử lý nền (nếu cần)
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Hàm xử lý giao diện (nếu cần)
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            // Xử lý thay đổi văn bản (nếu cần)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Xử lý khi form được tải (nếu cần)
        }
    }
}