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


namespace làm_việc_nhóm_3.all_user_control
{
    public partial class uc_addroom : UserControl
    {
        function fn = new function();
        string query;
        string connectionString = "Data Source=DESKTOP-4RB4QAK\\QUANGKHAI;Initial Catalog=QLikhachsan;Integrated Security=True;TrustServerCertificate=True;";

        public uc_addroom()
        {
            InitializeComponent();
        }

        private void uc_addroom_Load(object sender, EventArgs e)
        {
            LoadRoomData();
        }

        private void btnaddroom_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có trường nào bị bỏ trống không
            if (txtrnumber.Text == "" || txttype.Text == "" || txtprice.Text == "" || txttypebed.Text == "")
            {
                MessageBox.Show("Nhập thông tin phòng sai. Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số phòng chỉ nhập tối đa 2 chữ số
            if (txtrnumber.Text.Length != 2 || !int.TryParse(txtrnumber.Text, out _))
            {
                MessageBox.Show("Số phòng chỉ được nhập 2 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ các ô nhập
            string rn = txtrnumber.Text;
            string t = txttype.Text;
            string bed = txttypebed.Text;
            Int64 price;

            // Kiểm tra giá trị nhập vào cho giá phòng
            if (!Int64.TryParse(txtprice.Text, out price))
            {
                MessageBox.Show("Giá phòng phải là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá phòng phải lớn hơn 100.000 và bé hơn 10.000.000
            if (price < 100000 || price > 10000000)
            {
                MessageBox.Show("Giá phòng phải lớn hơn 100.000 và nhỏ hơn 10.000.000.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Thêm phòng vào database
                    query = "INSERT INTO Phong (Phongtrong, Loaiphong, Giuong, Gia, Dadat) VALUES (@Phongtrong, @Loaiphong, @Giuong, @Gia, @Dadat)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Phongtrong", rn);
                        cmd.Parameters.AddWithValue("@Loaiphong", t);
                        cmd.Parameters.AddWithValue("@Giuong", bed);
                        cmd.Parameters.AddWithValue("@Gia", price);
                        cmd.Parameters.AddWithValue("@Dadat", "NO"); // Giá trị mặc định là "NO"

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới dữ liệu
                        LoadRoomData(); // Gọi hàm nạp lại dữ liệu vào dtaGView
                        clearAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm phòng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRoomData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    query = "SELECT IDphong, Phongtrong, Loaiphong, Giuong, Gia, Dadat FROM Phong";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu lên dtaGView
                        dtaGView.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phòng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearAll()
        {
            txtrnumber.Clear();
            txttype.SelectedIndex = -1;
            txttypebed.SelectedIndex = -1;
            txtprice.Clear();
        }

        private void uc_addroom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void uc_addroom_Enter(object sender, EventArgs e)
        {
            LoadRoomData();
        }
    }
}