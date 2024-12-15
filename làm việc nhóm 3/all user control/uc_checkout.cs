using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace làm_việc_nhóm_3.all_user_control
{
    public partial class uc_checkout : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-4RB4QAK\\QUANGKHAI;Initial Catalog=QLikhachsan;Integrated Security=True;TrustServerCertificate=True;";

        public uc_checkout()
        {
            InitializeComponent();
        }

        private void uc_checkout_Load(object sender, EventArgs e)
        {
            // Bạn có thể thêm hành động cần thiết khi load UserControl, ví dụ: LoadData();
        }

        // Sự kiện tìm kiếm theo tên khách hàng
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchName = guna2TextBox1.Text;

            if (!string.IsNullOrEmpty(searchName))
            {
                LoadCustomerData(searchName);
            }
        }

        // Hàm tìm kiếm khách hàng theo tên
        private void LoadCustomerData(string searchName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Tenkhachhang, IDphong FROM Khachhang WHERE Tenkhachhang LIKE @Tenkhachhang";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tenkhachhang", "%" + searchName + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu vào DataGridView
                        guna2DataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi thanh toán
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string customerName = guna2TextBox1.Text;
            DateTime paymentDate = DateTime.Now;

            // Xác nhận thanh toán
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thanh toán cho khách hàng " + customerName + " không?",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(customerName))
                {
                    // Cập nhật thông tin thanh toán vào cơ sở dữ liệu
                    UpdatePayment(customerName, paymentDate);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Nếu người dùng chọn Hủy, không làm gì
                MessageBox.Show("Hành động thanh toán đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm cập nhật thông tin thanh toán vào cơ sở dữ liệu
        private void UpdatePayment(string customerName, DateTime paymentDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Cập nhật thông tin thanh toán cho khách hàng
                    string query = "UPDATE Khachhang SET Thanhtoan = 'YES', Ngaythanhtoan = @Ngaythanhtoan WHERE Tenkhachhang = @Tenkhachhang";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tenkhachhang", customerName);
                        cmd.Parameters.AddWithValue("@Ngaythanhtoan", paymentDate);

                        cmd.ExecuteNonQuery();
                    }

                    // Chuyển dữ liệu sang bảng LichSuKhachHang
                    string selectQuery = "SELECT * FROM Khachhang WHERE Tenkhachhang = @Tenkhachhang";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, conn);
                    DataTable customerDetails = new DataTable();
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Tenkhachhang", customerName);
                    dataAdapter.Fill(customerDetails);

                    if (customerDetails.Rows.Count > 0)
                    {
                        string customerNameDetail = customerDetails.Rows[0]["Tenkhachhang"].ToString();
                        string roomIdDetail = customerDetails.Rows[0]["IDphong"].ToString();
                        DateTime checkInDate = Convert.ToDateTime(customerDetails.Rows[0]["NgayCheckIn"]);
                        DateTime checkOutDate = Convert.ToDateTime(customerDetails.Rows[0]["NgayCheckOut"]);
                        long totalAmount = Convert.ToInt64(customerDetails.Rows[0]["TongTien"]);

                        // Chuyển dữ liệu sang bảng lịch sử khách hàng
                        string insertHistoryQuery = "INSERT INTO LichSuKhachHang (TenKhachHang, IDphong, MaPhong, NgayThanhToan, TrangThaiThanhToan, NgayCheckIn, NgayCheckOut, TongTien) " +
                                                    "VALUES (@TenKhachHang, @IDphong, @MaPhong, @NgayThanhToan, @TrangThaiThanhToan, @NgayCheckIn, @NgayCheckOut, @TongTien)";
                        using (SqlCommand cmdHistory = new SqlCommand(insertHistoryQuery, conn))
                        {
                            cmdHistory.Parameters.AddWithValue("@TenKhachHang", customerNameDetail);
                            cmdHistory.Parameters.AddWithValue("@IDphong", roomIdDetail);
                            cmdHistory.Parameters.AddWithValue("@MaPhong", roomIdDetail);
                            cmdHistory.Parameters.AddWithValue("@NgayThanhToan", paymentDate);
                            cmdHistory.Parameters.AddWithValue("@TrangThaiThanhToan", "YES");
                            cmdHistory.Parameters.AddWithValue("@NgayCheckIn", checkInDate);
                            cmdHistory.Parameters.AddWithValue("@NgayCheckOut", checkOutDate);
                            cmdHistory.Parameters.AddWithValue("@TongTien", totalAmount);
                            cmdHistory.ExecuteNonQuery();
                        }

                        // Xóa khách hàng khỏi bảng Khachhang
                        string deleteQuery = "DELETE FROM Khachhang WHERE Tenkhachhang = @Tenkhachhang";
                        using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn))
                        {
                            cmdDelete.Parameters.AddWithValue("@Tenkhachhang", customerName);
                            cmdDelete.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Thanh toán thành công và khách hàng đã được chuyển sang lịch sử.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cập nhật lại dữ liệu khách hàng
                    LoadCustomerData("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
