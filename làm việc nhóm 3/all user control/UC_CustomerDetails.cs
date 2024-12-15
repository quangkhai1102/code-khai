using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace làm_việc_nhóm_3.all_user_control
{
    public partial class UC_CustomerDetails : UserControl
    {
        function fn = new function(); // Kết nối đến lớp function
        string query;

        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        // Khi load form, hiển thị tất cả thông tin khách hàng
        private void UC_CustomerDetails_Load(object sender, EventArgs e)
        {
            // Gọi hàm tải thông tin khách hàng từ database
            LoadCustomerDetails("SELECT * FROM Khachhang");
        }

        // Xử lý khi người dùng thay đổi lựa chọn trong comboBox tìm kiếm
        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = txtSearchBy.SelectedItem?.ToString();

            // Tùy theo lựa chọn mà tải dữ liệu khách hàng phù hợp
            if (selectedOption == "All Customer Details")
            {
                LoadCustomerDetails("SELECT * FROM Khachhang");
            }
            else if (selectedOption == "In Hotel Customer")
            {
                LoadCustomerDetails("SELECT * FROM Khachhang WHERE Thanhtoan = 'NO'");
            }
            else if (selectedOption == "CheckOut Customer")
            {
                LoadCustomerDetails("SELECT * FROM Khachhang WHERE Thanhtoan = 'YES'");
            }
        }

        // Hàm để tải dữ liệu khách hàng vào DataGridView
        private void LoadCustomerDetails(string query)
        {
            try
            {
                // Lấy dữ liệu từ cơ sở dữ liệu
                DataSet ds = fn.GetData(query);

                // Kiểm tra dữ liệu trả về có hợp lệ không
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // Hiển thị dữ liệu lên DataGridView
                    guna2DataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    // Nếu không có dữ liệu
                    MessageBox.Show("Không có dữ liệu khách hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi người dùng click vào cell của DataGridView
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có click vào cột hợp lệ không
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                string customerName = row.Cells["Tenkhachhang"].Value.ToString(); // Lấy thông tin khách hàng từ cột "Tenkhachhang"

                // Hiển thị thông tin chi tiết khách hàng khi click vào dòng trong DataGridView
                MessageBox.Show("Thông tin khách hàng: " + customerName);
            }
        }
    }
}