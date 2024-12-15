using Guna.UI2.WinForms;
using System;
using System.Collections;
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
    public class Function
    {
        // Một phương thức ví dụ để thực hiện truy vấn
        public DataTable ExecuteQuery(string query)
        {
            // Thực hiện truy vấn SQL ở đây và trả về kết quả dưới dạng DataTable
            DataTable dataTable = new DataTable();
            // Cần thêm code thực hiện truy vấn với SQL và điền dữ liệu vào dataTable
            return dataTable;
        }
    }
    public partial class UC_thanhtoan : UserControl
    {
        Function fn = new Function();
        string query;

       
        public UC_thanhtoan()
        {
            InitializeComponent();
        }

        private void UC_thanhtoan_Load(object sender, EventArgs e)
        {
           
        }
    }
}
