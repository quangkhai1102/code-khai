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
    public partial class uc_register : UserControl
    {
        function fn = new function();
        string query;
        int roomId; // Lưu trữ ID phòng được chọn

        public uc_register()
        {
            InitializeComponent();
        }

        private void uc_register_Load(object sender, EventArgs e)
        {
            // Load danh sách loại giường từ bảng Phong
            query = "SELECT DISTINCT Giuong FROM Phong WHERE Dadat = 'NO'";
            setComboBox(query, cb_bed);
        }

        // Hàm thiết lập dữ liệu cho ComboBox
        public void setComboBox(string query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            try
            {
                combo.Items.Clear();
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        combo.Items.Add(sdr.GetString(i));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                sdr.Close();
            }
        }

        private void cb_bed_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn loại giường, load danh sách loại phòng tương ứng
            cb_room.Items.Clear();
            cb_nroom.Items.Clear();
            txt_price.Clear();

            query = "SELECT DISTINCT Loaiphong FROM Phong WHERE Giuong = '" + cb_bed.Text + "' AND Dadat = 'NO'";
            setComboBox(query, cb_room);
        }

        private void cb_room_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn loại phòng, load danh sách số phòng tương ứng
            cb_nroom.Items.Clear();
            txt_price.Clear();

            query = "SELECT Phongtrong FROM Phong WHERE Giuong = '" + cb_bed.Text + "' AND Loaiphong = '" + cb_room.Text + "' AND Dadat = 'NO'";
            setComboBox(query, cb_nroom);
        }

        private void cb_nroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chọn số phòng, hiển thị giá phòng và lưu ID phòng
            query = "SELECT Gia, IDphong FROM Phong WHERE Phongtrong = '" + cb_nroom.Text + "'";
            DataSet ds = fn.GetData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_price.Text = ds.Tables[0].Rows[0]["Gia"].ToString();
                roomId = int.Parse(ds.Tables[0].Rows[0]["IDphong"].ToString());
            }
        }

        private void btnaddpeople_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (txt_name.Text != "" && txt_contact.Text != "" && txt_na.Text != "" && cb_sex.Text != "" &&
                dtp_date.Text != "" && txt_id.Text != "" && txt_add.Text != "" && dtp_checkin.Text != "" && txt_price.Text != "")
            {
                // Lấy thông tin từ các trường nhập
                string name = txt_name.Text;
                Int64 phone = Int64.Parse(txt_contact.Text);
                string national = txt_na.Text;
                string sex = cb_sex.Text;
                string dob = dtp_date.Text;
                string id = txt_id.Text;
                string address = txt_add.Text;
                string checkin = dtp_checkin.Text;

                // Truy vấn thêm khách hàng vào bảng Khachhang
                query = "INSERT INTO Khachhang (Tenkhachhang, Sdt, Quoctich, Gioitinh, Ngaysinh, CCCD, Diachi, Nhanphong, IDphong) " +
                        "VALUES ('" + name + "', '" + phone + "', '" + national + "', '" + sex + "', '" + dob + "', '" + id + "', '" + address + "', '" + checkin + "', " + roomId + ")";
                fn.setData(query, "Khách hàng đã đăng ký thành công!");

                // Cập nhật trạng thái phòng trong bảng Phong
                query = "UPDATE Phong SET Dadat = 'YES' WHERE IDphong = " + roomId;
                fn.setData(query, "Cập nhật trạng thái phòng thành công!");

                // Xóa dữ liệu trong các trường nhập liệu
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            // Xóa sạch dữ liệu trong các trường nhập
            txt_name.Clear();
            txt_contact.Clear();
            txt_na.Clear();
            cb_sex.SelectedIndex = -1;
            dtp_date.ResetText();
            txt_id.Clear();
            txt_add.Clear();
            dtp_checkin.ResetText();
            cb_bed.SelectedIndex = -1;
            cb_room.SelectedIndex = -1;
            cb_nroom.Items.Clear();
            txt_price.Clear();
        }

        private void uc_register_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}